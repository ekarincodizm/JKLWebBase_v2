using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Nationalitys_Manager
    {
        private string error;
        private List<Base_Nationalitys> lbnnt = new List<Base_Nationalitys>();

        public List<Base_Nationalitys> getNationalitys()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_nationalitys";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Base_Nationalitys bnnt = new Base_Nationalitys();
                    bnnt.Nationality_id = reader.GetInt32(0);
                    bnnt.Nationality_name_ENG = reader.GetString(1);
                    bnnt.Nationality_name_TH = reader.GetString(2);
                    lbnnt.Add(bnnt);
                }

                return lbnnt;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Nationalitys_Manager --> getNationalitys() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Nationalitys_Manager --> getNationalitys() : " + ex.Message.ToString();
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