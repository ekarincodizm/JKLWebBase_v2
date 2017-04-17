using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Leasing_Code_Management : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadThaiProvinces();
            }

            _GetLeasingCode();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            Base_Leasing_Code bs_lscd = new Base_Leasing_Code();

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

            new Base_Leasing_Code_Manager().addLeasingCode(bs_lscd);

            _clearDataAfterAdded();

            Page_Load(sender, e);
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

        private void _GetLeasingCode()
        {
            List<Base_Leasing_Code> list_data = new Base_Leasing_Code_Manager().getLeasingCode();

            int row = list_data.Count;

            Session["List_Base_Leasing_Code"] = list_data;
        }

        private void _clearDataAfterAdded()
        {
            Leasing_code_name_TBx.Text = "";
            Leasing_code_S_Name_TBx.Text = "";
            Leasing_code_F_name_TBx.Text = "";
            Leasing_code_tax_id_TBx.Text = "";
            Leasing_code_tax_subcode_TBx.Text = "";

            Leasing_code_address_no_TBx.Text = "";
            Leasing_code_vilage_TBx.Text = "";
            Leasing_code_vilage_no_TBx.Text = "";
            Leasing_code_alley_TBx.Text = "";
            Leasing_code_road_TBx.Text = "";
            Leasing_code_subdistrict_TBx.Text = "";
            Leasing_code_district_TBx.Text = "";
            Leasing_code_province_DDL.SelectedValue = "39";
            Leasing_code_contry_TBx.Text = "";
            Leasing_code_zipcode_TBx.Text = "";
            Leasing_code_tel_TBx.Text = "";
        }
    }
}