using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using Model.HealthDao;

namespace Model.HealthService
{
    public interface IHealthService
    {
        [Inject]
        IHealthDao HealthDao { set; }

        void GetPatientsAssignedToDoctor(long doctorId, int startIndex, int count);

        void GetPatientsAssignedToEmployee(long employeeId, int startIndex, int count);

        void GetPatientAnalytics(long patientId, int startIndex, int count);

        void AddPatientAnalytic(long patientId, DateTime date);

        void GetPatientPrescription(long patientId);

        void AddPatientPrescription(long patientId);

        void RemovePatientPrescription(long patientId);

        void GetMedicineSearch();

        void AddPatientDosis(long patientId, DateTime date);

    }
}
