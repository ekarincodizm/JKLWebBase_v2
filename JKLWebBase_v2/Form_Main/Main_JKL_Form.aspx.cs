using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Main_JKL_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void link_Payment_Leasings_Click(object sender, EventArgs e)
        {

        }

        protected void link_Search_Customers_Leasings_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Customer/Customer_Search");
        }

        protected void link_Search_Leasings_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Search");
        }
    }
}