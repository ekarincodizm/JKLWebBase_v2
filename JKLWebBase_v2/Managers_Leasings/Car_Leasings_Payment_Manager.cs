using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Managers_Leasings
{
    public class Car_Leasings_Payment_Manager
    {
        private string error;

        public List<Car_Leasings_Payment> getPaymentSchedule(string Leasing_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_car_leasings_payment ] :: 
                 * g_car_leasings_payment (in i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_leasings_payment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Car_Leasings_Payment> list_cls_pay = new List<Car_Leasings_Payment>();

                while (reader.Read())
                {
                    Car_Leasings_Payment cls_pay = new Car_Leasings_Payment();
                    int defaultNum = 0;
                    string defaultString = "";

                    cls_pay.Leasing_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cls_pay.Period_no = reader.IsDBNull(1) ? defaultNum : reader.GetInt32(1);
                    cls_pay.Period_schedule = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cls_pay.Period_current = reader.IsDBNull(3) ? defaultNum : reader.GetDouble(3);
                    cls_pay.Period_cash = reader.IsDBNull(4) ? defaultNum : reader.GetDouble(4);
                    cls_pay.Period_value = reader.IsDBNull(5) ? defaultNum : reader.GetDouble(5);
                    cls_pay.Period_principle = reader.IsDBNull(6) ? defaultNum : reader.GetDouble(6);
                    cls_pay.Period_interst = reader.IsDBNull(7) ? defaultNum : reader.GetDouble(7);
                    cls_pay.Period_vat = reader.IsDBNull(8) ? defaultNum : reader.GetDouble(8);
                    cls_pay.Period_fine = reader.IsDBNull(9) ? defaultNum : reader.GetDouble(9);
                    cls_pay.Total_Period_fine = reader.IsDBNull(10) ? defaultNum : reader.GetDouble(10);
                    cls_pay.Total_Period_left = reader.IsDBNull(11) ? defaultNum : reader.GetDouble(11);
                    cls_pay.Period_payment_status = reader.IsDBNull(12) ? defaultNum : reader.GetInt32(12);
                    cls_pay.Period_Save_Date = reader.IsDBNull(13) ? defaultString : reader.GetString(13);

                    list_cls_pay.Add(cls_pay);
                }

                return list_cls_pay;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasing_Payment_Manager --> getPaymentSchedule() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasing_Payment_Manager --> getPaymentSchedule() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Car_Leasings_Payment> getRealPaymentInfo(string Leasing_id)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ g_car_leasings_payment_info ] :: 
                 * g_car_leasings_payment_info (in i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_leasings_payment_info", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Car_Leasings_Payment> list_cls_pay = new List<Car_Leasings_Payment>();

                while (reader.Read())
                {
                    Car_Leasings_Payment cls_pay = new Car_Leasings_Payment();
                    int defaultNum = 0;
                    string defaultString = "";

                    cls_pay.Leasing_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cls_pay.Period_no = reader.IsDBNull(1) ? defaultNum : reader.GetInt32(1);
                    cls_pay.Period_schedule = reader.IsDBNull(2) ? defaultString : reader.GetString(2);
                    cls_pay.Period_current = reader.IsDBNull(3) ? defaultNum : reader.GetDouble(3);
                    cls_pay.Period_cash = reader.IsDBNull(4) ? defaultNum : reader.GetDouble(4);
                    cls_pay.Period_value = reader.IsDBNull(5) ? defaultNum : reader.GetDouble(5);
                    cls_pay.Period_principle = reader.IsDBNull(6) ? defaultNum : reader.GetDouble(6);
                    cls_pay.Period_interst = reader.IsDBNull(7) ? defaultNum : reader.GetDouble(7);
                    cls_pay.Period_vat = reader.IsDBNull(8) ? defaultNum : reader.GetDouble(8);
                    cls_pay.Period_fine = reader.IsDBNull(9) ? defaultNum : reader.GetDouble(9);
                    cls_pay.Total_Period_fine = reader.IsDBNull(10) ? defaultNum : reader.GetDouble(10);
                    cls_pay.Total_Period_left = reader.IsDBNull(11) ? defaultNum : reader.GetDouble(11);
                    cls_pay.Period_payment_status = reader.IsDBNull(12) ? defaultNum : reader.GetInt32(12);
                    cls_pay.Period_Save_Date = reader.IsDBNull(13) ? defaultString : reader.GetString(13);

                    cls_pay.Count_payment = reader.IsDBNull(14) ? defaultNum : reader.GetInt32(14);
                    cls_pay.Period_fee = reader.IsDBNull(15) ? defaultNum : reader.GetDouble(15);
                    cls_pay.Period_track = reader.IsDBNull(16) ? defaultNum : reader.GetDouble(16);
                    cls_pay.Discount = reader.IsDBNull(17) ? defaultNum : reader.GetDouble(17);
                    cls_pay.Real_payment = reader.IsDBNull(18) ? defaultNum : reader.GetDouble(18);
                    cls_pay.Real_payment_fine = reader.IsDBNull(19) ? defaultNum : reader.GetDouble(19);
                    cls_pay.Total_payment_fine = reader.IsDBNull(20) ? defaultNum : reader.GetDouble(20);
                    cls_pay.Total_payment_left = reader.IsDBNull(21) ? defaultNum : reader.GetDouble(21);
                    cls_pay.Bill_no = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    cls_pay.Real_payment_date = reader.IsDBNull(23) ? defaultString : reader.GetString(23);

                    cls_pay.acc_lgn = new Account_Login();
                    cls_pay.acc_lgn.Employee_id = reader.IsDBNull(24) ? defaultString : reader.GetString(24);
                    cls_pay.acc_lgn.Employee_F_name = reader.IsDBNull(25) ? defaultString : reader.GetString(25);

                    cls_pay.bs_cpn = new Base_Companys();
                    cls_pay.bs_cpn.Company_id = reader.IsDBNull(26) ? defaultNum : reader.GetInt32(26);
                    cls_pay.bs_cpn.Company_N_name = reader.IsDBNull(27) ? defaultString : reader.GetString(27);
                    cls_pay.bs_cpn.Company_F_name = reader.IsDBNull(28) ? defaultString : reader.GetString(28);
                    cls_pay.bs_cpn.Company_tax_id = reader.IsDBNull(29) ? defaultString : reader.GetString(29);
                    cls_pay.bs_cpn.Company_tax_subcode = reader.IsDBNull(30) ? defaultString : reader.GetString(30);
                    cls_pay.bs_cpn.Company_province_id= reader.IsDBNull(31) ? defaultNum : reader.GetInt32(31);
                    cls_pay.bs_cpn.Company_province_name = reader.IsDBNull(32) ? defaultString : reader.GetString(32);

                    cls_pay.Payment_save_date = reader.IsDBNull(33) ? defaultString : reader.GetString(33);

                    list_cls_pay.Add(cls_pay);
                }

                return list_cls_pay;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasing_Payment_Manager --> getRealPaymentInfo() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasing_Payment_Manager --> getRealPaymentInfo() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addPayment(Car_Leasings_Payment cls_pay, int type)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ i_car_leasings_real_payment ] :: 
                 * i_car_leasings_real_payment (IN i_Leasing_id VARCHAR(50), IN i_Period_free DOUBLE(10,2), IN i_Period_track DOUBLE(10,2),
                 *                      IN i_Total_payment_fine DOUBLE(10,2), IN i_Discount DOUBLE(10,2), IN i_Real_payment DOUBLE(10,2), 
				 *                      IN i_Real_payment_date DATE, IN i_Emp_id VARCHAR(255), IN i_Company_Id INT(11), IN i_Type_Payment INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_leasings_real_payment_mod_II", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls_pay.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Period_free", cls_pay.Period_fee);
                cmd.Parameters.AddWithValue("@i_Period_track", cls_pay.Period_track);
                cmd.Parameters.AddWithValue("@i_Total_payment_fine", cls_pay.Total_payment_fine);
                cmd.Parameters.AddWithValue("@i_Discount", cls_pay.Discount);
                cmd.Parameters.AddWithValue("@i_Real_payment", cls_pay.Real_payment);
                cmd.Parameters.AddWithValue("@i_Real_payment_date", cls_pay.Real_payment_date);
                cmd.Parameters.AddWithValue("@i_Account_id", cls_pay.acc_lgn.Employee_id);
                cmd.Parameters.AddWithValue("@i_Company_Id", cls_pay.bs_cpn.Company_id);
                cmd.Parameters.AddWithValue("@i_Type_Payment", type);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasing_Payment_Manager --> addPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Payment_Manager --> addPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editPayment(Car_Leasings_Payment cls_pay, string Bill_no)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ u_car_leasings_real_payment ] :: 
                 * u_car_leasings_real_payment (IN i_Leasing_id VARCHAR(50), IN i_Bill_no VARCHAR(255), IN i_Period_free DOUBLE(10,2), IN i_Period_track DOUBLE(10,2),
                 *                      IN i_Total_payment_fine DOUBLE(10,2), IN i_Discount DOUBLE(10,2), IN i_Real_payment DOUBLE(10,2), 
				 *                      IN i_Real_payment_date DATE, IN i_Emp_id VARCHAR(255), IN i_Company_Id INT(11))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_car_leasings_real_payment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls_pay.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Bill_no", Bill_no);
                cmd.Parameters.AddWithValue("@i_Period_free", cls_pay.Period_fee);
                cmd.Parameters.AddWithValue("@i_Period_track", cls_pay.Period_track);
                cmd.Parameters.AddWithValue("@i_Total_payment_fine", cls_pay.Total_payment_fine);
                cmd.Parameters.AddWithValue("@i_Discount", cls_pay.Discount);
                cmd.Parameters.AddWithValue("@i_Real_payment", cls_pay.Real_payment);
                cmd.Parameters.AddWithValue("@i_Real_payment_date", cls_pay.Real_payment_date);
                cmd.Parameters.AddWithValue("@i_Account_id", cls_pay.acc_lgn.Employee_id);
                cmd.Parameters.AddWithValue("@i_Company_Id", cls_pay.bs_cpn.Company_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasing_Payment_Manager --> editPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Payment_Manager --> editPayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool removePayment(string Leasing_id, string Bill_no)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ d_car_leasing_real_payment ] :: 
                 * `d_car_leasing_real_payment`(IN i_Leasing_id VARCHAR(50), IN i_Bill_no VARCHAR(255))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("d_car_leasing_real_payment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", Leasing_id);
                cmd.Parameters.AddWithValue("@i_Bill_no", Bill_no);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasing_Payment_Manager --> removePayment() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Payment_Manager --> removePayment() ";
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