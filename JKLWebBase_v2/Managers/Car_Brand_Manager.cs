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
    public class Car_Brand_Manager
    {
        private string error;
        private List<Car_Brands> car_brand = new List<Car_Brands>();

        public List<Car_Brands> getCarBrands()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_brands";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Car_Brands cb = new Car_Brands();
                    cb.car_brand_id = int.Parse(reader[0].ToString());
                    cb.car_brand_name_eng = reader[1].ToString();
                    cb.car_brand_name_th = reader[2].ToString();
                    car_brand.Add(cb);
                }

                return car_brand;
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