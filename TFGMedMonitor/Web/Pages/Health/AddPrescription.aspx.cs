using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
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
    public partial class AddPrescription : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Medicine m = (Medicine)Session["selectedMedicine"];

            if (m == null)
                return;

            txtMedicine.Text = m.medName;
        }

        protected void BtnCreateClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IHealthService healthService = iocManager.Resolve<IHealthService>();

                    UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);

                    if (uD.UserType != 2)
                        return;

                    Medicine m = (Medicine)Session["selectedMedicine"];

                    if (m == null)
                        return;

                    int freq = Convert.ToInt32(txtFrequency.Text);

                    healthService.AddPatientPrescription(0, m.medicineId, freq, txtAdmin.Text);

                    Response.Redirect(Response.ApplyAppPathModifier("./ShowPatientDetails.aspx"));
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}