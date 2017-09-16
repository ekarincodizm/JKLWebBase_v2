using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;


namespace JKLWebBase_v2.Managers_Customers
{
    public class Customers_Manager
    {
        private string error;

        public string generateCustomerID()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM v_getcustomerid ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                string id = "";
                if (reader.Read())
                {
                    id = reader.IsDBNull(0) ? "" : reader.GetString(0);
                }

                return id;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> generateCustomerID() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> generateCustomerID() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Customers> getCustomers(string idcard, string fname, string lname, int i_row_str, int i_row_limit)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_customers ] :: 
                 * g_customers (in i_Cust_idcard varchar(30), in i_Cust_Fname varchar(255), in i_Cust_LName varchar(255), IN i_row_str INT(11), IN i_row_limit INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_idcard", idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", lname);
                cmd.Parameters.AddWithValue("@i_row_str", i_row_str);
                cmd.Parameters.AddWithValue("@i_row_limit", i_row_limit);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Customers> list_ctm = new List<Customers>();

                while (reader.Read())
                {
                    Customers ctm = new Customers();

                    int defaultNum = 0;
                    string defaultString = "";

                    ctm.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    ctm.Cust_Idcard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    ctm.Cust_Fname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    ctm.Cust_LName = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    ctm.Cust_B_date = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    ctm.Cust_Age = reader.IsDBNull(5) ? defaultNum : reader.GetInt32(5);
                    ctm.Cust_Idcard_without = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    ctm.Cust_Idcard_start = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    ctm.Cust_Idcard_expire = reader.IsDBNull(8) ? defaultString : reader.GetString(8);

                    ctm.ctm_ntnlt = new Base_Nationalitys();
                    ctm.ctm_ntnlt.Nationality_id = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9);
                    ctm.ctm_ntnlt.Nationality_name_ENG = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    ctm.ctm_ntnlt.Nationality_name_TH = reader.IsDBNull(11) ? defaultString : reader.GetString(11);

                    ctm.ctm_org = new Base_Origins();
                    ctm.ctm_org.Origin_id = reader.IsDBNull(12) ? defaultNum : reader.GetInt32(12);
                    ctm.ctm_org.Origin_name_ENG = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    ctm.ctm_org.Origin_name_TH = reader.IsDBNull(14) ? defaultString : reader.GetString(14);

