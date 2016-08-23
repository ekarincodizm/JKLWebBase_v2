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
                    bbrn.Branch_id = int.Parse(reader[0].ToString());
                    bbrn.Branch_code = reader[1].ToString();
                    bbrn.Branch_N_name = reader[2].ToString();
                    bbrn.Branch_F_name = reader[3].ToString();
                    bbrn.Branch_tax_id = reader[4].ToString();
                    bbrn.Branch_address_no = reader[5].ToString();
                    bbrn.Branch_vilage = reader[6].ToString();
                    bbrn.Branch_vilage_no = reader[7].ToString();
                    bbrn.Branch_alley = reader[8].ToString();
                    bbrn.Branch_road = reader[9].ToString();
                    bbrn.Branch_subdistrict = reader[10].ToString();
                    bbrn.Branch_district = reader[11].ToString();
                    bbrn.Branch_province = reader[12].ToString();
                    bbrn.Branch_country = reader[13].ToString();
                    bbrn.Branch_zipcode = reader[14].ToString();
                    bbrn.Branch_tel = reader[15].ToString();
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