using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Zone_Service_Edit : Page
    {
        private Base_Zone_Service bs_class = new Base_Zone_Service();
        private Base_Zone_Service_Manager bs_mng = new Base_Zone_Service_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_class = bs_mng.getZoneById(Convert.ToInt32(id));

                        _loadData(bs_class);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeData(id);

                        Response.Redirect("/Form_Base/Base_Zone_Service_Managenment");
                    }
                }
            }
        }

        private void _loadData(Base_Zone_Service bs_class)
        {
            Value_1_TBx.Text = bs_class.Zone_code;
            Value_2_TBx.Text = bs_class.Zone_name;
        }

        private void _editData(string id)
        {
            if (Request.Params["mode"] == "e")
            {
                string value_1 = string.IsNullOrEmpty(Value_1_TBx.Text) ? "" : Value_1_TBx.Text;
                string value_2 = string.IsNullOrEmpty(Value_2_TBx.Text) ? "" : Value_2_TBx.Text;

                bs_mng.editZoneService(Convert.ToInt32(id), value_1, value_2);
            }
        }

        private void _removeData(string id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_mng.removeZoneService(Convert.ToInt32(id));
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string id = code[1];

                _editData(id);
            }

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            Response.Redirect("/Form_Base/Base_Zone_Service_Managenment");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Zone_Service_Managenment");
        }
    }
}