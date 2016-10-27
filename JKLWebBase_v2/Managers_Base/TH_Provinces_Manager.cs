using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
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
                    th_pv.Province_id = reader.GetInt32(0);
                    th_pv.Province_code = reader.GetString(1);
                    th_pv.Province_name = reader.GetString(2);
                    th_pv.Geo_id = reader.GetInt32(3);
                    lth_pv.Add(th_pv);
                }

                return lth_pv;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Car_Brand_Manager --> getCarBrands : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Car_Brand_Manager --> getCarBrands : " + ex.Message.ToString();
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