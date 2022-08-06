using Model.HealthDao;
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

        public AnalyticBlock GetPatientAnalytics(long patientId, int startIndex, int count)
        {
            List<Analytic> analytics =
                AnalyticDao.FindByPatientId(patientId, startIndex, count + 1);

            bool existMoreAnalytics = (analytics.Count == count + 1);

            if (existMoreAnalytics)
                analytics.RemoveAt(count);

            return new AnalyticBlock(analytics, existMoreAnalytics);
        }

        public void AddPatientAnalytic(long patientId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void AddPatientDose(long patientId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void AddPatientPrescription(long patientId)
        {
            throw new NotImplementedException();
        }

        public MedicineBlock GetMedicineSearch(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public DoseBlock GetPatientDoses(long patientId, int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public void GetPatientPrescription(long patientId, int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public void RemovePatientPrescription(long patientId)
        {
            throw new NotImplementedException();
        }
    }
}
