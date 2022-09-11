using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ninject;
using System.Transactions;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Model.AdminService;
using Model.HealthDao;
using Model.UserService;
using Model.UserProfileDao;
using Model;
using Model.AdminDao;
using Model.HealthService;

namespace Test
{
    [TestClass]
    public class IAdminServiceTest
    {
        // Variables used in several tests are initialized here
        #region User Data
        private const string clearPassword = "password";
        private const string firstName = "name";
        private const string lastName = "lastName";
        private const string email = "user@gmail.es";
        private const string language = "es";
        private const string country = "ES";
        #endregion userData

        #region Medicine Data
        private const int regNum = 44099;
        private const string mName = "OCTOCAINE 20 MG/ML + 0,01 MG/ML SOLUCIÓN INYECTABLE";
        private const string lName = "Laboratorios Clarben S.A.";
        private const string mStatus = "Autorizado";
        private const string ATCCode = "N01BB52";
        private const string activePr = "LIDOCAINA HIDROCLORURO, EPINEFRINA BITARTRATO";
        private const int activePrN = 2;
        private const bool comm = true;
        private const bool yellowT = false;
        private const string observ = "Medicamento Sujeto A Prescripción Médica";
        private const bool affectsC = true;
        private const bool supplyI = false;

        #endregion Medicine Data

        private static IKernel kernel;
        private static IAdminService adminService;
        private static IUserService userService;
        private static IHealthService healthService;
        private static IUserProfileDao userDao;
        private static IMedicineDao medicineDao;
        private static IPatientDao patientDao;

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

        public long CreateValidPatient(string user, string name)
        {
            return adminService.CreatePatient(user, name, DateTime.Now, "");
        }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            adminService = kernel.Get<IAdminService>();
            userDao = kernel.Get<IUserProfileDao>();
            userService = kernel.Get<IUserService>();
            healthService = kernel.Get<IHealthService>();
            medicineDao = kernel.Get<IMedicineDao>();
            patientDao = kernel.Get<IPatientDao>();
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
        public void TestCreateMedicine()
        {
            using (var scope = new TransactionScope())
            {
                DateTime t = DateTime.Now;

                long u = CreateValidUser("admin", 3);
                UserProfileDetails admin = userService.FindUserProfileDetails(u);

                long medicineId = adminService.CreateMedicine(admin.LoginName, regNum, mName, lName, t, mStatus, t, ATCCode,
                    activePr, activePrN, comm, yellowT, observ, "", affectsC, supplyI);
                Medicine m = medicineDao.Find(medicineId);

                Assert.AreEqual(m.registerNumber, regNum);
                Assert.AreEqual(m.medName, mName);
                Assert.AreEqual(m.labName, lName);
                Assert.AreEqual(m.authDate, t);
                Assert.AreEqual(m.medStatus, mStatus);
                Assert.AreEqual(m.statusDate, t);
                Assert.AreEqual(m.ATCCode, ATCCode);
                Assert.AreEqual(m.activePrinc, activePr);
                Assert.AreEqual(m.activePrincN, activePrN);
                Assert.AreEqual(m.commercialized, "SI");
                Assert.AreEqual(m.yellowTriangle, "NO");
                Assert.AreEqual(m.observations, observ);
                Assert.AreEqual(m.substitutes, "");
                Assert.AreEqual(m.affectsConduction, "SI");
                Assert.AreEqual(m.supplyIssues, "NO");
            }
        }

        [TestMethod]
        public void TestGetMedicineSearch()
        {
            using (var scope = new TransactionScope())
            {
                DateTime t = DateTime.Now;

                long u = CreateValidUser("admin", 3);
                UserProfileDetails admin = userService.FindUserProfileDetails(u);

                long medicineId = adminService.CreateMedicine(admin.LoginName, regNum, mName, lName, t, mStatus, t, ATCCode,
                    activePr, activePrN, comm, yellowT, observ, "", affectsC, supplyI);
                Medicine p = medicineDao.Find(medicineId);

                MedicineBlock medB = adminService.GetMedicineSearch(mName, null, 0, 10);

                Assert.IsTrue(medB.Medicines.Count == 1);
                Assert.IsTrue(medB.Medicines.Contains(p));

                List<string> prin = new List<string>();
                prin.Add("LIDOCAINA");
                prin.Add("EPINEFRINA");

                medB = adminService.GetMedicineSearch("", prin, 0, 10);

                Assert.IsTrue(medB.Medicines.Count == 1);
                Assert.IsTrue(medB.Medicines.Contains(p));

                medB = adminService.GetMedicineSearch("mock", null, 0, 10);

                Assert.IsTrue(medB.Medicines.Count == 0);
            }
        }

