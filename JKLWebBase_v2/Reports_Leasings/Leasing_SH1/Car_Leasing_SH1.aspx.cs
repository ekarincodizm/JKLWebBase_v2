using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Reports_Leasings.DataSet_Leasings;
using System.Diagnostics;

namespace JKLWebBase_v2.Reports_Leasings.Leasing_SH1
{
    public partial class Car_Leasing_SH11 : Page
    {
        Car_Leasings cls = new Car_Leasings();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            _loadReport();
        }
        private void _loadReport()
        {
            cls = (Car_Leasings)Session["Leasings"];

            MySqlConnection con_cls = MySQLConnection.connectionMySQL();
            MySqlConnection con_ctm = MySQLConnection.connectionMySQL();
            MySqlConnection con_brn = MySQLConnection.connectionMySQL();
            MySqlConnection con_bsmn_1 = MySQLConnection.connectionMySQL();
            MySqlConnection con_bsmn_2 = MySQLConnection.connectionMySQL();
            MySqlConnection con_bsmn_3 = MySQLConnection.connectionMySQL();
            MySqlConnection con_bsmn_4 = MySQLConnection.connectionMySQL();
            MySqlConnection con_bsmn_5 = MySQLConnection.connectionMySQL();
            try
            {

                con_cls.Open();
                MySqlCommand cmd_cls = new MySqlCommand("r_leasings", con_cls);
                cmd_cls.CommandType = CommandType.StoredProcedure;
                cmd_cls.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cls = cmd_cls.ExecuteReader();

                con_ctm.Open();
                MySqlCommand cmd_ctm = new MySqlCommand("r_customers", con_ctm);
                cmd_ctm.CommandType = CommandType.StoredProcedure;
                cmd_ctm.Parameters.AddWithValue("@i_Cust_id", cls.ctm.Cust_id);
                MySqlDataReader reader_ctm = cmd_ctm.ExecuteReader();

                con_brn.Open();
                MySqlCommand cmd_crn = new MySqlCommand("g_branch_by_id", con_brn);
                cmd_crn.CommandType = CommandType.StoredProcedure;
                cmd_crn.Parameters.AddWithValue("@i_Branch_id", cls.bs_cpn.Company_id);
                MySqlDataReader reader_brn = cmd_crn.ExecuteReader();

                con_bsmn_1.Open();
                MySqlCommand cmd_bsmn_1 = new MySqlCommand("r_leasings_bondsmans", con_bsmn_1);
                cmd_bsmn_1.CommandType = CommandType.StoredProcedure;
                cmd_bsmn_1.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_bsmn_1.Parameters.AddWithValue("@i_Bondsman_no", 1);
                MySqlDataReader reader_bsmn_1 = cmd_bsmn_1.ExecuteReader();

                con_bsmn_2.Open();
                MySqlCommand cmd_bsmn_2 = new MySqlCommand("r_leasings_bondsmans", con_bsmn_2);
                cmd_bsmn_2.CommandType = CommandType.StoredProcedure;
                cmd_bsmn_2.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_bsmn_2.Parameters.AddWithValue("@i_Bondsman_no", 2);
                MySqlDataReader reader_bsmn_2 = cmd_bsmn_2.ExecuteReader();

                con_bsmn_3.Open();
                MySqlCommand cmd_bsmn_3 = new MySqlCommand("r_leasings_bondsmans", con_bsmn_3);
                cmd_bsmn_3.CommandType = CommandType.StoredProcedure;
                cmd_bsmn_3.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_bsmn_3.Parameters.AddWithValue("@i_Bondsman_no", 3);
                MySqlDataReader reader_bsmn_3 = cmd_bsmn_3.ExecuteReader();

                con_bsmn_4.Open();
                MySqlCommand cmd_bsmn_4 = new MySqlCommand("r_leasings_bondsmans", con_bsmn_4);
                cmd_bsmn_4.CommandType = CommandType.StoredProcedure;
                cmd_bsmn_4.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_bsmn_4.Parameters.AddWithValue("@i_Bondsman_no", 4);
                MySqlDataReader reader_bsmn_4 = cmd_bsmn_4.ExecuteReader();

                con_bsmn_5.Open();
                MySqlCommand cmd_bsmn_5 = new MySqlCommand("r_leasings_bondsmans", con_bsmn_5);
                cmd_bsmn_5.CommandType = CommandType.StoredProcedure;
                cmd_bsmn_5.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_bsmn_5.Parameters.AddWithValue("@i_Bondsman_no", 5);
                MySqlDataReader reader_bsmn_5 = cmd_bsmn_5.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Leasings"].Load(reader_cls);
                ls_ds.Tables["Customers"].Load(reader_ctm);
                ls_ds.Tables["Branch"].Load(reader_brn);
                ls_ds.Tables["Bondsmans_1"].Load(reader_bsmn_1);
                ls_ds.Tables["Bondsmans_2"].Load(reader_bsmn_2);
                ls_ds.Tables["Bondsmans_3"].Load(reader_bsmn_3);
                ls_ds.Tables["Bondsmans_4"].Load(reader_bsmn_4);
                ls_ds.Tables["Bondsmans_5"].Load(reader_bsmn_5);

                Car_Leasing_SH1 rpt = new Car_Leasing_SH1();
                rpt.SetDataSource(ls_ds);

                CRV_Display_Report.ReportSource = rpt;

                ExportReport(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Car_Leasing_KH11 : Page --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Car_Leasing_KH11 : Page --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con_cls.Close();
                con_ctm.Close();
                con_brn.Close();
                con_bsmn_1.Close();
                con_bsmn_2.Close();
                con_bsmn_3.Close();
                con_bsmn_4.Close();
                con_bsmn_5.Close();

                con_cls.Dispose();
                con_ctm.Dispose();
                con_brn.Dispose();
                con_bsmn_1.Dispose();
                con_bsmn_2.Dispose();
                con_bsmn_3.Dispose();
                con_bsmn_4.Dispose();
                con_bsmn_5.Dispose();
            }
        }

        public void ExportReport(Car_Leasing_SH1 rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = cls.Leasing_id;

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/สัญญา_ซ_1_" + cls.Deps_no + ".pdf");

            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "C:/ReportExport/" + mainDirectory + "/สัญญา_ซ_1_" + cls.Deps_no + ".pdf";
            process.Start();
        }
    }
}