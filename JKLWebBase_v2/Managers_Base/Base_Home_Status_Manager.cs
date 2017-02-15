using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Home_Status_Manager
    {
        private string error;

        public Base_Home_Status getHomeStatusById(int Home_status_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_home_status WHERE Home_status_id = " + Home_status_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Home_Status bs_home_stt = new Base_Home_Status();

                while (reader.Read())
                {
                    bs_home_stt.Home_status_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_home_stt.Home_status_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                }

                return bs_home_stt;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Home_Status_Manager --> getHomeStatusById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Home_Status_Manager --> getHomeStatusById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Home_Status> getHomeStatus()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_home_status";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Home_Status> list_bs_home_stt = new List<Base_Home_Status>();

                while (reader.Read())
                {
                    Base_Home_Status bs_home_stt = new Base_Home_Status();

                    bs_home_stt.Home_status_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_home_stt.Home_status_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);

                    list_bs_home_stt.Add(bs_home_stt);
                }

                return list_bs_home_stt;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Home_Status_Manager --> getHomeStatus() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Home_Status_Manager --> getHomeStatus() ";
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