        [TestMethod]
        public void TestCreatePatient()
        {
            using (var scope = new TransactionScope())
            {
                string pName = "paco rodríguez";
                DateTime bDate = DateTime.Now;
                string info = "null";

                long u = CreateValidUser("admin", 3);
                UserProfileDetails admin = userService.FindUserProfileDetails(u);

                long patientId = adminService.CreatePatient(admin.LoginName, pName, bDate, info);
                Patient p = patientDao.Find(patientId);

                Assert.AreEqual(p.patientName, pName);
                Assert.AreEqual(p.birthDate, bDate);
                Assert.AreEqual(p.info, info);

            }
        }

        [TestMethod]
        public void TestAssignDoctorToPatient()
        {
            using (var scope = new TransactionScope())
            {
                long doctorId1 = CreateValidUser("doc1", 2);
                long doctorId2 = CreateValidUser("doc2", 2);
                long adminId = CreateValidUser("admin", 3);

                UserProfileDetails doc1 = userService.FindUserProfileDetails(doctorId1);
                UserProfileDetails doc2 = userService.FindUserProfileDetails(doctorId2);
                UserProfileDetails admin = userService.FindUserProfileDetails(adminId);

                long patientId = CreateValidPatient(admin.LoginName, "patient");
                PatientDetails pat = healthService.GetPatientDetails(patientId);

                //Doctor assignation
                adminService.AssignDoctorToPatient(doc1.LoginName, pat.FullName);
                adminService.AssignDoctorToPatient(doc2.LoginName, pat.FullName);

                UserProfile user1 = userDao.Find(doctorId1);
                UserProfile user2 = userDao.Find(doctorId2);

                Patient p = patientDao.Find(patientId);

                //We check the first doctor is properly assigned
                Assert.IsTrue(p.UserProfile.Contains(user1));

                //We remove the second doctor and check proper removal
                adminService.RemoveDoctorFromPatient(doc2.LoginName, pat.FullName);

                p = patientDao.Find(patientId);
                Assert.IsFalse(p.UserProfile.Contains(user2));
            }
        }

        [TestMethod]
        public void TestAssignEmployeeToPatient()
        {
            using (var scope = new TransactionScope())
            {
                long employeeId1 = CreateValidUser("emp1", 1);
                long employeeId2 = CreateValidUser("emp2", 1);
                long adminId = CreateValidUser("admin", 3);

                UserProfileDetails emp1 = userService.FindUserProfileDetails(employeeId1);
                UserProfileDetails emp2 = userService.FindUserProfileDetails(employeeId2);
                UserProfileDetails admin = userService.FindUserProfileDetails(adminId);

                long patientId = CreateValidPatient(admin.LoginName, "patient");
                PatientDetails pat = healthService.GetPatientDetails(patientId);

                //Employee assignation
                adminService.AssignEmployeeToPatient(emp1.LoginName, pat.FullName);
                adminService.AssignEmployeeToPatient(emp2.LoginName, pat.FullName);

                UserProfile user1 = userDao.Find(employeeId1);
                UserProfile user2 = userDao.Find(employeeId2);

                Patient p = patientDao.Find(patientId);

                //We check the first employee is properly assigned
                Assert.IsTrue(p.UserProfile1.Contains(user1));

                //We remove the second employee and check proper removal
                adminService.RemoveEmployeeFromPatient(emp2.LoginName, pat.FullName);

                p = patientDao.Find(patientId);
                Assert.IsFalse(p.UserProfile1.Contains(user2));
            }
        }

        [TestMethod]
        public void TestGetChatMessages()
        {
            using (var scope = new TransactionScope())
            {
                long doctorId = CreateValidUser("doc", 1);
                long employeeId = CreateValidUser("emp", 2);

                UserProfileDetails doctor = userService.FindUserProfileDetails(doctorId);
                UserProfileDetails employee = userService.FindUserProfileDetails(employeeId);

                ChatMessage m1 = adminService.SendChatMessage(doctor.LoginName, employee.LoginName, "hello", "hi");
                ChatMessage m2 = adminService.SendChatMessage(employee.LoginName, doctor.LoginName, "hello2", "hello");

                ChatMessageBlock ms1 = adminService.GetChatMessages(doctor.LoginName, 0, 10);
                ChatMessageBlock ms2 = adminService.GetChatMessages(employee.LoginName, 0, 10);

                Assert.AreEqual(ms1.Messages.Count, 2);
                Assert.AreEqual(ms2.Messages.Count, 2);
                Assert.IsTrue(ms1.Messages.Contains(m1));
                Assert.IsTrue(ms1.Messages.Contains(m2));
                Assert.IsTrue(ms2.Messages.Contains(m1));
                Assert.IsTrue(ms2.Messages.Contains(m2));
            }
        }
    }
}
