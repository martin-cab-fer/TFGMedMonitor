using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace Model.AdminDao
{
    public class MedicineDaoEntityFramework :
        GenericDaoEntityFramework<Medicine, Int64>, IMedicineDao
    {
        public MedicineDaoEntityFramework()
        {
        }

        public List<Medicine> GetMedicineSearch(string name, List<string> activePrin, int startIndex, int count)
        {
            DbSet<Medicine> medicines = Context.Set<Medicine>();

            if(activePrin.Count == 0)
            {
                var result =
                 (from a in medicines
                  where a.medName.ToLower().Contains(name.ToLower())
                  orderby a.registerNumber
                  select a).Skip(startIndex).Take(count).ToList();

                return result;
            } else
            {
                var fResult = new List<Medicine>();

                foreach(string prin in activePrin)
                {
                    var result = new List<Medicine>();

                    if (name == "")
                    {
                        result =
                        (from a in medicines
                         where a.activePrinc.ToLower().Contains(prin.ToLower())
                         orderby a.registerNumber
                         select a).Skip(startIndex).Take(count).ToList();
                    } else
                    {
                        result =
                        (from a in medicines
                         where a.medName.ToLower().Contains(name.ToLower())
                         && a.activePrinc.ToLower().Contains(prin.ToLower())
                         orderby a.registerNumber
                         select a).Skip(startIndex).Take(count).ToList();
                    }

                    foreach(Medicine m in result)
                    {
                        if (!fResult.Contains(m))
                            fResult.Add(m);
                    }
                }

                return fResult;
            }
        }

        public List<Medicine> FindByRegisterNumber (int regNumber)
        {
            return null;
        }
    }
}
