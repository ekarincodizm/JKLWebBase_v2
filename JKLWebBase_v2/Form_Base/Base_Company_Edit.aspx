<%@ Page Title="แก้ไขข้อมูลสำนักงาน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Company_Edit.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Company_Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>แก้ไขข้อมูลสำนักงาน </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Company_code_Lbl" runat="server"> โค้ดสาขา </asp:Label>
                    <asp:TextBox ID="Company_code_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_N_name_Lbl" runat="server"> ชื่อย่อสาขา </asp:Label>
                    <asp:TextBox ID="Company_N_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Label ID="Company_F_name_Lbl" runat="server"> ชื่อเต็มสาขา </asp:Label>
                    <asp:TextBox ID="Company_F_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Company_tax_id_Lbl" runat="server"> รหัสผู้เสียภาษี </asp:Label>
                    <asp:TextBox ID="Company_tax_id_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_tax_subcode_Lbl" runat="server">รหัสแบ่งสาขา</asp:Label>
                    <asp:TextBox ID="Company_tax_subcode_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_address_no_Lbl" runat="server">ที่อยู่ เลขที่</asp:Label>
                    <asp:TextBox ID="Company_address_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_vilage_Lbl" runat="server">หมู่บ้าน</asp:Label>
                    <asp:TextBox ID="Company_vilage_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_vilage_no_Lbl" runat="server">หมู่ที่</asp:Label>
                    <asp:TextBox ID="Company_vilage_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_alley_Lbl" runat="server">ซอย</asp:Label>
                    <asp:TextBox ID="Company_alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Company_road_Lbl" runat="server">ถนน</asp:Label>
                    <asp:TextBox ID="Company_road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Company_subdistrict_Lbl" runat="server">ตำบล / แขวง</asp:Label>
                    <asp:TextBox ID="Company_subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Company_district_Lbl" runat="server">อำเภอ / เขต</asp:Label>
                    <asp:TextBox ID="Company_district_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Company_province_Lbl" runat="server">จังหวัด</asp:Label>
                    <asp:DropDownList ID="Company_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_contry_Lbl" runat="server">ประเทศ</asp:Label>
                    <asp:TextBox ID="Company_contry_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Company_zipcode_Lbl" runat="server">รหัสไปรษณีย์</asp:Label>
                    <asp:TextBox ID="Company_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Company_tel_Lbl" runat="server">เบอร์์ติดต่อ</asp:Label>
                    <asp:TextBox ID="Company_tel_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-10">
                    <asp:Label ID="Package_Lbl" runat="server"> package </asp:Label>
                    <asp:TextBox ID="Package_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Save_Btn_Click"><i class="fa fa-save fa-fw"></i> บันทึก </asp:LinkButton>
                </div>
                <div class="col-md-2">
                    <asp:LinkButton ID="Back_Btn" runat="server" CssClass="btn btn-sm btn-warning btn-block" OnClick="Back_Btn_Click"><i class="fa fa-arrow-circle-left fa-fw"></i> ย้อนกลับ </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
