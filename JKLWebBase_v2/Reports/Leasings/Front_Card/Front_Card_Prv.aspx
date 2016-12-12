<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front_Card_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports.Leasings.Front_Card.Front_Card_Prv" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CTRV_Front_Card" runat="server" AutoDataBind="true" ToolPanelView="None" />
    
    </div>
    </form>
</body>
</html>
