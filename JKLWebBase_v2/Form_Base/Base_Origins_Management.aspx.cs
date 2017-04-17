using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Origins_Management : Page
    {
        private Base_Origins bs_ntn = new Base_Origins();
        private Base_Origins_Manager bs_ntn_mng = new Base_Origins_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {

            _GetOrigin();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string Origin_name_ENG = string.IsNullOrEmpty(Origin_name_ENG_TBx.Text) ? "" : Origin_name_ENG_TBx.Text;
            string Origin_name_TH = string.IsNullOrEmpty(Origin_name_TH_TBx.Text) ? "" : Origin_name_TH_TBx.Text;

            bs_ntn_mng.addOrigin(Origin_name_ENG, Origin_name_TH);

            _clearDataAfterAdded();

            Page_Load(sender, e);
        }

        private void _GetOrigin()
        {
            List<Base_Origins> list_data = bs_ntn_mng.getOrigins();

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            Session["List_Base_Origin"] = list_data;
        }

        private void _clearDataAfterAdded()
        {
            Origin_name_ENG_TBx.Text = "";
            Origin_name_TH_TBx.Text = "";
        }
    }
}