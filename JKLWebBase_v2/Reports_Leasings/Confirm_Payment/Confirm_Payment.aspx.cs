using CrystalDecisions.Shared;
using System;
using System.IO;
using System.Web.UI;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using System.Net;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Reports_Leasings.Confirm_Payment
{
    public partial class Confirm_Payment : Page
    {
        private Car_Leasings cls = new Car_Leasings();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        string error = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            if (Session["Data_CFPM_Values"] != null)
            {
                printReport();
            }
        }

        public void printReport()
        {
            try
            {
                cls = (Car_Leasings)Session["Leasings"];

                string Company_Values = (string)Session["Data_CFPM_Values"];

                string[] Array_Data = Company_Values.Split('|');

                Confirm_Payment_Outline rpt = new Confirm_Payment_Outline();
                rpt.SetParameterValue("Company_Name", Array_Data[0]);
                rpt.SetParameterValue("Company_Type", Array_Data[1]);
                rpt.SetParameterValue("Car_Plate", Array_Data[2]);
                rpt.SetParameterValue("Car_Type", Array_Data[3]);
                rpt.SetParameterValue("Car_Brand", Array_Data[4]);
                rpt.SetParameterValue("Car_Engine_No", Array_Data[5]);
                rpt.SetParameterValue("Car_Chassis_No", Array_Data[6]);
                rpt.SetParameterValue("Payment_To", Array_Data[7]);
                rpt.SetParameterValue("Payment_Amount", Convert.ToDouble(Array_Data[8]));
                rpt.SetParameterValue("Bottom_Address", Array_Data[9]);
                rpt.SetParameterValue("Print_Date", DateTimeUtility.convertDateToPage(cls.Leasing_date));

                CRV_Display_Report.ReportSource = rpt;

                /// Export Report to PDF File with Save As Mode
                /// rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Payment_Schedule_" + cls.Deps_no);
                /// Response.End();

                ExportReport(rpt);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Confirm_Payment : Page --> printReport() ";
                Log_Error._writeErrorFile(error, ex);
            }

            GC.Collect();
        }

        public void ExportReport(Confirm_Payment_Outline rpt)
        {
            cls = (Car_Leasings)Session["Leasings"];

            /// Create Main Folder for Detected Images of Contact Leasing
            string mainDirectory = cls.Leasing_id;

            string mainDirectoryPath = "C:/ReportExport/" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string FilePath = "C:/ReportExport/" + mainDirectory + "/หนังสือยืนยันการชำระเงิน_" + cls.Deps_no + ".pdf";

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/หนังสือยืนยันการชำระเงิน_" + cls.Deps_no + ".pdf");

            /// Display PDF File to PDF Program
            /// Process process = new Process();
            /// process.StartInfo.UseShellExecute = true;
            /// process.StartInfo.FileName = FilePath;
            /// process.Start();

            WebClient User = new WebClient();
            byte[] FileBuffer = User.DownloadData(FilePath);
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