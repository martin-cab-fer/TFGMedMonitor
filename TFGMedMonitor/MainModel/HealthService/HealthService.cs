using Es.Udc.DotNet.ModelUtil.Transactions;
using Model.AdminDao;
using Model.HealthDao;
using Model.UserProfileDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthService
{
    public class HealthService : IHealthService
    {
        [Inject]
        public IAnalyticDao AnalyticDao { private get; set; }

        [Inject]
        public IDoseDao DoseDao { private get; set; }

        [Inject]
        public IMedicineDao MedicineDao { private get; set; }

        [Inject]
        public IPrescriptionDao PrescriptionDao { private get; set; }

        [Inject]
        public IPatientDao PatientDao { private get; set; }

        [Inject]
        public IUserProfileDao UserProfileDao { private get; set; }

        [Transactional]
        public PatientBlock GetPatientList(long userId, int startIndex, int count)
        {
            List<Patient> patients =
                PatientDao.GetPatientsPaged(startIndex, count + 1);

            bool existMorePatients = (patients.Count == count + 1);

            if (existMorePatients)
                patients.RemoveAt(count);

            List<PatientDetails> pd = new List<PatientDetails>();
            foreach (Patient p in patients) {
                pd.Add(GetPatientDetails(p));
            }

            return new PatientBlock(pd, existMorePatients);
        }

        [Transactional]
        public PatientDetails GetPatientDetails(long patientId)
        {
            Patient p =
                PatientDao.Find(patientId);

            if (p == null)
                return null;

            return GetPatientDetails(p);
        }

        private PatientDetails GetPatientDetails(Patient p)
        {
            PrescriptionBlock pb = GetPatientPrescription(p.patientName, 0, 3);
            AnalyticBlock ab = GetPatientAnalytics(p.patientId, 0, 3);

            List<string> docs = PatientDao.GetAssignedDoctors(p);
            List<string> emps = PatientDao.GetAssignedEmployees(p);

            return new PatientDetails(p, pb, ab, docs, emps);
        }

        [Transactional]
        public AnalyticBlock GetPatientAnalytics(long patientId, int startIndex, int count)
        {
            List<Analytic> analytics =
                AnalyticDao.FindByPatientId(patientId, startIndex, count + 1);

            bool existMoreAnalytics = (analytics.Count == count + 1);

            if (existMoreAnalytics)
                analytics.RemoveAt(count);

            return new AnalyticBlock(analytics, existMoreAnalytics);
        }

        [Transactional]
        public Analytic AddPatientAnalytic(string patient, string attendant, float weight,
            string procedure, string observations)
        {
            Patient p = PatientDao.FindByFullName(patient);
            UserProfile at = UserProfileDao.FindByLoginName(attendant);
            if (p == null)
                return null;
            if (at == null)
                return null;

            Analytic a = new Analytic
            {
                Patient = p,
                measurementTime = DateTime.Now,
                UserProfile = at,
                patientWeight = weight,
                usedProcedure = procedure,
                observations = observations
            };
            AnalyticDao.Create(a);
            return a;
        }

        [Transactional]
        public PrescriptionBlock GetPatientPrescription(string patient, int startIndex, int count)
        {
            Patient p = PatientDao.FindByFullName(patient);
            if (p == null)
                return null;
            
            List<Prescription> prescriptions =
               PrescriptionDao.FindByPatientId(p.patientId, startIndex, count + 1);

            bool existMorePrescriptions = (prescriptions.Count == count + 1);

            if (existMorePrescriptions)
                prescriptions.RemoveAt(count);

            return new PrescriptionBlock(prescriptions, existMorePrescriptions);
        }

        [Transactional]
        public Prescription AddPatientPrescription(string patient, long medicineId, int frequency, string admin)
        {
            Patient p = PatientDao.FindByFullName(patient);
            Medicine m = MedicineDao.Find(medicineId);
            if (p == null)
                return null;
            if (m == null)
                return null;

            Prescription pr = new Prescription
            {
                Patient1 = p,
                creationDate = DateTime.Now,
                Medicine1 = m,
                frequency = (short)frequency,
                administration = admin
            };

            PrescriptionDao.Create(pr);
            return pr;
        }

        [Transactional]
        public void RemovePatientPrescription(long prescriptionId)
        {
            Prescription pr = PrescriptionDao.Find(prescriptionId);
            if (pr == null)
                return;
            PrescriptionDao.Remove(prescriptionId);
        }

        [Transactional]
        public DoseBlock GetPatientDoses(long prescriptionId, int startIndex, int count)
        {
            Prescription pr = PrescriptionDao.Find(prescriptionId);
            if (pr == null)
                return null;

            List<Dose> doses =
               DoseDao.FindByPrescriptionId(prescriptionId, startIndex, count + 1);

            bool existMoreDoses = (doses.Count == count + 1);

            if (existMoreDoses)
                doses.RemoveAt(count);

            return new DoseBlock(doses, existMoreDoses);

        }

        [Transactional]
        public Dose AddPatientDose(long prescriptionId, string admin, string notes)
        {
            Prescription pr = PrescriptionDao.Find(prescriptionId);
            UserProfile u = UserProfileDao.FindByLoginName(admin);
            if (pr == null || u == null)
                return null;

            Dose d = new Dose
            {
                Prescription = pr,
                administrationTime = DateTime.Now,
                UserProfile = u,
                notes = notes
            };

            DoseDao.Create(d);
            return d;
        }
    }
}
