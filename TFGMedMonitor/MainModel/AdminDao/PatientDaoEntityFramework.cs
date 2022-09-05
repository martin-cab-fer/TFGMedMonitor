using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Exceptions;

namespace Model.HealthDao
{
    public class PatientDaoEntityFramework :
        GenericDaoEntityFramework<Patient, Int64>, IPatientDao
    {
        public PatientDaoEntityFramework()
        {
        }

        public Patient FindByFullName(string fullName)
        {
            Patient patient = null;

            DbSet<Patient> patients = Context.Set<Patient>();

            var result =
                (from p in patients
                 where p.patientName == fullName
                 select p);

            patient = result.FirstOrDefault();

            if (patient == null)
                throw new InstanceNotFoundException(fullName,
                    typeof(Patient).FullName);

            return patient;
        }

        public List<Patient> GetPatientsPaged(int startIndex, int count)
        {
            DbSet<Patient> patients = Context.Set<Patient>();

            var result =
                 (from a in patients
                  orderby a.patientName descending
                  select a).Skip(startIndex).Take(count).ToList();

            return result;
        }

        public void AssignDoctor(Patient p, UserProfile d)
        {
            p.UserProfile.Add(d);
            Update(p);
        }

        public void UnassignDoctor(Patient p, UserProfile d)
        {
            p.UserProfile.Remove(d);
            Update(p);
        }

        public void AssignEmployee(Patient p, UserProfile e)
        {
            p.UserProfile1.Add(e);
            Update(p);
        }

        public void UnassignEmployee(Patient p, UserProfile e)
        {
            p.UserProfile1.Remove(e);
            Update(p);
        }

        public List<string> GetAssignedDoctors(Patient p)
        {
            List<string> d = new List<string>();

            foreach (UserProfile u in p.UserProfile)
            {
                d.Add(u.loginName);
            }

            return d;
        }

        public List<string> GetAssignedEmployees(Patient p)
        {
            List<string> e = new List<string>();

            foreach (UserProfile u in p.UserProfile1)
            {
               e.Add(u.loginName);
            }

            return e;
        }
    }
}
