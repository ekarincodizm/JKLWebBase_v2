<%@ Page Title="เพิ่มข้อมูลผู้ใช้งาน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account_Add.aspx.cs" Inherits="JKLWebBase_v2.Form_Account.Account_Add" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">


                <div class="panel-heading">
                    <h6>เพิ่มข้อมูลผู้ใช้งาน</h6>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="username_Lbl" runat="server">ชื่อผู้ใช้งาน
                                <asp:RequiredFieldValidator ID="RFV_username_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="username_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="username_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="password_Lbl" runat="server">รหัสผ่าน
                                <asp:RequiredFieldValidator ID="RFV_password_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="password_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="password_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Account_Idcard_Lbl" runat="server"> รหัสบัตรประชาชน </asp:Label>
                            <asp:TextBox ID="Account_Idcard_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-4">
                            <asp:Label ID="Account_F_name_Lbl" runat="server"> ชื่อ - นามสกุล  </asp:Label>
                            <asp:TextBox ID="Account_F_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Account_N_Name_Lbl" runat="server"> ชื่อเล่น </asp:Label>
                            <asp:TextBox ID="Account_N_Name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-4">
                            <asp:Label ID="Account_Email_Lbl" runat="server">อีเมล์</asp:Label>
                            <asp:TextBox ID="Account_Email_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:Label ID="Account_Address_pri_Lbl" runat="server">ที่อยู่</asp:Label>
                            <asp:TextBox ID="Account_Address_pri_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Account_Tel_Lbl" runat="server">เบอร์โทรศัพท์</asp:Label>
                            <asp:TextBox ID="Account_Tel_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <asp:Label ID="level_Lbl" runat="server">สิทธิ์การเข้าใช้งาน</asp:Label>
                            <asp:DropDownList ID="level_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <asp:Label ID="Company_Lbl" runat="server">สำนักงาน</asp:Label>
                            <asp:DropDownList ID="Company_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <hr />

                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-2">
                            <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Save_Btn_Click" ValidationGroup="Save_Validation" CausesValidation="true"><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
