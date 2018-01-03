using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data.SqlClient;

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
            Messages_TBx.Text = "";
            _loadcustomers();
        }

        protected void link_load_leasings_no_customer_Click(object sender, EventArgs e)
        {
            Messages_TBx.Text = "";
            _loadLeasing_no_customer();
        }

        protected void link_load_leasings_Click(object sender, EventArgs e)
        {
            Messages_TBx.Text = "";
            _loadLeasings();
        }

        protected void link_load_paymnet_Click(object sender, EventArgs e)
        {
            Messages_TBx.Text = "";
            _getAllAmountRowsLeasing();
        }

        protected void link_load_guarantor_1_Click(object sender, EventArgs e)
        {
            Messages_TBx.Text = "";
            _loadGuarantor(1);
        }

        protected void link_load_guarantor_2_Click(object sender, EventArgs e)
        {
            Messages_TBx.Text = "";
            _loadGuarantor(2);
        }

        protected void link_load_guarantor_3_Click(object sender, EventArgs e)
        {
            Messages_TBx.Text = "";
            _loadGuarantor(3);
        }

        protected void link_fix_fine_Click(object sender, EventArgs e)
        {
            Messages_TBx.Text = "";

        }

        private void _loadcustomers()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "  SELECT  cntr.personID AS idcard_00, cntr.title + cntr.fName AS Fname_01, cntr.lName AS Lname_02, cntr.age AS age_03, cntr.race AS Origin_04, cntr.nationality AS nationality_05, cntr.cardForm AS cardForm_06,";
                sql += "                cntr.cardDate AS idcard_start_07, cntr.cardExpire AS idcard_expire_08, cntr.marryStatus AS Cust_Status_id_09, cntr.marrierFN AS marrierFN_10, cntr.marrierLN AS marrierLN_11, ";
                sql += "                cntr.occupation_M AS job_marry_12, cntr.occPosition_M AS job_position_marry_13, cntr.income_M AS job_salary_marry_14, cntr.occupation AS job_15, cntr.occPosition AS job_position_16, ";
                sql += "                cntr.income AS job_salary_17, add_marry.addressID AS m_addressID_18, add_marry.addressType AS m_addressType_19, add_marry.addressName AS m_addressName_20, ";
                sql += "                add_marry.addressNo AS m_addressNo_21, add_marry.soi AS m_soi_22, add_marry.moo AS m_moo_23, add_marry.street AS m_street_24, add_marry.tumbon AS m_tumbon_25, ";
                sql += "                add_marry.aumphur AS m_aumphur_26, add_marry.province AS m_province_27, add_marry.phone AS m_phone_28, add_marry.stayYear AS m_stayYear_29, add_marry.ownerStatus AS m_ownerStatus_30, ";
                sql += "                add_marry.zipcode AS m_zipcode_31, add_marry.homeName AS m_homeName_32, add_job.addressID AS job_addressID_33, add_job.addressType AS job_addressType_34, ";
                sql += "                add_job.addressName AS job_addressName_35, add_job.addressNo AS job_addressNo_36, add_job.soi AS job_soi_37, add_job.moo AS job_moo_38, add_job.street AS job_street_39, ";
                sql += "                add_job.tumbon AS job_tumbon_40, add_job.aumphur AS job_aumphur_41, add_job.province AS job_province_42, add_job.phone AS job_phone_43, add_job.stayYear AS job_stayYear_44, ";
                sql += "                add_job.ownerStatus AS job_ownerStatus_45, add_job.zipcode AS job_zipcode_46, add_job.homeName AS job_homeName_47, add_h.addressID AS h_addressID_48, add_h.addressType AS h_addressType_49, ";
                sql += "                add_h.addressName AS h_addressName_50, add_h.addressNo AS h_addressNo_51, add_h.soi AS h_soi_52, add_h.moo AS h_moo_53, add_h.street AS h_street_54, add_h.tumbon AS h_tumbon_55, ";
                sql += "                add_h.aumphur AS h_aumphur_56, add_h.province AS h_province_57, add_h.phone AS h_phone_58, add_h.stayYear AS h_stayYear_59, add_h.ownerStatus AS h_ownerStatus_60, ";
                sql += "                add_h.zipcode AS h_zipcode_61, add_h.homeName AS h_homeName_62, add_c.addressID AS idcard_addressID_63, add_c.addressType AS idcard_addressType_64, ";
                sql += "                add_c.addressName AS idcard_addressName_65, add_c.addressNo AS idcard_addressNo_66, add_c.soi AS idcard_soi_67, add_c.moo AS idcard_moo_68, add_c.street AS idcard_street_69, ";
                sql += "                add_c.tumbon AS idcard_tumbon_70, add_c.aumphur AS idcard_aumphur_71, add_c.province AS idcard_province_72, add_c.phone AS idcard_phone_73, add_c.stayYear AS idcard_stayYear_74, ";
                sql += "                add_c.ownerStatus AS idcard_ownerStatus_75, add_c.zipcode AS idcard_zipcode_76, add_c.homeName AS idcard_homeName_77, add_n.addressID AS current_addressID_78, ";
                sql += "                add_n.addressType AS current_addressType_79, add_n.addressName AS current_addressName_80, add_n.addressNo AS current_addressNo_81, add_n.soi AS current_soi_82, add_n.moo AS current_moo_83, ";
                sql += "                add_n.street AS current_street_84, add_n.tumbon AS current_tumbon_85, add_n.aumphur AS current_aumphur_86, add_n.province AS current_province_87, add_n.phone AS current_phone_88, ";
                sql += "                add_n.stayYear AS current_stayYear_89, add_n.ownerStatus AS current_ownerStatus_90, add_n.zipcode AS current_zipcode_91, add_n.homeName AS current_homeName_92";
                sql += "        FROM    dbo.Contractor AS cntr LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_c ON cntr.personID = add_c.personID AND add_c.addressType = 'C' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_h ON cntr.personID = add_h.personID AND add_h.addressType = 'H' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_n ON cntr.personID = add_n.personID AND add_n.addressType = 'N' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_job ON cntr.personID = add_job.personID AND add_job.addressType = 'O' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_marry ON cntr.personID = add_marry.personID AND add_marry.addressType = 'M' ";

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

                    ctm.Cust_Idcard_start = reader.IsDBNull(7) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(7).ToString()); // Server JKLFTP
                    ctm.Cust_Idcard_expire = reader.IsDBNull(8) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(8).ToString()); // Server JKLFTP

                    ctm.ctm_ntnlt = new Base_Nationalitys();
                    ctm.ctm_ntnlt.Nationality_id = 1;

                    ctm.ctm_org = new Base_Origins();
                    ctm.ctm_org.Origin_id = 1;

                    ctm.Cust_Tel = defaultString;
                    ctm.Cust_Email = defaultString;

                    ctm.ctm_pstt = new Base_Person_Status();
                    ctm.ctm_pstt.person_status_id = reader.IsDBNull(9) ? defaultNum : reader.GetString(9) == "" ? defaultNum : Convert.ToInt32(reader.GetString(9)) > 5 ? 1 : Convert.ToInt32(reader.GetString(9));

                    ctm.ctm_marry_ntnlt = new Base_Nationalitys();

                    ctm.ctm_marry_org = new Base_Origins();

                    if (ctm.ctm_pstt.person_status_id == 2)
                    {
                        ctm.Cust_Marry_Fname = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                        ctm.Cust_Marry_Lname = reader.IsDBNull(11) ? defaultString : reader.GetString(11);

                        ctm.ctm_marry_ntnlt.Nationality_id = 1;

                        ctm.ctm_marry_org.Origin_id = 1;

                        ctm.Cust_Marry_Address_no = defaultString;
                        ctm.Cust_Marry_vilage = defaultString;
                        ctm.Cust_Marry_vilage_no = "ม.-";
                        ctm.Cust_Marry_alley = "ซ.-";
                        ctm.Cust_Marry_road = "ถ.-";
                        ctm.Cust_Marry_subdistrict = "ต.-";
                        ctm.Cust_Marry_district = "อ.-";
                        ctm.Cust_Marry_province = "จ.-";
                        ctm.Cust_Marry_country = "ประเทศไทย";
                        ctm.Cust_Marry_zipcode = defaultString;
                        ctm.Cust_Marry_tel = defaultString;
                        ctm.Cust_Marry_email = defaultString;
                        ctm.Cust_Marry_job = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                        ctm.Cust_Marry_job_position = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                        ctm.Cust_Marry_job_long = 0;
                        ctm.Cust_Marry_job_salary = 0;
                        ctm.Cust_Marry_job_local_name = defaultString;
                        ctm.Cust_Marry_job_address_no = defaultString;
                        ctm.Cust_Marry_job_vilage = defaultString;
                        ctm.Cust_Marry_job_vilage_no = "ม.-";
                        ctm.Cust_Marry_job_alley = "ซ.-";
                        ctm.Cust_Marry_job_road = "ถ.-";
                        ctm.Cust_Marry_job_subdistrict = "ต.-";
                        ctm.Cust_Marry_job_district = "อ.-";
                        ctm.Cust_Marry_job_province = "จ.-";
                        ctm.Cust_Marry_job_country = "ประเทศไทย";
                        ctm.Cust_Marry_job_zipcode = defaultString;
                        ctm.Cust_Marry_job_tel = defaultString;
                    }

                    ctm.Cust_Job = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    ctm.Cust_Job_position = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    ctm.Cust_Job_long = 0;
                    ctm.Cust_Job_salary = 0;
                    ctm.Cust_Job_local_name = reader.IsDBNull(35) ? defaultString : reader.GetString(35);
                    ctm.Cust_Job_address_no = reader.IsDBNull(36) ? defaultString : reader.GetString(36);
                    ctm.Cust_Job_vilage = defaultString;
                    ctm.Cust_Job_vilage_no = reader.IsDBNull(38) ? "ม.-" : "ม." + reader.GetString(38);
                    ctm.Cust_Job_alley = reader.IsDBNull(37) ? "ซ.-" : "ซ." + reader.GetString(37);
                    ctm.Cust_Job_road = reader.IsDBNull(39) ? "ถ.-" : "ถ." + reader.GetString(39);
                    ctm.Cust_Job_subdistrict = reader.IsDBNull(40) ? "ต.-" : "ต." + reader.GetString(40);
                    ctm.Cust_Job_district = reader.IsDBNull(41) ? "อ.-" : "อ." + reader.GetString(41);
                    ctm.Cust_Job_province = reader.IsDBNull(42) ? "จ.-" : "จ." + reader.GetString(42);
                    ctm.Cust_Job_country = "ประเทศไทย";
                    ctm.Cust_Job_zipcode = reader.IsDBNull(46) ? defaultString : reader.GetString(46);
                    ctm.Cust_Job_tel = reader.IsDBNull(43) ? defaultString : reader.GetString(43);
                    ctm.Cust_Job_email = defaultString;

                    ctm.Cust_Home_address_no = reader.IsDBNull(51) ? defaultString : reader.GetString(51);
                    ctm.Cust_Home_vilage = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    ctm.Cust_Home_vilage_no = reader.IsDBNull(53) ? "ม.-" : "ม." + reader.GetString(53);
                    ctm.Cust_Home_alley = reader.IsDBNull(52) ? "ซ.-" : "ซ." + reader.GetString(52);
                    ctm.Cust_Home_road = reader.IsDBNull(54) ? "ถ.-" : "ถ." + reader.GetString(54);
                    ctm.Cust_Home_subdistrict = reader.IsDBNull(55) ? "ต.-" : "ต." + reader.GetString(55);
                    ctm.Cust_Home_district = reader.IsDBNull(56) ? "อ.-" : "อ." + reader.GetString(56);
                    ctm.Cust_Home_province = reader.IsDBNull(57) ? "จ.-" : "จ." + reader.GetString(57);
                    ctm.Cust_Home_country = "ประเทศไทย";
                    ctm.Cust_Home_zipcode = reader.IsDBNull(61) ? defaultString : reader.GetString(61);
                    ctm.Cust_Home_tel = reader.IsDBNull(58) ? defaultString : reader.GetString(58);
                    ctm.Cust_Home_GPS_Latitude = defaultString;
                    ctm.Cust_Home_GPS_Longitude = defaultString;

                    ctm.ctm_home_stt = new Base_Home_Status();
                    ctm.ctm_home_stt.Home_status_id = reader.IsDBNull(60) ? defaultNum : reader.GetString(60) == "4" ? 3 : reader.GetString(60) == "3" ? 2 : Convert.ToInt32(reader.GetString(60));

                    ctm.Cust_Idcard_address_no = reader.IsDBNull(66) ? defaultString : reader.GetString(66);
                    ctm.Cust_Idcard_vilage = reader.IsDBNull(77) ? defaultString : reader.GetString(77);
                    ctm.Cust_Idcard_vilage_no = reader.IsDBNull(68) ? "ม.-" : "ม." + reader.GetString(68);
                    ctm.Cust_Idcard_alley = reader.IsDBNull(67) ? "ซ.-" : "ซ." + reader.GetString(67);
                    ctm.Cust_Idcard_road = reader.IsDBNull(69) ? "ถ.-" : "ถ." + reader.GetString(69);
                    ctm.Cust_Idcard_subdistrict = reader.IsDBNull(70) ? "ต.-" : "ต." + reader.GetString(70);
                    ctm.Cust_Idcard_district = reader.IsDBNull(71) ? "อ.-" : "อ." + reader.GetString(71);
                    ctm.Cust_Idcard_province = reader.IsDBNull(72) ? "จ.-" : "จ." + reader.GetString(72);
                    ctm.Cust_Idcard_country = "ประเทศไทย";
                    ctm.Cust_Idcard_zipcode = reader.IsDBNull(76) ? defaultString : reader.GetString(76);
                    ctm.Cust_Idcard_tel = reader.IsDBNull(73) ? defaultString : reader.GetString(73);

                    ctm.ctm_idcard_stt = new Base_Home_Status();
                    ctm.ctm_idcard_stt.Home_status_id = reader.IsDBNull(75) ? defaultNum : reader.GetString(75) == "4" ? 3 : reader.GetString(75) == "3" ? 2 : Convert.ToInt32(reader.GetString(75));

                    ctm.Cust_Current_address_no = reader.IsDBNull(81) ? defaultString : reader.GetString(81);
                    ctm.Cust_Current_vilage = reader.IsDBNull(92) ? defaultString : reader.GetString(92);
                    ctm.Cust_Current_vilage_no = reader.IsDBNull(83) ? "ม.-" : "ม." + reader.GetString(83);
                    ctm.Cust_Current_alley = reader.IsDBNull(82) ? "ซ.-" : "ซ." + reader.GetString(82);
                    ctm.Cust_Current_road = reader.IsDBNull(84) ? "ถ.-" : "ถ." + reader.GetString(84);
                    ctm.Cust_Current_subdistrict = reader.IsDBNull(85) ? "ต.-" : "ต." + reader.GetString(85);
                    ctm.Cust_Current_district = reader.IsDBNull(86) ? "อ.-" : "อ." + reader.GetString(86);
                    ctm.Cust_Current_province = reader.IsDBNull(87) ? "จ.-" : "จ." + reader.GetString(87);
                    ctm.Cust_Current_country = "ประเทศไทย";
                    ctm.Cust_Current_zipcode = reader.IsDBNull(91) ? defaultString : reader.GetString(91);
                    ctm.Cust_Current_tel = reader.IsDBNull(88) ? defaultString : reader.GetString(88);

                    ctm.ctm_current_stt = new Base_Home_Status();
                    ctm.ctm_current_stt.Home_status_id = reader.IsDBNull(90) ? defaultNum : reader.GetString(90) == "4" ? 3 : reader.GetString(90) == "3" ? 2 : Convert.ToInt32(reader.GetString(90));

                    if (row_index % 5000 == 0) { part++; }

                    Customers chk_ctm = ctm_mng.getOnceCustomer(ctm.Cust_Idcard, ctm.Cust_Fname, ctm.Cust_LName, 0, 0);

                    if (string.IsNullOrEmpty(chk_ctm.Cust_id))
                    {
                        ctm_mng.addCustomers(ctm);

                        Messages_Logs._writeSQLCodeInsertCustomerToMYSQL(ctm, part);
                    }
                    else
                    {
                        ctm.Cust_id = chk_ctm.Cust_id;

                        ctm_mng.editCustomers(ctm);

                        Messages_Logs._writeSQLCodeUpdateCustomerToMYSQL(ctm, part);
                    }

                    row_index++;
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

                Messages_TBx.Text = "END TRANSFER DATAS CUSTOMER " + Environment.NewLine;
            }
        }

        private void _loadLeasing_no_customer()
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            try
            {
                con.Open();
                string sql = "  SELECT  cntr.personID AS idcard_00, cntr.title + cntr.fName AS Fname_01, cntr.lName AS Lname_02, cnt.cntID AS cntID_03, cnt.cntNoTemp AS Deps_No_04, cnt.cntNo AS Leasing_no_05, cnt.cntDate AS Leasing_date_06,  ";
                sql += "                cnt.totalTime AS Total_period_07, cnt.fixDate AS Payment_schedule_08, cnt.firstPayDate AS First_payment_date_09, cnt.branchNo AS Company_10, cnt.court AS Court_11, cnt.receiver AS PeReT_12,  ";
                sql += "                cnt.areaZone AS Zone_13, cnt.company AS Leasing_code_14, cnt.cntPrice AS Total_require_15, cnt.financePrice AS Total_Net_leasing_16, cnt.tax AS Interest_rate_17, cnt.vat AS Total_Tax_18,  ";
                sql += "                cnt.interest AS Total_Interest_19, cnt.payPerTime AS Period_cal_20, cnt.vatPerTime AS Period_tax_21, cnt.interestPerTime AS Period_interst_22, cnt.period AS Period_pure_23,  ";
                sql += "                cnt.payPerTimeCeiling AS Period_payment_24, car.carId AS carId_25, car.brand AS Car_brand_26, car.series AS Car_type_27, car.engineNo AS Car_engine_no_28, car.ccNo AS Car_chassis_no_29,  ";
                sql += "                car.licenseNo AS Car_license_plate_30, car.usedStatus AS Car_used_id_31, car.mile AS Car_distance_32, car.color AS Car_color_33, car.carYear AS Car_year_34,  ";
                sql += "                car.expireLicense AS Car_next_register_date_35, car.registerLicense AS Car_register_date_36, car.taxPrice AS Car_tax_value_37, car.credit AS Car_credits_38, car.agent AS Car_agent_39,  ";
                sql += "                car.formerName AS Car_old_owner_40, car.formerID AS Car_old_owner_idcard_41, car.formerCardExpire AS Car_old_owner_b_date_42, car.formerAddr AS Car_old_owner_address_no_43,  ";
                sql += "                cnt.getChequeDate AS Cheque_receive_date_44, cnt.chequeNo AS Cheque_number_45, cnt.chequePay AS Cheque_sum_46, cnt.chequeReceiver AS Cheque_receiver_47, cnt.nameGetCheque AS Cheque_bank_48, ";
                sql += "                cnt.commission AS Agent_commission_49, cnt.cmsID AS agent_idcard_50, cnt.cmsFName AS agent_Fname_51, cnt.cmsLName AS agent_Lname_52, cnt.cmsAddress AS agent_Address_53 ";
                sql += "        FROM    dbo.Contract AS cnt LEFT OUTER JOIN ";
                sql += "                dbo.ContractRef AS cnt_ref ON cnt.cntID = cnt_ref.cntID AND cnt_ref.refNo = 0 LEFT OUTER JOIN ";
                sql += "                dbo.Contractor AS cntr ON cnt_ref.personID = cntr.personID LEFT OUTER JOIN ";
                sql += "                dbo.Car AS car ON cnt.cntID = car.cntID AND car.personID = cntr.personID LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_c ON cntr.personID = add_c.personID AND add_c.addressType = 'C' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_h ON cntr.personID = add_h.personID AND add_h.addressType = 'H' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_n ON cntr.personID = add_n.personID AND add_n.addressType = 'N' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_job ON cntr.personID = add_job.personID AND add_job.addressType = 'O' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_marry ON cntr.personID = add_marry.personID AND add_marry.addressType = 'M' ";
                sql += "        WHERE   cnt.cntNoTemp = '0471251' OR cnt.cntNoTemp = '521094' OR ";
                sql += "        cnt.cntNoTemp = '47400066' OR cnt.cntNoTemp = '48050043' OR cnt.cntNoTemp = '48060086' OR cnt.cntNoTemp = '48070052' OR ";
                sql += "        cnt.cntNoTemp = '48110087' OR cnt.cntNoTemp = '51120158' OR cnt.cntNoTemp = '52100071' OR cnt.cntNoTemp = '53070176' OR ";
                sql += "        cnt.cntNoTemp = '54060034' OR cnt.cntNoTemp = '54070030' OR cnt.cntNoTemp = '56070157' OR cnt.cntNoTemp = '56080147' OR ";
                sql += "        cnt.cntNoTemp = '047-12-51' ";

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();

                while (reader.Read())
                {

                    int defaultNum = 0;
                    string defaultString = "";

                    Car_Leasings cls = new Car_Leasings();

                    Car_Leasings chk_cls = cls_mng.getCarLeasingByDepsNo(reader.GetString(4), "");

                    cls.Leasing_id = cls_mng.generateLeasingID();
                    cls.Deps_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cls.Leasing_no = reader.IsDBNull(5) ? defaultString : reader.GetString(5);

                    cls.bs_ls_code = new Base_Leasing_Code();
                    cls.bs_ls_code.Leasing_code_id = reader.IsDBNull(14) ? 1 : _getLeasingCode(reader.GetString(14));

                    cls.Leasing_date = reader.IsDBNull(6) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(6).ToString()); // Server JKLFTP
                    cls.bs_cpn = new Base_Companys();
                    cls.bs_cpn.Company_id = reader.IsDBNull(10) ? 1 : _getCompanys(reader.GetString(10));

                    cls.bs_zn = new Base_Zone_Service();
                    cls.bs_zn.Zone_id = reader.IsDBNull(13) ? 1 : _getZoneService(reader.GetString(13));

                    cls.bs_ct = new Base_Courts();
                    cls.bs_ct.Court_id = reader.IsDBNull(11) ? 1 : _getCourt(reader.GetString(11));

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

                    cls.First_payment_date = reader.IsDBNull(9) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(9).ToString()); // Server JKLFTP
                    cls.Car_register_date = reader.IsDBNull(36) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(36).ToString()); // Server JKLFTP

                    cls.Car_license_plate = reader.IsDBNull(30) ? null : reader.GetString(30);
                    cls.Car_license_plate_province = "จ.-";

                    cls.Car_type = reader.IsDBNull(27) ? null : reader.GetString(27);
                    cls.Car_feature = defaultString;

                    cls.bs_cbrn = new Base_Car_Brands();
                    cls.bs_cbrn.car_brand_id = reader.IsDBNull(26) ? defaultNum : _getCarBrand(reader.GetString(26));

                    cls.Car_model = defaultString;
                    cls.Car_year = reader.IsDBNull(34) ? defaultString : (Convert.ToInt32(reader.GetString(34)) - 543).ToString();
                    cls.Car_color = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    cls.Car_engine_no = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    cls.Car_engine_no_at = defaultString;
                    cls.Car_engine_brand = defaultString;
                    cls.Car_chassis_no = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    cls.Car_chassis_no_at = defaultString;
                    cls.Car_fual_type = defaultString;
                    cls.Car_gas_No = defaultString;
                    cls.Car_used_id = reader.IsDBNull(31) ? defaultNum : _getCarUsed(reader.GetString(31));
                    cls.Car_distance = 0;

                    cls.Car_next_register_date = reader.IsDBNull(35) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(35).ToString()); // Server JKLFTP

                    cls.Car_tax_value = reader.IsDBNull(37) ? defaultNum : Convert.ToDouble(reader.GetString(37) == "" ? "0" : reader.GetString(37));
                    cls.Car_credits = reader.IsDBNull(38) ? defaultString : reader.GetString(38);
                    cls.Car_agent = reader.IsDBNull(39) ? defaultString : reader.GetString(39);

                    cls.Car_old_owner = reader.IsDBNull(40) ? defaultString : reader.GetString(40);
                    cls.Car_old_owner_idcard = reader.IsDBNull(41) ? defaultString : reader.GetString(41);

                    cls.Car_old_owner_b_date = reader.IsDBNull(42) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(42).ToString()); // Server JKLFTP

                    cls.Car_old_owner_address_no = defaultString;
                    cls.Car_old_owner_vilage = defaultString;
                    cls.Car_old_owner_vilage_no = defaultString;
                    cls.Car_old_owner_alley = defaultString;
                    cls.Car_old_owner_road = defaultString;
                    cls.Car_old_owner_subdistrict = reader.IsDBNull(43) ? defaultString : reader.GetString(43);
                    cls.Car_old_owner_district = defaultString;
                    cls.Car_old_owner_province = "จ.-";
                    cls.Car_old_owner_contry = "ประเทศไทย";
                    cls.Car_old_owner_zipcode = defaultString;

                    cls.tent_car = new Base_Tents_Car();
                    cls.tent_car.Tent_car_id = defaultNum;

                    cls.Cheque_receiver = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                    cls.Cheque_bank = reader.IsDBNull(48) ? defaultString : reader.GetString(48);
                    cls.Cheque_bank_branch = defaultString;
                    cls.Cheque_number = reader.IsDBNull(45) ? defaultString : reader.GetString(45);
                    cls.Cheque_sum = reader.IsDBNull(46) ? defaultNum : Convert.ToDouble(reader.GetDecimal(46));

                    cls.Cheque_receive_date = reader.IsDBNull(44) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(44).ToString()); // Server JKLFTP

                    cls.Guarantee = defaultString;

                    cls.bs_ls_stt = new Base_Leasing_Status();
                    cls.bs_ls_stt.Contract_Status_id = 1;

                    if (string.IsNullOrEmpty(chk_cls.Deps_no)) /// กรณีค้นหาจากเลขฝากแล้วไม่เจอ
                    {
                        cls_mng.addCarLeasings(cls);

                        Messages_Logs._writeSQLCodeInsertLeasingsToMYSQL(cls, 0);

                        Messages_TBx.Text += "Transfer Add Data Leasing No Customers Passed : " + row_index + Environment.NewLine;

                        row_index++;
                    }
                    else if (string.IsNullOrEmpty(chk_cls.Leasing_no))  /// กรณีค้นหาจากเลขฝากเจอ แล้วเลขสัญญาเดิมเป็นค่าว่าง ให้ทำการแก้ไขข้อมูล
                    {
                        cls.Leasing_id = chk_cls.Leasing_id;

                        cls_mng.editCarLeasings(cls);

                        Messages_Logs._writeSQLCodeUpdateLeasingsToMYSQL(cls, 0);

                        Messages_TBx.Text += "Transfer Add Data Leasing No Customers Passed : " + row_index + Environment.NewLine;

                        row_index++;
                    }
                    else if (chk_cls.Leasing_no == cls.Leasing_no)  /// กรณีค้นหาจากเลขฝากเจอ แล้วเลขสัญญาเดิมเหมือนกัน ให้ทำการแก้ไขข้อมูล
                    {
                        cls.Leasing_id = chk_cls.Leasing_id;

                        cls_mng.editCarLeasings(cls);

                        Messages_Logs._writeSQLCodeUpdateLeasingsToMYSQL(cls, 0);

                        Messages_TBx.Text += "Transfer Add Data Leasing No Customers Passed : " + row_index + Environment.NewLine;

                        row_index++;
                    }
                    else
                    {
                        cls_mng.addCarLeasings(cls);

                        Messages_Logs._writeSQLCodeInsertLeasingsToMYSQL(cls, 0);

                        Messages_TBx.Text += "Transfer Add Data Leasing No Customers Passed : " + row_index + Environment.NewLine;

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

                Messages_TBx.Text = "END TRANSFER DATAS LEASING NO CUSTOMER " + Environment.NewLine;
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
                string sql = "  SELECT  cntr.personID AS idcard_00, cntr.title + cntr.fName AS Fname_01, cntr.lName AS Lname_02, cnt.cntID AS cntID_03, cnt.cntNoTemp AS Deps_No_04, cnt.cntNo AS Leasing_no_05, cnt.cntDate AS Leasing_date_06,  ";
                sql += "                cnt.totalTime AS Total_period_07, cnt.fixDate AS Payment_schedule_08, cnt.firstPayDate AS First_payment_date_09, cnt.branchNo AS Company_10, cnt.court AS Court_11, cnt.receiver AS PeReT_12,  ";
                sql += "                cnt.areaZone AS Zone_13, cnt.company AS Leasing_code_14, cnt.cntPrice AS Total_require_15, cnt.financePrice AS Total_Net_leasing_16, cnt.tax AS Interest_rate_17, cnt.vat AS Total_Tax_18,  ";
                sql += "                cnt.interest AS Total_Interest_19, cnt.payPerTime AS Period_cal_20, cnt.vatPerTime AS Period_tax_21, cnt.interestPerTime AS Period_interst_22, cnt.period AS Period_pure_23,  ";
                sql += "                cnt.payPerTimeCeiling AS Period_payment_24, car.carId AS carId_25, car.brand AS Car_brand_26, car.series AS Car_type_27, car.engineNo AS Car_engine_no_28, car.ccNo AS Car_chassis_no_29,  ";
                sql += "                car.licenseNo AS Car_license_plate_30, car.usedStatus AS Car_used_id_31, car.mile AS Car_distance_32, car.color AS Car_color_33, car.carYear AS Car_year_34,  ";
                sql += "                car.expireLicense AS Car_next_register_date_35, car.registerLicense AS Car_register_date_36, car.taxPrice AS Car_tax_value_37, car.credit AS Car_credits_38, car.agent AS Car_agent_39,  ";
                sql += "                car.formerName AS Car_old_owner_40, car.formerID AS Car_old_owner_idcard_41, car.formerCardExpire AS Car_old_owner_b_date_42, car.formerAddr AS Car_old_owner_address_no_43,  ";
                sql += "                cnt.getChequeDate AS Cheque_receive_date_44, cnt.chequeNo AS Cheque_number_45, cnt.chequePay AS Cheque_sum_46, cnt.chequeReceiver AS Cheque_receiver_47, cnt.nameGetCheque AS Cheque_bank_48, ";
                sql += "                cnt.commission AS Agent_commission_49, cnt.cmsID AS agent_idcard_50, cnt.cmsFName AS agent_Fname_51, cnt.cmsLName AS agent_Lname_52, cnt.cmsAddress AS agent_Address_53 ";
                sql += "        FROM    dbo.Contract AS cnt INNER JOIN ";
                sql += "                dbo.ContractRef AS cnt_ref ON cnt.cntID = cnt_ref.cntID AND cnt_ref.refNo = 0 LEFT OUTER JOIN ";
                sql += "                dbo.Contractor AS cntr ON cnt_ref.personID = cntr.personID LEFT OUTER JOIN";
                sql += "                dbo.Car AS car ON cnt.cntID = car.cntID AND car.personID = cntr.personID LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_c ON cntr.personID = add_c.personID AND add_c.addressType = 'C' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_h ON cntr.personID = add_h.personID AND add_h.addressType = 'H' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_n ON cntr.personID = add_n.personID AND add_n.addressType = 'N' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_job ON cntr.personID = add_job.personID AND add_job.addressType = 'O' LEFT OUTER JOIN ";
                sql += "                dbo.Address AS add_marry ON cntr.personID = add_marry.personID AND add_marry.addressType = 'M' ";

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

                    Car_Leasings chk_cls = cls_mng.getCarLeasingByDepsNo(reader.GetString(4), "");

                    Customers ctm = new Customers();

                    if (!reader.IsDBNull(0))
                    {

                        ctm = ctm_mng.getCustomersByIdCard(reader.IsDBNull(0) ? defaultString : reader.GetString(0));

                        ctm.Cust_B_date = null;

                        ctm.Cust_Idcard_start = string.IsNullOrEmpty(ctm.Cust_Idcard_start) ? null : DateTimeUtility.convertDateToMYSQLRealServer(ctm.Cust_Idcard_start); // Server JKLFTP
                        ctm.Cust_Idcard_expire = string.IsNullOrEmpty(ctm.Cust_Idcard_expire) ? null : DateTimeUtility.convertDateToMYSQLRealServer(ctm.Cust_Idcard_expire); // Server JKLFTP

                    }

                    Car_Leasings cls = new Car_Leasings();

                    cls.Leasing_id = cls_mng.generateLeasingID();

                    cls.Deps_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cls.Leasing_no = reader.IsDBNull(5) ? defaultString : reader.GetString(5);

                    cls.bs_ls_code = new Base_Leasing_Code();
                    cls.bs_ls_code.Leasing_code_id = reader.IsDBNull(14) ? 1 : _getLeasingCode(reader.GetString(14));

                    cls.Leasing_date = reader.IsDBNull(6) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(6).ToString()); // Server JKLFTP

                    //cls.Leasing_date = reader.IsDBNull(6) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(6).ToString()); // Server JKLWebBase

                    if (cls.Deps_no == "52060140")
                    {
                        cls.Leasing_date = "2009-08-13";
                    }
                    else if (cls.Deps_no == "52120052")
                    {
                        cls.Leasing_date = "2010-1-08";
                    }

                    cls.bs_cpn = new Base_Companys();
                    cls.bs_cpn.Company_id = reader.IsDBNull(10) ? 1 : _getCompanys(reader.GetString(10));

                    cls.bs_zn = new Base_Zone_Service();
                    cls.bs_zn.Zone_id = reader.IsDBNull(13) ? 1 : _getZoneService(reader.GetString(13));

                    cls.bs_ct = new Base_Courts();
                    cls.bs_ct.Court_id = reader.IsDBNull(11) ? 1 : _getCourt(reader.GetString(11));

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

                    cls.First_payment_date = reader.IsDBNull(9) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(9).ToString()); // Server JKLFTP

                    if (cls.Deps_no == "46120431")
                    {
                        cls.First_payment_date = "2004-01-05";
                    }

                    cls.Car_register_date = reader.IsDBNull(36) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(36).ToString()); // Server JKLFTP

                    cls.Car_license_plate = reader.IsDBNull(30) ? null : reader.GetString(30);
                    cls.Car_license_plate_province = "จ.-";

                    cls.Car_type = reader.IsDBNull(27) ? null : reader.GetString(27);
                    cls.Car_feature = defaultString;

                    cls.bs_cbrn = new Base_Car_Brands();
                    cls.bs_cbrn.car_brand_id = reader.IsDBNull(26) ? defaultNum : _getCarBrand(reader.GetString(26));

                    cls.Car_model = defaultString;
                    cls.Car_year = reader.IsDBNull(34) ? defaultString : (Convert.ToInt32(reader.GetString(34)) - 543).ToString();
                    cls.Car_color = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    cls.Car_engine_no = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    cls.Car_engine_no_at = defaultString;
                    cls.Car_engine_brand = defaultString;
                    cls.Car_chassis_no = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    cls.Car_chassis_no_at = defaultString;
                    cls.Car_fual_type = defaultString;
                    cls.Car_gas_No = defaultString;
                    cls.Car_used_id = reader.IsDBNull(31) ? defaultNum : _getCarUsed(reader.GetString(31));
                    cls.Car_distance = 0;

                    cls.Car_next_register_date = reader.IsDBNull(35) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(35).ToString()); // Server JKLFTP

                    cls.Car_tax_value = reader.IsDBNull(37) ? defaultNum : reader.GetString(37) == "" || reader.GetString(37) == "-" ? defaultNum : Convert.ToDouble(reader.GetString(37));
                    cls.Car_credits = reader.IsDBNull(38) ? defaultString : reader.GetString(38);
                    cls.Car_agent = reader.IsDBNull(39) ? defaultString : reader.GetString(39);

                    cls.Car_old_owner = reader.IsDBNull(40) ? defaultString : reader.GetString(40);
                    cls.Car_old_owner_idcard = reader.IsDBNull(41) ? defaultString : reader.GetString(41);

                    cls.Car_old_owner_b_date = reader.IsDBNull(42) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(42).ToString()); // Server JKLFTP

                    cls.Car_old_owner_address_no = defaultString;
                    cls.Car_old_owner_vilage = defaultString;
                    cls.Car_old_owner_vilage_no = defaultString;
                    cls.Car_old_owner_alley = defaultString;
                    cls.Car_old_owner_road = defaultString;
                    cls.Car_old_owner_subdistrict = reader.IsDBNull(43) ? defaultString : reader.GetString(43);
                    cls.Car_old_owner_district = defaultString;
                    cls.Car_old_owner_province = defaultString;
                    cls.Car_old_owner_contry = "ประเทศไทย";
                    cls.Car_old_owner_zipcode = defaultString;

                    cls.tent_car = new Base_Tents_Car();
                    cls.tent_car.Tent_car_id = defaultNum;

                    cls.Cheque_receiver = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                    cls.Cheque_bank = reader.IsDBNull(48) ? defaultString : reader.GetString(48);
                    cls.Cheque_bank_branch = defaultString;
                    cls.Cheque_number = reader.IsDBNull(45) ? defaultString : reader.GetString(45);
                    cls.Cheque_sum = reader.IsDBNull(46) ? defaultNum : Convert.ToDouble(reader.GetDecimal(46));

                    cls.Cheque_receive_date = reader.IsDBNull(44) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(44).ToString()); // Server JKLFTP

                    //cls.Cheque_receive_date = reader.IsDBNull(44) ? null : DateTimeUtility.convertDateToMYSQL(reader.GetDateTime(44).ToString()); // Server JKLWebBase

                    cls.Guarantee = defaultString;

                    cls.bs_ls_stt = new Base_Leasing_Status();
                    cls.bs_ls_stt.Contract_Status_id = 1;

                    if (row_index % 5000 == 0) { part++; }

                    if (string.IsNullOrEmpty(chk_cls.Deps_no)) /// กรณีค้นหาจากเลขฝากแล้วไม่เจอ
                    {
                        cls_mng.addCarLeasings(cls);

                        Messages_Logs._writeSQLCodeInsertLeasingsToMYSQL(cls, part);

                        cls_ctm_mng.addCustomersLeasing(cls, ctm);

                        Messages_Logs._writeSQLCodeInsertCustomerLeasingsToMYSQL(cls, ctm, part);

                        if (reader.GetDecimal(49) > 0)
                        {
                            Agents_Commission cag_com = new Agents_Commission();

                            Agents cag = new Agents();

                            Agents chk_cag = cag_mng.getAgentByName(reader.GetString(50), reader.GetString(51), reader.GetString(52));

                            cag.Agent_id = cag_mng.generateAgentID();
                            cag.Agent_Fname = reader.GetString(51);
                            cag.Agent_Lname = reader.GetString(52);
                            cag.Agent_Idcard = reader.GetString(50);
                            cag.Agent_Address_no = defaultString;
                            cag.Agent_Vilage = defaultString;
                            cag.Agent_Vilage_no = defaultString;
                            cag.Agent_Alley = defaultString;
                            cag.Agent_Road = defaultString;
                            cag.Agent_Subdistrict = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                            cag.Agent_District = defaultString;
                            cag.Agent_Province = defaultString;
                            cag.Agent_Country = "ประเทศไทย";
                            cag.Agent_Zipcode = defaultString;
                            cag.Agent_Status = 1;

                            if (string.IsNullOrEmpty(chk_cag.Agent_id))
                            {
                                cag_mng.addAgent(cag);

                                Messages_Logs._writeSQLCodeInsertAgentsToMYSQL(cag, part);

                            }
                            else
                            {
                                cag.Agent_id = chk_cag.Agent_id;

                                cag_mng.editAgent(cag);

                                Messages_Logs._writeSQLCodeUpdateAgentsToMYSQL(cag, part);
                            }

                            cag_com.cag = new Agents();
                            cag_com.cag = cag;

                            double commission = Convert.ToDouble(reader.GetDecimal(49)); ; // ค่านายหน้า
                            double loss_com = Math.Ceiling(commission * (3 / 100)); // ค่าหัก ณ ที่จ่าย

                            cag_com.Agent_commission = commission;
                            cag_com.Agent_percen = 3; // % หัก ณ ที่จ่าย
                            cag_com.Agent_cash = loss_com;
                            cag_com.Agent_net_com = (commission - loss_com);
                            cag_com.Agent_num_code = defaultString;
                            cag_com.Agent_book_code = defaultString;
                            cag_com.Agent_date_print = null;

                            cag_com.Leasing_id = cls.Leasing_id;

                            cag_mng.addAgentCommission(cag_com);

                            Messages_Logs._writeSQLCodeInsertAgentsCommissionToMYSQL(cag_com, part);
                        }

                        Messages_TBx.Text += "Transfer Add Data Leasing Passed : " + row_index + Environment.NewLine;

                        row_index++;
                    }
                    else if (string.IsNullOrEmpty(chk_cls.Leasing_no))  /// กรณีค้นหาจากเลขฝากเจอ แล้วเลขสัญญาเดิมเป็นค่าว่าง ให้ทำการแก้ไขข้อมูล
                    {
                        cls.Leasing_id = chk_cls.Leasing_id;

                        cls_mng.editCarLeasings(cls);

                        Messages_Logs._writeSQLCodeUpdateLeasingsToMYSQL(cls, part);

                        cls_ctm_mng.editCustomersLeasing(cls, ctm);

                        Messages_Logs._writeSQLCodeUpdateCustomerLeasingsToMYSQL(cls, ctm, part);

                        if (reader.GetDecimal(49) > 0)
                        {
                            Agents_Commission cag_com = new Agents_Commission();

                            Agents cag = new Agents();

                            Agents chk_cag = cag_mng.getAgentByName(reader.GetString(50), reader.GetString(51), reader.GetString(52));

                            cag.Agent_id = cag_mng.generateAgentID();
                            cag.Agent_Fname = reader.GetString(51);
                            cag.Agent_Lname = reader.GetString(52);
                            cag.Agent_Idcard = reader.GetString(50);
                            cag.Agent_Address_no = defaultString;
                            cag.Agent_Vilage = defaultString;
                            cag.Agent_Vilage_no = defaultString;
                            cag.Agent_Alley = defaultString;
                            cag.Agent_Road = defaultString;
                            cag.Agent_Subdistrict = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                            cag.Agent_District = defaultString;
                            cag.Agent_Province = defaultString;
                            cag.Agent_Country = "ประเทศไทย";
                            cag.Agent_Zipcode = defaultString;
                            cag.Agent_Status = 1;

                            if (string.IsNullOrEmpty(chk_cag.Agent_id))
                            {
                                cag_mng.addAgent(cag);

                                Messages_Logs._writeSQLCodeInsertAgentsToMYSQL(cag, part);

                            }
                            else
                            {
                                cag.Agent_id = chk_cag.Agent_id;

                                cag_mng.editAgent(cag);

                                Messages_Logs._writeSQLCodeUpdateAgentsToMYSQL(cag, part);
                            }

                            cag_com.cag = new Agents();
                            cag_com.cag = cag;

                            double commission = Convert.ToDouble(reader.GetDecimal(49)); ; // ค่านายหน้า
                            double loss_com = Math.Ceiling(commission * (3 / 100)); // ค่าหัก ณ ที่จ่าย

                            cag_com.Agent_commission = commission;
                            cag_com.Agent_percen = 3; // % หัก ณ ที่จ่าย
                            cag_com.Agent_cash = loss_com;
                            cag_com.Agent_net_com = (commission - loss_com);
                            cag_com.Agent_num_code = defaultString;
                            cag_com.Agent_book_code = defaultString;
                            cag_com.Agent_date_print = null;

                            cag_com.Leasing_id = cls.Leasing_id;

                            cag_mng.editAgentCommission(cag_com);

                            Messages_Logs._writeSQLCodeUpdateAgentsCommissionToMYSQL(cag_com, part);
                        }

                        row_index++;
                    }
                    else if (chk_cls.Leasing_no == cls.Leasing_no)  /// กรณีค้นหาจากเลขฝากเจอ แล้วเลขสัญญาเดิมเหมือนกัน ให้ทำการแก้ไขข้อมูล
                    {
                        cls.Leasing_id = chk_cls.Leasing_id;

                        cls_mng.editCarLeasings(cls);

                        Messages_Logs._writeSQLCodeUpdateLeasingsToMYSQL(cls, part);

                        cls_ctm_mng.editCustomersLeasing(cls, ctm);

                        Messages_Logs._writeSQLCodeUpdateCustomerLeasingsToMYSQL(cls, ctm, part);

                        if (reader.GetDecimal(49) > 0)
                        {
                            Agents_Commission cag_com = new Agents_Commission();

                            Agents cag = new Agents();

                            Agents chk_cag = cag_mng.getAgentByName(reader.GetString(50), reader.GetString(51), reader.GetString(52));

                            cag.Agent_id = cag_mng.generateAgentID();
                            cag.Agent_Fname = reader.GetString(51);
                            cag.Agent_Lname = reader.GetString(52);
                            cag.Agent_Idcard = reader.GetString(50);
                            cag.Agent_Address_no = defaultString;
                            cag.Agent_Vilage = defaultString;
                            cag.Agent_Vilage_no = defaultString;
                            cag.Agent_Alley = defaultString;
                            cag.Agent_Road = defaultString;
                            cag.Agent_Subdistrict = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                            cag.Agent_District = defaultString;
                            cag.Agent_Province = defaultString;
                            cag.Agent_Country = "ประเทศไทย";
                            cag.Agent_Zipcode = defaultString;
                            cag.Agent_Status = 1;

                            if (string.IsNullOrEmpty(chk_cag.Agent_id))
                            {
                                cag_mng.addAgent(cag);

                                Messages_Logs._writeSQLCodeInsertAgentsToMYSQL(cag, part);

                            }
                            else
                            {
                                cag.Agent_id = chk_cag.Agent_id;

                                cag_mng.editAgent(cag);

                                Messages_Logs._writeSQLCodeUpdateAgentsToMYSQL(cag, part);
                            }

                            cag_com.cag = new Agents();
                            cag_com.cag = cag;

                            double commission = Convert.ToDouble(reader.GetDecimal(49)); ; // ค่านายหน้า
                            double loss_com = Math.Ceiling(commission * (3 / 100)); // ค่าหัก ณ ที่จ่าย

                            cag_com.Agent_commission = commission;
                            cag_com.Agent_percen = 3; // % หัก ณ ที่จ่าย
                            cag_com.Agent_cash = loss_com;
                            cag_com.Agent_net_com = (commission - loss_com);
                            cag_com.Agent_num_code = defaultString;
                            cag_com.Agent_book_code = defaultString;
                            cag_com.Agent_date_print = null;

                            cag_com.Leasing_id = cls.Leasing_id;

                            cag_mng.editAgentCommission(cag_com);

                            Messages_Logs._writeSQLCodeUpdateAgentsCommissionToMYSQL(cag_com, part);
                        }

                        row_index++;
                    }
                    else
                    {
                        cls_mng.addCarLeasings(cls);

                        Messages_Logs._writeSQLCodeInsertLeasingsToMYSQL(cls, part);

                        cls_ctm_mng.addCustomersLeasing(cls, ctm);

                        Messages_Logs._writeSQLCodeInsertCustomerLeasingsToMYSQL(cls, ctm, part);

                        if (reader.GetDecimal(49) > 0)
                        {
                            Agents_Commission cag_com = new Agents_Commission();

                            Agents cag = new Agents();

                            Agents chk_cag = cag_mng.getAgentByName(reader.GetString(50), reader.GetString(51), reader.GetString(52));

                            cag.Agent_id = cag_mng.generateAgentID();
                            cag.Agent_Fname = reader.GetString(51);
                            cag.Agent_Lname = reader.GetString(52);
                            cag.Agent_Idcard = reader.GetString(50);
                            cag.Agent_Address_no = defaultString;
                            cag.Agent_Vilage = defaultString;
                            cag.Agent_Vilage_no = defaultString;
                            cag.Agent_Alley = defaultString;
                            cag.Agent_Road = defaultString;
                            cag.Agent_Subdistrict = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                            cag.Agent_District = defaultString;
                            cag.Agent_Province = defaultString;
                            cag.Agent_Country = "ประเทศไทย";
                            cag.Agent_Zipcode = defaultString;
                            cag.Agent_Status = 1;

                            if (string.IsNullOrEmpty(chk_cag.Agent_id))
                            {
                                cag_mng.addAgent(cag);

                                Messages_Logs._writeSQLCodeInsertAgentsToMYSQL(cag, part);

                            }
                            else
                            {
                                cag.Agent_id = chk_cag.Agent_id;

                                cag_mng.editAgent(cag);

                                Messages_Logs._writeSQLCodeUpdateAgentsToMYSQL(cag, part);
                            }

                            cag_com.cag = new Agents();
                            cag_com.cag = cag;

                            double commission = Convert.ToDouble(reader.GetDecimal(49)); ; // ค่านายหน้า
                            double loss_com = Math.Ceiling(commission * (3 / 100)); // ค่าหัก ณ ที่จ่าย

                            cag_com.Agent_commission = commission;
                            cag_com.Agent_percen = 3; // % หัก ณ ที่จ่าย
                            cag_com.Agent_cash = loss_com;
                            cag_com.Agent_net_com = (commission - loss_com);
                            cag_com.Agent_num_code = defaultString;
                            cag_com.Agent_book_code = defaultString;
                            cag_com.Agent_date_print = null;

                            cag_com.Leasing_id = cls.Leasing_id;

                            cag_mng.addAgentCommission(cag_com);

                            Messages_Logs._writeSQLCodeInsertAgentsCommissionToMYSQL(cag_com, part);
                        }

                        Messages_TBx.Text += "Transfer Add Data Leasing Passed : " + row_index + Environment.NewLine;

                        row_index++;
                    }
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

                Messages_TBx.Text = "END TRANSFER DATAS LEASING " + Environment.NewLine;
            }
        }

        private void _loadGuarantor(int Guarantor_no)
        {
            SqlConnection con = MSSQLConnection.connectionMSSQL();

            int row_index = 1;
            int part = 1;

            try
            {
                con.Open();
                string sql = "  SELECT  cntr.personID AS idcard_00, cntr.title + cntr.fName AS Fname_01, cntr.lName AS Lname_02, cnt.cntID AS cntID_03, cnt.cntNoTemp AS Deps_No_04, cnt.cntNo AS Leasing_no_05";
                sql += "        FROM    dbo.Contract AS cnt INNER JOIN";
                sql += "                dbo.ContractRef AS cnt_ref ON cnt.cntID = cnt_ref.cntID AND cnt_ref.refNo = " + Guarantor_no + " LEFT OUTER JOIN";
                sql += "                dbo.Contractor AS cntr ON cnt_ref.personID = cntr.personID LEFT OUTER JOIN";
                sql += "                dbo.Car AS car ON cnt.cntID = car.cntID AND car.personID = cntr.personID LEFT OUTER JOIN";
                sql += "                dbo.Address AS add_c ON cntr.personID = add_c.personID AND add_c.addressType = 'C' LEFT OUTER JOIN";
                sql += "                dbo.Address AS add_h ON cntr.personID = add_h.personID AND add_h.addressType = 'H' LEFT OUTER JOIN";
                sql += "                dbo.Address AS add_n ON cntr.personID = add_n.personID AND add_n.addressType = 'N' LEFT OUTER JOIN";
                sql += "                dbo.Address AS add_job ON cntr.personID = add_job.personID AND add_job.addressType = 'O' LEFT OUTER JOIN";
                sql += "                dbo.Address AS add_marry ON cntr.personID = add_marry.personID AND add_marry.addressType = 'M' ";

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

                        ctm.Cust_Idcard_start = string.IsNullOrEmpty(ctm.Cust_Idcard_start) ? null : DateTimeUtility.convertDateToMYSQLRealServer(ctm.Cust_Idcard_start);
                        ctm.Cust_Idcard_expire = string.IsNullOrEmpty(ctm.Cust_Idcard_expire) ? null : DateTimeUtility.convertDateToMYSQLRealServer(ctm.Cust_Idcard_expire);
                    }

                    Car_Leasings cls = new Car_Leasings();

                    cls = cls_mng.getCarLeasingByDepsNo(reader.GetString(4), "");

                    cls.Leasing_date = string.IsNullOrEmpty(cls.Leasing_date) ? null : DateTimeUtility.convertDateToMYSQLRealServer(cls.Leasing_date);
                    cls.First_payment_date = string.IsNullOrEmpty(cls.First_payment_date) ? null : DateTimeUtility.convertDateToMYSQLRealServer(cls.First_payment_date);
                    cls.Car_register_date = string.IsNullOrEmpty(cls.Car_register_date) ? null : DateTimeUtility.convertDateToMYSQLRealServer(cls.Car_register_date);
                    cls.Car_next_register_date = string.IsNullOrEmpty(cls.Car_next_register_date) ? null : DateTimeUtility.convertDateToMYSQLRealServer(cls.Car_next_register_date);
                    cls.Car_old_owner_b_date = string.IsNullOrEmpty(cls.Car_old_owner_b_date) ? null : DateTimeUtility.convertDateToMYSQLRealServer(cls.Car_old_owner_b_date);
                    cls.Cheque_receive_date = string.IsNullOrEmpty(cls.Cheque_receive_date) ? null : DateTimeUtility.convertDateToMYSQLRealServer(cls.Cheque_receive_date);

                    Car_Leasings_Guarator cls_grt = new Car_Leasings_Guarator();

                    cls_grt.cls = new Car_Leasings();
                    cls_grt.cls = cls;

                    cls_grt.ctm = new Customers();
                    cls_grt.ctm = ctm;

                    cls_grt.Guarantor_no = Guarantor_no;

                    if (row_index % 5000 == 0) { part++; }

                    if (cls_grt_mng.checkDuplicateGuarantor(cls.Leasing_id, ctm.Cust_id, ctm.Cust_Idcard))
                    {

                        cls_grt_mng.editGuarantorsLeasing(cls_grt);

                        Messages_Logs._writeSQLCodeUpdateGuarantorLeasingsToMYSQL(cls_grt, part);
                    }
                    else
                    {
                        cls_grt_mng.addGuarantorsLeasing(cls_grt);

                        Messages_Logs._writeSQLCodeInsertGuarantorLeasingsToMYSQL(cls_grt, part);
                    }

                    row_index++;
                }
            }
            catch (SqlException ex)
            {
                error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_" + Guarantor_no + "() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor 1 Failed SqlException : " + row_index + " : " + ex + Environment.NewLine;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadGuarantor_" + Guarantor_no + "() ";
                Log_Error._writeErrorFile(error, ex);

                Messages_TBx.Text += "Transfer Data Guarantor " + Guarantor_no + " Failed Exception : " + row_index + " : " + ex + Environment.NewLine;
            }
            finally
            {
                con.Close();
                con.Dispose();

                Messages_TBx.Text = "END TRANSFER DATAS GUARANTOR " + Guarantor_no + Environment.NewLine;
            }
        }

        protected void Search_Index_of_Btn_Click(object sender, EventArgs e)
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
            Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

            List<Car_Leasings> list_cls_all = cls_mng.getCarLeasing("", "", "", "", "", "", "", "", "", "", "", 0, 0);

            for (int i = 0; i < list_cls_all.Count; i++)
            {
                Car_Leasings cls = new Car_Leasings();

                cls = list_cls_all[i];

                if (cls.Leasing_id == Leasing_id_TBx.Text)
                {
                    Index_of_TBx.Text = i.ToString();
                }

            }
        }

        protected void Start_Transfer_data_Btn_Click(object sender, EventArgs e)
        {
            _loadPaymentLeasing();
        }

        private void _getAllAmountRowsLeasing()
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
            Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

            List<Car_Leasings> list_cls_all = cls_mng.getCarLeasing("", "", "", "", "", "", "", "", "", "", "", 0, 0);

            Recond_Amount_TBx.Text = list_cls_all.Count.ToString();
        }

        private void _loadPaymentLeasing()
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
            Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

            List<Car_Leasings> list_cls_all = cls_mng.getCarLeasing("", "", "", "", "", "", "", "", "", "", "", 0, 0);

            int part = Convert.ToInt32(Part_TBx.Text);
            int str = Convert.ToInt32(Str_Row_TBx.Text);
            int end = Convert.ToInt32(End_Row_TBx.Text);

            for (int i = str; i < end; i++)
            {
                Car_Leasings cls = new Car_Leasings();

                cls = list_cls_all[i];

                int row_index = 1;

                SqlConnection con = MSSQLConnection.connectionMSSQL();

                if ((i + 1) % 1000 == 0) { part++; }

                List<Car_Leasings_Payment> list_cls_pay_shd = cls_pay_mng.getPaymentSchedule(cls.Leasing_id);

                Car_Leasings_Payment cls_pay_shd = list_cls_pay_shd[0];

                if (cls_pay_shd.Period_payment_status == 0)
                {

                    try
                    {
                        con.Open();

                        string sql = " SELECT * FROM  view_payment_byday WHERE cntNoTemp = '" + cls.Deps_no + "' AND cntNo = '" + cls.Leasing_no + "' ORDER BY scheduleno ";

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
                            cls_pay.Period_fee = defaultNum;
                            cls_pay.Total_payment_fine = reader.IsDBNull(5) ? defaultNum : Convert.ToDouble(reader.GetDecimal(5));
                            cls_pay.Period_track = reader.IsDBNull(7) ? defaultNum : Convert.ToDouble(reader.GetDecimal(7));
                            cls_pay.Discount = reader.IsDBNull(9) ? defaultNum : Convert.ToDouble(reader.GetDecimal(9));
                            cls_pay.Real_payment = reader.IsDBNull(4) ? defaultNum : Convert.ToDouble(reader.GetDecimal(4));

                            cls_pay.Real_payment_date = reader.IsDBNull(3) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(3).ToString());
                            cls_pay.acc_lgn = new Account_Login();

                            cls_pay.bs_cpn = new Base_Companys();

                            cls_pay.bs_cpn.Company_id = _MatchCompanys(reader.GetString(2));

                            Car_Leasings_Payment chk_cls_pay = cls_pay_mng.getRealPaymentInfofromBill(cls_pay.Leasing_id, cls_pay.Bill_no, cls_pay.Real_payment_date);

                            if (string.IsNullOrEmpty(chk_cls_pay.Bill_no))
                            {
                                if (cls_pay.Discount <= 0)
                                {
                                    if (cls_pay_mng.addPayment_Mod_I(cls_pay, 1))
                                    {
                                        Messages_Logs._writeSQLCodeInsertCarLeasingsPaymentToMYSQL(cls_pay, 1, part);
                                    }
                                    else
                                    {
                                        Messages_TBx.Text += "Transfer Data Payment 1 Failed : " + row_index + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    if (cls.Deps_no == "58100031")
                                    {
                                        cls_pay.Discount = 0.00;
                                        cls_pay.Total_payment_fine = reader.IsDBNull(9) ? defaultNum : Convert.ToDouble(reader.GetDecimal(9));

                                        if (cls_pay_mng.addPayment_Mod_I(cls_pay, 1))
                                        {
                                            Messages_Logs._writeSQLCodeInsertCarLeasingsPaymentToMYSQL(cls_pay, 1, part);
                                        }
                                        else
                                        {
                                            Messages_TBx.Text += "Transfer Data Payment 1 Failed : " + row_index + Environment.NewLine;
                                        }
                                    }
                                    else
                                    {
                                        if (cls_pay_mng.addPayment_Mod_I(cls_pay, 2))
                                        {
                                            Messages_Logs._writeSQLCodeInsertCarLeasingsPaymentToMYSQL(cls_pay, 2, part);
                                        }
                                        else
                                        {
                                            Messages_TBx.Text += "Transfer Data Payment 2 Failed : " + row_index + Environment.NewLine;
                                        }
                                    }
                                }
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

                        Messages_TBx.Text += " Transfer Data Payment Failed Exception : " + i + " / " + row_index + " / " + list_cls_all.Count + " : " + ex + Environment.NewLine;

                        break;
                    }
                    finally
                    {
                        con.Close();
                        con.Dispose();
                    }
                }

                Messages_Logs._writeSQLCodeCalPeriodFineToMYSQL(cls.Leasing_id, part);

                if (cls_pay_mng.calculateFine(cls.Leasing_id))
                {
                    //Messages_TBx.Text += "Transfer Data Payment Passed : " + i + Environment.NewLine;
                }
                else
                {
                    break;
                }

                GC.Collect();
            }

            Messages_TBx.Text = "END LOOP PAYMENTS : " + str + " - " + end + Environment.NewLine;
        }

        private void _loadFixFinePayment()
        {
            Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
            Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

            List<Car_Leasings> list_cls_all = cls_mng.getCarLeasing("", "", "", "", "", "", "", "", "", "", "", 0, 0);

            int part = Convert.ToInt32(Part_TBx.Text);
            int str = Convert.ToInt32(Str_Row_TBx.Text);
            int end = Convert.ToInt32(End_Row_TBx.Text);

            for (int i = str; i < end; i++)
            {
                Car_Leasings cls = new Car_Leasings();

                cls = list_cls_all[i];

                int row_index = 1;

                SqlConnection con = MSSQLConnection.connectionMSSQL();

                if ((i + 1) % 1000 == 0) { part++; }

                List<Car_Leasings_Payment> list_cls_pay_shd = cls_pay_mng.getPaymentSchedule(cls.Leasing_id);

                Car_Leasings_Payment cls_pay_shd = list_cls_pay_shd[0];

                if (cls_pay_shd.Period_payment_status == 0)
                {

                    try
                    {
                        con.Open();

                        string sql = " SELECT * FROM  view_payment_byday WHERE cntNoTemp = '" + cls.Deps_no + "' AND cntNo = '" + cls.Leasing_no + "' ORDER BY scheduleno ";

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
                            cls_pay.Total_payment_fine = reader.IsDBNull(5) ? defaultNum : Convert.ToDouble(reader.GetDecimal(5));

                            cls_pay.Real_payment_date = reader.IsDBNull(3) ? null : DateTimeUtility.convertDateToMYSQLRealServer(reader.GetDateTime(3).ToString());

                            if (cls.Deps_no == "58100031")
                            {
                                cls_pay.Discount = 0.00;
                                cls_pay.Total_payment_fine = reader.IsDBNull(9) ? defaultNum : Convert.ToDouble(reader.GetDecimal(9));

                                if (cls_pay_mng.fixUpdtaeFine(cls_pay))
                                {
                                    Messages_Logs._writeSQLCodeFixFinePaymentToMYSQL(cls_pay, part);
                                }
                                else
                                {
                                    Messages_TBx.Text += "Fix Transfer Data Payment Failed : " + row_index + Environment.NewLine;
                                }
                            }
                            else
                            {
                                if (cls_pay_mng.fixUpdtaeFine(cls_pay))
                                {
                                    Messages_Logs._writeSQLCodeFixFinePaymentToMYSQL(cls_pay, part);
                                }
                                else
                                {
                                    Messages_TBx.Text += "Fix Transfer Data Payment Failed : " + row_index + Environment.NewLine;
                                }
                            }

                            row_index++;
                        }
                    }
                    catch (SqlException ex)
                    {
                        error = "SqlException ==> Form_Account --> Load_Data_From_MSSQL --> _loadFixFinePayment() ";
                        Log_Error._writeErrorFile(error, ex);

                        Messages_TBx.Text += "Fix Transfer Data Payment Failed SqlException : " + i + " / " + row_index + " / " + list_cls_all.Count + " : " + ex + Environment.NewLine;

                        break;
                    }
                    catch (Exception ex)
                    {
                        error = "Exception ==> Form_Account --> Load_Data_From_MSSQL --> _loadFixFinePayment() ";
                        Log_Error._writeErrorFile(error, ex);

                        Messages_TBx.Text += "Fix Transfer Data Payment Failed Exception : " + i + " / " + row_index + " / " + list_cls_all.Count + " : " + ex + Environment.NewLine;

                        break;
                    }
                    finally
                    {
                        con.Close();
                        con.Dispose();
                    }
                }

                GC.Collect();
            }

            Messages_TBx.Text = "END LOOP FIX FINE PAYMENTS : " + str + " - " + end + Environment.NewLine;
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
            int result = 1;
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
            int result = 1;
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
            int result = 2;
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


        private int _MatchCompanys(string company)
        {
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(0, 0);

            int result = 1;

            if (company != "-" && company != "")
            {
                if (company.IndexOf("-") >= 1)
                {
                    string com_code = company.Split('-')[0];

                    for (int i = 0; i < list_data.Count; i++)
                    {
                        Base_Companys data = list_data[i];

                        if (data.Company_N_name == com_code || data.Company_code == com_code)
                        {
                            result = data.Company_id;
                        }
                    }
                }
            }

            return result;
        }


    }
}