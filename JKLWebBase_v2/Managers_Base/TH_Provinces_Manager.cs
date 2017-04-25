using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class TH_Provinces_Manager
    {
        private string error;

        public TH_Provinces getProvinceById(int Province_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM th_provinces WHERE Province_id = " + Province_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                TH_Provinces th_pv = new TH_Provinces();

                if (reader.Read())
                {
                    th_pv.Province_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    th_pv.Province_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    th_pv.Province_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    th_pv.Geo_id = reader.IsDBNull(3) ? defaultNum : reader.GetInt32(3);
                }

                return th_pv;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> TH_Provinces_Manager --> getProvinceById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> TH_Provinces_Manager --> getProvinceById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public TH_Provinces getProvinceByName(string Province_name)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM th_provinces WHERE Province_name = '" + Province_name + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                TH_Provinces th_pv = new TH_Provinces();

                if (reader.Read())
                {
                    th_pv.Province_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    th_pv.Province_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    th_pv.Province_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    th_pv.Geo_id = reader.IsDBNull(3) ? defaultNum : reader.GetInt32(3);
                }

                return th_pv;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> TH_Provinces_Manager --> getProvinceByName() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> TH_Provinces_Manager --> getProvinceByName() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<TH_Provinces> getProvinces()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM th_provinces";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<TH_Provinces> list_th_pv = new List<TH_Provinces>();

                while (reader.Read())
                {
                    TH_Provinces th_pv = new TH_Provinces();

                    th_pv.Province_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    th_pv.Province_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    th_pv.Province_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    th_pv.Geo_id = reader.IsDBNull(3) ? defaultNum : reader.GetInt32(3);

                    list_th_pv.Add(th_pv);
                }

                return list_th_pv;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> TH_Provinces_Manager --> getProvinces ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> TH_Provinces_Manager --> getProvinces ";
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