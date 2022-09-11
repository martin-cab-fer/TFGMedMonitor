using Es.Udc.DotNet.ModelUtil.Transactions;
using Model.AdminDao;
using Model.HealthDao;
using Model.HealthService;
using Model.UserProfileDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AdminService
{
    public class AdminService : IAdminService
    {
        [Inject]
        public IUserProfileDao UserProfileDao { private get; set; }

        [Inject]
        public IPatientDao PatientDao { private get; set; }

        [Inject]
        public IChatMessageDao ChatMessageDao { private get; set; }

        [Inject]
        public IMedicineDao MedicineDao { private get; set; }

        [Inject]
        public IUserActionDao UserActionDao { private get; set; }

        [Transactional]
        public long CreateMedicine(string user, int regNum, string mName, string lName, DateTime authDate, string mStatus,
            DateTime statusDate, string ATCCode, string activePr, int activePrN, bool commerc,
            bool yellowT, string observ, string subst, bool affectsC, bool supplyI)
        {
            UserProfile u = UserProfileDao.FindByLoginName(user);
            if (u == null || u.userType != 3)
                return -1;

            if (regNum < 0 || mName == null || lName == null || authDate == null || mStatus == null ||
                statusDate == null || ATCCode == null || activePr == null || activePrN <= 0 ||
                observ == null)
            {
                return -1;
            }

            Medicine m = new Medicine();
            m.registerNumber = regNum;
            m.medName = mName;
            m.labName = lName;
            m.authDate = authDate;
            m.medStatus = mStatus;
            m.statusDate = statusDate;
            m.ATCCode = ATCCode;
            m.activePrinc = activePr;
            m.activePrincN = (short)activePrN;
            m.commercialized = commerc ? "SI" : "NO";
            m.yellowTriangle = yellowT ? "SI" : "NO";
            m.observations = observ;
            m.substitutes = subst;
            m.affectsConduction = affectsC ? "SI" : "NO";
            m.supplyIssues = supplyI ? "SI" : "NO";

            MedicineDao.Create(m);
            UserActionDao.LogUserAction(u, 7, m.medName, m.registerNumber);
            return m.medicineId;
        }

        [Transactional]
        public MedicineBlock GetMedicineSearch(string name, List<string> activePrin, int startIndex, int count)
        {
            string n = (name == null) ? "" : name;

            List<string> aP = (activePrin == null) ? new List<string>() : activePrin;

            if (aP.Count == 0 && n == "")
                return null;

            List<Medicine> medicines =
               MedicineDao.GetMedicineSearch(n, aP, startIndex, count);

            bool existMoreMedicines = (medicines.Count == count + 1);

            if (existMoreMedicines)
            {
                while (medicines.Count >= count + 1)
                {
                    medicines.RemoveAt(count);
                }
            }

            return new MedicineBlock(medicines, existMoreMedicines);
        }

        [Transactional]
        public long CreatePatient(string user, string patientName, DateTime birthDate, string info)
        {
            UserProfile u = UserProfileDao.FindByLoginName(user);
            if (u == null || u.userType != 3)
                return -1;

            Patient p = new Patient();
            p.patientName = patientName;
            p.birthDate = birthDate;
            p.info = info;

            PatientDao.Create(p);
            UserActionDao.LogUserAction(u, 6, p.patientName, 0);
            return p.patientId;
        }

        [Transactional]
        public bool AssignDoctorToPatient(string doctor, string patient)
        {
            Patient p = PatientDao.FindByFullName(patient);
            UserProfile d = UserProfileDao.FindByLoginName(doctor);
            if(p != null && d != null)
            {
                if (d.userType != 2)
                    return false;
                PatientDao.AssignDoctor(p, d);
            }
            return true;
        }

        [Transactional]
        public bool RemoveDoctorFromPatient(string doctor, string patient)
        {
            Patient p = PatientDao.FindByFullName(patient);
            UserProfile d = UserProfileDao.FindByLoginName(doctor);
            if (p != null && d != null)
            {
                PatientDao.UnassignDoctor(p, d);
                return true;
            }
            else
                return false;
        }

        [Transactional]
        public bool AssignEmployeeToPatient(string employee, string patient)
        {
            Patient p = PatientDao.FindByFullName(patient);
            UserProfile e = UserProfileDao.FindByLoginName(employee);
            if (p != null && e != null)
            {
                if (e.userType != 1)
                    return false;
                PatientDao.AssignEmployee(p, e);
            }
            return true;
        }

        [Transactional]
        public bool RemoveEmployeeFromPatient(string employee, string patient)
        {
            Patient p = PatientDao.FindByFullName(patient);
            UserProfile e = UserProfileDao.FindByLoginName(employee);
            if (p != null && e != null)
            {
                PatientDao.UnassignEmployee(p, e);
                return true;
            }
            else
                return false;
        }

        [Transactional]
        public ChatMessage SendChatMessage(string sender, string addressee, string title, string message)
        {
            UserProfile s = UserProfileDao.FindByLoginName(sender);
            UserProfile a = UserProfileDao.FindByLoginName(addressee);
            if (s == null)
                return null;
            if (a == null)
                return null;
            if (title.Length == 0)
                return null;
            if (message.Length == 0)
                return null;

            ChatMessage c = new ChatMessage
            {
                UserProfile = a,
                UserProfile1 = s,
                creationDate = DateTime.Now,
                title = title,
                messageText = message
            };

            ChatMessageDao.Create(c);
            return c;
        }

        [Transactional]
        public ChatMessageBlock GetChatMessages(string userName, int startIndex, int count)
        {
            UserProfile u = UserProfileDao.FindByLoginName(userName);
            if (u == null)
                return null;

            List<ChatMessage> messages =
                ChatMessageDao.FindMessagesByUser(u.usrId, startIndex, count + 1);

            bool existMoreMessages = (messages.Count == count + 1);

            if (existMoreMessages)
                messages.RemoveAt(count);

            return new ChatMessageBlock(messages, existMoreMessages);
        }

        public UserActionBlock GetUserActions(string user, int startIndex, int count)
        {
            long uId = -1;

            if(user != null && user != "")
            {
                UserProfile u = UserProfileDao.FindByLoginName(user);
                if (u != null)
                    uId = u.usrId;
            }

            List<UserAction> actions =
                UserActionDao.GetUserActions(uId, startIndex, count + 1);

            bool existMoreActions = (actions.Count == count + 1);

            if (existMoreActions)
                actions.RemoveAt(count);

            return new UserActionBlock(actions, existMoreActions);
        }
    }
}
