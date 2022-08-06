using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IDoseDao : IGenericDao<Dose,Int64>
    {
        List<Dose> FindByPrescriptionId(long prescriptionId, int startIndex, int count);
    }
}
