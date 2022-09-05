using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
using Model.AdminService;
using Model.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;

namespace Web.Pages.Admin
{
    public partial class SendMessage : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserProfileDetails uD = (UserProfileDetails)Session["selectedUser"];
            if(uD == null)
            {
                btnSend.Visible = false;
                return;
            }

            txtAdressee.Text = uD.LoginName;       
        }

        protected void BtnSendClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    UserProfileDetails s = SessionManager.FindUserProfileDetails(Context);
                    if (s == null)
                        return;

                    UserProfileDetails uD = (UserProfileDetails)Session["selectedUser"];
                    if (uD == null)
                        return;

                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IAdminService adminService = iocManager.Resolve<IAdminService>();

                    adminService.SendChatMessage(s.LoginName, uD.LoginName, txtTitle.Text, txtMessage.Text);

                    Response.Redirect(Response.ApplyAppPathModifier("./ShowMessages.aspx"));
                }
                catch (Exception)
                {

                }
            }
        }
    }
}