using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Total_Payment_Manager
    {
        private string error;
        private List<Base_Total_Payment> lbtp = new List<Base_Total_Payment>();

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
                while (reader.Read())
                {
                    Base_Total_Payment btp = new Base_Total_Payment();
                    btp.Total_payment_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    btp.Total_payment_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    lbtp.Add(btp);
                }

                return lbtp;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Total_Payment_Manager --> getTotalPayment() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Total_Payment_Manager --> getTotalPayment() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}