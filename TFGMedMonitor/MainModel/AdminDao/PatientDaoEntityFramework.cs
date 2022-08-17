using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace Model.HealthDao
{
    public class PatientDaoEntityFramework :
        GenericDaoEntityFramework<Patient, Int64>, IPatientDao
    {
        public PatientDaoEntityFramework()
        {
        }

        public List<Patient> GetPatientsPaged(int startIndex, int count)
        {
            DbSet<Patient> patients = Context.Set<Patient>();

            var result =
                 (from a in patients
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
    }
}
