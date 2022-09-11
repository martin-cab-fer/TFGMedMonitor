using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using Model.HealthDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Model.UserProfileDao;
using Model.AdminDao;

namespace Model.HealthService
{
    public interface IHealthService
    {
        [Inject]
        IAnalyticDao AnalyticDao { set; }

        [Inject]
        IDoseDao DoseDao { set; }

        [Inject]
        IMedicineDao MedicineDao { set; }

        [Inject]
        IPrescriptionDao PrescriptionDao { set; }

        [Inject]
        IPatientDao PatientDao { set; }

        [Inject]
        IUserProfileDao UserProfileDao { set; }

        [Inject]
        IUserActionDao UserActionDao { set; }

        [Transactional]
        PatientBlock GetPatientList(long userId, int startIndex, int count);

        [Transactional]
        PatientDetails GetPatientDetails(long patientId);

        [Transactional]
        AnalyticBlock GetPatientAnalytics(long patientId, int startIndex, int count);

        [Transactional]
        Analytic AddPatientAnalytic(string patient, string attendant, float weight, string procedure,
            string observations);

        [Transactional]
        PrescriptionBlock GetPatientPrescription(string patient, int startIndex, int count);

        [Transactional]
        Prescription AddPatientPrescription(string user, string patient, long medicineId, int frequency, string admin);

        [Transactional]
        void RemovePatientPrescription(string user, long prescriptionId);

        [Transactional]
        DoseBlock GetPatientDoses(long prescriptionId, int startIndex, int count);

        [Transactional]
        Dose AddPatientDose(long prescriptionId, string admin, string notes);

    }
}
