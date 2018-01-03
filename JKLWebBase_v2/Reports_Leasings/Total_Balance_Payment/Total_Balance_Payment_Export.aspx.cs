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

namespace JKLWebBase_v2.Reports_Leasings.Total_Balance_Payment
{
    public partial class Total_Balance_Payment_Export : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            _loadReport();

            Session.Remove("deposit_no_rpt");
            Session.Remove("leasing_no_rpt");
            Session.Remove("idcard_rpt");
            Session.Remove("fname_rpt");
            Session.Remove("lname_rpt");
            Session.Remove("lost_str_rpt");
            Session.Remove("lost_end_rpt");
            Session.Remove("district_rpt");
            Session.Remove("province_rpt");
            Session.Remove("leasing_Code_inline_rpt");
            Session.Remove("Company_id_inline_rpt");
            Session.Remove("zone_id_inline_rpt");
        }

        private void _loadReport()
        {
            string deposit_no = (string)Session["deposit_no_rpt"];
            string leasing_no = (string)Session["leasing_no_rpt"];
            string idcard = (string)Session["idcard_rpt"];
            string fname = (string)Session["fname_rpt"];
            string lname = (string)Session["lname_rpt"];
            string lost_str = (string)Session["lost_str_rpt"];
            string lost_end = (string)Session["lost_end_rpt"];
            string district = (string)Session["district_rpt"];
            string province = (string)Session["province_rpt"];
            string leasing_Code_inline = (string)Session["leasing_Code_inline_rpt"];
            string Company_id_inline = (string)Session["Company_id_inline_rpt"];
            string zone_id_inline = (string)Session["zone_id_inline_rpt"];
            string report_header = " รายงานลูกหนี้คงเหลือ ";

            bool chk_all = false;

            if (leasing_Code_inline == "" && Company_id_inline == "" && zone_id_inline == "")
            {
                report_header = " รายงานลูกหนี้คงเหลือ (ทั้งหมด)";

                chk_all = true;
            }

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            MySqlConnection con = MySQLConnection.connectionMySQL();

            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_total_balance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@i_Deps_no", deposit_no);
                cmd.Parameters.AddWithValue("@i_Leasing_no", leasing_no);
                cmd.Parameters.AddWithValue("@i_Cust_idcard", idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", lname);
                cmd.Parameters.AddWithValue("@i_Leasing_date_str", "");
                cmd.Parameters.AddWithValue("@i_Leasing_date_end", "");
                cmd.Parameters.AddWithValue("@i_Leasing_code_id", leasing_Code_inline);
                cmd.Parameters.AddWithValue("@i_Company_id", Company_id_inline);
                cmd.Parameters.AddWithValue("@i_Zone_id", zone_id_inline);
                cmd.Parameters.AddWithValue("@i_lost_str", lost_str);
                cmd.Parameters.AddWithValue("@i_lost_end", lost_end);
                cmd.Parameters.AddWithValue("@i_district", district);
                cmd.Parameters.AddWithValue("@i_province", province);
                cmd.Parameters.AddWithValue("@i_row_str", 0);
                cmd.Parameters.AddWithValue("@i_row_limit", 0);

                MySqlDataReader reader = cmd.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Report_General_Leasings"].Load(reader);

                if (chk_all)
                {
                    Total_Balance_Payment_All rpt = new Total_Balance_Payment_All();
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
                else
                {
                    Total_Balance_Payment rpt = new Total_Balance_Payment();
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
                
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Total_Balance_Payment_Export --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Total_Balance_Payment_Export --> _loadReport() ";
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

            GC.Collect();
        }

        public void ExportReport_Mod_I(Total_Balance_Payment rpt)
        {
            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = "Total_Balance_Payment";

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/รายงานลูกหนี้คงค้าง_" + DateTimeUtility._dateToFile() + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/รายงานลูกหนี้คงค้าง_" + DateTimeUtility._dateToFile() + ".pdf");

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

        public void ExportReport_Mod_II(Total_Balance_Payment_All rpt)
        {
            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = "Total_Balance_Payment";

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/รายงานลูกหนี้คงค้างทั้งหมด_" + DateTimeUtility._dateToFile() + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/รายงานลูกหนี้คงค้างทั้งหมด_" + DateTimeUtility._dateToFile() + ".pdf");

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