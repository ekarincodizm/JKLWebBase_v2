using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Managers_Agents;


namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Payment : Page
    {
        Customers ctm = new Customers();
        Car_Leasings cls = new Car_Leasings();
        Base_Companys bs_cpn = new Base_Companys();
        Base_Car_Brands bs_cbrn = new Base_Car_Brands();
        TH_Provinces car_plt_pv = new TH_Provinces();
        Base_Zone_Service bs_zn = new Base_Zone_Service();
        Agents_Commission cag_com = new Agents_Commission();

        Agents_Manager cag_mng = new Agents_Manager();
        Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
        Base_Car_Brand_Manager cbrn_mng = new Base_Car_Brand_Manager();
        TH_Provinces_Manager th_pv_mng = new TH_Provinces_Manager();
        Base_Companys_Manager bs_cpn_mng = new Base_Companys_Manager();
        Base_Zone_Service_Manager bs_zn_mng = new Base_Zone_Service_Manager();
        Car_Leasings_Customer_Manager cls_ctm_mng = new Car_Leasings_Customer_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string leasing_id = code[1];
                    string idcard = code[2];

                    Close_Leasing_Lbl.Visible = false;
                    Cal_Status_Lbl.Visible = false;

                    _loadLeasingDetails(leasing_id, idcard);
                }
            }
        }

        private void _loadLeasingDetails(string leasing_id, string idcard)
        {
            cls = cls_mng.getCarLeasingById(leasing_id);

            if (cls.Total_payment_left == 0)
            {
                Close_Leasing_Lbl.Visible = true;
                Cal_Status_Lbl.Visible = false;
                
                Payment_Btn.Visible = false;
                Calculate_Close_Leasing_Btn.Visible = false;
                Back_Before_Page_Btn.Visible = false;
            }
            else
            {

                Leasing_Date_TBx.Text = DateTimeUtility.convertDateToPage(cls.Leasing_date);
                Deps_No_TBx.Text = cls.Deps_no;
                Leasing_No_TBx.Text = cls.Leasing_no;

                bs_cpn = bs_cpn_mng.getCompanysById(cls.bs_cpn.Company_id.ToString());

                Company_N_Name_TBx.Text = bs_cpn.Company_N_name;
                Company_F_Name_TBx.Text = bs_cpn.Company_F_name;

                bs_zn = bs_zn_mng.getZoneById(cls.bs_zn.Zone_id);

                Zone_Name_TBx.Text = bs_zn.Zone_code + " " + bs_zn.Zone_name;

                ctm = cls_ctm_mng.getCustomersLeasing(leasing_id, idcard);

                Customer_Name_TBx.Text = ctm.Cust_Fname + " " + ctm.Cust_LName;
                Customer_Idcard_TBx.Text = ctm.Cust_Idcard.Length == 13 ? ctm.Cust_Idcard.Substring(0, 1) + "-" + ctm.Cust_Idcard.Substring(1, 4) + "-" + ctm.Cust_Idcard.Substring(5, 5) + "-" + ctm.Cust_Idcard.Substring(10, 2) + "-" + ctm.Cust_Idcard.Substring(12) : ctm.Cust_Idcard;
                Customer_B_Date_TBx.Text = DateTimeUtility.convertDateToPage(ctm.Cust_B_date);
                Customer_Age_TBx.Text = ctm.Cust_Age.ToString();

                Customer_H_Address_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Home_address_no) ? "" : ctm.Cust_Home_address_no;
                Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_vilage_no) ? "" : ctm.Cust_Home_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage_no.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_vilage_no : "";
                Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_vilage) ? "" : ctm.Cust_Home_vilage.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_vilage : "";
                Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_alley) ? "" : ctm.Cust_Home_alley.IndexOf('.') >= 1 ? ctm.Cust_Home_alley.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_alley : "";
                Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_road) ? "" : ctm.Cust_Home_road.IndexOf('.') >= 1 ? ctm.Cust_Home_road.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_road : "";
                Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_subdistrict) ? "" : ctm.Cust_Home_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Home_subdistrict.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_subdistrict : "";
                Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_district) ? "" : ctm.Cust_Home_district.IndexOf('.') >= 1 ? ctm.Cust_Home_district.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_district : "";
                Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.ctm_home_pv.Province_name) ? "" : " จ." + ctm.ctm_home_pv.Province_name;

                Customer_C_Address_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Current_address_no) ? "" : ctm.Cust_Current_address_no;
                Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_vilage_no) ? "" : ctm.Cust_Current_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage_no.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_vilage_no : "";
                Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_vilage) ? "" : ctm.Cust_Current_vilage.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_vilage : "";
                Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_alley) ? "" : ctm.Cust_Current_alley.IndexOf('.') >= 1 ? ctm.Cust_Current_alley.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_alley : "";
                Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_road) ? "" : ctm.Cust_Current_road.IndexOf('.') >= 1 ? ctm.Cust_Current_road.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_road : "";
                Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_subdistrict) ? "" : ctm.Cust_Current_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Current_subdistrict.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_subdistrict : "";
                Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_district) ? "" : ctm.Cust_Current_district.IndexOf('.') >= 1 ? ctm.Cust_Current_district.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_district : "";
                Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.ctm_current_pv.Province_name) ? "" : " จ." + ctm.ctm_current_pv.Province_name;

                Car_Type_TBx.Text = cls.Car_type;

                bs_cbrn = cbrn_mng.geCartBrandById(cls.bs_cbrn.car_brand_id);

                Car_Brand_TBx.Text = bs_cbrn.car_brand_name_th + " ( " + bs_cbrn.car_brand_name_eng + " )";

                car_plt_pv = th_pv_mng.getProvinceById(cls.cls_plate_pv.Province_id);

                Car_Plate_TBx.Text = cls.Car_license_plate + " " + car_plt_pv.Province_name;

                Car_Chassis_No_TBx.Text = cls.Car_chassis_no;
                Car_Engine_No_TBx.Text = cls.Car_engine_no;

                cag_com = cag_mng.getAgentCommission("", leasing_id);

                Agent_Commission_TBx.Text = cag_com.Agent_commission.ToString("#,###.00");

                Finance_Cost_TBx.Text = cls.Total_require.ToString("#,###.00");
                Finance_Value_TBx.Text = cls.Total_sum.ToString("#,###.00");
                Leasing_Cost_TBx.Text = cls.Total_Net_leasing.ToString("#,###.00");
                Period_Amount_TBx.Text = cls.Total_period.ToString();
                Period_Payment_TBx.Text = cls.Period_payment.ToString("#,###.00");
                Payment_Schedule_TBx.Text = cls.Payment_schedule.ToString();
                Frist_Payment_Date_TBx.Text = DateTimeUtility.convertDateToPage(cls.First_payment_date);

                Payment_Date_TBx.Text = DateTimeUtility.convertDateToPage(DateTime.Now.ToString());

                Period_No_TBx.Text = cls.Total_period_length;
                Total_Payment_Period_TBx.Text = cls.Total_period_lose.ToString();
                Total_payment_left_TBx.Text = cls.Total_payment_left.ToString("#,###.00");
                Period_free_TBx.Text = "0.00";
                Period_track_TBx.Text = "0.00";
                Discount_TBx.Text = "0.00";

                List<Car_Leasings_Payment> list_cls_pay = cls_mng.getPaymentScheduleById(leasing_id);

                double total_lost = 0.00;
                double total_period = 0.00;
                double total_interest = 0.00;
                double total_vat = 0.00;
                double total_payment_fine = 0.00;

                for (int i = 0; i < list_cls_pay.Count; i++)
                {
                    Car_Leasings_Payment cls_pay = list_cls_pay[i];

                    int period_str = Convert.ToInt32(cls.Total_period_length.Split('-')[0].Trim());
                    int period_end = Convert.ToInt32(cls.Total_period_length.Split('-')[1].Trim());

                    if (cls_pay.Period_no >= period_str && cls_pay.Period_no <= period_end)
                    {
                        total_period += cls_pay.Period_principle;
                        total_interest += cls_pay.Period_interst;
                        total_vat += cls_pay.Period_vat;
                        total_lost += cls_pay.Period_current;
                    }

                    if (cls_pay.Total_payment_fine != 0)
                    {
                        total_payment_fine = cls_pay.Total_payment_fine;
                    }

                }

                Total_payment_fine_TBx.Text = total_payment_fine.ToString("#,###.00");

                Total_period_left_TBx.Text = total_lost.ToString("#,###.00");
                Period_principle_TBx.Text = total_period.ToString("#,###.00");
                Period_interst_TBx.Text = total_interest.ToString("#,###.00");
                Period_vat_TBx.Text = total_vat.ToString("#,###.00");
                Period_fine_TBx.Text = total_payment_fine.ToString("#,###.00");
                Cal_Period_Payment_TBx.Text = (total_lost + total_payment_fine).ToString("#,###.00");

                Session["list_cls_pay"] = list_cls_pay;

                Total_payment_fine_TBx.Focus();
            }
        }

        protected void Calculate_Close_Leasing_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string leasing_id = code[1];
                string idcard = code[2];

                cls = cls_mng.getCarLeasingById(leasing_id);

                List<Car_Leasings_Payment> list_cls_pay = cls_mng.getPaymentScheduleById(leasing_id);

                double total_lost = 0;
                double total_period = 0;
                double total_interest = 0;
                double total_vat = 0;
                double total_payment_fine = 0.00;
                string date_last_payemnt = string.Empty;
                double interest = 0;
                double interest_per_day = 0;
                double day_of_cal = 0;
                double discount = 0;

                for (int i = 0; i < list_cls_pay.Count; i++)
                {
                    Car_Leasings_Payment cls_pay = list_cls_pay[i];

                    int period_str = Convert.ToInt32(cls.Total_period_length.Split('-')[0].Trim());
                    int period_end = Convert.ToInt32(cls.Total_period_length.Split('-')[1].Trim());

                    if (cls_pay.Period_no >= period_str && cls_pay.Period_no <= period_end)
                    {
                        total_lost += cls_pay.Period_current;
                    }

                    total_period += cls_pay.Period_principle;
                    total_interest += cls_pay.Period_interst;
                    total_vat += cls_pay.Period_vat;

                    if (cls_pay.Total_payment_fine != 0)
                    {
                        total_payment_fine = cls_pay.Total_payment_fine;
                    }

                    date_last_payemnt = cls_pay.Period_schedule;

                    interest = cls_pay.Period_interst;
                }

                Total_payment_fine_TBx.Text = total_payment_fine.ToString("#,###.00");

                Total_period_left_TBx.Text = total_lost.ToString("#,###.00");
                Period_principle_TBx.Text = total_period.ToString("#,###.00");
                Period_interst_TBx.Text = total_interest.ToString("#,###.00");
                Period_vat_TBx.Text = total_vat.ToString("#,###.00");
                Period_fine_TBx.Text = total_payment_fine.ToString("#,###.00");
                
                interest_per_day = interest / 30;
                day_of_cal = (Convert.ToDateTime(date_last_payemnt) - DateTime.Now).TotalDays;
                discount = Math.Floor((day_of_cal * interest_per_day) / 2);

                Discount_TBx.Text = (discount * (-1)).ToString("#,###.00");
                Cal_Period_Payment_TBx.Text = ((cls.Total_Net_leasing + total_payment_fine) - discount).ToString("#,###.00");

                Calculate_Close_Leasing_Btn.Focus();

                Close_Leasing_Lbl.Visible = false;
                Cal_Status_Lbl.Visible = true;
            }
        }

        protected void Back_Before_Page_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string leasing_id = code[1];
                string idcard = code[2];

                Close_Leasing_Lbl.Visible = false;
                Cal_Status_Lbl.Visible = false;

                _loadLeasingDetails(leasing_id, idcard);
            }
        }

        protected void Payment_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}