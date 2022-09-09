using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;

namespace Web.Pages.Admin
{
    public partial class ShowMedicineDetails : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Medicine m = (Medicine)Session["selectedMedicine"];
            if (m == null)
                return;

            txtRegNum.Text = m.registerNumber.ToString();
            txtMedName.Text = m.medName;
            txtLabName.Text = m.labName;
            txtAuthDate.Text = m.authDate.ToString();
            txtMedStatus.Text = m.medStatus;
            txtStatusDate.Text = m.statusDate.ToString();
            txtATCCode.Text = m.ATCCode;
            txtActivePrin.Text = m.activePrinc;
            txtCommerc.Text = m.commercialized;
            txtYellowT.Text = m.yellowTriangle;
            txtObservations.Text = m.observations;
            txtSubst.Text = m.substitutes;
            txtAffectsC.Text = m.affectsConduction;
            txtSupplyI.Text = m.supplyIssues;
        }
    }
}