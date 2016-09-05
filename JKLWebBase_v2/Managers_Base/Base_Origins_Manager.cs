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
                while (reader.Read())
                {
                    Base_Origins bog = new Base_Origins();
                    bog.Origin_id = int.Parse(reader[0].ToString());
                    bog.Origin_name_ENG = reader[1].ToString();
                    bog.Origin_name_TH = reader[2].ToString();
                    lbog.Add(bog);
                }

                return lbog;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Origins_Manager --> getOrigins() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Origins_Manager --> getOrigins() : " + ex.Message.ToString();
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