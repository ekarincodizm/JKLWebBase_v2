using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Address_Types_Manager
    {
        private string error;
        private List<Base_Address_Types> lbat = new List<Base_Address_Types>();

        public List<Base_Address_Types> getAddressTypes()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_address_types";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Base_Address_Types bats = new Base_Address_Types();
                    bats.Address_type_id = int.Parse(reader[0].ToString());
                    bats.Address_type_name = reader[1].ToString();
                    lbat.Add(bats);
                }

                return lbat;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Address_Types_Manager --> getAddressTypes() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Address_Types_Manager --> getAddressTypes() : " + ex.Message.ToString();
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