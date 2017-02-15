using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Car_Types_Manager
    {
        private string error;

        public Base_Car_Types getCarTypes(int Car_type_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_types WHERE Car_type_id = " + Car_type_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Car_Types bs_c_type = new Base_Car_Types();

                while (reader.Read())
                {
                    bs_c_type.car_type_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_c_type.car_type_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                }

                return bs_c_type;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Car_Types> getCarTypes()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_types";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Car_Types> list_bs_c_type = new List<Base_Car_Types>();

                while (reader.Read())
                {
                    Base_Car_Types bs_c_type = new Base_Car_Types();

                    bs_c_type.car_type_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_c_type.car_type_name = reader.IsDBNull(1) ? defaultString : reader.GetString(1);

                    list_bs_c_type.Add(bs_c_type);
                }

                return list_bs_c_type;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Types_Manager --> getCarTypes() ";
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