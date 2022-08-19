using System;
using System.Collections.Generic;

namespace Model.HealthService
{
    public class PatientBlock
    {
        public List<PatientDetails> Patients { get; private set; }

        public bool ExistsMorePatients { get; private set; }

        public PatientBlock(List<PatientDetails> patients, bool existsMorePatients)
        {
            Patients = patients;
            ExistsMorePatients = existsMorePatients;
        }

    }
}
