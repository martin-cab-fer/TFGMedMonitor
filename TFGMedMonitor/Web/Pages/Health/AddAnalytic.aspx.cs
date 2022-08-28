using Es.Udc.DotNet.ModelUtil.IoC;
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
    public partial class AddAnalytic : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSendClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Int32 weight = Convert.ToInt32(txtWeight.Text);

                    PatientDetails p = (PatientDetails)Session["selectedPatient"];

                    if (p == null)
                        return;

                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IHealthService healthService = iocManager.Resolve<IHealthService>();

                    healthService.AddPatientAnalytic(0, 0, weight, txtProcedure.Text, txtObservations.Text);

                    Response.Redirect(Response.ApplyAppPathModifier("./ShowPatientAnalytics.aspx"));

                } catch (Exception)
                {
                    return;
                }
            }
        }
    }
}