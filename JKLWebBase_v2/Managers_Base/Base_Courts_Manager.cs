using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Courts_Manager
    {
        private string error;
        private List<Base_Courts> lbct = new List<Base_Courts>();

        public List<Base_Courts> getCourts()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_courts";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                int defaultNum = 0;
                string defaultString = "";
                while (reader.Read())
                {
                    Base_Courts bct = new Base_Courts();
                    bct.Court_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bct.Court_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    lbct.Add(bct);
                }

                return lbct;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Courts_Manager --> getCourts() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Courts_Manager --> getCourts() : " + ex.Message.ToString();
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