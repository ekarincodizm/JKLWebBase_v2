using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Manager_Account
{
    public class COM_Client_Manager
    {
        private string error;

        public bool addComputerClient(Computer_Clients com_c)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_computer_client ] :: 
                 * i_computer_client (IN i_Computer_track_Latitude VARCHAR(255), IN i_Computer_track_Longitude VARCHAR(255))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_computer_client", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Computer_track_Latitude", com_c.Computer_track_Latitude);
                cmd.Parameters.AddWithValue("@i_Computer_track_Longitude", com_c.Computer_track_Longitude);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> COM_Client_Manager --> addComputerClient() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> COM_Client_Manager --> addComputerClient() ";
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