using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Person_Status_Manager
    {
        private string error;

        public Base_Person_Status getPersonStatusById(int person_status_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_person_status WHERE person_status_id = "+ person_status_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Person_Status bs_ps_st = new Base_Person_Status();

                while (reader.Read())
                {
                    bs_ps_st.person_status_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ps_st.person_status_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                }

                return bs_ps_st;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Person_Status_Manager --> getPersonStatusById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Person_Status_Manager --> getPersonStatusById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Person_Status> getPersonStatus()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_person_status";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Person_Status> list_bs_ps_st = new List<Base_Person_Status>();

                while (reader.Read())
                {
                    Base_Person_Status bs_ps_st = new Base_Person_Status();

                    bs_ps_st.person_status_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_ps_st.person_status_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);

                    list_bs_ps_st.Add(bs_ps_st);
                }

                return list_bs_ps_st;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Person_Status_Manager --> getPersonStatus() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Person_Status_Manager --> getPersonStatus() ";
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