using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Manager_Account;

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

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " จัดการข้อมูลรหัสลิสซิ่ง ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
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
            bs_lscd.Leasing_code_province = Leasing_code_province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ.-" + Leasing_code_province_DDL.SelectedItem.Text;
            bs_lscd.Leasing_code_country = string.IsNullOrEmpty(Leasing_code_contry_TBx.Text) ? "" : Leasing_code_contry_TBx.Text;
            bs_lscd.Leasing_code_zipcode = string.IsNullOrEmpty(Leasing_code_zipcode_TBx.Text) ? "" : Leasing_code_zipcode_TBx.Text;
            bs_lscd.Leasing_code_tel = string.IsNullOrEmpty(Leasing_code_tel_TBx.Text) ? "" : Leasing_code_tel_TBx.Text;

            new Base_Leasing_Code_Manager().addLeasingCode(bs_lscd);

            /// Acticity Logs System
            ///  

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " เพิ่มข้อมูลรหัสลิสซิ่ง ", acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System

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