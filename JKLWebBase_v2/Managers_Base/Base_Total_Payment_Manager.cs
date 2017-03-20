using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Total_Payment_Manager
    {
        private string error;

        public Base_Total_Payment getTotalPaymentById(int Total_payment_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_total_payment WHERE Total_payment_id = " + Total_payment_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Total_Payment bs_t_pay = new Base_Total_Payment();

                while (reader.Read())
                {
                    bs_t_pay.Total_payment_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_t_pay.Total_payment_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                }

                return bs_t_pay;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Total_Payment_Manager --> getTotalPaymentById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Total_Payment_Manager --> getTotalPaymentById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Total_Payment> getTotalPayment()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_total_payment";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Total_Payment> list_bs_t_pay = new List<Base_Total_Payment>();

                while (reader.Read())
                {
                    Base_Total_Payment bs_t_pay = new Base_Total_Payment();

                    bs_t_pay.Total_payment_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_t_pay.Total_payment_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);

                    list_bs_t_pay.Add(bs_t_pay);
                }

                return list_bs_t_pay;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Total_Payment_Manager --> getTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Total_Payment_Manager --> getTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addTotalPayment(string i_Total_payment_name)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `i_base_total_payment`(IN i_Total_payment_name VARCHAR(255))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_base_total_payment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Total_payment_name", i_Total_payment_name);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Total_Payment_Manager --> addTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Total_Payment_Manager --> addTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editTotalPayment(int i_Total_payment_id, string i_Total_payment_name)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `u_base_total_payment`(IN i_Total_payment_id INT(11), IN i_Total_payment_name VARCHAR(255))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_base_total_payment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Total_payment_id", i_Total_payment_id);
                cmd.Parameters.AddWithValue("@i_Total_payment_name", i_Total_payment_name);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Total_Payment_Manager --> editTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Total_Payment_Manager --> editTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeTotalPayment(int i_Total_payment_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `d_base_total_payment`(IN i_Total_payment_id INT(11))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_base_total_payment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Total_payment_id", i_Total_payment_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Total_Payment_Manager --> removeTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Total_Payment_Manager --> removeTotalPayment() ";
                Log_Error._writeErrorFile(error, ex);
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