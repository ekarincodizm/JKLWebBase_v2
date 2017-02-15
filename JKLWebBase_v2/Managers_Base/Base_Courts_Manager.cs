﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Courts_Manager
    {
        private string error;

        public Base_Courts getCourtsById(int Court_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_courts WHERE Court_id =" + Court_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Courts bs_ct = new Base_Courts();

                while (reader.Read())
                {
                    bs_ct.Court_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ct.Court_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                }

                return bs_ct;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Courts_Manager --> getCourtsById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Courts_Manager --> getCourtsById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Courts> getCourts()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_courts";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Courts> list_bs_ct = new List<Base_Courts>();

                while (reader.Read())
                {
                    Base_Courts bs_ct = new Base_Courts();

                    bs_ct.Court_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ct.Court_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);

                    list_bs_ct.Add(bs_ct);
                }

                return list_bs_ct;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Courts_Manager --> getCourts() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Courts_Manager --> getCourts() ";
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