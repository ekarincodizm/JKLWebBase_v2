﻿using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Agents;

namespace JKLWebBase_v2.Managers_Agents
{
    public class Agents_Manager
    {
        private string error;

        public string generateAgentID()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM v_getagentid ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                string id = "";
                if (reader.Read())
                {
                    id = reader.IsDBNull(0) ? "" : reader.GetString(0);
                }

                return id;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> generateAgentID() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> generateAgentID() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Agents> getAgents(string idcard, string fname, string lname, int i_row_str, int i_row_limit)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_agents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Agent_idcard", idcard);
                cmd.Parameters.AddWithValue("@i_Agent_fname", fname);
                cmd.Parameters.AddWithValue("@i_Agent_lname", lname);
                cmd.Parameters.AddWithValue("@i_row_str", i_row_str);
                cmd.Parameters.AddWithValue("@i_row_limit", i_row_limit);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Agents> list_cag = new List<Agents>();

                while (reader.Read())
                {
                    Agents cag = new Agents();

                    int defaultNum = 0;
                    string defaultString = "";

                    cag.Agent_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cag.Agent_Fname = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cag.Agent_Lname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cag.Agent_Idcard = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cag.Agent_Address_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cag.Agent_Vilage = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cag.Agent_Vilage_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cag.Agent_Alley = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cag.Agent_Road = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cag.Agent_Subdistrict = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cag.Agent_District = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cag.Agent_Province = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cag.Agent_Country = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cag.Agent_Zipcode = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    cag.Agent_Status = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cag.Agent_Status_name = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cag.Agent_save_date = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    list_cag.Add(cag);
                }

                return list_cag;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> getAgents() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> getAgents() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Agents getAgentByIdCard(string i_Agent_Idcard)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_agents_by_idcard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Agent_Idcard", i_Agent_Idcard);

                MySqlDataReader reader = cmd.ExecuteReader();

                Agents cag = new Agents();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cag.Agent_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cag.Agent_Fname = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cag.Agent_Lname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cag.Agent_Idcard = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cag.Agent_Address_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cag.Agent_Vilage = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cag.Agent_Vilage_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cag.Agent_Alley = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cag.Agent_Road = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cag.Agent_Subdistrict = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cag.Agent_District = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cag.Agent_Province = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cag.Agent_Country = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cag.Agent_Zipcode = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    cag.Agent_Status = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cag.Agent_Status_name = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cag.Agent_save_date = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                }

