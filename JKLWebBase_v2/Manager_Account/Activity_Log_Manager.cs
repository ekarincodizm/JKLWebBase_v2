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

        public List<Activity_Log> listActivityLogs(string i_log_date_str, string i_log_date_end, string i_Account_id, string i_Company_id, int i_row_str, int i_row_limit)
        {
            /// PROCEDURE 'g_activity_logs' (IN i_log_date_str VARCHAR(255), IN i_log_date_end VARCHAR(255), IN i_Account_id VARCHAR(255),
            /// IN i_Company_id VARCHAR(255), i_row_str INT(11), IN i_row_limit INT(11))

            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_activity_logs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_log_date_str", i_log_date_str);
                cmd.Parameters.AddWithValue("@i_log_date_end", i_log_date_end);
                cmd.Parameters.AddWithValue("@i_Account_id", i_Account_id);
                cmd.Parameters.AddWithValue("@i_Company_id", i_Company_id);
                cmd.Parameters.AddWithValue("@i_row_str", i_row_str);
                cmd.Parameters.AddWithValue("@i_row_limit", i_row_limit);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Activity_Log> list_data = new List<Activity_Log>();

                while (reader.Read())
                {
                    Activity_Log act_log = new Activity_Log();

                    act_log.log_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    act_log.log_date = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    act_log.log_details = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    act_log.acc_lgn = new Account_Login();
                    act_log.acc_lgn.Account_id = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    act_log.acc_lgn.Account_F_name = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    act_log.acc_lgn.Account_N_Name = reader.IsDBNull(5) ? defaultString : reader.GetString(5);

                    act_log.bs_cpn = new Base_Companys();
                    act_log.bs_cpn.Company_id = reader.IsDBNull(6) ? defaultNum : reader.GetInt32(6);
                    act_log.bs_cpn.Company_code = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    act_log.bs_cpn.Company_N_name = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    act_log.bs_cpn.Company_F_name = reader.IsDBNull(9) ? defaultString : reader.GetString(9);

                    list_data.Add(act_log);
                }

                return list_data;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Manager_Account --> Activity_Log_Manager --> listActivityLogs() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Manager_Account --> Activity_Log_Manager --> listActivityLogs() ";
                Log_Error._writeErrorFile(error, ex);
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