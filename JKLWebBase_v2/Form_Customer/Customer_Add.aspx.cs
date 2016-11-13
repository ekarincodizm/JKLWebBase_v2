using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Managers_Leasings;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Customer_Add : System.Web.UI.Page
    {
        bool find_customer = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadHomeStatus();
                _loadNationality();
                _loadOrigin();
                _loadPersonStatus();
                _loadThaiProvinces();

                Spouse_Panel.Visible = false;
            }
        }

        protected void Cust_idcard_TBx_TextChanged(object sender, EventArgs e)
        {
            _CheckCustomer();
        }

        protected void Cust_Search_Btn_Click(object sender, EventArgs e)
        {
            _CheckCustomer();
        }

        protected void Cust_status_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cust_status_DDL.SelectedIndex == 2 || Cust_status_DDL.SelectedIndex == 3)
            {
                Spouse_Panel.Visible = true;
            }
            else
            {
                Spouse_Panel.Visible = false;
            }
        }

        protected void Home_Copy_Idcard_btn_Click(object sender, EventArgs e)
        {
            _CopyBaseDataAddress(1);
        }

        protected void Current_Copy_Idcard_btn_Click(object sender, EventArgs e)
        {
            _CopyBaseDataAddress(2);
        }

        protected void Current_Copy_Home_btn_Click(object sender, EventArgs e)
        {
            _CopyBaseDataAddress(3);
        }

        protected void link_Leasing_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Add");
        }

        protected void Customer_Add_Save_Btn_Click(object sender, EventArgs e)
        {

            if (!find_customer)
            {
                _AddCustomer();
            }

            Response.Redirect("/Form_Leasings/Leasing_Add");
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // เชื้อชาติ
        private void _loadOrigin()
        {
            List<Base_Origins> list_data = new Base_Origins_Manager().getOrigins();
            Cust_Origin_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            Spouse_Origin_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Origins data = list_data[i];
                Cust_Origin_DDL.Items.Add(new ListItem(data.Origin_name_TH + " ( " + data.Origin_name_ENG + " ) ", data.Origin_id.ToString()));
                Spouse_Origin_DDL.Items.Add(new ListItem(data.Origin_name_TH + " ( " + data.Origin_name_ENG + " ) ", data.Origin_id.ToString()));
            }
        }

        // สัญชาติ
        private void _loadNationality()
        {
            List<Base_Nationalitys> list_data = new Base_Nationalitys_Manager().getNationalitys();
            Cust_Nationality_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            Spouse_Nationality_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Nationalitys data = list_data[i];
                Cust_Nationality_DDL.Items.Add(new ListItem(data.Nationality_name_TH + " ( " + data.Nationality_name_ENG + " ) ", data.Nationality_id.ToString()));
                Spouse_Nationality_DDL.Items.Add(new ListItem(data.Nationality_name_TH + " ( " + data.Nationality_name_ENG + " ) ", data.Nationality_id.ToString()));
            }
        }

        // สถานะภาพการสมรส
        private void _loadPersonStatus()
        {
            List<Base_Person_Status> list_data = new Base_Person_Status_Manager().getPersonStatus();
            Cust_status_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Person_Status data = list_data[i];
                Cust_status_DDL.Items.Add(new ListItem(data.person_status_name, data.person_status_id.ToString()));
            }
        }

        // สถานะภาพของผู้อาศัย
        private void _loadHomeStatus()
        {
            List<Base_Home_Status> list_data = new Base_Home_Status_Manager().getHomeStatus();
            Current_Cust_Home_status_id_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Home_Cust_Home_status_id_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Idcard_Cust_Home_status_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Home_Status data = list_data[i];
                Current_Cust_Home_status_id_DDL.Items.Add(new ListItem(data.Home_status_name, data.Home_status_id.ToString()));
                Home_Cust_Home_status_id_DDL.Items.Add(new ListItem(data.Home_status_name, data.Home_status_id.ToString()));
                Idcard_Cust_Home_status_DDL.Items.Add(new ListItem(data.Home_status_name, data.Home_status_id.ToString()));
            }
        }

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            Current_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Cust_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Home_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Idcard_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Spouse_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Spouse_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Current_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Cust_job_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Home_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Idcard_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Spouse_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Spouse_job_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }

            Current_Cust_Province_DDL.SelectedValue = "39";
            Cust_job_province_DDL.SelectedValue = "39";
            Home_Cust_Province_DDL.SelectedValue = "39";
            Idcard_Cust_Province_DDL.SelectedValue = "39";
            Spouse_province_DDL.SelectedValue = "39";
            Spouse_job_province_DDL.SelectedValue = "39";
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckCustomer()
        {
            Customers cust = new Customers_Manager().getCustomersByIdCard(Cust_idcard_TBx.Text);
            if (cust.Cust_idcard != null)
            {
                _GetCustomer(cust);
                find_customer = true;
                link_Leasing_Add.Enabled = true;

            }
            else
            {
                Alert_Warning_Panel.Visible = true;
                Alert_Id_Card_Lbl.Text = "ไม่พบเลขบัตรประชาชน " + Cust_idcard_TBx.Text + " นี้ในระบบ";

                find_customer = false;

                Cust_idcard_TBx.Focus();
            }

        }

        /*******************************************************************************************************************************************************************************
        ****************************************************              Get Data And Replace To Form Function                 ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/
        
        private void _GetCustomer(Customers ctm)
        {
            Cust_idcard_TBx.Text = ctm.Cust_idcard;
            Cust_Fname_TBx.Text = ctm.Cust_Fname;
            Cust_LName_TBx.Text = ctm.Cust_LName;
            Cust_B_date_TBx.Text = ctm.Cust_B_date.Split(' ')[0];
            Cust_Idcard_without_TBx.Text = ctm.Cust_Idcard_without;
            Cust_Idcard_start_TBx.Text = ctm.Cust_Idcard_start.Split(' ')[0];
            Cust_Idcard_expire_TBx.Text = ctm.Cust_Idcard_expire.Split(' ')[0];
            Cust_Nationality_DDL.SelectedValue = ctm.Cust_Nationality.ToString();
            Cust_Origin_DDL.SelectedValue = ctm.Cust_Origin.ToString();
            Cust_job_TBx.Text = ctm.Cust_job;
            Cust_job_position_TBx.Text = ctm.Cust_job_position;
            Cust_job_long_TBx.Text = ctm.Cust_job_long.ToString();
            Cust_job_local_name_TBx.Text = ctm.Cust_job_local_name;
            Cust_job_address_no_TBx.Text = ctm.Cust_job_address_no;
            Cust_job_vilage_TBx.Text = ctm.Cust_job_vilage;
            Cust_job_vilage_no_TBx.Text = ctm.Cust_job_vilage_no;
            Cust_job_alley_TBx.Text = ctm.Cust_job_alley;
            Cust_job_road_TBx.Text = ctm.Cust_job_road;
            Cust_job_subdistrict_TBx.Text = ctm.Cust_job_subdistrict;
            Cust_job_district_TBx.Text = ctm.Cust_job_district;
            Cust_job_province_DDL.SelectedValue = ctm.Cust_job_province.ToString();
            Cust_job_contry_TBx.Text = ctm.Cust_job_country;
            Cust_job_zipcode_TBx.Text = ctm.Cust_job_zipcode;
            Cust_job_tel_TBx.Text = ctm.Cust_job_tel;
            Cust_job_email_TBx.Text = ctm.Cust_job_email;
            Cust_job_salary_TBx.Text = ctm.Cust_job_salary.ToString();
            Cust_status_DDL.SelectedValue = ctm.Cust_status_id.ToString();

            _GetCustomerAddress(ctm.Cust_id);

            Session["Customer"] = ctm;

            if (ctm.Cust_status_id == 2 || ctm.Cust_status_id == 3)
            {
                _GetCustomerSpouse(ctm.Cust_id);
            }
        }

        private void _GetCustomerAddress(string Cust_id)
        {
            // ที่อยู่ตามบัตรประชาชน
            Customers_Address ctmadd_idcard = new Customers_Address_Manager().getCustomersAddressByCustomerId(Cust_id, 1);

            Idcard_Cust_Address_no_Tbx.Text = ctmadd_idcard.Cust_Address_no;
            Idcard_Cust_Vilage_Tbx.Text = ctmadd_idcard.Cust_Vilage;
            Idcard_Cust_Vilage_no_Tbx.Text = ctmadd_idcard.Cust_Vilage_no;
            Idcard_Cust_Alley_Tbx.Text = ctmadd_idcard.Cust_Alley;
            Idcard_Cust_Road_Tbx.Text = ctmadd_idcard.Cust_Road;
            Idcard_Cust_Subdistrict_Tbx.Text = ctmadd_idcard.Cust_Subdistrict;
            Idcard_Cust_District_Tbx.Text = ctmadd_idcard.Cust_District;
            Idcard_Cust_Province_DDL.SelectedValue = ctmadd_idcard.Cust_Province.ToString();
            Idcard_Cust_Country_Tbx.Text = ctmadd_idcard.Cust_Country;
            Idcard_Cust_Zipcode_Tbx.Text = ctmadd_idcard.Cust_Zipcode;
            Idcard_Cust_Tel_Tbx.Text = ctmadd_idcard.Cust_Tel;
            Idcard_Cust_Home_status_DDL.SelectedValue = ctmadd_idcard.Cust_Home_status_id.ToString();

            // ที่อยู่ตามทะเบียนบ้าน
            Customers_Address ctmadd_home = new Customers_Address_Manager().getCustomersAddressByCustomerId(Cust_id, 2);

            Home_Cust_Address_no_TBx.Text = ctmadd_home.Cust_Address_no;
            Home_Cust_Vilage_TBx.Text = ctmadd_home.Cust_Vilage;
            Home_Cust_Vilage_no_TBx.Text = ctmadd_home.Cust_Vilage_no;
            Home_Cust_Alley_TBx.Text = ctmadd_home.Cust_Alley;
            Home_Cust_Road_TBx.Text = ctmadd_home.Cust_Road;
            Home_Cust_Subdistrict_TBx.Text = ctmadd_home.Cust_Subdistrict;
            Home_Cust_District_TBx.Text = ctmadd_home.Cust_District;
            Home_Cust_Province_DDL.SelectedValue = ctmadd_home.Cust_Province.ToString();
            Home_Cust_Country_TBx.Text = ctmadd_home.Cust_Country;
            Home_Cust_Zipcode_TBx.Text = ctmadd_home.Cust_Zipcode;
            Home_Cust_Tel_TBx.Text = ctmadd_home.Cust_Tel;
            Home_Cust_Home_status_id_DDL.SelectedValue = ctmadd_home.Cust_Home_status_id.ToString();
            Home_Cust_Gps_Latitude_TBx.Text = ctmadd_home.Cust_Gps_Latitude;
            Home_Cust_Gps_Longitude_TBx.Text = ctmadd_home.Cust_Gps_Longitude;

            // ที่อยู่ปัจจุบัน
            Customers_Address ctmadd_current = new Customers_Address_Manager().getCustomersAddressByCustomerId(Cust_id, 3);

            Current_Cust_Address_no_TBx.Text = ctmadd_current.Cust_Address_no;
            Current_Cust_Vilage_TBx.Text = ctmadd_current.Cust_Vilage;
            Current_Cust_Vilage_no_TBx.Text = ctmadd_current.Cust_Vilage_no;
            Current_Cust_Road_TBx.Text = ctmadd_current.Cust_Road;
            Current_Cust_Subdistrict_TBx.Text = ctmadd_current.Cust_Subdistrict;
            Current_Cust_District_TBx.Text = ctmadd_current.Cust_District;
            Current_Cust_Province_DDL.SelectedValue = ctmadd_current.Cust_Province.ToString();
            Current_Cust_Country_TBx.Text = ctmadd_current.Cust_Country;
            Current_Cust_Zipcode_TBx.Text = ctmadd_current.Cust_Zipcode;
            Current_Cust_Tel_TBx.Text = ctmadd_current.Cust_Tel;
            Current_Cust_Home_status_id_DDL.SelectedValue = ctmadd_current.Cust_Home_status_id.ToString();

            Session["Address_Idcard"] = ctmadd_idcard;
            Session["Address_Home"] = ctmadd_home;
            Session["Address_Current"] = ctmadd_current;
        }

        private void _GetCustomerSpouse(string Cust_id)
        {
            Customers_Spouse cmarry = new Customers_Spouse_Manager().getCustomersSpouseByCustomerId(Cust_id);

            Spouse_idcard_TBx.Text = cmarry.Spouse_idcard;
            Spouse_Fname_TBx.Text = cmarry.Spouse_Fname;
            Spouse_Lname_TBx.Text = cmarry.Spouse_Lname;
            Spouse_Nationality_DDL.SelectedValue = cmarry.Spouse_Nationality.ToString();
            Spouse_Origin_DDL.SelectedValue = cmarry.Spouse_Origin.ToString();
            Spouse_address_no_TBx.Text = cmarry.Spouse_address_no;
            Spouse_vilage_TBx.Text = cmarry.Spouse_vilage;
            Spouse_vilage_no_TBx.Text = cmarry.Spouse_vilage_no;
            Spouse_alley_TBx.Text = cmarry.Spouse_alley;
            Spouse_road_TBx.Text = cmarry.Spouse_road;
            Spouse_subdistrict_TBx.Text = cmarry.Spouse_subdistrict;
            Spouse_district_TBx.Text = cmarry.Spouse_district;
            Spouse_province_DDL.SelectedValue = cmarry.Spouse_province.ToString();
            Spouse_country_TBx.Text = cmarry.Spouse_country;
            Spouse_zipcode_TBx.Text = cmarry.Spouse_zipcode;
            Spouse_job_TBx.Text = cmarry.Spouse_job;
            Spouse_job_position_TBx.Text = cmarry.Spouse_job_position;
            Spouse_job_long_TBx.Text = cmarry.Spouse_job_long.ToString();
            Spouse_job_salary_TBx.Text = cmarry.Spouse_job_salary.ToString();
            Spouse_job_local_name_TBx.Text = cmarry.Spouse_job_local_name;
            Spouse_job_address_no_TBx.Text = cmarry.Spouse_job_address_no;
            Spouse_job_vilage_TBx.Text = cmarry.Spouse_job_vilage;
            Spouse_job_vilage_no_TBx.Text = cmarry.Spouse_job_vilage_no;
            Spouse_job_alley_TBx.Text = cmarry.Spouse_job_alley;
            Spouse_job_road_TBx.Text = cmarry.Spouse_job_road;
            Spouse_job_subdistrict_TBx.Text = cmarry.Spouse_job_subdistrict;
            Spouse_job_district_TBx.Text = cmarry.Spouse_job_district;
            Spouse_job_province_DDL.SelectedValue = cmarry.Spouse_job_province.ToString();
            Spouse_job_country_TBx.Text = cmarry.Spouse_job_country;
            Spouse_job_zipcode_TBx.Text = cmarry.Spouse_job_zipcode;
            Spouse_job_tel_TBx.Text = cmarry.Spouse_job_tel;
            Spouse_tel_TBx.Text = cmarry.Spouse_tel;
            Spouse_email_TBx.Text = cmarry.Spouse_email;

            Session["Cust_Marry"] = cmarry;
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _AddCustomer()
        {
            Customers_Manager ctm_mng = new Customers_Manager();
            Customers ctm = new Customers();

            ctm.Cust_id = ctm_mng.generateCustomerID();
            ctm.Cust_idcard = string.IsNullOrEmpty(Cust_idcard_TBx.Text) ? "" : Cust_idcard_TBx.Text;
            ctm.Cust_Fname = string.IsNullOrEmpty(Cust_Fname_TBx.Text) ? "" : Cust_Fname_TBx.Text;
            ctm.Cust_LName = string.IsNullOrEmpty(Cust_LName_TBx.Text) ? "" : Cust_LName_TBx.Text;
            ctm.Cust_B_date = string.IsNullOrEmpty(Cust_B_date_TBx.Text) ? "" : DateTimeUtility.convertDateToMYSQL(Cust_B_date_TBx.Text);
            ctm.Cust_age = string.IsNullOrEmpty(Cust_B_date_TBx.Text) ? 0 : DateTime.Now.Year - (Convert.ToInt32(Cust_B_date_TBx.Text.Split('/')[2].ToString()) - 543);
            ctm.Cust_Idcard_without = string.IsNullOrEmpty(Cust_Idcard_without_TBx.Text) ? "" : Cust_Idcard_without_TBx.Text;
            ctm.Cust_Idcard_start = string.IsNullOrEmpty(Cust_Idcard_start_TBx.Text) ? "" : DateTimeUtility.convertDateToMYSQL(Cust_Idcard_start_TBx.Text);
            ctm.Cust_Idcard_expire = string.IsNullOrEmpty(Cust_Idcard_expire_TBx.Text) ? "" : DateTimeUtility.convertDateToMYSQL(Cust_Idcard_expire_TBx.Text);
            ctm.Cust_Nationality = Cust_Nationality_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Cust_Nationality_DDL.SelectedValue);
            ctm.Cust_Origin = Cust_Origin_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Cust_Origin_DDL.SelectedValue);
            ctm.Cust_job = string.IsNullOrEmpty(Cust_job_TBx.Text) ? "" : Cust_job_TBx.Text;
            ctm.Cust_job_position = string.IsNullOrEmpty(Cust_job_position_TBx.Text) ? "" : Cust_job_position_TBx.Text;
            ctm.Cust_job_long = string.IsNullOrEmpty(Cust_job_long_TBx.Text) ? 0 : Convert.ToInt32(Cust_job_long_TBx.Text);
            ctm.Cust_job_local_name = string.IsNullOrEmpty(Cust_job_local_name_TBx.Text) ? "" : Cust_job_local_name_TBx.Text;
            ctm.Cust_job_address_no = string.IsNullOrEmpty(Cust_job_address_no_TBx.Text) ? "" : Cust_job_address_no_TBx.Text;
            ctm.Cust_job_vilage = string.IsNullOrEmpty(Cust_job_vilage_TBx.Text) ? "" : Cust_job_vilage_TBx.Text;
            ctm.Cust_job_vilage_no = string.IsNullOrEmpty(Cust_job_vilage_no_TBx.Text) ? "" : Cust_job_vilage_no_TBx.Text;
            ctm.Cust_job_alley = string.IsNullOrEmpty(Cust_job_alley_TBx.Text) ? "" : Cust_job_alley_TBx.Text;
            ctm.Cust_job_road = string.IsNullOrEmpty(Cust_job_road_TBx.Text) ? "" : Cust_job_road_TBx.Text;
            ctm.Cust_job_subdistrict = string.IsNullOrEmpty(Cust_job_subdistrict_TBx.Text) ? "" : Cust_job_subdistrict_TBx.Text;
            ctm.Cust_job_district = string.IsNullOrEmpty(Cust_job_district_TBx.Text) ? "" : Cust_job_district_TBx.Text;
            ctm.Cust_job_province = Cust_job_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Cust_job_province_DDL.SelectedValue);
            ctm.Cust_job_country = string.IsNullOrEmpty(Cust_job_contry_TBx.Text) ? "" : Cust_job_contry_TBx.Text;
            ctm.Cust_job_zipcode = string.IsNullOrEmpty(Cust_job_zipcode_TBx.Text) ? "" : Cust_job_zipcode_TBx.Text;
            ctm.Cust_job_tel = string.IsNullOrEmpty(Cust_job_tel_TBx.Text) ? "" : Cust_job_tel_TBx.Text;
            ctm.Cust_job_email = string.IsNullOrEmpty(Cust_job_email_TBx.Text) ? "" : Cust_job_email_TBx.Text;
            ctm.Cust_job_salary = string.IsNullOrEmpty(Cust_job_salary_TBx.Text) ? 0 : Convert.ToDouble(Cust_job_salary_TBx.Text);
            ctm.Cust_status_id = Cust_status_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Cust_status_DDL.SelectedValue);

            ctm_mng.addCustomers(ctm);

            _AddCustomerAddress(ctm.Cust_id);

            Session["Customer"] = ctm;

            if (ctm.Cust_status_id == 2 || ctm.Cust_status_id == 3)
            {
                _AddCustomerSpouse(ctm.Cust_id);
            }

        }

        private void _AddCustomerAddress(string custId)
        {
            // ที่อยู่ตามบัตรประชาชน
            Customers_Address ctmadd_idcard = new Customers_Address();

            ctmadd_idcard.Cust_id = custId;
            ctmadd_idcard.Cust_Address_type_id = 1;
            ctmadd_idcard.Cust_Address_no = string.IsNullOrEmpty(Idcard_Cust_Address_no_Tbx.Text) ? "" : Idcard_Cust_Address_no_Tbx.Text;
            ctmadd_idcard.Cust_Vilage = string.IsNullOrEmpty(Idcard_Cust_Vilage_Tbx.Text) ? "" : Idcard_Cust_Vilage_Tbx.Text;
            ctmadd_idcard.Cust_Vilage_no = string.IsNullOrEmpty(Idcard_Cust_Vilage_no_Tbx.Text) ? "" : Idcard_Cust_Vilage_no_Tbx.Text;
            ctmadd_idcard.Cust_Alley= string.IsNullOrEmpty(Idcard_Cust_Alley_Tbx.Text) ? "" : Idcard_Cust_Alley_Tbx.Text;
            ctmadd_idcard.Cust_Road = string.IsNullOrEmpty(Idcard_Cust_Road_Tbx.Text) ? "" : Idcard_Cust_Road_Tbx.Text;
            ctmadd_idcard.Cust_Subdistrict = string.IsNullOrEmpty(Idcard_Cust_Subdistrict_Tbx.Text) ? "" : Idcard_Cust_Subdistrict_Tbx.Text;
            ctmadd_idcard.Cust_District = string.IsNullOrEmpty(Idcard_Cust_District_Tbx.Text) ? "" : Idcard_Cust_District_Tbx.Text;
            ctmadd_idcard.Cust_Province = Idcard_Cust_Province_DDL.SelectedIndex <= 0?  39  : Convert.ToInt32(Idcard_Cust_Province_DDL.SelectedValue);
            ctmadd_idcard.Cust_Country = string.IsNullOrEmpty(Idcard_Cust_Country_Tbx.Text) ? "" : Idcard_Cust_Country_Tbx.Text;
            ctmadd_idcard.Cust_Zipcode = string.IsNullOrEmpty(Idcard_Cust_Zipcode_Tbx.Text) ? "" : Idcard_Cust_Zipcode_Tbx.Text;
            ctmadd_idcard.Cust_Tel= string.IsNullOrEmpty(Idcard_Cust_Tel_Tbx.Text) ? "" : Idcard_Cust_Tel_Tbx.Text;
            ctmadd_idcard.Cust_Home_status_id = Idcard_Cust_Home_status_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Idcard_Cust_Home_status_DDL.SelectedValue); 
            ctmadd_idcard.Cust_Gps_Latitude = "";
            ctmadd_idcard.Cust_Gps_Longitude = "";

            // ที่อยู่ตามทะเบียนบ้าน
            Customers_Address ctmadd_home = new Customers_Address();

            ctmadd_home.Cust_id = custId;
            ctmadd_home.Cust_Address_type_id = 2;
            ctmadd_home.Cust_Address_no = string.IsNullOrEmpty(Home_Cust_Address_no_TBx.Text) ? "" : Home_Cust_Address_no_TBx.Text;
            ctmadd_home.Cust_Vilage = string.IsNullOrEmpty(Home_Cust_Vilage_TBx.Text) ? "" : Home_Cust_Vilage_TBx.Text;
            ctmadd_home.Cust_Vilage_no = string.IsNullOrEmpty(Home_Cust_Vilage_no_TBx.Text) ? "" : Home_Cust_Vilage_no_TBx.Text;
            ctmadd_home.Cust_Alley = string.IsNullOrEmpty(Home_Cust_Alley_TBx.Text) ? "" : Home_Cust_Alley_TBx.Text;
            ctmadd_home.Cust_Road = string.IsNullOrEmpty(Home_Cust_Road_TBx.Text) ? "" : Home_Cust_Road_TBx.Text;
            ctmadd_home.Cust_Subdistrict = string.IsNullOrEmpty(Home_Cust_Subdistrict_TBx.Text) ? "" : Home_Cust_Subdistrict_TBx.Text;
            ctmadd_home.Cust_District = string.IsNullOrEmpty(Home_Cust_District_TBx.Text) ? "" : Home_Cust_District_TBx.Text;
            ctmadd_home.Cust_Province = Home_Cust_Province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Home_Cust_Province_DDL.SelectedValue);
            ctmadd_home.Cust_Country = string.IsNullOrEmpty(Home_Cust_Country_TBx.Text) ? "" : Home_Cust_Country_TBx.Text;
            ctmadd_home.Cust_Zipcode = string.IsNullOrEmpty(Home_Cust_Zipcode_TBx.Text) ? "" : Home_Cust_Zipcode_TBx.Text;
            ctmadd_home.Cust_Tel = string.IsNullOrEmpty(Home_Cust_Tel_TBx.Text) ? "" : Home_Cust_Tel_TBx.Text;
            ctmadd_home.Cust_Home_status_id = Home_Cust_Home_status_id_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Home_Cust_Home_status_id_DDL.SelectedValue);
            ctmadd_home.Cust_Gps_Latitude = string.IsNullOrEmpty(Home_Cust_Gps_Latitude_TBx.Text) ? "" : Home_Cust_Gps_Latitude_TBx.Text;
            ctmadd_home.Cust_Gps_Longitude = string.IsNullOrEmpty(Home_Cust_Gps_Longitude_TBx.Text) ? "" : Home_Cust_Gps_Longitude_TBx.Text;

            // ที่อยู่ปัจจุบัน
            Customers_Address ctmadd_current = new Customers_Address();

            ctmadd_current.Cust_id = custId;
            ctmadd_current.Cust_Address_type_id = 3;
            ctmadd_current.Cust_Address_no = string.IsNullOrEmpty(Current_Cust_Address_no_TBx.Text) ? "" : Current_Cust_Address_no_TBx.Text;
            ctmadd_current.Cust_Vilage = string.IsNullOrEmpty(Current_Cust_Vilage_TBx.Text) ? "" : Current_Cust_Vilage_TBx.Text;
            ctmadd_current.Cust_Vilage_no = string.IsNullOrEmpty(Current_Cust_Vilage_no_TBx.Text) ? "" : Current_Cust_Vilage_no_TBx.Text;
            ctmadd_current.Cust_Alley = string.IsNullOrEmpty(Current_Cust_Alley_TBx.Text) ? "" : Current_Cust_Alley_TBx.Text;
            ctmadd_current.Cust_Road = string.IsNullOrEmpty(Current_Cust_Road_TBx.Text) ? "" : Current_Cust_Road_TBx.Text;
            ctmadd_current.Cust_Subdistrict = string.IsNullOrEmpty(Current_Cust_Subdistrict_TBx.Text) ? "" : Current_Cust_Subdistrict_TBx.Text;
            ctmadd_current.Cust_District = string.IsNullOrEmpty(Current_Cust_District_TBx.Text) ? "" : Current_Cust_District_TBx.Text;
            ctmadd_current.Cust_Province = Current_Cust_Province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Current_Cust_Province_DDL.SelectedValue);
            ctmadd_current.Cust_Country = string.IsNullOrEmpty(Current_Cust_Country_TBx.Text) ? "" : Current_Cust_Country_TBx.Text;
            ctmadd_current.Cust_Zipcode = string.IsNullOrEmpty(Current_Cust_Zipcode_TBx.Text) ? "" : Current_Cust_Zipcode_TBx.Text;
            ctmadd_current.Cust_Tel = string.IsNullOrEmpty(Current_Cust_Tel_TBx.Text) ? "" : Current_Cust_Tel_TBx.Text;
            ctmadd_current.Cust_Home_status_id = Current_Cust_Home_status_id_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Current_Cust_Home_status_id_DDL.SelectedValue);
            ctmadd_current.Cust_Gps_Latitude = "";
            ctmadd_current.Cust_Gps_Longitude = "";

            Customers_Address_Manager ctm_add_mng = new Customers_Address_Manager();

            ctm_add_mng.addCustomersAddress(ctmadd_idcard);
            ctm_add_mng.addCustomersAddress(ctmadd_home);
            ctm_add_mng.addCustomersAddress(ctmadd_current);

            Session["Address_Idcard"] = ctmadd_idcard;
            Session["Address_Home"] = ctmadd_home;
            Session["Address_Current"] = ctmadd_current;

        }

        private void _AddCustomerSpouse(string custId)
        {
            Customers_Spouse cmarry = new Customers_Spouse();

            cmarry.Cust_id = custId;
            cmarry.Spouse_idcard = string.IsNullOrEmpty(Spouse_idcard_TBx.Text) ? "" : Spouse_idcard_TBx.Text;
            cmarry.Spouse_Fname = string.IsNullOrEmpty(Spouse_Fname_TBx.Text) ? "" : Spouse_Fname_TBx.Text;
            cmarry.Spouse_Lname = string.IsNullOrEmpty(Spouse_Lname_TBx.Text) ? "" : Spouse_Lname_TBx.Text;
            cmarry.Spouse_Nationality = Spouse_Nationality_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Spouse_Nationality_DDL.SelectedValue);
            cmarry.Spouse_Origin = Spouse_Origin_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Spouse_Origin_DDL.SelectedValue);
            cmarry.Spouse_address_no = string.IsNullOrEmpty(Spouse_address_no_TBx.Text) ? "" : Spouse_address_no_TBx.Text;
            cmarry.Spouse_vilage = string.IsNullOrEmpty(Spouse_vilage_TBx.Text) ? "" : Spouse_vilage_TBx.Text;
            cmarry.Spouse_vilage_no = string.IsNullOrEmpty(Spouse_vilage_no_TBx.Text) ? "" : Spouse_vilage_no_TBx.Text;
            cmarry.Spouse_alley = string.IsNullOrEmpty(Spouse_alley_TBx.Text) ? "" : Spouse_alley_TBx.Text;
            cmarry.Spouse_road = string.IsNullOrEmpty(Spouse_road_TBx.Text) ? "" : Spouse_road_TBx.Text;
            cmarry.Spouse_subdistrict = string.IsNullOrEmpty(Spouse_subdistrict_TBx.Text) ? "" : Spouse_subdistrict_TBx.Text;
            cmarry.Spouse_district = string.IsNullOrEmpty(Spouse_district_TBx.Text) ? "" : Spouse_district_TBx.Text;
            cmarry.Spouse_province = Spouse_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Spouse_province_DDL.SelectedValue);
            cmarry.Spouse_country = string.IsNullOrEmpty(Spouse_country_TBx.Text) ? "" : Spouse_country_TBx.Text;
            cmarry.Spouse_zipcode = string.IsNullOrEmpty(Spouse_zipcode_TBx.Text) ? "" : Spouse_zipcode_TBx.Text;
            cmarry.Spouse_job = string.IsNullOrEmpty(Spouse_job_TBx.Text) ? "" : Spouse_job_TBx.Text;
            cmarry.Spouse_job_position = string.IsNullOrEmpty(Spouse_job_position_TBx.Text) ? "" : Spouse_job_position_TBx.Text;
            cmarry.Spouse_job_long = string.IsNullOrEmpty(Spouse_job_long_TBx.Text) ? 0 : Convert.ToInt32(Spouse_job_long_TBx.Text);
            cmarry.Spouse_job_salary = string.IsNullOrEmpty(Spouse_job_salary_TBx.Text) ? 0 : Convert.ToDouble(Spouse_job_salary_TBx.Text);
            cmarry.Spouse_job_local_name = string.IsNullOrEmpty(Spouse_job_local_name_TBx.Text) ? "" : Spouse_job_local_name_TBx.Text;
            cmarry.Spouse_job_address_no = string.IsNullOrEmpty(Spouse_job_address_no_TBx.Text) ? "" : Spouse_job_address_no_TBx.Text;
            cmarry.Spouse_job_vilage = string.IsNullOrEmpty(Spouse_job_vilage_TBx.Text) ? "" : Spouse_job_vilage_TBx.Text;
            cmarry.Spouse_job_vilage_no = string.IsNullOrEmpty(Spouse_job_vilage_no_TBx.Text) ? "" : Spouse_job_vilage_no_TBx.Text;
            cmarry.Spouse_job_alley = string.IsNullOrEmpty(Spouse_job_alley_TBx.Text) ? "" : Spouse_job_alley_TBx.Text;
            cmarry.Spouse_job_road = string.IsNullOrEmpty(Spouse_job_road_TBx.Text) ? "" : Spouse_job_road_TBx.Text;
            cmarry.Spouse_job_subdistrict = string.IsNullOrEmpty(Spouse_job_subdistrict_TBx.Text) ? "" : Spouse_job_subdistrict_TBx.Text;
            cmarry.Spouse_job_district = string.IsNullOrEmpty(Spouse_job_district_TBx.Text) ? "" : Spouse_job_district_TBx.Text;
            cmarry.Spouse_job_province = Spouse_job_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Spouse_job_province_DDL.SelectedValue);
            cmarry.Spouse_job_country = string.IsNullOrEmpty(Spouse_job_country_TBx.Text) ? "" : Spouse_job_country_TBx.Text;
            cmarry.Spouse_job_zipcode = string.IsNullOrEmpty(Spouse_job_zipcode_TBx.Text) ? "" : Spouse_job_zipcode_TBx.Text;
            cmarry.Spouse_job_tel = string.IsNullOrEmpty(Spouse_job_tel_TBx.Text) ? "" : Spouse_job_tel_TBx.Text;
            cmarry.Spouse_tel = string.IsNullOrEmpty(Spouse_tel_TBx.Text) ? "" : Spouse_tel_TBx.Text;
            cmarry.Spouse_email = string.IsNullOrEmpty(Spouse_email_TBx.Text) ? "" : Spouse_email_TBx.Text;

            Customers_Spouse_Manager ctm_sp_mng = new Customers_Spouse_Manager();

            ctm_sp_mng.addCustomersSpouse(cmarry);

            Session["Cust_Marry"] = cmarry;
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Copy Data Function                   ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // copy ข้อมูลที่อยู่แยกตามประเภท
        private void _CopyBaseDataAddress(int type)
        {
            if (type == 1) // copy ที่อยู่ตามบัตรประชาชน to ที่ตามทะเบียนบ้าน
            {
                Home_Cust_Address_no_TBx.Text = Idcard_Cust_Address_no_Tbx.Text;
                Home_Cust_Vilage_TBx.Text = Idcard_Cust_Vilage_Tbx.Text;
                Home_Cust_Vilage_no_TBx.Text = Idcard_Cust_Vilage_no_Tbx.Text;
                Home_Cust_Alley_TBx.Text = Idcard_Cust_Alley_Tbx.Text;
                Home_Cust_Road_TBx.Text = Idcard_Cust_Road_Tbx.Text;
                Home_Cust_Subdistrict_TBx.Text = Idcard_Cust_Subdistrict_Tbx.Text;
                Home_Cust_District_TBx.Text = Idcard_Cust_District_Tbx.Text;
                Home_Cust_Province_DDL.SelectedIndex = Idcard_Cust_Province_DDL.SelectedIndex;
                Home_Cust_Country_TBx.Text = Idcard_Cust_Country_Tbx.Text;
                Home_Cust_Zipcode_TBx.Text = Idcard_Cust_Zipcode_Tbx.Text;
                Home_Cust_Tel_TBx.Text = Idcard_Cust_Tel_Tbx.Text;
                Home_Cust_Home_status_id_DDL.SelectedIndex = Idcard_Cust_Home_status_DDL.SelectedIndex;

                Home_Cust_Gps_Latitude_TBx.Focus();
            }
            else if (type == 2) // copy ที่อยู่ตามบัตรประชาชน to ที่อยู่ปัจจุบัน
            {
                Current_Cust_Address_no_TBx.Text = Idcard_Cust_Address_no_Tbx.Text;
                Current_Cust_Vilage_TBx.Text = Idcard_Cust_Vilage_Tbx.Text;
                Current_Cust_Vilage_no_TBx.Text = Idcard_Cust_Vilage_no_Tbx.Text;
                Current_Cust_Alley_TBx.Text = Idcard_Cust_Alley_Tbx.Text;
                Current_Cust_Road_TBx.Text = Idcard_Cust_Road_Tbx.Text;
                Current_Cust_Subdistrict_TBx.Text = Idcard_Cust_Subdistrict_Tbx.Text;
                Current_Cust_District_TBx.Text = Idcard_Cust_District_Tbx.Text;
                Current_Cust_Province_DDL.SelectedIndex = Idcard_Cust_Province_DDL.SelectedIndex;
                Current_Cust_Country_TBx.Text = Idcard_Cust_Country_Tbx.Text;
                Current_Cust_Zipcode_TBx.Text = Idcard_Cust_Zipcode_Tbx.Text;
                Current_Cust_Tel_TBx.Text = Idcard_Cust_Tel_Tbx.Text;
                Current_Cust_Home_status_id_DDL.SelectedIndex = Idcard_Cust_Home_status_DDL.SelectedIndex;

                Cust_job_TBx.Focus();
            }
            else if (type == 3) // copy ที่อยู่ตามทะเบียนบ้าน to ที่อยู่ปัจจุบัน
            {
                Current_Cust_Address_no_TBx.Text = Home_Cust_Address_no_TBx.Text;
                Current_Cust_Vilage_TBx.Text = Home_Cust_Vilage_TBx.Text;
                Current_Cust_Vilage_no_TBx.Text = Home_Cust_Vilage_no_TBx.Text;
                Current_Cust_Alley_TBx.Text = Home_Cust_Alley_TBx.Text;
                Current_Cust_Road_TBx.Text = Home_Cust_Road_TBx.Text;
                Current_Cust_Subdistrict_TBx.Text = Home_Cust_Subdistrict_TBx.Text;
                Current_Cust_District_TBx.Text = Home_Cust_District_TBx.Text;
                Current_Cust_Province_DDL.SelectedIndex = Home_Cust_Province_DDL.SelectedIndex;
                Current_Cust_Country_TBx.Text = Home_Cust_Country_TBx.Text;
                Current_Cust_Zipcode_TBx.Text = Home_Cust_Zipcode_TBx.Text;
                Current_Cust_Tel_TBx.Text = Home_Cust_Tel_TBx.Text;
                Current_Cust_Home_status_id_DDL.SelectedIndex = Home_Cust_Home_status_id_DDL.SelectedIndex;

                Cust_job_TBx.Focus();
            }
        }
    }
}