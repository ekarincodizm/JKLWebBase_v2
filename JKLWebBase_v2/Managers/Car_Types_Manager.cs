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
    public class Car_Types_Manager
    {
        private string error;
        private List<Base_Car_Types> lctp = new List<Base_Car_Types>();

        public List<Base_Car_Types> getCarBrands()
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
                    ctp.car_type_id = int.Parse(reader[0].ToString());
                    ctp.car_type_name = reader[1].ToString();
                    lctp.Add(ctp);
                }

                return lctp;
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