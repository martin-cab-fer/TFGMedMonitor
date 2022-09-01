using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
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
    public partial class AddDose : SpecificCulturePage
    {
        private Prescription p;

        protected void Page_Load(object sender, EventArgs e)
        {
            p = (Prescription)Session["selectedPrescription"];

            if (p == null)
                return;

            txtMedicine.Text = p.Medicine1.medName;
        }

        protected void BtnSendClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    p = (Prescription)Session["selectedPrescription"];

                    if (p == null)
                        return;

                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IHealthService healthService = iocManager.Resolve<IHealthService>();

                    healthService.AddPatientDose(p.prescriptionId, 0, txtNotes.Text);

                    Response.Redirect(Response.ApplyAppPathModifier("./ShowPatientDoses.aspx"));
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}