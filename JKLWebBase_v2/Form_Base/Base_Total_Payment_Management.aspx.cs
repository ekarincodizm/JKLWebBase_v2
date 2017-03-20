using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;


namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Total_Payment_Management : Page
    {
        Base_Total_Payment_Manager bs_mng = new Base_Total_Payment_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            _GetData();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string value_1 = string.IsNullOrEmpty(Value_1_TBx.Text) ? "" : Value_1_TBx.Text;

            bs_mng.addTotalPayment(value_1);

            _clearDataAfterAdded();

            Page_Load(sender, e);
        }

        private void _GetData()
        {
            List<Base_Total_Payment> list_data = bs_mng.getTotalPayment();

            Session["List_Base_Total_Payment"] = list_data;
        }

        private void _clearDataAfterAdded()
        {
            Value_1_TBx.Text = "";

        }
    }
}