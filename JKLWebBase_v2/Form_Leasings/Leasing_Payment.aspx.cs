﻿using System;
using System.Collections.Generic;
using System.Web.UI;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Managers_Agents;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;
using System.Data.SqlClient;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Payment : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        private Customers ctm = new Customers();
        private Car_Leasings cls = new Car_Leasings();
        private Base_Companys bs_cpn = new Base_Companys();
        private Base_Car_Brands bs_cbrn = new Base_Car_Brands();
        private Base_Zone_Service bs_zn = new Base_Zone_Service();
        private Agents_Commission cag_com = new Agents_Commission();
        private Car_Leasings_Payment cls_pay = new Car_Leasings_Payment();

        private Agents_Manager cag_mng = new Agents_Manager();
        private Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
        private Base_Car_Brand_Manager cbrn_mng = new Base_Car_Brand_Manager();
        private Base_Companys_Manager bs_cpn_mng = new Base_Companys_Manager();
        private Base_Zone_Service_Manager bs_zn_mng = new Base_Zone_Service_Manager();
        private Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();
        private Car_Leasings_Customer_Manager cls_ctm_mng = new Car_Leasings_Customer_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (acc_lgn.acc_lv.level_access < 4)
            {
                Payment_Btn.Visible = false;
                Calculate_Close_Leasing_Btn.Visible = false;
            }

            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string leasing_id = code[1];
                    string idcard = code[2];

                    Close_Leasing_Lbl.Visible = false;
                    Cal_Status_Lbl.Visible = false;

                    _checkOldData(leasing_id);

                    _loadLeasingDetails(leasing_id, idcard);

                    Session["ctm_leasing_payment"] = idcard;
                }
            }
        }

        private void _checkOldData(string leasing_id)
        {
            cls = cls_mng.getCarLeasingById(leasing_id);

            /*string error = string.Empty;

            SqlConnection con = MSSQLConnection.connectionMSSQL();

            List<Car_Leasings_Payment> list_cls_pay_shd = cls_pay_mng.getPaymentSchedule(cls.Leasing_id);

            Car_Leasings_Payment cls_pay_shd = list_cls_pay_shd[0];

            if (cls_pay_shd.Period_payment_status == 0)
            {

                try
                {
                    con.Open();

                    string sql = " SELECT * FROM  view_payment_byday WHERE cntNoTemp = '" + cls.Deps_no + "' ORDER BY scheduleno ";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandTimeout = 0;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int defaultNum = 0;
                        string defaultString = "";

                        Car_Leasings_Payment cls_pay = new Car_Leasings_Payment();

                        cls_pay.Leasing_id = cls.Leasing_id;
                        cls_pay.Bill_no = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                        cls_pay.Period_fee = reader.IsDBNull(5) ? defaultNum : Convert.ToDouble(reader.GetDecimal(5));
                        cls_pay.Period_track = reader.IsDBNull(7) ? defaultNum : Convert.ToDouble(reader.GetDecimal(7));
                        cls_pay.Total_payment_fine = reader.IsDBNull(17) ? defaultNum : Convert.ToDouble(reader.GetDecimal(17));
                        cls_pay.Discount = reader.IsDBNull(9) ? defaultNum : Convert.ToDouble(reader.GetDecimal(9));
                        cls_pay.Real_payment = reader.IsDBNull(4) ? defaultNum : Convert.ToDouble(reader.GetDecimal(4));

                        cls_pay.Real_payment_date = reader.IsDBNull(3) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(3).ToString()); // Real Server JKLFTP

                        //cls_pay.Real_payment_date = reader.IsDBNull(3) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(3).ToString()); // Second Server JKLWebBase

                        cls_pay.acc_lgn = new Account_Login();

                        cls_pay.bs_cpn = new Base_Companys();

                        cls_pay.bs_cpn.Company_id = _getCompanys(reader.GetString(20));

                        if (cls_pay.Discount <= 0)
                        {
                            cls_pay_mng.addPayment_Mod_I(cls_pay, 1);
                        }
                        else
                        {
                            cls_pay_mng.addPayment_Mod_I(cls_pay, 2);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    error = "SqlException ==> Form_Leasings --> Leasing_Payment --> _checkOldData() ";
                    Log_Error._writeErrorFile(error, ex);
                }
                catch (Exception ex)
                {
                    error = "Exception ==> Form_Leasings --> Leasing_Payment --> _checkOldData() ";
                    Log_Error._writeErrorFile(error, ex);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }*/

            cls_pay_mng.calculateFine(cls.Leasing_id);

        }

        // สาขา
        private int _getCompanys(string company)
        {
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(0, 0);
            int result = 1;
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Companys data = list_data[i];
                if (data.Company_N_name == company || data.Company_code == company)
                {
                    result = data.Company_id;
                }
            }

            return result;
        }

        private void _loadLeasingDetails(string leasing_id, string idcard)
        {
            cls = cls_mng.getCarLeasingById(leasing_id);

            Leasing_Comments_Lbl.Text = cls.Leasing_Comment;

            if (cls.Total_payment_left == 0)
            {
                Close_Leasing_Lbl.Visible = true;
                Cal_Status_Lbl.Visible = false;

                Payment_Btn.Visible = false;
                Calculate_Close_Leasing_Btn.Visible = false;
                Back_Before_Page_Btn.Visible = false;

                Leasing_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(cls.Leasing_date);

                Deps_No_TBx.Text = cls.Deps_no;
                Leasing_No_TBx.Text = cls.Leasing_no;

                bs_cpn = bs_cpn_mng.getCompanysById(cls.bs_cpn.Company_id.ToString());

                Company_N_Name_TBx.Text = bs_cpn.Company_N_name;
                Company_F_Name_TBx.Text = bs_cpn.Company_F_name;

                bs_zn = bs_zn_mng.getZoneById(cls.bs_zn.Zone_id);

                Zone_Name_TBx.Text = bs_zn.Zone_code + " " + bs_zn.Zone_name;

                ctm = cls_ctm_mng.getCustomersLeasing(leasing_id, idcard);

                if (ctm != null)
                {
                    Customer_Name_TBx.Text = ctm.Cust_Fname + " " + ctm.Cust_LName;
                    Customer_Idcard_TBx.Text = ctm.Cust_Idcard.Length == 13 ? ctm.Cust_Idcard.Substring(0, 1) + "-" + ctm.Cust_Idcard.Substring(1, 4) + "-" + ctm.Cust_Idcard.Substring(5, 5) + "-" + ctm.Cust_Idcard.Substring(10, 2) + "-" + ctm.Cust_Idcard.Substring(12) : ctm.Cust_Idcard;
                    //Customer_B_Date_TBx.Text = DateTimeUtility.convertDateToPage(ctm.Cust_B_date);
                    //Customer_Age_TBx.Text = ctm.Cust_Age.ToString();

                    Customer_H_Address_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Home_address_no) ? "" : ctm.Cust_Home_address_no;
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_vilage_no) ? "" : ctm.Cust_Home_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage_no.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_vilage_no : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_vilage) ? "" : ctm.Cust_Home_vilage.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_vilage : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_alley) ? "" : ctm.Cust_Home_alley.IndexOf('.') >= 1 ? ctm.Cust_Home_alley.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_alley : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_road) ? "" : ctm.Cust_Home_road.IndexOf('.') >= 1 ? ctm.Cust_Home_road.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_road : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_subdistrict) ? "" : ctm.Cust_Home_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Home_subdistrict.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_subdistrict : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_district) ? "" : ctm.Cust_Home_district.IndexOf('.') >= 1 ? ctm.Cust_Home_district.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_district : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_province) ? "" : ctm.Cust_Home_province.IndexOf('.') >= 1 ? ctm.Cust_Home_province.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_province : "";

                    Customer_C_Address_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Current_address_no) ? "" : ctm.Cust_Current_address_no;
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_vilage_no) ? "" : ctm.Cust_Current_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage_no.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_vilage_no : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_vilage) ? "" : ctm.Cust_Current_vilage.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_vilage : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_alley) ? "" : ctm.Cust_Current_alley.IndexOf('.') >= 1 ? ctm.Cust_Current_alley.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_alley : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_road) ? "" : ctm.Cust_Current_road.IndexOf('.') >= 1 ? ctm.Cust_Current_road.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_road : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_subdistrict) ? "" : ctm.Cust_Current_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Current_subdistrict.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_subdistrict : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_district) ? "" : ctm.Cust_Current_district.IndexOf('.') >= 1 ? ctm.Cust_Current_district.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_district : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_province) ? "" : ctm.Cust_Current_province.IndexOf('.') >= 1 ? ctm.Cust_Current_province.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_province : "";

                }

                Car_Type_TBx.Text = cls.Car_type;

                bs_cbrn = cbrn_mng.getCarBrandById(cls.bs_cbrn.car_brand_id);

                if (bs_cbrn != null)
                {
                    Car_Brand_TBx.Text = bs_cbrn.car_brand_name_th + " ( " + bs_cbrn.car_brand_name_eng + " )";
                }

                Car_Plate_TBx.Text = cls.Car_license_plate + " " + cls.Car_license_plate_province;

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
                Frist_Payment_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(cls.First_payment_date);

                Payment_Date_TBx.Enabled = false;

                List<Car_Leasings_Payment> list_cls_pay = cls_pay_mng.getRealPaymentInfo(leasing_id);

                Session["list_cls_pay"] = list_cls_pay;

                Period_free_TBx.Enabled = false;
                Period_track_TBx.Enabled = false;

                Real_Payment_TBx.Enabled = false;
                Real_Payment_Fine_TBx.Enabled = false;
                Real_Discount_TBx.Enabled = false;

                Payment_Date_TBx.Text = "";

                Period_No_TBx.Text = "";
                Total_Payment_Period_TBx.Text = "";
                Total_payment_left_TBx.Text = "";
                Period_free_TBx.Text = "";
                Period_track_TBx.Text = "";
                Discount_TBx.Text = "";

                Total_payment_fine_TBx.Text = "";

                Total_period_left_TBx.Text = "";
                Period_fine_TBx.Text = "";
                Cal_Period_Payment_TBx.Text = "";
            }
            else
            {
                Leasing_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(cls.Leasing_date);
                Deps_No_TBx.Text = cls.Deps_no;
                Leasing_No_TBx.Text = cls.Leasing_no;

                bs_cpn = bs_cpn_mng.getCompanysById(cls.bs_cpn.Company_id.ToString());

                Company_N_Name_TBx.Text = bs_cpn.Company_N_name;
                Company_F_Name_TBx.Text = bs_cpn.Company_F_name;

                bs_zn = bs_zn_mng.getZoneById(cls.bs_zn.Zone_id);

                Zone_Name_TBx.Text = bs_zn.Zone_code + " " + bs_zn.Zone_name;

                ctm = cls_ctm_mng.getCustomersLeasing(leasing_id, idcard);

                if (ctm != null)
                {
                    Customer_Name_TBx.Text = ctm.Cust_Fname + " " + ctm.Cust_LName;
                    Customer_Idcard_TBx.Text = ctm.Cust_Idcard.Length == 13 ? ctm.Cust_Idcard.Substring(0, 1) + "-" + ctm.Cust_Idcard.Substring(1, 4) + "-" + ctm.Cust_Idcard.Substring(5, 5) + "-" + ctm.Cust_Idcard.Substring(10, 2) + "-" + ctm.Cust_Idcard.Substring(12) : ctm.Cust_Idcard;
                    //Customer_B_Date_TBx.Text = DateTimeUtility.convertDateToPage(ctm.Cust_B_date);
                    //Customer_Age_TBx.Text = ctm.Cust_Age.ToString();

                    Customer_H_Address_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Home_address_no) ? "" : ctm.Cust_Home_address_no;
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_vilage_no) ? "" : ctm.Cust_Home_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage_no.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_vilage_no : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_vilage) ? "" : ctm.Cust_Home_vilage.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_vilage : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_alley) ? "" : ctm.Cust_Home_alley.IndexOf('.') >= 1 ? ctm.Cust_Home_alley.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_alley : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_road) ? "" : ctm.Cust_Home_road.IndexOf('.') >= 1 ? ctm.Cust_Home_road.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_road : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_subdistrict) ? "" : ctm.Cust_Home_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Home_subdistrict.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_subdistrict : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_district) ? "" : ctm.Cust_Home_district.IndexOf('.') >= 1 ? ctm.Cust_Home_district.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_district : "";
                    Customer_H_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Home_province) ? "" : ctm.Cust_Home_province.IndexOf('.') >= 1 ? ctm.Cust_Home_province.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Home_province : "";

                    Customer_C_Address_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Current_address_no) ? "" : ctm.Cust_Current_address_no;
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_vilage_no) ? "" : ctm.Cust_Current_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage_no.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_vilage_no : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_vilage) ? "" : ctm.Cust_Current_vilage.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_vilage : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_alley) ? "" : ctm.Cust_Current_alley.IndexOf('.') >= 1 ? ctm.Cust_Current_alley.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_alley : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_road) ? "" : ctm.Cust_Current_road.IndexOf('.') >= 1 ? ctm.Cust_Current_road.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_road : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_subdistrict) ? "" : ctm.Cust_Current_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Current_subdistrict.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_subdistrict : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_district) ? "" : ctm.Cust_Current_district.IndexOf('.') >= 1 ? ctm.Cust_Current_district.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_district : "";
                    Customer_C_Address_TBx.Text += string.IsNullOrEmpty(ctm.Cust_Current_province) ? "" : ctm.Cust_Current_province.IndexOf('.') >= 1 ? ctm.Cust_Current_province.Split('.')[1] == "-" ? "" : " " + ctm.Cust_Current_province : "";

                }

                Car_Type_TBx.Text = cls.Car_type;

                bs_cbrn = cbrn_mng.getCarBrandById(cls.bs_cbrn.car_brand_id);

                if (bs_cbrn != null)
                {
                    Car_Brand_TBx.Text = bs_cbrn.car_brand_name_th + " ( " + bs_cbrn.car_brand_name_eng + " )";
                }

                Car_Plate_TBx.Text = cls.Car_license_plate + " " + cls.Car_license_plate_province;

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
                Frist_Payment_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(cls.First_payment_date);

                Payment_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(DateTime.Now.ToString());

                Period_No_TBx.Text = cls.Total_period_length;
                Total_Payment_Period_TBx.Text = cls.Total_period_lose == 0 ? "1" : cls.Total_period_lose.ToString();
                Total_payment_left_TBx.Text = cls.Total_payment_left.ToString("#,###.00");
                Period_free_TBx.Text = "0.00";
                Period_track_TBx.Text = "0.00";
                Discount_TBx.Text = "0.00";

                List<Car_Leasings_Payment> list_cls_pay = cls_pay_mng.getRealPaymentInfo(leasing_id);

                double total_lost = 0.00;
                double total_payment_fine = 0.00;
                double payment_fine = 0.00;
                double real_payment_fine = 0.00;
                double real_payment = 0.00;
                double next_period_no = 1;
                double duplicate_period = 0;

                for (int i = 0; i < list_cls_pay.Count; i++)
                {
                    Car_Leasings_Payment cls_pay = list_cls_pay[i];

                    if (string.IsNullOrEmpty(cls.Total_period_length))
                    {
                        total_lost = cls_pay.Period_current;
                        Period_No_TBx.Text = next_period_no.ToString();
                    }
                    else
                    {
                        int period_str = Convert.ToInt32(cls.Total_period_length.Split('-')[0].Trim());
                        int period_end = Convert.ToInt32(cls.Total_period_length.Split('-')[1].Trim());

                        if (cls_pay.Period_no >= period_str && cls_pay.Period_no <= period_end && cls_pay.Period_no != duplicate_period)
                        {
                            total_lost += cls_pay.Period_current;
                        }
                    }

                    if (cls_pay.Period_fine > 0 && cls_pay.Period_no != duplicate_period)
                    {
                        payment_fine += cls_pay.Period_fine;
                    }

                    if (cls_pay.Real_payment_fine > 0)
                    {
                        real_payment_fine += cls_pay.Real_payment_fine;
                    }

                    if (cls_pay.Real_payment > 0 && cls_pay.Period_payment_status != 9)
                    {
                        real_payment += cls_pay.Real_payment;
                    }

                    if (cls_pay.Period_payment_status == 9 && cls_pay.Period_no != duplicate_period)
                    {
                        next_period_no += 1;
                    }

                    duplicate_period = cls_pay.Period_no;
                }

                total_payment_fine = payment_fine - real_payment_fine;

                Total_payment_fine_TBx.Text = total_payment_fine > 0 ? total_payment_fine.ToString("#,###.00") : "0.00";

                Total_period_left_TBx.Text = string.IsNullOrEmpty(cls.Total_period_length) ? "0.00" : (total_lost - real_payment).ToString("#,###.00");

                Period_fine_TBx.Text = total_payment_fine < 0 ? "0.00" : total_payment_fine.ToString("#,###.00");

                Cal_Period_Payment_TBx.Text = (total_lost - real_payment).ToString("#,###.00");

                Session["list_cls_pay"] = list_cls_pay;

                Real_Payment_TBx.Focus();
            }
        }

        protected void Calculate_Close_Leasing_Btn_Click(object sender, EventArgs e)
        {
            Note_Lbl.Text = "";

            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string leasing_id = code[1];
                string idcard = code[2];

                _calculateCloseLeasing(leasing_id, idcard);
            }
        }

        private void _calculateCloseLeasing(string leasing_id, string idcard)
        {
            cls = cls_mng.getCarLeasingById(leasing_id);

            List<Car_Leasings_Payment> list_cls_pay = cls_pay_mng.getRealPaymentInfo(leasing_id);

            double total_lost = 0;
            double total_payment = 0;
            double total_payment_fine = 0.00;
            string date_last_payemnt = string.Empty;
            double payment_fine = 0.00;
            double real_payment_fine = 0.00;
            double interest = 0;
            double interest_per_day = 0;
            double day_of_cal = 0;
            double discount = 0;
            double next_period_no = 1;
            double real_payment = 0.00;
            double duplicate_period = 0;

            for (int i = 0; i < list_cls_pay.Count; i++)
            {
                Car_Leasings_Payment cls_pay = list_cls_pay[i];

                if (string.IsNullOrEmpty(cls.Total_period_length))
                {
                    Period_No_TBx.Text = next_period_no.ToString();
                }
                else
                {
                    int period_str = Convert.ToInt32(cls.Total_period_length.Split('-')[0].Trim());
                    int period_end = Convert.ToInt32(cls.Total_period_length.Split('-')[1].Trim());

                    if (cls_pay.Period_no >= period_str && cls_pay.Period_no <= period_end)
                    {
                        total_lost += cls_pay.Period_current;
                    }
                }

                if (cls_pay.Period_no != duplicate_period)
                {
                    total_payment += cls_pay.Period_current;
                }
                else
                {
                    next_period_no += 1;
                }

                if (cls_pay.Total_payment_fine != 0)
                {
                    total_payment_fine = cls_pay.Total_payment_fine;
                }

                date_last_payemnt = cls_pay.Period_schedule;

                interest = cls_pay.Period_interst;

                if (cls_pay.Period_fine > 0 && cls_pay.Period_no != duplicate_period)
                {
                    payment_fine += cls_pay.Period_fine;
                    duplicate_period = cls_pay.Period_no;
                }

                if (cls_pay.Real_payment_fine > 0)
                {
                    real_payment_fine += cls_pay.Real_payment_fine;
                }

                if (cls_pay.Real_payment > 0)
                {
                    real_payment += cls_pay.Real_payment;
                }
            }

            total_payment_fine = payment_fine - real_payment_fine;

            Total_payment_fine_TBx.Text = total_payment_fine <= 0 ? "0.00" : total_payment_fine.ToString("#,###.00");

            Total_period_left_TBx.Text = (total_lost - real_payment) <= 0 ? "0.00" : (total_lost - real_payment).ToString("#,###.00");

            Period_fine_TBx.Text = total_payment_fine < 0 ? "0.00" : total_payment_fine.ToString("#,###.00");

            interest_per_day = interest / 30;
            day_of_cal = (Convert.ToDateTime(date_last_payemnt) - DateTime.Now).TotalDays;
            discount = Math.Floor((day_of_cal * interest_per_day) / 2);

            Discount_TBx.Text = discount.ToString("#,###.00");

            Cal_Period_Payment_TBx.Text = (cls.Total_Net_leasing - real_payment).ToString("#,###.00");

            Real_Payment_TBx.Focus();

            Close_Leasing_Lbl.Visible = false;
            Cal_Status_Lbl.Visible = true;
        }

        protected void Back_Before_Page_Btn_Click(object sender, EventArgs e)
        {
            if (Cal_Status_Lbl.Visible == true)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string leasing_id = code[1];
                    string idcard = code[2];

                    Close_Leasing_Lbl.Visible = false;
                    Cal_Status_Lbl.Visible = false;
                    Note_Lbl.Text = "";
                    Real_Payment_TBx.Text = "";
                    Real_Payment_Fine_TBx.Text = "";
                    Real_Discount_TBx.Text = "";

                    _loadLeasingDetails(leasing_id, idcard);
                }
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Search_Payment");
            }
        }

        protected void Payment_Btn_Click(object sender, EventArgs e)
        {
            string[] code = Request.Params["code"].Split('U');
            string leasing_id = code[1];
            string idcard = code[2];

            cls = cls_mng.getCarLeasingById(leasing_id);

            double real_payment = string.IsNullOrEmpty(Real_Payment_TBx.Text) ? 0 : Convert.ToDouble(Real_Payment_TBx.Text);
            double cal_payment = string.IsNullOrEmpty(Cal_Period_Payment_TBx.Text) ? 0 : Convert.ToDouble(Cal_Period_Payment_TBx.Text);
            double total_payment_left = string.IsNullOrEmpty(Total_payment_left_TBx.Text) ? 0 : Convert.ToDouble(Total_payment_left_TBx.Text);
            double period_fine = string.IsNullOrEmpty(Total_payment_fine_TBx.Text) ? 0 : Convert.ToDouble(Total_payment_fine_TBx.Text);
            double real_payment_fine = string.IsNullOrEmpty(Real_Payment_Fine_TBx.Text) ? 0 : Convert.ToDouble(Real_Payment_Fine_TBx.Text);
            double discount = string.IsNullOrEmpty(Discount_TBx.Text) ? 0 : Convert.ToDouble(Discount_TBx.Text);
            double real_discount = string.IsNullOrEmpty(Real_Discount_TBx.Text) ? 0 : Convert.ToDouble(Real_Discount_TBx.Text);
            double sum_payment_left = total_payment_left;

            cls_pay.Leasing_id = leasing_id;
            cls_pay.Period_fee = string.IsNullOrEmpty(Period_free_TBx.Text) ? 0.00 : Convert.ToDouble(Period_free_TBx.Text);
            cls_pay.Period_track = string.IsNullOrEmpty(Period_track_TBx.Text) ? 0.00 : Convert.ToDouble(Period_track_TBx.Text);
            cls_pay.Total_payment_fine = Convert.ToDouble(Real_Payment_Fine_TBx.Text);
            cls_pay.Discount = Convert.ToDouble(Real_Discount_TBx.Text);
            cls_pay.Real_payment = Convert.ToDouble(Real_Payment_TBx.Text);
            cls_pay.Real_payment_date = string.IsNullOrEmpty(Payment_Date_TBx.Text) ? DateTimeUtility._dateNOWForServer() : DateTimeUtility.convertDateToMYSQL(Payment_Date_TBx.Text);
            cls_pay.Bill_no_manual_ref = string.IsNullOrEmpty(Bill_No_Manual_Ref_TBx.Text) ? "" : Bill_No_Manual_Ref_TBx.Text;

            Base_Companys package_login = new Base_Companys();
            Account_Login acc_lgn = new Account_Login();

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            cls_pay.acc_lgn = new Account_Login();
            cls_pay.acc_lgn.Account_id = acc_lgn.Account_id;

            cls_pay.bs_cpn = new Base_Companys();
            cls_pay.bs_cpn.Company_id = package_login.Company_id;

            bool past_page = false;

            if (Cal_Status_Lbl.Visible == false) /* กรณีจ่าค่างวดแบบธรรมดา */
            {
                if (real_payment >= sum_payment_left)
                {
                    if (real_payment <= 0)
                    {
                        Note_Lbl.Text = "*** ระบุยอดชำระมากกว่า : 0.00 บาท ***";

                        Real_Payment_TBx.Focus();
                    }
                    /*else if (period_fine > 0 && real_payment_fine != period_fine)
                    {
                        Note_Lbl.Text = "*** มียอดค่าปรับค้างชำระจำนวน :  " + period_fine.ToString("#,###.00") + " บาท ***";

                        Real_Payment_Fine_TBx.Focus();
                    }
                    else if (period_fine == 0 && real_payment_fine != period_fine)
                    {
                        Note_Lbl.Text = "*** ไม่มียอดค่าปรับค้างชำระกรุณาใส่ 0 ในช่องชำระค่าปรับ ***";

                        Real_Payment_Fine_TBx.Focus();
                    }*/
                    else if (discount == 0 && real_discount != 0)
                    {
                        Note_Lbl.Text = "*** ไม่มียอดส่วนลดกรุณาใส่ 0 ในช่องส่วนลด ***";

                        Real_Payment_Fine_TBx.Focus();
                    }
                    else if (real_payment > sum_payment_left)
                    {
                        Note_Lbl.Text = "*** ยอดปิดบัญชีจำนวน : " + sum_payment_left.ToString("#,###.00") + " บาท ***";
                    }
                    else
                    {
                        Note_Lbl.Text = "";

                        if (!string.IsNullOrEmpty(Bill_No_Manual_Ref_TBx.Text))
                        {
                            past_page = cls_pay_mng.addPayment_Mod_III(cls_pay, 1);
                        }
                        else
                        {
                            past_page = cls_pay_mng.addPayment(cls_pay, 1);
                        }

                        if (past_page)
                        {
                            /// Acticity Logs System
                            ///  

                            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " บันทึกข้อมูลการจ่ายเงิน ในสัญญา : " + cls.Leasing_no + " เลขที่ฝาก : " + cls.Deps_no + " จำนวนเงิน [ค่างวด] [ค่าปรับ] [ส่วนลด] : [" + real_payment + "] [" + period_fine + "] [" + real_discount + "] ", acc_lgn.resu, package_login.Company_N_name);

                            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                            /// Acticity Logs System

                            _clearRealPayment();
                        }
                        else
                        {
                            Alert_Danger_Panel.Visible = true;
                            alert_header_danger_Lbl.Text = "แจ้งเตือน!!";
                            alert_danger_Lbl.Text = "กรุณาตรวจสอบ ข้อมูลอีกครั้ง";

                            Alert_Danger_Panel.Focus();
                        }
                    }
                }
                else
                {
                    if (real_payment <= 0)
                    {
                        Note_Lbl.Text = "*** ระบุยอดชำระมากกว่า : 0.00 บาท ***";

                        Real_Payment_TBx.Focus();
                    }
                    /*else if (period_fine > 0 && real_payment_fine > period_fine)
                    {
                        Note_Lbl.Text = "*** มียอดค่าปรับค้างชำระจำนวน :  " + period_fine.ToString("#,###.00") + " บาท ***";

                        Real_Payment_Fine_TBx.Focus();
                    }
                    else if (period_fine == 0 && real_payment_fine != period_fine)
                    {
                        Note_Lbl.Text = "*** ไม่มียอดค่าปรับค้างชำระกรุณาใส่ 0 ในช่องชำระค่าปรับ ***";

                        Real_Payment_Fine_TBx.Focus();
                    }*/
                    else if (discount == 0 && real_discount != 0)
                    {
                        Note_Lbl.Text = "*** ไม่มียอดส่วนลดกรุณาใส่ 0 ในช่องส่วนลด ***";

                        Real_Payment_Fine_TBx.Focus();
                    }
                    else
                    {
                        Note_Lbl.Text = "";

                        if (!string.IsNullOrEmpty(Bill_No_Manual_Ref_TBx.Text))
                        {
                            past_page = cls_pay_mng.addPayment_Mod_III(cls_pay, 1);
                        }
                        else
                        {
                            past_page = cls_pay_mng.addPayment(cls_pay, 1);
                        }

                        if (past_page)
                        {
                            /// Acticity Logs System
                            ///  

                            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " บันทึกข้อมูลการจ่ายเงิน ในสัญญา : " + cls.Leasing_no + " เลขที่ฝาก : " + cls.Deps_no + " จำนวนเงิน [ค่างวด] [ค่าปรับ] [ส่วนลด] : [" + real_payment + "] [" + period_fine + "] [" + real_discount + "] ", acc_lgn.resu, package_login.Company_N_name);

                            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                            /// Acticity Logs System

                            _clearRealPayment();
                        }
                        else
                        {
                            Alert_Danger_Panel.Visible = true;
                            alert_header_danger_Lbl.Text = "แจ้งเตือน!!";
                            alert_danger_Lbl.Text = "กรุณาตรวจสอบ ข้อมูลอีกครั้ง";

                            Alert_Danger_Panel.Focus();
                        }
                    }
                }

                _loadLeasingDetails(leasing_id, idcard);
            }
            else /* กรณีปิดบัญชี และมีส่วนลด */
            {
                if (real_payment != cal_payment)
                {
                    Note_Lbl.Text = "*** ไม่สามารถปิดบัญชีได้ เนื่องจาก ยอดชำระไม่ตรงกับที่ระบบคำนวนได้  " + cal_payment.ToString("#,###.00") + " บาท ***";
                }
                /*else if (period_fine > 0 && real_payment_fine != period_fine)
                {
                    Note_Lbl.Text = "*** มียอดค่าปรับค้างชำระจำนวน :  " + period_fine.ToString("#,###.00") + " บาท ***";

                    Real_Payment_Fine_TBx.Focus();
                }
                else if (period_fine == 0 && real_payment_fine != period_fine)
                {
                    Note_Lbl.Text = "*** ไม่มียอดค่าปรับค้างชำระกรุณาใส่ 0 ในช่องชำระค่าปรับ ***";

                    Real_Payment_Fine_TBx.Focus();
                }
                else if (discount == 0 && real_discount != discount)
                {
                    Note_Lbl.Text = "*** ไม่มียอดส่วนลดกรุณาใส่ 0 ในช่องส่วนลด ***";

                    Real_Payment_Fine_TBx.Focus();
                }
                else if (discount > 0 && real_discount != discount)
                {
                    Note_Lbl.Text = "*** กรุณมระบุยอดส่วนลดจำนวน :  " + discount.ToString("#,###.00") + " บาท ***";

                    Real_Discount_TBx.Focus();
                }*/
                else
                {
                    Note_Lbl.Text = "";

                    if (!string.IsNullOrEmpty(Bill_No_Manual_Ref_TBx.Text))
                    {
                        past_page = cls_pay_mng.addPayment_Mod_III(cls_pay, 2);
                    }
                    else
                    {
                        past_page = cls_pay_mng.addPayment(cls_pay, 2);
                    }

                    if (past_page)
                    {

                        /// Acticity Logs System
                        ///  

                        string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " บันทึกข้อมูลการจ่ายเงินแบบคำนวนการปิดบัญชี ในสัญญา : " + cls.Leasing_no + " เลขที่ฝาก : " + cls.Deps_no + " จำนวนเงิน [ค่างวด] [ค่าปรับ] [ส่วนลด] : [" + real_payment + "] [" + period_fine + "] [" + real_discount + "] ", acc_lgn.resu, package_login.Company_N_name);

                        new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                        /// Acticity Logs System

                        _clearRealPayment();

                        _loadLeasingDetails(leasing_id, idcard);
                    }
                    else
                    {
                        Alert_Danger_Panel.Visible = true;
                        alert_header_danger_Lbl.Text = "แจ้งเตือน!!";
                        alert_danger_Lbl.Text = "กรุณาตรวจสอบ ข้อมูลอีกครั้ง";

                        Alert_Danger_Panel.Focus();
                    }
                }
            }
        }

        private void _clearRealPayment()
        {
            Real_Payment_TBx.Text = "";
            Real_Discount_TBx.Text = "";
            Real_Payment_Fine_TBx.Text = "";
            Bill_No_Manual_Ref_TBx.Text = "";
        }
    }
}