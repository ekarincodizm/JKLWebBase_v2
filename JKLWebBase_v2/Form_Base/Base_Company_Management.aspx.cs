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
    public partial class Base_Company_Management : Page
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

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " จัดการข้อมูลสำนักงาน ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }

            _GetCompany();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            bs_cpn = new Base_Companys();

            bs_cpn.Company_code = string.IsNullOrEmpty(Company_code_TBx.Text) ? "" : Company_code_TBx.Text;
            bs_cpn.Company_N_name = string.IsNullOrEmpty(Company_N_name_TBx.Text) ? "" : Company_N_name_TBx.Text;
            bs_cpn.Company_F_name = string.IsNullOrEmpty(Company_F_name_TBx.Text) ? "" : Company_F_name_TBx.Text;
            bs_cpn.Company_tax_id = string.IsNullOrEmpty(Company_tax_id_TBx.Text) ? "" : Company_tax_id_TBx.Text;
            bs_cpn.Company_tax_subcode = string.IsNullOrEmpty(Company_tax_subcode_TBx.Text) ? "" : Company_tax_subcode_TBx.Text;

            bs_cpn.Company_address_no = string.IsNullOrEmpty(Company_address_no_TBx.Text)? "" : Company_address_no_TBx.Text;
            bs_cpn.Company_vilage = string.IsNullOrEmpty(Company_vilage_TBx.Text) ? "บ.-" : "บ." + Company_vilage_TBx.Text;
            bs_cpn.Company_vilage_no = string.IsNullOrEmpty(Company_vilage_no_TBx.Text) ? "ม.-" : "ม." + Company_vilage_no_TBx.Text;
            bs_cpn.Company_alley = string.IsNullOrEmpty(Company_alley_TBx.Text) ? "ซ.-" : "ซ." + Company_alley_TBx.Text;
            bs_cpn.Company_road = string.IsNullOrEmpty(Company_road_TBx.Text) ? "ถ.-" : "ถ." + Company_road_TBx.Text;
            bs_cpn.Company_subdistrict = string.IsNullOrEmpty(Company_subdistrict_TBx.Text) ? "ต.-" : "ต." + Company_subdistrict_TBx.Text;
            bs_cpn.Company_district = string.IsNullOrEmpty(Company_district_TBx.Text) ? "อ.-" : "อ." + Company_district_TBx.Text;
            bs_cpn.Company_province = Company_province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ.-" + Company_province_DDL.SelectedItem.Text;
            bs_cpn.Company_country = string.IsNullOrEmpty(Company_contry_TBx.Text) ? "" : Company_contry_TBx.Text;
            bs_cpn.Company_zipcode = string.IsNullOrEmpty(Company_zipcode_TBx.Text) ? "" : Company_zipcode_TBx.Text;
            bs_cpn.Company_tel = string.IsNullOrEmpty(Company_tel_TBx.Text) ? "" : Company_tel_TBx.Text;

            bs_cpn_mng.addCompany(bs_cpn);

            /// Acticity Logs System
            ///  

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " เพิ่มข้อมูลสำนักงาน ", acc_lgn.resu, package_login.Company_N_name);

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
            Company_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Company_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }

            Company_province_DDL.SelectedValue = "39";
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Pageing System                              ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        protected void link_Previous_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            if (current_page > 1)
            {
                int prev = current_page - 1;

                Paging_DDL.SelectedValue = prev.ToString();

                _getMoreCompany(prev);
            }
        }
        protected void Paging_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            _getMoreCompany(current_page);
        }

        protected void link_Next_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            int next = current_page + 1;

            Paging_DDL.SelectedValue = next.ToString();

            _getMoreCompany(next);
        }

        private void _GetCompany()
        {
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(0, 20);

            int row = list_data.Count;

            _pageCount(row);

            Session["row_str"] = 0;
            Session["List_Base_Companys"] = list_data;

        }

        private void _getMoreCompany(int current_page)
        {
            if (current_page > 1)
            {
                int row_str = (current_page - 1) * 20;

                link_Previous.Enabled = true;

                List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(row_str, 20);

                Session["row_str"] = row_str;

                Session["List_Customers"] = list_data;
            }
            else
            {
                link_Previous.Enabled = false;

                List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(0, 20);

                Session["row_str"] = 0;

                Session["List_Customers"] = list_data;
            }
        }

        private void _pageCount(int row)
        {
            int paging = row > 20 ? (row / 20) + 1 : 1;

            for (int i = 1; i <= paging; i++)
            {
                Paging_DDL.Items.Add(new ListItem("" + i, "" + i));
            }

            if (paging == 1)
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = false;
            }
            else if (paging > 1 && Paging_DDL.Items[0].Value == "0")
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = true;
            }
            else
            {
                link_Previous.Enabled = true;
                link_Next.Enabled = true;
            }
        }

        private void _clearDataAfterAdded()
        {
            Company_code_TBx.Text = "";
            Company_N_name_TBx.Text = "";
            Company_F_name_TBx.Text = "";
            Company_tax_id_TBx.Text = "";
            Company_tax_subcode_TBx.Text = "";

            Company_address_no_TBx.Text = "";
            Company_vilage_TBx.Text = "";
            Company_vilage_no_TBx.Text = "";
            Company_alley_TBx.Text = "";
            Company_road_TBx.Text = "";
            Company_subdistrict_TBx.Text = "";
            Company_district_TBx.Text = "";
            Company_province_DDL.SelectedValue = "39";
            Company_contry_TBx.Text = "";
            Company_zipcode_TBx.Text = "";
            Company_tel_TBx.Text = "";
        }
    }
}