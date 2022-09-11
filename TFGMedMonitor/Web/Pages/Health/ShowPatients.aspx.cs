using Es.Udc.DotNet.ModelUtil.IoC;
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
    public partial class ShowPatients : SpecificCulturePage
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

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IHealthService healthService = iocManager.Resolve<IHealthService>();

            PatientBlock patients;
            patients = healthService.GetPatientList(0, startIndex, count);

            Session["patientSearch"] = patients;

            if (patients == null || patients.Patients.Count == 0)
                lblNoPatients.Visible = true;
            else
                lblNoPatients.Visible = false;

            bool loggedIn = SessionManager.IsUserAuthenticated(Context);
            if (!Page.IsPostBack)
            {
                try
                {
                    UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);
                    if (uD != null && uD.UserType == 3)
                    {
                        btnCreatePatient.Visible = true;
                    }
                }
                catch (Exception)
                {

                }
            }

            if (lblNoPatients.Visible == true)
                return;

            FillPatientList(patients, startIndex, count, loggedIn);
        }

        protected void FillPatientList(PatientBlock p, int stI, int c, bool l)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("FullName", typeof(String)));
            dt.Columns.Add(new DataColumn("BirthDate", typeof(String)));
            dt.Columns.Add(new DataColumn("Info", typeof(String)));
            dt.Columns.Add(new DataColumn("loggedIn", typeof(bool)));

            foreach (PatientDetails pD in p.Patients)
            {
                DataRow dr = dt.NewRow();
                dr["FullName"] = pD.FullName;
                dr["BirthDate"] = pD.BirthDate.ToString();
                dr["Info"] = pD.Info;
                dr["loggedIn"] = l;

                dt.Rows.Add(dr);
            }

            if (!l)
                GVPatients.Columns[3].Visible = false;

            GVPatients.DataSource = new DataView(dt);
            GVPatients.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Admin/ShowPatients.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (p.ExistsMorePatients)
            {
                string url;
                url = "~/Pages/Admin/ShowPatients.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }

        protected void BtnSeePatient(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                GridViewRow gVR = (GridViewRow)b.NamingContainer;
                if (b == null)
                    return;

                string pName = gVR.Cells[0].Text;
                PatientBlock patients = (PatientBlock)Session["patientSearch"];
                if (patients == null)
                    return;

                PatientDetails targetP = null;
                foreach (PatientDetails p in patients.Patients)
                {
                    if (pName == p.FullName)
                    {
                        targetP = p;
                        break;
                    }
                }

                if (targetP != null)
                {
                    Session["selectedPatient"] = targetP;

                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Health/ShowPatientDetails.aspx"));
                }
            } catch(Exception)
            {
                return;
            }         
        }

        protected void BtnCreatePatientClick(object sender, EventArgs e)
        {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Admin/AddPatient.aspx"));
        }
    }
}