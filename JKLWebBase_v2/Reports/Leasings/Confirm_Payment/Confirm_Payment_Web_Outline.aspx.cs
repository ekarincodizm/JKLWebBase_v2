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

namespace JKLWebBase_v2.Reports.Leasings.Confirm_Payment
{
    public partial class Confirm_Payment_Web_Outline : Page
    {
        Car_Leasings cls = new Car_Leasings();
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

            Response.Redirect("/Reports/Leasings/Confirm_Payment/Confirm_Payment");
        }

        private void _loadCompany()
        {
            List<Base_Branchs> list_data = new Base_Branchs_Manager().getBranchs();
            Company_Name_DDl.Items.Add(new ListItem("--------  กรุณาเลือก  --------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Branchs data = list_data[i];
                Company_Name_DDl.Items.Add(new ListItem(data.Branch_N_name, data.Branch_id.ToString()));
            }
        }

        private void _getLeasing()
        {
            cls = (Car_Leasings)Session["Leasings"];

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
                    Payment_Amount_TBx.Text = reader_cls.IsDBNull(13) ? defaultString : reader_cls.GetString(13);
                    Car_Plate_TBx.Text = reader_cls.IsDBNull(31) ? defaultString : reader_cls.GetString(31);
                    Car_Plate_TBx.Text += reader_cls.IsDBNull(32) ? defaultString : " " + reader_cls.GetString(32);
                    Car_TBx.Text = reader_cls.IsDBNull(33) ? defaultString : reader_cls.GetString(33);
                    Car_Brand_TBx.Text = reader_cls.IsDBNull(35) ? defaultString : reader_cls.GetString(35);
                    Car_Engine_TBx.Text = reader_cls.IsDBNull(39) ? defaultString : reader_cls.GetString(39);
                    Car_Chassis_TBx.Text = reader_cls.IsDBNull(42) ? defaultString : reader_cls.GetString(42);
                }
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Confirm_Payment_Web_Outline Page --> _getLeasing() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Confirm_Payment_Web_Outline  Page --> _getLeasing() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
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
                Base_Branchs data = new Base_Branchs_Manager().getBranchsById(Company_Name_DDl.SelectedValue);

                string address = "";

                if (data.Branch_tax_subcode == "000")
                {
                    address += data.Branch_address_no;
                    address += data.Branch_vilage.Split('.')[1] == "-" ? "" : " " + data.Branch_vilage;
                    address += data.Branch_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Branch_vilage_no;
                    address += data.Branch_alley.Split('.')[1] == "-" ? "" : " " + data.Branch_alley;
                    address += data.Branch_road.Split('.')[1] == "-" ? "" : " " + data.Branch_road;
                    address += data.Branch_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Branch_subdistrict;
                    address += data.Branch_district.Split('.')[1] == "-" ? "" : " " + data.Branch_district;
                    address += " จ." + data.Branch_province;

                    Bottom_Address_TBx.Text = data.Branch_F_name + " ( สำนักงานใหญ่ ) : " + address;
                }
                else
                {
                    address += data.Branch_address_no;
                    address += data.Branch_vilage.Split('.')[1] == "-" ? "" : " " + data.Branch_vilage;
                    address += data.Branch_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Branch_vilage_no;
                    address += data.Branch_alley.Split('.')[1] == "-" ? "" : " " + data.Branch_alley;
                    address += data.Branch_road.Split('.')[1] == "-" ? "" : " " + data.Branch_road;
                    address += data.Branch_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Branch_subdistrict;
                    address += data.Branch_district.Split('.')[1] == "-" ? "" : " " + data.Branch_district;
                    address += " จ." + data.Branch_province;

                    Bottom_Address_TBx.Text = data.Branch_F_name + " ( " + data.Branch_N_name + " ) : " + address;
                }
            }
        }

        private void _clearText()
        {
            Bottom_Address_TBx.Text = "";
        }
    }
}