﻿using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.IO;
using System.Web.UI;
using System.Data;

using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Reports_Leasings.DataSet_Leasings;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Reports_Leasings.Total_Balance_Payment
{
    public partial class Total_Balance_Payment_Export : Page
    {
        string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            _loadReport();

            Session.Remove("leasing_Code_inline_rpt");
            Session.Remove("Company_id_inline_rpt");
            Session.Remove("zone_id_inline_rpt");
        }

        private void _loadReport()
        {
            string leasing_Code_inline = (string)Session["leasing_Code_inline_rpt"];
            string Company_id_inline = (string)Session["Company_id_inline_rpt"];
            string zone_id_inline = (string)Session["zone_id_inline_rpt"];
            string report_header = " รายงานลูกหนี้คงเหลือ ";

            if (leasing_Code_inline == "" && Company_id_inline == "" && zone_id_inline == "")
            {
                report_header = " รายงานลูกหนี้คงเหลือ (ทั้งหมด)";
            }

            Base_Companys package_login = new Base_Companys();
            Account_Login acc_lgn = new Account_Login();

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            MySqlConnection con = MySQLConnection.connectionMySQL();

            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_generals_leasing", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Deps_no", "");
                cmd.Parameters.AddWithValue("@i_Leasing_no", "");
                cmd.Parameters.AddWithValue("@i_Cust_idcard", "");
                cmd.Parameters.AddWithValue("@i_Cust_Fname", "");
                cmd.Parameters.AddWithValue("@i_Cust_LName", "");
                cmd.Parameters.AddWithValue("@i_Leasing_date_str", "");
                cmd.Parameters.AddWithValue("@i_Leasing_date_end", "");
                cmd.Parameters.AddWithValue("@i_Leasing_code_id", leasing_Code_inline);
                cmd.Parameters.AddWithValue("@i_Company_id", Company_id_inline);
                cmd.Parameters.AddWithValue("@i_Zone_id", zone_id_inline);
                cmd.Parameters.AddWithValue("@i_lost_str", 0);
                cmd.Parameters.AddWithValue("@i_lost_end", 0);
                cmd.Parameters.AddWithValue("@i_row_str", 0);
                cmd.Parameters.AddWithValue("@i_row_limit", 0);

                MySqlDataReader reader = cmd.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Report_General_Leasings"].Load(reader);

                Total_Balance_Payment rpt = new Total_Balance_Payment();
                rpt.SetDataSource(ls_ds);
                rpt.SetParameterValue("Reported_By_User", "ออกโดย : " + acc_lgn.Account_F_name);
                rpt.SetParameterValue("Reported_Print_Date", "วันที่พิมพ์ : " + DateTimeUtility.convertDateToPage(DateTimeUtility._dateNOW()));
                rpt.SetParameterValue("Report_Header", report_header);


                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "หน้าการ์ด_" + cls.Deps_no);
                /// Response.End();

                ExportReport_Mod_I(rpt);
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
        }
    }
}