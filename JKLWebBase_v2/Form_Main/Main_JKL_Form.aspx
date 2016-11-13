<%@ Page Title="หน้าแรก" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main_JKL_Form.aspx.cs" Inherits="JKLWebBase_v2.Form_Main.Main_JKL_Form" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1> <strong> หน้าหลัก </strong> </h1>
        <div class="row">
            <div class="col-lg-4">
                <asp:LinkButton ID="link_1" runat="server">
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
                <asp:LinkButton ID="LinkButton1" runat="server">
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
            <div class="col-lg-4">
                <asp:LinkButton ID="LinkButton2" runat="server">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-book fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <h3> <strong> ค้นหาสัญญาเช่า - ซื้อ </strong> </h3>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>