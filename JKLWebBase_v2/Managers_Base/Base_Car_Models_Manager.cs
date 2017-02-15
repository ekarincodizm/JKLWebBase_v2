using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Car_Models_Manager
    {
        private string error;

        public List<Base_Car_Models> getCarModels()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_models";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Car_Models> list_bs_cmdl = new List<Base_Car_Models>();

                while (reader.Read())
                {
                    Base_Car_Models bs_cmdl = new Base_Car_Models();

                    bs_cmdl.car_model_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cmdl.car_model_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);

                    list_bs_cmdl.Add(bs_cmdl);
                }

                return list_bs_cmdl;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Models_Manager --> getCarModels()";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Models_Manager --> getCarModels()";
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