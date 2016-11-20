using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Customers;
using System.Data;

namespace JKLWebBase_v2.Managers_Leasings
{
    public class Car_Leasings_Bondsman_Manager
    {
        private string error;

        public bool addBondsman(string Leasing_id , int bondsman_no , string Cust_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_car_leasings_bondsmans ] :: 
                 * i_car_leasings_bondsmans (in i_Leasing_id varchar(50), in i_bondsman_no int(1) , in i_Cust_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_leasings_bondsmans", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);
                cmd.Parameters.AddWithValue("@i_bondsman_no", bondsman_no);
                cmd.Parameters.AddWithValue("@i_Cust_id", Cust_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Bondsman_Manager --> addBondsman(string Leasing_id , int bondsman_no , string Cust_id) : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Bondsman_Manager --> addBondsman(string Leasing_id , int bondsman_no , string Cust_id) : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}