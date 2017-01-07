using System;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;


namespace JKLWebBase_v2.Reports.Leasings.Front_Card
{
    public partial class Front_Card_Prv : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Front_Card rprt = new Front_Card();
            CTRV_Front_Card.ReportSource = rprt;
            printReport(rprt);
        }

        public void printReport(ReportDocument report)
        {
            MemoryStream oStream = new MemoryStream();
            report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(oStream.ToArray());
            Response.End();
        }
    }
}