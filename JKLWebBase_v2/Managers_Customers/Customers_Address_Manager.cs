using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Customers;


namespace JKLWebBase_v2.Managers_Customers
{
    public class Customers_Address_Manager
    {
        private string error;

        public Customers_Address getCustomersAddressByCustomerId(string id, int type)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: THE StoredProcedure :: [ g_customers_address ] :: 
                 * g_customers_address (in i_Cust_id varchar(50), in i_Cust_Address_type_id int(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers_address", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", id);
                cmd.Parameters.AddWithValue("@i_Cust_Address_type_id", type);

                MySqlDataReader reader = cmd.ExecuteReader();

                Customers_Address cadd = new Customers_Address();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cadd.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cadd.Cust_Address_type_id = reader.IsDBNull(1) ? defaultNum : reader.GetInt32(1);
                    cadd.Cust_Address_no = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cadd.Cust_Vilage = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cadd.Cust_Vilage_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cadd.Cust_Alley = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cadd.Cust_Road = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cadd.Cust_Subdistrict = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cadd.Cust_District = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cadd.Cust_Province = reader.IsDBNull(9) ? defaultNum : reader.GetInt32(9);
                    cadd.Cust_Country = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cadd.Cust_Zipcode = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cadd.Cust_Tel = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cadd.Cust_Home_status_id = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    cadd.Cust_Gps_Latitude = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    cadd.Cust_Gps_Longitude = reader.IsDBNull(15) ? defaultString : reader.GetString(15);

                }

                return cadd;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Address_Manager --> getCustomersAddressByCustomerId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Address_Manager --> getCustomersAddressByCustomerId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addCustomersAddress(Customers_Address cadd)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: THE StoredProcedure :: [ i_customers_address ] :: 
                 * i_customers_address (in i_Cust_id varchar(50)        , in i_Cust_Address_type_id int(11) , in i_Cust_Address_no varchar(255)     , in i_Cust_Vilage varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       utf8                  utf8_general_ci       utf8_general_ci   
                 *                      in i_Cust_Vilage_no varchar(255), in i_Cust_Alley varchar(255)      , in i_Cust_Road varchar(255)           , in i_Cust_Subdistrict varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                 *              		in i_Cust_District varchar(255) , in i_Cust_Province int(11)        , in i_Cust_Country varchar(255)        , in i_Cust_Zipcode varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                 *             			in i_Cust_Tel varchar(255)      , in i_Cust_Home_status_id int(11)  , in i_Cust_Gps_Latitude varchar(255)   , i_Cust_Gps_Longitude varchar(255))  
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_customers_address", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Cust_id", cadd.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_Address_type_id", cadd.Cust_Address_type_id);
                cmd.Parameters.AddWithValue("@i_Cust_Address_no", cadd.Cust_Address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Vilage", cadd.Cust_Vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Vilage_no", cadd.Cust_Vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Alley", cadd.Cust_Alley);
                cmd.Parameters.AddWithValue("@i_Cust_Road", cadd.Cust_Road);
                cmd.Parameters.AddWithValue("@i_Cust_Subdistrict", cadd.Cust_Subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_District", cadd.Cust_District);
                cmd.Parameters.AddWithValue("@i_Cust_Province", cadd.Cust_Province);
                cmd.Parameters.AddWithValue("@i_Cust_Country", cadd.Cust_Country);
                cmd.Parameters.AddWithValue("@i_Cust_Zipcode", cadd.Cust_Zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Tel", cadd.Cust_Tel);
                cmd.Parameters.AddWithValue("@i_Cust_Home_status_id", cadd.Cust_Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Gps_Latitude", cadd.Cust_Gps_Latitude);
                cmd.Parameters.AddWithValue("@i_Cust_Gps_Longitude", cadd.Cust_Gps_Longitude);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Address_Manager --> getCustomersAddressByCustomerId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Address_Manager --> getCustomersAddressByCustomerId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}