using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Customers;

namespace JKLWebBase_v2.Managers_Customers
{
    public class Customers_Spouse_Manager
    {
        private string error;

        public Customers getCustomersSpouseByCustomerId(string id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM customers_spouse WHERE Cust_id = '" + id + "' ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                Customers cust = new Customers();
                if (reader.Read())
                {
                    cust.Cust_id = reader[0].ToString();
                    cust.Cust_idcard = reader[1].ToString();
                    cust.Cust_Fname = reader[2].ToString();
                    cust.Cust_LName = reader[3].ToString();
                    cust.Cust_B_date = reader[4].ToString();
                    cust.Cust_age = Convert.ToInt32(reader[5].ToString());
                    cust.Cust_Idcard_without = reader[6].ToString();
                    cust.Cust_Idcard_start = reader[7].ToString();
                    cust.Cust_Idcard_expire = reader[8].ToString();
                    cust.Cust_Nationality = Convert.ToInt32(reader[9].ToString());
                    cust.Cust_Origin = Convert.ToInt32(reader[10].ToString());
                    cust.Cust_job = reader[11].ToString();
                    cust.Cust_job_position = reader[12].ToString();
                    cust.Cust_job_long = Convert.ToInt32(reader[13].ToString());
                    cust.Cust_job_local_name = reader[14].ToString();
                    cust.Cust_job_address_no = reader[15].ToString();
                    cust.Cust_job_vilage = reader[16].ToString();
                    cust.Cust_job_vilage_no = reader[17].ToString();
                    cust.Cust_job_alley = reader[18].ToString();
                    cust.Cust_job_road = reader[19].ToString();
                    cust.Cust_job_subdistrict = reader[20].ToString();
                    cust.Cust_job_district = reader[21].ToString();
                    cust.Cust_job_province = Convert.ToInt32(reader[22].ToString());
                    cust.Cust_job_contry = reader[23].ToString();
                    cust.Cust_job_zipcode = reader[24].ToString();
                    cust.Cust_job_tel = reader[25].ToString();
                    cust.Cust_job_email = reader[26].ToString();
                    cust.Cust_job_salary = Convert.ToDouble(reader[27].ToString());
                    cust.Cust_status_id = Convert.ToInt32(reader[28].ToString());
                }

                return cust;
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
                con.Open();
                string sql = "SELECT * FROM customers_spouse WHERE Cust_id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

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