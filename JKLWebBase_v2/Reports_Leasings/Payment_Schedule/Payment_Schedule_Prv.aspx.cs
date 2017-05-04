using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Diagnostics;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using System.Net;

namespace JKLWebBase_v2.Reports_Leasings.Payment_Schedule
{
    public partial class Payment_Schedule_Prv : Page
    {
        private Car_Leasings cls = new Car_Leasings();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["mod"] != null)
            {
                if (Request.Params["mod"] == "1")
                {
                    _loadReport();
                }
                else if (Request.Params["mod"] == "2")
                {
                    _loadReportFull();
                }
            }
        }

        private void _loadReport()
        {
            cls = (Car_Leasings)Session["Leasings"];

            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ rpt_payment_schedule ] :: 
                 *  rpt_payment_schedule (IN i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_payment_schedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                Payment_Schedule_Ds pay_schd_ds = new Payment_Schedule_Ds();
                pay_schd_ds.Clear();
                pay_schd_ds.Tables["r_payment_schedule"].Load(reader);

                Payment_Schedule rpt = new Payment_Schedule();
                rpt.SetDataSource(pay_schd_ds);

                CRV_Payment_Schedule.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_" + cls.Deps_no);
                /// Response.End();

                ExportReport(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Schedule_Prv --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Schedule_Prv --> _loadReport() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void _loadReportFull()
        {
            cls = (Car_Leasings)Session["Leasings"];

            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /* 
                 * :: StoredProcedure :: [ rpt_payment_schedule ] :: 
                 *  rpt_payment_schedule (IN i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("rpt_payment_schedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                Payment_Schedule_Ds pay_schd_ds = new Payment_Schedule_Ds();
                pay_schd_ds.Clear();
                pay_schd_ds.Tables["r_payment_schedule"].Load(reader);

                Payment_Schedule_Full rpt = new Payment_Schedule_Full();
                rpt.SetDataSource(pay_schd_ds);

                CRV_Payment_Schedule.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_Full_" + cls.Deps_no);
                /// Response.End();

                ExportReportFull(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Schedule_Prv --> _loadReportFull() ";
                Log_Error._writeErrorFile(error, ex);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Schedule_Prv --> _loadReportFull() ";
                Log_Error._writeErrorFile(error, ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void ExportReport(Payment_Schedule rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = cls.Leasing_id;

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/Payment_Schedule_" + cls.Deps_no + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Payment_Schedule_" + cls.Deps_no+".pdf");

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
        public void ExportReportFull(Payment_Schedule_Full rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = cls.Leasing_id;

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/Payment_Schedule_Full_" + cls.Deps_no + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Payment_Schedule_Full_" + cls.Deps_no + ".pdf");

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