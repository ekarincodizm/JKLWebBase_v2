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
        private List<Base_Car_Models> lcm = new List<Base_Car_Models>();

        public List<Base_Car_Models> getCarModels(int car_brand_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_models WHERE Car_brand_id = " + car_brand_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Base_Car_Models cm = new Base_Car_Models();
                    cm.car_model_id = reader.GetInt32(0);
                    cm.car_brand_id = reader.GetInt32(1);
                    cm.car_model_name = reader.GetString(2);
                    lcm.Add(cm);
                }

                return lcm;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Car_Brand_Manager --> getCarBrands(int car_brand_id) : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Car_Brand_Manager --> getCarBrands(int car_brand_id) : " + ex.Message.ToString();
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