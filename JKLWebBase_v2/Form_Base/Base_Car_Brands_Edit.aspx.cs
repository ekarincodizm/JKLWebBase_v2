using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Car_Brands_Edit : Page
    {
        Base_Car_Brands bs_class = new Base_Car_Brands();
        Base_Car_Brand_Manager bs_mng = new Base_Car_Brand_Manager();

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
                        bs_class = bs_mng.getCarBrandById(Convert.ToInt32(id));

                        _loadData(bs_class);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeData(id);

                        Response.Redirect("/Form_Base/Base_Car_Brands_Management");
                    }
                }
            }
        }

        private void _loadData(Base_Car_Brands bs_class)
        {
            Value_1_TBx.Text = bs_class.car_brand_name_eng;
            Value_2_TBx.Text = bs_class.car_brand_name_th;
        }

        private void _editData(string id)
        {
            if (Request.Params["mode"] == "e")
            {
                string value_1 = string.IsNullOrEmpty(Value_1_TBx.Text) ? "" : Value_1_TBx.Text;
                string value_2 = string.IsNullOrEmpty(Value_2_TBx.Text) ? "" : Value_2_TBx.Text;

                bs_mng.editCarBrand(Convert.ToInt32(id), value_1, value_2);
            }
        }

        private void _removeData(string id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_mng.removeCarBrand(Convert.ToInt32(id));
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

            Response.Redirect("/Form_Base/Base_Car_Brands_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Car_Brands_Management");
        }
    }
}