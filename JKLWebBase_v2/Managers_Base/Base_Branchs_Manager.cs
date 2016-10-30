using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Branchs_Manager
    {
        private string error;
        private List<Base_Branchs> lbbrn = new List<Base_Branchs>();

        public List<Base_Branchs> getBranchs()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_branchs";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                int defaultNum = 0;
                string defaultString = "";

                while (reader.Read())
                {
                    Base_Branchs bbrn = new Base_Branchs();
                    bbrn.Branch_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bbrn.Branch_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bbrn.Branch_N_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bbrn.Branch_F_name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bbrn.Branch_tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bbrn.Branch_address_no = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bbrn.Branch_vilage = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bbrn.Branch_vilage_no = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bbrn.Branch_alley = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bbrn.Branch_road = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bbrn.Branch_subdistrict = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bbrn.Branch_district = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bbrn.Branch_province = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bbrn.Branch_country = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    bbrn.Branch_zipcode = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bbrn.Branch_tel = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    lbbrn.Add(bbrn);
                }

                return lbbrn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Branchs_Manager --> getBranchs() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Branchs_Manager --> getBranchs() : " + ex.Message.ToString();
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