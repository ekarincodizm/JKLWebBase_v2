using JKLWebBase_v2.Class_Dealers;
using JKLWebBase_v2.Managers_Dealers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Form_Dealer
{
    public partial class Dealer_Search : Page
    {
        Dealers_Manager dlr_mng = new Dealers_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Dealers");

            _GetDealer();
        }

        private void _GetDealer()
        {
            string idcard = Dealer_Idcard_TBx.Text;
            string fname = Dealer_Fname_TBx.Text;
            string lname = Dealer_Lname_TBx.Text;

            dlr_mng = new Dealers_Manager();

            if (!string.IsNullOrEmpty(idcard) || !string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname))
            {
                List<Dealers> list_dlr_all = dlr_mng.getDealers(idcard, fname, lname, 0, 0);

                int row = list_dlr_all.Count;

                _pageCount(row);

                List<Dealers> list_dlr = dlr_mng.getDealers(idcard, fname, lname, 0, 20);

                Session["idcard"] = idcard;
                Session["fname"] = fname;
                Session["lname"] = lname;
                Session["row_str"] = 0;

                Session["List_Dealers"] = list_dlr;
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

                _getMoreDealer(prev);
            }
        }
        protected void Paging_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            _getMoreDealer(current_page);
        }

        protected void link_Next_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            int next = current_page + 1;

            Paging_DDL.SelectedValue = next.ToString();

            _getMoreDealer(next);
        }
        
        private void _getMoreDealer(int current_page)
        {
            string idcard = (string)Session["idcard"];
            string fname = (string)Session["fname"];
            string lname = (string)Session["lname"];

            if (current_page > 1)
            {
                int row_str = (current_page - 1) * 20;

                link_Previous.Enabled = true;

                dlr_mng = new Dealers_Manager();

                List<Dealers> list_dlr = dlr_mng.getDealers(idcard, fname, lname, row_str, 20);

                Session["row_str"] = row_str;

                Session["List_Dealers"] = list_dlr;
            }
            else
            {
                link_Previous.Enabled = false;

                List<Dealers> list_dlr = dlr_mng.getDealers(idcard, fname, lname, 0, 20);

                Session["row_str"] = 0;

                Session["List_Dealers"] = list_dlr;
            }
        }
    }
}