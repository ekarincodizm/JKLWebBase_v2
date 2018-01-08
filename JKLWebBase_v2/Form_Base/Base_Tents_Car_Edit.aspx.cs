using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Tents_Car_Edit : Page
    {
        private Base_Tents_Car bs_class = new Base_Tents_Car();
        private Base_Tents_Car_Manager bs_mng = new Base_Tents_Car_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_class = bs_mng.getTentsById(Convert.ToInt32(id));

                        _loadTentsCar(bs_class);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeTentsCar(id);

                        Response.Redirect("/Form_Base/Base_Tents_Car_Management");
                    }
                }
            }
        }

        private void _loadTentsCar(Base_Tents_Car bs_class)
        {
            Tent_name_TBx.Text = bs_class.Tent_name;
            Tent_local_TBx.Text = bs_class.Tent_local;
        }

        private void _editTentsCar(string id)
        {
            if (Request.Params["mode"] == "e")
            {
                string value_1 = string.IsNullOrEmpty(Tent_name_TBx.Text) ? "" : Tent_name_TBx.Text;
                string value_2 = string.IsNullOrEmpty(Tent_local_TBx.Text) ? "" : Tent_local_TBx.Text;

                bs_mng.editTent(Convert.ToInt32(id), value_1, value_2);

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลเต็นท์รถ ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }

        private void _removeTentsCar(string id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_mng.removeTent(Convert.ToInt32(id));

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ลบข้อมูลเต็นท์รถ ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string id = code[1];

                _editTentsCar(id);
            }

            Response.Redirect("/Form_Base/Base_Tents_Car_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Tents_Car_Management");
        }
    }
}