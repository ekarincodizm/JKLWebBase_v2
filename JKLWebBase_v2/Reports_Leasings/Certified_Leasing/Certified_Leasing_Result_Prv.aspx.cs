using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Global_Class;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

namespace JKLWebBase_v2.Reports_Leasings.Certified_Leasing
{
    public partial class Certified_Leasing_Result_Prv : Page
    {
        private Car_Leasings cls = new Car_Leasings();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["Leasings"] != null)
                {
                    cls = (Car_Leasings)Session["Leasings"];

                    cls.ctm = new Customers();
                    cls.ctm = (Customers)Session["Customer_Leasing"];

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

            Response.Redirect("/Reports_Leasings/Certified_Leasing/Certified_Leasing?mod=1");
        }

        private void _loadLeasing(Car_Leasings cls)
        {
            MySqlConnection con_cls = MySQLConnection.connectionMySQL();
            try
            {
                con_cls.Open();
                MySqlCommand cmd_cls = new MySqlCommand("rpt_leasings", con_cls);
                cmd_cls.CommandType = CommandType.StoredProcedure;
                cmd_cls.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);

                MySqlDataReader reader_cls = cmd_cls.ExecuteReader();

                string defaultString = "";

                if (reader_cls.Read())
                {
                    Print_Date_TBx.Text = reader_cls.IsDBNull(5) ? defaultString : reader_cls.GetString(5);
                    Registrar_TBx.Text = reader_cls.IsDBNull(56) ? defaultString : "จังหวัด" + reader_cls.GetString(56);

                    Car_TBx.Text = reader_cls.IsDBNull(57) ? defaultString : reader_cls.GetString(57);
                    Car_TBx.Text += reader_cls.IsDBNull(61) ? defaultString : " " + reader_cls.GetString(61);
                    Car_TBx.Text += reader_cls.IsDBNull(60) ? defaultString : " (" + reader_cls.GetString(60) + ")";
                    Car_TBx.Text += reader_cls.IsDBNull(64) ? defaultString : " สี " + reader_cls.GetString(64);

                    Model_TBx.Text = reader_cls.IsDBNull(62) ? defaultString : " " + reader_cls.GetString(62);

                    Car_Engine_TBx.Text = reader_cls.IsDBNull(65) ? defaultString : reader_cls.GetString(65);
                    Car_Chassis_TBx.Text = reader_cls.IsDBNull(68) ? defaultString : reader_cls.GetString(68);

                    Car_II_TBx.Text = Car_TBx.Text;

                    Leasing_Date_TBx.Text = Print_Date_TBx.Text;

                    double Finance = reader_cls.IsDBNull(32) ? 0 : reader_cls.GetDouble(32);
                    int Total_Period = reader_cls.IsDBNull(35) ? 0 : reader_cls.GetInt32(35);
                    double Interest = reader_cls.IsDBNull(37) ? 0 : reader_cls.GetDouble(37);
                    double Total_Period_Payment = reader_cls.IsDBNull(45) ? 0 : reader_cls.GetDouble(45);
                    double Period_Pay = reader_cls.IsDBNull(41) ? 0 : reader_cls.GetDouble(41);
                    

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
                error = "MysqlException ==> Certified_Leasing_Result_Prv : Page --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Certified_Leasing_Result_Prv : Page --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con_cls.Close();

                con_cls.Dispose();
            }

            GC.Collect();
        }

        private void _loadCustomer(Car_Leasings cls)
        {
            MySqlConnection con_ctm = MySQLConnection.connectionMySQL();
            try
            {
                con_ctm.Open();
                MySqlCommand cmd_ctm = new MySqlCommand("rpt_leasings_customers", con_ctm);
                cmd_ctm.CommandType = CommandType.StoredProcedure;
                cmd_ctm.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_ctm.Parameters.AddWithValue("@i_Cust_id", cls.ctm.Cust_id);

                MySqlDataReader reader_ctm = cmd_ctm.ExecuteReader();

                string defaultString = "";

                if (reader_ctm.Read())
                {
                    Ctm_Name_TBx.Text = reader_ctm.IsDBNull(3) ? defaultString : reader_ctm.GetString(3);
                    Ctm_Name_TBx.Text += reader_ctm.IsDBNull(4) ? defaultString : " " + reader_ctm.GetString(4);
                    Ctm_Address_No_TBx.Text = reader_ctm.IsDBNull(77) ? defaultString : reader_ctm.GetString(77);
                    Ctm_Moo_TBx.Text = reader_ctm.IsDBNull(79) ? defaultString : reader_ctm.GetString(79).Split('.')[1];
                    Ctm_Alley_TBx.Text = reader_ctm.IsDBNull(80) ? defaultString : reader_ctm.GetString(80).Split('.')[1];
                    Ctm_Road_TBx.Text = reader_ctm.IsDBNull(81) ? defaultString : reader_ctm.GetString(81).Split('.')[1];
                    Ctm_Subdistrict_TBx.Text = reader_ctm.IsDBNull(82) ? defaultString : reader_ctm.GetString(82).Split('.')[1];
                    Ctm_District_TBx.Text = reader_ctm.IsDBNull(83) ? defaultString : reader_ctm.GetString(83).Split('.')[1];
                    Ctm_Province_TBx.Text = reader_ctm.IsDBNull(85) ? defaultString : reader_ctm.GetString(85);

                    Ctm_Name_II_TBx.Text = Ctm_Name_TBx.Text;
                }

            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Certified_Leasing_Result_Prv : Page--> _loadCustomer() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Certified_Leasing_Result_Prv : Page--> _loadCustomer() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con_ctm.Close();
                con_ctm.Dispose();
            }

            GC.Collect();
        }

    }
}