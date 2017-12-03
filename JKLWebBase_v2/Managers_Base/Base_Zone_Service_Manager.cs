using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Zone_Service_Manager
    {
        private string error;

        public Base_Zone_Service getZoneById(int Zone_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_zones_service WHERE Zone_id = "+ Zone_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Zone_Service bs_zn = new Base_Zone_Service();

                if (reader.Read())
                {
                    bs_zn.Zone_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_zn.Zone_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_zn.Zone_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                }

                return bs_zn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Zone_Service_Manager --> getZoneById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Zone_Service_Manager --> getZoneById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Zone_Service> getZoneService()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_zones_service";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Zone_Service> list_bs_zn = new List<Base_Zone_Service>();

                while (reader.Read())
                {
                    Base_Zone_Service bs_zn = new Base_Zone_Service();

                    bs_zn.Zone_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_zn.Zone_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_zn.Zone_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    list_bs_zn.Add(bs_zn);
                }

                return list_bs_zn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Zone_Service_Manager --> getZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Zone_Service_Manager --> getZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addZoneService(string i_Zone_code, string i_Zone_name)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_base_zone_service", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Zone_code", i_Zone_code);
                cmd.Parameters.AddWithValue("@i_Zone_name", i_Zone_name);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Zone_Service_Manager --> addZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Zone_Service_Manager --> addZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editZoneService(int i_Zone_id, string i_Zone_code, string i_Zone_name)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_base_zone_service", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Zone_id", i_Zone_id);
                cmd.Parameters.AddWithValue("@i_Zone_code", i_Zone_code);
                cmd.Parameters.AddWithValue("@i_Zone_name", i_Zone_name);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Zone_Service_Manager --> editZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Zone_Service_Manager --> editZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeZoneService(int i_Zone_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_base_zone_service", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Zone_id", i_Zone_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Zone_Service_Manager --> removeZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Zone_Service_Manager --> removeZoneService() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}