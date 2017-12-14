using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Global_Class;
using System;
using System.Web.UI;
using JKLWebBase_v2.Managers_Leasings;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Main_JKL_Form : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        private Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (acc_lgn.acc_lv.level_access < 7)
            {
                link_Payment_Leasings_panel.Visible = false;
                link_Report_Form_Certified_Leasing_Outline_panel.Visible = false;
            }

            if (acc_lgn.acc_lv.level_access == 4)
            {
                link_Payment_Leasings_panel.Visible = true;
            }

            if (acc_lgn.acc_lv.level_access < 4)
            {
                link_Report_Payment_Daily_Leasings_panel.Visible = false;
            }

            if (!IsPostBack)
            {
                if (acc_lgn.acc_lv.level_access >= 7)
                {
                    string start_cal = DateTimeUtility._dateTimeNOWForServer().Split(' ')[1].Split(':')[0];

                    if (start_cal == "9" || start_cal == "09")
                    {
                        cls_pay_mng.calculateAllPeriodFine();
                    }
                }
            }

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