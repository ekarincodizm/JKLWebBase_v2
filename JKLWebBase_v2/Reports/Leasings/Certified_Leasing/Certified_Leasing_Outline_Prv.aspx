<%@ Page Title="แบบฟอร์มหนังสือรับรองการเช่า - ซื้อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Certified_Leasing_Outline_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports.Leasings.Certified_Leasing.Certified_Leasing_Outline_Prv" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Confirm_Form_panel" runat="server">
        <div class="panel panel-primary">
            <div class="panel-body">
                <div class="row">
                    <div class="form-group col-xs-6">
                        <div class="form-group input-group">
                            <asp:Label ID="Company_Name_Lbl" runat="server" CssClass="input-group-addon"> ชื่อสำนักงาน </asp:Label>
                            <asp:DropDownList ID="Company_Name_DDl" runat="server" CssClass="form-control" OnSelectedIndexChanged="Company_Name_DDl_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-xs-6">
                        <div class="form-group input-group">
                            <asp:Label ID="Company_Address_Lbl" runat="server" CssClass="input-group-addon"> ที่อยู่สำนักงานใหญ่ </asp:Label>
                            <asp:TextBox ID="Company_Address_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-xs-6">
                        <div class="form-group input-group">
                            <asp:Label ID="SubCompany_Address_1_Lbl" runat="server" CssClass="input-group-addon"> ที่อยู่สาขาย่อย 1  </asp:Label>
                            <asp:TextBox ID="SubCompany_Address_1_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-xs-6">
                        <div class="form-group input-group">
                            <asp:Label ID="SubCompany_Address_2_Lbl" runat="server" CssClass="input-group-addon"> ที่อยู่สาขาย่อย 2   </asp:Label>
                            <asp:TextBox ID="SubCompany_Address_2_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-xs-6">
                        <div class="form-group input-group">
                            <asp:Label ID="SubCompany_Address_3_Lbl" runat="server" CssClass="input-group-addon"> ที่อยู่สาขาย่อย 3   </asp:Label>
                            <asp:TextBox ID="SubCompany_Address_3_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2">
                        <asp:LinkButton ID="Export_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Export_Btn_Click"><i class="fa fa-print fa-fw"></i> พิมพ์แบบฟอร์ม </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

