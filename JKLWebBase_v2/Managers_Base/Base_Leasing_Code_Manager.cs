using System;
using System.Data;
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

        public bool addLeasingCode(Base_Leasing_Code bs_ls_cd)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `i_base_leasing_code`(IN i_Leasing_code_name VARCHAR(255), IN i_Leasing_code_S_Name VARCHAR(255), IN i_Leasing_code_F_Name VARCHAR(255),
                /// IN i_Leasing_code_Tax_id VARCHAR(255), IN i_Leasing_code_Tax_subcode VARCHAR(255), IN i_Leasing_code_address_no VARCHAR(255),
				///	IN i_Leasing_code_vilage VARCHAR(255), IN i_Leasing_code_vilage_no VARCHAR(255), IN i_Leasing_code_alley VARCHAR(255),
				///	IN i_Leasing_code_road VARCHAR(255), IN i_Leasing_code_subdistrict VARCHAR(255), IN i_Leasing_code_district VARCHAR(255),
				///	IN i_Leasing_code_province_id INT(11), IN i_Leasing_code_country VARCHAR(255), IN i_Leasing_code_zipcode VARCHAR(255),
				///	IN i_Leasing_code_tel VARCHAR(255))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_base_leasing_code", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_code_name", bs_ls_cd.Leasing_code_name);
                cmd.Parameters.AddWithValue("@i_Leasing_code_S_Name", bs_ls_cd.Leasing_code_S_Name);
                cmd.Parameters.AddWithValue("@i_Leasing_code_F_Name", bs_ls_cd.Leasing_code_F_Name);
                cmd.Parameters.AddWithValue("@i_Leasing_code_Tax_id", bs_ls_cd.Leasing_code_Tax_id);
                cmd.Parameters.AddWithValue("@i_Leasing_code_Tax_subcode", bs_ls_cd.Leasing_code_Tax_subcode);
                cmd.Parameters.AddWithValue("@i_Leasing_code_address_no", bs_ls_cd.Leasing_code_address_no);
                cmd.Parameters.AddWithValue("@i_Leasing_code_vilage", bs_ls_cd.Leasing_code_vilage);
                cmd.Parameters.AddWithValue("@i_Leasing_code_vilage_no", bs_ls_cd.Leasing_code_vilage_no);
                cmd.Parameters.AddWithValue("@i_Leasing_code_alley", bs_ls_cd.Leasing_code_alley);
                cmd.Parameters.AddWithValue("@i_Leasing_code_road", bs_ls_cd.Leasing_code_road);
                cmd.Parameters.AddWithValue("@i_Leasing_code_subdistrict", bs_ls_cd.Leasing_code_subdistrict);
                cmd.Parameters.AddWithValue("@i_Leasing_code_district", bs_ls_cd.Leasing_code_district);
                cmd.Parameters.AddWithValue("@i_Leasing_code_province", bs_ls_cd.Leasing_code_province);
                cmd.Parameters.AddWithValue("@i_Leasing_code_country", bs_ls_cd.Leasing_code_country);
                cmd.Parameters.AddWithValue("@i_Leasing_code_zipcode", bs_ls_cd.Leasing_code_zipcode);
                cmd.Parameters.AddWithValue("@i_Leasing_code_tel", bs_ls_cd.Leasing_code_tel);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Leasing_Code_Manager --> addLeasingCode() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Leasing_Code_Manager --> addLeasingCode() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editLeasingCode(Base_Leasing_Code bs_ls_cd)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `u_base_leasing_code`(IN i_Leasing_code_id INT(11), IN i_Leasing_code_name VARCHAR(255), IN i_Leasing_code_S_Name VARCHAR(255), IN i_Leasing_code_F_Name VARCHAR(255),
                /// IN i_Leasing_code_Tax_id VARCHAR(255), IN i_Leasing_code_Tax_subcode VARCHAR(255), IN i_Leasing_code_address_no VARCHAR(255),
                ///	IN i_Leasing_code_vilage VARCHAR(255), IN i_Leasing_code_vilage_no VARCHAR(255), IN i_Leasing_code_alley VARCHAR(255),
                ///	IN i_Leasing_code_road VARCHAR(255), IN i_Leasing_code_subdistrict VARCHAR(255), IN i_Leasing_code_district VARCHAR(255),
                ///	IN i_Leasing_code_province_id INT(11), IN i_Leasing_code_country VARCHAR(255), IN i_Leasing_code_zipcode VARCHAR(255),

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_base_leasing_code", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_code_id", bs_ls_cd.Leasing_code_id);
                cmd.Parameters.AddWithValue("@i_Leasing_code_name", bs_ls_cd.Leasing_code_name);
                cmd.Parameters.AddWithValue("@i_Leasing_code_S_Name", bs_ls_cd.Leasing_code_S_Name);
                cmd.Parameters.AddWithValue("@i_Leasing_code_F_Name", bs_ls_cd.Leasing_code_F_Name);
                cmd.Parameters.AddWithValue("@i_Leasing_code_Tax_id", bs_ls_cd.Leasing_code_Tax_id);
                cmd.Parameters.AddWithValue("@i_Leasing_code_Tax_subcode", bs_ls_cd.Leasing_code_Tax_subcode);
                cmd.Parameters.AddWithValue("@i_Leasing_code_address_no", bs_ls_cd.Leasing_code_address_no);
                cmd.Parameters.AddWithValue("@i_Leasing_code_vilage", bs_ls_cd.Leasing_code_vilage);
                cmd.Parameters.AddWithValue("@i_Leasing_code_vilage_no", bs_ls_cd.Leasing_code_vilage_no);
                cmd.Parameters.AddWithValue("@i_Leasing_code_alley", bs_ls_cd.Leasing_code_alley);
                cmd.Parameters.AddWithValue("@i_Leasing_code_road", bs_ls_cd.Leasing_code_road);
                cmd.Parameters.AddWithValue("@i_Leasing_code_subdistrict", bs_ls_cd.Leasing_code_subdistrict);
                cmd.Parameters.AddWithValue("@i_Leasing_code_district", bs_ls_cd.Leasing_code_district);
                cmd.Parameters.AddWithValue("@i_Leasing_code_province", bs_ls_cd.Leasing_code_province);
                cmd.Parameters.AddWithValue("@i_Leasing_code_country", bs_ls_cd.Leasing_code_country);
                cmd.Parameters.AddWithValue("@i_Leasing_code_zipcode", bs_ls_cd.Leasing_code_zipcode);
                cmd.Parameters.AddWithValue("@i_Leasing_code_tel", bs_ls_cd.Leasing_code_tel);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Leasing_Code_Manager --> editLeasingCode() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Leasing_Code_Manager --> editLeasingCode() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeLeasingCode(int i_Leasing_code_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `d_base_leasing_code`(IN i_Leasing_code_id INT(11))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_base_leasing_code", con);
                cmd.CommandType = CommandType.StoredProcedure;
                    
                cmd.Parameters.AddWithValue("@i_Leasing_code_id", i_Leasing_code_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Leasing_Code_Manager --> removeLeasingCode() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Leasing_Code_Manager --> removeLeasingCode() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}