using Es.Udc.DotNet.ModelUtil.IoC;
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
    public partial class ShowUsers : SpecificCulturePage
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
            IUserService userService = iocManager.Resolve<IUserService>();

            UserBlock users;
            users = userService.GetSpecificUserList(-1, startIndex, count);

            Session["userSearch"] = users;

            if (users == null || users.Users.Count == 0)
            {
                lblNoUsers.Visible = true;
                return;
            }
            else
                lblNoUsers.Visible = false;

            FillUserList(users, startIndex, count);
        }

        protected void FillUserList(UserBlock u, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("LoginName", typeof(String)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(String)));
            dt.Columns.Add(new DataColumn("Surname", typeof(String)));

            foreach (UserProfileDetails uD in u.Users)
            {
                DataRow dr = dt.NewRow();
                dr["LoginName"] = uD.LoginName;
                dr["FirstName"] = uD.FirstName;
                dr["Surname"] = uD.Lastname;

                dt.Rows.Add(dr);
            }

            GVUsers.DataSource = new DataView(dt);
            GVUsers.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/User/ShowUsers.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (u.ExistsMoreUsers)
            {
                string url;
                url = "~/Pages/User/ShowUsers.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }
    }
}