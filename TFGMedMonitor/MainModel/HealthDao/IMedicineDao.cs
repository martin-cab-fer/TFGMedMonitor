using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IMedicineDao : IGenericDao<Medicine,Int64>
    {
        List<Medicine> GetMedicineSearch(string name, List<string> activePrin, int startIndex, int count);
    }
}
