using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Drawing;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Leasings;


namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Edit : System.Web.UI.Page
    {
        Customers ctm = new Customers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Leasings"] == null)
            {
                Session["Class_Active"] = 2;
                Response.Redirect("/Form_Leasings/Leasing_Add");
            }

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

                Car_Leasings cls_tmp = (Car_Leasings)Session["Leasings"];

                _GetLeasing(cls_tmp.Leasing_id);
            }
        }

        protected void Total_Period_TBx_TextChanged(object sender, EventArgs e)
        {
            _Calculated();

            Total_Net_Leasing_TBx.Focus();
        }

        protected void Calculate_Btn_Click(object sender, EventArgs e)
        {
            _Calculated();

            Total_Net_Leasing_TBx.Focus();
        }
        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            _EditLeasings();

            Session["Class_Active"] = 3;

            if (Session["Agents_Leasing"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add_Agent");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit_Agent");
            }
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลประเภทรภ
        private void _loadCarType()
        {
            List<Base_Car_Types> list_data = new Base_Car_Types_Manager().getCarTypes();
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
        }

        // ปีรถ
        private void _loadCarYear()
        {
            Car_Year_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            int year_list = DateTime.Now.Year;
            while (year_list >= 1957)
            {
                // int year_th = year_list + 543; // พ.ศ.
                int year_th = year_list; // ค.ศ.
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
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys();
            Company_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Companys data = list_data[i];
                Company_DDL.Items.Add(new ListItem(data.Company_code + " ( " + data.Company_N_name + " ) ", data.Company_id.ToString()));
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
            int day_start = 1;
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
            Car_Plate_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Car_Old_Owner_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Car_Plate_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }

            Car_Old_Owner_Province_DDL.SelectedValue = "39";
            Car_Plate_Province_DDL.SelectedValue = "39";
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************              Get Data And Replace To Form Function                 ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _GetLeasing(string Leasing_id)
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();

            Car_Leasings cls_tmp = cls_mng.getCarLeasingById(Leasing_id);

            Deps_No_TBx.Text = cls_tmp.Deps_no;
            Leasing_No_TBx.Text = cls_tmp.Leasing_no;
            Leasing_Code_DDL.SelectedValue = cls_tmp.bs_ls_code.Leasing_code_id.ToString();
            Leasing_Date_TBx.Text = DateTimeUtility.convertDateToPage(cls_tmp.Leasing_date);
            Company_DDL.SelectedValue = cls_tmp.bs_cpn.Company_id.ToString();
            Zone_DDL.SelectedValue = cls_tmp.bs_zn.Zone_id.ToString();
            Court_DDL.SelectedValue = cls_tmp.bs_ct.Court_id.ToString();
            Person_Receive_Trasfer_TBx.Text = cls_tmp.PeReT;

            TotalPaymentTime_DDL.SelectedValue = cls_tmp.TotalPaymentTime.ToString();
            Total_Require_TBx.Text = cls_tmp.Total_require.ToString();
            Interest_Rate_TBx.Text = cls_tmp.Interest_rate.ToString();
            Total_Period_TBx.Text = cls_tmp.Total_period.ToString();
            Total_Sum_TBx.Text = cls_tmp.Total_sum.ToString("#,##0.00");
            Total_Interest_TBx.Text = cls_tmp.Total_Interest.ToString("#,##0.00");
            Total_Tax_TBx.Text = cls_tmp.Total_Tax.ToString("#,##0.00");
            Total_Leasing_TBx.Text = cls_tmp.Total_leasing.ToString("#,##0.00");
            Total_Net_Leasing_TBx.Text = cls_tmp.Total_Net_leasing.ToString("#,##0.00");
            Period_Cal_TBx.Text = cls_tmp.Period_cal.ToString("#,##0.00");
            Period_interst_TBx.Text = cls_tmp.Period_interst.ToString("#,##0.00");
            Period_tax_TBx.Text = cls_tmp.Period_tax.ToString("#,##0.00");
            Period_pure_TBx.Text = cls_tmp.Period_pure.ToString("#,##0.00");
            Period_Payment_TBx.Text = cls_tmp.Period_payment.ToString("#,##0.00");
            Period_require_TBx.Text = cls_tmp.Period_require.ToString("#,##0.00");

            Payment_Schedule_DDL.SelectedValue = cls_tmp.Payment_schedule.ToString();
            First_Payment_Date_TBx.Text = DateTimeUtility.convertDateToPage(cls_tmp.First_payment_date);

            // ข้อมูลรถ
            Car_Register_Date_TBx.Text = DateTimeUtility.convertDateToPage(cls_tmp.Car_register_date);
            Car_Plate_TBx.Text = cls_tmp.Car_license_plate;
            Car_Plate_Province_DDL.SelectedValue = cls_tmp.cls_plate_pv.Province_id.ToString();
            Car_Type_TBx.Text = cls_tmp.Car_type;
            Car_Feature_TBx.Text = cls_tmp.Car_feature;
            Car_Brand_DDL.SelectedValue = cls_tmp.bs_cbrn.car_brand_id.ToString();
            Car_Model_TBx.Text = cls_tmp.Car_model;
            Car_Year_DDL.SelectedValue = cls_tmp.Car_year;
            Car_Color_TBx.Text = cls_tmp.Car_color;
            Engine_No_TBx.Text = cls_tmp.Car_engine_no;
            Engine_No_At_TBx.Text = cls_tmp.Car_engine_no_at;
            Engine_Brand_TBx.Text = cls_tmp.Car_engine_brand;
            Chassis_No_TBx.Text = cls_tmp.Car_chassis_no;
            Chassis_No_At_TBx.Text = cls_tmp.Car_chassis_no_at;
            Car_Fuel_Type_TBx.Text = cls_tmp.Car_fual_type;
            Car_Gas_No_TBx.Text = cls_tmp.Car_gas_No;
            Car_Used_DDL.SelectedValue = cls_tmp.Car_used_id.ToString();
            Car_Distance_TBx.Text = cls_tmp.Car_distance.ToString();
            Car_Next_Register_Date_TBx.Text = DateTimeUtility.convertDateToPage(cls_tmp.Car_next_register_date);
            Car_Tax_Value_TBx.Text = cls_tmp.Car_tax_value.ToString();
            Car_Credits_TBx.Text = cls_tmp.Car_credits;
            Car_agent_TBx.Text = cls_tmp.Car_agent;

            Car_Old_Owner_TBx.Text = cls_tmp.Car_old_owner;
            Car_Old_Owner_Idcard_TBx.Text = cls_tmp.Car_old_owner_idcard;
            Car_old_owner_b_date_TBx.Text = DateTimeUtility.convertDateToPage(cls_tmp.Car_old_owner_b_date);
            Car_Old_Owner_Address_No_TBx.Text = cls_tmp.Car_old_owner_address_no;
            Car_Old_Owner_Vilage_TBx.Text = cls_tmp.Car_old_owner_vilage.IndexOf('.') >= 1 ? cls_tmp.Car_old_owner_vilage.Split('.')[1] : "";
            Car_Old_Owner_Vilage_No_TBx.Text = cls_tmp.Car_old_owner_vilage_no.IndexOf('.') >= 1 ? cls_tmp.Car_old_owner_vilage_no.Split('.')[1] : "";
            Car_Old_Owner_alley_TBx.Text = cls_tmp.Car_old_owner_alley.IndexOf('.') >= 1 ? cls_tmp.Car_old_owner_alley.Split('.')[1] : "";
            Car_Old_Owner_Road_TBx.Text = cls_tmp.Car_old_owner_road.IndexOf('.') >= 1 ? cls_tmp.Car_old_owner_road.Split('.')[1] : "";
            Car_Old_Owner_Subdistrict_TBx.Text = cls_tmp.Car_old_owner_subdistrict.IndexOf('.') >= 1 ? cls_tmp.Car_old_owner_subdistrict.Split('.')[1] : "";
            Car_Old_Owner_District_TBx.Text = cls_tmp.Car_old_owner_district.IndexOf('.') >= 1 ? cls_tmp.Car_old_owner_district.Split('.')[1] : "";
            Car_Old_Owner_Province_DDL.SelectedValue = cls_tmp.cls_owner_pv.Province_id.ToString();
            Car_Old_Owner_Contry_TBx.Text = cls_tmp.Car_old_owner_contry;
            Car_Old_Owner_Zipcode_TBx.Text = cls_tmp.Car_old_owner_zipcode;

            Tent_car_DDL.SelectedValue = cls_tmp.tent_car.Tent_car_id.ToString();
            Cheque_receiver_TBx.Text = cls_tmp.Cheque_receiver;
            Cheque_bank_TBx.Text = cls_tmp.Cheque_bank;
            Cheque_bank_branch_TBx.Text = cls_tmp.Cheque_bank_branch;
            Cheque_number_TBx.Text = cls_tmp.Cheque_number;
            Cheque_sum_TBx.Text = cls_tmp.Cheque_sum.ToString("#,##0.00");
            Cheque_receive_date_TBx.Text = DateTimeUtility.convertDateToPage(cls_tmp.Cheque_receive_date);

            _CheckLeasingPayment(Leasing_id);
        }

        private void _CheckLeasingPayment(string Leasing_id)
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
            List<Car_Leasings_Payment> list_cls_pay = cls_mng.getPaymentScheduleById(Leasing_id);

            if (list_cls_pay.Count > 0)
            {
                Car_Leasings_Payment cls_pay = list_cls_pay[0];

                if (string.IsNullOrEmpty(cls_pay.Real_payment_date))
                {
                    Payment_Schedule_DDL.Enabled = true;
                    First_Payment_Date_TBx.Enabled = true;
                    Total_Require_TBx.Enabled = true;
                    Interest_Rate_TBx.Enabled = true;
                    Total_Period_TBx.Enabled = true;
                    Vat_TBx.Enabled = true;
                    Calculate_Btn.Enabled = true;
                }
                else
                {
                    Payment_Schedule_DDL.Enabled = false;
                    First_Payment_Date_TBx.Enabled = false;
                    Total_Require_TBx.Enabled = false;
                    Interest_Rate_TBx.Enabled = false;
                    Total_Period_TBx.Enabled = false;
                    Vat_TBx.Enabled = false;
                    Calculate_Btn.Enabled = false;
                }
            } else
            {
                Payment_Schedule_DDL.Enabled = true;
                First_Payment_Date_TBx.Enabled = true;
                Total_Require_TBx.Enabled = true;
                Interest_Rate_TBx.Enabled = true;
                Total_Period_TBx.Enabled = true;
                Vat_TBx.Enabled = true;
                Calculate_Btn.Enabled = true;
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

                double require = Convert.ToDouble(Total_Require_TBx.Text); // ยอดจัด / เงินต้น
                double interest_rate = Convert.ToDouble(Interest_Rate_TBx.Text); // อัตราดอกเบี้ย
                double period = Convert.ToDouble(Total_Period_TBx.Text); // ระยะเวลา / จำนวนงวด 
                double vat_rate = Convert.ToDouble(Vat_TBx.Text); // อัตราภาษีมูลค่าเพิ่ม

                double interate = require * ((interest_rate / 100) * (period / 12));  /*  ดอกเบี้ย   = ยอดจัด * (อัตราดอกเบี้ย  * ระยะเวลา) */
                double vat = (require + interate) * (vat_rate / 100); /* ภาษี = (ยอดจัด + ดอกเบี้ย ) * (อัตราภาษีมูลค่าเพิ่ม / 100) */
                double finance = require + interate; /* มูลค่า = ยอดจัด + ดอกเบี้ย */
                double totalFinance = require + interate + vat; /* ยอดเช่า-ซื้อ   = ยอดจัด +  ดอกเบี้ย + ภาษี */
                double interateTime = interate / period; /* ดอกเบี้ยต่องวด  = ยอดดอกเบี้ย / ระยะเวลา */
                double payPerTimeTotal = totalFinance / period; /* ค่างวด = ยอดเช่า-ซื้อ  / ระยะเวลา */
                double payPerTime = payPerTimeTotal * (100 / (100 + vat_rate)); /* มูลค่าต่องวด = ค่างวด * ( 100 / 100 + อัตราภาษีมูลค่าเพิ่ม) */
                double taxpermonth = payPerTimeTotal - payPerTime; /* ภาษีต่องวด = ค่างวด  - มูลค่าต่องวด */
                double periodPayment = Math.Ceiling(payPerTimeTotal); /* ค่างวดสุทธิ = ปรับทศนิยม(ค่างวด) */
                double Period_require = require / period; /* เงินต้นต่องวด = ยอดจัด / ระยะเวลา */
                double Period_interst = periodPayment - Period_require - taxpermonth; /* ดอกเบี้ย / งวด = ค่างวดสุทธิ - เงินต้นต่องวด - ภาษีต่องวด */
                double Total_Net_Leasing = periodPayment * period; /* ยอดเช่า-ซื้อสุทธิ = ค่างวดสุทธิ * ระยะเวลา  */

                Total_Sum_TBx.Text = finance.ToString("#,##0.00");  // มูลค่า
                Total_Interest_TBx.Text = interate.ToString("#,##0.00"); // ดอกเบี้ย
                Total_Tax_TBx.Text = vat.ToString("#,##0.00"); // ภาษี 
                Total_Leasing_TBx.Text = totalFinance.ToString("#,##0.00"); // ยอดเช่า-ซื้อ
                Total_Net_Leasing_TBx.Text = Total_Net_Leasing.ToString("#,##0.00"); // ยอดเช่า-ซื้อสุทธิ

                Period_Cal_TBx.Text = payPerTime.ToString("#,##0.00"); // มูลค่า / งวด
                Period_tax_TBx.Text = taxpermonth.ToString("#,##0.00"); // ภาษีต่องวด
                Period_pure_TBx.Text = payPerTimeTotal.ToString("#,##0.00"); // ค่างวด
                Period_Payment_TBx.Text = periodPayment.ToString("#,##0.00"); // ค่างวดสุทธิ
                Period_require_TBx.Text = Period_require.ToString("#,##0.00"); // เงินต้น / งวด
                Period_interst_TBx.Text = Period_interst.ToString("#,##0.00"); // เดอกเบี้ย / งวด

                /********** Text Style Font Bold and Font Color Red **********/

                Total_Sum_TBx.Font.Bold = true;
                Total_Interest_TBx.Font.Bold = true;
                Total_Tax_TBx.Font.Bold = true;
                Total_Leasing_TBx.Font.Bold = true;
                Total_Net_Leasing_TBx.Font.Bold = true;

                Period_Cal_TBx.Font.Bold = true;
                Period_tax_TBx.Font.Bold = true;
                Period_pure_TBx.Font.Bold = true;
                Period_Payment_TBx.Font.Bold = true;
                Period_require_TBx.Font.Bold = true;
                Period_interst_TBx.Font.Bold = true;

                Total_Sum_TBx.ForeColor = Color.Red;
                Total_Interest_TBx.ForeColor = Color.Red;
                Total_Tax_TBx.ForeColor = Color.Red;
                Total_Leasing_TBx.ForeColor = Color.Red;
                Total_Net_Leasing_TBx.ForeColor = Color.Red;

                Period_Cal_TBx.ForeColor = Color.Red;
                Period_tax_TBx.ForeColor = Color.Red;
                Period_pure_TBx.ForeColor = Color.Red;
                Period_Payment_TBx.ForeColor = Color.Red;
                Period_require_TBx.ForeColor = Color.Red;
                Period_interst_TBx.ForeColor = Color.Red;

                /********** Text Style Font Bold and Font Color Red **********/
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/


        private void _EditLeasings()
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
            Car_Leasings cls = new Car_Leasings();

            Car_Leasings cls_tmp = (Car_Leasings)Session["Leasings"];

            // ข้อมูลสัญญา
            cls.Leasing_id = cls_tmp.Leasing_id;
            cls.Deps_no = string.IsNullOrEmpty(Deps_No_TBx.Text) ? "" : Deps_No_TBx.Text;
            cls.Leasing_no = string.IsNullOrEmpty(Leasing_No_TBx.Text) ? "" : Leasing_No_TBx.Text;

            cls.bs_ls_code = new Base_Leasing_Code();
            cls.bs_ls_code.Leasing_code_id = Leasing_Code_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Leasing_Code_DDL.SelectedValue);

            cls.Leasing_date = string.IsNullOrEmpty(Leasing_Date_TBx.Text) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(Leasing_Date_TBx.Text);

            cls.bs_cpn = new Base_Companys();
            cls.bs_cpn.Company_id = Company_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Company_DDL.SelectedValue);

            cls.bs_zn = new Base_Zone_Service();
            cls.bs_zn.Zone_id = Zone_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Zone_DDL.SelectedValue);

            cls.bs_ct = new Base_Courts();
            cls.bs_ct.Court_id = Court_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Court_DDL.SelectedValue);

            cls.PeReT = string.IsNullOrEmpty(Person_Receive_Trasfer_TBx.Text) ? "" : Person_Receive_Trasfer_TBx.Text;

            // ข้อมูลการประเมิน
            cls.TotalPaymentTime = TotalPaymentTime_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(TotalPaymentTime_DDL.SelectedValue);
            cls.Total_require = string.IsNullOrEmpty(Total_Require_TBx.Text) ? 0 : Convert.ToDouble(Total_Require_TBx.Text);
            cls.Vat_rate = string.IsNullOrEmpty(Vat_TBx.Text) ? 0 : Convert.ToDouble(Vat_TBx.Text);
            cls.Interest_rate = string.IsNullOrEmpty(Interest_Rate_TBx.Text) ? 0 : Convert.ToDouble(Interest_Rate_TBx.Text);
            cls.Total_period = string.IsNullOrEmpty(Total_Period_TBx.Text) ? 0 : Convert.ToInt32(Total_Period_TBx.Text);
            cls.Total_sum = string.IsNullOrEmpty(Total_Sum_TBx.Text) ? 0 : Convert.ToDouble(Total_Sum_TBx.Text);
            cls.Total_Interest = string.IsNullOrEmpty(Total_Interest_TBx.Text) ? 0 : Convert.ToDouble(Total_Interest_TBx.Text);
            cls.Total_Tax = string.IsNullOrEmpty(Total_Tax_TBx.Text) ? 0 : Convert.ToDouble(Total_Tax_TBx.Text);
            cls.Total_leasing = string.IsNullOrEmpty(Total_Leasing_TBx.Text) ? 0 : Convert.ToDouble(Total_Leasing_TBx.Text);
            cls.Total_Net_leasing = string.IsNullOrEmpty(Total_Net_Leasing_TBx.Text) ? 0 : Convert.ToDouble(Total_Net_Leasing_TBx.Text);
            cls.Period_cal = string.IsNullOrEmpty(Period_Cal_TBx.Text) ? 0 : Convert.ToDouble(Period_Cal_TBx.Text);
            cls.Period_interst = string.IsNullOrEmpty(Period_interst_TBx.Text) ? 0 : Convert.ToDouble(Period_interst_TBx.Text);
            cls.Period_tax = string.IsNullOrEmpty(Period_tax_TBx.Text) ? 0 : Convert.ToDouble(Period_tax_TBx.Text);
            cls.Period_pure = string.IsNullOrEmpty(Period_pure_TBx.Text) ? 0 : Convert.ToDouble(Period_pure_TBx.Text);
            cls.Period_payment = string.IsNullOrEmpty(Period_Payment_TBx.Text) ? 0 : Convert.ToDouble(Period_Payment_TBx.Text);
            cls.Period_require = string.IsNullOrEmpty(Period_require_TBx.Text) ? 0 : Convert.ToDouble(Period_require_TBx.Text);
            cls.Total_period_left = string.IsNullOrEmpty(Total_Period_TBx.Text) ? 0 : Convert.ToInt32(Total_Period_TBx.Text);
            cls.Total_payment_left = string.IsNullOrEmpty(Total_Net_Leasing_TBx.Text) ? 0 : Convert.ToDouble(Total_Net_Leasing_TBx.Text);
            cls.Payment_schedule = Payment_Schedule_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Payment_Schedule_DDL.SelectedValue);
            cls.First_payment_date = string.IsNullOrEmpty(First_Payment_Date_TBx.Text) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(First_Payment_Date_TBx.Text);

            // ข้อมูลรถ
            cls.Car_register_date = string.IsNullOrEmpty(Car_Register_Date_TBx.Text) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(Car_Register_Date_TBx.Text);
            cls.Car_license_plate = string.IsNullOrEmpty(Car_Plate_TBx.Text) ? "" : Car_Plate_TBx.Text;

            cls.cls_plate_pv = new TH_Provinces();
            cls.cls_plate_pv.Province_id = Car_Plate_Province_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Car_Plate_Province_DDL.SelectedValue);

            cls.Car_type = string.IsNullOrEmpty(Car_Type_TBx.Text) ? "" : Car_Type_TBx.Text;
            cls.Car_feature = string.IsNullOrEmpty(Car_Feature_TBx.Text) ? "" : Car_Feature_TBx.Text;

            cls.bs_cbrn = new Base_Car_Brands();
            cls.bs_cbrn.car_brand_id = Car_Brand_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Car_Brand_DDL.SelectedValue);

            cls.Car_model = string.IsNullOrEmpty(Car_Model_TBx.Text) ? "" : Car_Model_TBx.Text;
            cls.Car_year = Car_Year_DDL.SelectedIndex <= 0 ? "" : Car_Year_DDL.SelectedValue;
            cls.Car_color = string.IsNullOrEmpty(Car_Color_TBx.Text) ? "" : Car_Color_TBx.Text;
            cls.Car_engine_no = string.IsNullOrEmpty(Engine_No_TBx.Text) ? "" : Engine_No_TBx.Text;
            cls.Car_engine_no_at = string.IsNullOrEmpty(Engine_No_At_TBx.Text) ? "" : Engine_No_At_TBx.Text;
            cls.Car_engine_brand = string.IsNullOrEmpty(Engine_Brand_TBx.Text) ? "" : Engine_Brand_TBx.Text;
            cls.Car_chassis_no = string.IsNullOrEmpty(Chassis_No_TBx.Text) ? "" : Chassis_No_TBx.Text;
            cls.Car_chassis_no_at = string.IsNullOrEmpty(Chassis_No_At_TBx.Text) ? "" : Chassis_No_At_TBx.Text;
            cls.Car_fual_type = string.IsNullOrEmpty(Car_Fuel_Type_TBx.Text) ? "" : Car_Fuel_Type_TBx.Text;
            cls.Car_gas_No = string.IsNullOrEmpty(Car_Gas_No_TBx.Text) ? "" : Car_Gas_No_TBx.Text;
            cls.Car_used_id = Car_Used_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Car_Used_DDL.SelectedValue);
            cls.Car_distance = string.IsNullOrEmpty(Car_Distance_TBx.Text) ? 0 : Convert.ToInt32(Car_Distance_TBx.Text);
            cls.Car_next_register_date = string.IsNullOrEmpty(Car_Next_Register_Date_TBx.Text) ? DateTime.Now.ToString() : DateTimeUtility.convertDateToMYSQL(Car_Next_Register_Date_TBx.Text);
            cls.Car_tax_value = string.IsNullOrEmpty(Car_Tax_Value_TBx.Text) ? 0 : Convert.ToDouble(Car_Tax_Value_TBx.Text);
            cls.Car_credits = string.IsNullOrEmpty(Car_Credits_TBx.Text) ? "" : Car_Credits_TBx.Text;
            cls.Car_agent = string.IsNullOrEmpty(Car_agent_TBx.Text) ? "" : Car_agent_TBx.Text;

            // ข้อมูลเจ้าของรถเดิม
            cls.Car_old_owner = string.IsNullOrEmpty(Car_Old_Owner_TBx.Text) ? "" : Car_Old_Owner_TBx.Text;
            cls.Car_old_owner_idcard = string.IsNullOrEmpty(Car_Old_Owner_Idcard_TBx.Text) ? "" : Car_Old_Owner_Idcard_TBx.Text;
            cls.Car_old_owner_b_date = string.IsNullOrEmpty(Car_old_owner_b_date_TBx.Text) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(Car_old_owner_b_date_TBx.Text);
            cls.Car_old_owner_address_no = string.IsNullOrEmpty(Car_Old_Owner_Address_No_TBx.Text) ? "" : Car_Old_Owner_Address_No_TBx.Text;
            cls.Car_old_owner_vilage = string.IsNullOrEmpty(Car_Old_Owner_Vilage_TBx.Text) ? "บ.-" : "บ." + Car_Old_Owner_Vilage_TBx.Text;
            cls.Car_old_owner_vilage_no = string.IsNullOrEmpty(Car_Old_Owner_Vilage_No_TBx.Text) ? "ม.-" : "ม." + Car_Old_Owner_Vilage_No_TBx.Text;
            cls.Car_old_owner_alley = string.IsNullOrEmpty(Car_Old_Owner_alley_TBx.Text) ? "ซ.-" : "ซ." + Car_Old_Owner_alley_TBx.Text;
            cls.Car_old_owner_road = string.IsNullOrEmpty(Car_Old_Owner_Road_TBx.Text) ? "ถ.-" : "ถ." + Car_Old_Owner_Road_TBx.Text;
            cls.Car_old_owner_subdistrict = string.IsNullOrEmpty(Car_Old_Owner_Subdistrict_TBx.Text) ? "ต.-" : "ต." + Car_Old_Owner_Subdistrict_TBx.Text;
            cls.Car_old_owner_district = string.IsNullOrEmpty(Car_Old_Owner_District_TBx.Text) ? "อ.-" : "อ." + Car_Old_Owner_District_TBx.Text;

            cls.cls_owner_pv = new TH_Provinces();
            cls.cls_owner_pv.Province_id = Car_Old_Owner_Province_DDL.SelectedIndex < 0 ? 39 : Convert.ToInt32(Car_Old_Owner_Province_DDL.SelectedValue);

            cls.Car_old_owner_contry = string.IsNullOrEmpty(Car_Old_Owner_Contry_TBx.Text) ? "" : Car_Old_Owner_Contry_TBx.Text;
            cls.Car_old_owner_zipcode = string.IsNullOrEmpty(Car_Old_Owner_Zipcode_TBx.Text) ? "" : Car_Old_Owner_Zipcode_TBx.Text;

            cls.tent_car = new Base_Tents_Car();
            cls.tent_car.Tent_car_id = Tent_car_DDL.SelectedIndex < 0 ? 0 : Convert.ToInt32(Tent_car_DDL.SelectedValue);

            // ข้อมูลเช็คและการโอน
            cls.Cheque_receiver = string.IsNullOrEmpty(Cheque_receiver_TBx.Text) ? "" : Cheque_receiver_TBx.Text;
            cls.Cheque_bank = string.IsNullOrEmpty(Cheque_bank_TBx.Text) ? "" : Cheque_bank_TBx.Text;
            cls.Cheque_bank_branch = string.IsNullOrEmpty(Cheque_bank_branch_TBx.Text) ? "" : Cheque_bank_branch_TBx.Text;
            cls.Cheque_number = string.IsNullOrEmpty(Cheque_number_TBx.Text) ? "" : Cheque_number_TBx.Text;
            cls.Cheque_sum = string.IsNullOrEmpty(Cheque_sum_TBx.Text) ? 0 : Convert.ToDouble(Cheque_sum_TBx.Text);
            cls.Cheque_receive_date = string.IsNullOrEmpty(Cheque_receive_date_TBx.Text) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(Cheque_receive_date_TBx.Text);
            cls.Guarantee = string.IsNullOrEmpty(Guarantee_TBx.Text) ? "" : Guarantee_TBx.Text;

            cls.bs_ls_stt = new Base_Leasing_Status();
            cls.bs_ls_stt.Contract_Status_id = 1;

            cls_mng.editCarLeasings(cls);



            Session["Leasings"] = cls;
        }
    }
}