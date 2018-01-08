using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Reports_Leasings.DataSet_Leasings;
using System.Net;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Reports_Leasings.Withholding_Tax
{
    public partial class Withholding_Tax_Prv : Page
	{
        private Car_Leasings cls = new Car_Leasings();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            _loadReport();
        }

        private void _loadReport()
        {
            cls = (Car_Leasings)Session["Leasings"];
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            MySqlConnection con_cls = MySQLConnection.connectionMySQL();
            MySqlConnection con_cpn = MySQLConnection.connectionMySQL();
            try
            {

                con_cls.Open();
                MySqlCommand cmd_cls = new MySqlCommand("rpt_leasings", con_cls);
                cmd_cls.CommandType = CommandType.StoredProcedure;
                cmd_cls.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cls = cmd_cls.ExecuteReader();

                con_cpn.Open();
                MySqlCommand cmd_cpn = new MySqlCommand("rpt_withholding_tax", con_cpn);
                cmd_cpn.CommandType = CommandType.StoredProcedure;
                cmd_cpn.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cpn = cmd_cpn.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Leasings"].Load(reader_cls);
                ls_ds.Tables["Agent_Commission"].Load(reader_cpn);


                Withholding_Tax rpt = new Withholding_Tax();
                rpt.SetDataSource(ls_ds);

                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "หนังสือรับรองหัก_ณ_ที่จ่าย_" + cls.Deps_no);
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
                con_cpn.Close();

                con_cls.Dispose();
                con_cpn.Dispose();
            }

            /// Acticity Logs System
            ///  

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ออกรายงานลูกค้าคงเหลือ " , acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System


            GC.Collect();

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

            string FilePath = "C:/ReportExport/" + mainDirectory + "/หนังสือรับรองหัก_ณ_ที่จ่าย_" + cls.Deps_no + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/หนังสือรับรองหัก_ณ_ที่จ่าย_" + cls.Deps_no + ".pdf");

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

            User.Dispose();
            rpt.Dispose();

            GC.Collect();
        }
    }
}