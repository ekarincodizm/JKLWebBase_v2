﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;


namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Zone_Service_Managenment : Page
    {
        Base_Zone_Service_Manager bs_mng = new Base_Zone_Service_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            _GetData();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string value_1 = string.IsNullOrEmpty(Value_1_TBx.Text) ? "" : Value_1_TBx.Text;
            string value_2 = string.IsNullOrEmpty(Value_2_TBx.Text) ? "" : Value_2_TBx.Text;

            bs_mng.addZoneService(value_1, value_2);

            _clearDataAfterAdded();

            Page_Load(sender, e);
        }

        private void _GetData()
        {
            List<Base_Zone_Service> list_data = bs_mng.getZoneService();

            Session["List_Base_Zone_Service"] = list_data;
        }

        private void _clearDataAfterAdded()
        {
            Value_1_TBx.Text = "";
            Value_2_TBx.Text = "";
        }
    }
}