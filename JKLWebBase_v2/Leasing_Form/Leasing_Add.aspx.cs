using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Base;
using System.Drawing;

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

        protected void link_Leasing_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add");
        }

        protected void link_Add_Bondsman_1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_5_Click(object sender, EventArgs e)
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

            Cust_status_DDL.Focus();
        }

        protected void Calculate_Btn_Click(object sender, EventArgs e)
        {
            _Calculated();
        }

        protected void Home_Copy_Idcard_btn_Click(object sender, EventArgs e)
        {

        }

        protected void Current_Copy_Idcard_btn_Click(object sender, EventArgs e)
        {

        }

        protected void Current_Copy_Home_btn_Click(object sender, EventArgs e)
        {

        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลประเภทรภ
        private void _loadCarType()
        {
            List  <Base_Car_Types> list_data = new Base_Car_Types_Manager().getCarBrands();
            Car_Type_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Car_Types data = list_data[i];
                Car_Type_DDL.Items.Add(new ListItem(data.car_type_name.ToString(), data.car_type_id.ToString()));
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
                Car_Brand_DDL.Items.Add(new ListItem(data.car_brand_name_eng.ToString() + " ( " + data.car_brand_name_th.ToString() + " ) ", data.car_brand_id.ToString()));
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
                    Car_Model_DDL.Items.Add(new ListItem(data.car_model_name.ToString(), data.car_model_id.ToString()));
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
                Leasing_Code_DDL.Items.Add(new ListItem(data.Leasing_code_name.ToString() + " ( " + data.Leasing_code_S_Name.ToString() + " ) ", data.Leasing_code_id.ToString()));
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
                Branch_DDL.Items.Add(new ListItem(data.Branch_code.ToString() + " ( " + data.Branch_N_name.ToString() + " ) ", data.Branch_id.ToString()));
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
                Zone_DDL.Items.Add(new ListItem(data.Zone_code.ToString() + " " + data.Zone_name.ToString(), data.Zone_id.ToString()));
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
                TotalPaymentTime_DDL.Items.Add(new ListItem(data.Total_payment_name.ToString(), data.Total_payment_id.ToString()));
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
                Court_DDL.Items.Add(new ListItem(data.Court_name.ToString(), data.Court_id.ToString()));
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
                Cust_Origin_DDL.Items.Add(new ListItem(data.Origin_name_TH.ToString() + " ( " + data.Origin_name_ENG.ToString() + " ) ", data.Origin_id.ToString()));
                Spouse_Origin_DDL.Items.Add(new ListItem(data.Origin_name_TH.ToString() + " ( " + data.Origin_name_ENG.ToString() + " ) ", data.Origin_id.ToString()));
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
                Cust_Nationality_DDL.Items.Add(new ListItem(data.Nationality_name_TH.ToString() + " ( " + data.Nationality_name_ENG.ToString() + " ) ", data.Nationality_id.ToString()));
                Spouse_Nationality_DDL.Items.Add(new ListItem(data.Nationality_name_TH.ToString() + " ( " + data.Nationality_name_ENG.ToString() + " ) ", data.Nationality_id.ToString()));
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
                Cust_status_DDL.Items.Add(new ListItem(data.person_status_name.ToString(), data.person_status_id.ToString()));
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
                Tent_car_DDL.Items.Add(new ListItem(data.Tent_name.ToString(), data.Tent_car_id.ToString()));
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
                Current_Cust_Home_status_id_DDL.Items.Add(new ListItem(data.Home_status_name.ToString(), data.Home_status_id.ToString()));
                Home_Cust_Home_status_id_DDL.Items.Add(new ListItem(data.Home_status_name.ToString(), data.Home_status_id.ToString()));
                Idcard_Cust_Home_status_DDL.Items.Add(new ListItem(data.Home_status_name.ToString(), data.Home_status_id.ToString()));
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
                Car_Old_Owner_Province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
                Current_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
                Cust_job_province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
                Dealer_province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
                Home_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
                Idcard_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
                Spouse_province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
                Spouse_job_province_DDL.Items.Add(new ListItem(data.Province_name.ToString(), data.Province_id.ToString()));
            }
        }

        private void _Calculated()
        {
            if (!String.IsNullOrEmpty(Total_Require_TBx.Text) && !String.IsNullOrEmpty(Interest_Rate_TBx.Text) && !String.IsNullOrEmpty(Total_Period_TBx.Text) && !String.IsNullOrEmpty(Vat_TBx.Text))
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
    }
}
 
 