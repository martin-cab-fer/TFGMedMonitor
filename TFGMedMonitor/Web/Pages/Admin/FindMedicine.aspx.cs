using Es.Udc.DotNet.ModelUtil.IoC;
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
    public partial class FindMedicine : SpecificCulturePage
    {
        private List<string> actPrinList;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRemovePrin.Visible = false;
            actPrinList = new List<string>();
        }

        protected void BtnAddPrinClick(object sender, EventArgs e)
        {
            string s = txtNewActPrin.Text;
            if (s != null && s != "")
            {
                actPrinList.Add(s);
                txtActivePrin.Text += (" " + s);
                btnRemovePrin.Visible = true;
            }
        }

        protected void BtnRemovePrinClick(object sender, EventArgs e)
        {
            actPrinList = new List<string>();
            btnRemovePrin.Visible = false;
            txtActivePrin.Text = "";
        }

        protected void BtnSearchClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string s = txtActivePrin.Text;
                if (s == null)
                    s = "";

                if (s == "" && actPrinList.Count == 0)
                    return;

                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IAdminService adminService = iocManager.Resolve<IAdminService>();

                MedicineBlock medicines = adminService.GetMedicineSearch(s, actPrinList, 0, 10);

                Session["medicineSearch"] = medicines;     

                Session["selectedMedName"] = s;
                Session["selectedActivePrinciples"] = actPrinList;
                string url = "~/Pages/Admin/ShowMedicines.aspx" + "?startIndex=" + 0 + "&count=" + 10;
                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}