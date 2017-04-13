﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Nationalitys_Management : Page
    {
        Base_Nationalitys bs_ntn = new Base_Nationalitys();
        Base_Nationalitys_Manager bs_ntn_mng = new Base_Nationalitys_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            _GetNationality();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string Nationality_name_ENG = string.IsNullOrEmpty(Nationality_name_ENG_TBx.Text) ? "" : Nationality_name_ENG_TBx.Text;
            string Nationality_name_TH = string.IsNullOrEmpty(Nationality_name_TH_TBx.Text) ? "" : Nationality_name_TH_TBx.Text;

            bs_ntn_mng.addNationality(Nationality_name_ENG, Nationality_name_TH);

            _clearDataAfterAdded();

            Page_Load(sender, e);
        }

        private void _GetNationality()
        {
            List<Base_Nationalitys> list_data = bs_ntn_mng.getNationalitys();

            Session["List_Base_Nationality"] = list_data;
        }

        private void _clearDataAfterAdded()
        {
            Nationality_name_ENG_TBx.Text = "";
            Nationality_name_TH_TBx.Text = "";
        }
    }
}