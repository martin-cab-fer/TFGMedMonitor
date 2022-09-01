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
    public partial class ShowPatientAnalytics : SpecificCulturePage
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

            AnalyticBlock aB;
            if (startIndex > 0)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IHealthService healthService = iocManager.Resolve<IHealthService>();

                aB = healthService.GetPatientAnalytics(0, startIndex, count);
            }
            else
                aB = pD.LastAnalytics;

            if (aB.Analytics == null || aB.Analytics.Count == 0)
            {
                lblNoAnalytics.Visible = true;
                return;
            }
            else
                lblNoAnalytics.Visible = false;

            FillAnalyticsList(aB, startIndex, count);
        }

        protected void FillAnalyticsList(AnalyticBlock aB, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("procedure", typeof(String)));

            foreach (Analytic a in aB.Analytics)
            {
                DataRow dr = dt.NewRow();
                dr["procedure"] = a.usedProcedure;

                dt.Rows.Add(dr);
            }

            GVAnalytics.DataSource = new DataView(dt);
            GVAnalytics.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Health/ShowPatientAnalytics.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (aB.ExistsMoreAnalytics)
            {
                string url;
                url = "~/Pages/Health/ShowPatientAnalytics.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }
    }
}