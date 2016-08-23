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
                while (reader.Read())
                {
                    Base_Tents_Car btc = new Base_Tents_Car();
                    btc.Tent_car_id = int.Parse(reader[0].ToString());
                    btc.Tent_name = reader[1].ToString();
                    btc.Tent_local = reader[1].ToString();
                    lbtc.Add(btc);
                }

                return lbtc;
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