<%@ Page Title="หนังสือยืนยันการชำระเงิน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm_Payment_Web_Outline.aspx.cs" Inherits="JKLWebBase_v2.Reports_Leasings.Confirm_Payment.Confirm_Payment_Web_Outline" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h4 class="page-header">หนังสือยืนยันการชำระเงิน </h4>
    </div>

    <div class="panel panel-primary">
        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Title_1_Lbl" runat="server">เนื่องด้วย ทางสำนักงานใจกว้าง
                        <asp:RequiredFieldValidator ID="RFV_Company_Name_DDl" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Company_Name_DDl" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-4">
                    <asp:DropDownList ID="Company_Name_DDl" runat="server" CssClass="form-control" OnSelectedIndexChanged="Company_Name_DDl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="form-group col-xs-4">
                    <asp:Label ID="Title_2_Lbl" runat="server"> ได้ชำระเงินด้วยการโอนกรรมสิทธิ์ </asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Car_Lbl" runat="server"> รถ </asp:Label>
                </div>
                <div class=" form-group col-xs-3">
                    <asp:TextBox ID="Car_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Car_Brand_Lbl" runat="server"> ยี่ห้อ </asp:Label>
                </div>
                <div class="form-group col-xs-3">
                    <asp:TextBox ID="Car_Brand_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-2">
                    <asp:Label ID="Car_Plate_Lbl" runat="server"> หมายเลขทะเบียน </asp:Label>
                </div>
                <div class="form-group col-xs-2">
                    <asp:TextBox ID="Car_Plate_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Car_Engine_Lbl" runat="server"> หมายเลขเครื่องยนต์ </asp:Label>
                </div>
                <div class="form-group col-xs-3">
                    <asp:TextBox ID="Car_Engine_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-2">
                    <asp:Label ID="Car_Chassis_Lbl" runat="server"> หมายเลขตัวรถ </asp:Label>
                </div>
                <div class="form-group col-xs-3">
                    <asp:TextBox ID="Car_Chassis_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Payment_To_Lbl" runat="server">ให้กับ
                        <asp:RequiredFieldValidator ID="RFV_Payment_To_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Payment_To_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-3">

                    <asp:TextBox ID="Payment_To_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-2">
                    <asp:Label ID="Payment_Amount_Lbl" runat="server">เป็นจำนวนเงิน
                        <asp:RequiredFieldValidator ID="RFV_Payment_Amount_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Payment_Amount_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="col-xs-3">

                    <div class="form-group input-group">
                        <asp:TextBox ID="Payment_Amount_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Address_Lbl" runat="server"> ที่อยู่สำนักงาน </asp:Label>
                </div>
                <div class="form-group col-xs-10">
                    <asp:TextBox ID="Bottom_Address_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-2">
                    <asp:LinkButton ID="Export_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Export_Btn_Click" ValidationGroup="Save_Validation" CausesValidation="true"><i class="fa fa-print fa-fw"></i> พิมพ์ </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
