using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;


namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Courts_Management : Page
    {
        Base_Courts_Manager bs_mng = new Base_Courts_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            _GetData();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string value_1 = string.IsNullOrEmpty(Value_1_TBx.Text) ? "" : Value_1_TBx.Text;

            bs_mng.addCourts(value_1);

            _clearDataAfterAdded();

            Page_Load(sender, e);
        }

        private void _GetData()
        {
            List<Base_Courts> list_data = bs_mng.getCourts();

            Session["List_Base_Courts"] = list_data;
        }

        private void _clearDataAfterAdded()
        {
            Value_1_TBx.Text = "";
        }
    }
}