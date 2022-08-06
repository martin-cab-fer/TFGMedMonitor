using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace Model.HealthDao
{
    public class PrescriptionDaoEntityFramework :
        GenericDaoEntityFramework<Prescription, Int64>, IPrescriptionDao
    {
        public PrescriptionDaoEntityFramework()
        {
        }

        public List<Prescription> FindByPatientId(long patientId, int startIndex, int count)
        {
            DbSet<Prescription> prescriptions = Context.Set<Prescription>();

            var result =
                 (from a in prescriptions
                  where a.patient == patientId
                  orderby a.creationDate
                  select a).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
