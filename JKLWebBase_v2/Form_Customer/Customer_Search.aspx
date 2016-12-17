<%@ Page Title="ค้นหาข้อมูลลูกค้า" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer_Search.aspx.cs" Inherits="JKLWebBase_v2.Form_Customer.Customer_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>ค้นหาข้อมูลลูกค้า </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Label3" runat="server"> รหัสบัตรประชาชน </asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Label4" runat="server"> ชื่อลูกค้า </asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Label5" runat="server"> นามสกุลลูกค้า </asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                </div>
            </div>

            <hr>

        </div>

        <div class="panel-body">
        </div>
    </div>
</asp:Content>
