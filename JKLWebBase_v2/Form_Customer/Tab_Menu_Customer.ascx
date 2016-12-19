<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tab_Menu_Customer.ascx.cs" Inherits="JKLWebBase_v2.Form_Customer.Tab_Menu_Customer" %>

<%
    int act = 1;
    if (Session["Class_Active_Customer"] != null)
    {
        act = Convert.ToInt32(Session["Class_Active_Customer"].ToString());
    }
%>

<ul class="nav nav-tabs">
    <li role="presentation" <%= act == 1  ? "class='active'" : "" %>>
        <asp:LinkButton ID="link_Customer_Add" runat="server" OnClick="link_Customer_Add_Click"> <i class="fa fa-male fa-fw"></i> ข้อมูลผู้ติดต่อ </asp:LinkButton>
    </li>
    <li role="presentation" <%= act == 2 ? "class='active'" : "" %>>
        <asp:LinkButton ID="link_Customer_Home_Photo" runat="server" OnClick="link_Customer_Home_Photo_Click"> <i class="fa fa-home fa-fw"></i> รูปบ้าน </asp:LinkButton>
    </li>
</ul>