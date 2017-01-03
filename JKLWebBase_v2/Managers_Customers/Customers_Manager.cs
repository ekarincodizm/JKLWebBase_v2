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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> generateCustomerID() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> generateCustomerID() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
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

                List<Customers> list_cust = new List<Customers>();

                while (reader.Read())
                {
                    Customers cust = new Customers();

                    int defaultNum = 0;
                    string defaultString = "";

                    cust.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cust.Cust_idcard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cust.Cust_Fname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cust.Cust_LName = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cust.Cust_B_date = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cust.Cust_age = reader.IsDBNull(5) ? defaultNum : reader.GetInt32(5);
                    cust.Cust_Idcard_without = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cust.Cust_Idcard_start = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cust.Cust_Idcard_expire = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cust.Cust_Nationality = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9);
                    cust.Cust_Origin = reader.IsDBNull(10) ? defaultNum : reader.GetInt32(10);
                    cust.Cust_job = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cust.Cust_job_position = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cust.Cust_job_long = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    cust.Cust_job_local_name = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    cust.Cust_job_address_no = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cust.Cust_job_vilage = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    cust.Cust_job_vilage_no = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    cust.Cust_job_alley = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    cust.Cust_job_road = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    cust.Cust_job_subdistrict = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    cust.Cust_job_district = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    cust.Cust_job_province = reader.IsDBNull(22) ? defaultNum : reader.GetInt32(22);
                    cust.Cust_job_country = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    cust.Cust_job_zipcode = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    cust.Cust_job_tel = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    cust.Cust_job_email = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    cust.Cust_job_salary = reader.IsDBNull(27) ? defaultNum : reader.GetDouble(27);
                    cust.Cust_status_id = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28);
                    cust.Cust_save_date = reader.IsDBNull(29) ? defaultString : reader.GetString(29);

                    cust.bs_ntn = new Base_Nationalitys();
                    cust.bs_ntn.Nationality_id = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9);
                    cust.bs_ntn.Nationality_name_ENG = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    cust.bs_ntn.Nationality_name_TH = reader.IsDBNull(31) ? defaultString : reader.GetString(13);

                    cust.bs_org = new Base_Origins();
                    cust.bs_org.Origin_id = reader.IsDBNull(10) ? defaultNum : reader.GetInt32(10);
                    cust.bs_org.Origin_name_ENG = reader.IsDBNull(32) ? defaultString : reader.GetString(32);
                    cust.bs_org.Origin_name_TH = reader.IsDBNull(33) ? defaultString : reader.GetString(33);

                    cust.th_pv_job_ctm = new TH_Provinces();
                    cust.th_pv_job_ctm.Province_id = reader.IsDBNull(22) ? defaultNum : reader.GetInt32(22);
                    cust.th_pv_job_ctm.Province_name = reader.IsDBNull(34) ? defaultString : reader.GetString(34);

                    cust.bs_ps_st = new Base_Person_Status();
                    cust.bs_ps_st.person_status_id = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28);
                    cust.bs_ps_st.person_status_name = reader.IsDBNull(35) ? defaultString : reader.GetString(35);

                    list_cust.Add(cust);

                }

                return list_cust;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomers() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomers() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
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

                Customers cust = new Customers();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cust.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cust.Cust_idcard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cust.Cust_Fname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cust.Cust_LName = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cust.Cust_B_date = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cust.Cust_age = reader.IsDBNull(5) ? defaultNum : reader.GetInt32(5);
                    cust.Cust_Idcard_without = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cust.Cust_Idcard_start = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cust.Cust_Idcard_expire = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cust.Cust_Nationality = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9);
                    cust.Cust_Origin = reader.IsDBNull(10) ? defaultNum : reader.GetInt32(10);
                    cust.Cust_job = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cust.Cust_job_position = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cust.Cust_job_long = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    cust.Cust_job_local_name = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    cust.Cust_job_address_no = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cust.Cust_job_vilage = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    cust.Cust_job_vilage_no = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    cust.Cust_job_alley = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    cust.Cust_job_road = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    cust.Cust_job_subdistrict = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    cust.Cust_job_district = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    cust.Cust_job_province = reader.IsDBNull(22) ? defaultNum : reader.GetInt32(22);
                    cust.Cust_job_country = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    cust.Cust_job_zipcode = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    cust.Cust_job_tel = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    cust.Cust_job_email = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    cust.Cust_job_salary = reader.IsDBNull(27) ? defaultNum : reader.GetDouble(27);
                    cust.Cust_status_id = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28);
                    cust.Cust_save_date = reader.IsDBNull(29) ? defaultString : reader.GetString(29);

                    cust.bs_ntn = new Base_Nationalitys();
                    cust.bs_ntn.Nationality_id = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9);
                    cust.bs_ntn.Nationality_name_ENG = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    cust.bs_ntn.Nationality_name_TH = reader.IsDBNull(31) ? defaultString : reader.GetString(13);

                    cust.bs_org = new Base_Origins();
                    cust.bs_org.Origin_id = reader.IsDBNull(10) ? defaultNum : reader.GetInt32(10);
                    cust.bs_org.Origin_name_ENG = reader.IsDBNull(32) ? defaultString : reader.GetString(32);
                    cust.bs_org.Origin_name_TH = reader.IsDBNull(33) ? defaultString : reader.GetString(33);

                    cust.th_pv_job_ctm = new TH_Provinces();
                    cust.th_pv_job_ctm.Province_id = reader.IsDBNull(22) ? defaultNum : reader.GetInt32(22);
                    cust.th_pv_job_ctm.Province_name = reader.IsDBNull(34) ? defaultString : reader.GetString(34);

                    cust.bs_ps_st = new Base_Person_Status();
                    cust.bs_ps_st.person_status_id = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28);
                    cust.bs_ps_st.person_status_name = reader.IsDBNull(35) ? defaultString : reader.GetString(35);
                }

                return cust;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomersByIdCard() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomersByIdCard() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addCustomers(Customers cust)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_customers ] :: 
                 * i_customers (in i_Cust_id varchar(50)                , in i_Cust_idcard varchar(255)         , in i_Cust_Fname varchar(255)      , in i_Cust_LName varchar(255)          , in i_Cust_B_date date, in i_Cust_age int(11),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                utf8                  utf8_general_ci       utf8_general_ci   
                 *     		    in i_Cust_Idcard_without  varchar(255)  , in i_Cust_Idcard_start date           , in i_Cust_Idcard_expire date      , in i_Cust_Nationality int(11)         , in i_Cust_Origin int(11),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                 *      		in i_Cust_job varchar(50)               , in i_Cust_job_position varchar(255)   , in i_Cust_job_long int(11)        , in i_Cust_job_local_name varchar(255) , in i_Cust_job_address_no varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
                 *      		in i_Cust_job_vilage varchar(255)       , in i_Cust_job_vilage_no varchar(255)  , in i_Cust_job_alley varchar(255)  , in i_Cust_job_road varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                 *      		in i_Cust_job_subdistrict varchar(255)  , in i_Cust_job_district varchar(255)   , in i_Cust_job_province int(11)    , in i_Cust_job_country varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                 *      		in i_Cust_job_zipcode varchar(255)      , in i_Cust_job_tel varchar(255)        , in i_Cust_job_email varchar(255)  , in i_Cust_job_salary double(10,2), in i_Cust_status_id int(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_customers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Cust_id", cust.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_idcard", cust.Cust_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", cust.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", cust.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", cust.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_age", cust.Cust_age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", cust.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", cust.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", cust.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality", cust.Cust_Nationality);
                cmd.Parameters.AddWithValue("@i_Cust_Origin", cust.Cust_Origin);
                cmd.Parameters.AddWithValue("@i_Cust_job", cust.Cust_job);
                cmd.Parameters.AddWithValue("@i_Cust_job_position", cust.Cust_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_job_long", cust.Cust_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_job_local_name", cust.Cust_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_job_address_no", cust.Cust_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_job_vilage", cust.Cust_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_job_vilage_no", cust.Cust_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_job_alley", cust.Cust_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_job_road", cust.Cust_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_job_subdistrict", cust.Cust_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_job_district", cust.Cust_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_job_province", cust.Cust_job_province);
                cmd.Parameters.AddWithValue("@i_Cust_job_country", cust.Cust_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_job_zipcode", cust.Cust_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_job_tel", cust.Cust_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_job_email", cust.Cust_job_email);
                cmd.Parameters.AddWithValue("@i_Cust_job_salary", cust.Cust_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_status_id", cust.Cust_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> addCustomers() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> addCustomers() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editCustomers(Customers cust)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ u_customers ] :: 
                 * u_customers (in i_Cust_id varchar(50)                , in i_Cust_idcard varchar(255)         , in i_Cust_Fname varchar(255)      , in i_Cust_LName varchar(255)          , in i_Cust_B_date date, in i_Cust_age int(11),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                utf8                  utf8_general_ci       utf8_general_ci   
                 *     		    in i_Cust_Idcard_without  varchar(255)  , in i_Cust_Idcard_start date           , in i_Cust_Idcard_expire date      , in i_Cust_Nationality int(11)         , in i_Cust_Origin int(11),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                 *      		in i_Cust_job varchar(50)               , in i_Cust_job_position varchar(255)   , in i_Cust_job_long int(11)        , in i_Cust_job_local_name varchar(255) , in i_Cust_job_address_no varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
                 *      		in i_Cust_job_vilage varchar(255)       , in i_Cust_job_vilage_no varchar(255)  , in i_Cust_job_alley varchar(255)  , in i_Cust_job_road varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                 *      		in i_Cust_job_subdistrict varchar(255)  , in i_Cust_job_district varchar(255)   , in i_Cust_job_province int(11)    , in i_Cust_job_country varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                 *      		in i_Cust_job_zipcode varchar(255)      , in i_Cust_job_tel varchar(255)        , in i_Cust_job_email varchar(255)  , in i_Cust_job_salary double(10,2), in i_Cust_status_id int(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_customers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Cust_id", cust.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_idcard", cust.Cust_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", cust.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", cust.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", cust.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_age", cust.Cust_age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", cust.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", cust.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", cust.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality", cust.Cust_Nationality);
                cmd.Parameters.AddWithValue("@i_Cust_Origin", cust.Cust_Origin);
                cmd.Parameters.AddWithValue("@i_Cust_job", cust.Cust_job);
                cmd.Parameters.AddWithValue("@i_Cust_job_position", cust.Cust_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_job_long", cust.Cust_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_job_local_name", cust.Cust_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_job_address_no", cust.Cust_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_job_vilage", cust.Cust_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_job_vilage_no", cust.Cust_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_job_alley", cust.Cust_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_job_road", cust.Cust_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_job_subdistrict", cust.Cust_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_job_district", cust.Cust_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_job_province", cust.Cust_job_province);
                cmd.Parameters.AddWithValue("@i_Cust_job_country", cust.Cust_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_job_zipcode", cust.Cust_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_job_tel", cust.Cust_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_job_email", cust.Cust_job_email);
                cmd.Parameters.AddWithValue("@i_Cust_job_salary", cust.Cust_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_status_id", cust.Cust_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> editCustomers() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> editCustomers( : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> generateDigitID() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> generateDigitID() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
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
                 * :: StoredProcedure :: [ g_last_customers_homeaddress_photo_by_id ] :: 
                 * g_last_customers_homeaddress_photo_by_id (IN i_Cust_id varchar(50), IN i_Address_type_id int(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_last_customers_homeaddress_photo_by_id", con);
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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getLastNumberPhotoId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getLastNumberPhotoId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Customers_Homeaddress_Photo> getCustomersHomePhoto(string Cust_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_customers_homeaddress_photo ] :: 
                 * g_customers_homeaddress_photo (IN i_Cust_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers_homeaddress_photo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Customers_Homeaddress_Photo> list_ctm_photo = new List<Customers_Homeaddress_Photo>();

                while (reader.Read())
                {
                    Customers_Homeaddress_Photo ctm_photo = new Customers_Homeaddress_Photo();

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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhoto() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhoto() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Customers_Homeaddress_Photo getCustomersHomePhotoSelected(string Cust_id, string Home_img_num)
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

                Customers_Homeaddress_Photo ctm_photo = new Customers_Homeaddress_Photo();

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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhotoSelected) : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> getCustomersHomePhotoSelected() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addCustomersHomePhoto(Customers_Homeaddress_Photo ctm_photo)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_customers_homeaddress_photo ] :: 
                 * i_customers_homeaddress_photo   (in i_Cust_id varchar(50),       in i_Home_img_num int(11),      in i_Home_img_old_name text,    in i_Home_img_path text, 
				 *					                in i_Home_img_full_path text,   in i_Home_img_local_path text)
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_customers_homeaddress_photo", con);
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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> addCustomersHomePhoto() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> addCustomersHomePhoto() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
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
                 * :: StoredProcedure :: [ d_customers_homeaddress_photo ] :: 
                 * d_customers_homeaddress_photo (IN i_Cust_id varchar(50), IN i_Home_img_num INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_customers_homeaddress_photo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);
                cmd.Parameters.AddWithValue("@i_Home_img_num", Home_img_num);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> removeCustomersHomePhoto() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> removeCustomersHomePhoto() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}