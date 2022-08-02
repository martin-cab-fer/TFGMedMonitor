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
        void GetDoctorList();

        [Transactional]
        void GetEmployeeList();

        [Transactional]
        void GetPatientList();

        [Transactional]
        void AssignDoctorToPatient(long doctorId, long patientId);

        [Transactional]
        void AssignEmployeeToPatient(long employeeId, long patientId);

        void AddChatMessage(long sender, long addressee, string title, string message);

        void GetChatMessages(long usrId);
    }
}
