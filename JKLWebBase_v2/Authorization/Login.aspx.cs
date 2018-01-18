using System;
using System.Web.UI;

using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Global_Class;

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
                Alert_Warning_Panel.Visible = false;

                Session["Login"] = acc_lgn;
                Session["Package"] = package_login;

                /// Acticity Logs System
                ///  
                string message = Messages_Logs._messageLogsAccess(acc_lgn.Account_F_name, acc_lgn.resu, package_login.Company_N_name, 1);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System

                Response.Redirect("/Form_Main/Main_JKL_Form");
            }
            else if (acc_lgn.Account_status == 2)
            {
                alert_danger_Lbl.Visible = true;

                alert_danger_Lbl.Text = " ** ชื่อผู้ใช้งาน ' " + username + " ' ถูกระงับการใช้งานชั่วคราว กรุณาติดต่อเจ้าหน้าที่ฝ่าย IT ** ";

                /// Acticity Logs System
                ///  
                string message = Messages_Logs._messageLogsWarning(acc_lgn.Account_F_name, "ตรวจพบการเข้าใช้งานระบบ ในขณะ ถูกระงับการใช้งานชั่วคราว", username, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
            else if (acc_lgn.Account_status == 3)
            {
                alert_danger_Lbl.Visible = true;

                alert_danger_Lbl.Text = " ** ชื่อผู้ใช้งาน ' " + username + " ' ถูกระงับการใช้งานถาวร เนื่องจากพ้นสภาพพนักงาน ** ";

                /// Acticity Logs System
                ///  
                string message = Messages_Logs._messageLogsWarning(acc_lgn.Account_F_name, "ตรวจพบการเข้าใช้งานระบบ ในขณะ ถูกระงับการใช้งานถาวร", username, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
            else
            {
                alert_danger_Lbl.Visible = true;

                alert_danger_Lbl.Text = "** ไม่พบข้อมูลผู้ใช้งาน หรือ ชื่อผู้ใช้งาน (Username) หรือ รหัสผ่านไม่ถูกต้อง (Password) กรุณาตรวจสอบ **";

                /// Acticity Logs System
                ///  
                string message = Messages_Logs._messageLogsWarning(acc_lgn.Account_F_name, "ตรวจพบการเข้าใช้งานระบบโดยใช้ ชื่อผู้ใช้งาน หรือรหัสผ่าน ไม่ตามที่กำหนด", username, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }
    }
}