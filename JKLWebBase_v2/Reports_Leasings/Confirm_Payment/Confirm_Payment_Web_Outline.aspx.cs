using JKLWebBase_v2.Class_Account;
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

namespace JKLWebBase_v2.Reports_Leasings.Confirm_Payment
{
    public partial class Confirm_Payment_Web_Outline : Page
    {
        private Car_Leasings cls = new Car_Leasings();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCompany();
                _getLeasing();
            }
        }

        protected void Export_Btn_Click(object sender, EventArgs e)
        {
            string Company_Name = string.IsNullOrEmpty(Bottom_Address_TBx.Text) ? " " : Bottom_Address_TBx.Text.Split('(')[0];
            string Company_Type = string.IsNullOrEmpty(Bottom_Address_TBx.Text) ? " " : Bottom_Address_TBx.Text.Split('(')[1].Split(')')[0];
            string Car_Plate = string.IsNullOrEmpty(Car_Plate_TBx.Text) ? " " : Car_Plate_TBx.Text;
            string Car_Type = string.IsNullOrEmpty(Car_TBx.Text) ? " " : Car_TBx.Text;
            string Car_Brand = string.IsNullOrEmpty(Car_Brand_TBx.Text) ? " " : Car_Brand_TBx.Text;
            string Car_Engine = string.IsNullOrEmpty(Car_Engine_TBx.Text) ? " " : Car_Engine_TBx.Text;
            string Car_Chassis = string.IsNullOrEmpty(Car_Chassis_TBx.Text) ? " " : Car_Chassis_TBx.Text;
            string Payment_To = string.IsNullOrEmpty(Payment_To_TBx.Text) ? " " : Payment_To_TBx.Text;
            string Payment_Amount = string.IsNullOrEmpty(Payment_Amount_TBx.Text) ? "0" : Payment_Amount_TBx.Text;
            string Bottom_Address = string.IsNullOrEmpty(Bottom_Address_TBx.Text) ? " " : Bottom_Address_TBx.Text;

            Session["Data_CFPM_Values"] = Company_Name + "|" + Company_Type + "|" + Car_Plate + "|" + Car_Type + "|" + Car_Brand + "|" + Car_Engine + "|" + Car_Chassis + "|" + Payment_To + "|" + Payment_Amount + "|" + Bottom_Address;

            Response.Redirect("/Reports_Leasings/Confirm_Payment/Confirm_Payment");
        }

        private void _loadCompany()
        {
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(0, 0);
            Company_Name_DDl.Items.Add(new ListItem("--------  กรุณาเลือก  --------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Companys data = list_data[i];
                Company_Name_DDl.Items.Add(new ListItem(data.Company_N_name, data.Company_id.ToString()));
            }
        }

        private void _getLeasing()
        {
            cls = (Car_Leasings)Session["Leasings"];

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
                    Payment_Amount_TBx.Text = reader_cls.IsDBNull(32) ? defaultString : reader_cls.GetString(32);
                    Car_Plate_TBx.Text = reader_cls.IsDBNull(54) ? defaultString : reader_cls.GetString(54);
                    Car_Plate_TBx.Text += reader_cls.IsDBNull(56) ? defaultString : " " + reader_cls.GetString(56);
                    Car_TBx.Text = reader_cls.IsDBNull(57) ? defaultString : reader_cls.GetString(57);
                    Car_Brand_TBx.Text = reader_cls.IsDBNull(61) ? defaultString : reader_cls.GetString(61);
                    Car_Brand_TBx.Text += reader_cls.IsDBNull(60) ? defaultString : " (" + reader_cls.GetString(60) + ")";
                    Car_Brand_TBx.Text += reader_cls.IsDBNull(62) ? defaultString : " " + reader_cls.GetString(62);
                    Car_Engine_TBx.Text = reader_cls.IsDBNull(65) ? defaultString : reader_cls.GetString(65);
                    Car_Chassis_TBx.Text = reader_cls.IsDBNull(68) ? defaultString : reader_cls.GetString(68);
                }
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Confirm_Payment_Web_Outline Page --> _getLeasing() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Confirm_Payment_Web_Outline  Page --> _getLeasing() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con_cls.Close();
                con_cls.Dispose();
            }
        }

        protected void Company_Name_DDl_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clearText();

            if (Company_Name_DDl.SelectedValue != "0")
            {
                Base_Companys data = new Base_Companys_Manager().getCompanysById(Company_Name_DDl.SelectedValue);

                string address = "";

                if (data.Company_tax_subcode == "000")
                {
                    address += data.Company_address_no;
                    address += data.Company_vilage.Split('.')[1] == "-" ? "" : " " + data.Company_vilage;
                    address += data.Company_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Company_vilage_no;
                    address += data.Company_alley.Split('.')[1] == "-" ? "" : " " + data.Company_alley;
                    address += data.Company_road.Split('.')[1] == "-" ? "" : " " + data.Company_road;
                    address += data.Company_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Company_subdistrict;
                    address += data.Company_district.Split('.')[1] == "-" ? "" : " " + data.Company_district;
                    address += " จ." + data.Company_province_name;

                    Bottom_Address_TBx.Text = data.Company_F_name + " ( สำนักงานใหญ่ ) : " + address;
                }
                else
                {
                    address += data.Company_address_no;
                    address += data.Company_vilage.Split('.')[1] == "-" ? "" : " " + data.Company_vilage;
                    address += data.Company_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Company_vilage_no;
                    address += data.Company_alley.Split('.')[1] == "-" ? "" : " " + data.Company_alley;
                    address += data.Company_road.Split('.')[1] == "-" ? "" : " " + data.Company_road;
                    address += data.Company_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Company_subdistrict;
                    address += data.Company_district.Split('.')[1] == "-" ? "" : " " + data.Company_district;
                    address += " จ." + data.Company_province_name;

                    Bottom_Address_TBx.Text = data.Company_F_name + " ( " + data.Company_N_name + " ) : " + address;
                }
            }
        }

        private void _clearText()
        {
            Bottom_Address_TBx.Text = "";
        }
    }
}