                    ctm.Cust_Tel = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    ctm.Cust_Email = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    ctm.ctm_pstt = new Base_Person_Status();
                    ctm.ctm_pstt.person_status_id = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17);
                    ctm.ctm_pstt.person_status_name = reader.IsDBNull(18) ? defaultString : reader.GetString(18);

                    ctm.Cust_Marry_idcard = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    ctm.Cust_Marry_Fname = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    ctm.Cust_Marry_Lname = reader.IsDBNull(21) ? defaultString : reader.GetString(21);

                    ctm.ctm_marry_ntnlt = new Base_Nationalitys();
                    ctm.ctm_marry_ntnlt.Nationality_id = reader.IsDBNull(22) ? defaultNum : reader.GetInt32(22);
                    ctm.ctm_marry_ntnlt.Nationality_name_ENG = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    ctm.ctm_marry_ntnlt.Nationality_name_TH = reader.IsDBNull(24) ? defaultString : reader.GetString(24);

                    ctm.ctm_marry_org = new Base_Origins();
                    ctm.ctm_marry_org.Origin_id = reader.IsDBNull(25) ? defaultNum : reader.GetInt32(25);
                    ctm.ctm_marry_org.Origin_name_ENG = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    ctm.ctm_marry_org.Origin_name_TH = reader.IsDBNull(27) ? defaultString : reader.GetString(27);

                    ctm.Cust_Marry_Address_no = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    ctm.Cust_Marry_vilage = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    ctm.Cust_Marry_vilage_no = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    ctm.Cust_Marry_alley = reader.IsDBNull(31) ? defaultString : reader.GetString(31);
                    ctm.Cust_Marry_road = reader.IsDBNull(32) ? defaultString : reader.GetString(32);
                    ctm.Cust_Marry_subdistrict = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    ctm.Cust_Marry_district = reader.IsDBNull(34) ? defaultString : reader.GetString(34);
                    ctm.Cust_Marry_province = reader.IsDBNull(35) ? defaultString : reader.GetString(35);
                    ctm.Cust_Marry_country = reader.IsDBNull(36) ? defaultString : reader.GetString(36);
                    ctm.Cust_Marry_zipcode = reader.IsDBNull(37) ? defaultString : reader.GetString(37);
                    ctm.Cust_Marry_tel = reader.IsDBNull(38) ? defaultString : reader.GetString(38);
                    ctm.Cust_Marry_email = reader.IsDBNull(39) ? defaultString : reader.GetString(39);

                    ctm.Cust_Marry_job = reader.IsDBNull(40) ? defaultString : reader.GetString(40);
                    ctm.Cust_Marry_job_position = reader.IsDBNull(41) ? defaultString : reader.GetString(41);
                    ctm.Cust_Marry_job_long = reader.IsDBNull(42) ? defaultNum : reader.GetInt32(42);
                    ctm.Cust_Marry_job_salary = reader.IsDBNull(43) ? defaultNum : reader.GetDouble(43);
                    ctm.Cust_Marry_job_local_name = reader.IsDBNull(44) ? defaultString : reader.GetString(44);
                    ctm.Cust_Marry_job_address_no = reader.IsDBNull(45) ? defaultString : reader.GetString(45);
                    ctm.Cust_Marry_job_vilage = reader.IsDBNull(46) ? defaultString : reader.GetString(46);
                    ctm.Cust_Marry_job_vilage_no = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                    ctm.Cust_Marry_job_alley = reader.IsDBNull(48) ? defaultString : reader.GetString(48);
                    ctm.Cust_Marry_job_road = reader.IsDBNull(49) ? defaultString : reader.GetString(49);
                    ctm.Cust_Marry_job_subdistrict = reader.IsDBNull(50) ? defaultString : reader.GetString(50);
                    ctm.Cust_Marry_job_district = reader.IsDBNull(51) ? defaultString : reader.GetString(51);
                    ctm.Cust_Marry_job_province = reader.IsDBNull(52) ? defaultString : reader.GetString(52);
                    ctm.Cust_Marry_job_country = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                    ctm.Cust_Marry_job_zipcode = reader.IsDBNull(54) ? defaultString : reader.GetString(54);
                    ctm.Cust_Marry_job_tel = reader.IsDBNull(55) ? defaultString : reader.GetString(55);

                    ctm.Cust_Job = reader.IsDBNull(56) ? defaultString : reader.GetString(56);
                    ctm.Cust_Job_position = reader.IsDBNull(57) ? defaultString : reader.GetString(57);
                    ctm.Cust_Job_long = reader.IsDBNull(58) ? defaultNum : reader.GetInt32(58);
                    ctm.Cust_Job_salary = reader.IsDBNull(59) ? defaultNum : reader.GetDouble(59);
                    ctm.Cust_Job_local_name = reader.IsDBNull(60) ? defaultString : reader.GetString(60);
                    ctm.Cust_Job_address_no = reader.IsDBNull(61) ? defaultString : reader.GetString(61);
                    ctm.Cust_Job_vilage = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    ctm.Cust_Job_vilage_no = reader.IsDBNull(63) ? defaultString : reader.GetString(63);
                    ctm.Cust_Job_alley = reader.IsDBNull(64) ? defaultString : reader.GetString(64);
                    ctm.Cust_Job_road = reader.IsDBNull(65) ? defaultString : reader.GetString(65);
                    ctm.Cust_Job_subdistrict = reader.IsDBNull(66) ? defaultString : reader.GetString(66);
                    ctm.Cust_Job_district = reader.IsDBNull(67) ? defaultString : reader.GetString(67);
                    ctm.Cust_Job_province = reader.IsDBNull(68) ? defaultString : reader.GetString(68);
                    ctm.Cust_Job_country = reader.IsDBNull(69) ? defaultString : reader.GetString(69);
                    ctm.Cust_Job_zipcode = reader.IsDBNull(70) ? defaultString : reader.GetString(70);
                    ctm.Cust_Job_tel = reader.IsDBNull(71) ? defaultString : reader.GetString(71);
                    ctm.Cust_Job_email = reader.IsDBNull(72) ? defaultString : reader.GetString(72);

                    ctm.Cust_Home_address_no = reader.IsDBNull(73) ? defaultString : reader.GetString(73);
                    ctm.Cust_Home_vilage = reader.IsDBNull(74) ? defaultString : reader.GetString(74);
                    ctm.Cust_Home_vilage_no = reader.IsDBNull(75) ? defaultString : reader.GetString(75);
                    ctm.Cust_Home_alley = reader.IsDBNull(76) ? defaultString : reader.GetString(76);
                    ctm.Cust_Home_road = reader.IsDBNull(77) ? defaultString : reader.GetString(77);
                    ctm.Cust_Home_subdistrict = reader.IsDBNull(78) ? defaultString : reader.GetString(78);
                    ctm.Cust_Home_district = reader.IsDBNull(79) ? defaultString : reader.GetString(79);
                    ctm.Cust_Home_province = reader.IsDBNull(80) ? defaultString : reader.GetString(80);
                    ctm.Cust_Home_country = reader.IsDBNull(81) ? defaultString : reader.GetString(81);
                    ctm.Cust_Home_zipcode = reader.IsDBNull(82) ? defaultString : reader.GetString(82);
                    ctm.Cust_Home_tel = reader.IsDBNull(83) ? defaultString : reader.GetString(83);
                    ctm.Cust_Home_GPS_Latitude = reader.IsDBNull(84) ? defaultString : reader.GetString(84);
                    ctm.Cust_Home_GPS_Longitude = reader.IsDBNull(85) ? defaultString : reader.GetString(85);

                    ctm.ctm_home_stt = new Base_Home_Status();
                    ctm.ctm_home_stt.Home_status_id = reader.IsDBNull(86) ? defaultNum : reader.GetInt32(86);
                    ctm.ctm_home_stt.Home_status_name = reader.IsDBNull(87) ? defaultString : reader.GetString(87);

                    ctm.Cust_Idcard_address_no = reader.IsDBNull(88) ? defaultString : reader.GetString(88);
                    ctm.Cust_Idcard_vilage = reader.IsDBNull(89) ? defaultString : reader.GetString(89);
                    ctm.Cust_Idcard_vilage_no = reader.IsDBNull(90) ? defaultString : reader.GetString(90);
                    ctm.Cust_Idcard_alley = reader.IsDBNull(91) ? defaultString : reader.GetString(91);
                    ctm.Cust_Idcard_road = reader.IsDBNull(92) ? defaultString : reader.GetString(92);
                    ctm.Cust_Idcard_subdistrict = reader.IsDBNull(93) ? defaultString : reader.GetString(93);
                    ctm.Cust_Idcard_district = reader.IsDBNull(94) ? defaultString : reader.GetString(94);
                    ctm.Cust_Idcard_province = reader.IsDBNull(95) ? defaultString : reader.GetString(95);
                    ctm.Cust_Idcard_country = reader.IsDBNull(96) ? defaultString : reader.GetString(96);
                    ctm.Cust_Idcard_zipcode = reader.IsDBNull(97) ? defaultString : reader.GetString(97);
                    ctm.Cust_Idcard_tel = reader.IsDBNull(98) ? defaultString : reader.GetString(98);

                    ctm.ctm_idcard_stt = new Base_Home_Status();
                    ctm.ctm_idcard_stt.Home_status_id = reader.IsDBNull(99) ? defaultNum : reader.GetInt32(99);
                    ctm.ctm_idcard_stt.Home_status_name = reader.IsDBNull(100) ? defaultString : reader.GetString(100);

                    ctm.Cust_Current_address_no = reader.IsDBNull(101) ? defaultString : reader.GetString(101);
                    ctm.Cust_Current_vilage = reader.IsDBNull(102) ? defaultString : reader.GetString(102);
                    ctm.Cust_Current_vilage_no = reader.IsDBNull(103) ? defaultString : reader.GetString(103);
                    ctm.Cust_Current_alley = reader.IsDBNull(104) ? defaultString : reader.GetString(104);
                    ctm.Cust_Current_road = reader.IsDBNull(105) ? defaultString : reader.GetString(105);
                    ctm.Cust_Current_subdistrict = reader.IsDBNull(106) ? defaultString : reader.GetString(106);
                    ctm.Cust_Current_district = reader.IsDBNull(107) ? defaultString : reader.GetString(107);
                    ctm.Cust_Current_province = reader.IsDBNull(108) ? defaultString : reader.GetString(108);
                    ctm.Cust_Current_country = reader.IsDBNull(109) ? defaultString : reader.GetString(109);
                    ctm.Cust_Current_zipcode = reader.IsDBNull(110) ? defaultString : reader.GetString(110);
                    ctm.Cust_Current_tel = reader.IsDBNull(111) ? defaultString : reader.GetString(111);

                    ctm.ctm_current_stt = new Base_Home_Status();
                    ctm.ctm_current_stt.Home_status_id = reader.IsDBNull(112) ? defaultNum : reader.GetInt32(112);
                    ctm.ctm_current_stt.Home_status_name = reader.IsDBNull(113) ? defaultString : reader.GetString(113);

                    ctm.Cust_save_date = reader.IsDBNull(114) ? defaultString : reader.GetString(114);

                    list_ctm.Add(ctm);
                }

                return list_ctm;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomers() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomers() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Customers getCustomersByIdCard(string idcard)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_customers_by_idcard ] :: 
                 * g_customers_by_idcard (in i_Cust_idcard varchar(13))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers_by_idcard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_idcard", idcard);

                MySqlDataReader reader = cmd.ExecuteReader();

                Customers ctm = new Customers();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    ctm.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    ctm.Cust_Idcard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    ctm.Cust_Fname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    ctm.Cust_LName = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    ctm.Cust_B_date = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    ctm.Cust_Age = reader.IsDBNull(5) ? defaultNum : reader.GetInt32(5);
                    ctm.Cust_Idcard_without = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    ctm.Cust_Idcard_start = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    ctm.Cust_Idcard_expire = reader.IsDBNull(8) ? defaultString : reader.GetString(8);

                    ctm.ctm_ntnlt = new Base_Nationalitys();
                    ctm.ctm_ntnlt.Nationality_id = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9);
                    ctm.ctm_ntnlt.Nationality_name_ENG = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    ctm.ctm_ntnlt.Nationality_name_TH = reader.IsDBNull(11) ? defaultString : reader.GetString(11);

                    ctm.ctm_org = new Base_Origins();
                    ctm.ctm_org.Origin_id = reader.IsDBNull(12) ? defaultNum : reader.GetInt32(12);
                    ctm.ctm_org.Origin_name_ENG = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    ctm.ctm_org.Origin_name_TH = reader.IsDBNull(14) ? defaultString : reader.GetString(14);

                    ctm.Cust_Tel = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    ctm.Cust_Email = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    ctm.ctm_pstt = new Base_Person_Status();
                    ctm.ctm_pstt.person_status_id = reader.IsDBNull(17) ? defaultNum : reader.GetInt32(17);
                    ctm.ctm_pstt.person_status_name = reader.IsDBNull(18) ? defaultString : reader.GetString(18);

                    ctm.Cust_Marry_idcard = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    ctm.Cust_Marry_Fname = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    ctm.Cust_Marry_Lname = reader.IsDBNull(21) ? defaultString : reader.GetString(21);

                    ctm.ctm_marry_ntnlt = new Base_Nationalitys();
                    ctm.ctm_marry_ntnlt.Nationality_id = reader.IsDBNull(22) ? defaultNum : reader.GetInt32(22);
                    ctm.ctm_marry_ntnlt.Nationality_name_ENG = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    ctm.ctm_marry_ntnlt.Nationality_name_TH = reader.IsDBNull(24) ? defaultString : reader.GetString(24);

                    ctm.ctm_marry_org = new Base_Origins();
                    ctm.ctm_marry_org.Origin_id = reader.IsDBNull(25) ? defaultNum : reader.GetInt32(25);
                    ctm.ctm_marry_org.Origin_name_ENG = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    ctm.ctm_marry_org.Origin_name_TH = reader.IsDBNull(27) ? defaultString : reader.GetString(27);

                    ctm.Cust_Marry_Address_no = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    ctm.Cust_Marry_vilage = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    ctm.Cust_Marry_vilage_no = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    ctm.Cust_Marry_alley = reader.IsDBNull(31) ? defaultString : reader.GetString(31);
                    ctm.Cust_Marry_road = reader.IsDBNull(32) ? defaultString : reader.GetString(32);
                    ctm.Cust_Marry_subdistrict = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    ctm.Cust_Marry_district = reader.IsDBNull(34) ? defaultString : reader.GetString(34);
                    ctm.Cust_Marry_province = reader.IsDBNull(35) ? defaultString : reader.GetString(35);
                    ctm.Cust_Marry_country = reader.IsDBNull(36) ? defaultString : reader.GetString(36);
                    ctm.Cust_Marry_zipcode = reader.IsDBNull(37) ? defaultString : reader.GetString(37);
                    ctm.Cust_Marry_tel = reader.IsDBNull(38) ? defaultString : reader.GetString(38);
                    ctm.Cust_Marry_email = reader.IsDBNull(39) ? defaultString : reader.GetString(39);

                    ctm.Cust_Marry_job = reader.IsDBNull(40) ? defaultString : reader.GetString(40);
                    ctm.Cust_Marry_job_position = reader.IsDBNull(41) ? defaultString : reader.GetString(41);
                    ctm.Cust_Marry_job_long = reader.IsDBNull(42) ? defaultNum : reader.GetInt32(42);
                    ctm.Cust_Marry_job_salary = reader.IsDBNull(43) ? defaultNum : reader.GetDouble(43);
                    ctm.Cust_Marry_job_local_name = reader.IsDBNull(44) ? defaultString : reader.GetString(44);
                    ctm.Cust_Marry_job_address_no = reader.IsDBNull(45) ? defaultString : reader.GetString(45);
                    ctm.Cust_Marry_job_vilage = reader.IsDBNull(46) ? defaultString : reader.GetString(46);
                    ctm.Cust_Marry_job_vilage_no = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                    ctm.Cust_Marry_job_alley = reader.IsDBNull(48) ? defaultString : reader.GetString(48);
                    ctm.Cust_Marry_job_road = reader.IsDBNull(49) ? defaultString : reader.GetString(49);
                    ctm.Cust_Marry_job_subdistrict = reader.IsDBNull(50) ? defaultString : reader.GetString(50);
                    ctm.Cust_Marry_job_district = reader.IsDBNull(51) ? defaultString : reader.GetString(51);
                    ctm.Cust_Marry_job_province = reader.IsDBNull(52) ? defaultString : reader.GetString(52);
                    ctm.Cust_Marry_job_country = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                    ctm.Cust_Marry_job_zipcode = reader.IsDBNull(54) ? defaultString : reader.GetString(54);
                    ctm.Cust_Marry_job_tel = reader.IsDBNull(55) ? defaultString : reader.GetString(55);

                    ctm.Cust_Job = reader.IsDBNull(56) ? defaultString : reader.GetString(56);
                    ctm.Cust_Job_position = reader.IsDBNull(57) ? defaultString : reader.GetString(57);
                    ctm.Cust_Job_long = reader.IsDBNull(58) ? defaultNum : reader.GetInt32(58);
                    ctm.Cust_Job_salary = reader.IsDBNull(59) ? defaultNum : reader.GetDouble(59);
                    ctm.Cust_Job_local_name = reader.IsDBNull(60) ? defaultString : reader.GetString(60);
                    ctm.Cust_Job_address_no = reader.IsDBNull(61) ? defaultString : reader.GetString(61);
                    ctm.Cust_Job_vilage = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    ctm.Cust_Job_vilage_no = reader.IsDBNull(63) ? defaultString : reader.GetString(63);
                    ctm.Cust_Job_alley = reader.IsDBNull(64) ? defaultString : reader.GetString(64);
                    ctm.Cust_Job_road = reader.IsDBNull(65) ? defaultString : reader.GetString(65);
                    ctm.Cust_Job_subdistrict = reader.IsDBNull(66) ? defaultString : reader.GetString(66);
                    ctm.Cust_Job_district = reader.IsDBNull(67) ? defaultString : reader.GetString(67);
                    ctm.Cust_Job_province = reader.IsDBNull(68) ? defaultString : reader.GetString(68);
                    ctm.Cust_Job_country = reader.IsDBNull(69) ? defaultString : reader.GetString(69);
                    ctm.Cust_Job_zipcode = reader.IsDBNull(70) ? defaultString : reader.GetString(70);
                    ctm.Cust_Job_tel = reader.IsDBNull(71) ? defaultString : reader.GetString(71);
                    ctm.Cust_Job_email = reader.IsDBNull(72) ? defaultString : reader.GetString(72);

                    ctm.Cust_Home_address_no = reader.IsDBNull(73) ? defaultString : reader.GetString(73);
                    ctm.Cust_Home_vilage = reader.IsDBNull(74) ? defaultString : reader.GetString(74);
                    ctm.Cust_Home_vilage_no = reader.IsDBNull(75) ? defaultString : reader.GetString(75);
                    ctm.Cust_Home_alley = reader.IsDBNull(76) ? defaultString : reader.GetString(76);
                    ctm.Cust_Home_road = reader.IsDBNull(77) ? defaultString : reader.GetString(77);
                    ctm.Cust_Home_subdistrict = reader.IsDBNull(78) ? defaultString : reader.GetString(78);
                    ctm.Cust_Home_district = reader.IsDBNull(79) ? defaultString : reader.GetString(79);
                    ctm.Cust_Home_province = reader.IsDBNull(80) ? defaultString : reader.GetString(80);
                    ctm.Cust_Home_country = reader.IsDBNull(81) ? defaultString : reader.GetString(81);
                    ctm.Cust_Home_zipcode = reader.IsDBNull(82) ? defaultString : reader.GetString(82);
                    ctm.Cust_Home_tel = reader.IsDBNull(83) ? defaultString : reader.GetString(83);
                    ctm.Cust_Home_GPS_Latitude = reader.IsDBNull(84) ? defaultString : reader.GetString(84);
                    ctm.Cust_Home_GPS_Longitude = reader.IsDBNull(85) ? defaultString : reader.GetString(85);

                    ctm.ctm_home_stt = new Base_Home_Status();
                    ctm.ctm_home_stt.Home_status_id = reader.IsDBNull(86) ? defaultNum : reader.GetInt32(86);
                    ctm.ctm_home_stt.Home_status_name = reader.IsDBNull(87) ? defaultString : reader.GetString(87);

                    ctm.Cust_Idcard_address_no = reader.IsDBNull(88) ? defaultString : reader.GetString(88);
                    ctm.Cust_Idcard_vilage = reader.IsDBNull(89) ? defaultString : reader.GetString(89);
                    ctm.Cust_Idcard_vilage_no = reader.IsDBNull(90) ? defaultString : reader.GetString(90);
                    ctm.Cust_Idcard_alley = reader.IsDBNull(91) ? defaultString : reader.GetString(91);
                    ctm.Cust_Idcard_road = reader.IsDBNull(92) ? defaultString : reader.GetString(92);
                    ctm.Cust_Idcard_subdistrict = reader.IsDBNull(93) ? defaultString : reader.GetString(93);
                    ctm.Cust_Idcard_district = reader.IsDBNull(94) ? defaultString : reader.GetString(94);
                    ctm.Cust_Idcard_province = reader.IsDBNull(95) ? defaultString : reader.GetString(95);
                    ctm.Cust_Idcard_country = reader.IsDBNull(96) ? defaultString : reader.GetString(96);
                    ctm.Cust_Idcard_zipcode = reader.IsDBNull(97) ? defaultString : reader.GetString(97);
                    ctm.Cust_Idcard_tel = reader.IsDBNull(98) ? defaultString : reader.GetString(98);

                    ctm.ctm_idcard_stt = new Base_Home_Status();
                    ctm.ctm_idcard_stt.Home_status_id = reader.IsDBNull(99) ? defaultNum : reader.GetInt32(99);
                    ctm.ctm_idcard_stt.Home_status_name = reader.IsDBNull(100) ? defaultString : reader.GetString(100);

                    ctm.Cust_Current_address_no = reader.IsDBNull(101) ? defaultString : reader.GetString(101);
                    ctm.Cust_Current_vilage = reader.IsDBNull(102) ? defaultString : reader.GetString(102);
                    ctm.Cust_Current_vilage_no = reader.IsDBNull(103) ? defaultString : reader.GetString(103);
                    ctm.Cust_Current_alley = reader.IsDBNull(104) ? defaultString : reader.GetString(104);
                    ctm.Cust_Current_road = reader.IsDBNull(105) ? defaultString : reader.GetString(105);
                    ctm.Cust_Current_subdistrict = reader.IsDBNull(106) ? defaultString : reader.GetString(106);
                    ctm.Cust_Current_district = reader.IsDBNull(107) ? defaultString : reader.GetString(107);
                    ctm.Cust_Current_province = reader.IsDBNull(108) ? defaultString : reader.GetString(108);
                    ctm.Cust_Current_country = reader.IsDBNull(109) ? defaultString : reader.GetString(109);
                    ctm.Cust_Current_zipcode = reader.IsDBNull(110) ? defaultString : reader.GetString(110);
                    ctm.Cust_Current_tel = reader.IsDBNull(111) ? defaultString : reader.GetString(111);

                    ctm.ctm_current_stt = new Base_Home_Status();
                    ctm.ctm_current_stt.Home_status_id = reader.IsDBNull(112) ? defaultNum : reader.GetInt32(112);
                    ctm.ctm_current_stt.Home_status_name = reader.IsDBNull(113) ? defaultString : reader.GetString(113);

                    ctm.Cust_save_date = reader.IsDBNull(114) ? defaultString : reader.GetString(114);
                }

                return ctm;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomersByIdCard() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomersByIdCard() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addCustomers(Customers ctm)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_customers ] :: 
                 * i_customers ( IN i_Cust_id VARCHAR(50), IN i_Cust_Idcard VARCHAR(20), IN i_Cust_Fname VARCHAR(255), IN i_Cust_LName VARCHAR(255),
	             *   IN i_Cust_B_date DATE, IN i_Cust_Age INT(11), IN i_Cust_Idcard_without VARCHAR(255), IN i_Cust_Idcard_start DATE,
	             *   IN i_Cust_Idcard_expire DATE, IN i_Cust_Nationality_id INT(11), IN i_Cust_Origin_id INT(11), IN i_Cust_Tel VARCHAR(255),
	             *   IN i_Cust_Email VARCHAR(255), IN i_Cust_Status_id INT(11), IN i_Cust_Marry_idcard VARCHAR(20), IN i_Cust_Marry_Fname VARCHAR(255),
	             *   IN i_Cust_Marry_Lname VARCHAR(255), IN i_Cust_Marry_Nationality INT(11), IN i_Cust_Marry_Origin INT(11), IN i_Cust_Marry_Address_no VARCHAR(255),
	             *   IN i_Cust_Marry_vilage VARCHAR(255), IN i_Cust_Marry_vilage_no VARCHAR(255), IN i_Cust_Marry_alley VARCHAR(255), IN i_Cust_Marry_road VARCHAR(255),
	             *   IN i_Cust_Marry_subdistrict VARCHAR(255), IN i_Cust_Marry_district VARCHAR(255), IN i_Cust_Marry_province_id INT(11), IN i_Cust_Marry_country VARCHAR(255),
	             *   IN i_Cust_Marry_zipcode VARCHAR(255), IN i_Cust_Marry_tel VARCHAR(255), IN i_Cust_Marry_email VARCHAR(255), IN i_Cust_Marry_job VARCHAR(255),
	             *   IN i_Cust_Marry_job_position VARCHAR(255), IN i_Cust_Marry_job_long INT(11), IN i_Cust_Marry_job_salary DOUBLE(10,2), IN i_Cust_Marry_job_local_name VARCHAR(255),
	             *   IN i_Cust_Marry_job_address_no VARCHAR(255), IN i_Cust_Marry_job_vilage VARCHAR(255), IN i_Cust_Marry_job_vilage_no VARCHAR(255), IN i_Cust_Marry_job_alley VARCHAR(255),
	             *   IN i_Cust_Marry_job_road VARCHAR(255), IN i_Cust_Marry_job_subdistrict VARCHAR(255), IN i_Cust_Marry_job_district VARCHAR(255), IN i_Cust_Marry_job_province_id INT(11),
	             *   IN i_Cust_Marry_job_zipcode VARCHAR(255), IN i_Cust_Marry_job_tel VARCHAR(255), IN i_Cust_Job VARCHAR(255), IN i_Cust_Job_position VARCHAR(255),
	             *   IN i_Cust_Job_long INT(11), IN i_Cust_Job_salary DOUBLE(10,2), IN i_Cust_Job_local_name VARCHAR(255), IN i_Cust_Job_address_no VARCHAR(255),
	             *   IN i_Cust_Job_vilage VARCHAR(255), IN i_Cust_Job_vilage_no VARCHAR(255), IN i_Cust_Job_alley VARCHAR(255), IN i_Cust_Job_road VARCHAR(255),
	             *   IN i_Cust_Job_subdistrict VARCHAR(255), IN i_Cust_Job_district VARCHAR(255), IN i_Cust_Job_province_id INT(11), IN i_Cust_Job_country VARCHAR(255),
	             *   IN i_Cust_Job_zipcode VARCHAR(255), IN i_Cust_Job_tel VARCHAR(255), IN i_Cust_Job_email VARCHAR(255), IN i_Cust_Home_address_no VARCHAR(255),
	             *   IN i_Cust_Home_vilage VARCHAR(255), IN i_Cust_Home_vilage_no VARCHAR(255), IN i_Cust_Home_alley VARCHAR(255), IN i_Cust_Home_road VARCHAR(255),
	             *   IN i_Cust_Home_subdistrict VARCHAR(255), IN i_Cust_Home_district VARCHAR(255), IN i_Cust_Home_province_id INT(11), IN i_Cust_Home_country VARCHAR(255),
	             *   IN i_Cust_Home_zipcode VARCHAR(255), IN i_Cust_Home_tel VARCHAR(255), IN i_Cust_Home_GPS_Latitude VARCHAR(255), IN i_Cust_Home_GPS_Longitude VARCHAR(255),
	             *   IN i_Cust_Home_Status_id INT(11), IN i_Cust_Idcard_address_no VARCHAR(255), IN i_Cust_Idcard_vilage VARCHAR(255), IN i_Cust_Idcard_vilage_no VARCHAR(255),
	             *   IN i_Cust_Idcard_alley VARCHAR(255), IN i_Cust_Idcard_road VARCHAR(255), IN i_Cust_Idcard_subdistrict VARCHAR(255), IN i_Cust_Idcard_district VARCHAR(255),
	             *   IN i_Cust_Idcard_province_id INT(11), IN i_Cust_Idcard_country VARCHAR(255), IN i_Cust_Idcard_zipcode VARCHAR(255), IN i_Cust_Idcard_tel VARCHAR(255),
	             *   IN i_Cust_Idcard_Status_id INT(11), IN i_Cust_Current_address_no VARCHAR(255), IN i_Cust_Current_vilage VARCHAR(255), IN i_Cust_Current_vilage_no VARCHAR(255),
	             *   IN i_Cust_Current_alley VARCHAR(255), IN i_Cust_Current_road VARCHAR(255), IN i_Cust_Current_subdistrict VARCHAR(255), IN i_Cust_Current_district VARCHAR(255),
	             *   IN i_Cust_Current_province_id INT(11), IN i_Cust_Current_country VARCHAR(255), IN i_Cust_Current_zipcode VARCHAR(255), IN i_Cust_Current_tel VARCHAR(255),
	             *   IN i_Cust_Current_Status_id INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_customers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Cust_id", ctm.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard", ctm.Cust_Idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", ctm.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", ctm.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", ctm.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_Age", ctm.Cust_Age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", ctm.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", ctm.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", ctm.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality_id", ctm.ctm_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Origin_id", ctm.ctm_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Tel", ctm.Cust_Tel);
                cmd.Parameters.AddWithValue("@i_Cust_Email", ctm.Cust_Email);
                cmd.Parameters.AddWithValue("@i_Cust_Status_id", ctm.ctm_pstt.person_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_idcard", ctm.Cust_Marry_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Fname", ctm.Cust_Marry_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Lname", ctm.Cust_Marry_Lname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Nationality", ctm.ctm_marry_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Origin", ctm.ctm_marry_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Address_no", ctm.Cust_Marry_Address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage", ctm.Cust_Marry_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage_no", ctm.Cust_Marry_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_alley", ctm.Cust_Marry_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_road", ctm.Cust_Marry_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_subdistrict", ctm.Cust_Marry_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_district", ctm.Cust_Marry_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province", ctm.Cust_Marry_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_country", ctm.Cust_Marry_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_zipcode", ctm.Cust_Marry_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_tel", ctm.Cust_Marry_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_email", ctm.Cust_Marry_email);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job", ctm.Cust_Marry_job);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_position", ctm.Cust_Marry_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_long", ctm.Cust_Marry_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_salary", ctm.Cust_Marry_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_local_name", ctm.Cust_Marry_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_address_no", ctm.Cust_Marry_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage", ctm.Cust_Marry_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage_no", ctm.Cust_Marry_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_alley", ctm.Cust_Marry_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_road", ctm.Cust_Marry_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_subdistrict", ctm.Cust_Marry_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_district", ctm.Cust_Marry_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province", ctm.Cust_Marry_job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_country", ctm.Cust_Marry_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_zipcode", ctm.Cust_Marry_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_tel", ctm.Cust_Marry_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job", ctm.Cust_Job);
                cmd.Parameters.AddWithValue("@i_Cust_Job_position", ctm.Cust_Job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Job_long", ctm.Cust_Job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Job_salary", ctm.Cust_Job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Job_local_name", ctm.Cust_Job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Job_address_no", ctm.Cust_Job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage", ctm.Cust_Job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage_no", ctm.Cust_Job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_alley", ctm.Cust_Job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Job_road", ctm.Cust_Job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Job_subdistrict", ctm.Cust_Job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Job_district", ctm.Cust_Job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Job_province", ctm.Cust_Job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Job_country", ctm.Cust_Job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Job_zipcode", ctm.Cust_Job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Job_tel", ctm.Cust_Job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job_email", ctm.Cust_Job_email);
                cmd.Parameters.AddWithValue("@i_Cust_Home_address_no", ctm.Cust_Home_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage", ctm.Cust_Home_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage_no", ctm.Cust_Home_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_alley", ctm.Cust_Home_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Home_road", ctm.Cust_Home_road);
                cmd.Parameters.AddWithValue("@i_Cust_Home_subdistrict", ctm.Cust_Home_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Home_district", ctm.Cust_Home_district);
                cmd.Parameters.AddWithValue("@i_Cust_Home_province", ctm.Cust_Home_province);
                cmd.Parameters.AddWithValue("@i_Cust_Home_country", ctm.Cust_Home_country);
                cmd.Parameters.AddWithValue("@i_Cust_Home_zipcode", ctm.Cust_Home_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Home_tel", ctm.Cust_Home_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Latitude", ctm.Cust_Home_GPS_Latitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Longitude", ctm.Cust_Home_GPS_Longitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_Status_id", ctm.ctm_home_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_address_no", ctm.Cust_Idcard_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage", ctm.Cust_Idcard_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage_no", ctm.Cust_Idcard_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_alley", ctm.Cust_Idcard_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_road", ctm.Cust_Idcard_road);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_subdistrict", ctm.Cust_Idcard_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_district", ctm.Cust_Idcard_district);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province", ctm.Cust_Idcard_province);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_country", ctm.Cust_Idcard_country);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_zipcode", ctm.Cust_Idcard_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_tel", ctm.Cust_Idcard_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_Status_id", ctm.ctm_idcard_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_address_no", ctm.Cust_Current_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage", ctm.Cust_Current_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage_no", ctm.Cust_Current_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_alley", ctm.Cust_Current_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Current_road", ctm.Cust_Current_road);
                cmd.Parameters.AddWithValue("@i_Cust_Current_subdistrict", ctm.Cust_Current_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Current_district", ctm.Cust_Current_district);
                cmd.Parameters.AddWithValue("@i_Cust_Current_province", ctm.Cust_Current_province);
                cmd.Parameters.AddWithValue("@i_Cust_Current_country", ctm.Cust_Current_country);
                cmd.Parameters.AddWithValue("@i_Cust_Current_zipcode", ctm.Cust_Current_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Current_tel", ctm.Cust_Current_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Current_Status_id", ctm.ctm_current_stt.Home_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> addCustomers() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> addCustomers() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editCustomers(Customers ctm)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ u_customers ] :: 
                 * u_customers ( IN i_Cust_id VARCHAR(50), IN i_Cust_Idcard VARCHAR(20), IN i_Cust_Fname VARCHAR(255), IN i_Cust_LName VARCHAR(255),
	             *   IN i_Cust_B_date DATE, IN i_Cust_Age INT(11), IN i_Cust_Idcard_without VARCHAR(255), IN i_Cust_Idcard_start DATE,
	             *   IN i_Cust_Idcard_expire DATE, IN i_Cust_Nationality_id INT(11), IN i_Cust_Origin_id INT(11), IN i_Cust_Tel VARCHAR(255),
	             *   IN i_Cust_Email VARCHAR(255), IN i_Cust_Status_id INT(11), IN i_Cust_Marry_idcard VARCHAR(20), IN i_Cust_Marry_Fname VARCHAR(255),
	             *   IN i_Cust_Marry_Lname VARCHAR(255), IN i_Cust_Marry_Nationality INT(11), IN i_Cust_Marry_Origin INT(11), IN i_Cust_Marry_Address_no VARCHAR(255),
	             *   IN i_Cust_Marry_vilage VARCHAR(255), IN i_Cust_Marry_vilage_no VARCHAR(255), IN i_Cust_Marry_alley VARCHAR(255), IN i_Cust_Marry_road VARCHAR(255),
	             *   IN i_Cust_Marry_subdistrict VARCHAR(255), IN i_Cust_Marry_district VARCHAR(255), IN i_Cust_Marry_province_id INT(11), IN i_Cust_Marry_country VARCHAR(255),
	             *   IN i_Cust_Marry_zipcode VARCHAR(255), IN i_Cust_Marry_tel VARCHAR(255), IN i_Cust_Marry_email VARCHAR(255), IN i_Cust_Marry_job VARCHAR(255),
	             *   IN i_Cust_Marry_job_position VARCHAR(255), IN i_Cust_Marry_job_long INT(11), IN i_Cust_Marry_job_salary DOUBLE(10,2), IN i_Cust_Marry_job_local_name VARCHAR(255),
	             *   IN i_Cust_Marry_job_address_no VARCHAR(255), IN i_Cust_Marry_job_vilage VARCHAR(255), IN i_Cust_Marry_job_vilage_no VARCHAR(255), IN i_Cust_Marry_job_alley VARCHAR(255),
	             *   IN i_Cust_Marry_job_road VARCHAR(255), IN i_Cust_Marry_job_subdistrict VARCHAR(255), IN i_Cust_Marry_job_district VARCHAR(255), IN i_Cust_Marry_job_province_id INT(11),
	             *   IN i_Cust_Marry_job_zipcode VARCHAR(255), IN i_Cust_Marry_job_tel VARCHAR(255), IN i_Cust_Job VARCHAR(255), IN i_Cust_Job_position VARCHAR(255),
	             *   IN i_Cust_Job_long INT(11), IN i_Cust_Job_salary DOUBLE(10,2), IN i_Cust_Job_local_name VARCHAR(255), IN i_Cust_Job_address_no VARCHAR(255),
	             *   IN i_Cust_Job_vilage VARCHAR(255), IN i_Cust_Job_vilage_no VARCHAR(255), IN i_Cust_Job_alley VARCHAR(255), IN i_Cust_Job_road VARCHAR(255),
	             *   IN i_Cust_Job_subdistrict VARCHAR(255), IN i_Cust_Job_district VARCHAR(255), IN i_Cust_Job_province_id INT(11), IN i_Cust_Job_country VARCHAR(255),
	             *   IN i_Cust_Job_zipcode VARCHAR(255), IN i_Cust_Job_tel VARCHAR(255), IN i_Cust_Job_email VARCHAR(255), IN i_Cust_Home_address_no VARCHAR(255),
	             *   IN i_Cust_Home_vilage VARCHAR(255), IN i_Cust_Home_vilage_no VARCHAR(255), IN i_Cust_Home_alley VARCHAR(255), IN i_Cust_Home_road VARCHAR(255),
	             *   IN i_Cust_Home_subdistrict VARCHAR(255), IN i_Cust_Home_district VARCHAR(255), IN i_Cust_Home_province_id INT(11), IN i_Cust_Home_country VARCHAR(255),
	             *   IN i_Cust_Home_zipcode VARCHAR(255), IN i_Cust_Home_tel VARCHAR(255), IN i_Cust_Home_GPS_Latitude VARCHAR(255), IN i_Cust_Home_GPS_Longitude VARCHAR(255),
	             *   IN i_Cust_Home_Status_id INT(11), IN i_Cust_Idcard_address_no VARCHAR(255), IN i_Cust_Idcard_vilage VARCHAR(255), IN i_Cust_Idcard_vilage_no VARCHAR(255),
	             *   IN i_Cust_Idcard_alley VARCHAR(255), IN i_Cust_Idcard_road VARCHAR(255), IN i_Cust_Idcard_subdistrict VARCHAR(255), IN i_Cust_Idcard_district VARCHAR(255),
	             *   IN i_Cust_Idcard_province_id INT(11), IN i_Cust_Idcard_country VARCHAR(255), IN i_Cust_Idcard_zipcode VARCHAR(255), IN i_Cust_Idcard_tel VARCHAR(255),
	             *   IN i_Cust_Idcard_Status_id INT(11), IN i_Cust_Current_address_no VARCHAR(255), IN i_Cust_Current_vilage VARCHAR(255), IN i_Cust_Current_vilage_no VARCHAR(255),
	             *   IN i_Cust_Current_alley VARCHAR(255), IN i_Cust_Current_road VARCHAR(255), IN i_Cust_Current_subdistrict VARCHAR(255), IN i_Cust_Current_district VARCHAR(255),
	             *   IN i_Cust_Current_province_id INT(11), IN i_Cust_Current_country VARCHAR(255), IN i_Cust_Current_zipcode VARCHAR(255), IN i_Cust_Current_tel VARCHAR(255),
	             *   IN i_Cust_Current_Status_id INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_customers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Cust_id", ctm.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard", ctm.Cust_Idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", ctm.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", ctm.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", ctm.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_Age", ctm.Cust_Age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", ctm.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", ctm.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", ctm.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality_id", ctm.ctm_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Origin_id", ctm.ctm_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Tel", ctm.Cust_Tel);
                cmd.Parameters.AddWithValue("@i_Cust_Email", ctm.Cust_Email);
                cmd.Parameters.AddWithValue("@i_Cust_Status_id", ctm.ctm_pstt.person_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_idcard", ctm.Cust_Marry_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Fname", ctm.Cust_Marry_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Lname", ctm.Cust_Marry_Lname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Nationality", ctm.ctm_marry_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Origin", ctm.ctm_marry_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Address_no", ctm.Cust_Marry_Address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage", ctm.Cust_Marry_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage_no", ctm.Cust_Marry_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_alley", ctm.Cust_Marry_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_road", ctm.Cust_Marry_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_subdistrict", ctm.Cust_Marry_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_district", ctm.Cust_Marry_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province", ctm.Cust_Marry_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_country", ctm.Cust_Marry_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_zipcode", ctm.Cust_Marry_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_tel", ctm.Cust_Marry_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_email", ctm.Cust_Marry_email);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job", ctm.Cust_Marry_job);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_position", ctm.Cust_Marry_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_long", ctm.Cust_Marry_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_salary", ctm.Cust_Marry_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_local_name", ctm.Cust_Marry_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_address_no", ctm.Cust_Marry_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage", ctm.Cust_Marry_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage_no", ctm.Cust_Marry_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_alley", ctm.Cust_Marry_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_road", ctm.Cust_Marry_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_subdistrict", ctm.Cust_Marry_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_district", ctm.Cust_Marry_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province", ctm.Cust_Marry_job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_country", ctm.Cust_Marry_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_zipcode", ctm.Cust_Marry_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_tel", ctm.Cust_Marry_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job", ctm.Cust_Job);
                cmd.Parameters.AddWithValue("@i_Cust_Job_position", ctm.Cust_Job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Job_long", ctm.Cust_Job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Job_salary", ctm.Cust_Job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Job_local_name", ctm.Cust_Job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Job_address_no", ctm.Cust_Job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage", ctm.Cust_Job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage_no", ctm.Cust_Job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_alley", ctm.Cust_Job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Job_road", ctm.Cust_Job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Job_subdistrict", ctm.Cust_Job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Job_district", ctm.Cust_Job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Job_province", ctm.Cust_Job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Job_country", ctm.Cust_Job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Job_zipcode", ctm.Cust_Job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Job_tel", ctm.Cust_Job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job_email", ctm.Cust_Job_email);
                cmd.Parameters.AddWithValue("@i_Cust_Home_address_no", ctm.Cust_Home_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage", ctm.Cust_Home_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage_no", ctm.Cust_Home_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_alley", ctm.Cust_Home_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Home_road", ctm.Cust_Home_road);
                cmd.Parameters.AddWithValue("@i_Cust_Home_subdistrict", ctm.Cust_Home_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Home_district", ctm.Cust_Home_district);
                cmd.Parameters.AddWithValue("@i_Cust_Home_province", ctm.Cust_Home_province);
                cmd.Parameters.AddWithValue("@i_Cust_Home_country", ctm.Cust_Home_country);
                cmd.Parameters.AddWithValue("@i_Cust_Home_zipcode", ctm.Cust_Home_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Home_tel", ctm.Cust_Home_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Latitude", ctm.Cust_Home_GPS_Latitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Longitude", ctm.Cust_Home_GPS_Longitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_Status_id", ctm.ctm_home_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_address_no", ctm.Cust_Idcard_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage", ctm.Cust_Idcard_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage_no", ctm.Cust_Idcard_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_alley", ctm.Cust_Idcard_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_road", ctm.Cust_Idcard_road);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_subdistrict", ctm.Cust_Idcard_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_district", ctm.Cust_Idcard_district);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province", ctm.Cust_Idcard_province);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_country", ctm.Cust_Idcard_country);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_zipcode", ctm.Cust_Idcard_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_tel", ctm.Cust_Idcard_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_Status_id", ctm.ctm_idcard_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_address_no", ctm.Cust_Current_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage", ctm.Cust_Current_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage_no", ctm.Cust_Current_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_alley", ctm.Cust_Current_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Current_road", ctm.Cust_Current_road);
                cmd.Parameters.AddWithValue("@i_Cust_Current_subdistrict", ctm.Cust_Current_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Current_district", ctm.Cust_Current_district);
                cmd.Parameters.AddWithValue("@i_Cust_Current_province", ctm.Cust_Current_province);
                cmd.Parameters.AddWithValue("@i_Cust_Current_country", ctm.Cust_Current_country);
                cmd.Parameters.AddWithValue("@i_Cust_Current_zipcode", ctm.Cust_Current_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Current_tel", ctm.Cust_Current_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Current_Status_id", ctm.ctm_current_stt.Home_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> editCustomers() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> editCustomers( ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public string generateDigitID()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM v_getdigit ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                string id = "";
                if (reader.Read())
                {
                    id = reader.IsDBNull(0) ? "" : reader.GetString(0);
                }

                return id;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> generateDigitID() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> generateDigitID() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public string getLastNumberPhotoId(string Cust_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_customers_home_photo_lastnumber_by_id ] :: 
                 * g_customers_home_photo_lastnumber_by_id (IN i_Cust_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers_home_photo_lastnumber_by_id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                string digit = "";

                if (reader.Read())
                {
                    digit = reader.IsDBNull(0) ? "" : reader.GetString(0);
                }

                return digit;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getLastNumberPhotoId() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getLastNumberPhotoId() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Customers_Home_Photo> getCustomersHomePhoto(string Cust_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_customers_home_photo ] :: 
                 * g_customers_home_photo (IN i_Cust_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers_home_photo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Customers_Home_Photo> list_ctm_photo = new List<Customers_Home_Photo>();

                while (reader.Read())
                {
                    Customers_Home_Photo ctm_photo = new Customers_Home_Photo();

                    int defaultNum = 0;
                    string defaultString = "";

                    ctm_photo.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    ctm_photo.Home_img_num = reader.IsDBNull(1) ? defaultNum : reader.GetInt32(1);
                    ctm_photo.Home_img_old_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    ctm_photo.Home_img_path = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    ctm_photo.Home_img_full_path = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    ctm_photo.Home_img_local_path = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    ctm_photo.Home_img_save_date = reader.IsDBNull(6) ? defaultString : reader.GetString(6);

                    list_ctm_photo.Add(ctm_photo);

                }

                return list_ctm_photo;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhoto() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhoto() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Customers_Home_Photo getCustomersHomePhotoSelected(string Cust_id, string Home_img_num)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_customers_home_photo_for_remove ] :: 
                 * g_customers_home_photo_for_remove (IN i_Cust_id varchar(50), IN i_Home_img_num INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers_home_photo_for_remove", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);
                cmd.Parameters.AddWithValue("@i_Home_img_num", Home_img_num);

                MySqlDataReader reader = cmd.ExecuteReader();

                Customers_Home_Photo ctm_photo = new Customers_Home_Photo();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    ctm_photo.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    ctm_photo.Home_img_num = reader.IsDBNull(1) ? defaultNum : reader.GetInt32(1);
                    ctm_photo.Home_img_old_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    ctm_photo.Home_img_path = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    ctm_photo.Home_img_full_path = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    ctm_photo.Home_img_local_path = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    ctm_photo.Home_img_save_date = reader.IsDBNull(6) ? defaultString : reader.GetString(6);

                }

                return ctm_photo;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhotoSelected) ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhotoSelected() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addCustomersHomePhoto(Customers_Home_Photo ctm_photo)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_customers_home_photo ] :: 
                 * i_customers_home_photo   (in i_Cust_id varchar(50),       in i_Home_img_num int(11),      in i_Home_img_old_name text,    in i_Home_img_path text, 
				 *					                in i_Home_img_full_path text,   in i_Home_img_local_path text)
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_customers_home_photo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Cust_id", ctm_photo.Cust_id);
                cmd.Parameters.AddWithValue("@i_Home_img_num", ctm_photo.Home_img_num);
                cmd.Parameters.AddWithValue("@i_Home_img_old_name", ctm_photo.Home_img_old_name);
                cmd.Parameters.AddWithValue("@i_Home_img_path", ctm_photo.Home_img_path);
                cmd.Parameters.AddWithValue("@i_Home_img_full_path", ctm_photo.Home_img_full_path);
                cmd.Parameters.AddWithValue("@i_Home_img_local_path", ctm_photo.Home_img_local_path);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> addCustomersHomePhoto() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> addCustomersHomePhoto() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool removeCustomersHomePhoto(string Cust_id, int Home_img_num)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ d_customers_home_photo ] :: 
                 * d_customers_home_photo (IN i_Cust_id varchar(50), IN i_Home_img_num INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_customers_home_photo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);
                cmd.Parameters.AddWithValue("@i_Home_img_num", Home_img_num);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> removeCustomersHomePhoto() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> removeCustomersHomePhoto() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}