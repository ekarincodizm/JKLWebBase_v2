<%@ Page Title="แก้ไขข้อมูลเต็นท์รถ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Tents_Car_Edit.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Tents_Car_Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6> แก้ไขข้อมูลเต็นท์รถ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Tent_name_Lbl" runat="server"> ชื่อเต็นท์รถ </asp:Label>
                    <asp:TextBox ID="Tent_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-5">
                    <asp:Label ID="Tent_local_Lbl" runat="server"> ที่อยู่เต็นท์รถ </asp:Label>
                    <asp:TextBox ID="Tent_local_TBx" runat="server" CssClass="form-control"></asp:TextBox>
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