using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Zone_Service_Manager
    {
        private string error;
        private List<Base_Zone_Service> lbzs = new List<Base_Zone_Service>();

        public List<Base_Zone_Service> getZoneService()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_zones_service";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Base_Zone_Service bzs = new Base_Zone_Service();
                    bzs.Zone_id = int.Parse(reader[0].ToString());
                    bzs.Zone_code = reader[1].ToString();
                    bzs.Zone_name = reader[2].ToString();
                    lbzs.Add(bzs);
                }

                return lbzs;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Zone_Service_Manager --> getZoneService() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Zone_Service_Manager --> getZoneService() : " + ex.Message.ToString();
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