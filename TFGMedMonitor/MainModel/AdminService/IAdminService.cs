using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Model.HealthDao;
using Model.UserProfileDao;

namespace Model.AdminService
{
    public interface IAdminService
    {
        [Inject]
        IUserProfileDao UserProfileDao { set; }

        [Inject]
        IPatientDao PatientDao { set; }

        [Inject]
        IChatMessageDao ChatMessageDao { set; }

        [Transactional]
        void AssignDoctorToPatient(long doctorId, long patientId);

        [Transactional]
        void RemoveDoctorFromPatient(long doctorId, long patientId);

        [Transactional]
        void AssignEmployeeToPatient(long employeeId, long patientId);

        [Transactional]
        void RemoveEmployeeFromPatient(long employeeId, long patientId);

        [Transactional]
        ChatMessage AddChatMessage(long sender, long addressee, string title, string message);

        [Transactional]
        ChatMessageBlock GetChatMessages(long usrId, int startIndex, int count);
    }
}
