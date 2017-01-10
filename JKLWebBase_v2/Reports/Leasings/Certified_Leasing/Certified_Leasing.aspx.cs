using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Diagnostics;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Reports.Leasings.DataSet_Leasings;

namespace JKLWebBase_v2.Reports.Leasings.Certified_Leasing
{
    public partial class Certified_Leasing : Page
    {
        Car_Leasings cls = new Car_Leasings();
        Leasing_Ds ls_ds = new Leasing_Ds();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["mod"] != null)
            {
                ls_ds = _loadReport();

                if (Request.Params["mod"] == "1")
                {
                    //printReport(ls_ds);
                }
                else if (Request.Params["mod"] == "2")
                {
                    printReportFull(ls_ds);
                }
            }
        }

        private Leasing_Ds _loadReport()
        {
            cls = (Car_Leasings)Session["Leasings"];

            MySqlConnection con_cls = MySQLConnection.connectionMySQL();
            MySqlConnection con_ctm = MySQLConnection.connectionMySQL();
            try
            {

                con_cls.Open();
                MySqlCommand cmd_cls = new MySqlCommand("r_leasings", con_cls);
                cmd_cls.CommandType = CommandType.StoredProcedure;
                cmd_cls.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                MySqlDataReader reader_cls = cmd_cls.ExecuteReader();

                con_ctm.Open();
                MySqlCommand cmd_ctm = new MySqlCommand("r_customers", con_ctm);
                cmd_ctm.CommandType = CommandType.StoredProcedure;
                cmd_ctm.Parameters.AddWithValue("@i_Cust_id", cls.Cust_id);
                MySqlDataReader reader_ctm = cmd_ctm.ExecuteReader();

                Leasing_Ds ls_ds = new Leasing_Ds();
                ls_ds.Clear();
                ls_ds.Tables["Leasings"].Load(reader_cls);
                ls_ds.Tables["Customers"].Load(reader_ctm);

                return ls_ds;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Certified_Leasing --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Certified_Leasing --> _loadReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
                return null;
            }
            finally
            {
                con_cls.Close();
                con_ctm.Close();

                con_cls.Dispose();
                con_ctm.Dispose();
            }
        }

        /*public void printReport(Leasing_Ds ls_ds)
        {
            cls = (Car_Leasings)Session["Leasings"];

            Certified_Leasing_Half rpt = new Certified_Leasing_Half();
            rpt.SetDataSource(ls_ds);

            CRV_Display_Report.ReportSource = rpt;

            /// Export Report to PDF File with Save As Mode
            /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_" + cls.Deps_no);
            /// Response.End();

            ExportReport(rpt);
        }*/

       public void printReportFull(Leasing_Ds ls_ds)
       {
            cls = (Car_Leasings)Session["Leasings"];

            Certified_Leasing_Full rpt = new Certified_Leasing_Full();
            rpt.SetDataSource(ls_ds);

            CRV_Display_Report.ReportSource = rpt;

            /// Export Report to PDF File with Save As Mode
            /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_" + cls.Deps_no);
            /// Response.End();

            ExportReportFull(rpt);
        }

       /*public void ExportReport(Certified_Leasing_Half rpt)
       {
           cls = (Car_Leasings)Session["Leasings"];

            /// Create Main Folder for Detected Images of Contact Leasing
            string mainDirectory = cls.Leasing_id;

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Certified_Leasing_" + cls.Deps_no + ".pdf");

            /// Display PDF File to PDF Program
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "C:/ReportExport/" + mainDirectory + "/Certified_Leasing_" + cls.Deps_no + ".pdf";
            process.Start();
        }*/

        public void ExportReportFull(Certified_Leasing_Full rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            /// Create Main Folder for Detected Images of Contact Leasing
            string mainDirectory = cls.Leasing_id;

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/Certified_Leasing_Full_" + cls.Deps_no + ".pdf");

            /// Display PDF File to PDF Program
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "C:/ReportExport/" + mainDirectory + "/Certified_Leasing_Full_" + cls.Deps_no + ".pdf";
            process.Start();
        }
    }
}