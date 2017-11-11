using System;
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

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Edit_Payment : Page
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
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (acc_lgn.acc_lv.level_access < 7)
            {
                Save_Btn.Visible = false;
            }

            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string leasing_id = code[1];
                    string bill_no = code[2];
                    string idcard = (string)Session["ctm_leasing_payment"];

                    if (Request.Params["mode"] == "e")
                    {
                        Close_Leasing_Lbl.Visible = false;

                        _loadLeasingDetails(leasing_id, idcard, bill_no);
                    }
                    else if(Request.Params["mode"] == "r")
                    {
                        Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

                        cls_pay_mng.removePayment(leasing_id, bill_no);

                        /// Acticity Logs System
                        ///  

                        package_login = (Base_Companys)Session["Package"];
                        acc_lgn = (Account_Login)Session["Login"];

                        string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ลบข้อมูลการจ่ายเงืน เลขที่ใบเสร็จ : " + bill_no, acc_lgn.resu, package_login.Company_N_name);

                        new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                        /// Acticity Logs System

                        string ogn_code = CryptographyCode.GenerateSHA512String(leasing_id);

                        Response.Redirect("/Form_Leasings/Leasing_Payment?code=" + CryptographyCode.EncodeTOAddressBar(ogn_code, leasing_id, idcard));
                    }
                }
            }
        }

        private void _loadLeasingDetails(string leasing_id, string idcard, string bill_no)
        {
            cls = cls_mng.getCarLeasingById(leasing_id);

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

            Bill_No_TBx.Text = bill_no;
            
            Period_fee_TBx.Text = "0.00";
            Period_track_TBx.Text = "0.00";

            List<Car_Leasings_Payment> list_cls_pay = cls_pay_mng.getRealPaymentInfo(leasing_id);

            double total_payment_left = 0.00;
            double total_payment_fine = 0.00;

            double total_fee = 0.00;
            double total_track = 0.00;
            double total_real_payment = 0.00;
            double total_rea_payment_fine = 0.00;
            double total_discount = 0.00;

            for (int i = 0; i < list_cls_pay.Count; i++)
            {
                Car_Leasings_Payment cls_pay = list_cls_pay[i];

                if (cls_pay.Bill_no == bill_no)
                {
                    Payment_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(cls_pay.Real_payment_date);

                    total_fee += cls_pay.Period_fee;
                    total_track += cls_pay.Period_track;
                    total_real_payment += cls_pay.Real_payment;
                    total_rea_payment_fine += cls_pay.Real_payment_fine;
                    total_discount += cls_pay.Discount;

                    total_payment_left = cls_pay.Total_payment_left;
                    total_payment_fine = cls_pay.Total_payment_fine;

                    Bill_No_Manual_Ref_TBx.Text = cls_pay.Bill_no_manual_ref;

                    Session["old_company"] = cls_pay.bs_cpn.Company_id;
                }
            }

            Total_payment_left_TBx.Text = total_payment_left.ToString("#,###.00");
            Total_payment_fine_TBx.Text = total_payment_fine.ToString("#,###.00");

            Old_Period_fee_TBx.Text = total_fee.ToString("#,###.00");
            Old_Period_track_TBx.Text = total_track.ToString("#,###.00");
            Old_Real_Payment_TBx.Text = total_real_payment.ToString("#,###.00");
            Old_Real_Payment_Fine_TBx.Text = total_rea_payment_fine.ToString("#,###.00");
            Old_Real_Discount_TBx.Text = total_discount.ToString("#,###.00");

            Session["list_cls_pay"] = list_cls_pay;

            Real_Payment_TBx.Focus();
        }

        protected void Back_Before_Page_Btn_Click(object sender, EventArgs e)
        {
            string[] code = Request.Params["code"].Split('U');
            string leasing_id = code[1];
            string bill_no = code[2];
            string idcard = (string)Session["ctm_leasing_payment"];

            string ogn_code = CryptographyCode.GenerateSHA512String(leasing_id);

            Response.Redirect("/Form_Leasings/Leasing_Payment?code=" + CryptographyCode.EncodeTOAddressBar(ogn_code, leasing_id, idcard));
        }

        private void _clearRealPayment()
        {
            Real_Payment_TBx.Text = "";
            Real_Discount_TBx.Text = "";
            Real_Payment_Fine_TBx.Text = "";
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string[] code = Request.Params["code"].Split('U');
            string leasing_id = code[1];
            string bill_no = code[2];
            string idcard = (string)Session["ctm_leasing_payment"];

            double total_payment_left = string.IsNullOrEmpty(Total_payment_left_TBx.Text) ? 0 : Convert.ToDouble(Total_payment_left_TBx.Text);
            double period_fine = string.IsNullOrEmpty(Total_payment_fine_TBx.Text) ? 0 : Convert.ToDouble(Total_payment_fine_TBx.Text);

            double old_period_fee = string.IsNullOrEmpty(Old_Period_fee_TBx.Text) ? 0.00 : Convert.ToDouble(Old_Period_fee_TBx.Text);
            double old_period_track = string.IsNullOrEmpty(Old_Period_track_TBx.Text) ? 0.00 : Convert.ToDouble(Old_Period_track_TBx.Text);
            double old_payment = string.IsNullOrEmpty(Old_Real_Payment_TBx.Text) ? 0 : Convert.ToDouble(Old_Real_Payment_TBx.Text);
            double old_payment_fine = string.IsNullOrEmpty(Old_Real_Payment_Fine_TBx.Text) ? 0 : Convert.ToDouble(Old_Real_Payment_Fine_TBx.Text);
            double old_discount = string.IsNullOrEmpty(Old_Real_Discount_TBx.Text) ? 0 : Convert.ToDouble(Old_Real_Discount_TBx.Text);

            double real_period_fee = string.IsNullOrEmpty(Period_fee_TBx.Text) ? 0.00 : Convert.ToDouble(Period_fee_TBx.Text);
            double real_period_track = string.IsNullOrEmpty(Period_track_TBx.Text) ? 0.00 : Convert.ToDouble(Period_track_TBx.Text);
            double real_payment = string.IsNullOrEmpty(Real_Payment_TBx.Text) ? 0 : Convert.ToDouble(Real_Payment_TBx.Text);
            double real_payment_fine = string.IsNullOrEmpty(Real_Payment_Fine_TBx.Text) ? 0 : Convert.ToDouble(Real_Payment_Fine_TBx.Text);
            double real_discount = string.IsNullOrEmpty(Real_Discount_TBx.Text) ? 0 : Convert.ToDouble(Real_Discount_TBx.Text);

            cls_pay.Leasing_id = leasing_id;
            cls_pay.Period_fee = real_period_fee;
            cls_pay.Period_track = real_period_track;
            cls_pay.Total_payment_fine = real_payment_fine;
            cls_pay.Discount = real_discount;
            cls_pay.Real_payment = real_payment;
            cls_pay.Real_payment_date = string.IsNullOrEmpty(Payment_Date_TBx.Text) ? DateTimeUtility._dateNOWForServer() : DateTimeUtility.convertDateToMYSQL(Payment_Date_TBx.Text);
            cls_pay.Bill_no_manual_ref = string.IsNullOrEmpty(Bill_No_Manual_Ref_TBx.Text) ? "" : Bill_No_Manual_Ref_TBx.Text;

            Base_Companys package_login = new Base_Companys();
            Account_Login acc_lgn = new Account_Login();

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            cls_pay.acc_lgn = new Account_Login();
            cls_pay.acc_lgn.Account_id = acc_lgn.Account_id;

            cls_pay.bs_cpn = new Base_Companys();
            cls_pay.bs_cpn.Company_id = (int)Session["old_company"];

            if(total_payment_left == 0)
            {
                if(real_payment <= 0)
                {
                    Note_Lbl.Text = "*** ระบุยอดชำระมากกว่า : 0.00 บาท ***";

                    Real_Payment_TBx.Focus();
                }
                else if(real_payment > old_payment)
                {
                    Note_Lbl.Text = "*** ยอดชำระเกินกว่ายอดเดิม :  " + old_payment.ToString("#,###.00") + " บาท ***";

                    Real_Payment_TBx.Focus();
                }
               /* else if (period_fine == 0 && old_payment_fine != 0)
                {
                    Note_Lbl.Text = "*** ระบุยอดชำระค่าปรับ :  " + old_payment_fine.ToString("#,###.00") + " บาท ***";

                    Real_Payment_Fine_TBx.Focus();
                }*/
                else if (old_discount != 0)
                {
                    Note_Lbl.Text = "*** ระบุยอดส่วนลด :  " + old_discount.ToString("#,###.00") + " บาท ***";

                    Real_Discount_TBx.Focus();
                }
                else
                {
                    Note_Lbl.Text = "";

                    cls_pay_mng.editPayment(cls_pay, bill_no);

                    /// Acticity Logs System
                    ///  

                    package_login = (Base_Companys)Session["Package"];
                    acc_lgn = (Account_Login)Session["Login"];

                    string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลการจ่ายเงืน ในสัญญา : " + cls.Leasing_no + " เลขที่ฝาก : " + cls.Deps_no + " เลขที่ใบเสร็จ : " + bill_no + " จำนวนเงิน [ค่างวด] [ค่าปรับ] [ส่วนลด] : [" + real_payment +"] ["+ period_fine+"] ["+ real_discount+"] ", acc_lgn.resu, package_login.Company_N_name);

                    new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                    /// Acticity Logs System

                    string ogn_code = CryptographyCode.GenerateSHA512String(leasing_id);

                    Session.Remove("old_company");

                    Response.Redirect("/Form_Leasings/Leasing_Payment?code=" + CryptographyCode.EncodeTOAddressBar(ogn_code, leasing_id, idcard));
                }
            }
            else
            {
                if (real_payment <= 0)
                {
                    Note_Lbl.Text = "*** ระบุยอดชำระมากกว่า : 0.00 บาท ***";

                    Real_Payment_TBx.Focus();
                }
                /*else if(real_payment > total_payment_left && real_payment > 0)
                {
                    Note_Lbl.Text = "*** ยอดชำระเกินกว่ายอดคงค้าง :  " + total_payment_left.ToString("#,###.00") + " บาท ***";

                    Real_Payment_TBx.Focus();
                }*/
                else if (old_discount == 0 && real_discount != 0)
                {
                    Note_Lbl.Text = "*** ไม่มียอดส่วนลดกรุณาใส่ 0 ในช่องส่วนลด ***";

                    Real_Discount_TBx.Focus();
                }
                else
                {
                    Note_Lbl.Text = "";

                    cls_pay_mng.editPayment(cls_pay, bill_no);

                    /// Acticity Logs System
                    ///  

                    package_login = (Base_Companys)Session["Package"];
                    acc_lgn = (Account_Login)Session["Login"];

                    string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลการจ่ายเงืน ในสัญญา : " + cls.Leasing_no + " เลขที่ฝาก : " + cls.Deps_no + " เลขที่ใบเสร็จ : " + bill_no + " จำนวนเงิน [ค่างวด] [ค่าปรับ] [ส่วนลด] : [" + real_payment + "] [" + period_fine + "] [" + real_discount + "] ", acc_lgn.resu, package_login.Company_N_name);

                    new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                    /// Acticity Logs System

                    string ogn_code = CryptographyCode.GenerateSHA512String(leasing_id);

                    Session.Remove("old_company");

                    Response.Redirect("/Form_Leasings/Leasing_Payment?code=" + CryptographyCode.EncodeTOAddressBar(ogn_code, leasing_id, idcard));
                }
            }
        }
    }
}