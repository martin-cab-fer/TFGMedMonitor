using Es.Udc.DotNet.ModelUtil.IoC;
using Model;
using Model.AdminService;
using Model.HealthService;
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
    public partial class ShowMedicines : SpecificCulturePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int startIndex;
            int count;
            bool presc;

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
            try
            {
                presc = Boolean.Parse(Request.Params.Get("prescripting"));
            }
            catch (ArgumentNullException)
            {
                presc = false;
            }

            IIoCManager iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            IAdminService adminService = iocManager.Resolve<IAdminService>();

            string medName = (string)Session["selectedMedName"];
            List<string> actPrin = (List<string>)Session["actPrinList"];

            if(medName == null || actPrin == null)
                return;

            PatientDetails pD = (PatientDetails)Session["selectedPatient"];
            if (presc && pD != null)
                lblPrescripting.Text += (" " + pD.FullName);
            else
            {
                lblPrescripting.Visible = false;
                
            }

            bool loggedIn = SessionManager.IsUserAuthenticated(Context);
            if (loggedIn)
            {
                UserProfileDetails uD = SessionManager.FindUserProfileDetails(Context);
                if (uD != null && uD.UserType >= 2)
                    btnCreate.Visible = true;
            }

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

            FillMedicineList(medicines, startIndex, count, presc);           
        }

        protected void FillMedicineList(MedicineBlock mB, int stI, int c, bool presc)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("regNum", typeof(String)));
            dt.Columns.Add(new DataColumn("medName", typeof(String)));
            dt.Columns.Add(new DataColumn("labName", typeof(String)));
            dt.Columns.Add(new DataColumn("prescripting", typeof(bool)));

            foreach (Medicine m in mB.Medicines)
            {
                DataRow dr = dt.NewRow();
                dr["regNum"] = m.registerNumber.ToString();
                dr["medName"] = m.medName;
                dr["labName"] = m.labName;
                dr["prescripting"] = presc;

                dt.Rows.Add(dr);
            }

            GVMedicines.Columns[(GVMedicines.Columns.Count - 1)].Visible = presc;
            GVMedicines.DataSource = new DataView(dt);
            GVMedicines.DataBind();

            string p = "&prescripting=" + presc.ToString();

            /* "Previous" link */
            if ((stI - c) >= 0)
            {
                string url;
                url = "~/Pages/Admin/ShowMedicines.aspx" + "?startIndex=" + (stI - c)
                        + "&count=" + c + p;

                lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (mB.ExistsMoreMedicines)
            {
                string url;
                url = "~/Pages/Admin/ShowMedicines.aspx" + "?startIndex=" + (stI + c)
                        + "&count=" + c + p;

                lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                lnkNext.Visible = true;
            }
        }

        protected void BtnCreateClick(object sender, EventArgs e)
        {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Admin/AddMedicine.aspx"));
        }

        protected void BtnDetailsClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string mN = b.CommandArgument;
            MedicineBlock mB = (MedicineBlock)Session["medicineSearch"];
            if (mB == null)
                return;

            Medicine targetM = null;
            foreach (Medicine m in mB.Medicines)
            {
                if (mN == m.medName)
                {
                    targetM = m;
                    break;
                }
            }

            if (targetM == null)
                return;
            
            Session["selectedMedicine"] = targetM;

            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Admin/ShowMedicineDetails.aspx"));
        }

        protected void BtnSelectClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string mN = b.CommandArgument;
            MedicineBlock mB = (MedicineBlock)Session["medicineSearch"];
            if (mB == null)
                return;

            Medicine targetM = null;
            foreach (Medicine m in mB.Medicines)
            {
                if (mN == m.medName)
                {
                    targetM = m;
                    break;
                }
            }

            if (targetM == null)
                return;

            Session["selectedMedicine"] = targetM;

            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Health/AddPrescription.aspx"));
        }
    }
}