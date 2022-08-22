using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AdminDao
{
    public interface IMedicineDao : IGenericDao<Medicine,Int64>
    {
        List<Medicine> GetMedicineSearch(string name, List<string> activePrin, int startIndex, int count);

        List<Medicine> FindByRegisterNumber(int regCode);
    }
}
