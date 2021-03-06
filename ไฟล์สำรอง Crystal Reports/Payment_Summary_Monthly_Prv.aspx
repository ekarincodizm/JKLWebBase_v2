﻿<%@ Page Title="รายงานสรุปชำระเงินประจำเดือน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment_Summary_Monthly_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports_Leasings.Payment_Summary_Monthly.Payment_Summary_Monthly_Prv" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>รายงานสรุปชำระเงินประจำเดือน </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3">
                    <asp:Label ID="Month_Lbl" runat="server">เดือน</asp:Label>
                    <asp:DropDownList ID="Month_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-3">
                    <asp:Label ID="Year_Lbl" runat="server">ปี</asp:Label>
                    <asp:DropDownList ID="Year_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <asp:Panel ID="Comapnys_Panel" runat="server" Visible="false">
                <div class="row">
                    <div class="form-group col-xs-12">
                        <asp:Label ID="Label1" runat="server" CssClass="checkbox">สาขา
                        <asp:CheckBox ID="Company_ChkBxL_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Company_ChkBxL_All_CheckedChanged" AutoPostBack="true" />
                        </asp:Label>
                        <asp:CheckBoxList ID="Company_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="9">
                        </asp:CheckBoxList>
                    </div>
                </div>
            </asp:Panel>

            <div class="row">
                <div class="col-md-3">
                    <asp:LinkButton ID="Export_Reported_mod_I_Btn" runat="server" CssClass="btn btn-sm btn-success btn-block" OnClick="Export_Reported_mod_I_Click"><i class="fa fa-print fa-fw"></i> ออกรายงานการชำระเงิน 1 </asp:LinkButton>
                </div>
                <div class="col-md-3">
                    <asp:LinkButton ID="Export_Reported_mod_II_Btn" runat="server" CssClass="btn btn-sm btn-success btn-block" OnClick="Export_Reported_mod_II_Click"><i class="fa fa-print fa-fw"></i> ออกรายงานการชำระเงิน 2 </asp:LinkButton>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
