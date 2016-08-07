using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Models;
using System.Configuration;

namespace JKLWebBase_v2.Managers
{
    public class Car_Models_Manager
    {
        private string error;
        private List<Car_Models> lcm = new List<Car_Models>();

        public List<Car_Models> getCarBrands(int car_brand_id)
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
                    Car_Models cm = new Car_Models();
                    cm.car_model_id = int.Parse(reader[0].ToString());
                    cm.car_brand_id = int.Parse(reader[1].ToString());
                    cm.car_model_name = reader[2].ToString();
                    lcm.Add(cm);
                }

                return lcm;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException Form Car_Brand_Manager at getCarBrands : " + ex.Message.ToString();
                //Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception Form Car_Brand_Manager at getCarBrands : " + ex.Message.ToString();
                //Log_Error._writeErrorFile(error);
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