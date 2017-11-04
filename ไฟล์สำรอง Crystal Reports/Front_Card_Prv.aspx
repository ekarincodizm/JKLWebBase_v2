<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front_Card_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports_Leasings.Front_Card.Front_Card_Prv" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <CR:CrystalReportViewer ID="CRV_Front_Card" runat="server" AutoDataBind="True" GroupTreeStyle-ShowLines="False" ToolPanelView="None" Width="100%" PageZoomFactor="125" />
    </form>
</body>
</html>
