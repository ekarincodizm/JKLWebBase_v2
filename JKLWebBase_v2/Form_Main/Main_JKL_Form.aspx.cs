using JKLWebBase_v2.Reports.Leasings.Certified_Leasing;
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
            Session.Remove("Customer");
        }

        protected void link_Payment_Leasings_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Dealers");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Dealers_Leasing");

            Response.Redirect("/Form_Leasings/Leasing_Search_Payment");
        }

        protected void link_Search_Leasings_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Dealers");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Dealers_Leasing");

            Session["Class_Active"] = 1;

            Response.Redirect("/Form_Leasings/Leasing_Search");
        }

        protected void link_Report_Payment_Daily_Leasings_Click(object sender, EventArgs e)
        {

        }

        protected void link_Search_Customers_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Dealers");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Dealers_Leasing");

            Session["Class_Active_Customer"] = 1;

            Response.Redirect("/Form_Customer/Customer_Search");
        }

        protected void link_Search_Dealers_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Dealers");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Dealers_Leasing");

            Response.Redirect("/Form_Dealer/Dealer_Search");
        }
    }
}