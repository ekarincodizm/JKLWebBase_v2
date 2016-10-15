using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
    public partial class Leasing_Edit : System.Web.UI.Page
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
            Response.Redirect("/Leasing_Form/Car_Dealer_Add");
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลประเภทรภ
        private void _loadCarType()
        {
            List<Base_Car_Types> list_data = new Base_Car_Types_Manager().getCarTypes();
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
    }
}