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

namespace JKLWebBase_v2.Reports.Leasings.Confirm_Payment
{
    public partial class Confirm_Payment : Page
    {
        Car_Leasings cls = new Car_Leasings();
        string error = "";

        protected void Page_Load(object sender, EventArgs e)
        {
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
                error = "Exception ==> Confirm_Payment : Page --> printReport() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
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

            /// Export Report to PDF File with Save As Mode
            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:/ReportExport/" + mainDirectory + "/หนังสือยืนยันการชำระเงิน_" + cls.Deps_no + ".pdf");

            /// Display PDF File to PDF Program
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = "C:/ReportExport/" + mainDirectory + "/หนังสือยืนยันการชำระเงิน_" + cls.Deps_no + ".pdf";
            process.Start();
        }
    }
}