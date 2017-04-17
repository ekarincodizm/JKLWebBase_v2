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
    public partial class Account_Search : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        private Account_Manager acc_lgn_mng = new Account_Manager();
        private string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCompanys();
                _loadLevelAccess();
            }
        }

        protected void Company_ChkBxL_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Company_ChkBxL.Items.Count;

            if (Company_ChkBxL_All.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    Company_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Company_ChkBxL.Items[i].Selected = false;
                }
            }
        }

        protected void level_ChkBxL_ALL_CheckedChanged(object sender, EventArgs e)
        {
            int count = level_ChkBxL.Items.Count;

            if (level_ChkBxL_ALL.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    level_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    level_ChkBxL.Items[i].Selected = false;
                }
            }

        }

        protected void link_Previous_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            if (current_page > 1)
            {
                int prev = current_page - 1;

                Paging_DDL.SelectedValue = prev.ToString();

                _getMore(prev);
            }
        }
        protected void Paging_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            _getMore(current_page);
        }

        protected void link_Next_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            int next = current_page + 1;

            Paging_DDL.SelectedValue = next.ToString();

            _getMore(next);
        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Account");

            Paging_DDL.Items.Clear();

            _getData();
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Search Leasing Method                            ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _getData()
        {
            string username = Username_md_TBx.Text;
            string idcard = Account_Idcard_TBx.Text;
            string name = Account_F_name_TBx.Text.Trim(' ');
            string level_id_inline = _getCheckedLevel();
            string Company_id_inline = _getCheckedCompany();
            
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(idcard) || !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(level_id_inline) || !string.IsNullOrEmpty(Company_id_inline))
            {
                acc_lgn_mng = new Account_Manager();

                List<Account_Login> list_acc_all = acc_lgn_mng.listAccount(username, name, idcard, level_id_inline, Company_id_inline, 0, 0);

                try
                {
                    int row = list_acc_all.Count;

                    _pageCount(row);

                    List<Account_Login> list_acc = acc_lgn_mng.listAccount(username, name, idcard, level_id_inline, Company_id_inline, 0, 20);

                    Session["username"] = username;
                    Session["idcard"] = idcard;
                    Session["name"] = name;
                    Session["level_id_inline"] = level_id_inline;
                    Session["company_id_inline"] = Company_id_inline;
                    Session["row_str"] = 0;

                    Session["List_Account"] = list_acc;
                }
                catch (Exception ex)
                {
                    error = "Exception ==> Account_Search : Page --> _getData() ";
                    Log_Error._writeErrorFile(error, ex);
                }
            }
        }

        private void _pageCount(int row)
        {
            int paging = row > 20 ? (row / 20) + 1 : 1;

            for (int i = 1; i <= paging; i++)
            {
                Paging_DDL.Items.Add(new ListItem("" + i, "" + i));
            }

            if (paging == 1)
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = false;
            }
            else if (paging > 1 && Paging_DDL.Items[0].Value == "0")
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = true;
            }
            else
            {
                link_Previous.Enabled = true;
                link_Next.Enabled = true;
            }
        }

        private void _getMore(int current_page)
        {
            string username = (string)Session["username"];
            string idcard = (string)Session["idcard"];
            string name = (string)Session["name"];
            string level_id_inline = (string)Session["level_id_inline"];
            string Company_id_inline = (string)Session["company_id_inline"];
            
            acc_lgn_mng = new Account_Manager();

            if (current_page > 1)
            {
                int row_str = (current_page - 1) * 20;

                link_Previous.Enabled = true;

                List<Account_Login> list_acc = acc_lgn_mng.listAccount(username, name, idcard, level_id_inline, Company_id_inline, row_str, 20);

                Session["row_str"] = row_str;

                Session["List_Account"] = list_acc;
            }
            else
            {
                link_Previous.Enabled = false;

                List<Account_Login> list_acc = acc_lgn_mng.listAccount(username, name, idcard, level_id_inline, Company_id_inline, 0, 20);

                Session["row_str"] = 0;

                Session["List_Account"] = list_acc;
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

            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Companys data = list_data[i];
                Company_ChkBxL.Items.Add(new ListItem(data.Company_code + " ( " + data.Company_N_name + " ) ", data.Company_id.ToString()));
            }
        }

        // สิทธิ์ในการใช้งาน
        private void _loadLevelAccess()
        {
            List<Account_Level> list_data = new Account_Manager().listAccountLevel();

            for (int i = 0; i < list_data.Count; i++)
            {
                Account_Level data = list_data[i];
                level_ChkBxL.Items.Add(new ListItem(data.level_name_TH + " ( " + data.level_name_ENG + " ) ", data.level_id.ToString()));
            }
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                   Get Value in CheckBoxList                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private string _getCheckedCompany()
        {
            string Company_id_inline = "";
            int count = 1;

            for (int i = 0; i < Company_ChkBxL.Items.Count; i++)
            {
                if (Company_ChkBxL.Items[i].Selected && count == 1)
                {
                    Company_id_inline += Company_ChkBxL.Items[i].Value;
                    count++;
                }
                else if (Company_ChkBxL.Items[i].Selected)
                {
                    Company_id_inline += "," + Company_ChkBxL.Items[i].Value;
                    count++;
                }
            }
            return Company_id_inline;
        }


        private string _getCheckedLevel()
        {
            string level_id_inline = "";
            int count = 1;

            for (int i = 0; i < level_ChkBxL.Items.Count; i++)
            {
                if (level_ChkBxL.Items[i].Selected && count == 1)
                {
                    level_id_inline += level_ChkBxL.Items[i].Value;
                    count++;
                }
                else if (level_ChkBxL.Items[i].Selected)
                {
                    level_id_inline += "," + level_ChkBxL.Items[i].Value;
                    count++;
                }
            }
            return level_id_inline;
        }
    }
}