<%@ Page Title="หน้าแรก" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main_JKL_Form.aspx.cs" Inherits="JKLWebBase_v2.Form_Main.Main_JKL_Form" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            ลิสซิ่ง ( LEASINGS )
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <asp:LinkButton ID="link_Payment_Leasings" runat="server" OnClick="link_Payment_Leasings_Click">
                            <div class="panel panel-success">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-money fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <h3> ชำระค่างวดเช่า - ซื้อ </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </asp:LinkButton>
                </div>

                <div class="col-md-6">
                    <asp:LinkButton ID="link_Search_Leasings" runat="server" OnClick="link_Search_Leasings_Click">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-car fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <h3> ค้นหาสัญญาเช่า - ซื้อ </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </asp:LinkButton>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <asp:HyperLink ID="link_Report_Form_Certified_Leasing_Outline" runat="server" NavigateUrl="/Reports_Leasings/Certified_Leasing/Certified_Leasing_Outline_Prv" Target="_blank">
                            <div class="panel panel-danger">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-file-pdf-o fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <h3>  แบบฟอร์มหนังสือรับรองการเช่า - ซื้อ </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </asp:HyperLink>
                </div>

                <div class="col-md-6">
                    <asp:LinkButton ID="link_Report_Payment_Daily_Leasings" runat="server" OnClick="link_Report_Payment_Daily_Leasings_Click">
                            <div class="panel panel-danger">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-file-pdf-o fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <h3> รายงานสรุปการชำระเงินประจำวัน </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="panel-heading">
            ผู้ติดต่อ ( CONTACT PERSON )
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <asp:LinkButton ID="link_Search_Customers" runat="server" OnClick="link_Search_Customers_Click">
                    <div class="panel panel-warning">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3> ค้นหาข้อมูลผู้ติดต่อ </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    </asp:LinkButton>
                </div>
                <div class="col-md-6">
                    <asp:LinkButton ID="link_Search_Agents" runat="server" OnClick="link_Search_Agents_Click">
                    <div class="panel panel-warning">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3> ค้นหาข้อมูลนายหน้า </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    </asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="panel-heading">
            เงินกู้ ( LOAN )
        </div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-6">
                    <asp:LinkButton ID="LinkButton5" runat="server">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-money fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3> ชำระเงินกู้ </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    </asp:LinkButton>
                </div>

                <div class="col-md-6">
                    <asp:LinkButton ID="LinkButton4" runat="server">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-credit-card fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3>  ค้นหาสัญญาเงินกู้ </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    </asp:LinkButton>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
