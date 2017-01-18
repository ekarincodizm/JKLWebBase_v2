using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Nav_Menu_Bar : System.Web.UI.UserControl
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

        protected void link_Menu_Search_Dealer_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Dealers");

            Response.Redirect("/Form_Dealer/Dealer_Search");
        }

        protected void link_Menu_Add_Dealer_Click(object sender, EventArgs e)
        {
            Session.Remove("Dealer");

            Response.Redirect("/Form_Dealer/Dealer_Add");
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
            Session.Remove("Dealers_Leasing");

            Session["Class_Active"] = 1;

            Response.Redirect("/Form_Leasings/Leasing_Add");
        }

        protected void link_Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Authorization/Login");
        }


    }
}