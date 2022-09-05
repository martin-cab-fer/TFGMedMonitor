using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
using Model.HealthService;
using Model.UserService;
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
    public partial class ShowPatientDoses : SpecificCulturePage
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

            Prescription p = (Prescription)Session["selectedPrescription"];
            if (p == null)
                return;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IHealthService healthService = iocManager.Resolve<IHealthService>();

            DoseBlock dB = healthService.GetPatientDoses(p.prescriptionId, startIndex, count);

            UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);
            if (uD != null && uD.UserType > 0)
                btnCreate.Visible = true;

            if (dB.Doses == null || dB.Doses.Count == 0)
            {
                lblNoDoses.Visible = true;
                return;
            }
            else
                lblNoDoses.Visible = false;

            FillDosesList(dB, startIndex, count);
        }

        protected void FillDosesList(DoseBlock dB, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("administrator", typeof(String)));
            dt.Columns.Add(new DataColumn("date", typeof(String)));
            dt.Columns.Add(new DataColumn("notes", typeof(String)));

            foreach (Dose d in dB.Doses)
            {
                DataRow dr = dt.NewRow();
                dr["administrator"] = d.UserProfile.loginName;
                dr["date"] = d.administrationTime.ToString();
                dr["notes"] = d.notes;
                dt.Rows.Add(dr);
            }

            GVDoses.DataSource = new DataView(dt);
            GVDoses.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Health/ShowPatientDoses.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (dB.ExistsMoreDoses)
            {
                string url;
                url = "~/Pages/Health/ShowPatientDoses.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }

        protected void BtnCreateClick(object sender, EventArgs e)
        {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Health/AddDose.aspx"));
        }
    }
}