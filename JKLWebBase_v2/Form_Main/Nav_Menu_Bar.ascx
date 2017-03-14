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
                <li class="divider"></li>
                <li>
                    <asp:LinkButton ID="link_Menu_Deposit_Search" runat="server" OnClick="link_Menu_Deposit_Search_Click"> <i class="fa fa-search fa-fw"></i> ค้นหาสัญญาฝาก </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="link_Menu_Deposit_Add" runat="server" OnClick="link_Menu_Deposit_Add_Click"> <i class="fa fa-tag fa-fw"></i> เพิ่มสัญญาฝาก </asp:LinkButton>
                </li>
                <li class="divider"></li>
                <li>
                    <asp:LinkButton ID="link_Menu_Leasing_Search" runat="server" OnClick="link_Menu_Leasing_Search_Click"> <i class="fa fa-search fa-fw"></i> ค้นหาสัญญาเช่า-ซื้อ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="link_Menu_Leasing_Add" runat="server" OnClick="link_Menu_Leasing_Add_Click"> <i class="fa fa-book fa-fw"></i> เพิ่มสัญญาเช่า-ซื้อ </asp:LinkButton>
                </li>
            </ul>
        </li>
    </ul>
    <ul class="nav navbar-top-links navbar-left">
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="~/">
                <i class="fa fa-file-text fa-fw"></i>รายงานลิสซิ่ง  <i class="fa fa-caret-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำวัน </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton9" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำเดือน </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton10" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำปี </asp:LinkButton>
                </li>
                <li class="divider"></li>
                <li>
                    <asp:LinkButton ID="LinkButton11" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานแจ้งเตือนชำระค่างวด </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton12" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานแจ้งเตือนชำระค่างวด (ผู้ค้ำ) </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton13" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานค้างชำระ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton14" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานขาดชำระ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton15" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานเร่งรัด </asp:LinkButton>
                </li>
            </ul>
        </li>
    </ul>
    <ul class="nav navbar-top-links navbar-left">
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="~/">
                <i class="fa fa-credit-card fa-fw"></i>สัญญาเงินกู้  <i class="fa fa-caret-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li>
                    <asp:LinkButton ID="LinkButton16" runat="server"> <i class="fa fa-search fa-fw"></i> ค้นหาสัญญาเงินกู้ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton8" runat="server"> <i class="fa fa-credit-card fa-fw"></i> เพิ่มสัญญาเงินกู้ </asp:LinkButton>
                </li>
            </ul>
        </li>
    </ul>
    <ul class="nav navbar-top-links navbar-left">
        <li class="dropdown">
            <a class="dropdown-toggle" data-toggle="dropdown" href="~/">
                <i class="fa fa-file-text fa-fw"></i>รายงานเงินกู้  <i class="fa fa-caret-down"></i>
            </a>
            <ul class="dropdown-menu dropdown-user">
                <li>
                    <asp:LinkButton ID="LinkButton2" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำวัน </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton17" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำเดือน </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton18" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานสรุปชำระเงินประจำปี </asp:LinkButton>
                </li>
                <li class="divider"></li>
                <li>
                    <asp:LinkButton ID="LinkButton19" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานแจ้งเตือนชำระค่างวด </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton20" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานแจ้งเตือนชำระค่างวด (ผู้ค้ำ) </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton21" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานค้างชำระ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton22" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานขาดชำระ </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton23" runat="server"> <i class="fa fa-file-pdf-o fa-fw"></i> รายงานเร่งรัด </asp:LinkButton>
                </li>
            </ul>
        </li>
    </ul>

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
                        <asp:LinkButton ID="LinkButton7" runat="server"> <i class="fa fa-sitemap fa-fw"></i> จัดการ สาขา </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton28" runat="server"> <i class="fa fa-phone-square fa-fw"></i> จัดการ เขตบริการ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton25" runat="server"> <i class="fa fa-car fa-fw"></i> จัดการ ยี่ห้อรถ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton24" runat="server"> <i class="fa fa-legal fa-fw"></i> จัดการ ศาล </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton26" runat="server"> <i class="fa fa-barcode fa-fw"></i> จัดการ รหัสลิสซิ่ง </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton27" runat="server"> <i class="fa fa-language fa-fw"></i> จัดการ สัญชาติ และ เชื้อชาติ</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton29" runat="server"> <i class="fa fa-calendar fa-fw"></i> จัดการ ระยะเวลาการชำระ</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton31" runat="server"> <i class="fa fa-info-circle fa-fw"></i> จัดการ สถานะลิ่สซิ่ง</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton30" runat="server"> <i class="fa fa-truck fa-fw"></i> จัดการ เต้นรถ </asp:LinkButton>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <asp:LinkButton ID="LinkButton3" runat="server"> <i class="fa fa-users fa-fw"></i> <i class="fa fa-search fa-fw"></i>  ค้นหาผู้ใช้งานระบบ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton4" runat="server"> <i class="fa fa-users fa-fw"></i> <i class="fa fa-plus-circle fa-fw"></i> เพิ่มผู้ใช้งานระบบ </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton5" runat="server"> <i class="fa fa-users fa-fw"></i> <i class="fa fa-list-ul fa-fw"></i> แสดงสถานะผู้ใช้งาน </asp:LinkButton>
                    </li>
                    <li class="divider"></li>
                    <li>
                        <asp:LinkButton ID="LinkButton6" runat="server"> <i class="fa fa-database fa-fw"></i> โหลดข้อมูลจาก DB MSSQL TO MySQL </asp:LinkButton>
                    </li>
                </ul>
            </li>
        </ul>
        
    </asp:Panel>

</nav>
