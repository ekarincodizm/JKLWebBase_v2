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
                while (reader.Read())
                {
                    Base_Car_Types ctp = new Base_Car_Types();
                    ctp.car_type_id = reader.GetInt32(0);
                    ctp.car_type_name = reader.GetString(1);
                    lctp.Add(ctp);
                }

                return lctp;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() : " + ex.Message.ToString();
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