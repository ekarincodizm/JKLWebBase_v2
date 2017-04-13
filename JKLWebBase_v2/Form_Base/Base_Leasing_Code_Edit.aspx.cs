﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Leasing_Code_Edit : Page
    {
        Base_Leasing_Code bs_lscd = new Base_Leasing_Code();
        Base_Leasing_Code_Manager bs_lscd_mng = new Base_Leasing_Code_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadThaiProvinces();

                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string Leasing_code_id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_lscd = bs_lscd_mng.getLeasingCodeById(Convert.ToInt32(Leasing_code_id));

                        _loadLeasingCod(bs_lscd);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeLeasingCode(Leasing_code_id);

                        Response.Redirect("/Form_Base/Base_Leasing_Code_Management");
                    }
                }
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            Leasing_code_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Leasing_code_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }

            Leasing_code_province_DDL.SelectedValue = "39";
        }

        private void _loadLeasingCod(Base_Leasing_Code bs_lscd)
        {
            Leasing_code_name_TBx.Text = bs_lscd.Leasing_code_name;
            Leasing_code_S_Name_TBx.Text = bs_lscd.Leasing_code_S_Name;
            Leasing_code_F_name_TBx.Text = bs_lscd.Leasing_code_F_Name;
            Leasing_code_tax_id_TBx.Text = bs_lscd.Leasing_code_Tax_id;
            Leasing_code_tax_subcode_TBx.Text = bs_lscd.Leasing_code_Tax_subcode;

            Leasing_code_address_no_TBx.Text = bs_lscd.Leasing_code_address_no;
            Leasing_code_vilage_TBx.Text = bs_lscd.Leasing_code_vilage.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_vilage.Split('.')[1] : "";
            Leasing_code_vilage_no_TBx.Text = bs_lscd.Leasing_code_vilage_no.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_vilage_no.Split('.')[1] : "";
            Leasing_code_alley_TBx.Text = bs_lscd.Leasing_code_alley.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_alley.Split('.')[1] : "";
            Leasing_code_road_TBx.Text = bs_lscd.Leasing_code_road.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_road.Split('.')[1] : "";
            Leasing_code_subdistrict_TBx.Text = bs_lscd.Leasing_code_subdistrict.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_subdistrict.Split('.')[1] : "";
            Leasing_code_district_TBx.Text = bs_lscd.Leasing_code_district.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_district.Split('.')[1] : "";
            Leasing_code_province_DDL.SelectedValue = bs_lscd.Leasing_code_province_id.ToString();
            Leasing_code_contry_TBx.Text = bs_lscd.Leasing_code_country;
            Leasing_code_zipcode_TBx.Text = bs_lscd.Leasing_code_zipcode;
            Leasing_code_tel_TBx.Text = bs_lscd.Leasing_code_tel;
        }

        private void _editLeasingCod(string Leasing_code_id)
        {
            if (Request.Params["mode"] == "e")
            {
                Base_Leasing_Code bs_lscd = new Base_Leasing_Code();

                bs_lscd.Leasing_code_id = Convert.ToInt32(Leasing_code_id);

                bs_lscd.Leasing_code_name = string.IsNullOrEmpty(Leasing_code_name_TBx.Text) ? "" : Leasing_code_name_TBx.Text;
                bs_lscd.Leasing_code_S_Name = string.IsNullOrEmpty(Leasing_code_S_Name_TBx.Text) ? "" : Leasing_code_S_Name_TBx.Text;
                bs_lscd.Leasing_code_F_Name = string.IsNullOrEmpty(Leasing_code_F_name_TBx.Text) ? "" : Leasing_code_F_name_TBx.Text;
                bs_lscd.Leasing_code_Tax_id = string.IsNullOrEmpty(Leasing_code_tax_id_TBx.Text) ? "" : Leasing_code_tax_id_TBx.Text;
                bs_lscd.Leasing_code_Tax_subcode = string.IsNullOrEmpty(Leasing_code_tax_subcode_TBx.Text) ? "" : Leasing_code_tax_subcode_TBx.Text;

                bs_lscd.Leasing_code_address_no = string.IsNullOrEmpty(Leasing_code_address_no_TBx.Text) ? "" : Leasing_code_address_no_TBx.Text;
                bs_lscd.Leasing_code_vilage = string.IsNullOrEmpty(Leasing_code_vilage_TBx.Text) ? "บ.-" : "บ." + Leasing_code_vilage_TBx.Text;
                bs_lscd.Leasing_code_vilage_no = string.IsNullOrEmpty(Leasing_code_vilage_no_TBx.Text) ? "ม.-" : "ม." + Leasing_code_vilage_no_TBx.Text;
                bs_lscd.Leasing_code_alley = string.IsNullOrEmpty(Leasing_code_alley_TBx.Text) ? "ซ.-" : "ซ." + Leasing_code_alley_TBx.Text;
                bs_lscd.Leasing_code_road = string.IsNullOrEmpty(Leasing_code_road_TBx.Text) ? "ถ.-" : "ถ." + Leasing_code_road_TBx.Text;
                bs_lscd.Leasing_code_subdistrict = string.IsNullOrEmpty(Leasing_code_subdistrict_TBx.Text) ? "ต.-" : "ต." + Leasing_code_subdistrict_TBx.Text;
                bs_lscd.Leasing_code_district = string.IsNullOrEmpty(Leasing_code_district_TBx.Text) ? "อ.-" : "อ." + Leasing_code_district_TBx.Text;
                bs_lscd.Leasing_code_province_id = Leasing_code_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Leasing_code_province_DDL.SelectedValue);
                bs_lscd.Leasing_code_country = string.IsNullOrEmpty(Leasing_code_contry_TBx.Text) ? "" : Leasing_code_contry_TBx.Text;
                bs_lscd.Leasing_code_zipcode = string.IsNullOrEmpty(Leasing_code_zipcode_TBx.Text) ? "" : Leasing_code_zipcode_TBx.Text;
                bs_lscd.Leasing_code_tel = string.IsNullOrEmpty(Leasing_code_tel_TBx.Text) ? "" : Leasing_code_tel_TBx.Text;

                bs_lscd_mng.editLeasingCode(bs_lscd);
            }
        }

        private void _removeLeasingCode(string Leasing_code_id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_lscd_mng.removeLeasingCode(Convert.ToInt32(Leasing_code_id));
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string Leasing_code_id = code[1];

                _editLeasingCod(Leasing_code_id);
            }

            Response.Redirect("/Form_Base/Base_Leasing_Code_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Leasing_Code_Management");
        }
    }
}