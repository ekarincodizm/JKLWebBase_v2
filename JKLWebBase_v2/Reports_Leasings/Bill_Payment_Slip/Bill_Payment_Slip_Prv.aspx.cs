﻿using CrystalDecisions.Shared;
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

namespace JKLWebBase_v2.Reports_Leasings.Bill_Payment_Slip
{
    public partial class Bill_Payment_Slip_Prv : Page
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

            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string leasing_id = code[1];
                    string bill_no = code[2];

                    _loadReport(leasing_id, bill_no);
                }
            }
        }

        private void _loadReport(string leasing_id, string bill_no)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_bill_payment_slip", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", leasing_id);
                cmd.Parameters.AddWithValue("@i_Bill_no", bill_no);
                MySqlDataReader reader_cls = cmd.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Bill_Payment_Slip"].Load(reader_cls);
                
                Bill_Payment_Slip rpt = new Bill_Payment_Slip();
                rpt.SetDataSource(ls_ds);
                rpt.SetParameterValue("Print_Bill_Date", DateTimeUtility.convertDateTimeToPage(DateTimeUtility._dateTimeNOWForServer()));

                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "หนังสือรับรองหัก_ณ_ที่จ่าย_" + cls.Deps_no);
                /// Response.End();

                ExportReport(rpt, leasing_id, bill_no);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Bill_Payment_Slip_Prv : Page --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Bill_Payment_Slip_Prv : Page --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            GC.Collect();
        }

        public void ExportReport(Bill_Payment_Slip rpt, string leasing_id, string bill_no)
        {
            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = DateTime.Now.ToString("yyyy-MM-dd");

            string mainDirectoryPath = "C:/ReportExport/Bill_Payment_Slip/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/Bill_Payment_Slip/" + mainDirectory + "/" + bill_no.Replace('ฝ', 'D').Replace('/','-') + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/Bill_Payment_Slip/" + mainDirectory + "/" + bill_no.Replace('ฝ', 'D').Replace('/', '-') + ".pdf");

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