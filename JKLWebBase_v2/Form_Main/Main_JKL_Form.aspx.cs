using System;
using System.Web.UI;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Main_JKL_Form : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("Customer");
        }

        protected void link_Payment_Leasings_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");

            Response.Redirect("/Form_Leasings/Leasing_Search_Payment");
        }

        protected void link_Search_Leasings_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");

            Session["Class_Active"] = 1;

            Response.Redirect("/Form_Leasings/Leasing_Search");
        }

        protected void link_Report_Payment_Daily_Leasings_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Reports_Leasings/Payment_Summary_Daily/Payment_Summary_Daily_Prv");
        }

        protected void link_Search_Customers_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");

            Session["Class_Active_Customer"] = 1;

            Response.Redirect("/Form_Customer/Customer_Search");
        }

        protected void link_Search_Agents_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");

            Response.Redirect("/Form_Agents/Agents_Search");
        }
    }
}