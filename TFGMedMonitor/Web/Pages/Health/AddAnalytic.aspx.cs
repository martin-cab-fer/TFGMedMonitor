using Es.Udc.DotNet.ModelUtil.IoC;
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
    public partial class AddAnalytic : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PatientDetails p = (PatientDetails)Session["selectedPatient"];
            if (p == null)
                return;

            txtPatient.Text = p.FullName;
        }

        protected void BtnSendClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    float weight = Convert.ToSingle(txtWeight.Text);
                    if (weight <= 0)
                        return;

                    PatientDetails p = (PatientDetails)Session["selectedPatient"];
                    if (p == null)
                        return;

                    UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);
                    if (uD == null)
                        Response.Redirect(Response.ApplyAppPathModifier("~/Pages/User/Authentication.aspx"));

                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IHealthService healthService = iocManager.Resolve<IHealthService>();

                    healthService.AddPatientAnalytic(p.FullName, uD.LoginName, weight, txtProcedure.Text, txtObservations.Text);

                    Response.Redirect(Response.ApplyAppPathModifier("./ShowPatientAnalytics.aspx?startIndex=0&count=10"));

                } catch (Exception)
                {
                    return;
                }
            }
        }
    }
}