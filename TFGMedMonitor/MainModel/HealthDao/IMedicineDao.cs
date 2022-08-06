using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IMedicineDao : IGenericDao<Medicine,Int64>
    {
        List<Medicine> FindByName(string name, int startIndex, int count);
    }
}
