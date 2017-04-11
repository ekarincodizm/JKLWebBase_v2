<%@ Page Title="รายงานลูกหนี้คงเหลือ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Total_Balance_Payment_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports_Leasings.Total_Balance_Payment.Total_Balance_Payment_Prv" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6> รายงานลูกหนี้คงเหลือ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Leasing_Code_Lbl" runat="server" CssClass="checkbox">รหัสสัญญา
                        <asp:CheckBox ID="Leasing_Code_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Leasing_Code_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Leasing_Code_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="9">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Company_Lbl" runat="server" CssClass="checkbox">สาขา
                        <asp:CheckBox ID="Company_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Company_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Company_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="10">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Zone_Lbl" runat="server" CssClass="checkbox">เขตบริการ
                        <asp:CheckBox ID="Zone_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Zone_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Zone_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="9">
                    </asp:CheckBoxList>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:LinkButton ID="Export_Reported_Btn" runat="server" CssClass="btn btn-sm btn-success btn-block" OnClick="Export_Reported_Btn_Click"><i class="fa fa-print fa-fw"></i> ออกรายงาน </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
