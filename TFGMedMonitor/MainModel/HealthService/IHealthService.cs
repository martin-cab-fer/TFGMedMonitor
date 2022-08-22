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

        [Transactional]
        PatientBlock GetPatientList(long userId, int startIndex, int count);

        [Transactional]
        PatientDetails GetPatientDetails(long patientId);

        [Transactional]
        AnalyticBlock GetPatientAnalytics(long patientId, int startIndex, int count);

        [Transactional]
        Analytic AddPatientAnalytic(long patientId, long attendant, float weight, string procedure,
            string observations);

        [Transactional]
        PrescriptionBlock GetPatientPrescription(long patientId, int startIndex, int count);

        [Transactional]
        Prescription AddPatientPrescription(long patientId, long medicineId, int frequency, string admin);

        [Transactional]
        void RemovePatientPrescription(long prescriptionId);

        [Transactional]
        DoseBlock GetPatientDoses(long prescriptionId, int startIndex, int count);

        [Transactional]
        Dose AddPatientDose(long prescriptionId, long adminId, string notes);

    }
}
