using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IPrescriptionDao : IGenericDao<Prescription,Int64>
    {
        List<Prescription> FindByPatientId(long patientId, int startIndex, int count);
    }
}
