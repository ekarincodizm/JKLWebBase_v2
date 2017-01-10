using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Diagnostics;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;

namespace JKLWebBase_v2.Reports.Leasings.Payment_Schedule
{
    public partial class Payment_Schedule_Prv : Page
    {
        Car_Leasings cls = new Car_Leasings();
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
                 * :: StoredProcedure :: [ r_payment_schedule ] :: 
                 *  r_payment_schedule (IN i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("r_payment_schedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                Payment_Schedule_Ds pay_schd_ds = new Payment_Schedule_Ds();
                pay_schd_ds.Clear();
                pay_schd_ds.Tables["r_payment_schedule"].Load(reader);

                Payment_Schedule rpt = new Payment_Schedule();
                rpt.SetDataSource(pay_schd_ds);

                CRV_Payment_Schedule.ReportSource = rpt;

                //printReport(rpt);

                ExportReport(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Schedule_Prv --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Schedule_Prv --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
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
                 * :: StoredProcedure :: [ r_payment_schedule ] :: 
                 *  r_payment_schedule (IN i_Leasing_id varchar(50))
                 * 
                 */

                con.Open();
                MySqlCommand cmd = new MySqlCommand("r_payment_schedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);

                MySqlDataReader reader = cmd.ExecuteReader();

                Payment_Schedule_Ds pay_schd_ds = new Payment_Schedule_Ds();
                pay_schd_ds.Clear();
                pay_schd_ds.Tables["r_payment_schedule"].Load(reader);

                Payment_Schedule_Full rpt = new Payment_Schedule_Full();
                rpt.SetDataSource(pay_schd_ds);

                CRV_Payment_Schedule.ReportSource = rpt;

                //printReportFull(rpt);

                ExportReportFull(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Schedule_Prv --> _loadReportFull() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Schedule_Prv --> _loadReportFull() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void printReport(Payment_Schedule rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_" + cls.Deps_no);
            Response.End();
        }
        public void printReportFull(Payment_Schedule_Full rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_Full_" + cls.Deps_no);
            Response.End();
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

            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Payment_Schedule_" + cls.Deps_no+".pdf");

            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "C:/ReportExport/" + mainDirectory + "/Payment_Schedule_" + cls.Deps_no + ".pdf";
            process.Start();
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

            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Payment_Schedule_Full_" + cls.Deps_no + ".pdf");

            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "C:/ReportExport/" + mainDirectory + "/Payment_Schedule_Full_" + cls.Deps_no + ".pdf";
            process.Start();
        }

    }
}