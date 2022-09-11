using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
using Model.AdminService;
using Model.UserService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;

namespace Web.Pages.User
{
    public partial class ShowUserActions : SpecificCulturePage
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

            if (!SessionManager.IsUserAuthenticated(Context))
                return;

            string u;
            UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);
            if (uD.UserType == 3)
                u = null;
            else
                u = uD.LoginName;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IAdminService adminService = iocManager.Resolve<IAdminService>();

            UserActionBlock actions;
            actions = adminService.GetUserActions(u, startIndex, count);

            if (actions == null || actions.Actions.Count == 0)
            {
                lblNoActions.Visible = true;
                return;
            }
            else
                lblNoActions.Visible = false;

            FillActionList(actions, startIndex, count);
        }

        protected void FillActionList(UserActionBlock a, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("LoginName", typeof(String)));
            dt.Columns.Add(new DataColumn("Date", typeof(String)));
            dt.Columns.Add(new DataColumn("Action", typeof(String)));

            foreach (UserAction uA in a.Actions)
            {
                DataRow dr = dt.NewRow();
                dr["LoginName"] = uA.UserProfile.loginName;
                dr["Date"] = uA.actionTime;
                dr["Action"] = uA.actionText;

                dt.Rows.Add(dr);
            }

            GVActions.DataSource = new DataView(dt);
            GVActions.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/User/ShowUserActions.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (a.ExistsMoreActions)
            {
                string url;
                url = "~/Pages/User/ShowUserActions.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }
    }
}