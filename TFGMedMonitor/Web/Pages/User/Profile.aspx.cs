using Es.Udc.DotNet.ModelUtil.IoC;
using Model.UserService;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Web.HTTP.Session;

namespace Web.Pages.User
{
    public partial class Profile : SpecificCulturePage
    {
        protected UserProfileDetails uDets;

        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IUserService userService = iocManager.Resolve<IUserService>();
            string userName;

            try
            {
                userName = Request.Params.Get("userName");
                if (userName != null && userName.Length > 0)
                    Session["selectedUser"] = userService.FindUserProfileDetailsByName(userName);
                else
                    Session["selectedUser"] = SessionManager.FindUserProfileDetails(Context);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            uDets = (UserProfileDetails)Session["selectedUser"];

            txtUserName.Text = uDets.LoginName;
            txtFirstName.Text = uDets.FirstName;
        }
    }
}