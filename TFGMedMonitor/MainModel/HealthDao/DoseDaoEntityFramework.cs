using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace Model.HealthDao
{
    public class DoseDaoEntityFramework :
        GenericDaoEntityFramework<Dose, Int64>, IDoseDao
    {
        public DoseDaoEntityFramework()
        {
        }

        public List<Dose> FindByPrescriptionId(long prescriptionId, int startIndex, int count)
        {
            DbSet<Dose> doses = Context.Set<Dose>();

            var result =
                 (from a in doses
                  where a.prescriptionId == prescriptionId
                  orderby a.administrationTime
                  select a).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
