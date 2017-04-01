using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;


namespace JKLWebBase_v2
{
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["pack"] != null)
                {
                    string pack = Request.Params["pack"];

                    Session["lctn"] = pack;

                    Alert_Warning_Panel.Visible = false;

                    Login_panel.Visible = true;
                }
                else
                {
                    Alert_Warning_Panel.Visible = true;

                    Login_panel.Visible = false;
                }
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string pack = Request.Params["pack"];
            string username = Username_TBx.Text;
            string password = Password_TBx.Text;

            Base_Companys package_login = new Base_Companys_Manager().getCompanypackage(pack);
            Account_Login acc_lgn = new Account_Manager().getLogin(username, password);

            if (acc_lgn.Account_status == 1 && package_login != null)
            {
                Alert_Danger_Panel.Visible = false;
                Alert_Warning_Panel.Visible = false;

                Session["Login"] = acc_lgn;
                Session["Package"] = package_login;

                Response.Redirect("/Form_Main/Main_JKL_Form");
            }
            else if (acc_lgn.Account_status == 0)
            {
                Alert_Danger_Panel.Visible = true;

                alert_danger_Lbl.Text = "ชื่อผู้ใช้งาน "+ username + " ถูกระงับการใช้งานชั่วคราว กรุณาติดต่อเจ้าหน้าที่ฝ่าย IT";
            }
            else
            {
                Alert_Danger_Panel.Visible = true;

                alert_danger_Lbl.Text = "ชื่อผู้ใช้งาน " + username + " ถูกระงับการใช้งานถาวร เนื่องจากพ้นสภาพพนักงาน";
            }
        }
    }
}