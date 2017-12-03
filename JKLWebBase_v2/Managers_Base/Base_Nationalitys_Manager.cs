using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Nationalitys_Manager
    {
        private string error;

        public Base_Nationalitys getNationalityById(int Nationality_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_nationalitys WHERE Nationality_id = " + Nationality_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Nationalitys bs_ntn = new Base_Nationalitys();

                if (reader.Read())
                {
                    bs_ntn.Nationality_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ntn.Nationality_name_ENG = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_ntn.Nationality_name_TH = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                }

                return bs_ntn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Nationalitys_Manager --> getNationalityById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Nationalitys_Manager --> getNationalityById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Nationalitys> getNationalitys()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_nationalitys";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Nationalitys> list_bs_ntn = new List<Base_Nationalitys>();

                while (reader.Read())
                {
                    Base_Nationalitys bs_ntn = new Base_Nationalitys();

                    bs_ntn.Nationality_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ntn.Nationality_name_ENG = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_ntn.Nationality_name_TH = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    list_bs_ntn.Add(bs_ntn);
                }

                return list_bs_ntn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Nationalitys_Manager --> getNationalitys() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Nationalitys_Manager --> getNationalitys() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addNationality(string i_Nationality_name_ENG, string i_Nationality_name_TH)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_base_nationalitys", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Nationality_name_ENG", i_Nationality_name_ENG);
                cmd.Parameters.AddWithValue("@i_Nationality_name_TH", i_Nationality_name_TH);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Nationalitys_Manager --> addNationality() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Nationalitys_Manager --> addNationality() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editNationality(int i_Nationality_id, string i_Nationality_name_ENG, string i_Nationality_name_TH)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_base_car_type", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Nationality_id", i_Nationality_id);
                cmd.Parameters.AddWithValue("@i_Nationality_name_ENG", i_Nationality_name_ENG);
                cmd.Parameters.AddWithValue("@i_Nationality_name_TH", i_Nationality_name_TH);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Nationalitys_Manager --> editNationality() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Nationalitys_Manager --> editNationality() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeNationality(int i_Nationality_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_base_nationalitys", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Nationality_id", i_Nationality_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Nationalitys_Manager --> removeNationality() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Nationalitys_Manager --> removeNationality() ";
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