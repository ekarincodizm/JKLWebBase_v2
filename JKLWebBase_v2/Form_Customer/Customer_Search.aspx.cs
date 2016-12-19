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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            _GetCustomer();
        }

        private void _GetCustomer()
        {
            string idcard = Customer_Idcard_TBx.Text;
            string fname = Customer_Fname_TBx.Text;
            string lname = Customer_Lname_TBx.Text;

            Customers_Manager cust_mng = new Customers_Manager();

            List<Customers> list_cust = cust_mng.getCustomers(idcard, fname, lname);

            Session["List_Customers"] = list_cust;
        }
    }
}