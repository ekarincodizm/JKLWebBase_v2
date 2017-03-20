using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Tents_Car_Edit : Page
    {
        Base_Tents_Car bs_class = new Base_Tents_Car();
        Base_Tents_Car_Manager bs_mng = new Base_Tents_Car_Manager();

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
                        bs_class = bs_mng.getTentsById(Convert.ToInt32(id));

                        _loadTentsCar(bs_class);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeTentsCar(id);

                        Response.Redirect("/Form_Base/Base_Tents_Car_Management");
                    }
                }
            }
        }

        private void _loadTentsCar(Base_Tents_Car bs_class)
        {
            Tent_name_TBx.Text = bs_class.Tent_name;
            Tent_local_TBx.Text = bs_class.Tent_local;
        }

        private void _editTentsCar(string id)
        {
            if (Request.Params["mode"] == "e")
            {
                string value_1 = string.IsNullOrEmpty(Tent_name_TBx.Text) ? "" : Tent_name_TBx.Text;
                string value_2 = string.IsNullOrEmpty(Tent_local_TBx.Text) ? "" : Tent_local_TBx.Text;

                bs_mng.editTent(Convert.ToInt32(id), value_1, value_2);
            }
        }

        private void _removeTentsCar(string id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_mng.removeTent(Convert.ToInt32(id));
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string id = code[1];

                _editTentsCar(id);
            }

            Response.Redirect("/Form_Base/Base_Tents_Car_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Tents_Car_Management");
        }
    }
}