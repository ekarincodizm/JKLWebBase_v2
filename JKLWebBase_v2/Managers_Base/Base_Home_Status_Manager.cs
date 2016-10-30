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
        private List<Base_Home_Status> lbhs = new List<Base_Home_Status>();

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
                while (reader.Read())
                {
                    Base_Home_Status bhs = new Base_Home_Status();
                    bhs.Home_status_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bhs.Home_status_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    lbhs.Add(bhs);
                }

                return lbhs;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Home_Status_Manager --> getHomeStatus() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Home_Status_Manager --> getHomeStatus() : " + ex.Message.ToString();
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