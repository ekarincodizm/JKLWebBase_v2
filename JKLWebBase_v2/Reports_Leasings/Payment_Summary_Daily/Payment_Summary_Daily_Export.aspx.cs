using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.IO;
using System.Web.UI;
using System.Data;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Reports_Leasings.DataSet_Leasings;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Reports_Leasings.Payment_Summary_Daily
{
    public partial class Payment_Summary_Daily_Export : Page
    {
        string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            int mode = (int)Session["mode"];

            if(mode == 1)
            {
                _loadReport_mod_I();
            }
            else if (mode == 2)
            {
                _loadReport_mod_II();
            }

            Session.Remove("date_str");
            Session.Remove("date_end");
            Session.Remove("Company_id_inline_rpt");
            Session.Remove("leasing_Code_inline_rpt");
            Session.Remove("zone_id_inline_rpt");
        }

        private void _loadReport_mod_I()
        {
            string date_str = (string)Session["date_str"];
            string date_end = (string)Session["date_end"];
            string Company_id_inline = (string)Session["Company_id_inline_rpt"];
            string leasing_Code_inline = (string)Session["leasing_Code_inline_rpt"];
            string zone_id_inline = (string)Session["zone_id_inline_rpt"];

            string report_header = "รายงานการชำระเงิน 1 ประจำวันที่ " + DateTimeUtility.convertDateToPage(date_str);

            if(date_end != "")
            {
                report_header = "รายงานการชำระเงิน 1 ประจำวันที่ " + DateTimeUtility.convertDateToPage(date_str) + " ถึง " + DateTimeUtility.convertDateToPage(date_end);
            }

            Base_Companys package_login = new Base_Companys();
            Account_Login acc_lgn = new Account_Login();

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            MySqlConnection con = MySQLConnection.connectionMySQL();

            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_real_payment_daily", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@i_payment_str_date", date_str);
                cmd.Parameters.AddWithValue("@i_payment_end_date", date_end);
                cmd.Parameters.AddWithValue("@i_Leasing_code_id", leasing_Code_inline);
                cmd.Parameters.AddWithValue("@i_Company_id", Company_id_inline);
                cmd.Parameters.AddWithValue("@i_Zone_id", zone_id_inline);
                cmd.Parameters.AddWithValue("@i_row_str", 0);
                cmd.Parameters.AddWithValue("@i_row_limit", 0);

                MySqlDataReader reader = cmd.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Report_Payments"].Load(reader);

                Payment_Summary_Daily_mod_I_001 rpt = new Payment_Summary_Daily_mod_I_001();
                rpt.SetDataSource(ls_ds);
                rpt.SetParameterValue("Reported_By_User", "ออกโดย : " + acc_lgn.Account_F_name);
                rpt.SetParameterValue("Reported_Print_Date", "วันที่พิมพ์ : " + DateTimeUtility.convertDateTimeToPage(DateTimeUtility._dateTimeNOWForServer()));
                rpt.SetParameterValue("Report_Header", report_header);


                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "หน้าการ์ด_" + cls.Deps_no);
                /// Response.End();

                ExportReport_Mod_I(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Summary_Daily_Export --> _loadReport_mod_I() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Summary_Daily_Export --> _loadReport_mod_I() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            /// Acticity Logs System
            ///  

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ออก" + report_header, acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System
        }

        public void ExportReport_Mod_I(Payment_Summary_Daily_mod_I_001 rpt)
        {
            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = "Payment_Summary_Daily_I";

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/Daily_" + DateTimeUtility._dateToFile() + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Daily_" + DateTimeUtility._dateToFile() + ".pdf");

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

        private void _loadReport_mod_II()
        {
            string date_str = (string)Session["date_str"];
            string date_end = (string)Session["date_end"];
            string Company_id_inline = (string)Session["Company_id_inline_rpt"];
            string leasing_Code_inline = (string)Session["leasing_Code_inline_rpt"];
            string zone_id_inline = (string)Session["zone_id_inline_rpt"];

            string report_header = "รายงานการชำระเงิน 2 ประจำวันที่ " + DateTimeUtility.convertDateToPage(date_str);

            if (date_end != "")
            {
                report_header = "รายงานการชำระเงิน 2 ประจำวันที่ " + DateTimeUtility.convertDateToPage(date_str) + " ถึง " + DateTimeUtility.convertDateToPage(date_end);
            }

            Base_Companys package_login = new Base_Companys();
            Account_Login acc_lgn = new Account_Login();

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            MySqlConnection con = MySQLConnection.connectionMySQL();

            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_real_payment_daily", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@i_payment_str_date", date_str);
                cmd.Parameters.AddWithValue("@i_payment_end_date", date_end);
                cmd.Parameters.AddWithValue("@i_Leasing_code_id", leasing_Code_inline);
                cmd.Parameters.AddWithValue("@i_Company_id", Company_id_inline);
                cmd.Parameters.AddWithValue("@i_Zone_id", zone_id_inline);
                cmd.Parameters.AddWithValue("@i_row_str", 0);
                cmd.Parameters.AddWithValue("@i_row_limit", 0);

                MySqlDataReader reader = cmd.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Report_Payments"].Load(reader);

                Payment_Summary_Daily_mod_II rpt = new Payment_Summary_Daily_mod_II();
                rpt.SetDataSource(ls_ds);
                rpt.SetParameterValue("Reported_By_User", "ออกโดย : " + acc_lgn.Account_F_name);
                rpt.SetParameterValue("Reported_Print_Date", "วันที่พิมพ์ : " + DateTimeUtility.convertDateTimeToPage(DateTimeUtility._dateTimeNOWForServer()));
                rpt.SetParameterValue("Report_Header", report_header);

                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "หน้าการ์ด_" + cls.Deps_no);
                /// Response.End();

                ExportReport_Mod_II(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Summary_Daily_Export --> _loadReport_mod_II() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Summary_Daily_Export --> _loadReport_mod_II() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            /// Acticity Logs System
            ///  

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ออก" + report_header, acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System
        }

        public void ExportReport_Mod_II(Payment_Summary_Daily_mod_II rpt)
        {
            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = "Payment_Summary_Daily_II";

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/Daily_" + DateTimeUtility._dateToFile() + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Daily_" + DateTimeUtility._dateToFile() + ".pdf");

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