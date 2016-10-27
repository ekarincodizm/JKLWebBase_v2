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
                while (reader.Read())
                {
                    Base_Branchs bbrn = new Base_Branchs();
                    bbrn.Branch_id = reader.GetInt32(0);
                    bbrn.Branch_code = reader.GetString(1);
                    bbrn.Branch_N_name = reader.GetString(2); ;
                    bbrn.Branch_F_name = reader.GetString(3);
                    bbrn.Branch_tax_id = reader.GetString(4);
                    bbrn.Branch_address_no = reader.GetString(5);
                    bbrn.Branch_vilage = reader.GetString(6);
                    bbrn.Branch_vilage_no = reader.GetString(7);
                    bbrn.Branch_alley = reader.GetString(8);
                    bbrn.Branch_road = reader.GetString(9);
                    bbrn.Branch_subdistrict = reader.GetString(10);
                    bbrn.Branch_district = reader.GetString(11);
                    bbrn.Branch_province = reader.GetString(12);
                    bbrn.Branch_country = reader.GetString(13);
                    bbrn.Branch_zipcode = reader.GetString(14);
                    bbrn.Branch_tel = reader.GetString(15);
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