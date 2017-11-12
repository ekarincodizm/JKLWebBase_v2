using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Class_Customers;

namespace JKLWebBase_v2.Managers_Leasings
{
    public class Car_Leasings_Guarantor_Manager
    {
        private string error = string.Empty;

        public bool checkDuplicateGuarantor(string Leasing_id, string Cust_id, string Cust_idcard)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_car_leasings_guarantor_chk_duplicate ] :: 
                 * g_car_leasings_guarantor_chk_duplicate (IN i_Leasing_id VARCHAR(50), IN i_Cust_id VARCHAR(50), IN i_Cust_idcard VARCHAR(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_leasings_guarantor_chk_duplicate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_idcard", Cust_idcard);

                MySqlDataReader reader = cmd.ExecuteReader();

                bool detected = false;

                if (reader.Read())
                {
                    detected = true;
                }

                return detected;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> checkDuplicateGuarantor() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> checkDuplicateGuarantor() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Car_Leasings_Guarator> getAllGuarantors(string Leasing_id, string Cust_id, string Cust_idcard)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_car_leasings_guarantor ] :: 
                 * g_car_leasings_guarantor (IN i_Leasing_id VARCHAR(50), IN i_Cust_id VARCHAR(50), IN i_Cust_idcard VARCHAR(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_leasings_guarantor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_idcard", Cust_idcard);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Car_Leasings_Guarator> list_cls_grt = new List<Car_Leasings_Guarator>();

                while (reader.Read())
                {
                    Car_Leasings_Guarator cls_grt =  new Car_Leasings_Guarator();

                    int defaultNum = 0;
                    string defaultString = "";

                    cls_grt.cls = new Car_Leasings();
                    cls_grt.cls.Leasing_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);

                    cls_grt.Guarantor_no = reader.IsDBNull(1) ? defaultNum : reader.GetInt32(1);

                    cls_grt.ctm = new Customers();
                    cls_grt.ctm.Cust_id = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cls_grt.ctm.Cust_Idcard = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cls_grt.ctm.Cust_Fname = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cls_grt.ctm.Cust_LName = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cls_grt.ctm.Cust_B_date = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cls_grt.ctm.Cust_Age = reader.IsDBNull(7) ? defaultNum : reader.GetInt32(7);
                    cls_grt.ctm.Cust_Idcard_without = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cls_grt.ctm.Cust_Idcard_start = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cls_grt.ctm.Cust_Idcard_expire = reader.IsDBNull(10) ? defaultString : reader.GetString(10);

                    cls_grt.ctm.ctm_ntnlt = new Base_Nationalitys();
                    cls_grt.ctm.ctm_ntnlt.Nationality_id = reader.IsDBNull(11) ? defaultNum : reader.GetInt32(11);
                    cls_grt.ctm.ctm_ntnlt.Nationality_name_ENG = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cls_grt.ctm.ctm_ntnlt.Nationality_name_TH = reader.IsDBNull(13) ? defaultString : reader.GetString(13);

                    cls_grt.ctm.ctm_org = new Base_Origins();
                    cls_grt.ctm.ctm_org.Origin_id = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cls_grt.ctm.ctm_org.Origin_name_ENG = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cls_grt.ctm.ctm_org.Origin_name_TH = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    cls_grt.ctm.Cust_Tel = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    cls_grt.ctm.Cust_Email = reader.IsDBNull(18) ? defaultString : reader.GetString(18);

                    cls_grt.ctm.ctm_pstt = new Base_Person_Status();
                    cls_grt.ctm.ctm_pstt.person_status_id = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19);
                    cls_grt.ctm.ctm_pstt.person_status_name = reader.IsDBNull(20) ? defaultString : reader.GetString(20);

                    cls_grt.ctm.Cust_Marry_idcard = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    cls_grt.ctm.Cust_Marry_Fname = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    cls_grt.ctm.Cust_Marry_Lname = reader.IsDBNull(23) ? defaultString : reader.GetString(23);

                    cls_grt.ctm.ctm_marry_ntnlt = new Base_Nationalitys();
                    cls_grt.ctm.ctm_marry_ntnlt.Nationality_id = reader.IsDBNull(24) ? defaultNum : reader.GetInt32(24);
                    cls_grt.ctm.ctm_marry_ntnlt.Nationality_name_ENG = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    cls_grt.ctm.ctm_marry_ntnlt.Nationality_name_TH = reader.IsDBNull(26) ? defaultString : reader.GetString(26);

                    cls_grt.ctm.ctm_marry_org = new Base_Origins();
                    cls_grt.ctm.ctm_marry_org.Origin_id = reader.IsDBNull(27) ? defaultNum : reader.GetInt32(27);
                    cls_grt.ctm.ctm_marry_org.Origin_name_ENG = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    cls_grt.ctm.ctm_marry_org.Origin_name_TH = reader.IsDBNull(29) ? defaultString : reader.GetString(29);

                    cls_grt.ctm.Cust_Marry_Address_no = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    cls_grt.ctm.Cust_Marry_vilage = reader.IsDBNull(31) ? defaultString : reader.GetString(31);
                    cls_grt.ctm.Cust_Marry_vilage_no = reader.IsDBNull(32) ? defaultString : reader.GetString(32);
                    cls_grt.ctm.Cust_Marry_alley = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    cls_grt.ctm.Cust_Marry_road = reader.IsDBNull(34) ? defaultString : reader.GetString(34);
                    cls_grt.ctm.Cust_Marry_subdistrict = reader.IsDBNull(35) ? defaultString : reader.GetString(35);
                    cls_grt.ctm.Cust_Marry_district = reader.IsDBNull(36) ? defaultString : reader.GetString(36);
                    cls_grt.ctm.Cust_Marry_province = reader.IsDBNull(37) ? defaultString : reader.GetString(37);
                    cls_grt.ctm.Cust_Marry_country = reader.IsDBNull(38) ? defaultString : reader.GetString(38);
                    cls_grt.ctm.Cust_Marry_zipcode = reader.IsDBNull(39) ? defaultString : reader.GetString(39);
                    cls_grt.ctm.Cust_Marry_tel = reader.IsDBNull(40) ? defaultString : reader.GetString(40);
                    cls_grt.ctm.Cust_Marry_email = reader.IsDBNull(41) ? defaultString : reader.GetString(41);

                    cls_grt.ctm.Cust_Marry_job = reader.IsDBNull(42) ? defaultString : reader.GetString(42);
                    cls_grt.ctm.Cust_Marry_job_position = reader.IsDBNull(43) ? defaultString : reader.GetString(43);
                    cls_grt.ctm.Cust_Marry_job_long = reader.IsDBNull(44) ? defaultNum : reader.GetInt32(44);
                    cls_grt.ctm.Cust_Marry_job_salary = reader.IsDBNull(45) ? defaultNum : reader.GetDouble(45);
                    cls_grt.ctm.Cust_Marry_job_local_name = reader.IsDBNull(46) ? defaultString : reader.GetString(46);
                    cls_grt.ctm.Cust_Marry_job_address_no = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                    cls_grt.ctm.Cust_Marry_job_vilage = reader.IsDBNull(48) ? defaultString : reader.GetString(48);
                    cls_grt.ctm.Cust_Marry_job_vilage_no = reader.IsDBNull(49) ? defaultString : reader.GetString(49);
                    cls_grt.ctm.Cust_Marry_job_alley = reader.IsDBNull(50) ? defaultString : reader.GetString(50);
                    cls_grt.ctm.Cust_Marry_job_road = reader.IsDBNull(51) ? defaultString : reader.GetString(51);
                    cls_grt.ctm.Cust_Marry_job_subdistrict = reader.IsDBNull(52) ? defaultString : reader.GetString(52);
                    cls_grt.ctm.Cust_Marry_job_district = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                    cls_grt.ctm.Cust_Marry_job_province = reader.IsDBNull(54) ? defaultString : reader.GetString(54);
                    cls_grt.ctm.Cust_Marry_job_country = reader.IsDBNull(55) ? defaultString : reader.GetString(55);
                    cls_grt.ctm.Cust_Marry_job_zipcode = reader.IsDBNull(56) ? defaultString : reader.GetString(56);
                    cls_grt.ctm.Cust_Marry_job_tel = reader.IsDBNull(57) ? defaultString : reader.GetString(57);

                    cls_grt.ctm.Cust_Job = reader.IsDBNull(58) ? defaultString : reader.GetString(58);
                    cls_grt.ctm.Cust_Job_position = reader.IsDBNull(59) ? defaultString : reader.GetString(59);
                    cls_grt.ctm.Cust_Job_long = reader.IsDBNull(60) ? defaultNum : reader.GetInt32(60);
                    cls_grt.ctm.Cust_Job_salary = reader.IsDBNull(61) ? defaultNum : reader.GetDouble(61);
                    cls_grt.ctm.Cust_Job_local_name = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    cls_grt.ctm.Cust_Job_address_no = reader.IsDBNull(63) ? defaultString : reader.GetString(63);
                    cls_grt.ctm.Cust_Job_vilage = reader.IsDBNull(64) ? defaultString : reader.GetString(64);
                    cls_grt.ctm.Cust_Job_vilage_no = reader.IsDBNull(65) ? defaultString : reader.GetString(65);
                    cls_grt.ctm.Cust_Job_alley = reader.IsDBNull(66) ? defaultString : reader.GetString(66);
                    cls_grt.ctm.Cust_Job_road = reader.IsDBNull(67) ? defaultString : reader.GetString(67);
                    cls_grt.ctm.Cust_Job_subdistrict = reader.IsDBNull(68) ? defaultString : reader.GetString(68);
                    cls_grt.ctm.Cust_Job_district = reader.IsDBNull(69) ? defaultString : reader.GetString(69);
                    cls_grt.ctm.Cust_Job_province = reader.IsDBNull(70) ? defaultString : reader.GetString(70);
                    cls_grt.ctm.Cust_Job_country = reader.IsDBNull(71) ? defaultString : reader.GetString(71);
                    cls_grt.ctm.Cust_Job_zipcode = reader.IsDBNull(72) ? defaultString : reader.GetString(72);
                    cls_grt.ctm.Cust_Job_tel = reader.IsDBNull(73) ? defaultString : reader.GetString(73);
                    cls_grt.ctm.Cust_Job_email = reader.IsDBNull(74) ? defaultString : reader.GetString(74);

                    cls_grt.ctm.Cust_Home_address_no = reader.IsDBNull(75) ? defaultString : reader.GetString(75);
                    cls_grt.ctm.Cust_Home_vilage = reader.IsDBNull(76) ? defaultString : reader.GetString(76);
                    cls_grt.ctm.Cust_Home_vilage_no = reader.IsDBNull(77) ? defaultString : reader.GetString(77);
                    cls_grt.ctm.Cust_Home_alley = reader.IsDBNull(78) ? defaultString : reader.GetString(78);
                    cls_grt.ctm.Cust_Home_road = reader.IsDBNull(79) ? defaultString : reader.GetString(79);
                    cls_grt.ctm.Cust_Home_subdistrict = reader.IsDBNull(80) ? defaultString : reader.GetString(80);
                    cls_grt.ctm.Cust_Home_district = reader.IsDBNull(81) ? defaultString : reader.GetString(81);
                    cls_grt.ctm.Cust_Home_province = reader.IsDBNull(82) ? defaultString : reader.GetString(82);
                    cls_grt.ctm.Cust_Home_country = reader.IsDBNull(83) ? defaultString : reader.GetString(83);
                    cls_grt.ctm.Cust_Home_zipcode = reader.IsDBNull(84) ? defaultString : reader.GetString(84);
                    cls_grt.ctm.Cust_Home_tel = reader.IsDBNull(85) ? defaultString : reader.GetString(85);
                    cls_grt.ctm.Cust_Home_GPS_Latitude = reader.IsDBNull(86) ? defaultString : reader.GetString(86);
                    cls_grt.ctm.Cust_Home_GPS_Longitude = reader.IsDBNull(87) ? defaultString : reader.GetString(87);

                    cls_grt.ctm.ctm_home_stt = new Base_Home_Status();
                    cls_grt.ctm.ctm_home_stt.Home_status_id = reader.IsDBNull(88) ? defaultNum : reader.GetInt32(88);
                    cls_grt.ctm.ctm_home_stt.Home_status_name = reader.IsDBNull(89) ? defaultString : reader.GetString(89);

                    cls_grt.ctm.Cust_Idcard_address_no = reader.IsDBNull(90) ? defaultString : reader.GetString(90);
                    cls_grt.ctm.Cust_Idcard_vilage = reader.IsDBNull(91) ? defaultString : reader.GetString(91);
                    cls_grt.ctm.Cust_Idcard_vilage_no = reader.IsDBNull(92) ? defaultString : reader.GetString(92);
                    cls_grt.ctm.Cust_Idcard_alley = reader.IsDBNull(93) ? defaultString : reader.GetString(93);
                    cls_grt.ctm.Cust_Idcard_road = reader.IsDBNull(94) ? defaultString : reader.GetString(94);
                    cls_grt.ctm.Cust_Idcard_subdistrict = reader.IsDBNull(95) ? defaultString : reader.GetString(95);
                    cls_grt.ctm.Cust_Idcard_district = reader.IsDBNull(96) ? defaultString : reader.GetString(96);
                    cls_grt.ctm.Cust_Idcard_province = reader.IsDBNull(97) ? defaultString : reader.GetString(97);
                    cls_grt.ctm.Cust_Idcard_country = reader.IsDBNull(98) ? defaultString : reader.GetString(98);
                    cls_grt.ctm.Cust_Idcard_zipcode = reader.IsDBNull(99) ? defaultString : reader.GetString(99);
                    cls_grt.ctm.Cust_Idcard_tel = reader.IsDBNull(100) ? defaultString : reader.GetString(100);

                    cls_grt.ctm.ctm_idcard_stt = new Base_Home_Status();
                    cls_grt.ctm.ctm_idcard_stt.Home_status_id = reader.IsDBNull(101) ? defaultNum : reader.GetInt32(101);
                    cls_grt.ctm.ctm_idcard_stt.Home_status_name = reader.IsDBNull(102) ? defaultString : reader.GetString(102);

                    cls_grt.ctm.Cust_Current_address_no = reader.IsDBNull(103) ? defaultString : reader.GetString(103);
                    cls_grt.ctm.Cust_Current_vilage = reader.IsDBNull(104) ? defaultString : reader.GetString(104);
                    cls_grt.ctm.Cust_Current_vilage_no = reader.IsDBNull(105) ? defaultString : reader.GetString(105);
                    cls_grt.ctm.Cust_Current_alley = reader.IsDBNull(106) ? defaultString : reader.GetString(106);
                    cls_grt.ctm.Cust_Current_road = reader.IsDBNull(107) ? defaultString : reader.GetString(107);
                    cls_grt.ctm.Cust_Current_subdistrict = reader.IsDBNull(108) ? defaultString : reader.GetString(108);
                    cls_grt.ctm.Cust_Current_district = reader.IsDBNull(109) ? defaultString : reader.GetString(109);
                    cls_grt.ctm.Cust_Current_province = reader.IsDBNull(110) ? defaultString : reader.GetString(110);
                    cls_grt.ctm.Cust_Current_country = reader.IsDBNull(111) ? defaultString : reader.GetString(111);
                    cls_grt.ctm.Cust_Current_zipcode = reader.IsDBNull(112) ? defaultString : reader.GetString(112);
                    cls_grt.ctm.Cust_Current_tel = reader.IsDBNull(113) ? defaultString : reader.GetString(113);

                    cls_grt.ctm.ctm_current_stt = new Base_Home_Status();
                    cls_grt.ctm.ctm_current_stt.Home_status_id = reader.IsDBNull(114) ? defaultNum : reader.GetInt32(114);
                    cls_grt.ctm.ctm_current_stt.Home_status_name = reader.IsDBNull(115) ? defaultString : reader.GetString(115);

                    cls_grt.ctm.Cust_save_date = reader.IsDBNull(116) ? defaultString : reader.GetString(116);

                    list_cls_grt.Add(cls_grt);
                }

                return list_cls_grt;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> getAllGuarantors() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> getAllGuarantors() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addGuarantorsLeasing(Car_Leasings_Guarator cls_grt)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// <summary>
                /// :: StoredProcedure :: [ i_car_leasings_guarantor ] :: 
                /// i_car_leasings_guarantor ( IN i_Leasing_id VARCHAR(50), IN i_Guarantor_no INT(11), IN i_Cust_id VARCHAR(50), IN i_Cust_Idcard VARCHAR(20), IN i_Cust_Fname VARCHAR(255), IN i_Cust_LName VARCHAR(255),
	            ///   IN i_Cust_B_date DATE, IN i_Cust_Age INT(11), IN i_Cust_Idcard_without VARCHAR(255), IN i_Cust_Idcard_start DATE,
	            ///   IN i_Cust_Idcard_expire DATE, IN i_Cust_Nationality_id INT(11), IN i_Cust_Origin_id INT(11), IN i_Cust_Tel VARCHAR(255),
	            ///   IN i_Cust_Email VARCHAR(255), IN i_Cust_Status_id INT(11), IN i_Cust_Marry_idcard VARCHAR(20), IN i_Cust_Marry_Fname VARCHAR(255),
	            ///   IN i_Cust_Marry_Lname VARCHAR(255), IN i_Cust_Marry_Nationality INT(11), IN i_Cust_Marry_Origin INT(11), IN i_Cust_Marry_Address_no VARCHAR(255),
	            ///   IN i_Cust_Marry_vilage VARCHAR(255), IN i_Cust_Marry_vilage_no VARCHAR(255), IN i_Cust_Marry_alley VARCHAR(255), IN i_Cust_Marry_road VARCHAR(255),
	            ///   IN i_Cust_Marry_subdistrict VARCHAR(255), IN i_Cust_Marry_district VARCHAR(255), IN i_Cust_Marry_province_id INT(11), IN i_Cust_Marry_country VARCHAR(255),
	            ///   IN i_Cust_Marry_zipcode VARCHAR(255), IN i_Cust_Marry_tel VARCHAR(255), IN i_Cust_Marry_email VARCHAR(255), IN i_Cust_Marry_job VARCHAR(255),
	            ///   IN i_Cust_Marry_job_position VARCHAR(255), IN i_Cust_Marry_job_long INT(11), IN i_Cust_Marry_job_salary DOUBLE(10,2), IN i_Cust_Marry_job_local_name VARCHAR(255),
	            ///   IN i_Cust_Marry_job_address_no VARCHAR(255), IN i_Cust_Marry_job_vilage VARCHAR(255), IN i_Cust_Marry_job_vilage_no VARCHAR(255), IN i_Cust_Marry_job_alley VARCHAR(255),
	            ///   IN i_Cust_Marry_job_road VARCHAR(255), IN i_Cust_Marry_job_subdistrict VARCHAR(255), IN i_Cust_Marry_job_district VARCHAR(255), IN i_Cust_Marry_job_province_id INT(11),
	            ///   IN i_Cust_Marry_job_zipcode VARCHAR(255), IN i_Cust_Marry_job_tel VARCHAR(255), IN i_Cust_Job VARCHAR(255), IN i_Cust_Job_position VARCHAR(255),
	            ///   IN i_Cust_Job_long INT(11), IN i_Cust_Job_salary DOUBLE(10,2), IN i_Cust_Job_local_name VARCHAR(255), IN i_Cust_Job_address_no VARCHAR(255),
	            ///   IN i_Cust_Job_vilage VARCHAR(255), IN i_Cust_Job_vilage_no VARCHAR(255), IN i_Cust_Job_alley VARCHAR(255), IN i_Cust_Job_road VARCHAR(255),
	            ///   IN i_Cust_Job_subdistrict VARCHAR(255), IN i_Cust_Job_district VARCHAR(255), IN i_Cust_Job_province_id INT(11), IN i_Cust_Job_country VARCHAR(255),
	            ///   IN i_Cust_Job_zipcode VARCHAR(255), IN i_Cust_Job_tel VARCHAR(255), IN i_Cust_Job_email VARCHAR(255), IN i_Cust_Home_address_no VARCHAR(255),
	            ///   IN i_Cust_Home_vilage VARCHAR(255), IN i_Cust_Home_vilage_no VARCHAR(255), IN i_Cust_Home_alley VARCHAR(255), IN i_Cust_Home_road VARCHAR(255),
	            ///   IN i_Cust_Home_subdistrict VARCHAR(255), IN i_Cust_Home_district VARCHAR(255), IN i_Cust_Home_province_id INT(11), IN i_Cust_Home_country VARCHAR(255),
	            ///   IN i_Cust_Home_zipcode VARCHAR(255), IN i_Cust_Home_tel VARCHAR(255), IN i_Cust_Home_GPS_Latitude VARCHAR(255), IN i_Cust_Home_GPS_Longitude VARCHAR(255),
	            ///   IN i_Cust_Home_Status_id INT(11), IN i_Cust_Idcard_address_no VARCHAR(255), IN i_Cust_Idcard_vilage VARCHAR(255), IN i_Cust_Idcard_vilage_no VARCHAR(255),
	            ///   IN i_Cust_Idcard_alley VARCHAR(255), IN i_Cust_Idcard_road VARCHAR(255), IN i_Cust_Idcard_subdistrict VARCHAR(255), IN i_Cust_Idcard_district VARCHAR(255),
	            ///   IN i_Cust_Idcard_province_id INT(11), IN i_Cust_Idcard_country VARCHAR(255), IN i_Cust_Idcard_zipcode VARCHAR(255), IN i_Cust_Idcard_tel VARCHAR(255),
	            ///   IN i_Cust_Idcard_Status_id INT(11), IN i_Cust_Current_address_no VARCHAR(255), IN i_Cust_Current_vilage VARCHAR(255), IN i_Cust_Current_vilage_no VARCHAR(255),
	            ///   IN i_Cust_Current_alley VARCHAR(255), IN i_Cust_Current_road VARCHAR(255), IN i_Cust_Current_subdistrict VARCHAR(255), IN i_Cust_Current_district VARCHAR(255),
	            ///   IN i_Cust_Current_province_id INT(11), IN i_Cust_Current_country VARCHAR(255), IN i_Cust_Current_zipcode VARCHAR(255), IN i_Cust_Current_tel VARCHAR(255),
	            ///   IN i_Cust_Current_Status_id INT(11))
                /// </summary>

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_leasings_guarantor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls_grt.cls.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Guarantor_no", cls_grt.Guarantor_no);
                cmd.Parameters.AddWithValue("@i_Cust_id", cls_grt.ctm.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard", cls_grt.ctm.Cust_Idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", cls_grt.ctm.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", cls_grt.ctm.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", cls_grt.ctm.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_Age", cls_grt.ctm.Cust_Age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", cls_grt.ctm.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", cls_grt.ctm.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", cls_grt.ctm.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality_id", cls_grt.ctm.ctm_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Origin_id", cls_grt.ctm.ctm_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Tel", cls_grt.ctm.Cust_Tel);
                cmd.Parameters.AddWithValue("@i_Cust_Email", cls_grt.ctm.Cust_Email);
                cmd.Parameters.AddWithValue("@i_Cust_Status_id", cls_grt.ctm.ctm_pstt.person_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_idcard", cls_grt.ctm.Cust_Marry_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Fname", cls_grt.ctm.Cust_Marry_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Lname", cls_grt.ctm.Cust_Marry_Lname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Nationality", cls_grt.ctm.ctm_marry_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Origin", cls_grt.ctm.ctm_marry_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Address_no", cls_grt.ctm.Cust_Marry_Address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage", cls_grt.ctm.Cust_Marry_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage_no", cls_grt.ctm.Cust_Marry_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_alley", cls_grt.ctm.Cust_Marry_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_road", cls_grt.ctm.Cust_Marry_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_subdistrict", cls_grt.ctm.Cust_Marry_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_district", cls_grt.ctm.Cust_Marry_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province", cls_grt.ctm.Cust_Marry_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_country", cls_grt.ctm.Cust_Marry_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_zipcode", cls_grt.ctm.Cust_Marry_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_tel", cls_grt.ctm.Cust_Marry_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_email", cls_grt.ctm.Cust_Marry_email);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job", cls_grt.ctm.Cust_Marry_job);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_position", cls_grt.ctm.Cust_Marry_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_long", cls_grt.ctm.Cust_Marry_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_salary", cls_grt.ctm.Cust_Marry_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_local_name", cls_grt.ctm.Cust_Marry_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_address_no", cls_grt.ctm.Cust_Marry_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage", cls_grt.ctm.Cust_Marry_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage_no", cls_grt.ctm.Cust_Marry_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_alley", cls_grt.ctm.Cust_Marry_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_road", cls_grt.ctm.Cust_Marry_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_subdistrict", cls_grt.ctm.Cust_Marry_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_district", cls_grt.ctm.Cust_Marry_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province", cls_grt.ctm.Cust_Marry_job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_country", cls_grt.ctm.Cust_Marry_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_zipcode", cls_grt.ctm.Cust_Marry_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_tel", cls_grt.ctm.Cust_Marry_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job", cls_grt.ctm.Cust_Job);
                cmd.Parameters.AddWithValue("@i_Cust_Job_position", cls_grt.ctm.Cust_Job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Job_long", cls_grt.ctm.Cust_Job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Job_salary", cls_grt.ctm.Cust_Job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Job_local_name", cls_grt.ctm.Cust_Job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Job_address_no", cls_grt.ctm.Cust_Job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage", cls_grt.ctm.Cust_Job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage_no", cls_grt.ctm.Cust_Job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_alley", cls_grt.ctm.Cust_Job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Job_road", cls_grt.ctm.Cust_Job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Job_subdistrict", cls_grt.ctm.Cust_Job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Job_district", cls_grt.ctm.Cust_Job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Job_province", cls_grt.ctm.Cust_Job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Job_country", cls_grt.ctm.Cust_Job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Job_zipcode", cls_grt.ctm.Cust_Job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Job_tel", cls_grt.ctm.Cust_Job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job_email", cls_grt.ctm.Cust_Job_email);
                cmd.Parameters.AddWithValue("@i_Cust_Home_address_no", cls_grt.ctm.Cust_Home_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage", cls_grt.ctm.Cust_Home_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage_no", cls_grt.ctm.Cust_Home_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_alley", cls_grt.ctm.Cust_Home_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Home_road", cls_grt.ctm.Cust_Home_road);
                cmd.Parameters.AddWithValue("@i_Cust_Home_subdistrict", cls_grt.ctm.Cust_Home_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Home_district", cls_grt.ctm.Cust_Home_district);
                cmd.Parameters.AddWithValue("@i_Cust_Home_province", cls_grt.ctm.Cust_Home_province);
                cmd.Parameters.AddWithValue("@i_Cust_Home_country", cls_grt.ctm.Cust_Home_country);
                cmd.Parameters.AddWithValue("@i_Cust_Home_zipcode", cls_grt.ctm.Cust_Home_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Home_tel", cls_grt.ctm.Cust_Home_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Latitude", cls_grt.ctm.Cust_Home_GPS_Latitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Longitude", cls_grt.ctm.Cust_Home_GPS_Longitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_Status_id", cls_grt.ctm.ctm_home_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_address_no", cls_grt.ctm.Cust_Idcard_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage", cls_grt.ctm.Cust_Idcard_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage_no", cls_grt.ctm.Cust_Idcard_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_alley", cls_grt.ctm.Cust_Idcard_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_road", cls_grt.ctm.Cust_Idcard_road);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_subdistrict", cls_grt.ctm.Cust_Idcard_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_district", cls_grt.ctm.Cust_Idcard_district);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province", cls_grt.ctm.Cust_Idcard_province);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_country", cls_grt.ctm.Cust_Idcard_country);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_zipcode", cls_grt.ctm.Cust_Idcard_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_tel", cls_grt.ctm.Cust_Idcard_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_Status_id", cls_grt.ctm.ctm_idcard_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_address_no", cls_grt.ctm.Cust_Current_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage", cls_grt.ctm.Cust_Current_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage_no", cls_grt.ctm.Cust_Current_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_alley", cls_grt.ctm.Cust_Current_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Current_road", cls_grt.ctm.Cust_Current_road);
                cmd.Parameters.AddWithValue("@i_Cust_Current_subdistrict", cls_grt.ctm.Cust_Current_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Current_district", cls_grt.ctm.Cust_Current_district);
                cmd.Parameters.AddWithValue("@i_Cust_Current_province", cls_grt.ctm.Cust_Current_province);
                cmd.Parameters.AddWithValue("@i_Cust_Current_country", cls_grt.ctm.Cust_Current_country);
                cmd.Parameters.AddWithValue("@i_Cust_Current_zipcode", cls_grt.ctm.Cust_Current_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Current_tel", cls_grt.ctm.Cust_Current_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Current_Status_id", cls_grt.ctm.ctm_current_stt.Home_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> addGuarantorsLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> addGuarantorsLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editGuarantorsLeasing(Car_Leasings_Guarator cls_grt)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// <summary>
                /// :: StoredProcedure :: [ u_car_leasings_guarantor ] :: 
                /// u_car_leasings_guarantor ( IN i_Leasing_id VARCHAR(50), IN i_Guarantor_no INT(11), IN i_Cust_id VARCHAR(50), IN i_Cust_Idcard VARCHAR(20), IN i_Cust_Fname VARCHAR(255), IN i_Cust_LName VARCHAR(255),
                ///   IN i_Cust_B_date DATE, IN i_Cust_Age INT(11), IN i_Cust_Idcard_without VARCHAR(255), IN i_Cust_Idcard_start DATE,
                ///   IN i_Cust_Idcard_expire DATE, IN i_Cust_Nationality_id INT(11), IN i_Cust_Origin_id INT(11), IN i_Cust_Tel VARCHAR(255),
                ///   IN i_Cust_Email VARCHAR(255), IN i_Cust_Status_id INT(11), IN i_Cust_Marry_idcard VARCHAR(20), IN i_Cust_Marry_Fname VARCHAR(255),
                ///   IN i_Cust_Marry_Lname VARCHAR(255), IN i_Cust_Marry_Nationality INT(11), IN i_Cust_Marry_Origin INT(11), IN i_Cust_Marry_Address_no VARCHAR(255),
                ///   IN i_Cust_Marry_vilage VARCHAR(255), IN i_Cust_Marry_vilage_no VARCHAR(255), IN i_Cust_Marry_alley VARCHAR(255), IN i_Cust_Marry_road VARCHAR(255),
                ///   IN i_Cust_Marry_subdistrict VARCHAR(255), IN i_Cust_Marry_district VARCHAR(255), IN i_Cust_Marry_province_id INT(11), IN i_Cust_Marry_country VARCHAR(255),
                ///   IN i_Cust_Marry_zipcode VARCHAR(255), IN i_Cust_Marry_tel VARCHAR(255), IN i_Cust_Marry_email VARCHAR(255), IN i_Cust_Marry_job VARCHAR(255),
                ///   IN i_Cust_Marry_job_position VARCHAR(255), IN i_Cust_Marry_job_long INT(11), IN i_Cust_Marry_job_salary DOUBLE(10,2), IN i_Cust_Marry_job_local_name VARCHAR(255),
                ///   IN i_Cust_Marry_job_address_no VARCHAR(255), IN i_Cust_Marry_job_vilage VARCHAR(255), IN i_Cust_Marry_job_vilage_no VARCHAR(255), IN i_Cust_Marry_job_alley VARCHAR(255),
                ///   IN i_Cust_Marry_job_road VARCHAR(255), IN i_Cust_Marry_job_subdistrict VARCHAR(255), IN i_Cust_Marry_job_district VARCHAR(255), IN i_Cust_Marry_job_province_id INT(11),
                ///   IN i_Cust_Marry_job_zipcode VARCHAR(255), IN i_Cust_Marry_job_tel VARCHAR(255), IN i_Cust_Job VARCHAR(255), IN i_Cust_Job_position VARCHAR(255),
                ///   IN i_Cust_Job_long INT(11), IN i_Cust_Job_salary DOUBLE(10,2), IN i_Cust_Job_local_name VARCHAR(255), IN i_Cust_Job_address_no VARCHAR(255),
                ///   IN i_Cust_Job_vilage VARCHAR(255), IN i_Cust_Job_vilage_no VARCHAR(255), IN i_Cust_Job_alley VARCHAR(255), IN i_Cust_Job_road VARCHAR(255),
                ///   IN i_Cust_Job_subdistrict VARCHAR(255), IN i_Cust_Job_district VARCHAR(255), IN i_Cust_Job_province_id INT(11), IN i_Cust_Job_country VARCHAR(255),
                ///   IN i_Cust_Job_zipcode VARCHAR(255), IN i_Cust_Job_tel VARCHAR(255), IN i_Cust_Job_email VARCHAR(255), IN i_Cust_Home_address_no VARCHAR(255),
                ///   IN i_Cust_Home_vilage VARCHAR(255), IN i_Cust_Home_vilage_no VARCHAR(255), IN i_Cust_Home_alley VARCHAR(255), IN i_Cust_Home_road VARCHAR(255),
                ///   IN i_Cust_Home_subdistrict VARCHAR(255), IN i_Cust_Home_district VARCHAR(255), IN i_Cust_Home_province_id INT(11), IN i_Cust_Home_country VARCHAR(255),
                ///   IN i_Cust_Home_zipcode VARCHAR(255), IN i_Cust_Home_tel VARCHAR(255), IN i_Cust_Home_GPS_Latitude VARCHAR(255), IN i_Cust_Home_GPS_Longitude VARCHAR(255),
                ///   IN i_Cust_Home_Status_id INT(11), IN i_Cust_Idcard_address_no VARCHAR(255), IN i_Cust_Idcard_vilage VARCHAR(255), IN i_Cust_Idcard_vilage_no VARCHAR(255),
                ///   IN i_Cust_Idcard_alley VARCHAR(255), IN i_Cust_Idcard_road VARCHAR(255), IN i_Cust_Idcard_subdistrict VARCHAR(255), IN i_Cust_Idcard_district VARCHAR(255),
                ///   IN i_Cust_Idcard_province_id INT(11), IN i_Cust_Idcard_country VARCHAR(255), IN i_Cust_Idcard_zipcode VARCHAR(255), IN i_Cust_Idcard_tel VARCHAR(255),
                ///   IN i_Cust_Idcard_Status_id INT(11), IN i_Cust_Current_address_no VARCHAR(255), IN i_Cust_Current_vilage VARCHAR(255), IN i_Cust_Current_vilage_no VARCHAR(255),
                ///   IN i_Cust_Current_alley VARCHAR(255), IN i_Cust_Current_road VARCHAR(255), IN i_Cust_Current_subdistrict VARCHAR(255), IN i_Cust_Current_district VARCHAR(255),
                ///   IN i_Cust_Current_province_id INT(11), IN i_Cust_Current_country VARCHAR(255), IN i_Cust_Current_zipcode VARCHAR(255), IN i_Cust_Current_tel VARCHAR(255),
                ///   IN i_Cust_Current_Status_id INT(11))
                /// </summary>

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_car_leasings_guarantor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls_grt.cls.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Guarantor_no", cls_grt.Guarantor_no);
                cmd.Parameters.AddWithValue("@i_Cust_id", cls_grt.ctm.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard", cls_grt.ctm.Cust_Idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", cls_grt.ctm.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", cls_grt.ctm.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", cls_grt.ctm.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_Age", cls_grt.ctm.Cust_Age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", cls_grt.ctm.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", cls_grt.ctm.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", cls_grt.ctm.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality_id", cls_grt.ctm.ctm_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Origin_id", cls_grt.ctm.ctm_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Tel", cls_grt.ctm.Cust_Tel);
                cmd.Parameters.AddWithValue("@i_Cust_Email", cls_grt.ctm.Cust_Email);
                cmd.Parameters.AddWithValue("@i_Cust_Status_id", cls_grt.ctm.ctm_pstt.person_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_idcard", cls_grt.ctm.Cust_Marry_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Fname", cls_grt.ctm.Cust_Marry_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Lname", cls_grt.ctm.Cust_Marry_Lname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Nationality", cls_grt.ctm.ctm_marry_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Origin", cls_grt.ctm.ctm_marry_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Address_no", cls_grt.ctm.Cust_Marry_Address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage", cls_grt.ctm.Cust_Marry_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage_no", cls_grt.ctm.Cust_Marry_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_alley", cls_grt.ctm.Cust_Marry_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_road", cls_grt.ctm.Cust_Marry_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_subdistrict", cls_grt.ctm.Cust_Marry_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_district", cls_grt.ctm.Cust_Marry_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province", cls_grt.ctm.Cust_Marry_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_country", cls_grt.ctm.Cust_Marry_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_zipcode", cls_grt.ctm.Cust_Marry_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_tel", cls_grt.ctm.Cust_Marry_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_email", cls_grt.ctm.Cust_Marry_email);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job", cls_grt.ctm.Cust_Marry_job);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_position", cls_grt.ctm.Cust_Marry_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_long", cls_grt.ctm.Cust_Marry_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_salary", cls_grt.ctm.Cust_Marry_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_local_name", cls_grt.ctm.Cust_Marry_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_address_no", cls_grt.ctm.Cust_Marry_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage", cls_grt.ctm.Cust_Marry_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage_no", cls_grt.ctm.Cust_Marry_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_alley", cls_grt.ctm.Cust_Marry_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_road", cls_grt.ctm.Cust_Marry_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_subdistrict", cls_grt.ctm.Cust_Marry_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_district", cls_grt.ctm.Cust_Marry_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province", cls_grt.ctm.Cust_Marry_job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_country", cls_grt.ctm.Cust_Marry_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_zipcode", cls_grt.ctm.Cust_Marry_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_tel", cls_grt.ctm.Cust_Marry_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job", cls_grt.ctm.Cust_Job);
                cmd.Parameters.AddWithValue("@i_Cust_Job_position", cls_grt.ctm.Cust_Job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Job_long", cls_grt.ctm.Cust_Job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Job_salary", cls_grt.ctm.Cust_Job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Job_local_name", cls_grt.ctm.Cust_Job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Job_address_no", cls_grt.ctm.Cust_Job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage", cls_grt.ctm.Cust_Job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage_no", cls_grt.ctm.Cust_Job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_alley", cls_grt.ctm.Cust_Job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Job_road", cls_grt.ctm.Cust_Job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Job_subdistrict", cls_grt.ctm.Cust_Job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Job_district", cls_grt.ctm.Cust_Job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Job_province", cls_grt.ctm.Cust_Job_province);
                cmd.Parameters.AddWithValue("@i_Cust_Job_country", cls_grt.ctm.Cust_Job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Job_zipcode", cls_grt.ctm.Cust_Job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Job_tel", cls_grt.ctm.Cust_Job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job_email", cls_grt.ctm.Cust_Job_email);
                cmd.Parameters.AddWithValue("@i_Cust_Home_address_no", cls_grt.ctm.Cust_Home_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage", cls_grt.ctm.Cust_Home_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage_no", cls_grt.ctm.Cust_Home_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_alley", cls_grt.ctm.Cust_Home_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Home_road", cls_grt.ctm.Cust_Home_road);
                cmd.Parameters.AddWithValue("@i_Cust_Home_subdistrict", cls_grt.ctm.Cust_Home_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Home_district", cls_grt.ctm.Cust_Home_district);
                cmd.Parameters.AddWithValue("@i_Cust_Home_province", cls_grt.ctm.Cust_Home_province);
                cmd.Parameters.AddWithValue("@i_Cust_Home_country", cls_grt.ctm.Cust_Home_country);
                cmd.Parameters.AddWithValue("@i_Cust_Home_zipcode", cls_grt.ctm.Cust_Home_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Home_tel", cls_grt.ctm.Cust_Home_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Latitude", cls_grt.ctm.Cust_Home_GPS_Latitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Longitude", cls_grt.ctm.Cust_Home_GPS_Longitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_Status_id", cls_grt.ctm.ctm_home_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_address_no", cls_grt.ctm.Cust_Idcard_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage", cls_grt.ctm.Cust_Idcard_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage_no", cls_grt.ctm.Cust_Idcard_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_alley", cls_grt.ctm.Cust_Idcard_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_road", cls_grt.ctm.Cust_Idcard_road);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_subdistrict", cls_grt.ctm.Cust_Idcard_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_district", cls_grt.ctm.Cust_Idcard_district);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province", cls_grt.ctm.Cust_Idcard_province);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_country", cls_grt.ctm.Cust_Idcard_country);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_zipcode", cls_grt.ctm.Cust_Idcard_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_tel", cls_grt.ctm.Cust_Idcard_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_Status_id", cls_grt.ctm.ctm_idcard_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_address_no", cls_grt.ctm.Cust_Current_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage", cls_grt.ctm.Cust_Current_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage_no", cls_grt.ctm.Cust_Current_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_alley", cls_grt.ctm.Cust_Current_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Current_road", cls_grt.ctm.Cust_Current_road);
                cmd.Parameters.AddWithValue("@i_Cust_Current_subdistrict", cls_grt.ctm.Cust_Current_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Current_district", cls_grt.ctm.Cust_Current_district);
                cmd.Parameters.AddWithValue("@i_Cust_Current_province", cls_grt.ctm.Cust_Current_province);
                cmd.Parameters.AddWithValue("@i_Cust_Current_country", cls_grt.ctm.Cust_Current_country);
                cmd.Parameters.AddWithValue("@i_Cust_Current_zipcode", cls_grt.ctm.Cust_Current_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Current_tel", cls_grt.ctm.Cust_Current_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Current_Status_id", cls_grt.ctm.ctm_current_stt.Home_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> editGuarantorsLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> editGuarantorsLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool removeGuarantor(string Leasing_id, int Guarantor_no, string Cust_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ d_car_leasings_Guarantors ] :: 
                 * d_car_leasings_Guarantors (in i_Leasing_id varchar(50), in i_Guarantor_no int(1) , in i_Cust_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_car_leasings_guarantor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);
                cmd.Parameters.AddWithValue("@i_Guarantor_no", Guarantor_no);
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> removeGuarantor() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Guarantor_Manager --> removeGuarantor() ";
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