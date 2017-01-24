using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Reports.Leasings.DataSet_Leasings;
using System.Diagnostics;


namespace JKLWebBase_v2.Reports.Leasings.Withholding_Tax
{
	public partial class Withholding_Tax_Prv : Page
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
            MySqlConnection con_brn = MySQLConnection.connectionMySQL();
            try
            {

                con_cls.Open();
                MySqlCommand cmd_cls = new MySqlCommand("r_leasings", con_cls);
                cmd_cls.CommandType = CommandType.StoredProcedure;
                cmd_cls.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cls = cmd_cls.ExecuteReader();

                con_brn.Open();
                MySqlCommand cmd_crn = new MySqlCommand("g_branch_by_id", con_brn);
                cmd_crn.CommandType = CommandType.StoredProcedure;
                cmd_crn.Parameters.AddWithValue("@i_Branch_id", cls.Branch_id);
                MySqlDataReader reader_brn = cmd_crn.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Leasings"].Load(reader_cls);
                ls_ds.Tables["Branch"].Load(reader_brn);


                Withholding_Tax rpt = new Withholding_Tax();
                rpt.SetDataSource(ls_ds);

                CRV_Display_Report.ReportSource = rpt;

                ExportReport(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Car_Leasing_KH11 : Page --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Car_Leasing_KH11 : Page --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            finally
            {
                con_cls.Close();
                con_brn.Close();

                con_cls.Dispose();
                con_brn.Dispose();
            }
        }

        public void ExportReport(Withholding_Tax rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = cls.Leasing_id;

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/หนังสือรับรองหัก_ณ_ที่จ่าย_" + cls.Deps_no + ".pdf");

            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "C:/ReportExport/" + mainDirectory + "/หนังสือรับรองหัก_ณ_ที่จ่าย_" + cls.Deps_no + ".pdf";
            process.Start();
        }
    }
}