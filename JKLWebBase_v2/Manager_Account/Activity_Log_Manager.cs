using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Manager_Account
{
    public class Activity_Log_Manager
    {
        private string error = string.Empty;

        public bool addActivityLogs(string i_log_details, string i_Account_id, int i_Company_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `i_activity_log` (IN i_log_details TEXT, IN i_Account_id VARCHAR(255), IN i_Company_id INT(11))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_activity_log", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_log_details", i_log_details);
                cmd.Parameters.AddWithValue("@i_Account_id", i_Account_id);
                cmd.Parameters.AddWithValue("@i_Company_id", i_Company_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Manager_Account --> Activity_Log_Manager --> addActivityLogs() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Manager_Account --> Activity_Log_Manager --> addActivityLogs() ";
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