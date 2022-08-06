using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace Model.HealthDao
{
    public class MedicineDaoEntityFramework :
        GenericDaoEntityFramework<Medicine, Int64>, IMedicineDao
    {
        public MedicineDaoEntityFramework()
        {
        }

        public List<Medicine> FindByName(string name, int startIndex, int count)
        {
            DbSet<Medicine> medicines = Context.Set<Medicine>();

            var result =
                 (from a in medicines
                  where a.medName == name
                  orderby a.ATCCode
                  select a).Skip(startIndex).Take(count).ToList();

            return result;
        }
    }
}
