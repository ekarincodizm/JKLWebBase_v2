using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Managers_Base
{
    public class Base_Car_Brand_Manager
    {
        private string error;

        public Base_Car_Brands geCartBrandById(int Car_brand_id)
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
                error = "MysqlException ==> Managers_Base --> Base_Car_Brand_Manager --> geCartBrandById() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Base --> Base_Car_Brand_Manager --> geCartBrandById() ";
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