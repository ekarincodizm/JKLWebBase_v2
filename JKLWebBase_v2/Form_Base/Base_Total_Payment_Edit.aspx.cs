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
    public partial class Base_Total_Payment_Edit : Page
    {
        private Base_Total_Payment bs_class = new Base_Total_Payment();
        private Base_Total_Payment_Manager bs_mng = new Base_Total_Payment_Manager();
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

            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_class = bs_mng.getTotalPaymentById(Convert.ToInt32(id));

                        _loadData(bs_class);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeData(id);

                        Response.Redirect("/Form_Base/Base_Total_Payment_Management");
                    }
                }
            }
        }

        private void _loadData(Base_Total_Payment bs_class)
        {
            Value_1_TBx.Text = bs_class.Total_payment_name;
        }

        private void _editData(string id)
        {
            if (Request.Params["mode"] == "e")
            {
                string value_1 = string.IsNullOrEmpty(Value_1_TBx.Text) ? "" : Value_1_TBx.Text;

                bs_mng.editTotalPayment(Convert.ToInt32(id), value_1);

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลระยะการชำระ ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }

        private void _removeData(string id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_mng.removeTotalPayment(Convert.ToInt32(id));

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ลบข้อมูลระยะการชำระ ", acc_lgn.resu, package_login.Company_N_name);

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

                _editData(id);
            }

            Response.Redirect("/Form_Base/Base_Total_Payment_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Total_Payment_Management");
        }
    }
}