<%@ Page Title="แก้ไขข้อมูลสัญชาติ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Nationalitys_Edit.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Nationalitys_Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6> แก้ไขข้อมูลสัญชาติ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Nationality_name_ENG_Lbl" runat="server"> ชื่อสัญชาติภาษาอังกฤษ </asp:Label>
                    <asp:TextBox ID="Nationality_name_ENG_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Nationality_name_TH_Lbl" runat="server"> ชื่อสัญชาติภาษาไทย </asp:Label>
                    <asp:TextBox ID="Nationality_name_TH_TBx" runat="server" CssClass="form-control"></asp:TextBox>
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

