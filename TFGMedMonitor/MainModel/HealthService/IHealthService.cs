using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using Model.HealthDao;
using Es.Udc.DotNet.ModelUtil.Transactions;

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

        [Transactional]
        AnalyticBlock GetPatientAnalytics(long patientId, int startIndex, int count);

        [Transactional]
        void AddPatientAnalytic(long patientId, DateTime date);

        [Transactional]
        void GetPatientPrescription(long patientId, int startIndex, int count);

        [Transactional]
        void AddPatientPrescription(long patientId);

        [Transactional]
        void RemovePatientPrescription(long patientId);

        [Transactional]
        MedicineBlock GetMedicineSearch(int startIndex, int count);

        [Transactional]
        DoseBlock GetPatientDoses(long patientId, int startIndex, int count);

        [Transactional]
        void AddPatientDose(long patientId, DateTime date);

    }
}
