using Es.Udc.DotNet.ModelUtil.IoC;
using Model.AdminService;
using Model.HealthService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;

namespace Web.Pages.Admin
{
    public partial class AddPatient : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IAdminService adminService = iocManager.Resolve<IAdminService>();
                IHealthService healthService = iocManager.Resolve<IHealthService>();

                try
                {
                    DateTime bD = Convert.ToDateTime(txtDate.Text);
                    long p = adminService.CreatePatient(txtPatientName.Text, bD, txtPatientInfo.Text);
                    PatientDetails pD = healthService.GetPatientDetails(p);
                    Session["selectedPatient"] = pD;
                    string url = "~/Pages/Health/ShowPatientDetails.aspx";
                    Response.Redirect(Response.ApplyAppPathModifier(url));
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}