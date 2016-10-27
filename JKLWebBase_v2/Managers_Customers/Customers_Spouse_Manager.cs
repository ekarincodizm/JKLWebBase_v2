﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Customers;


namespace JKLWebBase_v2.Managers_Customers
{
    public class Customers_Spouse_Manager
    {
        private string error;

        public Customers_Spouse getCustomersSpouseByCustomerId(string id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: THE StoredProcedure :: [ g_customers_spouse ] :: 
                 *  g_customers_spouse (in i_Cust_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_customers_spouse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Cust_id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                Customers_Spouse cmarry = new Customers_Spouse();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cmarry.Cust_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cmarry.Spouse_idcard = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cmarry.Spouse_Fname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cmarry.Spouse_Lname = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cmarry.Spouse_Nationality = reader.IsDBNull(4) ? defaultNum : reader.GetInt32(4);
                    cmarry.Spouse_Origin = reader.IsDBNull(5) ? defaultNum : reader.GetInt32(5);
                    cmarry.Spouse_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cmarry.Spouse_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cmarry.Spouse_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cmarry.Spouse_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cmarry.Spouse_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cmarry.Spouse_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cmarry.Spouse_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cmarry.Spouse_province = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    cmarry.Spouse_country = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    cmarry.Spouse_zipcode = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cmarry.Spouse_job = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    cmarry.Spouse_job_position = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    cmarry.Spouse_job_long = reader.IsDBNull(18) ? defaultNum : reader.GetInt32(18);
                    cmarry.Spouse_job_salary = reader.IsDBNull(19) ? defaultNum : reader.GetDouble(19);
                    cmarry.Spouse_job_local_name = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    cmarry.Spouse_job_address_no = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    cmarry.Spouse_job_vilage = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    cmarry.Spouse_job_vilage_no = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    cmarry.Spouse_job_alley = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    cmarry.Spouse_job_road = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    cmarry.Spouse_job_subdistrict = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    cmarry.Spouse_job_district = reader.IsDBNull(27) ? defaultString : reader.GetString(27);
                    cmarry.Spouse_job_province = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28);
                    cmarry.Spouse_job_country = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    cmarry.Spouse_job_zipcode = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    cmarry.Spouse_job_tel = reader.IsDBNull(31) ? defaultString : reader.GetString(31);
                    cmarry.Spouse_tel = reader.IsDBNull(32) ? defaultString : reader.GetString(32);
                    cmarry.Spouse_email = reader.IsDBNull(33) ? defaultString : reader.GetString(33);


                }

