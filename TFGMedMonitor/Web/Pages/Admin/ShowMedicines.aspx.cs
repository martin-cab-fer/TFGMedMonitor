using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
using Model.AdminService;
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
    public partial class ShowMedicines : SpecificCulturePage
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
            IAdminService adminService = iocManager.Resolve<IAdminService>();

            string medName = (string)Session["selectedMedName"];
            List<string> actPrin = (List<string>)Session["selectedActivePrinciples"];

            if(medName == null || actPrin == null)
                return;

            MedicineBlock medicines;
            medicines = adminService.GetMedicineSearch(medName, actPrin, startIndex, count);

            Session["medicineSearch"] = medicines;

            if (medicines == null || medicines.Medicines.Count == 0)
            {
                lblNoMedicines.Visible = true;
                return;
            }
            else
                lblNoMedicines.Visible = false;

            FillMedicineList(medicines, startIndex, count);
        }

        protected void FillMedicineList(MedicineBlock mB, int stI, int c)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("medName", typeof(String)));

            foreach (Medicine m in mB.Medicines)
            {
                DataRow dr = dt.NewRow();
                dr["medName"] = m.medName;

                dt.Rows.Add(dr);
            }

            GVMedicines.DataSource = new DataView(dt);
            GVMedicines.DataBind();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Admin/ShowMedicines.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (mB.ExistsMoreMedicines)
            {
                string url;
                url = "~/Pages/Admin/ShowMedicines.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }
    }
}