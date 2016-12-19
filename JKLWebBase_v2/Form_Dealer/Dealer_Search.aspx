<%@ Page Title="ค้นหาข้อมูลนายหน้า" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dealer_Search.aspx.cs" Inherits="JKLWebBase_v2.Form_Dealer.Dealer_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6> ค้นหาข้อมูลนายหน้า </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Dealer_Idcard_Lbl" runat="server"> รหัสบัตรประชาชน </asp:Label>
                    <asp:TextBox ID="Dealer_Idcard_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Dealer_Fname_Lbl" runat="server"> ชื่อ </asp:Label>
                    <asp:TextBox ID="Dealer_Fname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Dealer_Lname_Lbl" runat="server"> นามสกุล </asp:Label>
                    <asp:TextBox ID="Dealer_Lname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Search_Btn_Click"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                </div>
            </div>

            <hr>

        </div>

        <div class="panel-body">
        </div>
    </div>
</asp:Content>
