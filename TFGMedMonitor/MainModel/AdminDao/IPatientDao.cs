using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HealthDao
{
    public interface IPatientDao : IGenericDao<Patient,Int64>
    {
        List<Patient> GetPatientsPaged(int startIndex, int count);

        void AssignDoctor(Patient p, UserProfile d);

        void UnassignDoctor(Patient p, UserProfile d);

        void AssignEmployee(Patient p, UserProfile e);

        void UnassignEmployee(Patient p, UserProfile e);
    }
}