                return cmarry;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Spouse_Manager --> getCustomersSpouseByCustomerId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Spouse_Manager --> getCustomersSpouseByCustomerId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addCustomersSpouse(Customers_Spouse cmarry)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: THE StoredProcedure :: [ i_customers_spouse ] :: 
                 *  i_customers_spouse (in i_Cust_id varchar(50)                , in i_Spouse_idcard varchar(50)            , in i_Spouse_Fname varchar(255)            , in i_Spouse_Lname varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               utf8                  utf8_general_ci       utf8_general_ci   
                 *                      in i_Spouse_Nationality int(11)         , in i_Spouse_Origin int(11)                , in i_Spouse_address_no varchar(255)       , in i_Spouse_vilage varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
                 *             			in i_Spouse_vilage_no varchar(255)      , in i_Spouse_alley varchar(255)            , in i_Spouse_road varchar(255)             , in i_Spouse_subdistrict varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                 *             			in i_Spouse_district varchar(255)       , in i_Spouse_province int(11)              , in i_Spouse_country varchar(255)          , in i_Spouse_zipcode varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                 *             			in i_Spouse_job varchar(255)            , in i_Spouse_job_position varchar(255)     , in i_Spouse_job_long int(11)              , in i_Spouse_job_salary double(10,2),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                 *             			in i_Spouse_job_local_name varchar(255) , in i_Spouse_job_address_no varchar(255)   , in i_Spouse_job_vilage varchar(255)       , in i_Spouse_job_vilage_no varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                 *             			in i_Spouse_job_alley varchar(255)      , in i_Spouse_job_road varchar(255)         , in i_Spouse_job_subdistrict varchar(255)  , in i_Spouse_job_district varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                 *             			in i_Spouse_job_province int(11)        , in i_Spouse_job_country varchar(255)      , in i_Spouse_job_zipcode varchar(255)      , in i_Spouse_job_tel varchar(255),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                 *            			in i_Spouse_tel varchar(255)            , in i_Spouse_email varchar(255))   
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_customers_spouse", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Cust_id", cmarry.Cust_id);
                cmd.Parameters.AddWithValue("@i_Spouse_idcard", cmarry.Spouse_idcard);
                cmd.Parameters.AddWithValue("@i_Spouse_Fname", cmarry.Spouse_Fname);
                cmd.Parameters.AddWithValue("@i_Spouse_Lname", cmarry.Spouse_Lname);
                cmd.Parameters.AddWithValue("@i_Spouse_Nationality", cmarry.Spouse_Nationality);
                cmd.Parameters.AddWithValue("@i_Spouse_Origin", cmarry.Spouse_Origin);
                cmd.Parameters.AddWithValue("@i_Spouse_address_no", cmarry.Spouse_address_no);
                cmd.Parameters.AddWithValue("@i_Spouse_vilage", cmarry.Spouse_vilage);
                cmd.Parameters.AddWithValue("@i_Spouse_vilage_no", cmarry.Spouse_vilage_no);
                cmd.Parameters.AddWithValue("@i_Spouse_alley", cmarry.Spouse_alley);
                cmd.Parameters.AddWithValue("@i_Spouse_road", cmarry.Spouse_road);
                cmd.Parameters.AddWithValue("@i_Spouse_subdistrict", cmarry.Spouse_subdistrict);
                cmd.Parameters.AddWithValue("@i_Spouse_district", cmarry.Spouse_district);
                cmd.Parameters.AddWithValue("@i_Spouse_province", cmarry.Spouse_province);
                cmd.Parameters.AddWithValue("@i_Spouse_country", cmarry.Spouse_country);
                cmd.Parameters.AddWithValue("@i_Spouse_zipcode", cmarry.Spouse_zipcode);
                cmd.Parameters.AddWithValue("@i_Spouse_job", cmarry.Spouse_job);
                cmd.Parameters.AddWithValue("@i_Spouse_job_position", cmarry.Spouse_job_position);
                cmd.Parameters.AddWithValue("@i_Spouse_job_long", cmarry.Spouse_job_long);
                cmd.Parameters.AddWithValue("@i_Spouse_job_salary", cmarry.Spouse_job_salary);
                cmd.Parameters.AddWithValue("@i_Spouse_job_local_name", cmarry.Spouse_job_local_name);
                cmd.Parameters.AddWithValue("@i_Spouse_job_address_no", cmarry.Spouse_job_address_no);
                cmd.Parameters.AddWithValue("@i_Spouse_job_vilage", cmarry.Spouse_job_vilage);
                cmd.Parameters.AddWithValue("@i_Spouse_job_vilage_no", cmarry.Spouse_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Spouse_job_alley", cmarry.Spouse_job_alley);
                cmd.Parameters.AddWithValue("@i_Spouse_job_road", cmarry.Spouse_job_road);
                cmd.Parameters.AddWithValue("@i_Spouse_job_subdistrict", cmarry.Spouse_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Spouse_job_district", cmarry.Spouse_job_district);
                cmd.Parameters.AddWithValue("@i_Spouse_job_province", cmarry.Spouse_job_province);
                cmd.Parameters.AddWithValue("@i_Spouse_job_country", cmarry.Spouse_job_country);
                cmd.Parameters.AddWithValue("@i_Spouse_job_zipcode", cmarry.Spouse_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Spouse_job_tel", cmarry.Spouse_job_tel);
                cmd.Parameters.AddWithValue("@i_Spouse_tel", cmarry.Spouse_tel);
                cmd.Parameters.AddWithValue("@i_Spouse_email", cmarry.Spouse_email);


                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Customers --> Customers_Spouse_Manager --> getCustomersSpouseByCustomerId() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Customers --> Customers_Spouse_Manager --> getCustomersSpouseByCustomerId() : " + ex.Message.ToString();
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