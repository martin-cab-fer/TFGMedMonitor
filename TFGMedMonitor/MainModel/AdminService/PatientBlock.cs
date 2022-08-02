using System;
using System.Collections.Generic;

namespace Model.AdminService
{
    public class PatientBlock
    {
        public List<Patient> Patients { get; private set; }

        public bool ExistsMorePatients { get; private set; }

        public PatientBlock(List<Patient> patients, bool existsMorePatients)
        {
            Patients = patients;
            ExistsMorePatients = existsMorePatients;
        }

    }
}
