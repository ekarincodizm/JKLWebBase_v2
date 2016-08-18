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
                    blsc.Leasing_code_id = int.Parse(reader[0].ToString());
                    blsc.Leasing_code_name = reader[1].ToString();
                    blsc.Leasing_code_S_Name = reader[2].ToString();
                    blsc.Leasing_code_F_Name = reader[3].ToString();
                    blsc.Leasing_code_Tax_id = reader[4].ToString();
                    blsc.Leasing_code_address_no = reader[5].ToString();
                    blsc.Leasing_code_vilage = reader[6].ToString();
                    blsc.Leasing_code_vilage_no = reader[7].ToString();
                    blsc.Leasing_code_alley = reader[8].ToString();
                    blsc.Leasing_code_road = reader[9].ToString();
                    blsc.Leasing_code_subdistrict = reader[10].ToString();
                    blsc.Leasing_code_district = reader[11].ToString();
                    blsc.Leasing_code_province = reader[12].ToString();
                    blsc.Leasing_code_country = reader[13].ToString();
                    blsc.Leasing_code_zipcode = reader[14].ToString();
                    blsc.Leasing_code_tel = reader[15].ToString();
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