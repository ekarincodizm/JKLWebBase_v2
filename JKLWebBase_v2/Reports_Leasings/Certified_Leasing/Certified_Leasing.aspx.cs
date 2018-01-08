using CrystalDecisions.Shared;
using System;
using System.IO;
using System.Web.UI;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Reports_Leasings.DataSet_Leasings;
using System.Net;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Reports_Leasings.Certified_Leasing
{
    public partial class Certified_Leasing : Page
    {
        private Car_Leasings cls = new Car_Leasings();
        private Leasing_Ds ls_ds = new Leasing_Ds();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            if (Request.Params["mod"] != null)
            {
                if (Request.Params["mod"] == "1")
                {
                    printReport();
                }
            }
            else
            {
                printReportOutline();
            }
        }

        public void printReportOutline()
        {
            if (Session["Company_Values"] != null)
            {
                try
                {
                    string Company_Values = (string)Session["Company_Values"];

                    string[] Array_Company = Company_Values.Split('|');

                    Certified_Leasing_Outline rpt = new Certified_Leasing_Outline();
                    rpt.SetParameterValue("Company_Name", Array_Company[0]);
                    rpt.SetParameterValue("Company_Address", Array_Company[1]);
                    rpt.SetParameterValue("SubCompany_Address_1", Array_Company[2]);
                    rpt.SetParameterValue("SubCompany_Address_2", Array_Company[3]);
                    rpt.SetParameterValue("SubCompany_Address_3", Array_Company[4]);

                    CRV_Display_Report.ReportSource = rpt;

                    /// Export Report to PDF File with Save As Mode
                    /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_" + cls.Deps_no);
                    /// Response.End();

                    ExportReportOutline(rpt, Array_Company[0]);
                }
                catch (Exception ex)
                {
                    error = "Exception ==> Certified_Leasing : Page --> printReportOutline() ";
                    Log_Error._writeErrorFile(error, ex);
                }
            }

            GC.Collect();
        }

        public void ExportReportOutline(Certified_Leasing_Outline rpt, string file_name)
        {
            try
            {
                /// Create Main Folder for Detected Images of Contact Leasing
                string mainDirectory = "OutlineReport";

                string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

                if (!Directory.Exists(mainDirectoryPath))
                {
                    Directory.CreateDirectory(mainDirectoryPath);
                }

                string FilePath = "C:/ReportExport/" + mainDirectory + "/หนังสือรับรองการเช่า-ซื้อ_template_" + file_name + ".pdf";

                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }

                /// Export Report to PDF File with Save As Mode
                rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/หนังสือรับรองการเช่า-ซื้อ_template_" + file_name + ".pdf");

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
            }
            catch (Exception ex)
            {
                error = "Exception ==> Certified_Leasing : Page --> ExportReportOutline() ";
                Log_Error._writeErrorFile(error, ex);
            }

            rpt.Dispose();

            GC.Collect();
        }

        public void printReport()
        {
            if (Session["Data_CTFLS_Values"] != null)
            {
                try
                {
                    string Data_CTFLS_Values = (string)Session["Data_CTFLS_Values"];

                    string[] Array_Data_CTFLS_Values = Data_CTFLS_Values.Split('|');

                    Certified_Leasing_Result rpt = new Certified_Leasing_Result();
                    rpt.SetParameterValue("Leasing_Date", Array_Data_CTFLS_Values[0]);
                    rpt.SetParameterValue("Registrar", Array_Data_CTFLS_Values[1]);
                    rpt.SetParameterValue("Car_detail", Array_Data_CTFLS_Values[2]);
                    rpt.SetParameterValue("Car_model", Array_Data_CTFLS_Values[3]);
                    rpt.SetParameterValue("Car_engine_no", Array_Data_CTFLS_Values[4]);
                    rpt.SetParameterValue("Car_chassis_no", Array_Data_CTFLS_Values[5]);
                    rpt.SetParameterValue("Ctm_name", Array_Data_CTFLS_Values[6]);
                    rpt.SetParameterValue("Ctm_address_no", Array_Data_CTFLS_Values[7]);
                    rpt.SetParameterValue("Ctm_moo", Array_Data_CTFLS_Values[8]);
                    rpt.SetParameterValue("Ctm_alley", Array_Data_CTFLS_Values[9]);
                    rpt.SetParameterValue("Ctm_road", Array_Data_CTFLS_Values[10]);
                    rpt.SetParameterValue("Ctm_subdistrict", Array_Data_CTFLS_Values[11]);
                    rpt.SetParameterValue("Ctm_district", Array_Data_CTFLS_Values[12]);
                    rpt.SetParameterValue("Ctm_Province", Array_Data_CTFLS_Values[13]);
                    rpt.SetParameterValue("Finance", Array_Data_CTFLS_Values[14]);
                    rpt.SetParameterValue("Interest", Array_Data_CTFLS_Values[15]);
                    rpt.SetParameterValue("Total_Finance", Array_Data_CTFLS_Values[16]);
                    rpt.SetParameterValue("Total_period", Array_Data_CTFLS_Values[17]);
                    rpt.SetParameterValue("Period_pay", Array_Data_CTFLS_Values[18]);
                    rpt.SetParameterValue("Period_vat", Array_Data_CTFLS_Values[19]);
                    rpt.SetParameterValue("Total_sum_Period", Array_Data_CTFLS_Values[20]);
                    rpt.SetParameterValue("For", Array_Data_CTFLS_Values[21]);
                    rpt.SetParameterValue("Agree", Array_Data_CTFLS_Values[22]);


                    CRV_Display_Report.ReportSource = rpt;

                    /// Export Report to PDF File with Save As Mode
                    /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_" + cls.Deps_no);
                    /// Response.End();

                    ExportReport(rpt);
                }
                catch (Exception ex)
                {
                    error = "Exception ==> Certified_Leasing : Page --> printReport()";
                    Log_Error._writeErrorFile(error, ex);
                }
            }

            GC.Collect();
        }

        public void ExportReport(Certified_Leasing_Result rpt)
        {
            try
            {
                cls = (Car_Leasings)Session["Leasings"];

                /// Create Main Folder for Detected Images of Contact Leasing
                string mainDirectory = cls.Leasing_id;

                string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

                if (!Directory.Exists(mainDirectoryPath))
                {
                    Directory.CreateDirectory(mainDirectoryPath);
                }

                string FilePath = "C:/ReportExport/" + mainDirectory + "/หนังสือรับรองการเช่า-ซื้อ_" + cls.Deps_no + ".pdf";

                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }

                /// Export Report to PDF File with Save As Mode
                rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/หนังสือรับรองการเช่า-ซื้อ_" + cls.Deps_no + ".pdf");

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
            }
            catch (Exception ex)
            {
                error = "Exception ==> Certified_Leasing : Page --> ExportReport() ";
                Log_Error._writeErrorFile(error, ex);
            }

            rpt.Dispose();

            GC.Collect();
        }
    }
}