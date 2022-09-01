using Model.HealthService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;

namespace Web.Pages.Health
{
    public partial class ShowPatientDetails : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSession s = SessionManager.GetUserSession(Context);

            if (s == null)
                return;          

            PatientDetails pD = (PatientDetails)Session["selectedPatient"];
            if (pD == null)
                return;

            txtFullName.Text = pD.FullName;
            txtBirthDate.Text = pD.BirthDate.ToString();
            txtInfo.Text = pD.Info;

            if(false /*pD.assignedEmployees.Count > 0 */)
            {
                //empLinks.DataSource = pD.assignedEmployees;
                //empLinks.DataBind();
            }

            if (false /*pD.assignedDoctors.Count > 0 */)
            {
                //docLinks.DataSource = pD.assignedDoctors;
                //docLinks.DataBind();
            }

            if (true /*pD.assignedDoctors.Contains(s.LoginName)*/)
            {
                btnPrescription.Visible = true;
                btnAnalytics.Visible = true;
            }
            else if (false /*pD.assignedEmployees.Contains(s.LoginName)*/)
            {
                btnAnalytics.Visible = true;
                btnPrescription.Visible = false;
            }
            else
            {
                btnAnalytics.Visible = false;
                btnPrescription.Visible = false;
            }
        }
    }
}