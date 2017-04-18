using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Manager_Account;
using JKLWebBase_v2.Managers_Agents;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Form_Agents
{
    public partial class Agents_Search : Page
    {
        Agents_Manager dlr_mng = new Agents_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Agents");

            Paging_DDL.Items.Clear();

            _GetAgent();

            /// Acticity Logs System
            ///  

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ค้นหาข้อมูลนายหน้า ", acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System
        }

        private void _GetAgent()
        {
            string idcard = Agent_Idcard_TBx.Text;
            string fname = Agent_Fname_TBx.Text;
            string lname = Agent_Lname_TBx.Text;

            dlr_mng = new Agents_Manager();

            if (!string.IsNullOrEmpty(idcard) || !string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname))
            {
                List<Agents> list_dlr_all = dlr_mng.getAgents(idcard, fname, lname, 0, 0);

                int row = list_dlr_all.Count;

                _pageCount(row);

                List<Agents> list_dlr = dlr_mng.getAgents(idcard, fname, lname, 0, 20);

                Session["idcard"] = idcard;
                Session["fname"] = fname;
                Session["lname"] = lname;
                Session["row_str"] = 0;

                Session["List_Agents"] = list_dlr;
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

        protected void link_Previous_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            if(current_page > 1)
            {
                int prev = current_page - 1;

                Paging_DDL.SelectedValue = prev.ToString();

                _getMoreAgent(prev);
            }
        }
        protected void Paging_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            _getMoreAgent(current_page);
        }

        protected void link_Next_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            int next = current_page + 1;

            Paging_DDL.SelectedValue = next.ToString();

            _getMoreAgent(next);
        }
        
        private void _getMoreAgent(int current_page)
        {
            string idcard = (string)Session["idcard"];
            string fname = (string)Session["fname"];
            string lname = (string)Session["lname"];

            if (current_page > 1)
            {
                int row_str = (current_page - 1) * 20;

                link_Previous.Enabled = true;

                dlr_mng = new Agents_Manager();

                List<Agents> list_dlr = dlr_mng.getAgents(idcard, fname, lname, row_str, 20);

                Session["row_str"] = row_str;

                Session["List_Agents"] = list_dlr;
            }
            else
            {
                link_Previous.Enabled = false;

                List<Agents> list_dlr = dlr_mng.getAgents(idcard, fname, lname, 0, 20);

                Session["row_str"] = 0;

                Session["List_Agents"] = list_dlr;
            }
        }
    }
}