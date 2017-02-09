using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Car_Types_Manager
    {
        private string error;
        private List<Base_Car_Types> lctp = new List<Base_Car_Types>();

        public List<Base_Car_Types> getCarTypes()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_types";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                int defaultNum = 0;
                string defaultString = "";
                while (reader.Read())
                {
                    Base_Car_Types ctp = new Base_Car_Types();
                    ctp.car_type_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    ctp.car_type_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    lctp.Add(ctp);
                }

                return lctp;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() ";
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