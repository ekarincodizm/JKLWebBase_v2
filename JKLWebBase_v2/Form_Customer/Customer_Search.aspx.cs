using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Customers;


namespace JKLWebBase_v2.Form_Customer
{
    public partial class Customer_Search : Page
    {
        Customers_Manager cust_mng = new Customers_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Customers");

            _GetCustomer();
        }

        private void _GetCustomer()
        {
            string idcard = Customer_Idcard_TBx.Text;
            string fname = Customer_Fname_TBx.Text;
            string lname = Customer_Lname_TBx.Text;

            cust_mng = new Customers_Manager();

            if (!string.IsNullOrEmpty(idcard) || !string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname))
            {
                List<Customers> list_dlr_all = cust_mng.getCustomers(idcard, fname, lname, 0, 0);

                int row = list_dlr_all.Count;

                _pageCount(row);

                List<Customers> list_cust = cust_mng.getCustomers(idcard, fname, lname, 0, 20);

                Session["idcard"] = idcard;
                Session["fname"] = fname;
                Session["lname"] = lname;
                Session["row_str"] = 0;

                Session["List_Customers"] = list_cust;
            }
        }

        private void _pageCount(int row)
        {
            int paging = row > 20 ? (row / 20) : 1;

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

            if (current_page > 1)
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

                cust_mng = new Customers_Manager();

                List<Customers> list_cust = cust_mng.getCustomers(idcard, fname, lname, row_str, 20);

                Session["row_str"] = row_str;

                Session["List_Customers"] = list_cust;
            }
            else
            {
                link_Previous.Enabled = false;

                List<Customers> list_cust = cust_mng.getCustomers(idcard, fname, lname, 0, 20);

                Session["row_str"] = 0;

                Session["List_Customers"] = list_cust;
            }
        }
    }
}