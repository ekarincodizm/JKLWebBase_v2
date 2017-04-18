using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;

namespace JKLWebBase_v2.Form_Account
{
    public partial class Account_Edit : Page
    {
        private Account_Login acc_lgn = new Account_Login();
        private Account_Manager acc_mng = new Account_Manager();
        private Base_Companys package_login = new Base_Companys();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("List_Account");

                _loadCompanys();
                _loadLevelAccess();
                _loadAccountStatus();

                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        acc_lgn = acc_mng.getAccount(id);

                        _loadData(acc_lgn);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeData(id);

                        Response.Redirect("/Form_Account/Account_Search");
                    }
                }
            }
        }

        private void _loadData(Account_Login acc_lgn)
        {
            username_TBx.Text = acc_lgn.resu;
            password_TBx.Text = acc_lgn.ssap;
            level_DDL.SelectedValue = acc_lgn.acc_lv.level_id.ToString();
            Account_Idcard_TBx.Text = acc_lgn.Account_Idcard;
            Account_F_name_TBx.Text = acc_lgn.Account_F_name;
            Account_N_Name_TBx.Text = acc_lgn.Account_N_Name;
            Account_Address_pri_TBx.Text = acc_lgn.Account_Address_pri;
            Account_Tel_TBx.Text = acc_lgn.Account_Tel;
            Account_Email_TBx.Text = acc_lgn.Account_Email;
            Company_DDL.SelectedValue = acc_lgn.bs_cpn.Company_id.ToString();
            Account_status_DDL.SelectedValue = acc_lgn.Account_status.ToString();
        }

        private void _removeData(string id)
        {
            acc_mng.removeAccount(id);
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // สาขา
        private void _loadCompanys()
        {
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(0, 0);
            Company_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Companys data = list_data[i];
                Company_DDL.Items.Add(new ListItem(data.Company_code + " ( " + data.Company_N_name + " ) ", data.Company_id.ToString()));
            }
        }

        // สิทธิ์ในการใช้งาน
        private void _loadLevelAccess()
        {
            List<Account_Level> list_data = new Account_Manager().listAccountLevel();
            level_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Account_Level data = list_data[i];
                level_DDL.Items.Add(new ListItem(data.level_name_TH + " ( " + data.level_name_ENG + " ) ", data.level_id.ToString()));
            }
        }

        // สถานะผู้ใช้งาน
        private void _loadAccountStatus()
        {
            List<Account_Level> list_data = new Account_Manager().listAccountLevel();
            Account_status_DDL.Items.Add(new ListItem("ปกติ", "1"));
            Account_status_DDL.Items.Add(new ListItem("ลาออก", "-1"));
            Account_status_DDL.Items.Add(new ListItem("ห้ามใช้งาน", "0"));
            
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string[] code = Request.Params["code"].Split('U');
            string id = code[1];

            Account_Login acc_lgn_edit = new Account_Login();

            acc_lgn_edit.Account_id = id;
            acc_lgn_edit.Username_md = username_TBx.Text;
            acc_lgn_edit.Password_md = password_TBx.Text;

            acc_lgn_edit.acc_lv = new Account_Level();
            acc_lgn_edit.acc_lv.level_id = level_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(level_DDL.SelectedValue);

            acc_lgn_edit.Account_Idcard = Account_Idcard_TBx.Text;
            acc_lgn_edit.Account_F_name = Account_F_name_TBx.Text;
            acc_lgn_edit.Account_N_Name = Account_N_Name_TBx.Text;
            acc_lgn_edit.Account_Address_pri = Account_Address_pri_TBx.Text;
            acc_lgn_edit.Account_Tel = Account_Tel_TBx.Text;
            acc_lgn_edit.Account_Email = Account_Email_TBx.Text;

            acc_lgn_edit.bs_cpn = new Base_Companys();
            acc_lgn_edit.bs_cpn.Company_id = Company_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Company_DDL.SelectedValue);

            acc_lgn_edit.Account_status = Convert.ToInt32(Account_status_DDL.SelectedValue);

            Account_Manager acc_mng = new Account_Manager();

            acc_mng.editAccount(acc_lgn_edit);

            /// Acticity Logs System
            ///  

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลผู้ใช้งาน : " + acc_lgn_edit.Account_F_name, acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System

            Response.Redirect("/Form_Account/Account_Search");
        }
    }
}