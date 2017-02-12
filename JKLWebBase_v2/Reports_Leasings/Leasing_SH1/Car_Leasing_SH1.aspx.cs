using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Net;
using System.Diagnostics;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Reports_Leasings.DataSet_Leasings;

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
            cls.ctm = new Customers();
            cls.ctm = (Customers)Session["Customer_Leasing"];

            MySqlConnection con_cls = MySQLConnection.connectionMySQL();
            MySqlConnection con_ctm = MySQLConnection.connectionMySQL();
            MySqlConnection con_grt_1 = MySQLConnection.connectionMySQL();
            MySqlConnection con_grt_2 = MySQLConnection.connectionMySQL();
            MySqlConnection con_grt_3 = MySQLConnection.connectionMySQL();
            MySqlConnection con_grt_4 = MySQLConnection.connectionMySQL();
            MySqlConnection con_grt_5 = MySQLConnection.connectionMySQL();
            MySqlConnection con_cpn = MySQLConnection.connectionMySQL();
            try
            {

                con_cls.Open();
                MySqlCommand cmd_cls = new MySqlCommand("rpt_leasings", con_cls);
                cmd_cls.CommandType = CommandType.StoredProcedure;
                cmd_cls.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cls = cmd_cls.ExecuteReader();

                con_ctm.Open();
                MySqlCommand cmd_ctm = new MySqlCommand("rpt_leasings_customers", con_ctm);
                cmd_ctm.CommandType = CommandType.StoredProcedure;
                cmd_ctm.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_ctm.Parameters.AddWithValue("@i_Cust_id", cls.ctm.Cust_id);
                MySqlDataReader reader_ctm = cmd_ctm.ExecuteReader();

                con_grt_1.Open();
                MySqlCommand cmd_grt_1 = new MySqlCommand("rpt_leasings_guarantors", con_grt_1);
                cmd_grt_1.CommandType = CommandType.StoredProcedure;
                cmd_grt_1.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_grt_1.Parameters.AddWithValue("@i_Guarantor_no", 1);
                MySqlDataReader reader_grt_1 = cmd_grt_1.ExecuteReader();

                con_grt_2.Open();
                MySqlCommand cmd_grt_2 = new MySqlCommand("rpt_leasings_guarantors", con_grt_2);
                cmd_grt_2.CommandType = CommandType.StoredProcedure;
                cmd_grt_2.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_grt_2.Parameters.AddWithValue("@i_Guarantor_no", 2);
                MySqlDataReader reader_grt_2 = cmd_grt_2.ExecuteReader();

                con_grt_3.Open();
                MySqlCommand cmd_grt_3 = new MySqlCommand("rpt_leasings_guarantors", con_grt_3);
                cmd_grt_3.CommandType = CommandType.StoredProcedure;
                cmd_grt_3.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_grt_3.Parameters.AddWithValue("@i_Guarantor_no", 3);
                MySqlDataReader reader_grt_3 = cmd_grt_3.ExecuteReader();

                con_grt_4.Open();
                MySqlCommand cmd_grt_4 = new MySqlCommand("rpt_leasings_guarantors", con_grt_4);
                cmd_grt_4.CommandType = CommandType.StoredProcedure;
                cmd_grt_4.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_grt_4.Parameters.AddWithValue("@i_Guarantor_no", 4);
                MySqlDataReader reader_grt_4 = cmd_grt_4.ExecuteReader();

                con_grt_5.Open();
                MySqlCommand cmd_grt_5 = new MySqlCommand("rpt_leasings_guarantors", con_grt_5);
                cmd_grt_5.CommandType = CommandType.StoredProcedure;
                cmd_grt_5.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd_grt_5.Parameters.AddWithValue("@i_Guarantor_no", 5);
                MySqlDataReader reader_grt_5 = cmd_grt_5.ExecuteReader();

                con_cpn.Open();
                MySqlCommand cmd_cpn = new MySqlCommand("rpt_withholding_tax", con_cpn);
                cmd_cpn.CommandType = CommandType.StoredProcedure;
                cmd_cpn.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cpn = cmd_cpn.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Leasings"].Load(reader_cls);
                ls_ds.Tables["Customers"].Load(reader_ctm);
                ls_ds.Tables["Guarantor_1"].Load(reader_grt_1);
                ls_ds.Tables["Guarantor_2"].Load(reader_grt_2);
                ls_ds.Tables["Guarantor_3"].Load(reader_grt_3);
                ls_ds.Tables["Guarantor_4"].Load(reader_grt_4);
                ls_ds.Tables["Guarantor_5"].Load(reader_grt_5);
                ls_ds.Tables["Agent_Commission"].Load(reader_cpn);

                Car_Leasing_SH1 rpt = new Car_Leasing_SH1();
                rpt.SetDataSource(ls_ds);

                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "สัญญา_ซ_1_" + cls.Deps_no);
                /// Response.End();

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
                con_grt_1.Close();
                con_grt_2.Close();
                con_grt_3.Close();
                con_grt_4.Close();
                con_grt_5.Close();
                con_cpn.Close();

                con_cls.Dispose();
                con_ctm.Dispose();
                con_grt_1.Dispose();
                con_grt_2.Dispose();
                con_grt_3.Dispose();
                con_grt_4.Dispose();
                con_grt_5.Dispose();
                con_cpn.Dispose();
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

            string FilePath = "C:/ReportExport/" + mainDirectory + "/สัญญา_ซ_1_" + cls.Deps_no + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/สัญญา_ซ_1_" + cls.Deps_no + ".pdf");

            /// Display PDF File to PDF Program
            /// Process process = new Process();
            /// process.StartInfo.UseShellExecute = true;
            /// process.StartInfo.FileName = FilePath;
            /// process.Start();

            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
    }
}