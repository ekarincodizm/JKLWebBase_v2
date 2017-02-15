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

        public Base_Leasing_Code getLeasingCodeById(int Leasing_code_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_leasing_code WHERE Leasing_code_id = " + Leasing_code_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Leasing_Code bs_ls_code = new Base_Leasing_Code();

                if (reader.Read())
                {
                    bs_ls_code.Leasing_code_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ls_code.Leasing_code_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_ls_code.Leasing_code_S_Name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bs_ls_code.Leasing_code_F_Name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bs_ls_code.Leasing_code_Tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bs_ls_code.Leasing_code_Tax_subcode = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bs_ls_code.Leasing_code_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bs_ls_code.Leasing_code_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bs_ls_code.Leasing_code_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bs_ls_code.Leasing_code_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bs_ls_code.Leasing_code_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bs_ls_code.Leasing_code_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bs_ls_code.Leasing_code_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bs_ls_code.Leasing_code_province = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    bs_ls_code.Leasing_code_country = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bs_ls_code.Leasing_code_zipcode = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    bs_ls_code.Leasing_code_tel = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                }

                return bs_ls_code;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Leasing_Code_Manager --> getLeasingCodeById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Leasing_Code_Manager --> getLeasingCodeById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public List<Base_Leasing_Code> getLeasingCode()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_leasing_code";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Leasing_Code> list_bs_ls_code = new List<Base_Leasing_Code>();

                while (reader.Read())
                {
                    Base_Leasing_Code bs_ls_code = new Base_Leasing_Code();

                    bs_ls_code.Leasing_code_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ls_code.Leasing_code_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_ls_code.Leasing_code_S_Name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bs_ls_code.Leasing_code_F_Name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bs_ls_code.Leasing_code_Tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bs_ls_code.Leasing_code_Tax_subcode = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bs_ls_code.Leasing_code_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bs_ls_code.Leasing_code_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bs_ls_code.Leasing_code_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bs_ls_code.Leasing_code_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bs_ls_code.Leasing_code_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bs_ls_code.Leasing_code_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bs_ls_code.Leasing_code_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bs_ls_code.Leasing_code_province = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    bs_ls_code.Leasing_code_country = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bs_ls_code.Leasing_code_zipcode = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    bs_ls_code.Leasing_code_tel = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    list_bs_ls_code.Add(bs_ls_code);
                }

                return list_bs_ls_code;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Leasing_Code_Manager --> getLeasingCode() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Leasing_Code_Manager --> getLeasingCode() ";
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