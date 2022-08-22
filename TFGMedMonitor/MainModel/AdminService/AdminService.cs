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

        [Transactional]
        public long CreateMedicine(int regNum, string mName, string lName, DateTime authDate, string mStatus,
            DateTime statusDate, string ATCCode, string activePr, int activePrN, bool commerc,
            bool yellowT, string observ, string subst, bool affectsC, bool supplyI)
        {
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
            return m.medicineId;
        }

        [Transactional]
        public MedicineBlock GetMedicineSearch(string name, List<string> activePrin, int startIndex, int count)
        {
            if (name == null)
                return null;

            if (activePrin == null && name == "")
                return null;

            List<Medicine> medicines =
               MedicineDao.GetMedicineSearch(name, activePrin, startIndex, count);

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
        public long CreatePatient(string patientName, DateTime birthDate, string info)
        {
            Patient p = new Patient();
            p.patientName = patientName;
            p.birthDate = birthDate;
            p.info = info;

            PatientDao.Create(p);

            return p.patientId;
        }

        [Transactional]
        public void AssignDoctorToPatient(long doctorId, long patientId)
        {
            Patient p = PatientDao.Find(patientId);
            UserProfile d = UserProfileDao.Find(doctorId);
            if(p != null && d != null)
            {
                if (d.userType != 1)
                    return;
                PatientDao.AssignDoctor(p, d);
            }
        }

        [Transactional]
        public void RemoveDoctorFromPatient(long doctorId, long patientId)
        {
            Patient p = PatientDao.Find(patientId);
            UserProfile d = UserProfileDao.Find(doctorId);
            if (p != null && d != null)
            {
                PatientDao.UnassignDoctor(p, d);
            }
        }

        [Transactional]
        public void AssignEmployeeToPatient(long employeeId, long patientId)
        {
            Patient p = PatientDao.Find(patientId);
            UserProfile e = UserProfileDao.Find(employeeId);
            if (p != null && e != null)
            {
                if (e.userType != 2)
                    return;
                PatientDao.AssignEmployee(p, e);
            }
        }

        [Transactional]
        public void RemoveEmployeeFromPatient(long employeeId, long patientId)
        {
            Patient p = PatientDao.Find(patientId);
            UserProfile e = UserProfileDao.Find(employeeId);
            if (p != null && e != null)
            {
                PatientDao.UnassignEmployee(p, e);
            }
        }

        [Transactional]
        public ChatMessage SendChatMessage(long sender, long addressee, string title, string message)
        {
            UserProfile s = UserProfileDao.Find(sender);
            UserProfile a = UserProfileDao.Find(addressee);
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
                UserProfile = s,
                UserProfile1 = a,
                creationDate = DateTime.Now,
                title = title,
                messageText = message
            };

            ChatMessageDao.Create(c);
            return c;
        }

        [Transactional]
        public ChatMessageBlock GetChatMessages(long usrId, int startIndex, int count)
        {
            List<ChatMessage> messages =
                ChatMessageDao.FindMessagesByUser(usrId, startIndex, count + 1);

            bool existMoreMessages = (messages.Count == count + 1);

            if (existMoreMessages)
                messages.RemoveAt(count);

            return new ChatMessageBlock(messages, existMoreMessages);
        }
    }
}
