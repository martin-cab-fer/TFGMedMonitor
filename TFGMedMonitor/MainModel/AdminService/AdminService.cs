using Es.Udc.DotNet.ModelUtil.Transactions;
using Model.HealthDao;
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

        [Transactional]
        public void AssignDoctorToPatient(long doctorId, long patientId)
        {
            Patient p = PatientDao.Find(patientId);
            UserProfile d = UserProfileDao.Find(doctorId);
            if(p != null && d != null)
            {
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
        public ChatMessage AddChatMessage(long sender, long addressee, string title, string message)
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
