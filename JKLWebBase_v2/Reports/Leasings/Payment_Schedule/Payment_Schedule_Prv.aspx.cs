using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Web.UI;
using System.Data;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Leasings;
using System.Web;
using Microsoft.Reporting.WebForms;

namespace JKLWebBase_v2.Reports.Leasings.Payment_Schedule
{
    public partial class Payment_Schedule_Prv : Page
    {
        Car_Leasings cls = new Car_Leasings();
        private string error;

        protected void Page_Load(object sender, EventArgs e)
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

                printReport(rpt);

                //ExportReport(rpt);
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Payment_Schedule_Prv --> Page_Load() : " + ex.Message.ToString();
                Log_Error._writeErrorFile(error);
            }
            catch (Exception ex)
            {
                error = "Exception ==> Payment_Schedule_Prv --> Page_Load() : " + ex.Message.ToString();
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

            File.OpenText("C:/ReportExport/" + mainDirectory + "/Payment_Schedule_" + cls.Deps_no + ".pdf");
        }
    }
}