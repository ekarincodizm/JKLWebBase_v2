using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Managers_Agents;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Account
{
    public partial class Load_Data_From_MSSQL : Page
    {
        private string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void link_load_customers_Click(object sender, EventArgs e)
        {
            _loadcustomers();
        }

        protected void link_load_leasings_no_customer_Click(object sender, EventArgs e)
        {
            _loadLeasing_no_customer();
        }

        protected void link_load_leasings_Click(object sender, EventArgs e)
        {
            _loadLeasings();
        }

        protected void link_load_paymnet_Click(object sender, EventArgs e)
        {
            _loadPaymentLeasing();
        }

        protected void link_load_guarantor_1_Click(object sender, EventArgs e)
        {
            _loadGuarantor_1();
        }

        protected void link_load_guarantor_2_Click(object sender, EventArgs e)
        {
            _loadGuarantor_2();
        }

        protected void link_load_guarantor_3_Click(object sender, EventArgs e)
        {
            _loadGuarantor_3();
        }

        private void _loadcustomers()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "SELECT * FROM v_get_customer_all ";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Customers_Manager ctm_mng = new Customers_Manager();

                while (reader.Read())
                {
                    Customers ctm = new Customers();

                    int defaultNum = 0;
                    string defaultString = "";

                    ctm.Cust_id = ctm_mng.generateCustomerID();
                    ctm.Cust_Idcard = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    ctm.Cust_Fname = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    ctm.Cust_LName = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    ctm.Cust_Age = reader.IsDBNull(3) ? defaultNum : reader.GetString(3) == "" ? defaultNum : Convert.ToInt32(reader.GetString(3));
                    ctm.Cust_Idcard_without = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    ctm.Cust_Idcard_start = reader.IsDBNull(7) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(7).ToString());
                    ctm.Cust_Idcard_expire = reader.IsDBNull(8) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(8).ToString());

                    ctm.ctm_ntnlt = new Base_Nationalitys();
                    ctm.ctm_ntnlt.Nationality_id = 1;

                    ctm.ctm_org = new Base_Origins();
                    ctm.ctm_org.Origin_id = 1;

                    ctm.ctm_pstt = new Base_Person_Status();
                    ctm.ctm_pstt.person_status_id = reader.IsDBNull(9) ? defaultNum : reader.GetString(9) == "" ? defaultNum : Convert.ToInt32(reader.GetString(9)) > 5 ? 1 : Convert.ToInt32(reader.GetString(9));

                    ctm.ctm_marry_ntnlt = new Base_Nationalitys();

                    ctm.ctm_marry_org = new Base_Origins();

                    if (ctm.ctm_pstt.person_status_id == 2)
                    {
                        ctm.Cust_Marry_Fname = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                        ctm.Cust_Marry_Lname = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                        ctm.Cust_Marry_job = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                        ctm.Cust_Marry_job_position = reader.IsDBNull(13) ? defaultString : reader.GetString(13);

                        ctm.ctm_marry_ntnlt.Nationality_id = 1;

                        ctm.ctm_marry_org.Origin_id = 1;
                    }

                    ctm.ctm_marry_pv = new TH_Provinces();

                    ctm.ctm_marry_job_pv = new TH_Provinces();

                    ctm.Cust_Job = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    ctm.Cust_Job_position = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    ctm.Cust_Job_local_name = reader.IsDBNull(35) ? defaultString : reader.GetString(35);
                    ctm.Cust_Job_address_no = reader.IsDBNull(36) ? defaultString : reader.GetString(36);

                    ctm.Cust_Job_vilage_no = reader.IsDBNull(38) ? "ม.-" : "ม." + reader.GetString(38);
                    ctm.Cust_Job_alley = reader.IsDBNull(37) ? "ซ.-" : "ซ." + reader.GetString(37);
                    ctm.Cust_Job_road = reader.IsDBNull(39) ? "ถ.-" : "ถ." + reader.GetString(39);
                    ctm.Cust_Job_subdistrict = reader.IsDBNull(40) ? "ต.-" : "ต." + reader.GetString(40);
                    ctm.Cust_Job_district = reader.IsDBNull(41) ? "อ.-" : "อ." + reader.GetString(41);

                    ctm.ctm_job_pv = new TH_Provinces();
                    ctm.ctm_job_pv.Province_id = reader.IsDBNull(42) ? defaultNum : new TH_Provinces_Manager().getProvinceByName(reader.GetString(42)).Province_id;

                    ctm.Cust_Job_country = "ประเทศไทย";
                    ctm.Cust_Job_zipcode = reader.IsDBNull(46) ? defaultString : reader.GetString(46);
                    ctm.Cust_Job_tel = reader.IsDBNull(43) ? defaultString : reader.GetString(43);

                    ctm.Cust_Home_address_no = reader.IsDBNull(51) ? defaultString : reader.GetString(51);
                    ctm.Cust_Home_vilage = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    ctm.Cust_Home_vilage_no = reader.IsDBNull(53) ? "ม.-" : "ม." + reader.GetString(53);
                    ctm.Cust_Home_alley = reader.IsDBNull(52) ? "ซ.-" : "ซ." + reader.GetString(52);
                    ctm.Cust_Home_road = reader.IsDBNull(54) ? "ถ.-" : "ถ." + reader.GetString(54);
                    ctm.Cust_Home_subdistrict = reader.IsDBNull(55) ? "ต.-" : "ต." + reader.GetString(55);
                    ctm.Cust_Home_district = reader.IsDBNull(56) ? "อ.-" : "อ." + reader.GetString(56);

                    ctm.ctm_home_pv = new TH_Provinces();
                    ctm.ctm_home_pv.Province_id = reader.IsDBNull(57) ? defaultNum : new TH_Provinces_Manager().getProvinceByName(reader.GetString(57)).Province_id;

                    ctm.Cust_Home_country = "ประเทศไทย";
                    ctm.Cust_Home_zipcode = reader.IsDBNull(61) ? defaultString : reader.GetString(61);
                    ctm.Cust_Home_tel = reader.IsDBNull(58) ? defaultString : reader.GetString(58);

                    ctm.ctm_home_stt = new Base_Home_Status();
                    ctm.ctm_home_stt.Home_status_id = reader.IsDBNull(60) ? defaultNum : reader.GetString(60) == "4" ? 3 : reader.GetString(60) == "3'" ? 2 : Convert.ToInt32(reader.GetString(60));

                    ctm.Cust_Idcard_address_no = reader.IsDBNull(66) ? defaultString : reader.GetString(66);
                    ctm.Cust_Idcard_vilage = reader.IsDBNull(77) ? defaultString : reader.GetString(77);
                    ctm.Cust_Idcard_vilage_no = reader.IsDBNull(68) ? "ม.-" : "ม." + reader.GetString(68);
                    ctm.Cust_Idcard_alley = reader.IsDBNull(67) ? "ซ.-" : "ซ." + reader.GetString(67);
                    ctm.Cust_Idcard_road = reader.IsDBNull(69) ? "ถ.-" : "ถ." + reader.GetString(69);
                    ctm.Cust_Idcard_subdistrict = reader.IsDBNull(70) ? "ต.-" : "ต." + reader.GetString(70);
                    ctm.Cust_Idcard_district = reader.IsDBNull(71) ? "อ.-" : "อ." + reader.GetString(71);

                    ctm.ctm_idcard_pv = new TH_Provinces();
                    ctm.ctm_idcard_pv.Province_id = reader.IsDBNull(72) ? defaultNum : new TH_Provinces_Manager().getProvinceByName(reader.GetString(72)).Province_id;

                    ctm.Cust_Idcard_country = "ประเทศไทย";
                    ctm.Cust_Idcard_zipcode = reader.IsDBNull(76) ? defaultString : reader.GetString(76);
                    ctm.Cust_Idcard_tel = reader.IsDBNull(73) ? defaultString : reader.GetString(73);

                    ctm.ctm_idcard_stt = new Base_Home_Status();
                    ctm.ctm_idcard_stt.Home_status_id = reader.IsDBNull(75) ? defaultNum : reader.GetString(75) == "4" ? 3 : reader.GetString(75) == "3'" ? 2 : Convert.ToInt32(reader.GetString(75));

                    ctm.Cust_Current_address_no = reader.IsDBNull(81) ? defaultString : reader.GetString(81);
                    ctm.Cust_Current_vilage = reader.IsDBNull(92) ? defaultString : reader.GetString(92);
                    ctm.Cust_Current_vilage_no = reader.IsDBNull(83) ? "ม.-" : "ม." + reader.GetString(83);
                    ctm.Cust_Current_alley = reader.IsDBNull(82) ? "ซ.-" : "ซ." + reader.GetString(82);
                    ctm.Cust_Current_road = reader.IsDBNull(84) ? "ถ.-" : "ถ." + reader.GetString(84);
                    ctm.Cust_Current_subdistrict = reader.IsDBNull(85) ? "ต.-" : "ต." + reader.GetString(85);
                    ctm.Cust_Current_district = reader.IsDBNull(86) ? "อ.-" : "อ." + reader.GetString(86);

                    ctm.ctm_current_pv = new TH_Provinces();
                    ctm.ctm_current_pv.Province_id = reader.IsDBNull(87) ? defaultNum : new TH_Provinces_Manager().getProvinceByName(reader.GetString(87)).Province_id;

                    ctm.Cust_Current_country = "ประเทศไทย";
                    ctm.Cust_Current_zipcode = reader.IsDBNull(91) ? defaultString : reader.GetString(91);
                    ctm.Cust_Current_tel = reader.IsDBNull(88) ? defaultString : reader.GetString(88);

                    ctm.ctm_current_stt = new Base_Home_Status();
                    ctm.ctm_current_stt.Home_status_id = reader.IsDBNull(90) ? defaultNum : reader.GetString(90) == "4" ? 3 : reader.GetString(90) == "3'" ? 2 : Convert.ToInt32(reader.GetString(90));


                    if (row_index % 5000 == 0) { part++;  }

                    Messages_Logs._writeSQLCodeInsertCustomerToMYSQL(ctm, part);

                    Messages_TBx.Text += "Transfer Data Cusotmer Passed : " + row_index + Environment.NewLine;

                    row_index++;

                    /*if (ctm_mng.addCustomers(ctm))
                    {
                        Messages_TBx.Text += "Transfer Data Cusotmer Passed : " + row_index + Environment.NewLine;

                        row_index++;
                    }
                    else
                    {
                        break;
                    }*/
                }
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadcustomers() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Cusotmer Failed SqlException : " + row_index + " : " + ex + Environment.NewLine;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadcustomers() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Cusotmer Failed Exception : " + row_index + " : " + ex + Environment.NewLine;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void _loadLeasing_no_customer()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "SELECT * FROM v_get_leasing_no_customers";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();

                while (reader.Read())
                {

                    int defaultNum = 0;
                    string defaultString = "";

                    Car_Leasings cls = new Car_Leasings();

                    cls = cls_mng.getCarLeasingByDepsNo(reader.GetString(4), reader.GetString(5));

                    if (string.IsNullOrEmpty(cls.Leasing_id))
                    {
                        cls.Leasing_id = cls_mng.generateLeasingID();
                        cls.Deps_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                        cls.Leasing_no = reader.IsDBNull(5) ? defaultString : reader.GetString(5);

                        cls.bs_ls_code = new Base_Leasing_Code();
                        cls.bs_ls_code.Leasing_code_id = reader.IsDBNull(14) ? defaultNum : _getLeasingCode(reader.GetString(14));

                        cls.Leasing_date = reader.IsDBNull(6) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(6).ToString());

                        cls.bs_cpn = new Base_Companys();
                        cls.bs_cpn.Company_id = reader.IsDBNull(10) ? defaultNum : _getCompanys(reader.GetString(10));

                        cls.bs_zn = new Base_Zone_Service();
                        cls.bs_zn.Zone_id = reader.IsDBNull(13) ? defaultNum : _getZoneService(reader.GetString(13));

                        cls.bs_ct = new Base_Courts();
                        cls.bs_ct.Court_id = reader.IsDBNull(11) ? defaultNum : _getCourt(reader.GetString(11));

                        cls.PeReT = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                        cls.TotalPaymentTime = 1;

                        double require = reader.IsDBNull(15) ? 0 : Convert.ToDouble(reader.GetDecimal(15)); // ยอดจัด / เงินต้น
                        double interest_rate = reader.IsDBNull(17) ? 0 : Convert.ToDouble(reader.GetDecimal(17)); // อัตราดอกเบี้ย
                        double period = reader.IsDBNull(7) ? 0 : Convert.ToDouble(reader.GetInt16(7)); // ระยะเวลา / จำนวนงวด 
                        double vat_rate = 7; // อัตราภาษีมูลค่าเพิ่ม

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

                        cls.Total_require = require;
                        cls.Vat_rate = vat_rate;
                        cls.Interest_rate = interest_rate;
                        cls.Total_period = Convert.ToInt32(period);
                        cls.Total_sum = finance;
                        cls.Total_Interest = interate;
                        cls.Total_Tax = vat;
                        cls.Total_leasing = totalFinance;
                        cls.Total_Net_leasing = Total_Net_Leasing;
                        cls.Period_cal = payPerTime;
                        cls.Period_interst = Period_interst;
                        cls.Period_tax = taxpermonth;
                        cls.Period_pure = payPerTimeTotal;
                        cls.Period_payment = periodPayment;
                        cls.Period_require = Period_require;

                        cls.Total_period_left = Convert.ToInt32(period);
                        cls.Total_payment_left = Total_Net_Leasing;

                        cls.Payment_schedule = reader.IsDBNull(8) ? defaultNum : Convert.ToInt32(reader.GetString(8));
                        cls.First_payment_date = reader.IsDBNull(9) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(9).ToString());
                        cls.Car_register_date = reader.IsDBNull(36) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(36).ToString());
                        cls.Car_license_plate = reader.IsDBNull(30) ? null : reader.GetString(30);

                        cls.cls_plate_pv = new TH_Provinces();
                        cls.cls_plate_pv.Province_id = 39;

                        cls.Car_type = reader.IsDBNull(27) ? null : reader.GetString(27);

                        cls.bs_cbrn = new Base_Car_Brands();
                        cls.bs_cbrn.car_brand_id = reader.IsDBNull(26) ? defaultNum : _getCarBrand(reader.GetString(26));

                        cls.Car_year = reader.IsDBNull(34) ? defaultString : (Convert.ToInt32(reader.GetString(34)) - 543).ToString();
                        cls.Car_color = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                        cls.Car_engine_no = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                        cls.Car_chassis_no = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                        cls.Car_used_id = reader.IsDBNull(31) ? defaultNum : _getCarUsed(reader.GetString(31));
                        cls.Car_distance = 0;
                        cls.Car_next_register_date = reader.IsDBNull(35) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(35).ToString());
                        cls.Car_tax_value = reader.IsDBNull(37) ? defaultNum : Convert.ToDouble(reader.GetString(37) == "" ? "0" : reader.GetString(37));
                        cls.Car_credits = reader.IsDBNull(38) ? defaultString : reader.GetString(38);
                        cls.Car_agent = reader.IsDBNull(39) ? defaultString : reader.GetString(39);
                        cls.Car_old_owner = reader.IsDBNull(40) ? defaultString : reader.GetString(40);
                        cls.Car_old_owner_idcard = reader.IsDBNull(41) ? defaultString : reader.GetString(41);
                        cls.Car_old_owner_b_date = reader.IsDBNull(42) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(42).ToString());

                        cls.Car_old_owner_subdistrict = reader.IsDBNull(43) ? defaultString : reader.GetString(43);

                        cls.cls_owner_pv = new TH_Provinces();
                        cls.cls_owner_pv.Province_id = 39;

                        cls.Car_old_owner_contry = "ประเทศไทย";

                        cls.tent_car = new Base_Tents_Car();

                        cls.Cheque_receiver = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                        cls.Cheque_bank = reader.IsDBNull(48) ? defaultString : reader.GetString(48);
                        cls.Cheque_number = reader.IsDBNull(45) ? defaultString : reader.GetString(45);
                        cls.Cheque_sum = reader.IsDBNull(46) ? defaultNum : Convert.ToDouble(reader.GetDecimal(46));
                        cls.Cheque_receive_date = reader.IsDBNull(44) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(44).ToString());

                        cls.bs_ls_stt = new Base_Leasing_Status();
                        cls.bs_ls_stt.Contract_Status_id = 1;

                        cls_mng.addCarLeasings(cls);

                        Messages_TBx.Text += "Transfer Data Leasing No Customers Passed : " + row_index + Environment.NewLine;

                        row_index++;
                    }
                }
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadLeasing_no_customer() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Leasing No Customers Failed SqlException : " + row_index + " : " + ex + Environment.NewLine;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadLeasing_no_customer() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Leasing No Customers Failed Exception : " + row_index + " : " + ex + Environment.NewLine;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void _loadLeasings()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "SELECT * FROM v_get_leasings ";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Agents_Manager cag_mng = new Agents_Manager();
                Customers_Manager ctm_mng = new Customers_Manager();
                Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
                Car_Leasings_Customer_Manager cls_ctm_mng = new Car_Leasings_Customer_Manager();
                Car_Leasings_Guarantor_Manager cls_grt_mng = new Car_Leasings_Guarantor_Manager();

                while (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    Customers ctm = new Customers();

                    if (!reader.IsDBNull(0))
                    {

                        ctm = ctm_mng.getCustomersByIdCard(reader.GetString(0));

                        ctm.Cust_B_date = null;

                        ctm.Cust_Idcard_start = ctm.Cust_Idcard_start == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_start);
                        ctm.Cust_Idcard_expire = ctm.Cust_Idcard_expire == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_expire);
                    }

                    Car_Leasings cls = new Car_Leasings();

                    cls.Deps_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cls.Leasing_no = reader.IsDBNull(5) ? defaultString : reader.GetString(5);

                    Car_Leasings cls_dup = new Car_Leasings();

                    cls_mng.getCarLeasingByDepsNo(cls.Deps_no, cls.Leasing_no);

                    cls.Leasing_id = string.IsNullOrEmpty(cls_dup.Leasing_id) ? cls_mng.generateLeasingID() : cls_dup.Leasing_id;

                    cls.bs_ls_code = new Base_Leasing_Code();
                    cls.bs_ls_code.Leasing_code_id = reader.IsDBNull(14) ? defaultNum : _getLeasingCode(reader.GetString(14));

                    cls.Leasing_date = reader.IsDBNull(6) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(6).ToString());

                    cls.bs_cpn = new Base_Companys();
                    cls.bs_cpn.Company_id = reader.IsDBNull(10) ? defaultNum : _getCompanys(reader.GetString(10));

                    cls.bs_zn = new Base_Zone_Service();
                    cls.bs_zn.Zone_id = reader.IsDBNull(13) ? defaultNum : _getZoneService(reader.GetString(13));

                    cls.bs_ct = new Base_Courts();
                    cls.bs_ct.Court_id = reader.IsDBNull(11) ? defaultNum : _getCourt(reader.GetString(11));

                    cls.PeReT = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cls.TotalPaymentTime = 1;

                    double require = reader.IsDBNull(15) ? 0 : Convert.ToDouble(reader.GetDecimal(15)); // ยอดจัด / เงินต้น
                    double interest_rate = reader.IsDBNull(17) ? 0 : Convert.ToDouble(reader.GetDecimal(17)); // อัตราดอกเบี้ย
                    double period = reader.IsDBNull(7) ? 1 : Convert.ToDouble(reader.GetInt16(7)); // ระยะเวลา / จำนวนงวด 
                    double vat_rate = 7; // อัตราภาษีมูลค่าเพิ่ม

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

                    cls.Total_require = require;
                    cls.Vat_rate = vat_rate;
                    cls.Interest_rate = interest_rate;
                    cls.Total_period = Convert.ToInt32(period);
                    cls.Total_sum = finance;
                    cls.Total_Interest = interate;
                    cls.Total_Tax = vat;
                    cls.Total_leasing = totalFinance;
                    cls.Total_Net_leasing = Total_Net_Leasing;
                    cls.Period_cal = payPerTime;
                    cls.Period_interst = Period_interst;
                    cls.Period_tax = taxpermonth;
                    cls.Period_pure = payPerTimeTotal;
                    cls.Period_payment = periodPayment;
                    cls.Period_require = Period_require;

                    cls.Total_period_left = Convert.ToInt32(period);
                    cls.Total_payment_left = Total_Net_Leasing;

                    cls.Payment_schedule = reader.IsDBNull(8) ? defaultNum : Convert.ToInt32(reader.GetString(8));
                    cls.First_payment_date = reader.IsDBNull(9) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(9).ToString());
                    cls.Car_register_date = reader.IsDBNull(36) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(36).ToString());
                    cls.Car_license_plate = reader.IsDBNull(30) ? null : reader.GetString(30);

                    cls.cls_plate_pv = new TH_Provinces();
                    cls.cls_plate_pv.Province_id = 39;

                    cls.Car_type = reader.IsDBNull(27) ? null : reader.GetString(27);

                    cls.bs_cbrn = new Base_Car_Brands();
                    cls.bs_cbrn.car_brand_id = reader.IsDBNull(26) ? defaultNum : _getCarBrand(reader.GetString(26));

                    cls.Car_year = reader.IsDBNull(34) ? defaultString : (Convert.ToInt32(reader.GetString(34)) - 543).ToString();
                    cls.Car_color = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    cls.Car_engine_no = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    cls.Car_chassis_no = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    cls.Car_used_id = reader.IsDBNull(31) ? defaultNum : _getCarUsed(reader.GetString(31));
                    cls.Car_distance = 0;
                    cls.Car_next_register_date = reader.IsDBNull(35) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(35).ToString());
                    cls.Car_tax_value = reader.IsDBNull(37) ? defaultNum : Convert.ToDouble(reader.GetString(37) == "" || reader.GetString(37) == "-" ? "0" : reader.GetString(37));
                    cls.Car_credits = reader.IsDBNull(38) ? defaultString : reader.GetString(38);
                    cls.Car_agent = reader.IsDBNull(39) ? defaultString : reader.GetString(39);
                    cls.Car_old_owner = reader.IsDBNull(40) ? defaultString : reader.GetString(40);
                    cls.Car_old_owner_idcard = reader.IsDBNull(41) ? defaultString : reader.GetString(41);
                    cls.Car_old_owner_b_date = reader.IsDBNull(42) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(42).ToString());

                    cls.Car_old_owner_subdistrict = reader.IsDBNull(43) ? defaultString : reader.GetString(43);

                    cls.cls_owner_pv = new TH_Provinces();
                    cls.cls_owner_pv.Province_id = 39;

                    cls.Car_old_owner_contry = "ประเทศไทย";

                    cls.tent_car = new Base_Tents_Car();

                    cls.Cheque_receiver = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                    cls.Cheque_bank = reader.IsDBNull(48) ? defaultString : reader.GetString(48);
                    cls.Cheque_number = reader.IsDBNull(45) ? defaultString : reader.GetString(45);
                    cls.Cheque_sum = reader.IsDBNull(46) ? defaultNum : Convert.ToDouble(reader.GetDecimal(46));
                    cls.Cheque_receive_date = reader.IsDBNull(44) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(44).ToString());

                    cls.bs_ls_stt = new Base_Leasing_Status();
                    cls.bs_ls_stt.Contract_Status_id = 1;

                    /*if (string.IsNullOrEmpty(cls_dup.Leasing_id))
                    {
                        if (cls_mng.addCarLeasings(cls))
                        {

                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Leasing Add Failed SqlException : " + row_index + Environment.NewLine;
                        }
                    }
                    else
                    {
                        if (cls_mng.editCarLeasings(cls))
                        {

                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Leasing Edit Failed SqlException : " + row_index + Environment.NewLine;
                        }
                    }

                    cls_ctm_mng.addCustomersLeasing(cls, ctm);*/

                    if (row_index % 5000 == 0) { part++; }

                    Messages_Logs._writeSQLCodeInsertLeasingsToMYSQL(cls, part);

                    Messages_Logs._writeSQLCodeInsertCustomerLeasingsToMYSQL(cls, ctm, part);

                    if (reader.GetDecimal(49) > 0)
                    {
                        Agents_Commission cag_com = new Agents_Commission();

                        Agents cag = new Agents();

                        cag = cag_mng.getAgentByName(reader.GetString(50), reader.GetString(51), reader.GetString(52));

                        if (string.IsNullOrEmpty(cag.Agent_id))
                        {
                            cag = new Agents();

                            cag.Agent_id = cag_mng.generateAgentID();
                            cag.Agent_Idcard = reader.GetString(50);
                            cag.Agent_Fname = reader.GetString(51);
                            cag.Agent_Lname = reader.GetString(52);
                            cag.Agent_Subdistrict = reader.GetString(53);

                            cag.cag_pv = new TH_Provinces();
                            cag.cag_pv.Province_id = 39;

                            //cag_mng.addAgent(cag);

                            Messages_Logs._writeSQLCodeInsertAgentsToMYSQL(cag, part);
                        }

                        cag_com.cag = new Agents();
                        cag_com.cag = cag;

                        double commission = Convert.ToDouble(reader.GetDecimal(49)); ; // ค่านายหน้า
                        double loss_com = Math.Ceiling(commission * (3 / 100)); // ค่าหัก ณ ที่จ่าย

                        cag_com.Agent_commission = commission;
                        cag_com.Agent_percen = 3; // % หัก ณ ที่จ่าย
                        cag_com.Agent_cash = loss_com;
                        cag_com.Agent_net_com = (commission - loss_com);

                        cag_com.Leasing_id = cls.Leasing_id;

                        //cag_mng.addAgentCommission(cag_com);

                        Messages_Logs._writeSQLCodeInsertAgentsCommissionToMYSQL(cag_com, part);
                    }

                    Messages_TBx.Text += "Transfer Data Leasing Passed : " + row_index + Environment.NewLine;

                    row_index++;
                }
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadLeasings() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Leasing Failed SqlException : " + row_index + " : " + ex + Environment.NewLine;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadLeasings() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += " Transfer Data Leasing Failed Exception : " + row_index + " : " + ex + Environment.NewLine;

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void _loadPaymentLeasing()
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
            Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

            List<Car_Leasings> list_cls_all = cls_mng.getCarLeasing("", "", "", "", "", "", "", "", "", "", 0, 0);

            int part = 1;

            for (int i = 0; i < list_cls_all.Count; i++)
            {
                Car_Leasings cls = new Car_Leasings();

                cls = list_cls_all[i];

                int row_index = 1;

                SqlConnection con = MSSQLConnection.connectionMSSQL();

                try
                {
                    con.Open();

                    string sql = "SELECT * FROM v_get_payment WHERE cntNoTemp = '" + cls.Deps_no + "' ORDER BY scheduleno";

                    SqlCommand cmd = new SqlCommand(sql, con);
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
                        cls_pay.Real_payment_date = reader.IsDBNull(3) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(3).ToString());

                        cls_pay.acc_lgn = new Account_Login();

                        cls_pay.bs_cpn = new Base_Companys();
                        cls_pay.bs_cpn.Company_id = _getCompanys(reader.GetString(20));

                        if (i % 1000 == 0) { part++; }

                        if (cls_pay.Discount <= 0)
                        {
                            
                            Messages_Logs._writeSQLCodeInsertCarLeasingsPaymentToMYSQL(cls_pay, 1, part);

                            Messages_TBx.Text += "Transfer Data Payment 1 Passed : " + row_index + Environment.NewLine;

                            /*if (cls_pay_mng.addPayment_Mod_I(cls_pay, 1))
                            {
                                Messages_TBx.Text += "Transfer Data Payment 1 Passed : " + row_index + Environment.NewLine;

                                row_index++;
                            }
                            else
                            {
                                Messages_TBx.Text += "Transfer Data Payment 1 Failed : " + row_index + Environment.NewLine;
                            }*/
                        }
                        else
                        {
                            Messages_Logs._writeSQLCodeInsertCarLeasingsPaymentToMYSQL(cls_pay, 2, part);

                            Messages_TBx.Text += "Transfer Data Payment 2 Passed : " + row_index + Environment.NewLine;

                            /*if (cls_pay_mng.addPayment_Mod_I(cls_pay, 2))
                            {
                                Messages_TBx.Text += "Transfer Data Payment 2 Passed : " + row_index + Environment.NewLine;

                                row_index++;
                            }
                            else
                            {
                                Messages_TBx.Text += "Transfer Data Payment 2 Failed : " + row_index + Environment.NewLine;
                            }*/
                        }

                        row_index++;
                    }
                }
                catch (SqlException ex)
                {
                    error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadPaymentLeasing() ";
                    Log_Error._writeErrorFile(error, ex);

                    Messages_TBx.Text += "Transfer Data Payment Failed SqlException : " + i + " / " + row_index + " / " + list_cls_all.Count + " : " + ex + Environment.NewLine;

                    break;
                }
                catch (Exception ex)
                {
                    error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadPaymentLeasing() ";
                    Log_Error._writeErrorFile(error, ex);

                    Messages_TBx.Text += " Transfer Data Payment Failed Exception : " + i+ " / " + row_index + " / " + list_cls_all.Count + " : " + ex + Environment.NewLine;

                    break;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        private void _loadGuarantor_1()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "SELECT * FROM v_get_guarantor_1";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Agents_Manager cag_mng = new Agents_Manager();
                Customers_Manager ctm_mng = new Customers_Manager();
                Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
                Car_Leasings_Customer_Manager cls_ctm_mng = new Car_Leasings_Customer_Manager();
                Car_Leasings_Guarantor_Manager cls_grt_mng = new Car_Leasings_Guarantor_Manager();

                while (reader.Read())
                {

                    Customers ctm = new Customers();

                    if (!reader.IsDBNull(0))
                    {

                        ctm = ctm_mng.getCustomersByIdCard(reader.GetString(0));

                        ctm.Cust_B_date = null;

                        ctm.Cust_Idcard_start = ctm.Cust_Idcard_start == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_start);
                        ctm.Cust_Idcard_expire = ctm.Cust_Idcard_expire == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_expire);
                    }

                    Car_Leasings cls = new Car_Leasings();

                    cls = cls_mng.getCarLeasingByDepsNo(reader.GetString(4), reader.GetString(5));

                    cls.Leasing_date = cls.Leasing_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Leasing_date);
                    cls.First_payment_date = cls.First_payment_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.First_payment_date);
                    cls.Car_register_date = cls.Car_register_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_register_date);
                    cls.Car_next_register_date = cls.Car_next_register_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_next_register_date);
                    cls.Car_old_owner_b_date = cls.Car_old_owner_b_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_old_owner_b_date);
                    cls.Cheque_receive_date = cls.Cheque_receive_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Cheque_receive_date);

                    Car_Leasings_Guarator cls_grt = new Car_Leasings_Guarator();

                    cls_grt.cls = new Car_Leasings();
                    cls_grt.cls = cls;

                    cls_grt.ctm = new Customers();
                    cls_grt.ctm = ctm;

                    cls_grt.Guarantor_no = 1;

                    if (row_index % 5000 == 0) { part++; }

                    Messages_Logs._writeSQLCodeInsertGuarantorLeasingsToMYSQL(cls_grt, part);

                    Messages_TBx.Text += "Transfer Data Guarantor 1 Passed : " + row_index + Environment.NewLine;

                    row_index++;

                    /*if (cls_grt_mng.checkDuplicateGuarantor(cls.Leasing_id, ctm.Cust_id, ctm.Cust_Idcard))
                    {
                        if (cls_grt_mng.editGuarantorsLeasing(cls_grt))
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 1 Edit Passed : " + row_index + Environment.NewLine;

                            row_index++;
                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 1 Edit Failed : " + row_index + Environment.NewLine;

                            break;
                        }
                    }
                    else
                    {

                        if (cls_grt_mng.addGuarantorsLeasing(cls_grt))
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 1 Add Passed : " + row_index + Environment.NewLine;

                            row_index++;
                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 1 Edit Failed : " + row_index + Environment.NewLine;

                            break;
                        }
                    }*/
                }
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_1() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor 1 Failed SqlException : " + row_index + " : " + ex + Environment.NewLine;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_1() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor 1 Failed Exception : " + row_index + " : " + ex + Environment.NewLine;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void _loadGuarantor_2()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "SELECT * FROM v_get_guarantor_2";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Agents_Manager cag_mng = new Agents_Manager();
                Customers_Manager ctm_mng = new Customers_Manager();
                Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
                Car_Leasings_Customer_Manager cls_ctm_mng = new Car_Leasings_Customer_Manager();
                Car_Leasings_Guarantor_Manager cls_grt_mng = new Car_Leasings_Guarantor_Manager();

                while (reader.Read())
                {

                    Customers ctm = new Customers();

                    if (!reader.IsDBNull(0))
                    {

                        ctm = ctm_mng.getCustomersByIdCard(reader.GetString(0));

                        ctm.Cust_B_date = null;

                        ctm.Cust_Idcard_start = ctm.Cust_Idcard_start == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_start);
                        ctm.Cust_Idcard_expire = ctm.Cust_Idcard_expire == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_expire);
                    }

                    Car_Leasings cls = new Car_Leasings();

                    cls = cls_mng.getCarLeasingByDepsNo(reader.GetString(4), reader.GetString(5));

                    cls.Leasing_date = cls.Leasing_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Leasing_date);
                    cls.First_payment_date = cls.First_payment_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.First_payment_date);
                    cls.Car_register_date = cls.Car_register_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_register_date);
                    cls.Car_next_register_date = cls.Car_next_register_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_next_register_date);
                    cls.Car_old_owner_b_date = cls.Car_old_owner_b_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_old_owner_b_date);
                    cls.Cheque_receive_date = cls.Cheque_receive_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Cheque_receive_date);

                    Car_Leasings_Guarator cls_grt = new Car_Leasings_Guarator();

                    cls_grt.cls = new Car_Leasings();
                    cls_grt.cls = cls;

                    cls_grt.ctm = new Customers();
                    cls_grt.ctm = ctm;

                    cls_grt.Guarantor_no = 2;

                    if (row_index % 5000 == 0) { part++; }

                    Messages_Logs._writeSQLCodeInsertGuarantorLeasingsToMYSQL(cls_grt, part);

                    Messages_TBx.Text += "Transfer Data Guarantor 2 Passed : " + row_index + Environment.NewLine;

                    row_index++;

                    /*if (cls_grt_mng.checkDuplicateGuarantor(cls.Leasing_id, ctm.Cust_id, ctm.Cust_Idcard))
                    {
                        if (cls_grt_mng.editGuarantorsLeasing(cls_grt))
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 2 Edit Passed : " + row_index + Environment.NewLine;

                            row_index++;
                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 2 Edit Failed : " + row_index + Environment.NewLine;

                            break;
                        }
                    }
                    else
                    {

                        if (cls_grt_mng.addGuarantorsLeasing(cls_grt))
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 2 Add Passed : " + row_index + Environment.NewLine;

                            row_index++;
                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 2 Edit Failed : " + row_index + Environment.NewLine;

                            break;
                        }
                    }*/
                }
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_2() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor 2 Failed SqlException : " + row_index + " : " + ex + Environment.NewLine;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_2() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor 2 Failed Exception : " + row_index + " : " + ex + Environment.NewLine;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void _loadGuarantor_3()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "SELECT * FROM v_get_guarantor_3";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Agents_Manager cag_mng = new Agents_Manager();
                Customers_Manager ctm_mng = new Customers_Manager();
                Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
                Car_Leasings_Customer_Manager cls_ctm_mng = new Car_Leasings_Customer_Manager();
                Car_Leasings_Guarantor_Manager cls_grt_mng = new Car_Leasings_Guarantor_Manager();

                while (reader.Read())
                {

                    Customers ctm = new Customers();

                    if (!reader.IsDBNull(0))
                    {

                        ctm = ctm_mng.getCustomersByIdCard(reader.GetString(0));

                        ctm.Cust_B_date = null;

                        ctm.Cust_Idcard_start = ctm.Cust_Idcard_start == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_start);
                        ctm.Cust_Idcard_expire = ctm.Cust_Idcard_expire == "" ? null : DateTimeUtility.convertDateToMYSQL(ctm.Cust_Idcard_expire);
                    }

                    Car_Leasings cls = new Car_Leasings();

                    cls = cls_mng.getCarLeasingByDepsNo(reader.GetString(4), reader.GetString(5));

                    cls.Leasing_date = cls.Leasing_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Leasing_date);
                    cls.First_payment_date = cls.First_payment_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.First_payment_date);
                    cls.Car_register_date = cls.Car_register_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_register_date);
                    cls.Car_next_register_date = cls.Car_next_register_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_next_register_date);
                    cls.Car_old_owner_b_date = cls.Car_old_owner_b_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Car_old_owner_b_date);
                    cls.Cheque_receive_date = cls.Cheque_receive_date == "" ? null : DateTimeUtility.convertDateToMYSQL(cls.Cheque_receive_date);

                    Car_Leasings_Guarator cls_grt = new Car_Leasings_Guarator();

                    cls_grt.cls = new Car_Leasings();
                    cls_grt.cls = cls;

                    cls_grt.ctm = new Customers();
                    cls_grt.ctm = ctm;

                    cls_grt.Guarantor_no = 3;

                    if (row_index % 5000 == 0) { part++; }

                    Messages_Logs._writeSQLCodeInsertGuarantorLeasingsToMYSQL(cls_grt, part);

                    Messages_TBx.Text += "Transfer Data Guarantor 3 Passed : " + row_index + Environment.NewLine;

                    row_index++;

                    /*if (cls_grt_mng.checkDuplicateGuarantor(cls.Leasing_id, ctm.Cust_id, ctm.Cust_Idcard))
                    {
                        if (cls_grt_mng.editGuarantorsLeasing(cls_grt))
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 3 Edit Passed : " + row_index + Environment.NewLine;

                            row_index++;
                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 3 Edit Failed : " + row_index + Environment.NewLine;

                            break;
                        }
                    }
                    else
                    {

                        if (cls_grt_mng.addGuarantorsLeasing(cls_grt))
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 3 Add Passed : " + row_index + Environment.NewLine;

                            row_index++;
                        }
                        else
                        {
                            Messages_TBx.Text += "Transfer Data Guarantor 3 Edit Failed : " + row_index + Environment.NewLine;

                            break;
                        }
                    }*/
                }
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_3() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor 3 Failed SqlException : " + row_index + " : " + ex + Environment.NewLine;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_3() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor 3 Failed Exception : " + row_index + " : " + ex + Environment.NewLine;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลประเภทรภ
        private int _getCarType(string cartype)
        {
            List<Base_Car_Types> list_data = new Base_Car_Types_Manager().getCarTypes();

            int result = 0;

            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Car_Types data = list_data[i];

                if (data.car_type_name == cartype)
                {
                    result = data.car_type_id;
                }

            }

            return result;
        }

        // ดึงข้อมูลยี่ห้อรถ
        private int _getCarBrand(string carbrand)
        {
            List<Base_Car_Brands> list_data = new Base_Car_Brand_Manager().getCarBrands();
            int result = 0;

            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Car_Brands data = list_data[i];

                if (carbrand.IndexOf('-') > 0)
                {
                    carbrand = carbrand.Split('-')[0];
                }

                if (data.car_brand_name_eng == carbrand || data.car_brand_name_th == carbrand)
                {
                    result = data.car_brand_id;
                }
            }

            return result;
        }

        // สภาพรถ
        private int _getCarUsed(string car_used)
        {
            int result = 0;
            if (car_used == "0")
            {
                result = 1;
            }
            else if (car_used == "1")
            {
                result = 2;
            }
            return result;
        }

        // รหัสสัญญา
        private int _getLeasingCode(string Leasing_code_name)
        {
            List<Base_Leasing_Code> list_data = new Base_Leasing_Code_Manager().getLeasingCode();
            int result = 0;
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Leasing_Code data = list_data[i];
                if (data.Leasing_code_name == Leasing_code_name)
                {
                    result = data.Leasing_code_id;
                }
            }
            return result;
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

        // เขตบริการ
        private int _getZoneService(string zone)
        {
            List<Base_Zone_Service> list_data = new Base_Zone_Service_Manager().getZoneService();
            int result = 0;
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Zone_Service data = list_data[i];

                if (data.Zone_code == zone.Split(' ')[0])
                {
                    result = data.Zone_id;
                }
                else if ("ต่างจังหวัด" == zone)
                {
                    result = 7;
                }
            }
            return result;
        }

        // ศาล
        private int _getCourt(string Court_name)
        {
            List<Base_Courts> list_data = new Base_Courts_Manager().getCourts();
            int result = 0;
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Courts data = list_data[i];
                if (data.Court_name == Court_name)
                {
                    result = data.Court_id;
                }
            }
            return result;
        }

        // ชื่อเต้นท์รถ
        private void _loadTentsCar()
        {
            List<Base_Tents_Car> list_data = new Base_Tents_Car_Manager().getTents();

            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Tents_Car data = list_data[i];


            }
        }

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private int _getThaiProvinces(string province)
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            int result = 0;

            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];

                if (data.Province_name == province)
                {
                    result = data.Province_id;
                }
            }
            return result;
        }


    }
}