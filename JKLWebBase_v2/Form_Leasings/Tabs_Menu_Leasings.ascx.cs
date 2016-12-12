using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Tabs_Menu_Leasings : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (Session["Customer"] != null && Session["Leasings"] == null)
            {
                link_Customer_Add.Enabled = true;
                link_Leasing_Add.Enabled = true;
                link_Dealers_Add.Enabled = false;
                link_Add_Bondsman_1.Enabled = false;
                link_Add_Bondsman_2.Enabled = false;
                link_Add_Bondsman_3.Enabled = false;
                link_Add_Bondsman_4.Enabled = false;
                link_Add_Bondsman_5.Enabled = false;
                link_Add_Car_Img.Enabled = false;
                link_Add_Home_Img.Enabled = false;
                link_List_Payment_Schedule.Enabled = false;
            }
            else if (Session["Customer"] != null && Session["Leasings"] != null)
            {
                link_Customer_Add.Enabled = true;
                link_Leasing_Add.Enabled = true;
                link_Dealers_Add.Enabled = true;
                link_Add_Bondsman_1.Enabled = true;
                link_Add_Bondsman_2.Enabled = true;
                link_Add_Bondsman_3.Enabled = true;
                link_Add_Bondsman_4.Enabled = true;
                link_Add_Bondsman_5.Enabled = true;
                link_Add_Car_Img.Enabled = true;
                link_Add_Home_Img.Enabled = true;
                link_List_Payment_Schedule.Enabled = true;
            }
            else
            {
                link_Customer_Add.Enabled = true;
                link_Leasing_Add.Enabled = false;
                link_Dealers_Add.Enabled = false;
                link_Add_Bondsman_1.Enabled = false;
                link_Add_Bondsman_2.Enabled = false;
                link_Add_Bondsman_3.Enabled = false;
                link_Add_Bondsman_4.Enabled = false;
                link_Add_Bondsman_5.Enabled = false;
                link_Add_Car_Img.Enabled = false;
                link_Add_Home_Img.Enabled = false;
                link_List_Payment_Schedule.Enabled = false;
            }*/
        }

        protected void link_Customer_Add_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 1;

            if (Session["Customer"] == null)
            {
                Response.Redirect("/Form_Customer/Customer_Add");
            }
            else
            {
                Response.Redirect("/Form_Customer/Customer_Edit");
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

        protected void link_Dealers_Add_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 3;

            if (Session["Dealers"] == null)
            {
                Response.Redirect("/Form_Dealer/Car_Dealer_Add");
            }
            else
            {
                Response.Redirect("/Form_Dealer/Car_Dealer_Edit");
            }
        }

        protected void link_Add_Bondsman_1_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 4;

            Session["Number_Of_Bondsman"] = "1";

            if (Session["Bondsman_1"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Bondsman");
            }
        }

        protected void link_Add_Bondsman_2_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 5;

            Session["Number_Of_Bondsman"] = "2";

            if (Session["Bondsman_2"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Bondsman");
            }
        }

        protected void link_Add_Bondsman_3_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 6;

            Session["Number_Of_Bondsman"] = "3";

            if (Session["Bondsman_3"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Bondsman");
            }
        }

        protected void link_Add_Bondsman_4_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 7;

            Session["Number_Of_Bondsman"] = "4";

            if (Session["Bondsman_4"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Bondsman");
            }
        }

        protected void link_Add_Bondsman_5_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 8;

            Session["Number_Of_Bondsman"] = "5";

            if (Session["Bondsman_5"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Bondsman");
            }
        }

        protected void link_Add_Car_Img_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 9;

            Response.Redirect("/Form_Leasings/Leasing_Car_Img");
        }

        protected void link_Add_Home_Img_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 10;

            Response.Redirect("/Form_Leasings/Leasing_Home_Img");
        }

        protected void link_List_Payment_Schedule_Click(object sender, EventArgs e)
        {
            Session["Class_Active"] = 11;

            Response.Redirect("/Form_Leasings/Leasing_Payment_Schedule");
        }
    }
}