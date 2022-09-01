using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;

namespace Web.Pages.Admin
{
    public partial class AddMedicine : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddMedicineClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}