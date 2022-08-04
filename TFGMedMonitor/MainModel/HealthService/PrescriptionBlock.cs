using System;
using System.Collections.Generic;

namespace Model.HealthService
{
    public class PrescriptionBlock
    {
        public List<Analytic> Prescriptions { get; private set; }

        public bool ExistsMorePrescriptions { get; private set; }

        public PrescriptionBlock(List<Analytic> prescriptions, bool existsMorePrescriptions)
        {
            Prescriptions = prescriptions;
            ExistsMorePrescriptions = existsMorePrescriptions;
        }

    }
}
