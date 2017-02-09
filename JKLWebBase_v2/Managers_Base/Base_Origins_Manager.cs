using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Origins_Manager
    {
        private string error;
        private List<Base_Origins> lbog = new List<Base_Origins>();

        public List<Base_Origins> getOrigins()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_origins";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                int defaultNum = 0;
                string defaultString = "";
                while (reader.Read())
                {
                    Base_Origins bog = new Base_Origins();
                    bog.Origin_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bog.Origin_name_ENG = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bog.Origin_name_TH = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    lbog.Add(bog);
                }

                return lbog;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Origins_Manager --> getOrigins() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Origins_Manager --> getOrigins() ";
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