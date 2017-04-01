<%@ Page Title="เพิ่มข้อมูลนายหน้า" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Add_Agent.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Add_Agent" %>

<%@ Register TagPrefix="nav_menu" TagName="Tab_Menu" Src="Tabs_Menu_Leasings.ascx" %>

<%@ Register TagPrefix="print_menu_leasing" TagName="Print_Menu" Src="Print_Menu_Leasing.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Print Menu Button -->
    <print_menu_leasing:Print_Menu ID="Print_Menu1" runat="server" />

    <!-- ./Print Menu Button -->

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
    <!-- Alert MessagesBox -->

    <div class="col-lg-12">
        <h4 class="page-header">เพิ่มข้อมูลนายหน้า </h4>
    </div>

    <!-- Tab MenuBar -->
    <nav_menu:Tab_Menu ID="nav_tabs" runat="server" />

    <!-- ./Tab MenuBar -->

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
                            <asp:Label ID="Agent_idcard_Lbl" runat="server">เลขบัตรประชาชน</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Agent_idcard_TBx" runat="server" CssClass="form-control" OnTextChanged="Agent_idcard_TBx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:LinkButton ID="Agent_search_Btn" runat="server" CssClass="input-group-addon search" OnClick="Agent_search_Btn_Click"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_fname_Lbl" runat="server">ชื่อ</asp:Label>
                            <asp:TextBox ID="Agent_fname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_lname_Lbl" runat="server">นามสกุล</asp:Label>
                            <asp:TextBox ID="Agent_lname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Agent_address_no_Lbl" runat="server">ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="Agent_address_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Agent_vilage_Lbl" runat="server">หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Agent_vilage_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Agent_vilage_no_Lbl" runat="server">หมู่ที่</asp:Label>
                            <asp:TextBox ID="Agent_vilage_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Agent_alley_Lbl" runat="server">ซอย</asp:Label>
                            <asp:TextBox ID="Agent_alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_road_Lbl" runat="server">ถนน</asp:Label>
                            <asp:TextBox ID="Agent_road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Agent_subdistrict_Lbl" runat="server">ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Agent_subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
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
                        <div class="col-xs-1">
                            <asp:Label ID="Agent_zipcode_Lbl" runat="server">รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Agent_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Agent_status_Lbl" runat="server">ประเภทนายหน้า</asp:Label>
                            <asp:DropDownList ID="Agent_status_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_commission_Lbl" runat="server">ค่านายหน้า</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Agent_commission_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_percen_Lbl" runat="server"> % หัก ณ ที่จ่าย</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Agent_percen_TBx" runat="server" CssClass="form-control" TextMode="Number" OnTextChanged="Agent_percen_TBx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <span class="input-group-addon">%</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_cash_Lbl" runat="server">ค่าหัก ณ ที่จ่าย</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Agent_cash_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_net_com_Lbl" runat="server">ค่านายหน้าสุทธิ</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Agent_net_com_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Agent_bookcode_Lbl" runat="server">เล่มที่</asp:Label>
                            <asp:TextBox ID="Agent_bookcode_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_com_code_Lbl" runat="server">เลขใบหักภาษี ณ ที่จ่าย</asp:Label>
                            <asp:TextBox ID="Agent_com_code_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_date_print_Lbl" runat="server">ลงวันที่</asp:Label>
                            <div class="form-group input-group" id="Agent_date_print">
                                <asp:TextBox ID="Agent_date_print_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                            <script type="text/javascript">
                                $(function () {

                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                    // กรณีใช้แบบ input
                                    $("#Agent_date_print").datetimepicker({
                                        timepicker: false,
                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                        onSelectDate: function (dp, $input) {
                                            var yearT = new Date(dp).getFullYear() - 0;
                                            var yearTH = yearT + 543;
                                            var fulldate = $input.val();
                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                            $("<%= "#" + Agent_date_print_TBx.ClientID %>").val(fulldateTH);
		                                },
                                    });
                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                    $("<%= "#" + Agent_date_print_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                        var dateValue = $(this).val();
                                        if (dateValue != "") {
                                            var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                            if (e.type == "mouseenter") {
                                                var yearT = arr_date[2] - 543;
                                            }
                                            if (e.type == "mouseleave") {
                                                var yearT = parseInt(arr_date[2]) + 543;
                                            }
                                            dateValue = dateValue.replace(arr_date[2], yearT);
                                            $(this).val(dateValue);
                                        }
                                    });
                                });
                            </script>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลนายหน้า -->

                <hr />

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="Agent_Add_Save_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Agent_Add_Save_Btn_Click"><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

