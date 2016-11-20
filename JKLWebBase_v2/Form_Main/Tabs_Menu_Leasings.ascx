<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tabs_Menu_Leasings.ascx.cs" Inherits="JKLWebBase_v2.Form_Main.Tabs_Menu_Leasings" %>

<%
    int act = 0;
    if(Session["Class_Active"] != null)
    {
        act = Convert.ToInt32(Session["Class_Active"].ToString());
    }
%>

<ul class="nav nav-tabs">
    <li role="presentation" <%= act == 1  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Customer_Add" runat="server"  OnClick="link_Customer_Add_Click"><i class="fa fa-male fa-fw"></i> ผู้ทำสัญญา </asp:LinkButton></li>
    <li role="presentation" <%= act == 2  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Leasing_Add" runat="server" OnClick="link_Leasing_Add_Click"><i class="fa fa-book fa-fw"></i> สัญญาเช่า - ซื้อ </asp:LinkButton></li>
    <li role="presentation" <%= act == 3  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Dealers_Add" runat="server" OnClick="link_Dealers_Add_Click"><i class="fa fa-male fa-fw"></i> นายหน้า </asp:LinkButton></li>
    <li role="presentation" <%= act == 4  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_1" runat="server" OnClick="link_Add_Bondsman_1_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 1 </asp:LinkButton></li>
    <li role="presentation" <%= act == 5  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_2" runat="server" OnClick="link_Add_Bondsman_2_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 2 </asp:LinkButton></li>
    <li role="presentation" <%= act == 6  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_3" runat="server" OnClick="link_Add_Bondsman_3_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 3 </asp:LinkButton></li>
    <li role="presentation" <%= act == 7  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_4" runat="server" OnClick="link_Add_Bondsman_4_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 4 </asp:LinkButton></li>
    <li role="presentation" <%= act == 8  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_5" runat="server" OnClick="link_Add_Bondsman_5_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 5 </asp:LinkButton></li>
    <li role="presentation" <%= act == 9  ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Car_Img" runat="server" OnClick="link_Add_Car_Img_Click"><i class="fa fa-car fa-fw"></i>รูปรถ </asp:LinkButton></li>
    <li role="presentation" <%= act == 10 ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Home_Img" runat="server" OnClick="link_Add_Home_Img_Click"><i class="fa fa-home fa-fw"></i> รูปบ้าน </asp:LinkButton></li>
    <li role="presentation" <%= act == 11 ? "class='active'" : "" %> ><asp:LinkButton ID="link_List_Payment_Schedule" runat="server" OnClick="link_List_Payment_Schedule_Click"><i class="fa fa-table fa-fw"></i> ตารางการผ่อนชำระ </asp:LinkButton></li>
</ul>