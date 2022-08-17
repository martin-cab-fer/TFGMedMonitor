using System;
using System.Collections.Generic;

namespace Model.HealthService
{
    public class PrescriptionBlock
    {
        public List<Prescription> Prescriptions { get; private set; }

        public bool ExistsMorePrescriptions { get; private set; }

        public PrescriptionBlock(List<Prescription> prescriptions, bool existsMorePrescriptions)
        {
            Prescriptions = prescriptions;
            ExistsMorePrescriptions = existsMorePrescriptions;
        }

    }
}
