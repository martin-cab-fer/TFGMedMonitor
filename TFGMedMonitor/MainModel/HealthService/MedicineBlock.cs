using System;
using System.Collections.Generic;

namespace Model.HealthService
{
    public class MedicineBlock
    {
        public List<Medicine> Medicines { get; private set; }

        public bool ExistsMoreMedicines { get; private set; }

        public MedicineBlock(List<Medicine> medicines, bool existsMoreMedicines)
        {
            Medicines = medicines;
            ExistsMoreMedicines = existsMoreMedicines;
        }

    }
}
