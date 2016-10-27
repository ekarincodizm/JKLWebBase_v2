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

namespace JKLWebBase_v2.Form_Leasings
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
                _loadLeasingCode();
                _loadPaymentSchedule();
                _loadTentsCar();
                _loadZoneService();
                _loadTotalPaymentTime();
                _loadThaiProvinces();
            }
        }


        protected void link_Customer_Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("/Form_Leasings/Customer_Edit");
        }

        protected void Car_Brand_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Car_Brand_DDL.SelectedIndex != 0)
            {
                _loadCarModels(int.Parse(Car_Brand_DDL.SelectedValue));
            }

            Car_Model_DDL.Focus();
        }

        protected void Calculate_Btn_Click(object sender, EventArgs e)
        {
            _Calculated();

            Period_Payment_TBx.Focus();
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

        protected void Leasing_Add_Save_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Car_Dealer_Add");
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

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            Car_Old_Owner_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Car_Old_Owner_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
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

                Total_Sum_TBx.Text = finance.ToString("#,##0.00");  // ยอดรวม
                Total_Interest_TBx.Text = interate.ToString("#,##0.00"); // ดอกเบี้ย
                Total_Tax_TBx.Text = vat.ToString("#,##0.00"); // ภาษี 
                Total_Leasing_TBx.Text = totalFinance.ToString("#,##0.00"); // ยอดเช่า-ซื้อ

                Period_Cal_TBx.Text = payPerTime.ToString("#,##0.00"); // ค่างวด
                Tax_per_m_TBx.Text = taxpermonth.ToString("#,##0.00"); // ภาษีต่องวด
                Period_pure_TBx.Text = payPerTimeTotal.ToString("#,##0.00"); // ค่างวดสุทธิ
                Period_Payment_TBx.Text = periodPayment.ToString("#,##0.00"); // ค่างวดจ่ายจริง

                
                /********** Text Style Font Bold and Font Color Red **********/

                Total_Sum_TBx.Font.Bold = true;
                Total_Interest_TBx.Font.Bold = true;
                Total_Tax_TBx.Font.Bold = true;
                Total_Leasing_TBx.Font.Bold = true;
                Period_Cal_TBx.Font.Bold = true;
                Tax_per_m_TBx.Font.Bold = true;
                Period_pure_TBx.Font.Bold = true;
                Period_Payment_TBx.Font.Bold = true;

                Total_Sum_TBx.ForeColor = Color.Red;
                Total_Interest_TBx.ForeColor = Color.Red;
                Total_Tax_TBx.ForeColor = Color.Red;
                Total_Leasing_TBx.ForeColor = Color.Red;
                Period_Cal_TBx.ForeColor = Color.Red;
                Tax_per_m_TBx.ForeColor = Color.Red;
                Period_pure_TBx.ForeColor = Color.Red;
                Period_Payment_TBx.ForeColor = Color.Red;

                /********** Text Style Font Bold and Font Color Red **********/
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/


        private void _AddLeasings()
        {
            Car_Leasings cl = new Car_Leasings();

            cl.Leasing_id = "";
            cl.Deps_no = string.IsNullOrEmpty(Deps_No_TBx.Text)? "" : Deps_No_TBx.Text;
            cl.Leasing_no = Leasing_No_TBx.Text;
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
            cl.Total_sum = Convert.ToDouble(Total_Sum_TBx.Text);
            cl.Total_Interest = Convert.ToDouble(Total_Interest_TBx.Text);
            cl.Total_Tax = Convert.ToDouble(Total_Tax_TBx.Text);
            cl.Total_leasing = Convert.ToDouble(Total_Leasing_TBx.Text);
            cl.Period_cal = Convert.ToDouble(Period_Cal_TBx.Text);
            cl.Tax_per_m = Convert.ToDouble(Tax_per_m_TBx.Text);
            cl.Period_pure = Convert.ToDouble(Period_pure_TBx.Text);
            cl.Period_payment = Convert.ToDouble(Period_Payment_TBx.Text);
            cl.Payment_schedule = Convert.ToInt32(Payment_Schedule_DDL.Text);
            cl.First_payment_date = First_Payment_Date_TBx.Text;
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
            cl.Car_credits = Car_Credits_TBx.Text;
            cl.Car_dealer = Car_Dealer_TBx.Text;
            cl.Car_old_owner = Car_Old_Owner_TBx.Text;
            cl.Car_old_owner_idcard = Car_Old_Owner_Idcard_TBx.Text;
            cl.Car_old_owner_idcard_str = Car_Old_Owner_Idcard_Str_TBx.Text;
            cl.Car_old_owner_idcard_exp = Car_Old_Owner_Idcard_Exp_TBx.Text;
            cl.Car_old_owner_address_no = Car_Old_Owner_Address_No_TBx.Text;
            cl.Car_old_owner_vilage = Car_Old_Owner_Vilage_TBx.Text;
            cl.Car_old_owner_vilage_no = Car_Old_Owner_Vilage_No_TBx.Text;
            cl.Car_old_owner_alley = Car_Old_Owner_alley_TBx.Text;
            cl.Car_old_owner_road = Car_Old_Owner_Road_TBx.Text;
            cl.Car_old_owner_subdistrict = Car_Old_Owner_Subdistrict_TBx.Text;
            cl.Car_old_owner_district = Car_Old_Owner_District_TBx.Text;
            cl.Car_old_owner_province = Convert.ToInt32(Car_Old_Owner_Province_DDL.SelectedValue);
            cl.Car_old_owner_contry = Car_Old_Owner_Contry_TBx.Text;
            cl.Car_old_owner_zipcode = Car_Old_Owner_Zipcode_TBx.Text;
            cl.Cust_idcard = "";
            cl.Tent_car_id = Convert.ToInt32(Tent_car_DDL.SelectedValue);
            cl.Check_receive_person = Check_receive_person_TBx.Text;
            cl.Check_number = Check_number_TBx.Text;
            cl.Check_payment = Convert.ToDouble(Check_payment_TBx.Text);
            cl.Check_receive_date = Check_receive_date_TBx.Text;
            cl.Contract_status = "1";

        }
    }
}
 
 