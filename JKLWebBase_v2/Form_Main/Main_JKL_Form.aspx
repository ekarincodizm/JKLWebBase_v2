<%@ Page Title="หน้าแรก" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main_JKL_Form.aspx.cs" Inherits="JKLWebBase_v2.Form_Main.Main_JKL_Form" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            ลิสซิ่ง ( LEASINGS )
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-4">
                    <asp:LinkButton ID="link_Payment_Leasings" runat="server" OnClick="link_Payment_Leasings_Click">
                            <div class="panel panel-success">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-money fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <h3> <strong> ชำระค่างวดเช่า - ซื้อ </strong> </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </asp:LinkButton>
                </div>

                <div class="col-lg-4">
                    <asp:LinkButton ID="link_Search_Leasings" runat="server" OnClick="link_Search_Leasings_Click">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-car fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <h3> <strong> ค้นหาสัญญาเช่า - ซื้อ </strong> </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </asp:LinkButton>
                </div>

                <div class="col-lg-4">
                    <asp:LinkButton ID="LinkButton3" runat="server">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-file-pdf-o fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <h3> <strong> รายงานสรุปการชำระเงินประจำวัน </strong> </h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="panel-heading">
            ลูกค้า ( CUSTOMERS )
        </div>
        <div class="panel-body">

            <div class="row">
                <div class="col-lg-4">
                    <asp:LinkButton ID="link_Search_Customers_Leasings" runat="server" OnClick="link_Search_Customers_Leasings_Click">
                    <div class="panel panel-warning">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3> <strong> ค้นหาข้อมูลลูกค้า </strong> </h3>
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
                <div class="col-lg-4">
                    <asp:LinkButton ID="LinkButton5" runat="server">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-money fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3> <strong> ชำระเงินกู้ </strong> </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    </asp:LinkButton>
                </div>

                <div class="col-lg-4">
                    <asp:LinkButton ID="LinkButton4" runat="server">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-credit-card fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3> <strong> ค้นหาสัญญาเงินกู้ </strong> </h3>
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
