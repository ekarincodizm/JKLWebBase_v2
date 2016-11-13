using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;

namespace JKLWebBase_v2.Managers_Dealers
{
    public class Car_Dealers_Manager
    {
        private string error;

        public string generateDealerID()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM v_getdealerid ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                string id = "";
                if (reader.Read())
                {
                    id = reader[0].ToString();
                }

                return id;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Dealers --> Car_Dealers_Manager --> generateDealerID() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Dealers --> Car_Dealers_Manager --> generateDealerID() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Car_Dealers getDealerByIdCard(string idcard)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM car_dealers Where Dealer_idcard = '" + idcard + "' ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                Car_Dealers cdler = new Car_Dealers();
                if (reader.Read())
                {
                    cdler.Dealer_id = reader[0].ToString();
                    cdler.Dealer_fname = reader[0].ToString();
                    cdler.Dealer_lname = reader[0].ToString();
                    cdler.Dealer_idcard = reader[0].ToString();
                    cdler.Dealer_address_no = reader[0].ToString();
                    cdler.Dealer_vilage = reader[0].ToString();
                    cdler.Dealer_vilage_no = reader[0].ToString();
                    cdler.Dealer_alley = reader[0].ToString();
                    cdler.Dealer_road = reader[0].ToString();
                    cdler.Dealer_subdistrict = reader[0].ToString();
                    cdler.Dealer_district = reader[0].ToString();
                    cdler.Dealer_province = Convert.ToInt32(reader[0].ToString());
                    cdler.Dealer_country = reader[0].ToString();
                    cdler.Dealer_zipcode = reader[0].ToString();
                }

                return cdler;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Dealers --> Car_Dealers_Manager --> getDealerByIdCard() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Dealers --> Car_Dealers_Manager --> getDealerByIdCard() : " + ex.Message.ToString();
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