<%@ Page Title="แก้ไขข้อมูลนายหน้า" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dealer_Edit.aspx.cs" Inherits="JKLWebBase_v2.Form_Dealer.Dealer_Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Alert MessagesBox -->
    <asp:Panel ID="Alert_Warning_Panel" runat="server" Visible="false">
        <div class="col-md-6 col-md-offset-3">
            <div class="alert alert-warning" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true"><i class="glyphicon glyphicon-remove fa-fw"></i></span>
                </button>
                <div class="modal-header">
                    <h6 class="modal-title"><i class="fa fa-warning fa-fw"></i>!! แจ้งเตือน !! </h6>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="Alert_Id_Card_Lbl" runat="server"> ไม่พบเลขบัตรประชาชน . . . นี้ในระบบข้อมูลนายหน้า </asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="Alert_Success_Panel" runat="server" Visible="false">
        <div class="col-md-6 col-md-offset-3">
            <div class="alert alert-success" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true"><i class="glyphicon glyphicon-remove fa-fw"></i></span>
                </button>
                <div class="modal-header">
                    <h6 class="modal-title"><i class="fa fa-edit fa-fw"></i>++ แก้ไขมข้อมูลสำเร็จ ++ </h6>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="alert_success_Lbl" runat="server"> ระบบได้แก้ไขข้อมูลนายหน้าในฐานข้อมูลเป็นที่เรียบร้อนแล้ว </asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- Alert MessagesBox -->

    <div class="col-lg-12">
        <h4 class="page-header">แก้ไขข้อมูลนายหน้า </h4>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">

                <!-- ข้อมูลนายหน้า -->
                <div class="panel-heading">
                    ข้อมูลนายหน้า
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_idcard_Lbl" runat="server">เลขบัตรประชาชน</asp:Label>
                            <asp:TextBox ID="Dealer_idcard_TBx" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_fname_Lbl" runat="server">ชื่อ</asp:Label>
                            <asp:TextBox ID="Dealer_fname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_lname_Lbl" runat="server">นามสกุล</asp:Label>
                            <asp:TextBox ID="Dealer_lname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_address_no_Lbl" runat="server">ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="Dealer_address_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_vilage_Lbl" runat="server">หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Dealer_vilage_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_vilage_no_Lbl" runat="server">หมู่ที่</asp:Label>
                            <asp:TextBox ID="Dealer_vilage_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_alley_Lbl" runat="server">ซอย</asp:Label>
                            <asp:TextBox ID="Dealer_alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_road_Lbl" runat="server">ถนน</asp:Label>
                            <asp:TextBox ID="Dealer_road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_subdistrict_Lbl" runat="server">ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Dealer_subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_district_Lbl" runat="server">อำเภอ / เขต</asp:Label>
                            <asp:TextBox ID="Dealer_district_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_province_Lbl" runat="server">จังหวัด</asp:Label>
                            <asp:DropDownList ID="Dealer_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_country_Lbl" runat="server">ประเทศ</asp:Label>
                            <asp:TextBox ID="Dealer_country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_zipcode_Lbl" runat="server">รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Dealer_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_status_Lbl" runat="server" >ประเภทนายหน้า</asp:Label>
                            <asp:DropDownList ID="Dealer_status_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลนายหน้า -->

                <hr />

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:LinkButton ID="Dealer_Add_Save_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Dealer_Add_Save_Btn_Click"><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
