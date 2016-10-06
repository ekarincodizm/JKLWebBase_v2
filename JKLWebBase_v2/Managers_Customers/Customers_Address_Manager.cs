using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
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
                con.Open();
                string sql = "SELECT * FROM customers_address WHERE Cust_id = '" + id + "' AND Cust_Address_type_id = " + type;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                Customers_Address cadd = new Customers_Address();
                if (reader.Read())
                {
                    cadd.Cust_idcard = reader[0].ToString();
                    cadd.Cust_Address_type_id = Convert.ToInt32(reader[1].ToString());
                    cadd.Cust_Address_no = reader[2].ToString();
                    cadd.Cust_Vilage = reader[3].ToString();
                    cadd.Cust_Vilage_no = reader[4].ToString();
                    cadd.Cust_Alley = reader[5].ToString();
                    cadd.Cust_Road = reader[6].ToString();
                    cadd.Cust_Subdistrict = reader[7].ToString();
                    cadd.Cust_District = reader[8].ToString();
                    cadd.Cust_Province = Convert.ToInt32(reader[9].ToString());
                    cadd.Cust_Country = reader[10].ToString();
                    cadd.Cust_Zipcode = reader[11].ToString();
                    cadd.Cust_Tel = reader[12].ToString();
                    cadd.Cust_Home_status_id = Convert.ToInt32(reader[13].ToString());
                    cadd.Cust_Gps_Latitude = reader[14].ToString();
                    cadd.Cust_Gps_Longitude = reader[15].ToString();

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