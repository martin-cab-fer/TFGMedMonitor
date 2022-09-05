using Model.HealthService;
using Model.UserService;
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
            UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);

            if (uD == null)
                return;          

            PatientDetails pD = (PatientDetails)Session["selectedPatient"];
            if (pD == null)
                return;

            txtFullName.Text = pD.FullName;
            txtBirthDate.Text = pD.BirthDate.ToString();
            txtInfo.Text = pD.Info;

            if(pD.assignedEmployees.Count > 0)
            {
                empLinks.DataSource = pD.assignedEmployees;
                empLinks.DataBind();
            }

            if (pD.assignedDoctors.Count > 0)
            {
                docLinks.DataSource = pD.assignedDoctors;
                docLinks.DataBind();
            }

            if (pD.assignedDoctors.Contains(uD.LoginName) || uD.UserType == 3)
            {
                btnPrescription.Visible = true;
                btnAnalytics.Visible = true;
            }
            else if (pD.assignedEmployees.Contains(uD.LoginName))
            {
                btnAnalytics.Visible = true;
                btnPrescription.Visible = false;
            }
            else
            {
                btnAnalytics.Visible = false;
                btnPrescription.Visible = false;
            }

            if(uD.UserType == 3)
            {
                btnManageDocs.Visible = true;
                btnManageEmps.Visible = true;
            }
        }

        protected void BtnPrescriptionClick(object sender, EventArgs e)
        {
            string url = "~/Pages/Health/ShowPatientPrescription.aspx";

            Response.Redirect(Response.ApplyAppPathModifier(url));
        }

        protected void BtnAnalyticsClick(object sender, EventArgs e)
        {
            string url = "~/Pages/Health/ShowPatientAnalytics.aspx?startIndex=0&count=3";

            Response.Redirect(Response.ApplyAppPathModifier(url));
        }

        protected void BtnManageDocsClick(object sender, EventArgs e)
        {
            PatientDetails pD = (PatientDetails)Session["selectedPatient"];
            if (pD == null)
                return;

            string url = "~/Pages/Admin/DoctorAssignation.aspx";

            Response.Redirect(Response.ApplyAppPathModifier(url));
        }

        protected void BtnManageEmpsClick(object sender, EventArgs e)
        {
            PatientDetails pD = (PatientDetails)Session["selectedPatient"];
            if (pD == null)
                return;

            string url = "~/Pages/Admin/EmployeeAssignation.aspx";

            Response.Redirect(Response.ApplyAppPathModifier(url));
        }
    }
}