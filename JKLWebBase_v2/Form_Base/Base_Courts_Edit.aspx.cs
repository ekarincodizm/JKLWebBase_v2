using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Courts_Edit : Page
    {
        private Base_Courts bs_class = new Base_Courts();
        private Base_Courts_Manager bs_mng = new Base_Courts_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_class = bs_mng.getCourtsById(Convert.ToInt32(id));

                        _loadData(bs_class);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeData(id);

                        Response.Redirect("/Form_Base/Base_Courts_Management");
                    }
                }
            }
        }

        private void _loadData(Base_Courts bs_class)
        {
            Value_1_TBx.Text = bs_class.Court_name;
        }

        private void _editData(string id)
        {
            if (Request.Params["mode"] == "e")
            {
                string value_1 = string.IsNullOrEmpty(Value_1_TBx.Text) ? "" : Value_1_TBx.Text;

                bs_mng.editCourts(Convert.ToInt32(id), value_1);
            }
        }

        private void _removeData(string id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_mng.removeCourts(Convert.ToInt32(id));
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

            Response.Redirect("/Form_Base/Base_Courts_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Courts_Management");
        }
    }
}