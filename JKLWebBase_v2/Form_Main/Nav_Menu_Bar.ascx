<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav_Menu_Bar.ascx.cs" Inherits="JKLWebBase_v2.Form_Main.Nav_Menu_Bar" %>

<nav class="navbar navbar-default navbar-static-top">

    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <asp:LinkButton ID="link_Menu_Home" runat="server" CssClass="navbar-brand" OnClick="link_Menu_Home_Click"> <i class="fa fa-home fa-fw"></i> หน้าแรก </asp:LinkButton>
    </div>

    <ul class="nav navbar-top-links navbar-left">
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="~/">
                <i class="fa fa-group fa-fw"></i>ผู้ติดต่อ <i class="fa fa-caret-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li>
                    <asp:LinkButton ID="link_Menu_Search_Customer" runat="server" OnClick="link_Menu_Search_Customer_Click"> <i class="fa fa-search fa-fw"></i> ค้นหาข้อมูลผู้ติดต่อ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="link_Menu_Add_Customer" runat="server" OnClick="link_Menu_Add_Customer_Click"> <i class="fa fa-user fa-fw"></i> เพิ่มข้อมูลผู้ติดต่อ </asp:LinkButton>
                </li>
                <li class="divider"></li>
                <li>
                    <asp:LinkButton ID="link_Menu_Search_Agent" runat="server" OnClick="link_Menu_Search_Agent_Click"> <i class="fa fa-search fa-fw"></i> ค้นหาข้อมูลนายหน้า </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="link_Menu_Add_Agent" runat="server" OnClick="link_Menu_Add_Agent_Click"> <i class="fa fa-user fa-fw"></i> เพิ่มข้อมูลนายหน้า </asp:LinkButton>
                </li>
            </ul>
        </li>
    </ul>

    <ul class="nav navbar-top-links navbar-left">
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="~/">
                <i class="fa fa-book fa-fw"></i>สัญญาเช่า-ซื้อ  <i class="fa fa-caret-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li>
                    <asp:LinkButton ID="link_Menu_Pyament_Leasing" runat="server" OnClick="link_Menu_Pyament_Leasing_Click"> <i class="fa fa-money fa-fw"></i> ชำระค่างวดเช่า - ซื้อ  </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="link_Menu_Leasing_Search" runat="server" OnClick="link_Menu_Leasing_Search_Click"> <i class="fa fa-search fa-fw"></i> ค้นหาสัญญาเช่า-ซื้อ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="link_Menu_Leasing_Add" runat="server" OnClick="link_Menu_Leasing_Add_Click"> <i class="fa fa-book fa-fw"></i> เพิ่มสัญญาเช่า-ซื้อ </asp:LinkButton>
                </li>
            </ul>
        </li>
    </ul>

    <asp:Panel ID="Leasing_Report_Panel" runat="server">
        <ul class="nav navbar-top-links navbar-left">
            <li class="dropdown">
                <a class="dropdown-toggle" data-toggle="dropdown" href="~/">
                    <i class="fa fa-file-text fa-fw"></i>รายงานลิสซิ่ง  <i class="fa fa-caret-down"></i>
                </a>
                <ul class="dropdown-menu dropdown-user">
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_daily_payment" runat="server" OnClick="link_report_leainsg_daily_payment_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำวัน </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_monthly_payment" runat="server" OnClick="link_report_leainsg_monthly_payment_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำเดือน </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_yearly_payment" runat="server" OnClick="link_report_leainsg_yearly_payment_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำปี </asp:LinkButton>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_lost_payment" runat="server" OnClick="link_report_leainsg_lost_payment_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานขาดชำระ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_intensive" runat="server" OnClick="link_report_leainsg_intensive_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานขาดชำระเร่งรัด </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_alert_payment" runat="server" OnClick="link_report_leainsg_alert_payment_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานแจ้งเตือนชำระค่างวด </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_alert_payment_guarantor" runat="server" OnClick="link_report_leainsg_alert_payment_guarantor_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานแจ้งเตือนชำระค่างวด (ผู้ค้ำ) </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_report_leainsg_payment_left" runat="server" OnClick="link_report_leainsg_payment_left_Click"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานลูกหนี้คงเหลือ </asp:LinkButton>
                    </li>
                </ul>
            </li>
        </ul>
    </asp:Panel>

    <ul class="nav navbar-top-links navbar-right">
        <li>
            <asp:LinkButton ID="link_Logout" runat="server" CssClass="logout" OnClick="link_Logout_Click"> <i class="fa fa-sign-out fa-fw"></i> Logout </asp:LinkButton>
        </li>
    </ul>

    <asp:Panel ID="Account_Panel" runat="server">
        <ul class="nav navbar-top-links navbar-right">
            <li class="dropdown">
                <a class="dropdown-toggle" data-toggle="dropdown" href="~/">
                    <i class="fa fa-cogs fa-fw"></i>จัดการระบบ  <i class="fa fa-caret-down"></i>
                </a>
                <ul class="dropdown-menu dropdown-user">
                    <li>
                        <asp:LinkButton ID="link_Company_Management" runat="server" OnClick="link_Company_Management_Click"> <i class="fa fa-sitemap fa-fw"></i> จัดการ สาขา </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_zone_management" runat="server" OnClick="link_zone_management_Click"> <i class="fa fa-phone-square fa-fw"></i> จัดการ เขตบริการ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_brand_management" runat="server" OnClick="link_brand_management_Click"> <i class="fa fa-car fa-fw"></i> จัดการ ยี่ห้อรถ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_court_management" runat="server" OnClick="link_court_management_Click"> <i class="fa fa-legal fa-fw"></i> จัดการ ศาล </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_leasing_code_management" runat="server" OnClick="link_leasing_code_management_Click"> <i class="fa fa-barcode fa-fw"></i> จัดการ รหัสลิสซิ่ง </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_nationality_management" runat="server" OnClick="link_nationality_management_Click"> <i class="fa fa-flag fa-fw"></i> จัดการ สัญชาติ</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_origin_management" runat="server" OnClick="link_origin_management_Click"> <i class="fa fa-flag-o fa-fw"></i> จัดการ เชื้อชาติ</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_length_payment_management" runat="server" OnClick="link_length_payment_management_Click"> <i class="fa fa-calendar fa-fw"></i> จัดการ ระยะเวลาการชำระ</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_tents_management" runat="server" OnClick="link_tents_management_Click"> <i class="fa fa-truck fa-fw"></i> จัดการ เต้นรถ </asp:LinkButton>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <asp:LinkButton ID="link_search_account" runat="server" OnClick="link_search_account_Click"> <i class="fa fa-users fa-fw"></i> <i class="fa fa-search fa-fw"></i>  ค้นหาผู้ใช้งานระบบ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_add_account" runat="server" OnClick="link_add_account_Click"> <i class="fa fa-users fa-fw"></i> <i class="fa fa-plus-circle fa-fw"></i> เพิ่มผู้ใช้งานระบบ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_list_logs" runat="server" OnClick="link_list_logs_Click"> <i class="fa fa-list-alt fa-fw"></i>  ข้อมูลการใช้งานระบบ </asp:LinkButton>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <asp:LinkButton ID="link_load_leasing" runat="server" OnClick="link_load_leasing_Click"> <i class="fa fa-database fa-fw"></i> โหลดข้อมูลลิสซิ่งจาก DB MSSQL TO DB MySQL </asp:LinkButton>
                    </li>
                </ul>
            </li>
        </ul>
    </asp:Panel>

</nav>
