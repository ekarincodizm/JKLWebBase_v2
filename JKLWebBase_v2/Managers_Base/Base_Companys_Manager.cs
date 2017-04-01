using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using System.Data;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Companys_Manager
    {
        private string error;

        public bool addCompany(Base_Companys bs_cpn)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE i_base_companys (IN i_Company_code VARCHAR(10), IN i_Company_N_name VARCHAR(255), IN i_Company_F_name VARCHAR(255), IN i_Company_tax_id VARCHAR(255), 
                /// IN i_Company_tax_subcode VARCHAR(255), IN i_Company_address_no VARCHAR(255), IN i_Company_vilage VARCHAR(255), IN i_Company_vilage_no VARCHAR(255), 
                /// IN i_Company_alley VARCHAR(255), IN i_Company_road VARCHAR(255), IN i_Company_subdistrict VARCHAR(255), IN i_Company_district VARCHAR(255), IN i_Company_province_id INT(11), 
                /// IN i_Company_country VARCHAR(255), IN i_Company_zipcode VARCHAR(255), IN i_Company_tel VARCHAR(255)

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_base_companys", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Company_code", bs_cpn.Company_code);
                cmd.Parameters.AddWithValue("@i_Company_N_name", bs_cpn.Company_N_name);
                cmd.Parameters.AddWithValue("@i_Company_F_name", bs_cpn.Company_F_name);
                cmd.Parameters.AddWithValue("@i_Company_tax_id", bs_cpn.Company_tax_id);
                cmd.Parameters.AddWithValue("@i_Company_tax_subcode", bs_cpn.Company_tax_subcode);
                cmd.Parameters.AddWithValue("@i_Company_address_no", bs_cpn.Company_address_no);
                cmd.Parameters.AddWithValue("@i_Company_vilage", bs_cpn.Company_vilage);
                cmd.Parameters.AddWithValue("@i_Company_vilage_no", bs_cpn.Company_vilage_no);
                cmd.Parameters.AddWithValue("@i_Company_alley", bs_cpn.Company_alley);
                cmd.Parameters.AddWithValue("@i_Company_road", bs_cpn.Company_road);
                cmd.Parameters.AddWithValue("@i_Company_subdistrict", bs_cpn.Company_subdistrict);
                cmd.Parameters.AddWithValue("@i_Company_district", bs_cpn.Company_district);
                cmd.Parameters.AddWithValue("@i_Company_province_id", bs_cpn.Company_province_id);
                cmd.Parameters.AddWithValue("@i_Company_country", bs_cpn.Company_country);
                cmd.Parameters.AddWithValue("@i_Company_zipcode", bs_cpn.Company_zipcode);
                cmd.Parameters.AddWithValue("@i_Company_tel", bs_cpn.Company_tel);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> addCompany() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> addCompany() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editCompany(Base_Companys bs_cpn)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE u_base_companys (IN i_Company_id VARCHAR(10), IN i_Company_code VARCHAR(10), IN i_Company_N_name VARCHAR(255), IN i_Company_F_name VARCHAR(255), IN i_Company_tax_id VARCHAR(255), 
                /// IN i_Company_tax_subcode VARCHAR(255), IN i_Company_address_no VARCHAR(255), IN i_Company_vilage VARCHAR(255), IN i_Company_vilage_no VARCHAR(255), 
                /// IN i_Company_alley VARCHAR(255), IN i_Company_road VARCHAR(255), IN i_Company_subdistrict VARCHAR(255), IN i_Company_district VARCHAR(255), IN i_Company_province_id INT(11), 
                /// IN i_Company_country VARCHAR(255), IN i_Company_zipcode VARCHAR(255), IN i_Company_tel VARCHAR(255)

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_base_companys", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Company_id", bs_cpn.Company_id);
                cmd.Parameters.AddWithValue("@i_Company_code", bs_cpn.Company_code);
                cmd.Parameters.AddWithValue("@i_Company_N_name", bs_cpn.Company_N_name);
                cmd.Parameters.AddWithValue("@i_Company_F_name", bs_cpn.Company_F_name);
                cmd.Parameters.AddWithValue("@i_Company_tax_id", bs_cpn.Company_tax_id);
                cmd.Parameters.AddWithValue("@i_Company_tax_subcode", bs_cpn.Company_tax_subcode);
                cmd.Parameters.AddWithValue("@i_Company_address_no", bs_cpn.Company_address_no);
                cmd.Parameters.AddWithValue("@i_Company_vilage", bs_cpn.Company_vilage);
                cmd.Parameters.AddWithValue("@i_Company_vilage_no", bs_cpn.Company_vilage_no);
                cmd.Parameters.AddWithValue("@i_Company_alley", bs_cpn.Company_alley);
                cmd.Parameters.AddWithValue("@i_Company_road", bs_cpn.Company_road);
                cmd.Parameters.AddWithValue("@i_Company_subdistrict", bs_cpn.Company_subdistrict);
                cmd.Parameters.AddWithValue("@i_Company_district", bs_cpn.Company_district);
                cmd.Parameters.AddWithValue("@i_Company_province_id", bs_cpn.Company_province_id);
                cmd.Parameters.AddWithValue("@i_Company_country", bs_cpn.Company_country);
                cmd.Parameters.AddWithValue("@i_Company_zipcode", bs_cpn.Company_zipcode);
                cmd.Parameters.AddWithValue("@i_Company_tel", bs_cpn.Company_tel);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> editCompany() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> editCompany() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeCompany(int i_Company_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE d_base_companys (IN i_Company_id INT(11))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_base_companys", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Company_id", i_Company_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> removeCompany() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> removeCompany() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Companys> getCompanys(int i_row_str, int i_row_limit)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_companys", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_row_str", i_row_str);
                cmd.Parameters.AddWithValue("@i_row_limit", i_row_limit);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Companys> list_cpn = new List<Base_Companys>();

                while (reader.Read())
                {
                    Base_Companys bs_cpn = new Base_Companys();

                    bs_cpn.Company_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cpn.Company_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_cpn.Company_N_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bs_cpn.Company_F_name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bs_cpn.Company_tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bs_cpn.Company_tax_subcode = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bs_cpn.Company_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bs_cpn.Company_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bs_cpn.Company_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bs_cpn.Company_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bs_cpn.Company_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bs_cpn.Company_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bs_cpn.Company_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bs_cpn.Company_province_id = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    bs_cpn.Company_province_name = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bs_cpn.Company_country = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    bs_cpn.Company_zipcode = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    bs_cpn.Company_tel = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    bs_cpn.Company_Save_date = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    bs_cpn.Company_package = reader.IsDBNull(19) ? defaultString : reader.GetString(19);

                    list_cpn.Add(bs_cpn);
                }

                return list_cpn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> getCompanys() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> getCompanys() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Base_Companys getCompanysById(string i_Company_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_company_by_id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Company_id", i_Company_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Companys bs_cpn = new Base_Companys();

                if (reader.Read())
                {
                    bs_cpn.Company_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cpn.Company_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_cpn.Company_N_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bs_cpn.Company_F_name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bs_cpn.Company_tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bs_cpn.Company_tax_subcode = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bs_cpn.Company_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bs_cpn.Company_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bs_cpn.Company_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bs_cpn.Company_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bs_cpn.Company_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bs_cpn.Company_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bs_cpn.Company_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bs_cpn.Company_province_id = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    bs_cpn.Company_province_name = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bs_cpn.Company_country = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    bs_cpn.Company_zipcode = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    bs_cpn.Company_tel = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    bs_cpn.Company_Save_date = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    bs_cpn.Company_package = reader.IsDBNull(19) ? defaultString : reader.GetString(19);

                }

                return bs_cpn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> getCompanysById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> getCompanysById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Base_Companys getCompanypackage(string i_Company_package)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_package_company", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Company_package", i_Company_package);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Companys bs_cpn = new Base_Companys();

                if (reader.Read())
                {
                    bs_cpn.Company_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cpn.Company_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_cpn.Company_N_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bs_cpn.Company_F_name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bs_cpn.Company_tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bs_cpn.Company_tax_subcode = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bs_cpn.Company_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bs_cpn.Company_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bs_cpn.Company_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bs_cpn.Company_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bs_cpn.Company_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bs_cpn.Company_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bs_cpn.Company_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bs_cpn.Company_province_id = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    bs_cpn.Company_province_name = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bs_cpn.Company_country = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    bs_cpn.Company_zipcode = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    bs_cpn.Company_tel = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    bs_cpn.Company_Save_date = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    bs_cpn.Company_package = reader.IsDBNull(19) ? defaultString : reader.GetString(19);

                }

                return bs_cpn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> getCompanysById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> getCompanysById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Companys> getCompanysForWebReport()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_company_for_web_report", con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Companys> list_cpn = new List<Base_Companys>();

                while (reader.Read())
                {
                    Base_Companys bs_cpn = new Base_Companys();

                    bs_cpn.Company_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cpn.Company_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_cpn.Company_N_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bs_cpn.Company_F_name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bs_cpn.Company_tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bs_cpn.Company_tax_subcode = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bs_cpn.Company_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bs_cpn.Company_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bs_cpn.Company_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bs_cpn.Company_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bs_cpn.Company_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bs_cpn.Company_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bs_cpn.Company_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bs_cpn.Company_province_id = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    bs_cpn.Company_province_name = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bs_cpn.Company_country = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    bs_cpn.Company_zipcode = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    bs_cpn.Company_tel = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    bs_cpn.Company_Save_date = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    bs_cpn.Company_package = reader.IsDBNull(19) ? defaultString : reader.GetString(19);

                    list_cpn.Add(bs_cpn);
                }

                return list_cpn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> getCompanysForWebReport() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> getCompanysForWebReport() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Companys> getCompanysAddressForWebReport(string i_Company_tax_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_company_address_for_web_report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Company_tax_id", i_Company_tax_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Companys> list_cpn = new List<Base_Companys>();

                while (reader.Read())
                {
                    Base_Companys bs_cpn = new Base_Companys();

                    bs_cpn.Company_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cpn.Company_code = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_cpn.Company_N_name = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    bs_cpn.Company_F_name = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    bs_cpn.Company_tax_id = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    bs_cpn.Company_tax_subcode = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    bs_cpn.Company_address_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    bs_cpn.Company_vilage = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    bs_cpn.Company_vilage_no = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    bs_cpn.Company_alley = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    bs_cpn.Company_road = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    bs_cpn.Company_subdistrict = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    bs_cpn.Company_district = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    bs_cpn.Company_province_id = reader.IsDBNull(13) ? defaultNum : reader.GetInt32(13);
                    bs_cpn.Company_province_name = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    bs_cpn.Company_country = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    bs_cpn.Company_zipcode = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    bs_cpn.Company_tel = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    bs_cpn.Company_Save_date = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    bs_cpn.Company_package = reader.IsDBNull(19) ? defaultString : reader.GetString(19);

                    list_cpn.Add(bs_cpn);
                }

                return list_cpn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Companys_Manager --> getCompanysAddressForWebReport() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Companys_Manager --> getCompanysAddressForWebReport() ";
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