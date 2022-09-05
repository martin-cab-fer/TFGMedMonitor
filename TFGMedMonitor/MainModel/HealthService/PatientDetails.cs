using System;
using System.Collections.Generic;

namespace Model.HealthService
{
    /// <summary>
    /// VO Class which contains the patient details
    /// </summary>
    [Serializable()]
    public class PatientDetails
    {
        #region Properties Region

        public String FullName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public String Info { get; private set; }

        public PrescriptionBlock Prescriptions;

        public AnalyticBlock LastAnalytics;

        public List<string> assignedDoctors { get; private set; }

        public List<string> assignedEmployees { get; private set; }

        #endregion

        public PatientDetails(Patient p, PrescriptionBlock pb, AnalyticBlock ab, List<string> aD, List<string> aE)
        {
            FullName = p.patientName;
            BirthDate = p.birthDate;
            Info = p.info;
            Prescriptions = pb;
            LastAnalytics = ab;
            assignedDoctors = aD;
            assignedEmployees = aE;
        }

        public override bool Equals(object obj)
        {
            PatientDetails target = (PatientDetails)obj;

            return (this.FullName == target.FullName)
                  && (this.BirthDate == target.BirthDate)
                  && (this.Info == target.Info);
        }
   
        public override int GetHashCode()
        {
            return this.FullName.GetHashCode();
        }

        public override String ToString()
        {
            String strPatientDetails;

            strPatientDetails =
                "[ FullName = " + FullName + " | " +
                "Birthdate = " + BirthDate + " | " +
                "Info = " + Info + " ]";

            return strPatientDetails;
        }
    }
}
