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
    }
}
