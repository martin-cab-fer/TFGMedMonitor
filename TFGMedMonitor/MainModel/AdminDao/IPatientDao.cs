using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IPatientDao : IGenericDao<Patient,Int64>
    {
        List<Patient> GetPatientsPaged(int startIndex, int count);
    }
}
