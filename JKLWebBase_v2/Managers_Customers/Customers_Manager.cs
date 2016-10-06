using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Customers;
using System.Data;

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
                    id = reader[0].ToString();
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
                con.Open();
                string sql = "SELECT * FROM customers WHERE Cust_idcard = '" + idcard + "' ";
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
                con.Dispose();
            }
        }

        public bool addCustomers(Customers cust)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                MySqlCommand cmd = new MySqlCommand("customers_add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new MySqlParameter("?i_Cust_id", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_id"].Value = cust.Cust_id;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_idcard", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_idcard"].Value = cust.Cust_idcard;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_Fname", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_Fname"].Value = cust.Cust_Fname;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_LName", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_LName"].Value = cust.Cust_LName;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_B_date", MySqlDbType.Date));
                cmd.Parameters["?i_Cust_B_date"].Value = cust.Cust_B_date;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_age", MySqlDbType.Int32));
                cmd.Parameters["?i_Cust_age"].Value = cust.Cust_age;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_Idcard_without", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_Idcard_without"].Value = cust.Cust_Idcard_without;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_Idcard_start", MySqlDbType.Date));
                cmd.Parameters["?i_Cust_Idcard_start"].Value = cust.Cust_Idcard_start;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_Idcard_expire", MySqlDbType.Date));
                cmd.Parameters["?i_Cust_Idcard_expire"].Value = cust.Cust_Idcard_expire;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_Nationality", MySqlDbType.Int32));
                cmd.Parameters["?i_Cust_Nationality"].Value = cust.Cust_Nationality;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_Origin", MySqlDbType.Int32));
                cmd.Parameters["?i_Cust_Origin"].Value = cust.Cust_Origin;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job"].Value = cust.Cust_job;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_position", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_position"].Value = cust.Cust_job_position;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_long", MySqlDbType.Int32));
                cmd.Parameters["?i_Cust_job_long"].Value = cust.Cust_job_long;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_local_name", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_local_name"].Value = cust.Cust_job_local_name;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_address_no", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_address_no"].Value = cust.Cust_job_address_no;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_vilage", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_vilage"].Value = cust.Cust_job_vilage;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_vilage_no", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_vilage_no"].Value = cust.Cust_job_vilage_no;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_alley", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_alley"].Value = cust.Cust_job_alley;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_road", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_road"].Value = cust.Cust_job_road;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_subdistrict", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_subdistrict"].Value = cust.Cust_job_subdistrict;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_district", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_district"].Value = cust.Cust_job_district;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_province", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_province"].Value = cust.Cust_job_province;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_contry", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_contry"].Value = cust.Cust_job_contry;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_zipcode", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_zipcode"].Value = cust.Cust_job_zipcode;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_tel", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_tel"].Value = cust.Cust_job_tel;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_email", MySqlDbType.VarChar));
                cmd.Parameters["?i_Cust_job_email"].Value = cust.Cust_job_email;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_job_salary", MySqlDbType.Double));
                cmd.Parameters["?i_Cust_job_salary"].Value = cust.Cust_job_salary;

                cmd.Parameters.Add(new MySqlParameter("?i_Cust_status_id", MySqlDbType.Int32));
                cmd.Parameters["?i_Cust_status_id"].Value = cust.Cust_status_id;

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
                con.Dispose();
            }
        }
    }
}