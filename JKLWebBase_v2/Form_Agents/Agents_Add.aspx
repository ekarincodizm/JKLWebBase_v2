<%@ Page Title="เพิ่มข้อมูลนายหน้า" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agents_Add.aspx.cs" Inherits="JKLWebBase_v2.Form_Agents.Agents_Add" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Alert MessagesBox -->
    <div class="row">
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
                        <h6 class="modal-title"><i class="fa fa-thumbs-o-up fa-fw"></i>++ เพิ่มข้อมูลสำเร็จ ++ </h6>
                    </div>
                    <div class="modal-body">
                        <p>
                            <asp:Label ID="alert_success_Lbl" runat="server"> ระบบได้เพิ่มข้อมูลนายหน้าลงในฐานข้อมูลเป็นที่เรียบร้อนแล้ว </asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="Alert_Danger_Panel" runat="server" Visible="false">
            <div class="col-md-6 col-md-offset-3">
                <div class="alert alert-danger" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="glyphicon glyphicon-remove fa-fw"></i></span>
                    </button>
                    <div class="modal-header">
                        <h6 class="modal-title"><i class="fa fa-warning fa-fw"></i>
                            <asp:Label ID="alert_header_danger_Lbl" runat="server"> </asp:Label>
                        </h6>
                    </div>
                    <div class="modal-body">
                        <p>
                            <asp:Label ID="alert_danger_Lbl" runat="server"> </asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <!-- Alert MessagesBox -->

    <div class="col-lg-12">
        <h4 class="page-header">เพิ่มข้อมูลนายหน้า </h4>
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
                        <div class="form-group col-xs-4">
                            <asp:Label ID="Agent_idcard_Lbl" runat="server">เลขบัตรประชาชน
                                <asp:RequiredFieldValidator ID="RFV_Agent_idcard_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Agent_idcard_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Agent_idcard_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:LinkButton ID="Agent_search_Btn" runat="server" CssClass="input-group-addon search" OnClick="Agent_search_Btn_Click"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Agent_fname_Lbl" runat="server">ชื่อ
                                <asp:RequiredFieldValidator ID="RFV_Agent_fname_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Agent_fname_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Agent_fname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Agent_lname_Lbl" runat="server">นามสกุล
                                <asp:RequiredFieldValidator ID="RFV_Agent_lname_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Agent_lname_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Agent_lname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Agent_address_no_Lbl" runat="server">ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="Agent_address_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Agent_vilage_Lbl" runat="server">หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Agent_vilage_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Agent_vilage_no_Lbl" runat="server">หมู่ที่</asp:Label>
                            <asp:TextBox ID="Agent_vilage_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Agent_alley_Lbl" runat="server">ซอย</asp:Label>
                            <asp:TextBox ID="Agent_alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Agent_road_Lbl" runat="server">ถนน</asp:Label>
                            <asp:TextBox ID="Agent_road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Agent_subdistrict_Lbl" runat="server">ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Agent_subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Agent_district_Lbl" runat="server">อำเภอ / เขต</asp:Label>
                            <asp:TextBox ID="Agent_district_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_province_Lbl" runat="server">จังหวัด</asp:Label>
                            <asp:DropDownList ID="Agent_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_country_Lbl" runat="server">ประเทศ</asp:Label>
                            <asp:TextBox ID="Agent_country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_zipcode_Lbl" runat="server">รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Agent_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_status_Lbl" runat="server">ประเภทนายหน้า</asp:Label>
                            <asp:DropDownList ID="Agent_status_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลนายหน้า -->

                <hr />

                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-2">
                            <asp:LinkButton ID="Agent_Add_Save_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Agent_Add_Save_Btn_Click" ValidationGroup="Save_Validation" CausesValidation="true"><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
