using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Origins_Manager
    {
        private string error;

        public Base_Origins getOriginById(int Origin_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_origins WHERE Origin_id = " + Origin_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Origins bs_org = new Base_Origins();

                while (reader.Read())
                {
                    bs_org.Origin_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_org.Origin_name_ENG = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_org.Origin_name_TH = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                }

                return bs_org;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Origins_Manager --> getOriginById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Origins_Manager --> getOriginById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Origins> getOrigins()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_origins";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Origins> list_bs_org = new List<Base_Origins>();

                while (reader.Read())
                {
                    Base_Origins bs_org = new Base_Origins();

                    bs_org.Origin_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_org.Origin_name_ENG = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_org.Origin_name_TH = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    list_bs_org.Add(bs_org);
                }

                return list_bs_org;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Origins_Manager --> getOrigins() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Origins_Manager --> getOrigins() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addOrigin(string i_Origin_name_ENG, string i_Origin_name_TH)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_base_origins", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Origin_name_ENG", i_Origin_name_ENG);
                cmd.Parameters.AddWithValue("@i_Origin_name_TH", i_Origin_name_TH);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Origins_Manager --> addOrigin() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Origins_Manager --> addOrigin() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editOrigin(int i_Origin_id, string i_Origin_name_ENG, string i_Origin_name_TH)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_base_origins", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Origin_id", i_Origin_id);
                cmd.Parameters.AddWithValue("@i_Origin_name_ENG", i_Origin_name_ENG);
                cmd.Parameters.AddWithValue("@i_Origin_name_TH", i_Origin_name_TH);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Origins_Manager --> editOrigin() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Origins_Manager --> editOrigin() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeOrigin(int i_Origin_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_base_origins", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Origin_id", i_Origin_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Origins_Manager --> removeOrigin() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Origins_Manager --> removeOrigin() ";
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