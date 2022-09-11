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
            if (startIndex > 0 || count != 3)
            {
                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IHealthService healthService = iocManager.Resolve<IHealthService>();

                pB = healthService.GetPatientPrescription(pD.FullName, startIndex, count);
            }
            else
                pB = pD.Prescriptions;

            bool qual = false;
            UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);
            if (uD != null && uD.UserType > 1)
            {
                btnCreate.Visible = true;
                qual = true;
            }

            if (pB.Prescriptions == null || pB.Prescriptions.Count == 0)
            {
                lblNoPrescriptions.Visible = true;
                return;
            }
            else
                lblNoPrescriptions.Visible = false;

            Session["prescriptionSearch"] = pB;

            FillPrescriptionsList(pB, startIndex, count, qual);
        }

        protected void FillPrescriptionsList(PrescriptionBlock pB, int stI, int c, bool q)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("medName", typeof(String)));
            dt.Columns.Add(new DataColumn("frequency", typeof(String)));
            dt.Columns.Add(new DataColumn("creationDate", typeof(String)));
            dt.Columns.Add(new DataColumn("admin", typeof(String)));

            foreach (Prescription p in pB.Prescriptions)
            {
                DataRow dr = dt.NewRow();
                dr["medName"] = p.Medicine1.medName;
                dr["frequency"] = p.frequency;
                dr["creationDate"] = p.creationDate.ToString();
                dr["admin"] = p.administration;

                dt.Rows.Add(dr);
            }

            GVPrescriptions.Columns[(GVPrescriptions.Columns.Count - 1)].Visible = q;
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

        protected void BtnSeeDoses(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                GridViewRow gVR = (GridViewRow)b.NamingContainer;
                if (b == null)
                    return;

                string mName = gVR.Cells[0].Text;
                PrescriptionBlock prescriptions = (PrescriptionBlock)Session["prescriptionSearch"];
                if (prescriptions == null)
                    return;

                Prescription targetP = null;
                foreach (Prescription p in prescriptions.Prescriptions)
                {
                    if (mName == p.Medicine1.medName)
                    {
                        targetP = p;
                        break;
                    }
                }

                if (targetP != null)
                {
                    Session["selectedPrescription"] = targetP;

                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Health/ShowPatientDoses.aspx"));
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void BtnRemoveClick(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                GridViewRow gVR = (GridViewRow)b.NamingContainer;
                if (b == null)
                    return;

                string mName = gVR.Cells[0].Text;
                PrescriptionBlock prescriptions = (PrescriptionBlock)Session["prescriptionSearch"];
                if (prescriptions == null)
                    return;

                Prescription targetP = null;
                foreach (Prescription p in prescriptions.Prescriptions)
                {
                    if (mName == p.Medicine1.medName)
                    {
                        targetP = p;
                        break;
                    }
                }

                if (targetP != null)
                {
                    Session["selectedPrescription"] = null;

                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IHealthService healthService = iocManager.Resolve<IHealthService>();

                    UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);
                    if (uD == null || uD.UserType < 2)
                        return;

                    healthService.RemovePatientPrescription(uD.LoginName, targetP.prescriptionId);

                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Health/ShowPatientPrescription.aspx?startIndex=0&count=10"));
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void BtnCreateClick(object sender, EventArgs e)
        {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Admin/FindMedicine.aspx?prescripting=true"));
        }
    }
}