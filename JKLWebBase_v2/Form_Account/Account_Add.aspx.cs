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
    public partial class Account_Add : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCompanys();
                _loadLevelAccess();
            }
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

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            Account_Login acc_lgn = new Account_Login();

            acc_lgn.Username_md = username_TBx.Text;
            acc_lgn.Password_md = password_TBx.Text;

            acc_lgn.acc_lv = new Account_Level();
            acc_lgn.acc_lv.level_id = level_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(level_DDL.SelectedValue);

            acc_lgn.Account_Idcard = Account_Idcard_TBx.Text;
            acc_lgn.Account_F_name = Account_F_name_TBx.Text;
            acc_lgn.Account_N_Name = Account_N_Name_TBx.Text;
            acc_lgn.Account_Address_pri = Account_Address_pri_TBx.Text;
            acc_lgn.Account_Tel = Account_Tel_TBx.Text;
            acc_lgn.Account_Email = Account_Email_TBx.Text;

            acc_lgn.bs_cpn = new Base_Companys();
            acc_lgn.bs_cpn.Company_id = Company_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Company_DDL.SelectedValue);

            Account_Manager acc_mng = new Account_Manager();

            acc_mng.addAccount(acc_lgn);

            /// Acticity Logs System
            ///  

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            string message = Messages_Logs._messageLogsAccess("ยินดีต้อนรับ : " + acc_lgn.Account_F_name, "", package_login.Company_N_name, 1);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System

            Response.Redirect("/Form_Account/Account_Search");
        }
    }
}