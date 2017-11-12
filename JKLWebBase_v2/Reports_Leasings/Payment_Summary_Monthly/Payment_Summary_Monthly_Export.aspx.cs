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

namespace JKLWebBase_v2.Reports_Leasings.Payment_Summary_Monthly
{
    public partial class Payment_Summary_Monthly_Export : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
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

            Session.Remove("month");
            Session.Remove("year");
            Session.Remove("Company_id_inline_rpt");
            Session.Remove("leasing_Code_inline_rpt");
            Session.Remove("zone_id_inline_rpt");
        }

        private void _loadReport_mod_I()
        {
            string month = (string)Session["month"];
            string year = (string)Session["year"];
            string Company_id_inline = (string)Session["Company_id_inline_rpt"];
            string leasing_Code_inline = (string)Session["leasing_Code_inline_rpt"];
            string zone_id_inline = (string)Session["zone_id_inline_rpt"];

            string report_header = "รายงานการชำระเงิน 1 ประจำเดือน " + DateTimeUtility.convertMonthToThai(month) + " " + (Convert.ToInt32(year) + 543);

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            MySqlConnection con = MySQLConnection.connectionMySQL();

            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_real_payment_monthly", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@i_month", month);
                cmd.Parameters.AddWithValue("@i_year", year);
                cmd.Parameters.AddWithValue("@i_Leasing_code_id", leasing_Code_inline);
                cmd.Parameters.AddWithValue("@i_Company_id", Company_id_inline);
                cmd.Parameters.AddWithValue("@i_Zone_id", zone_id_inline);
                cmd.Parameters.AddWithValue("@i_row_str", 0);
                cmd.Parameters.AddWithValue("@i_row_limit", 0);

                MySqlDataReader reader = cmd.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Report_Payments"].Load(reader);

                Payment_Summary_Monthly_mod_I_001 rpt = new Payment_Summary_Monthly_mod_I_001();
                rpt.SetDataSource(ls_ds);
                rpt.SetParameterValue("Reported_By_User", "ออกโดย : " + acc_lgn.Account_F_name);
                rpt.SetParameterValue("Reported_Print_Date", "วันที่พิมพ์ : " + DateTimeUtility.convertDateTimeToPageRealServer(DateTimeUtility._dateTimeNOWForServer()));
                rpt.SetParameterValue("Report_Header", report_header);


                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "หน้าการ์ด_" + cls.Deps_no);
                /// Response.End();

                ExportReport_Mod_I(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Summary_Monthly_Export --> _loadReport_mod_I() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Summary_Monthly_Export --> _loadReport_mod_I() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void ExportReport_Mod_I(Payment_Summary_Monthly_mod_I_001 rpt)
        {
            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = "Payment_Summary_Monthly_I";

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/Monthly_" + DateTimeUtility._dateToFile() + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Monthly_" + DateTimeUtility._dateToFile() + ".pdf");

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
            string month = (string)Session["month"];
            string year = (string)Session["year"];
            string Company_id_inline = (string)Session["Company_id_inline_rpt"];
            string leasing_Code_inline = (string)Session["leasing_Code_inline_rpt"];
            string zone_id_inline = (string)Session["zone_id_inline_rpt"];

            string report_header = "รายงานการชำระเงิน 2 ประจำเดือน " + DateTimeUtility.convertMonthToThai(month) + " " + (Convert.ToInt32(year) + 543);

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            MySqlConnection con = MySQLConnection.connectionMySQL();

            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_real_payment_monthly", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@i_month", month);
                cmd.Parameters.AddWithValue("@i_year", year);
                cmd.Parameters.AddWithValue("@i_Leasing_code_id", leasing_Code_inline);
                cmd.Parameters.AddWithValue("@i_Company_id", Company_id_inline);
                cmd.Parameters.AddWithValue("@i_Zone_id", zone_id_inline);
                cmd.Parameters.AddWithValue("@i_row_str", 0);
                cmd.Parameters.AddWithValue("@i_row_limit", 0); ;

                MySqlDataReader reader = cmd.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Report_Payments"].Load(reader);

                Payment_Summary_Monthly_mod_II rpt = new Payment_Summary_Monthly_mod_II();
                rpt.SetDataSource(ls_ds);
                rpt.SetParameterValue("Reported_By_User", "ออกโดย : " + acc_lgn.Account_F_name);
                rpt.SetParameterValue("Reported_Print_Date", "วันที่พิมพ์ : " + DateTimeUtility.convertDateTimeToPageRealServer(DateTimeUtility._dateTimeNOWForServer()));
                rpt.SetParameterValue("Report_Header", report_header);

                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "หน้าการ์ด_" + cls.Deps_no);
                /// Response.End();

                ExportReport_Mod_II(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Summary_Monthly_Export --> _loadReport_mod_II() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Summary_Monthly_Export --> _loadReport_mod_II() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void ExportReport_Mod_II(Payment_Summary_Monthly_mod_II rpt)
        {
            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = "Payment_Summary_Monthly_II";

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/Monthly_" + DateTimeUtility._dateToFile() + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Monthly_" + DateTimeUtility._dateToFile() + ".pdf");

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