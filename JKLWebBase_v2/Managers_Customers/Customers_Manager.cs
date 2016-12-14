using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
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
                    id = reader.GetString(0);
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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> addCustomers(Customers cust) : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> addCustomers(Customers cust) : " + ex.Message.ToString();
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
                error = "MysqlException ==> Managers_Customers --> Customers_Manager --> editCustomers(Customers cust) : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Manager --> editCustomers(Customers cust) : " + ex.Message.ToString();
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