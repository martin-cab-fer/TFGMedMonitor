using Model.HealthDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AdminService
{
    public class AdminService : IAdminService
    {
        [Inject]
        public IPatientDao PatientDao { private get; set; }

        public void AddChatMessage(long sender, long addressee, string title, string message)
        {
            throw new NotImplementedException();
        }

        public void AssignDoctorToPatient(long doctorId, long patientId)
        {
            throw new NotImplementedException();
        }

        public void AssignEmployeeToPatient(long employeeId, long patientId)
        {
            throw new NotImplementedException();
        }

        public ChatMessageBlock GetChatMessages(long usrId, int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public UserBlock GetDoctorList(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public UserBlock GetEmployeeList(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public PatientBlock GetPatientList(long userId, bool isDoctor, int startIndex, int count)
        {
            throw new NotImplementedException();
        }
    }
}
