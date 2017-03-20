using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Origins_Edit : Page
    {
        Base_Origins bs_ntn = new Base_Origins();
        Base_Origins_Manager bs_ntn_mng = new Base_Origins_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string Origin_id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_ntn = bs_ntn_mng.getOriginById(Convert.ToInt32(Origin_id));

                        _loadOrigin(bs_ntn);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeOrigin(Origin_id);

                        Response.Redirect("/Form_Base/Base_Origins_Management");
                    }
                }
            }
        }

        private void _loadOrigin(Base_Origins bs_ntn)
        {
            Origin_name_ENG_TBx.Text = bs_ntn.Origin_name_ENG;
            Origin_name_TH_TBx.Text = bs_ntn.Origin_name_TH;
        }

        private void _editOrigin(string Origin_id)
        {
            if (Request.Params["mode"] == "e")
            {
                Base_Leasing_Code bs_lscd = new Base_Leasing_Code();

                string Origin_name_ENG = string.IsNullOrEmpty(Origin_name_ENG_TBx.Text) ? "" : Origin_name_ENG_TBx.Text;
                string Origin_name_TH = string.IsNullOrEmpty(Origin_name_TH_TBx.Text) ? "" : Origin_name_TH_TBx.Text;

                bs_ntn_mng.editOrigin(Convert.ToInt32(Origin_id), Origin_name_ENG, Origin_name_TH);
            }
        }

        private void _removeOrigin(string Origin_id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_ntn_mng.removeOrigin(Convert.ToInt32(Origin_id));
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string Origin_id = code[1];

                _editOrigin(Origin_id);
            }

            Response.Redirect("/Form_Base/Base_Origins_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Origins_Management");
        }
    }
}