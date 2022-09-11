using Ninject;
using System;
using System.Collections.Generic;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Model.HealthDao;
using Model.UserProfileDao;
using Model.UserService;
using Model.AdminDao;

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

        [Inject]
        IMedicineDao MedicineDao { set; }

        [Inject]
        IUserActionDao UserActionDao { set; }

        [Transactional]
        long CreateMedicine(string user, int regNum, string mName, string lName, DateTime authDate, string mStatus,
            DateTime statusDate, string ATCCode, string activePr, int activePrN, bool commerc,
            bool yellowT, string observ, string subst, bool affectsC, bool supplyI);

        [Transactional]
        MedicineBlock GetMedicineSearch(string name, List<string> activePrin, int startIndex, int count);

        [Transactional]
        long CreatePatient(string user, string patientName, DateTime birthDate, string info);

        [Transactional]
        bool AssignDoctorToPatient(string doctor, string patient);

        [Transactional]
        bool RemoveDoctorFromPatient(string doctor, string patient);

        [Transactional]
        bool AssignEmployeeToPatient(string employee, string patient);

        [Transactional]
        bool RemoveEmployeeFromPatient(string employee, string patient);

        [Transactional]
        ChatMessage SendChatMessage(string sender, string addressee, string title, string message);

        [Transactional]
        ChatMessageBlock GetChatMessages(string userName, int startIndex, int count);

        [Transactional]
        UserActionBlock GetUserActions(string user, int startIndex, int count);
    }
}
