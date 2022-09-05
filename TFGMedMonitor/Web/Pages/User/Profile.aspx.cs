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
            txtSurname.Text = uDets.Lastname;
            switch (uDets.UserType)
            {
                case 1:
                    txtUserType.Text = (string)this.GetLocalResourceObject("Employee");
                    break;

                case 2:
                    txtUserType.Text = (string)this.GetLocalResourceObject("Doctor");
                    break;

                case 3:
                    txtUserType.Text = (string)this.GetLocalResourceObject("Admin");
                    break;

                default:
                    break;
            }

            try
            {
                UserProfileDetails loggedUser = SessionManager.FindUserProfileDetails(Context);

                if (uDets.LoginName != loggedUser.LoginName)
                    btnMessage.Visible = true;
            }
            catch (Exception)
            {

            }
        }

        protected void BtnMessageClick(object sender, EventArgs e)
        {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Admin/SendMessage.aspx"));
        }
    }
}