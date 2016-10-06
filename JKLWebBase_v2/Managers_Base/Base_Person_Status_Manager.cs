﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Person_Status_Manager
    {
        private string error;
        private List<Base_Person_Status> lbps = new List<Base_Person_Status>();

        public List<Base_Person_Status> getPersonStatus()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_person_status";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Base_Person_Status bps = new Base_Person_Status();
                    bps.person_status_id = int.Parse(reader[0].ToString());
                    bps.person_status_name = reader[1].ToString();
                    lbps.Add(bps);
                }

                return lbps;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Person_Status_Manager --> getPersonStatus() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Person_Status_Manager --> getPersonStatus() : " + ex.Message.ToString();
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