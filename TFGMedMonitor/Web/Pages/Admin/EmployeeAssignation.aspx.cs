using Es.Udc.DotNet.ModelUtil.IoC;
using Model.AdminService;
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

namespace Web.Pages.Admin
{
    public partial class EmployeeAssignation : SpecificCulturePage
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

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IUserService userService = iocManager.Resolve<IUserService>();

            UserBlock employees;
            employees = userService.GetSpecificUserList(1, startIndex, count);

            Session["employeeSearch"] = employees;

            if (employees == null || employees.Users.Count == 0)
            {
                lblNoEmployees.Visible = true;
                return;
            }
            else
                lblNoEmployees.Visible = false;

            FillDoctorList(pD, employees, startIndex, count);
        }

        protected void FillDoctorList(PatientDetails pD, UserBlock u, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("userName", typeof(String)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(String)));
            dt.Columns.Add(new DataColumn("Status", typeof(String)));

            bool x;

            foreach (UserProfileDetails uD in u.Users)
            {
                x = pD.assignedEmployees.Contains(uD.LoginName);

                DataRow dr = dt.NewRow();
                dr["userName"] = uD.LoginName;
                dr["FirstName"] = uD.FirstName;
                dr["Status"] = x ? this.GetLocalResourceObject("Assigned") : this.GetLocalResourceObject("Unassigned");

                dt.Rows.Add(dr);
            }

            GVEmployees.DataSource = new DataView(dt);
            GVEmployees.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Admin/EmployeeAssignation.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (u.ExistsMoreUsers)
            {
                string url;
                url = "~/Pages/Admin/EmployeeAssignation.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }

        protected void BtnToggleClick(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                string eName = b.CommandArgument;
                PatientDetails pD = (PatientDetails)Session["selectedPatient"];
                if (pD == null)
                    return;

                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IAdminService adminService = iocManager.Resolve<IAdminService>();

                bool success;

                if (pD.assignedDoctors.Contains(eName))
                {
                    success = adminService.RemoveEmployeeFromPatient(eName, pD.FullName);
                    if (success)
                    {
                        pD.assignedEmployees.Remove(eName);
                        Session["selectedPatient"] = pD;
                    }
                }
                else
                {
                    success = adminService.AssignEmployeeToPatient(eName, pD.FullName);
                    if (success)
                    {
                        pD.assignedEmployees.Add(eName);
                        Session["selectedPatient"] = pD;
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}