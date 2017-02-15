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

        public Base_Tents_Car getTentsById(int Tent_car_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_tents_car WHERE Tent_car_id = " + Tent_car_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Tents_Car bs_tnc = new Base_Tents_Car();

                if (reader.Read())
                {
                    bs_tnc.Tent_car_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_tnc.Tent_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_tnc.Tent_local = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                }

                return bs_tnc;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Tents_Car_Manager --> getTentsById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Tents_Car_Manager --> getTentsById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

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

                List<Base_Tents_Car> list_bs_tnc = new List<Base_Tents_Car>();

                while (reader.Read())
                {
                    Base_Tents_Car bs_tnc = new Base_Tents_Car();

                    bs_tnc.Tent_car_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_tnc.Tent_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_tnc.Tent_local = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    list_bs_tnc.Add(bs_tnc);
                }

                return list_bs_tnc;
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