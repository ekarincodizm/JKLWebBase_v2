﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Tents_Car_Management : Page
    {
        private Base_Tents_Car_Manager bs_mng = new Base_Tents_Car_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            _GetTentsCar();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string Origin_name_ENG = string.IsNullOrEmpty(Tent_name_TBx.Text) ? "" : Tent_name_TBx.Text;
            string Origin_name_TH = string.IsNullOrEmpty(Tent_local_TBx.Text) ? "" : Tent_local_TBx.Text;

            bs_mng.addTent(Origin_name_ENG, Origin_name_TH);


            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            _clearDataAfterAdded();

            Page_Load(sender, e);
        }

        private void _GetTentsCar()
        {
            List<Base_Tents_Car> list_data = bs_mng.getTents();

            Session["List_Base_Tents_Car"] = list_data;
        }

        private void _clearDataAfterAdded()
        {
            Tent_name_TBx.Text = "";
            Tent_local_TBx.Text = "";
        }
    }
}