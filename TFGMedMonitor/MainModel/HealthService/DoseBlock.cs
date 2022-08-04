using System;
using System.Collections.Generic;

namespace Model.HealthService
{
    public class DoseBlock
    {
        public List<Dose> Doses { get; private set; }

        public bool ExistsMoreDoses { get; private set; }

        public DoseBlock(List<Dose> doses, bool existsMoreDoses)
        {
            Doses = doses;
            ExistsMoreDoses = existsMoreDoses;
        }

    }
}
