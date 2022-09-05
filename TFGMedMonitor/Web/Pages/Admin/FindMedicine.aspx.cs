using Es.Udc.DotNet.ModelUtil.IoC;
using Model.AdminService;
using Model.HealthService;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnRemovePrin.Visible = false;
                Session["actPrinList"] = new List<string>();

                bool presc;
                try
                {
                    presc = Boolean.Parse(Request.Params.Get("prescripting"));
                }
                catch (ArgumentNullException)
                {
                    presc = false;
                }

                PatientDetails pD = (PatientDetails)Session["selectedPatient"];
                if (presc && pD != null)
                    lblPrescripting.Text += (" " + pD.FullName);
                else
                    lblPrescripting.Visible = false;               
            }
        }

        protected void BtnAddPrinClick(object sender, EventArgs e)
        {
            string s = txtNewActPrin.Text;
            if (s != null && s != "")
            {
                List<string> l = (List<string>)Session["actPrinList"];
                if (l == null)
                    l = new List<string>();
                if (l.Contains(s))
                    return;
                l.Add(s);
                Session["actPrinList"] = l;
                txtActivePrin.Text += (" " + s);
                btnRemovePrin.Visible = true;
            }
        }

        protected void BtnRemovePrinClick(object sender, EventArgs e)
        {
            Session["actPrinList"] = new List<string>();
            btnRemovePrin.Visible = false;
            txtActivePrin.Text = "";
        }

        protected void BtnSearchClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string s = txtName.Text;
                if (s == null)
                    s = "";

                List<string> actPrinList = (List<string>)Session["actPrinList"];
                if (actPrinList == null)
                    actPrinList = new List<string>();

                if (s == "" && actPrinList.Count == 0)
                {
                    return;
                }

                IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
                IAdminService adminService = iocManager.Resolve<IAdminService>();

                MedicineBlock medicines = adminService.GetMedicineSearch(s, actPrinList, 0, 10);

                Session["medicineSearch"] = medicines;
                Session["selectedMedName"] = txtName.Text;

                string pres;
                bool presc;
                try
                {
                    presc = Boolean.Parse(Request.Params.Get("prescripting"));
                }
                catch (ArgumentNullException)
                {
                    presc = false;
                }

                PatientDetails pD = (PatientDetails)Session["selectedPatient"];
                if (presc && pD != null)
                    pres = "&prescripting=true";
                else
                    pres = "";

                string url = "~/Pages/Admin/ShowMedicines.aspx" + "?startIndex=" + 0 + "&count=" + 10 + pres;
                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }
    }
}