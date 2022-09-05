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

namespace Web.Pages.Admin
{
    public partial class ShowMessages : SpecificCulturePage
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

            UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);

            if (uD == null)
                return;

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IAdminService adminService = iocManager.Resolve<IAdminService>();

            ChatMessageBlock messages;
            messages = adminService.GetChatMessages(uD.LoginName, startIndex, count);

            Session["messageSearch"] = messages;

            if (messages == null || messages.Messages.Count == 0)
            {
                lblNoMessages.Visible = true;
                return;
            }
            else
                lblNoMessages.Visible = false;

            FillMessageList(messages, startIndex, count);
        }

        protected void FillMessageList(ChatMessageBlock cmB, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("sender", typeof(String)));
            dt.Columns.Add(new DataColumn("adressee", typeof(String)));
            dt.Columns.Add(new DataColumn("date", typeof(String)));
            dt.Columns.Add(new DataColumn("title", typeof(String)));
            dt.Columns.Add(new DataColumn("message", typeof(String)));

            foreach (ChatMessage cM in cmB.Messages)
            {                
                DataRow dr = dt.NewRow();
                dr["sender"] = cM.UserProfile1.loginName;
                dr["adressee"] = cM.UserProfile.loginName;
                dr["date"] = cM.creationDate.ToString();
                dr["title"] = cM.title;
                dr["message"] = cM.messageText;

                dt.Rows.Add(dr);
            }

            GVMessages.DataSource = new DataView(dt);
            GVMessages.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Admin/ShowMessages.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (cmB.ExistsMoreMessages)
            {
                string url;
                url = "~/Pages/Admin/ShowMessages.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }
    }
}