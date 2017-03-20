using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Car_Brand_Manager
    {
        private string error;

        public bool addCarBrand(string i_Car_brand_name_eng, string i_Car_brand_name_th)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE i_base_car_brands (IN i_Car_brand_name_eng VARCHAR(255), IN i_Car_brand_name_th VARCHAR(255))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_base_car_brands", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Car_brand_name_eng", i_Car_brand_name_eng);
                cmd.Parameters.AddWithValue("@i_Car_brand_name_th", i_Car_brand_name_th);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Brand_Manager --> addCarBrand() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Brand_Manager --> addCarBrand() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool editCarBrand(int i_Car_brand_id, string i_Car_brand_name_eng, string i_Car_brand_name_th)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE u_base_car_brands (IN i_Car_brand_id INT(11), IN i_Car_brand_name_eng VARCHAR(255), IN i_Car_brand_name_th VARCHAR(255))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_base_car_brands", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Car_brand_id", i_Car_brand_id);
                cmd.Parameters.AddWithValue("@i_Car_brand_name_eng", i_Car_brand_name_eng);
                cmd.Parameters.AddWithValue("@i_Car_brand_name_th", i_Car_brand_name_th);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Brand_Manager --> editCarBrand() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Brand_Manager --> editCarBrand() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public bool removeCarBrand(int i_Car_brand_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// PROCEDURE d_base_car_brand (IN i_Car_brand_id INT(11))

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_base_car_brand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Car_brand_id", i_Car_brand_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Brand_Manager --> removeCarBrand() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Brand_Manager --> removeCarBrand() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public Base_Car_Brands getCarBrandById(int Car_brand_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_brands WHERE Car_brand_id = " + Car_brand_id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                Base_Car_Brands bs_cbrn = new Base_Car_Brands();

                if (reader.Read())
                {
                    bs_cbrn.car_brand_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cbrn.car_brand_name_eng = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_cbrn.car_brand_name_th = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                }

                return bs_cbrn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Base_Car_Brand_Manager --> getCarBrandById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Brand_Manager --> getCarBrandById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Base_Car_Brands> getCarBrands()
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                con.Open();
                string sql = "SELECT * FROM base_car_brands";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int defaultNum = 0;
                string defaultString = "";

                List<Base_Car_Brands> list_bs_cbrn = new List<Base_Car_Brands>();

                while (reader.Read())
                {
                    Base_Car_Brands bs_cbrn = new Base_Car_Brands();

                    bs_cbrn.car_brand_id = reader.IsDBNull(0) ? defaultNum : reader.GetInt32(0);
                    bs_cbrn.car_brand_name_eng = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    bs_cbrn.car_brand_name_th = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    list_bs_cbrn.Add(bs_cbrn);
                }

                return list_bs_cbrn;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Base --> Car_Brand_Manager --> getCarBrands() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Car_Brand_Manager --> getCarBrands() ";
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