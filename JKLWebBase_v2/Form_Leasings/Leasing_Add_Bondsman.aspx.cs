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
    public partial class Leasing_Add_Bondsman_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadHomeStatus();
                _loadNationality();
                _loadOrigin();
                _loadPersonStatus();
                _loadThaiProvinces();

                Number_Of_Bondsman.Text = Session["Number_Of_Bondsman"].ToString();
                Page.Title = "ผู้ค้ำประกันคนที่ " + Session["Number_Of_Bondsman"].ToString();
            }
        }


        protected void link_Dealers_Add_Click(object sender, EventArgs e)
        {
            
        }

        protected void link_Leasing_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Edit");
        }

        protected void link_Customer_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Customer_Add");
        }

        protected void link_Add_Bondsman_1_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "1";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_2_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "2";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_3_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "3";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_4_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "4";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_5_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "5";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Car_Img_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Car_Img");
        }

        protected void link_Add_Home_Img_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Home_Img");
        }

        protected void Cust_idcard_TBx_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Cust_Search_Btn_Click(object sender, EventArgs e)
        {

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

        protected void Customer_Add_Save_Btn_Click(object sender, EventArgs e)
        {

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
        ****************************************************                        Calculate   Function                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _AddCustomer()
        {
            Customers ctm = new Customers();

            ctm.Cust_id = new Customers_Manager().generateCustomerID();
            ctm.Cust_idcard = string.IsNullOrEmpty(Cust_idcard_TBx.Text) ? "-" : Cust_idcard_TBx.Text;
            ctm.Cust_Fname = string.IsNullOrEmpty(Cust_Fname_TBx.Text) ? "-" : Cust_Fname_TBx.Text;
            ctm.Cust_LName = string.IsNullOrEmpty(Cust_LName_TBx.Text) ? "-" : Cust_LName_TBx.Text;
            ctm.Cust_B_date = string.IsNullOrEmpty(Cust_B_date_TBx.Text) ? "-" : Cust_B_date_TBx.Text;
            ctm.Cust_age = string.IsNullOrEmpty(Cust_B_date_TBx.Text) ? 0 : DateTime.Now.Year - Convert.ToInt32(Cust_B_date_TBx.Text.Split('-')[0].ToString());
            ctm.Cust_Idcard_without = string.IsNullOrEmpty(Cust_Idcard_without_TBx.Text) ? "-" : Cust_Idcard_without_TBx.Text;
            ctm.Cust_Idcard_start = string.IsNullOrEmpty(Cust_Idcard_start_TBx.Text) ? "-" : Cust_Idcard_start_TBx.Text;
            ctm.Cust_Idcard_expire = string.IsNullOrEmpty(Cust_Idcard_expire_TBx.Text) ? "-" : Cust_Idcard_expire_TBx.Text;
            ctm.Cust_Nationality = Convert.ToInt32(Cust_Nationality_DDL.SelectedValue);
            ctm.Cust_Origin = Convert.ToInt32(Cust_Origin_DDL.SelectedValue);
            ctm.Cust_job = string.IsNullOrEmpty(Cust_job_TBx.Text) ? "-" : Cust_job_TBx.Text;
            ctm.Cust_job_position = string.IsNullOrEmpty(Cust_job_position_TBx.Text) ? "-" : Cust_job_position_TBx.Text;
            ctm.Cust_job_long = string.IsNullOrEmpty(Cust_job_long_TBx.Text) ? 0 : Convert.ToInt32(Cust_job_long_TBx.Text);
            ctm.Cust_job_local_name = string.IsNullOrEmpty(Cust_job_local_name_TBx.Text) ? "-" : Cust_job_local_name_TBx.Text;
            ctm.Cust_job_address_no = string.IsNullOrEmpty(Cust_job_address_no_TBx.Text) ? "-" : Cust_job_address_no_TBx.Text;
            ctm.Cust_job_vilage = string.IsNullOrEmpty(Cust_job_vilage_TBx.Text) ? "-" : Cust_job_vilage_TBx.Text;
            ctm.Cust_job_vilage_no = string.IsNullOrEmpty(Cust_job_vilage_no_TBx.Text) ? "-" : Cust_job_vilage_no_TBx.Text;
            ctm.Cust_job_alley = string.IsNullOrEmpty(Cust_job_alley_TBx.Text) ? "-" : Cust_job_alley_TBx.Text;
            ctm.Cust_job_road = string.IsNullOrEmpty(Cust_job_road_TBx.Text) ? "-" : Cust_job_road_TBx.Text;
            ctm.Cust_job_subdistrict = string.IsNullOrEmpty(Cust_job_subdistrict_TBx.Text) ? "-" : Cust_job_subdistrict_TBx.Text;
            ctm.Cust_job_district = string.IsNullOrEmpty(Cust_job_district_TBx.Text) ? "-" : Cust_job_district_TBx.Text;
            ctm.Cust_job_province = Convert.ToInt32(Cust_job_province_DDL.SelectedValue);
            ctm.Cust_job_country = string.IsNullOrEmpty(Cust_job_contry_TBx.Text) ? "-" : Cust_job_contry_TBx.Text;
            ctm.Cust_job_zipcode = string.IsNullOrEmpty(Cust_job_zipcode_TBx.Text) ? "-" : Cust_job_zipcode_TBx.Text;
            ctm.Cust_job_tel = string.IsNullOrEmpty(Cust_job_tel_TBx.Text) ? "-" : Cust_job_tel_TBx.Text;
            ctm.Cust_job_email = string.IsNullOrEmpty(Cust_job_email_TBx.Text) ? "-" : Cust_job_email_TBx.Text;
            ctm.Cust_job_salary = string.IsNullOrEmpty(Cust_job_salary_TBx.Text) ? 0 : Convert.ToDouble(Cust_job_salary_TBx.Text);
            ctm.Cust_status_id = Convert.ToInt32(Cust_status_DDL.SelectedValue);

            _AddCustomerAddress(ctm.Cust_id);

            if (ctm.Cust_status_id == 2 || ctm.Cust_status_id == 3)
            {
                _AddCustomerSpouse(ctm.Cust_id);
            }

        }

        private void _AddCustomerAddress(string custId)
        {
            Customers_Address ctmadd = new Customers_Address();

        }

        private void _AddCustomerSpouse(string custId)
        {
            Customers_Spouse cmarry = new Customers_Spouse();

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

                Current_Cust_Address_no_TBx.Focus();
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

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckCustomer()
        {
            Customers cust = new Customers_Manager().getCustomersByIdCard(Cust_idcard_TBx.Text);
            if (!cust.Equals(null) && cust != null)
            {

            }
            else
            {
                string message = "ไม่พบหมายเลขบัตรประชาชน " + Cust_idcard_TBx.Text + " ขอลูกค้าในระบบ";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());

                Cust_idcard_TBx.Focus();
            }

        }

        protected void Open_Search_Modal_Box_Click(object sender, EventArgs e)
        {

        }
    }
}