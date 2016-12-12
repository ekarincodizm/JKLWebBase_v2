<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment_Schedule_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports.Leasings.Payment_Schedule.Payment_Schedule_Prv" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CTRV_Payment_Schedule" runat="server" AutoDataBind="true" ToolPanelView="None" />
    </div>
    </form>
</body>
</html>