                return cag;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> getAgentByIdCard() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> getAgentByIdCard() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Agents getAgentByName(string i_Agent_Idcard, string i_Agent_fname, string i_Agent_lname)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_agents_by_name", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Agent_Idcard", i_Agent_Idcard);
                cmd.Parameters.AddWithValue("@i_Agent_fname", i_Agent_fname);
                cmd.Parameters.AddWithValue("@i_Agent_lname", i_Agent_lname);

                MySqlDataReader reader = cmd.ExecuteReader();

                Agents cag = new Agents();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cag.Agent_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cag.Agent_Fname = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cag.Agent_Lname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cag.Agent_Idcard = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cag.Agent_Address_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cag.Agent_Vilage = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cag.Agent_Vilage_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cag.Agent_Alley = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cag.Agent_Road = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cag.Agent_Subdistrict = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cag.Agent_District = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cag.Agent_Province = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cag.Agent_Country = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cag.Agent_Zipcode = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    cag.Agent_Status = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cag.Agent_Status_name = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cag.Agent_save_date = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                }

                return cag;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> getAgentByName() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> getAgentByName() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Agents_Commission getAgentCommission(string Agent_id, string Leasing_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_agents_commission", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Agent_id", Agent_id);
                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                Agents_Commission cag_com = new Agents_Commission();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cag_com.cag = new Agents();
                    cag_com.cag.Agent_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cag_com.cag.Agent_Fname = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cag_com.cag.Agent_Lname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cag_com.cag.Agent_Idcard = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cag_com.cag.Agent_Address_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cag_com.cag.Agent_Vilage = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cag_com.cag.Agent_Vilage_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cag_com.cag.Agent_Alley = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cag_com.cag.Agent_Road = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cag_com.cag.Agent_Subdistrict = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cag_com.cag.Agent_District = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cag_com.cag.Agent_Province = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cag_com.cag.Agent_Country = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cag_com.cag.Agent_Zipcode = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    cag_com.cag.Agent_Status = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cag_com.cag.Agent_Status_name = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cag_com.cag.Agent_save_date = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    cag_com.Leasing_id = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    cag_com.Agent_commission = reader.IsDBNull(18) ? defaultNum : reader.GetDouble(18);
                    cag_com.Agent_percen = reader.IsDBNull(19) ? defaultNum : reader.GetDouble(19);
                    cag_com.Agent_cash = reader.IsDBNull(20) ? defaultNum : reader.GetDouble(20);
                    cag_com.Agent_net_com = reader.IsDBNull(21) ? defaultNum : reader.GetDouble(21);
                    cag_com.Agent_num_code = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    cag_com.Agent_book_code = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    cag_com.Agent_date_print = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    cag_com.Agent_value_save_date = reader.IsDBNull(25) ? defaultString : reader.GetString(25);

                }

                return cag_com;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> getAgentCommission() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> getAgentCommission() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addAgent(Agents cag)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_agents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Agent_id", cag.Agent_id);
                cmd.Parameters.AddWithValue("@i_Agent_Fname", cag.Agent_Fname);
                cmd.Parameters.AddWithValue("@i_Agent_Lname", cag.Agent_Lname);
                cmd.Parameters.AddWithValue("@i_Agent_Idcard", cag.Agent_Idcard);
                cmd.Parameters.AddWithValue("@i_Agent_Address_no", cag.Agent_Address_no);
                cmd.Parameters.AddWithValue("@i_Agent_Vilage", cag.Agent_Vilage);
                cmd.Parameters.AddWithValue("@i_Agent_Vilage_no", cag.Agent_Vilage_no);
                cmd.Parameters.AddWithValue("@i_Agent_Alley", cag.Agent_Alley);
                cmd.Parameters.AddWithValue("@i_Agent_Road", cag.Agent_Road);
                cmd.Parameters.AddWithValue("@i_Agent_Subdistrict", cag.Agent_Subdistrict);
                cmd.Parameters.AddWithValue("@i_Agent_District", cag.Agent_District);
                cmd.Parameters.AddWithValue("@i_Agent_Province", cag.Agent_Province);
                cmd.Parameters.AddWithValue("@i_Agent_Country", cag.Agent_Country);
                cmd.Parameters.AddWithValue("@i_Agent_Zipcode", cag.Agent_Zipcode);
                cmd.Parameters.AddWithValue("@i_Agent_Status", cag.Agent_Status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> addAgent() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> addAgent() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addAgentCommission(Agents_Commission cag_com)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_agents_commission", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cag_com.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Agent_id", cag_com.cag.Agent_id);
                cmd.Parameters.AddWithValue("@i_Agent_commission", cag_com.Agent_commission);
                cmd.Parameters.AddWithValue("@i_Agent_percen", cag_com.Agent_percen);
                cmd.Parameters.AddWithValue("@i_Agent_cash", cag_com.Agent_cash);
                cmd.Parameters.AddWithValue("@i_Agent_net_com", cag_com.Agent_net_com);
                cmd.Parameters.AddWithValue("@i_Agent_num_code", cag_com.Agent_num_code);
                cmd.Parameters.AddWithValue("@i_Agent_book_code", cag_com.Agent_book_code);
                cmd.Parameters.AddWithValue("@i_Agent_date_print", cag_com.Agent_date_print);
                cmd.Parameters.AddWithValue("@i_Agent_value_save_date", cag_com.Agent_value_save_date);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> addAgentCommission() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> addAgentCommission() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editAgent(Agents cag)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_car_agents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Agent_id", cag.Agent_id);
                cmd.Parameters.AddWithValue("@i_Agent_Fname", cag.Agent_Fname);
                cmd.Parameters.AddWithValue("@i_Agent_Lname", cag.Agent_Lname);
                cmd.Parameters.AddWithValue("@i_Agent_Idcard", cag.Agent_Idcard);
                cmd.Parameters.AddWithValue("@i_Agent_Address_no", cag.Agent_Address_no);
                cmd.Parameters.AddWithValue("@i_Agent_Vilage", cag.Agent_Vilage);
                cmd.Parameters.AddWithValue("@i_Agent_Vilage_no", cag.Agent_Vilage_no);
                cmd.Parameters.AddWithValue("@i_Agent_Alley", cag.Agent_Alley);
                cmd.Parameters.AddWithValue("@i_Agent_Road", cag.Agent_Road);
                cmd.Parameters.AddWithValue("@i_Agent_Subdistrict", cag.Agent_Subdistrict);
                cmd.Parameters.AddWithValue("@i_Agent_District", cag.Agent_District);
                cmd.Parameters.AddWithValue("@i_Agent_Province", cag.Agent_Province);
                cmd.Parameters.AddWithValue("@i_Agent_Country", cag.Agent_Country);
                cmd.Parameters.AddWithValue("@i_Agent_Zipcode", cag.Agent_Zipcode);
                cmd.Parameters.AddWithValue("@i_Agent_Status", cag.Agent_Status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> editAgent() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> editAgent() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editAgentCommission(Agents_Commission cag_com)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_car_agents_commission", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cag_com.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Agent_id", cag_com.cag.Agent_id);
                cmd.Parameters.AddWithValue("@i_Agent_commission", cag_com.Agent_commission);
                cmd.Parameters.AddWithValue("@i_Agent_percen", cag_com.Agent_percen);
                cmd.Parameters.AddWithValue("@i_Agent_cash", cag_com.Agent_cash);
                cmd.Parameters.AddWithValue("@i_Agent_net_com", cag_com.Agent_net_com);
                cmd.Parameters.AddWithValue("@i_Agent_num_code", cag_com.Agent_num_code);
                cmd.Parameters.AddWithValue("@i_Agent_book_code", cag_com.Agent_book_code);
                cmd.Parameters.AddWithValue("@i_Agent_date_print", cag_com.Agent_date_print);
                cmd.Parameters.AddWithValue("@i_Agent_value_save_date", cag_com.Agent_value_save_date);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> editAgentCommission() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> editAgentCommission() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool removeAgent(string Leasing_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_car_agents_commission", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Agents --> Car_Agents_Manager --> removeAgent() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Agents --> Car_Agents_Manager --> removeAgent() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}