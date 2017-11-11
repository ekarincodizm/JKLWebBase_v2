using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Manager_Account;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Form_Account
{
    public partial class Activity_Log_Prv : Page
    {
        private string error = string.Empty;
        private Activity_Log_Manager act_log_mng = new Activity_Log_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string account_id = code[1];

                    Session["Account_id_Log"] = account_id;
                }

                _getData();
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
            _getData();
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Search Leasing Method                            ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _getData()
        {
            string date_str = Log_Date_str_TBx.Text == "" ? DateTimeUtility._dateNOWForServer() : DateTimeUtility.convertDateToMYSQLRealServer(Log_Date_str_TBx.Text);
            string date_end = Log_Date_end_TBx.Text == "" ? "" : DateTimeUtility.convertDateToMYSQLRealServer(Log_Date_end_TBx.Text);
            string account_id = (string)Session["Account_id_Log"];

            List<Activity_Log> list_data_all = act_log_mng.listActivityLogs(date_str, date_end, account_id, "", 0, 0);

            try
            {
                int row = list_data_all.Count;

                _pageCount(row);

                List<Activity_Log> list_data = act_log_mng.listActivityLogs(date_str, date_end, account_id, "", 0, 20);

                Session["date_str"] = date_str;
                Session["date_end"] = date_str.Equals(date_end) ? "" : date_end;
                Session["row_str"] = 0;

                Session["List_Activity_Log"] = list_data;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Activity_Log_Prv : Page --> _getData() ";
                Log_Error._writeErrorFile(error, ex);
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
            string date_str = (string)Session["date_str"];
            string date_end = (string)Session["date_end"];
            string account_id = (string)Session["Account_id_Log"];


            if (current_page > 1)
            {
                int row_str = (current_page - 1) * 20;

                link_Previous.Enabled = true;

                List<Activity_Log> list_data = act_log_mng.listActivityLogs(date_str, date_end, account_id, "", row_str, 20);

                Session["row_str"] = row_str;

                Session["List_Activity_Log"] = list_data;
            }
            else
            {
                link_Previous.Enabled = false;

                List<Activity_Log> list_data = act_log_mng.listActivityLogs(date_str, date_end, account_id, "", 0, 20);

                Session["row_str"] = 0;

                Session["List_Activity_Log"] = list_data;
            }
        }
    }
}