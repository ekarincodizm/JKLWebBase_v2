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
        private List<Base_Companys> list_cpn = new List<Base_Companys>();

        public List<Base_Companys> getCompanys()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_companys", con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

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