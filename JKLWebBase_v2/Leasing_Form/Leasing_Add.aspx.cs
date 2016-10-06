using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Managers_Leasings;

namespace JKLWebBase_v2.Leasing_Form
{
    public partial class Leasing_Add : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCarType();
                _loadCarBrand();
                _loadCarYear();
                _loadCarUsed();
                _loadBrands();
                _loadCourt();
                _loadHomeStatus();
                _loadLeasingCode();
                _loadNationality();
                _loadOrigin();
                _loadPaymentSchedule();
                _loadPersonStatus();
                _loadTentsCar();
                _loadZoneService();
                _loadTotalPaymentTime();
                _loadThaiProvinces();

                Spouse_Panel.Visible = false;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void Car_Brand_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Car_Brand_DDL.SelectedIndex != 0)
            {
                _loadCarModels(int.Parse(Car_Brand_DDL.SelectedValue));
            }

            Car_Model_DDL.Focus();
        }


        protected void Cust_status_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cust_status_DDL.SelectedIndex == 2)
            {
                Spouse_Panel.Visible = true;
            }
            else
            {
                Spouse_Panel.Visible = false;
            }

            Tent_car_DDL.Focus();
        }

        protected void Calculate_Btn_Click(object sender, EventArgs e)
        {
            _Calculated();
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

        // Code Example
        protected void Deps_No_Tbx_TextChanged(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(Deps_No_Tbx.Text))
            {
                string message = "Hello! Mudassar.";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());
            }
            else
            {

            }*/
        }

        protected void Dealer_idcard_TBx_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Cust_idcard_TBx_TextChanged(object sender, EventArgs e)
        {

        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลประเภทรภ
        private void _loadCarType()
        {
            List  <Base_Car_Types> list_data = new Base_Car_Types_Manager().getCarTypes();
            Car_Type_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Car_Types data = list_data[i];
                Car_Type_DDL.Items.Add(new ListItem(data.car_type_name, data.car_type_id.ToString()));
            }
        }

        // ดึงข้อมูลยี่ห้อรถ
        private void _loadCarBrand()
        {
            List<Base_Car_Brands> list_data = new Base_Car_Brand_Manager().getCarBrands();
            Car_Brand_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Car_Brands data = list_data[i];
                Car_Brand_DDL.Items.Add(new ListItem(data.car_brand_name_eng + " ( " + data.car_brand_name_th + " ) ", data.car_brand_id.ToString()));
            }
        }

        // ดึงข้อมูลรุ่นรถ
        private void _loadCarModels(int index)
        {
            List<Base_Car_Models> list_data = new Base_Car_Models_Manager().getCarModels(index);
            if (list_data.Count > 0)
            {
                Car_Model_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
                for (int i = 0; i < list_data.Count; i++)
                {
                    Base_Car_Models data = list_data[i];
                    Car_Model_DDL.Items.Add(new ListItem(data.car_model_name, data.car_model_id.ToString()));
                }
            }
            else
            {
                Car_Model_DDL.Items.Clear();
            }
        }

        // ปีรถ
        private void _loadCarYear()
        {
            Car_Year_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            int year_list = DateTime.Now.Year;
            while (year_list >= 1957)
            {
                int year_th = year_list + 543;
                Car_Year_DDL.Items.Add(new ListItem(year_th.ToString(), year_list.ToString()));
                year_list--;
            }
        }

        // สภาพรถ
        private void _loadCarUsed()
        {
            Car_Used_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            Car_Used_DDL.Items.Add(new ListItem("รถใหม่", "1"));
            Car_Used_DDL.Items.Add(new ListItem("ใช้แล้ว", "2"));
        }

        // รหัสสัญญา
        private void _loadLeasingCode()
        {
            List<Base_Leasing_Code> list_data = new Base_Leasing_Code_Manager().getLeasingCode();
            Leasing_Code_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Leasing_Code data = list_data[i];
                if (String.IsNullOrEmpty(data.Leasing_code_S_Name))
                {
                    Leasing_Code_DDL.Items.Add(new ListItem(data.Leasing_code_name, data.Leasing_code_id.ToString()));
                }
                else
                {
                    Leasing_Code_DDL.Items.Add(new ListItem(data.Leasing_code_name + " ( " + data.Leasing_code_S_Name + " ) ", data.Leasing_code_id.ToString()));
                }
                
            }
        }

        // สาขา
        private void _loadBrands()
        {
            List<Base_Branchs> list_data = new Base_Branchs_Manager().getBranchs();
            Branch_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Branchs data = list_data[i];
                Branch_DDL.Items.Add(new ListItem(data.Branch_code + " ( " + data.Branch_N_name + " ) ", data.Branch_id.ToString()));
            }
        }

        // เขตบริการ
        private void _loadZoneService()
        {
            List<Base_Zone_Service> list_data = new Base_Zone_Service_Manager().getZoneService();
            Zone_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Zone_Service data = list_data[i];
                Zone_DDL.Items.Add(new ListItem(data.Zone_code + " " + data.Zone_name, data.Zone_id.ToString()));
            }
        }

        // ระยะเวลาชำระเงิน
        private void _loadTotalPaymentTime()
        {
            List<Base_Total_Payment> list_data = new Base_Total_Payment_Manager().getTotalPayment();
            TotalPaymentTime_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Total_Payment data = list_data[i];
                TotalPaymentTime_DDL.Items.Add(new ListItem(data.Total_payment_name, data.Total_payment_id.ToString()));
            }
        }

        // ศาล
        private void _loadCourt()
        {
            List<Base_Courts> list_data = new Base_Courts_Manager().getCourts();
            Court_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Courts data = list_data[i];
                Court_DDL.Items.Add(new ListItem(data.Court_name, data.Court_id.ToString()));
            }
        }

        // กำหนดชำระทุกวันที่
        private void _loadPaymentSchedule()
        {
            Payment_Schedule_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            int day_start = 5;
            while (day_start <= 25)
            {
                Payment_Schedule_DDL.Items.Add(new ListItem(day_start.ToString(), day_start.ToString()));
                day_start++;
            }
        }

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

        // ชื่อเต้นท์รถ
        private void _loadTentsCar()
        {
            List<Base_Tents_Car> list_data = new Base_Tents_Car_Manager().getTents();
            Tent_car_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Tents_Car data = list_data[i];
                Tent_car_DDL.Items.Add(new ListItem(data.Tent_name, data.Tent_car_id.ToString()));
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
            Car_Old_Owner_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Current_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Cust_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Dealer_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Home_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Idcard_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Spouse_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Spouse_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Car_Old_Owner_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Current_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Cust_job_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Dealer_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Home_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Idcard_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Spouse_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Spouse_job_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Calculate   Function                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // คำนวนข้อมูลประเมินการเช่า-ซื้อ
        private void _Calculated()
        {
            if (!string.IsNullOrEmpty(Total_Require_TBx.Text) && !string.IsNullOrEmpty(Interest_Rate_TBx.Text) && !string.IsNullOrEmpty(Total_Period_TBx.Text) && !string.IsNullOrEmpty(Vat_TBx.Text))
            {
                
                double require = Convert.ToDouble(Total_Require_TBx.Text); // ยอดจัด
                double interest_rate = Convert.ToDouble(Interest_Rate_TBx.Text); // อัตราดอกเบี้ย
                double period = Convert.ToDouble(Total_Period_TBx.Text); // ระยะเวลา
                double vat_rate = Convert.ToDouble(Vat_TBx.Text); // อัตราภาษีมูลค่าเพิ่ม

               
                double interate = require * ((interest_rate / 100) * (period / 12));  /* ยอดดอกเบี้ย = ยอดจัด * (อัตราดอกเบี้ย  * ระยะเวลา) */
                double vat = (require + interate) * (vat_rate / 100); /* ภาษี = (ยอดจัด + ดอกเบี้ย ) * อัตราภาษีมูลค่าเพิ่ม */
                double finance = require + interate; /* ยอดรวม = ยอดจัด + ดอกเบี้ย */
                double totalFinance = require + interate + vat; /* รวมยอดไฟแนนซ์สุทธิ   = ยอดจัด+  ยอดดอกเบี้ย + vat */
                double interateTime = interate / period; /* ดอกเบี้ยต่องวด  = ยอดดอกเบี้ย /จำนวนงวด */
                double payPerTimeTotal = totalFinance / period; /* รวมค่างวดและภาษีมูลค่าเพิ่ม = ยอดไฟแนนซ์สุทธิ  / จำนวนงวด */
                double payPerTime = payPerTimeTotal * (100 / (100 + vat_rate)); /* ค่างวดไม่รวมภาษี = รวมค่างวดและภาษีมูลค่าเพิ่ม - ภาษี     (รวมค่างวด * 100 / 107) */
                double taxpermonth = payPerTimeTotal - payPerTime; /* ค่าภาษีต่องวด = รวมค่างวดและภาษีมูลค่าเพิ่ม  -ค่างวด */
                double periodPayment = Math.Ceiling(payPerTimeTotal); /* ค่างวดจ่ายจริง */

                Total_Sum_Tbx.Text = finance.ToString("#,##0.00");  // ยอดรวม
                Total_Interest_TBx.Text = interate.ToString("#,##0.00"); // ดอกเบี้ย
                Total_Tax_TBx.Text = vat.ToString("#,##0.00"); // ภาษี 
                Total_Leasing_TBx.Text = totalFinance.ToString("#,##0.00"); // ยอดเช่า-ซื้อ

                Period_Cal_Tbx.Text = payPerTime.ToString("#,##0.00"); // ค่างวด
                Tax_per_m_TBx.Text = taxpermonth.ToString("#,##0.00"); // ภาษีต่องวด
                Period_pure_Tbx.Text = payPerTimeTotal.ToString("#,##0.00"); // ค่างวดสุทธิ
                Period_Payment_TBx.Text = periodPayment.ToString("#,##0.00"); // ค่างวดจ่ายจริง

                /* Text Style Font Bold and Font Color Red */
                Total_Sum_Tbx.Font.Bold = true;
                Total_Interest_TBx.Font.Bold = true;
                Total_Tax_TBx.Font.Bold = true;
                Total_Leasing_TBx.Font.Bold = true;
                Period_Cal_Tbx.Font.Bold = true;
                Tax_per_m_TBx.Font.Bold = true;
                Period_pure_Tbx.Font.Bold = true;
                Period_Payment_TBx.Font.Bold = true;

                Total_Sum_Tbx.ForeColor = Color.Red;
                Total_Interest_TBx.ForeColor = Color.Red;
                Total_Tax_TBx.ForeColor = Color.Red;
                Total_Leasing_TBx.ForeColor = Color.Red;
                Period_Cal_Tbx.ForeColor = Color.Red;
                Tax_per_m_TBx.ForeColor = Color.Red;
                Period_pure_Tbx.ForeColor = Color.Red;
                Period_Payment_TBx.ForeColor = Color.Red;
                /* Text Style Font Bold and Font Color Red */

                Period_Payment_TBx.Focus();
            }
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


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckCustomer()
        {
            Customers cust = new Customers_Manager().getCustomersByIdCard(Cust_idcard_TBx.Text);
            if (!cust.Equals(null) && cust != null)
            {

            } else
            {
                string message = "ไม่พบหมายเลขบัตรประชาชน "+ Cust_idcard_TBx.Text + " ขอลูกค้าในระบบ";
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

        private void _CheckDealer()
        {
            Car_Dealers cdler = new Car_Dealers_Manager().getDealerByIdCard(Dealer_idcard_TBx.Text);
            if (!cdler.Equals(null) && cdler != null)
            {

            }
            else
            {
                string message = "ไม่พบหมายเลขบัตรประชาชน " + Dealer_idcard_TBx.Text + " ของนายหน้าในระบบ";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", sb.ToString());

                Dealer_idcard_TBx.Focus();
            }
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _AddCustomer()
        {
            Customers ctm = new Customers();

            ctm.Cust_id = new Customers_Manager().generateCustomerID();
            ctm.Cust_idcard = string.IsNullOrEmpty(Cust_idcard_TBx.Text)? "-" : Cust_idcard_TBx.Text;
            ctm.Cust_Fname = string.IsNullOrEmpty(Cust_Fname_TBx.Text) ? "-" : Cust_Fname_TBx.Text;
            ctm.Cust_LName = string.IsNullOrEmpty(Cust_LName_TBx.Text) ? "-" : Cust_LName_TBx.Text;
            ctm.Cust_B_date = string.IsNullOrEmpty(Cust_B_date_TBx.Text) ? "-" : Cust_B_date_TBx.Text;
            ctm.Cust_age = string.IsNullOrEmpty(Cust_B_date_TBx.Text)? 0 : DateTime.Now.Year - Convert.ToInt32(Cust_B_date_TBx.Text.Split('-')[0].ToString());
            ctm.Cust_Idcard_without = string.IsNullOrEmpty(Dealer_fname_TBx.Text) ? "-" : Dealer_fname_TBx.Text;
            ctm.Cust_Idcard_start = string.IsNullOrEmpty(Cust_Idcard_start_TBx.Text) ? "-" : Cust_Idcard_start_TBx.Text;
            ctm.Cust_Idcard_expire = string.IsNullOrEmpty(Cust_Idcard_expire_TBx.Text) ? "-" : Cust_Idcard_expire_TBx.Text;
            ctm.Cust_Nationality = Convert.ToInt32(Cust_Nationality_DDL.SelectedValue);
            ctm.Cust_Origin = Convert.ToInt32(Cust_Origin_DDL.SelectedValue);
            ctm.Cust_job = string.IsNullOrEmpty(Cust_job_TBx.Text) ? "-" : Cust_job_TBx.Text;
            ctm.Cust_job_position = string.IsNullOrEmpty(Cust_job_position_TBx.Text) ? "-" : Cust_job_position_TBx.Text;
            ctm.Cust_job_long =  string.IsNullOrEmpty(Cust_job_long_TBx.Text) ? 0 : Convert.ToInt32(Cust_job_long_TBx.Text);
            ctm.Cust_job_local_name = string.IsNullOrEmpty(Cust_job_local_name_TBx.Text) ? "-" : Cust_job_local_name_TBx.Text; 
            ctm.Cust_job_address_no = string.IsNullOrEmpty(Cust_job_address_no_TBx.Text) ? "-" : Cust_job_address_no_TBx.Text;
            ctm.Cust_job_vilage = string.IsNullOrEmpty(Cust_job_vilage_TBx.Text) ? "-" : Cust_job_vilage_TBx.Text;
            ctm.Cust_job_vilage_no = string.IsNullOrEmpty(Cust_job_vilage_no_TBx.Text) ? "-" : Cust_job_vilage_no_TBx.Text;
            ctm.Cust_job_alley = string.IsNullOrEmpty(Cust_job_alley_TBx.Text) ? "-" : Cust_job_alley_TBx.Text;
            ctm.Cust_job_road = string.IsNullOrEmpty(Cust_job_road_TBx.Text) ? "-" : Cust_job_road_TBx.Text;
            ctm.Cust_job_subdistrict = string.IsNullOrEmpty(Cust_job_subdistrict_TBx.Text) ? "-" : Cust_job_subdistrict_TBx.Text;
            ctm.Cust_job_district = string.IsNullOrEmpty(Cust_job_district_TBx.Text) ? "-" : Cust_job_district_TBx.Text;
            ctm.Cust_job_province = Convert.ToInt32(Cust_job_province_DDL.SelectedValue); 
            ctm.Cust_job_contry = string.IsNullOrEmpty(Cust_job_contry_TBx.Text) ? "-" : Cust_job_contry_TBx.Text;
            ctm.Cust_job_zipcode = string.IsNullOrEmpty(Cust_job_zipcode_TBx.Text) ? "-" : Cust_job_zipcode_TBx.Text;
            ctm.Cust_job_tel = string.IsNullOrEmpty(Cust_job_tel_TBx.Text) ? "-" : Cust_job_tel_TBx.Text;
            ctm.Cust_job_email = string.IsNullOrEmpty(Cust_job_email_TBx.Text) ? "-" : Cust_job_email_TBx.Text;
            ctm.Cust_job_salary = string.IsNullOrEmpty(Cust_job_salary_TBx.Text) ? 0 : Convert.ToDouble(Cust_job_salary_TBx.Text);
            ctm.Cust_status_id = Convert.ToInt32(Cust_status_DDL.SelectedValue);

            _AddCustomerAddress(ctm.Cust_id);

            if (ctm.Cust_status_id == 2) { _AddCustomerSpouse(ctm.Cust_id); }

        }

        private void _AddCustomerAddress(string custId)
        {
            Customers_Address ctmadd = new Customers_Address();

        }

        private void _AddCustomerSpouse(string custId)
        {
            Customers_Spouse cmarry = new Customers_Spouse();

        }

        private void _AddDealer()
        {

            Car_Dealers cdlr = new Car_Dealers();

            cdlr.Dealer_id = new Car_Dealers_Manager().generateDealerID();
            cdlr.Dealer_receive = Convert.ToDouble(Dealer_receive_TBx.Text);
            cdlr.Dealer_fname = Dealer_fname_TBx.Text;
            cdlr.Dealer_lname = Dealer_lname_TBx.Text;
            cdlr.Dealer_idcard = Dealer_idcard_TBx.Text;
            cdlr.Dealer_address_no = Dealer_address_no_TBx.Text;
            cdlr.Dealer_vilage = Dealer_vilage_TBx.Text;
            cdlr.Dealer_vilage_no = Dealer_vilage_no_TBx.Text;
            cdlr.Dealer_alley = Dealer_alley_TBx.Text;
            cdlr.Dealer_road = Dealer_road_TBx.Text;
            cdlr.Dealer_subdistrict = Dealer_subdistrict_TBx.Text;
            cdlr.Dealer_district = Dealer_district_TBx.Text;
            cdlr.Dealer_province = Convert.ToInt32(Dealer_province_DDL.SelectedValue);
            cdlr.Dealer_country = Dealer_country_TBx.Text;
            cdlr.Dealer_zipcode = Dealer_zipcode_TBx.Text;

        }

        private void _AddLeasings()
        {
            Car_Leasings cl = new Car_Leasings();

            cl.Leasing_id = "";
            cl.Deps_no = string.IsNullOrEmpty(Deps_No_Tbx.Text)? "" : Deps_No_Tbx.Text;
            cl.Leasing_no = Leasing_No_Tbx.Text;
            cl.Leasing_code_id = Convert.ToInt32(Leasing_Code_DDL.SelectedValue);
            cl.Leasing_date = Leasing_Date_TBx.Text;
            cl.Branch_id = Convert.ToInt32(Branch_DDL.SelectedValue);
            cl.Zone_id = Convert.ToInt32(Zone_DDL.SelectedValue);
            cl.Court_id = Convert.ToInt32(Court_DDL.SelectedValue);
            cl.PeReT = Person_Receive_Trasfer_TBx.Text;
            cl.TotalPaymentTime = Convert.ToInt32(TotalPaymentTime_DDL.SelectedValue);
            cl.Total_require = Convert.ToDouble(Total_Require_TBx.Text);
            cl.Interest_rate = Convert.ToDouble(Interest_Rate_TBx.Text);
            cl.Total_period = Convert.ToInt32(Total_Period_TBx.Text);
            cl.Total_sum = Convert.ToDouble(Total_Sum_Tbx.Text);
            cl.Total_Interest = Convert.ToDouble(Total_Interest_TBx.Text);
            cl.Total_Tax = Convert.ToDouble(Total_Tax_TBx.Text);
            cl.Total_leasing = Convert.ToDouble(Total_Leasing_TBx.Text);
            cl.Period_cal = Convert.ToDouble(Period_Cal_Tbx.Text);
            cl.Tax_per_m = Convert.ToDouble(Tax_per_m_TBx.Text);
            cl.Period_pure = Convert.ToDouble(Period_pure_Tbx.Text);
            cl.Period_payment = Convert.ToDouble(Period_Payment_TBx.Text);
            cl.Payment_schedule = Convert.ToInt32(Payment_Schedule_DDL.Text);
            cl.First_payment_date = First_Payment_Date_Tbx.Text;
            cl.Car_type = Convert.ToInt32(Car_Type_DDL.SelectedValue);
            cl.Car_brand = Convert.ToInt32(Car_Brand_DDL.SelectedValue);
            cl.Car_model = Convert.ToInt32(Car_Model_DDL.SelectedValue);
            cl.Car_color = Car_Color_TBx.Text;
            cl.Car_license_plate = Car_Plate_TBx.Text;
            cl.Car_engine_no = Engine_No_TBx.Text;
            cl.Car_chassis_no = Chassis_No_TBx.Text;
            cl.Car_year = Car_Year_DDL.SelectedValue;
            cl.Car_used_id = Convert.ToInt32(Car_Used_DDL.SelectedValue);
            cl.Car_distance = Convert.ToInt32(Car_Distance_TBx.Text);
            cl.Car_register_date = Car_Register_Date_TBx.Text;
            cl.Car_next_register_date = Car_Next_Register_Date_TBx.Text;
            cl.Car_tax_value = Convert.ToDouble(Car_Tax_Value_Lbl.Text);
            cl.Car_credits = Car_Credits_Tbx.Text;
            cl.Car_dealer = Car_Dealer_Tbx.Text;
            cl.Car_old_owner = Car_Old_Owner_Tbx.Text;
            cl.Car_old_owner_idcard = Car_Old_Owner_Idcard_Tbx.Text;
            cl.Car_old_owner_idcard_str = Car_Old_Owner_Idcard_Str_Tbx.Text;
            cl.Car_old_owner_idcard_exp = Car_Old_Owner_Idcard_Exp_Tbx.Text;
            cl.Car_old_owner_address_no = Car_Old_Owner_Address_No_Tbx.Text;
            cl.Car_old_owner_vilage = Car_Old_Owner_Vilage_Tbx.Text;
            cl.Car_old_owner_vilage_no = Car_Old_Owner_Vilage_No_Tbx.Text;
            cl.Car_old_owner_alley = Car_Old_Owner_alley_Tbx.Text;
            cl.Car_old_owner_road = Car_Old_Owner_Road_Tbx.Text;
            cl.Car_old_owner_subdistrict = Car_Old_Owner_Subdistrict_Tbx.Text;
            cl.Car_old_owner_district = Car_Old_Owner_District_Tbx.Text;
            cl.Car_old_owner_province = Convert.ToInt32(Car_Old_Owner_Province_DDL.SelectedValue);
            cl.Car_old_owner_contry = Car_Old_Owner_Contry_Tbx.Text;
            cl.Car_old_owner_zipcode = Car_Old_Owner_Zipcode_Tbx.Text;
            cl.Cust_idcard = Cust_idcard_TBx.Text;
            cl.Dealer_id = Convert.ToInt32(Dealer_idcard_TBx.Text);
            cl.Tent_car_id = Convert.ToInt32(Tent_car_DDL.SelectedValue);
            cl.Check_receive_person = Check_receive_person_TBx.Text;
            cl.Check_number = Check_number_TBx.Text;
            cl.Check_payment = Convert.ToDouble(Check_payment_TBx.Text);
            cl.Check_receive_date = Check_receive_date_TBx.Text;
            cl.Contract_status = "1";



        }

    }
}
 
 