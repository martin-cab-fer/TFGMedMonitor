using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IAnalyticDao : IGenericDao<Analytic,Int64>
    {
        List<Analytic> FindByPatientId(long patientId, int startIndex, int count);
    }
}
