using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Company_Edit : Page
    {
        private Base_Companys bs_cpn = new Base_Companys();
        private Base_Companys_Manager bs_cpn_mng = new Base_Companys_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadThaiProvinces();

                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string Company_id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_cpn = bs_cpn_mng.getCompanysById(Company_id);

                        _loadCompany(bs_cpn);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeCompany(Company_id);

                        Response.Redirect("/Form_Base/Base_Company_Management");
                    }
                }
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string Company_id = code[1];

                _editCompany(Company_id);

            }

            Response.Redirect("/Form_Base/Base_Company_Management");
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            Company_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Company_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }

            Company_province_DDL.SelectedValue = "39";
        }

        private void _loadCompany(Base_Companys bs_cpn)
        {
            Company_code_TBx.Text = bs_cpn.Company_code;
            Company_N_name_TBx.Text = bs_cpn.Company_N_name;
            Company_F_name_TBx.Text = bs_cpn.Company_F_name;
            Company_tax_id_TBx.Text = bs_cpn.Company_tax_id;
            Company_tax_subcode_TBx.Text = bs_cpn.Company_tax_subcode;

            Company_address_no_TBx.Text = bs_cpn.Company_address_no;
            Company_vilage_TBx.Text = bs_cpn.Company_vilage.IndexOf('.') >= 1 ? bs_cpn.Company_vilage.Split('.')[1] : "";
            Company_vilage_no_TBx.Text = bs_cpn.Company_vilage_no.IndexOf('.') >= 1 ? bs_cpn.Company_vilage_no.Split('.')[1] : "";
            Company_alley_TBx.Text = bs_cpn.Company_alley.IndexOf('.') >= 1 ? bs_cpn.Company_alley.Split('.')[1] : "";
            Company_road_TBx.Text = bs_cpn.Company_road.IndexOf('.') >= 1 ? bs_cpn.Company_road.Split('.')[1] : "";
            Company_subdistrict_TBx.Text = bs_cpn.Company_subdistrict.IndexOf('.') >= 1 ? bs_cpn.Company_subdistrict.Split('.')[1] : "";
            Company_district_TBx.Text = bs_cpn.Company_district.IndexOf('.') >= 1 ? bs_cpn.Company_district.Split('.')[1] : "";
            Company_province_DDL.SelectedValue = bs_cpn.Company_province_id.ToString();
            Company_contry_TBx.Text = bs_cpn.Company_country;
            Company_zipcode_TBx.Text = bs_cpn.Company_zipcode;
            Company_tel_TBx.Text = bs_cpn.Company_tel;

            Package_TBx.Text = bs_cpn.Company_package;
        }

        private void _editCompany(string Company_id)
        {
            if (Request.Params["mode"] == "e")
            {
                Base_Companys bs_cpn = new Base_Companys();

                bs_cpn.Company_id = Convert.ToInt32(Company_id);

                bs_cpn.Company_code = string.IsNullOrEmpty(Company_code_TBx.Text) ? "" : Company_code_TBx.Text;
                bs_cpn.Company_N_name = string.IsNullOrEmpty(Company_N_name_TBx.Text) ? "" : Company_N_name_TBx.Text;
                bs_cpn.Company_F_name = string.IsNullOrEmpty(Company_F_name_TBx.Text) ? "" : Company_F_name_TBx.Text;
                bs_cpn.Company_tax_id = string.IsNullOrEmpty(Company_tax_id_TBx.Text) ? "" : Company_tax_id_TBx.Text;
                bs_cpn.Company_tax_subcode = string.IsNullOrEmpty(Company_tax_subcode_TBx.Text) ? "" : Company_tax_subcode_TBx.Text;

                bs_cpn.Company_address_no = string.IsNullOrEmpty(Company_address_no_TBx.Text) ? "" : Company_address_no_TBx.Text;
                bs_cpn.Company_vilage = string.IsNullOrEmpty(Company_vilage_TBx.Text) ? "บ.-" : "บ." + Company_vilage_TBx.Text;
                bs_cpn.Company_vilage_no = string.IsNullOrEmpty(Company_vilage_no_TBx.Text) ? "ม.-" : "ม." + Company_vilage_no_TBx.Text;
                bs_cpn.Company_alley = string.IsNullOrEmpty(Company_alley_TBx.Text) ? "ซ.-" : "ซ." + Company_alley_TBx.Text;
                bs_cpn.Company_road = string.IsNullOrEmpty(Company_road_TBx.Text) ? "ถ.-" : "ถ." + Company_road_TBx.Text;
                bs_cpn.Company_subdistrict = string.IsNullOrEmpty(Company_subdistrict_TBx.Text) ? "ต.-" : "ต." + Company_subdistrict_TBx.Text;
                bs_cpn.Company_district = string.IsNullOrEmpty(Company_district_TBx.Text) ? "อ.-" : "อ." + Company_district_TBx.Text;
                bs_cpn.Company_province_id = Company_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Company_province_DDL.SelectedValue);
                bs_cpn.Company_country = string.IsNullOrEmpty(Company_contry_TBx.Text) ? "" : Company_contry_TBx.Text;
                bs_cpn.Company_zipcode = string.IsNullOrEmpty(Company_zipcode_TBx.Text) ? "" : Company_zipcode_TBx.Text;
                bs_cpn.Company_tel = string.IsNullOrEmpty(Company_tel_TBx.Text) ? "" : Company_tel_TBx.Text;

                bs_cpn_mng.editCompany(bs_cpn);


                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลสำนักงาน ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }

        private void _removeCompany(string Company_id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_cpn_mng.removeCompany(Convert.ToInt32(Company_id));

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ลบข้อมูลสำนักงาน ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Company_Management");
        }
    }
}