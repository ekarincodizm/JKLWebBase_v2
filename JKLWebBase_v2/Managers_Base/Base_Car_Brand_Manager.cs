using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Car_Brand_Manager
    {
        private string error;
        private List<Base_Car_Brands> lcb = new List<Base_Car_Brands>();

        public List<Base_Car_Brands> getCarBrands()
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
                    Base_Car_Brands cb = new Base_Car_Brands();
                    cb.car_brand_id = reader.GetInt32(0);
                    cb.car_brand_name_eng = reader.GetString(0);
                    cb.car_brand_name_th = reader.GetString(0);
                    lcb.Add(cb);
                }

                return lcb;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Car_Brand_Manager --> getCarBrands() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Car_Brand_Manager --> getCarBrands() : " + ex.Message.ToString();
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