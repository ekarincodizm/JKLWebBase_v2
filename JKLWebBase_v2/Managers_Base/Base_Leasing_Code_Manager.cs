using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Leasing_Code_Manager
    {
        private string error;
        private List<Base_Leasing_Code> lblsc = new List<Base_Leasing_Code>();

        public List<Base_Leasing_Code> getLeasingCode()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_leasing_code";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Base_Leasing_Code blsc = new Base_Leasing_Code();
                    blsc.Leasing_code_id = reader.GetInt32(0);
                    blsc.Leasing_code_name = reader.GetString(1);
                    blsc.Leasing_code_S_Name = reader.GetString(2);
                    blsc.Leasing_code_F_Name = reader.GetString(3);
                    blsc.Leasing_code_Tax_id = reader.GetString(4);
                    blsc.Leasing_code_address_no = reader.GetString(5);
                    blsc.Leasing_code_vilage = reader.GetString(6);
                    blsc.Leasing_code_vilage_no = reader.GetString(7);
                    blsc.Leasing_code_alley = reader.GetString(8);
                    blsc.Leasing_code_road = reader.GetString(9);
                    blsc.Leasing_code_subdistrict = reader.GetString(10);
                    blsc.Leasing_code_district = reader.GetString(11);
                    blsc.Leasing_code_province = reader.GetString(12);
                    blsc.Leasing_code_country = reader.GetString(13);
                    blsc.Leasing_code_zipcode = reader.GetString(14);
                    blsc.Leasing_code_tel = reader.GetString(15);
                    lblsc.Add(blsc);
                }

                return lblsc;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Leasing_Code_Manager --> getLeasingCode() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Leasing_Code_Manager --> getLeasingCode() : " + ex.Message.ToString();
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