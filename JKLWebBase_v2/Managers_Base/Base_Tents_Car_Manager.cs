using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Tents_Car_Manager
    {
        private string error;
        private List<Base_Tents_Car> lbtc = new List<Base_Tents_Car>();

        public List<Base_Tents_Car> getTents()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_tents_car";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                int defaultNum = 0;
                string defaultString = "";
                while (reader.Read())
                {
                    Base_Tents_Car btc = new Base_Tents_Car();
                    btc.Tent_car_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    btc.Tent_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    btc.Tent_local = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    lbtc.Add(btc);
                }

                return lbtc;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Tents_Car_Manager --> getTents() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Tents_Car_Manager --> getTents() ";
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