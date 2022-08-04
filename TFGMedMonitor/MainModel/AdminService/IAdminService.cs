using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using Model.AdminDao;
using Es.Udc.DotNet.ModelUtil.Transactions;

namespace Model.AdminService
{
    public interface IAdminService
    {
        [Inject]
        IAdminDao AdminDao { set; }

        [Transactional]
        UserBlock GetDoctorList(int startIndex, int count);

        [Transactional]
        UserBlock GetEmployeeList(int startIndex, int count);

        [Transactional]
        PatientBlock GetPatientList(long userId, bool isDoctor, int startIndex, int count);

        [Transactional]
        void AssignDoctorToPatient(long doctorId, long patientId);

        [Transactional]
        void AssignEmployeeToPatient(long employeeId, long patientId);

        [Transactional]
        void AddChatMessage(long sender, long addressee, string title, string message);

        [Transactional]
        ChatMessageBlock GetChatMessages(long usrId, int startIndex, int count);
    }
}
