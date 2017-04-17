using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;
using System;
using System.Web.UI;

namespace JKLWebBase_v2.Form_Customer
{
    public partial class Tab_Menu_Customer : UserControl
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (Session["Customer"] != null || Request.Params["code"] != null)
            {
                link_Customer_Add.Enabled = true;
                link_Customer_Home_Photo.Enabled = true;
            }
            else
            {
                link_Customer_Add.Enabled = true;
                link_Customer_Home_Photo.Enabled = false;
            }

            if (acc_lgn.acc_lv.level_access < 7)
            {
                link_Customer_Home_Photo.Visible = false;
            }
        }

        protected void link_Customer_Add_Click(object sender, EventArgs e)
        {
            Session["Class_Active_Customer"] = 1;

            if (Session["Customer"] == null && Request.Params["code"] == null)
            {
                Response.Redirect("/Form_Customer/Customer_Add");
            }
            else
            {
                Response.Redirect("/Form_Customer/Customer_Edit");
            }
        }

        protected void link_Customer_Home_Photo_Click(object sender, EventArgs e)
        {
            Session["Class_Active_Customer"] = 2;

            if (Session["Customer"] == null && Request.Params["code"] == null)
            {
                Response.Redirect("/Form_Customer/Customer_Add");
            }
            else
            {
                Response.Redirect("/Form_Customer/Customer_Home_Photo");
            }
        }
    }
}