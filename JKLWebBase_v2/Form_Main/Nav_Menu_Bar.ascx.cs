using System;
using System.Web.UI;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Nav_Menu_Bar : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void link_Menu_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Main/Main_JKL_Form");
        }

        protected void link_Menu_Search_Customer_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");

            Session["Class_Active_Customer"] = 1;

            Response.Redirect("/Form_Customer/Customer_Search");
        }

        protected void link_Menu_Add_Customer_Click(object sender, EventArgs e)
        {
            Session.Remove("Customer");

            Session["Class_Active_Customer"] = 1;

            Response.Redirect("/Form_Customer/Customer_Add");
        }

        protected void link_Menu_Search_Agent_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Agents");

            Response.Redirect("/Form_Agents/Agents_Search");
        }

        protected void link_Menu_Add_Agent_Click(object sender, EventArgs e)
        {
            Session.Remove("Agent");

            Response.Redirect("/Form_Agents/Agents_Add");
        }

        protected void link_Menu_Pyament_Leasing_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Leasings");

            Response.Redirect("/Form_Leasings/Leasing_Search_Payment");
        }

        protected void link_Menu_Deposit_Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Search");
        }

        protected void link_Menu_Deposit_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Add");
        }

        protected void link_Menu_Leasing_Search_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Leasings");

            Session["Class_Active"] = 1;

            Response.Redirect("/Form_Leasings/Leasing_Search");
        }

        protected void link_Menu_Leasing_Add_Click(object sender, EventArgs e)
        {
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agents_Leasing");

            Session["Class_Active"] = 1;

            Response.Redirect("/Form_Leasings/Leasing_Add");
        }

        protected void link_Logout_Click(object sender, EventArgs e)
        {
            string package = (string)Session["lctn"];

            Session.RemoveAll();

            Response.Redirect("/Authorization/Login?pack=" + package);
        }

        protected void link_Company_Management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Company_Management");
        }

        protected void link_zone_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Zone_Service_Managenment");
        }

        protected void link_brand_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Car_Brands_Management");
        }

        protected void link_court_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Courts_Management");
        }

        protected void link_leasing_code_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Leasing_Code_Management");
        }

        protected void link_nationality_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Nationalitys_Management");
        }

        protected void link_origin_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Origins_Management");
        }

        protected void link_length_payment_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Total_Payment_Management");
        }

        protected void link_tents_management_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Base/Base_Tents_Car_Management");
        }

        protected void link_search_account_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Account/Account_Search");
        }

        protected void link_add_account_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Account/Account_Add");
        }

        protected void link_list_logs_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");
            Session.Remove("List_Leasings");
            Session.Remove("List_Agents");
            Session.Remove("Customer_Leasing");
            Session.Remove("Leasings");
            Session.Remove("Agent_Leasing");
            Session.Remove("List_Account");

            Response.Redirect("/Form_Account/Activity_Log_List");
        }

        protected void link_load_leasing_Click(object sender, EventArgs e)
        {

        }

        protected void link_load_loan_Click(object sender, EventArgs e)
        {

        }

        protected void link_report_leainsg_daily_payment_Click(object sender, EventArgs e)
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

        protected void link_report_leainsg_monthly_payment_Click(object sender, EventArgs e)
        {

        }

        protected void link_report_leainsg_yearly_payment_Click(object sender, EventArgs e)
        {

        }
    }
}