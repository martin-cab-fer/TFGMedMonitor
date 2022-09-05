using Es.Udc.DotNet.ModelUtil.IoC;
using Model.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;
using System.Data.Entity.Validation;

namespace Web.Pages.Admin
{
    public partial class AddMedicine : SpecificCulturePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRemovePrin.Visible = false;
            if (!Page.IsPostBack)
                Session["actPrinList"] = new List<string>();
        }

        protected void BtnAddPrinClick(object sender, EventArgs e)
        {
            string s = txtNewActPrin.Text;
            if (s != null && s != "")
            {
                List<string> l = (List<string>)Session["actPrinList"];
                if (l == null)
                    l = new List<string>();
                if (!l.Contains(s))
                {
                    l.Add(s);
                    Session["actPrinList"] = l;
                    txtActivePrin.Text += (" " + s);
                    btnRemovePrin.Visible = true;
                } else if (l.Count > 0)
                    btnRemovePrin.Visible = true;
            }
        }

        protected void BtnRemovePrinClick(object sender, EventArgs e)
        {
            Session["actPrinList"] = new List<string>();
            btnRemovePrin.Visible = false;
            txtActivePrin.Text = "";
        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<string> actPrinList = (List<string>)Session["actPrinList"];
                    if (actPrinList == null)
                        actPrinList = new List<string>();

                    if (actPrinList.Count == 0)
                    {
                        txtActivePrin.Text = (string)this.GetLocalResourceObject("actPrinReq");
                        return;
                    }

                    IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                    IAdminService adminService = iocManager.Resolve<IAdminService>();

                    Int32 regN = Convert.ToInt32(txtRegNum.Text);
                    if (regN <= 0)
                        return;

                    DateTime authD = Convert.ToDateTime(txtAuthDate.Text);
                    DateTime statusD = Convert.ToDateTime(txtStatusDate.Text);

                    string ATC = txtATCCode.Text.Substring(0, Math.Min(txtATCCode.Text.Length, 7));

                    adminService.CreateMedicine(regN, txtMedName.Text, txtLabName.Text, authD, txtMedStatus.Text, statusD,
                        ATC, txtActivePrin.Text, actPrinList.Count, txtCommerc.Checked, txtYellowT.Checked,
                        txtObservations.Text, txtSubst.Text, txtAffectsC.Checked, txtSupplyI.Checked);

                    string url = "~/Pages/Admin/FindMedicine.aspx";
                    Response.Redirect(Response.ApplyAppPathModifier(url));
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        txtActivePrin.Text = "Entity of type " + eve.Entry.Entity.GetType().Name +
                            " in state " + eve.Entry.State + " has the following validation errors: ";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            txtActivePrin.Text += (ve.PropertyName + " " + ve.ErrorMessage);
                        }
                    }
                    return;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}