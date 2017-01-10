<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certified_Leasing.aspx.cs" Inherits="JKLWebBase_v2.Reports.Leasings.Certified_Leasing.Certified_Leasing" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CRV_Display_Report" runat="server" AutoDataBind="true" />
    </div>
    </form>
</body>
</html>
