using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Dealers;
using JKLWebBase_v2.Class_Base;


namespace JKLWebBase_v2.Managers_Dealers
{
    public class Dealers_Manager
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
                    id = reader.IsDBNull(0) ? "" : reader.GetString(0);
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

        public List<Dealers> getDealers(string idcard, string fname, string lname, int i_row_str, int i_row_limit)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_car_dealers ] :: 
                 * g_car_dealers (in i_Dealer_idcard varchar(13), in i_Dealer_fname varchar(255), in i_Dealer_lname varchar(255), IN i_row_str INT(11), IN i_row_limit INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_dealers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Dealer_idcard", idcard);
                cmd.Parameters.AddWithValue("@i_Dealer_fname", fname);
                cmd.Parameters.AddWithValue("@i_Dealer_lname", lname);
                cmd.Parameters.AddWithValue("@i_row_str", i_row_str);
                cmd.Parameters.AddWithValue("@i_row_limit", i_row_limit);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Dealers> list_dlr = new List<Dealers>();

                while (reader.Read())
                {
                    Dealers cdl = new Dealers();

                    int defaultNum = 0;
                    string defaultString = "";

                    cdl.Dealer_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cdl.Dealer_fname = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cdl.Dealer_lname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cdl.Dealer_idcard = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cdl.Dealer_address_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cdl.Dealer_vilage = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cdl.Dealer_vilage_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cdl.Dealer_alley = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cdl.Dealer_road = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cdl.Dealer_subdistrict = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cdl.Dealer_district = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cdl.Dealer_province = reader.IsDBNull(11) ? defaultNum : reader.GetInt32(11);
                    cdl.Dealer_country = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cdl.Dealer_zipcode = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    cdl.Dealer_status = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cdl.Dealer_status_name = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cdl.Dealer_save_date = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    cdl.cdl_pv = new TH_Provinces();
                    cdl.cdl_pv.Province_id = reader.IsDBNull(11) ? defaultNum : reader.GetInt32(11);
                    cdl.cdl_pv.Province_name = reader.IsDBNull(17) ? defaultString : reader.GetString(17);

                    list_dlr.Add(cdl);
                }

                return list_dlr;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Dealers --> Car_Dealers_Manager --> getDealers() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Dealers --> Car_Dealers_Manager --> getDealers() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Dealers getDealerByIdCard(string Dealer_idcard)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_car_dealers_by_idcard ] :: 
                 * g_car_dealers_by_idcard (in i_Dealer_idcard varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_dealers_by_idcard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Dealer_idcard", Dealer_idcard);

                MySqlDataReader reader = cmd.ExecuteReader();

                Dealers cdl = new Dealers();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cdl.Dealer_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cdl.Dealer_fname = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cdl.Dealer_lname = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cdl.Dealer_idcard = reader.IsDBNull(3) ? defaultString : reader.GetString(3);
                    cdl.Dealer_address_no = reader.IsDBNull(4) ? defaultString : reader.GetString(4);
                    cdl.Dealer_vilage = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cdl.Dealer_vilage_no = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cdl.Dealer_alley = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cdl.Dealer_road = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cdl.Dealer_subdistrict = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cdl.Dealer_district = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cdl.Dealer_province = reader.IsDBNull(11) ? defaultNum : reader.GetInt32(11);
                    cdl.Dealer_country = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cdl.Dealer_zipcode = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    cdl.Dealer_status = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cdl.Dealer_status_name = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cdl.Dealer_save_date = reader.IsDBNull(16) ? defaultString : reader.GetString(16);

                    cdl.cdl_pv = new TH_Provinces();
                    cdl.cdl_pv.Province_id = reader.IsDBNull(11) ? defaultNum : reader.GetInt32(11);
                    cdl.cdl_pv.Province_name = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                }

                return cdl;
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

        public Dealers_Values getDealerValues(string Dealer_id, string Leasing_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_car_dealers_values ] :: 
                 * g_car_dealers_values(in i_Dealer_id varchar(50), in i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_dealers_values", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Dealer_id", Dealer_id);
                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                Dealers_Values cdlval = new Dealers_Values();

                if (reader.Read())
                {
                    int defaultNum = 0;
                    string defaultString = "";

                    cdlval.Dealer_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cdlval.Dealer_commission = reader.IsDBNull(1) ? defaultNum : reader.GetDouble(1);
                    cdlval.Dealer_percen = reader.IsDBNull(2) ? defaultNum : reader.GetDouble(2);
                    cdlval.Dealer_cash = reader.IsDBNull(3) ? defaultNum : reader.GetDouble(3);
                    cdlval.Dealer_net_com = reader.IsDBNull(4) ? defaultNum : reader.GetDouble(4);
                    cdlval.Dealer_com_code = reader.IsDBNull(5) ? defaultString : reader.GetString(5);
                    cdlval.Dealer_bookcode = reader.IsDBNull(6) ? defaultString : reader.GetString(6);
                    cdlval.Dealer_date_print = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cdlval.Dealer_save_date = reader.IsDBNull(8) ? defaultString : reader.GetString(9);
                    cdlval.Leasing_id = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                }

                return cdlval;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Dealers --> Car_Dealers_Manager --> getDealerValues() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Dealers --> Car_Dealers_Manager --> getDealerValues() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool addDealer(Dealers cdl)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_car_dealers ] :: 
                 * i_car_dealers (in i_Dealer_id varchar(50),            in i_Dealer_fname varchar(255),         in i_Dealer_lname varchar(255),     in i_Dealer_idcard varchar(13), 
				 *	              in i_Dealer_address_no varchar(255),   in i_Dealer_vilage varchar(255),        in i_Dealer_vilage_no varchar(255), in i_Dealer_alley varchar(255), 
				 *	              in i_Dealer_road varchar(255),         in i_Dealer_subdistrict varchar(255),   in i_Dealer_district varchar(255),  in i_Dealer_province int(11), 
				 *	              in i_Dealer_country varchar(255),      in i_Dealer_zipcode varchar(255),       in i_Dealer_status int(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_dealers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Dealer_id", cdl.Dealer_id);
                cmd.Parameters.AddWithValue("@i_Dealer_fname", cdl.Dealer_fname);
                cmd.Parameters.AddWithValue("@i_Dealer_lname", cdl.Dealer_lname);
                cmd.Parameters.AddWithValue("@i_Dealer_idcard", cdl.Dealer_idcard);
                cmd.Parameters.AddWithValue("@i_Dealer_address_no", cdl.Dealer_address_no);
                cmd.Parameters.AddWithValue("@i_Dealer_vilage", cdl.Dealer_vilage);
                cmd.Parameters.AddWithValue("@i_Dealer_vilage_no", cdl.Dealer_vilage_no);
                cmd.Parameters.AddWithValue("@i_Dealer_alley", cdl.Dealer_alley);
                cmd.Parameters.AddWithValue("@i_Dealer_road", cdl.Dealer_road);
                cmd.Parameters.AddWithValue("@i_Dealer_subdistrict", cdl.Dealer_subdistrict);
                cmd.Parameters.AddWithValue("@i_Dealer_district", cdl.Dealer_district);
                cmd.Parameters.AddWithValue("@i_Dealer_province", cdl.Dealer_province);
                cmd.Parameters.AddWithValue("@i_Dealer_country", cdl.Dealer_country);
                cmd.Parameters.AddWithValue("@i_Dealer_zipcode", cdl.Dealer_zipcode);
                cmd.Parameters.AddWithValue("@i_Dealer_status", cdl.Dealer_status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Dealers --> Car_Dealers_Manager --> addDealer() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Dealers --> Car_Dealers_Manager --> addDealer() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addDealerValues(Dealers_Values cdlval)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_car_deales_values ] :: 
                 * i_car_deales_values (in i_Dealer_id varchar(50),         in i_Dealer_commission double(10,2),    in i_Dealer_percen double(10,2),    in i_Dealer_cash double(10,2), 
				 *	                    in i_Dealer_net_com double(10,2),   in i_Dealer_com_code varchar(50),       in i_Dealer_bookcode varchar(50),   in i_Dealer_date_print date, 
				 *                      in i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_deales_values", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Dealer_id", cdlval.Dealer_id);
                cmd.Parameters.AddWithValue("@i_Dealer_commission", cdlval.Dealer_commission);
                cmd.Parameters.AddWithValue("@i_Dealer_percen", cdlval.Dealer_percen);
                cmd.Parameters.AddWithValue("@i_Dealer_cash", cdlval.Dealer_cash);
                cmd.Parameters.AddWithValue("@i_Dealer_net_com", cdlval.Dealer_net_com);
                cmd.Parameters.AddWithValue("@i_Dealer_com_code", cdlval.Dealer_com_code);
                cmd.Parameters.AddWithValue("@i_Dealer_bookcode", cdlval.Dealer_bookcode);
                cmd.Parameters.AddWithValue("@i_Dealer_date_print", cdlval.Dealer_date_print);
                cmd.Parameters.AddWithValue("@i_Leasing_id", cdlval.Leasing_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Dealers --> Car_Dealers_Manager --> addDealerValues() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Dealers --> Car_Dealers_Manager --> addDealerValues() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editDealer(Dealers cdl)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ u_car_dealers ] :: 
                 * u_car_dealers (in i_Dealer_id varchar(50),            in i_Dealer_fname varchar(255),         in i_Dealer_lname varchar(255),     in i_Dealer_idcard varchar(13), 
				 *	              in i_Dealer_address_no varchar(255),   in i_Dealer_vilage varchar(255),        in i_Dealer_vilage_no varchar(255), in i_Dealer_alley varchar(255), 
				 *	              in i_Dealer_road varchar(255),         in i_Dealer_subdistrict varchar(255),   in i_Dealer_district varchar(255),  in i_Dealer_province int(11), 
				 *	              in i_Dealer_country varchar(255),      in i_Dealer_zipcode varchar(255),       in i_Dealer_status int(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_car_dealers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Dealer_id", cdl.Dealer_id);
                cmd.Parameters.AddWithValue("@i_Dealer_fname", cdl.Dealer_fname);
                cmd.Parameters.AddWithValue("@i_Dealer_lname", cdl.Dealer_lname);
                cmd.Parameters.AddWithValue("@i_Dealer_idcard", cdl.Dealer_idcard);
                cmd.Parameters.AddWithValue("@i_Dealer_address_no", cdl.Dealer_address_no);
                cmd.Parameters.AddWithValue("@i_Dealer_vilage", cdl.Dealer_vilage);
                cmd.Parameters.AddWithValue("@i_Dealer_vilage_no", cdl.Dealer_vilage_no);
                cmd.Parameters.AddWithValue("@i_Dealer_alley", cdl.Dealer_alley);
                cmd.Parameters.AddWithValue("@i_Dealer_road", cdl.Dealer_road);
                cmd.Parameters.AddWithValue("@i_Dealer_subdistrict", cdl.Dealer_subdistrict);
                cmd.Parameters.AddWithValue("@i_Dealer_district", cdl.Dealer_district);
                cmd.Parameters.AddWithValue("@i_Dealer_province", cdl.Dealer_province);
                cmd.Parameters.AddWithValue("@i_Dealer_country", cdl.Dealer_country);
                cmd.Parameters.AddWithValue("@i_Dealer_zipcode", cdl.Dealer_zipcode);
                cmd.Parameters.AddWithValue("@i_Dealer_status", cdl.Dealer_status);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Dealers --> Car_Dealers_Manager --> editDealer() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Dealers --> Car_Dealers_Manager --> editDealer() : " + ex.Message.ToString();
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