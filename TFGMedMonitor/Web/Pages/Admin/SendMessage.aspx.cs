using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
using Model.AdminService;
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

        }

        protected void BtnSendClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IAdminService adminService = iocManager.Resolve<IAdminService>();

                    adminService.SendChatMessage(0, 0, txtTitle.Text, txtMessage.Text);

                    Response.Redirect(Response.ApplyAppPathModifier("./ShowMessages.aspx"));
                }
                catch (Exception)
                {

                }
            }
        }
    }
}