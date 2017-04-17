using System;
using System.Web.UI;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Tabs_Menu_Leasings : UserControl
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (Session["Customer_Leasing"] != null && Session["Leasings"] == null)
            {
                link_Customer_Add.Enabled = true;
                link_Leasing_Add.Enabled = true;
                link_Agents_Add.Enabled = false;
                link_Add_Guarantor_1.Enabled = false;
                link_Add_Guarantor_2.Enabled = false;
                link_Add_Guarantor_3.Enabled = false;
                link_Add_Guarantor_4.Enabled = false;
                link_Add_Guarantor_5.Enabled = false;
                link_Add_Car_Img.Enabled = false;
                link_List_Payment_Schedule.Enabled = false;
            }
            else if (Session["Customer_Leasing"] != null && Session["Leasings"] != null)
            {
                link_Customer_Add.Enabled = true;
                link_Leasing_Add.Enabled = true;
                link_Agents_Add.Enabled = true;
                link_Add_Guarantor_1.Enabled = true;
                link_Add_Guarantor_2.Enabled = true;
                link_Add_Guarantor_3.Enabled = true;
                link_Add_Guarantor_4.Enabled = true;
                link_Add_Guarantor_5.Enabled = true;
                link_Add_Car_Img.Enabled = true;
                link_List_Payment_Schedule.Enabled = true;
            }
            else
            {
                link_Customer_Add.Enabled = true;
                link_Leasing_Add.Enabled = false;
                link_Agents_Add.Enabled = false;
                link_Add_Guarantor_1.Enabled = false;
                link_Add_Guarantor_2.Enabled = false;
                link_Add_Guarantor_3.Enabled = false;
                link_Add_Guarantor_4.Enabled = false;
                link_Add_Guarantor_5.Enabled = false;
                link_Add_Car_Img.Enabled = false;
                link_List_Payment_Schedule.Enabled = false;
            }

            if (acc_lgn.acc_lv.level_access < 7)
            {
                link_Add_Car_Img.Visible = false;
            }
        }

        protected void link_Customer_Add_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 1;

            if (Session["Customer_Leasing"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Customer");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Customer");
            }
        }

        protected void link_Leasing_Add_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 2;

            if (Session["Leasings"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit");
            }

        }

        protected void link_Agents_Add_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 3;

            if (Session["Agents_Leasing"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Agent");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Agent");
            }
        }

        protected void link_Add_Guarantor_1_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 4;

            Session["Number_Of_Guarantor"] = "1";

            if (Session["Guarantor_1"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Guarantor");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Guarantor");
            }
        }

        protected void link_Add_Guarantor_2_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 5;

            Session["Number_Of_Guarantor"] = "2";

            if (Session["Guarantor_2"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Guarantor");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Guarantor");
            }
        }

        protected void link_Add_Guarantor_3_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 6;

            Session["Number_Of_Guarantor"] = "3";

            if (Session["Guarantor_3"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Guarantor");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Guarantor");
            }
        }

        protected void link_Add_Guarantor_4_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 7;

            Session["Number_Of_Guarantor"] = "4";

            if (Session["Guarantor_4"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Guarantor");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Guarantor");
            }
        }

        protected void link_Add_Guarantor_5_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 8;

            Session["Number_Of_Guarantor"] = "5";

            if (Session["Guarantor_5"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Guarantor");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Guarantor");
            }
        }

        protected void link_Add_Car_Img_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 9;

            Response.Redirect("/Form_Leasings/Leasing_Car_Img");
        }

        protected void link_List_Payment_Schedule_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 10;

            Response.Redirect("/Form_Leasings/Leasing_Payment_Schedule");
        }
    }
}