using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
using Model.HealthService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;

namespace Web.Pages.Health
{
    public partial class ShowPatientPrescription : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int startIndex;
            int count;

            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 0;
            }

            try
            {
                count = Int32.Parse(Request.Params.Get("count"));
            }
            catch (ArgumentNullException)
            {
                count = 10;
            }

            PatientDetails pD = (PatientDetails)Session["selectedPatient"];
            if (pD == null)
                return;

            PrescriptionBlock pB;
            if (startIndex > 0)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IHealthService healthService = iocManager.Resolve<IHealthService>();

                pB = healthService.GetPatientPrescription(0, startIndex, count);
            } else
                pB = pD.Prescriptions;

            if (pB.Prescriptions == null || pB.Prescriptions.Count == 0)
            {
                lblNoPrescriptions.Visible = true;
                return;
            }
            else
                lblNoPrescriptions.Visible = false;

            FillPrescriptionsList(pB, startIndex, count);
        }

        protected void FillPrescriptionsList(PrescriptionBlock pB, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("medName", typeof(String)));

            foreach (Prescription p in pB.Prescriptions)
            {
                DataRow dr = dt.NewRow();
                dr["medName"] = p.medicine.ToString();

                dt.Rows.Add(dr);
            }

            GVPrescriptions.DataSource = new DataView(dt);
            GVPrescriptions.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Health/ShowPatientPrescription.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (pB.ExistsMorePrescriptions)
            {
                string url;
                url = "~/Pages/Health/ShowPatientPrescription.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }
    }
}