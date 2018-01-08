using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;
using System;
using System.Web.UI;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Print_Menu_Leasing : UserControl
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (Session["Customer_Leasing"] != null && Session["Leasings"] != null)
            {
                Print_Menu_panel.Visible = true;

                if(Session["Agents_Leasing"] != null)
                {
                    Print_Withholding_Tax.Visible = true;
                }
                else
                {
                    Print_Withholding_Tax.Visible = false;
                }
            }
            else
            {
                Print_Menu_panel.Visible = false;
            }

            if (acc_lgn.acc_lv.level_access < 6)
            {
                Print_Menu_panel.Visible = false;
            }
        }
    }
}