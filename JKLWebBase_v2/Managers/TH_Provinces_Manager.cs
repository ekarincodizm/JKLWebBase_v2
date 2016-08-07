using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Models;

namespace JKLWebBase_v2.Managers
{
    public class TH_Provinces_Manager
    {
        private string error;
        private List<TH_Provinces> lth_pv = new List<TH_Provinces>();

        public List<TH_Provinces> getProvinces()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM th_provinces";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TH_Provinces th_pv = new TH_Provinces();
                    th_pv.Province_id = int.Parse(reader["Province_id"].ToString());
                    th_pv.Province_code = reader["Province_code"].ToString();
                    th_pv.Province_name = reader["Province_name"].ToString();
                    th_pv.Geo_id = int.Parse(reader["Geo_id"].ToString());
                    lth_pv.Add(th_pv);
                }

                return lth_pv;
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