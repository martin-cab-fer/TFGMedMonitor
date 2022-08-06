using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace Model.HealthDao
{
    public class AnalyticDaoEntityFramework :
        GenericDaoEntityFramework<Analytic, Int64>, IAnalyticDao
    {
        public AnalyticDaoEntityFramework()
        {
        }

        public List<Analytic> FindByPatientId(long patientId, int startIndex, int count)
        {
            DbSet<Analytic> analytics = Context.Set<Analytic>();

            var result =
                 (from a in analytics
                  where a.patientId == patientId
                  orderby a.measurementTime
                  select a).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
