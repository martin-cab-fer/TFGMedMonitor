using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ninject;
using System.Transactions;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Model.HealthService;
using Model.HealthDao;
using Model.UserProfileDao;
using Model.UserService;
using Model.AdminService;
using Model.AdminDao;
using Model;

namespace Test
{
    [TestClass]
    public class IHealthServiceTest
    {
        // Variables used in several tests are initialized here
        private const string clearPassword = "password";
        private const string firstName = "name";
        private const string lastName = "lastName";
        private const string email = "user@gmail.es";
        private const string language = "es";
        private const string country = "ES";

        private static IKernel kernel;
        private static IHealthService healthService;
        private static IUserService userService;
        private static IAdminService adminService;

        private TransactionScope transaction;

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the
        /// current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        public long CreateValidUser(string name, int userType)
        {
            return userService.RegisterUser(name, clearPassword,
                        new UserProfileDetails(name, firstName, lastName, email, language,
                        country, userType));
        }

        public long CreateValidMedicine()
        {
            return adminService.CreateMedicine(99999, "mock", "mock Ltd", DateTime.Now, "Autorizado",
                DateTime.Now, "N01BB99", "cocacola", 1, true, true, "none", "", false, false);
        }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            adminService = kernel.Get<IAdminService>();
            userService = kernel.Get<IUserService>();
            healthService = kernel.Get<IHealthService>();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
        }

        #endregion Additional test attributes

        [TestMethod]
        public void TestGetPatientList()
        {
            using (var scope = new TransactionScope())
            {
                DateTime t = DateTime.Now;
                long patientId1 = adminService.CreatePatient("paco", t, "info");

                long patientId2 = adminService.CreatePatient("pedro", t, "info");

                long medicineId = CreateValidMedicine();

                long doctorId = CreateValidUser("juan", 2);

                PatientDetails pat1 = healthService.GetPatientDetails(patientId1);

                PatientDetails pat2 = healthService.GetPatientDetails(patientId2);

                UserProfileDetails doc = userService.FindUserProfileDetails(doctorId);

                Prescription pr1 = healthService.AddPatientPrescription(pat1.FullName, medicineId,
                    2, "pills");

                Prescription pr2 = healthService.AddPatientPrescription(pat2.FullName, medicineId,
                    2, "intravenous");

                Prescription pr3 = healthService.AddPatientPrescription(pat2.FullName, medicineId,
                    4, "pills");

                Analytic a = healthService.AddPatientAnalytic(pat1.FullName, doc.LoginName, 55, "bloodletting", "all ok");

                PatientDetails p1 = healthService.GetPatientDetails(patientId1);
                PatientDetails p2 = healthService.GetPatientDetails(patientId2);

                Assert.AreEqual(p1.LastAnalytics.Analytics.Count, 1);
                Assert.AreEqual(p2.LastAnalytics.Analytics.Count, 0);
                Assert.AreEqual(p1.Prescriptions.Prescriptions.Count, 1);
                Assert.AreEqual(p2.Prescriptions.Prescriptions.Count, 2);
                Assert.IsTrue(p1.Prescriptions.Prescriptions.Contains(pr1));
                Assert.IsTrue(p2.Prescriptions.Prescriptions.Contains(pr2));
                Assert.IsTrue(p2.Prescriptions.Prescriptions.Contains(pr3));
            }
        }

        [TestMethod]
        public void TestGetPatientDetails()
        {
            using (var scope = new TransactionScope())
            {
                DateTime t = DateTime.Now;
                long patientId = adminService.CreatePatient("paco", t, "info");

                PatientDetails p = healthService.GetPatientDetails(patientId);

                Assert.AreEqual(p.FullName, "paco");
                Assert.AreEqual(p.BirthDate, t);
                Assert.AreEqual(p.Info, "info");
                Assert.AreEqual(p.LastAnalytics.Analytics.Count, 0);
                Assert.AreEqual(p.Prescriptions.Prescriptions.Count, 0);
            }

        }

        [TestMethod]
        public void TestPatientAnalytics()
        {
            using (var scope = new TransactionScope())
            {
                DateTime t = DateTime.Now;
                long patientId = adminService.CreatePatient("paco", t, "info");

                long doctorId = CreateValidUser("juan", 2);

                UserProfileDetails doc = userService.FindUserProfileDetails(doctorId);

                PatientDetails p = healthService.GetPatientDetails(patientId);

                Analytic a = healthService.AddPatientAnalytic(p.FullName, doc.LoginName, 55, "bloodletting", "all ok");

                p = healthService.GetPatientDetails(patientId);

                Assert.IsTrue(p.LastAnalytics.Analytics.Count == 1);
                Analytic fa = p.LastAnalytics.Analytics.ToArray()[0];
                Assert.AreEqual(fa.patientId, a.patientId);
                Assert.AreEqual(fa.attendant, a.attendant);
                Assert.AreEqual(fa.patientWeight, a.patientWeight);
                Assert.AreEqual(fa.usedProcedure, a.usedProcedure);
                Assert.AreEqual(fa.observations, a.observations);
            }
        }

        [TestMethod]
        public void TestPatientPrescription()
        {
            using (var scope = new TransactionScope())
            {
                DateTime t = DateTime.Now;
                long patientId = adminService.CreatePatient("paco", t, "info");

                long medicineId = CreateValidMedicine();

                PatientDetails pat = healthService.GetPatientDetails(patientId);

                Prescription pr = healthService.AddPatientPrescription(pat.FullName, medicineId,
                    2, "pills");

                PatientDetails p = healthService.GetPatientDetails(patientId);

                Assert.IsTrue(p.Prescriptions.Prescriptions.Count == 1);
                Assert.IsTrue(p.Prescriptions.Prescriptions.Contains(pr));
            }
        }

        [TestMethod]
        public void TestPatientDoses()
        {
            using (var scope = new TransactionScope())
            {
                DateTime t = DateTime.Now;
                long patientId = adminService.CreatePatient("paco", t, "info");

                long medicineId = CreateValidMedicine();

                long doctorId = CreateValidUser("juan", 2);

                UserProfileDetails doctor = userService.FindUserProfileDetails(doctorId);

                PatientDetails pat = healthService.GetPatientDetails(patientId);

                Prescription pr = healthService.AddPatientPrescription(pat.FullName, medicineId,
                    2, "pills");

                Dose d = healthService.AddPatientDose(pr.prescriptionId, doctor.LoginName, "all ok");

                DoseBlock db = healthService.GetPatientDoses(pr.prescriptionId, 0, 10);

                Assert.IsTrue(db.Doses.Count == 1);
                Dose fd = db.Doses.ToArray()[0];
                Assert.AreEqual(fd.prescriptionId, d.prescriptionId);
                Assert.AreEqual(fd.administrator, d.administrator);
                Assert.AreEqual(fd.notes, d.notes);
            }
        }
    }
}
