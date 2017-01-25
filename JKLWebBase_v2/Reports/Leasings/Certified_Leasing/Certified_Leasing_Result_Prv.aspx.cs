using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Managers_Base;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace JKLWebBase_v2.Reports.Leasings.Certified_Leasing
{
    public partial class Certified_Leasing_Result_Prv : Page
    {
        Car_Leasings cls = new Car_Leasings();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["Leasings"] != null)
                {
                    cls = (Car_Leasings)Session["Leasings"];
                    _loadLeasing(cls);
                    _loadCustomer(cls);
                }
            }
        }

        protected void Export_Btn_Click(object sender, EventArgs e)
        {
            string Data_CTFLS_Values = "";

            Data_CTFLS_Values += string.IsNullOrEmpty(Print_Date_TBx.Text) ? " " : Print_Date_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Registrar_TBx.Text) ? "|" : "|" + Registrar_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Car_TBx.Text) ? "|" : "|" + Car_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Model_TBx.Text) ? "|" : "|" + Model_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Car_Engine_TBx.Text) ? "|" : "|" + Car_Engine_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Car_Chassis_TBx.Text) ? "|" : "|" + Car_Chassis_TBx.Text;

            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_Name_TBx.Text) ? "|" : "|" + Ctm_Name_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_Address_No_TBx.Text) ? "|" : "|" + Ctm_Address_No_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_Moo_TBx.Text) ? "|" : "|" + Ctm_Moo_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_Alley_TBx.Text) ? "|" : "|" + Ctm_Alley_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_Road_TBx.Text) ? "|" : "|" + Ctm_Road_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_Subdistrict_TBx.Text) ? "|" : "|" + Ctm_Subdistrict_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_District_TBx.Text) ? "|" : "|" + Ctm_District_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Ctm_Province_TBx.Text) ? "|" : "|" + Ctm_Province_TBx.Text;

            Data_CTFLS_Values += string.IsNullOrEmpty(Finance_TBx.Text) ? "|" : "|" + Finance_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Interest_TBx.Text) ? "|" : "|" + Interest_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Total_Finance_TBx.Text) ? "|" : "|" + Total_Finance_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Total_Period_TBx.Text) ? "|" : "|" + Total_Period_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Payment_Period_TBx.Text) ? "|" : "|" + Payment_Period_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Period_Vat_TBx.Text) ? "|" : "|" + Period_Vat_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(Total_Period_Payment_TBx.Text) ? "|" : "|" + Total_Period_Payment_TBx.Text;

            Data_CTFLS_Values += string.IsNullOrEmpty(For_TBx.Text) ? "|" : "|" + For_TBx.Text;
            Data_CTFLS_Values += string.IsNullOrEmpty(For_II_TBx.Text) ? "|" : "|" + For_II_TBx.Text;

            Session["Data_CTFLS_Values"] = Data_CTFLS_Values;

            Response.Redirect("/Reports/Leasings/Certified_Leasing/Certified_Leasing?mod=1");
        }

        private void _loadLeasing(Car_Leasings cls)
        {
            MySqlConnection con_cls = MySQLConnection.connectionMySQL();
            try
            {
                con_cls.Open();
                MySqlCommand cmd_cls = new MySqlCommand("r_leasings", con_cls);
                cmd_cls.CommandType = CommandType.StoredProcedure;
                cmd_cls.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cls = cmd_cls.ExecuteReader();

                string defaultString = "";

                if (reader_cls.Read())
                {
                    Print_Date_TBx.Text = reader_cls.IsDBNull(7) ? defaultString : reader_cls.GetString(7);
                    Registrar_TBx.Text = reader_cls.IsDBNull(32) ? defaultString : "จังหวัด" + reader_cls.GetString(32);

                    Car_TBx.Text += reader_cls.IsDBNull(33) ? defaultString : reader_cls.GetString(33);
                    Car_TBx.Text += reader_cls.IsDBNull(31) ? defaultString : " " + reader_cls.GetString(31);
                    Car_TBx.Text += reader_cls.IsDBNull(32) ? defaultString : " " + reader_cls.GetString(32);
                    Car_TBx.Text += reader_cls.IsDBNull(38) ? defaultString : " สี " + reader_cls.GetString(38);

                    Model_TBx.Text = reader_cls.IsDBNull(35) ? defaultString : reader_cls.GetString(35);
                    Model_TBx.Text += reader_cls.IsDBNull(36) ? defaultString : " " + reader_cls.GetString(36);

                    Car_Engine_TBx.Text = reader_cls.IsDBNull(39) ? defaultString : reader_cls.GetString(39);
                    Car_Chassis_TBx.Text = reader_cls.IsDBNull(42) ? defaultString : reader_cls.GetString(42);

                    Car_II_TBx.Text = Car_TBx.Text;

                    Leasing_Date_TBx.Text = Print_Date_TBx.Text;

                    double Finance = reader_cls.IsDBNull(13) ? 0 : reader_cls.GetDouble(13);
                    int Total_Period = reader_cls.IsDBNull(16) ? 0 : reader_cls.GetInt32(16);
                    double Interest = reader_cls.IsDBNull(18) ? 0 : reader_cls.GetDouble(18);
                    double Total_Period_Payment = reader_cls.IsDBNull(26) ? 0 : reader_cls.GetDouble(26);
                    double Period_Pay = reader_cls.IsDBNull(22) ? 0 : reader_cls.GetDouble(22);
                    

                    double Period_Vat = Total_Period_Payment - Period_Pay;
                    double Total_Finance = Finance + Interest;

                    Finance_TBx.Text = Finance.ToString("#,###.00");
                    Interest_TBx.Text = Interest.ToString("#,###.00");
                    Total_Finance_TBx.Text = Total_Finance.ToString("#,###.00");
                    Total_Period_TBx.Text = Total_Period.ToString();
                    Payment_Period_TBx.Text = Period_Pay.ToString("#,###.00");
                    Period_Pay_TBx.Text = Period_Pay.ToString("#,###.00");
                    Period_Vat_TBx.Text = Period_Vat.ToString("#,###.00");
                    Total_Period_Payment_TBx.Text = Total_Period_Payment.ToString("#,###.00");

                    Car_III_TBx.Text = Car_TBx.Text;
                    Car_IV_TBx.Text = Car_TBx.Text;

                }

            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Certified_Leasing_Result_Prv : Page --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Certified_Leasing_Result_Prv : Page --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            finally
            {
                con_cls.Close();

                con_cls.Dispose();
            }
        }

        private void _loadCustomer(Car_Leasings cls)
        {
            MySqlConnection con_ctm = MySQLConnection.connectionMySQL();
            try
            {
                con_ctm.Open();
                MySqlCommand cmd_ctm = new MySqlCommand("r_customers", con_ctm);
                cmd_ctm.CommandType = CommandType.StoredProcedure;
                cmd_ctm.Parameters.AddWithValue("@i_Cust_id", cls.Cust_id);
                MySqlDataReader reader_ctm = cmd_ctm.ExecuteReader();

                string defaultString = "";

                if (reader_ctm.Read())
                {
                    Ctm_Name_TBx.Text = reader_ctm.IsDBNull(4) ? defaultString : reader_ctm.GetString(4);
                    Ctm_Address_No_TBx.Text = reader_ctm.IsDBNull(27) ? defaultString : reader_ctm.GetString(27);
                    Ctm_Moo_TBx.Text = reader_ctm.IsDBNull(29) ? defaultString : reader_ctm.GetString(29).Split('.')[1];
                    Ctm_Alley_TBx.Text = reader_ctm.IsDBNull(30) ? defaultString : reader_ctm.GetString(30).Split('.')[1];
                    Ctm_Road_TBx.Text = reader_ctm.IsDBNull(31) ? defaultString : reader_ctm.GetString(31).Split('.')[1];
                    Ctm_Subdistrict_TBx.Text = reader_ctm.IsDBNull(32) ? defaultString : reader_ctm.GetString(32).Split('.')[1];
                    Ctm_District_TBx.Text = reader_ctm.IsDBNull(33) ? defaultString : reader_ctm.GetString(33).Split('.')[1];
                    Ctm_Province_TBx.Text = reader_ctm.IsDBNull(34) ? defaultString : reader_ctm.GetString(34);

                    Ctm_Name_II_TBx.Text = Ctm_Name_TBx.Text;
                }

            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Certified_Leasing_Result_Prv : Page--> _loadCustomer() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Certified_Leasing_Result_Prv : Page--> _loadCustomer() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            finally
            {
                con_ctm.Close();
                con_ctm.Dispose();
            }
        }

    }
}