using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Manager_Account
{
    public class Account_Manager
    {
        private string error = string.Empty;

        public Account_Login getLogin(string i_Username_md, string i_Password_md)
        {
            /// PROCEDURE `g_account_login_by_id`(IN i_Account_id VARCHAR(255))

            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_account_login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Username_md", i_Username_md);
                cmd.Parameters.AddWithValue("@i_Password_md", i_Password_md);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Account_Login acc_lgn = new Account_Login();

                if (reader.Read())
                {
                    acc_lgn.Account_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    acc_lgn.Username_md = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    acc_lgn.Password_md = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    acc_lgn.acc_lv = new Account_Level();
                    acc_lgn.acc_lv.level_id = reader.IsDBNull(3) ? defaultNum : reader.GetInt32(3);
                    acc_lgn.acc_lv.level_name_TH = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    acc_lgn.acc_lv.level_name_ENG = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    acc_lgn.acc_lv.level_details = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    acc_lgn.acc_lv.level_access = reader.IsDBNull(7) ? defaultNum : reader.GetInt32(7);

                    acc_lgn.Account_Idcard = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    acc_lgn.Account_F_name = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    acc_lgn.Account_N_Name = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    acc_lgn.Account_Address_pri = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    acc_lgn.Account_Tel = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    acc_lgn.Account_Email = reader.IsDBNull(13) ? defaultString : reader.GetString(13);

                    acc_lgn.bs_cpn = new Base_Companys();
                    acc_lgn.bs_cpn.Company_id = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    acc_lgn.bs_cpn.Company_code = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    acc_lgn.bs_cpn.Company_N_name = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    acc_lgn.bs_cpn.Company_F_name = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    acc_lgn.bs_cpn.Company_tax_id = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    acc_lgn.bs_cpn.Company_tax_subcode = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    acc_lgn.bs_cpn.Company_address_no = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    acc_lgn.bs_cpn.Company_vilage = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    acc_lgn.bs_cpn.Company_vilage_no = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    acc_lgn.bs_cpn.Company_alley = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    acc_lgn.bs_cpn.Company_road = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    acc_lgn.bs_cpn.Company_subdistrict = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    acc_lgn.bs_cpn.Company_district = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    acc_lgn.bs_cpn.Company_province_id = reader.IsDBNull(27) ? defaultNum : reader.GetInt32(27);
                    acc_lgn.bs_cpn.Company_province_name = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    acc_lgn.bs_cpn.Company_country = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    acc_lgn.bs_cpn.Company_zipcode = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    acc_lgn.bs_cpn.Company_tel = reader.IsDBNull(31) ? defaultString : reader.GetString(31);
                    acc_lgn.bs_cpn.Company_Save_date = reader.IsDBNull(32) ? defaultString : reader.GetString(32);

                    acc_lgn.resu = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    acc_lgn.ssap = reader.IsDBNull(34) ? defaultString : reader.GetString(34);
                    acc_lgn.Account_status = reader.IsDBNull(35) ? defaultNum : reader.GetInt32(35);
                    acc_lgn.Account_Save_Date = reader.IsDBNull(36) ? defaultString : reader.GetString(36);

                }

                return acc_lgn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Account_Manager --> listAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Account_Manager --> listAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Account_Login getAccount(string i_Account_id)
        {
            /// PROCEDURE `g_account_login_by_id`(IN i_Account_id VARCHAR(255))

            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_account_login_by_id", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Account_id", i_Account_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Account_Login acc_lgn = new Account_Login();

                if (reader.Read())
                {
                    acc_lgn.Account_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    acc_lgn.Username_md = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    acc_lgn.Password_md = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    acc_lgn.acc_lv = new Account_Level();
                    acc_lgn.acc_lv.level_id = reader.IsDBNull(3) ? defaultNum : reader.GetInt32(3);
                    acc_lgn.acc_lv.level_name_TH = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    acc_lgn.acc_lv.level_name_ENG = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    acc_lgn.acc_lv.level_details = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    acc_lgn.acc_lv.level_access = reader.IsDBNull(7) ? defaultNum : reader.GetInt32(7);

                    acc_lgn.Account_Idcard = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    acc_lgn.Account_F_name = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    acc_lgn.Account_N_Name = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    acc_lgn.Account_Address_pri = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    acc_lgn.Account_Tel = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    acc_lgn.Account_Email = reader.IsDBNull(13) ? defaultString : reader.GetString(13);

                    acc_lgn.bs_cpn = new Base_Companys();
                    acc_lgn.bs_cpn.Company_id = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    acc_lgn.bs_cpn.Company_code = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    acc_lgn.bs_cpn.Company_N_name = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    acc_lgn.bs_cpn.Company_F_name = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    acc_lgn.bs_cpn.Company_tax_id = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    acc_lgn.bs_cpn.Company_tax_subcode = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    acc_lgn.bs_cpn.Company_address_no = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    acc_lgn.bs_cpn.Company_vilage = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    acc_lgn.bs_cpn.Company_vilage_no = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    acc_lgn.bs_cpn.Company_alley = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    acc_lgn.bs_cpn.Company_road = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    acc_lgn.bs_cpn.Company_subdistrict = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    acc_lgn.bs_cpn.Company_district = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    acc_lgn.bs_cpn.Company_province_id = reader.IsDBNull(27) ? defaultNum : reader.GetInt32(27);
                    acc_lgn.bs_cpn.Company_province_name = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    acc_lgn.bs_cpn.Company_country = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    acc_lgn.bs_cpn.Company_zipcode = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    acc_lgn.bs_cpn.Company_tel = reader.IsDBNull(31) ? defaultString : reader.GetString(31);
                    acc_lgn.bs_cpn.Company_Save_date = reader.IsDBNull(32) ? defaultString : reader.GetString(32);

                    acc_lgn.resu = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    acc_lgn.ssap = reader.IsDBNull(34) ? defaultString : reader.GetString(34);
                    acc_lgn.Account_status = reader.IsDBNull(35) ? defaultNum : reader.GetInt32(35);
                    acc_lgn.Account_Save_Date = reader.IsDBNull(36) ? defaultString : reader.GetString(36);

                }

                return acc_lgn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Account_Manager --> listAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Account_Manager --> listAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Account_Login> listAccount(string i_Username_md, string i_Account_F_name, string i_Account_Idcard, string i_level_id, string i_Company_id, int i_row_str, int i_row_limit)
        {
            /// PROCEDURE `g_account_login_list`(IN i_Username_md VARCHAR(255), IN i_Account_F_name VARCHAR(255), IN i_Account_Idcard VARCHAR(255),
            /// IN i_level_id VARCHAR(255), IN i_Company_id VARCHAR(255), IN i_row_str INT(11), IN i_row_limit INT(11))

            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_account_login_list", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Username_md", i_Username_md);
                cmd.Parameters.AddWithValue("@i_Account_F_name", i_Account_F_name);
                cmd.Parameters.AddWithValue("@i_Account_Idcard", i_Account_Idcard);
                cmd.Parameters.AddWithValue("@i_level_id", i_level_id);
                cmd.Parameters.AddWithValue("@i_Company_id", i_Company_id);
                cmd.Parameters.AddWithValue("@i_row_str", i_row_str);
                cmd.Parameters.AddWithValue("@i_row_limit", i_row_limit);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Account_Login> list_data = new List<Account_Login>();

                while (reader.Read())
                {
                    Account_Login acc_lgn = new Account_Login();

                    acc_lgn.Account_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    acc_lgn.Username_md = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    acc_lgn.Password_md = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    acc_lgn.acc_lv = new Account_Level();
                    acc_lgn.acc_lv.level_id = reader.IsDBNull(3) ? defaultNum : reader.GetInt32(3);
                    acc_lgn.acc_lv.level_name_TH = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    acc_lgn.acc_lv.level_name_ENG = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    acc_lgn.acc_lv.level_details = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    acc_lgn.acc_lv.level_access = reader.IsDBNull(7) ? defaultNum : reader.GetInt32(7);

                    acc_lgn.Account_Idcard = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    acc_lgn.Account_F_name = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    acc_lgn.Account_N_Name = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    acc_lgn.Account_Address_pri = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    acc_lgn.Account_Tel = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    acc_lgn.Account_Email = reader.IsDBNull(13) ? defaultString : reader.GetString(13);

                    acc_lgn.bs_cpn = new Base_Companys();
                    acc_lgn.bs_cpn.Company_id = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    acc_lgn.bs_cpn.Company_code = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    acc_lgn.bs_cpn.Company_N_name = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    acc_lgn.bs_cpn.Company_F_name = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    acc_lgn.bs_cpn.Company_tax_id = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    acc_lgn.bs_cpn.Company_tax_subcode = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    acc_lgn.bs_cpn.Company_address_no = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    acc_lgn.bs_cpn.Company_vilage = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    acc_lgn.bs_cpn.Company_vilage_no = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    acc_lgn.bs_cpn.Company_alley = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    acc_lgn.bs_cpn.Company_road = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    acc_lgn.bs_cpn.Company_subdistrict = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    acc_lgn.bs_cpn.Company_district = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    acc_lgn.bs_cpn.Company_province_id = reader.IsDBNull(27) ? defaultNum : reader.GetInt32(27);
                    acc_lgn.bs_cpn.Company_province_name = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    acc_lgn.bs_cpn.Company_country = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    acc_lgn.bs_cpn.Company_zipcode = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    acc_lgn.bs_cpn.Company_tel = reader.IsDBNull(31) ? defaultString : reader.GetString(31);
                    acc_lgn.bs_cpn.Company_Save_date = reader.IsDBNull(32) ? defaultString : reader.GetString(32);

                    acc_lgn.resu = reader.IsDBNull(33) ? defaultString : reader.GetString(33);
                    acc_lgn.ssap = reader.IsDBNull(34) ? defaultString : reader.GetString(34);
                    acc_lgn.Account_status = reader.IsDBNull(35) ? defaultNum : reader.GetInt32(35);
                    acc_lgn.Account_Save_Date = reader.IsDBNull(36) ? defaultString : reader.GetString(36);

                    list_data.Add(acc_lgn);
                }

                return list_data;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Account_Manager --> listAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Account_Manager --> listAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addAccount(Account_Login acc_lgn)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `i_account_login`(IN i_Username_md VARCHAR(255), IN i_Password_md VARCHAR(255), IN i_level_id VARCHAR(255), IN i_Account_Idcard VARCHAR(255),
                /// IN i_Account_F_name VARCHAR(255), IN i_Account_N_Name VARCHAR(255), IN i_Account_Address_pri VARCHAR(255), IN i_Account_Tel VARCHAR(255), 
				///	IN i_Account_Email VARCHAR(255), IN i_Company_id int(11))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_account_login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Username_md", acc_lgn.Username_md);
                cmd.Parameters.AddWithValue("@i_Password_md", acc_lgn.Password_md);
                cmd.Parameters.AddWithValue("@i_level_id", acc_lgn.acc_lv.level_id);
                cmd.Parameters.AddWithValue("@i_Account_Idcard", acc_lgn.Account_Idcard);
                cmd.Parameters.AddWithValue("@i_Account_F_name", acc_lgn.Account_F_name);
                cmd.Parameters.AddWithValue("@i_Account_N_Name", acc_lgn.Account_N_Name);
                cmd.Parameters.AddWithValue("@i_Account_Address_pri", acc_lgn.Account_Address_pri);
                cmd.Parameters.AddWithValue("@i_Account_Tel", acc_lgn.Account_Tel);
                cmd.Parameters.AddWithValue("@i_Account_Email", acc_lgn.Account_Email);
                cmd.Parameters.AddWithValue("@i_Company_id", acc_lgn.bs_cpn.Company_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Account_Manager --> addAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Account_Manager --> addAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editAccount(Account_Login acc_lgn)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `u_account_login`(IN i_Account_id VARCHAR(255), IN i_Username_md VARCHAR(255), IN i_Password_md VARCHAR(255), IN i_level_id VARCHAR(255), IN i_Account_Idcard VARCHAR(255),
                /// IN i_Account_F_name VARCHAR(255), IN i_Account_N_Name VARCHAR(255), IN i_Account_Address_pri VARCHAR(255), IN i_Account_Tel VARCHAR(255), 
				///	IN i_Account_Email VARCHAR(255), IN i_Company_id int(11), IN i_Account_status INT(1))
                
                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_account_login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Account_id", acc_lgn.Account_id);
                cmd.Parameters.AddWithValue("@i_Username_md", acc_lgn.Username_md);
                cmd.Parameters.AddWithValue("@i_Password_md", acc_lgn.Password_md);
                cmd.Parameters.AddWithValue("@i_level_id", acc_lgn.acc_lv.level_id);
                cmd.Parameters.AddWithValue("@i_Account_Idcard", acc_lgn.Account_Idcard);
                cmd.Parameters.AddWithValue("@i_Account_F_name", acc_lgn.Account_F_name);
                cmd.Parameters.AddWithValue("@i_Account_N_Name", acc_lgn.Account_N_Name);
                cmd.Parameters.AddWithValue("@i_Account_Address_pri", acc_lgn.Account_Address_pri);
                cmd.Parameters.AddWithValue("@i_Account_Tel", acc_lgn.Account_Tel);
                cmd.Parameters.AddWithValue("@i_Account_Email", acc_lgn.Account_Email);
                cmd.Parameters.AddWithValue("@i_Company_id", acc_lgn.bs_cpn.Company_id);
                cmd.Parameters.AddWithValue("@i_Account_status", acc_lgn.Account_status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Account_Manager --> editAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Account_Manager --> editAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeAccount(string i_Account_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE `d_account_login`(IN i_Account_id VARCHAR(255))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_account_login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Account_id", i_Account_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Account_Manager --> removeAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Account_Manager --> removeAccount() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Account_Level> listAccountLevel()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM account_login_levels";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Account_Level> list_acc_lv = new List<Account_Level>();

                while (reader.Read())
                {
                    Account_Level acc_lv = new Account_Level();

                    acc_lv.level_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    acc_lv.level_name_TH = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    acc_lv.level_name_ENG = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    acc_lv.level_details = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    acc_lv.level_access = reader.IsDBNull(4) ? defaultNum : reader.GetInt32(4);

                    list_acc_lv.Add(acc_lv);
                }

                return list_acc_lv;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Account_Manager --> listAccountLevel() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Account_Manager --> listAccountLevel() ";
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