<%@ Page Title="ค้นหาสัญญาเช่า-ซื้อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Search.aspx.cs" Inherits="JKLWebBase_v2.Leasing_Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>ค้นหาสัญญาเช่า-ซื้อ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Deps_No_Lbl" runat="server"> เลขที่ฝาก </asp:Label>
                    <asp:TextBox ID="Deps_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_No_Lbl" runat="server"> เลขที่สัญญา </asp:Label>
                    <asp:TextBox ID="Leasing_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Label3" runat="server"> รหัสบัตรประชาชน </asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Label4" runat="server"> ชื่อ-นามสกุล </asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_Date_Lbl" runat="server"> วันที่ทำสัญญา </asp:Label>
                    <div class="form-group input-group" id="Leasing_Date_str">
                        <asp:TextBox ID="Leasing_Date_str_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                    </div>
                    <script type="text/javascript">
                        $(function () {

                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                            // กรณีใช้แบบ input
                            $("#Leasing_Date_str").datetimepicker({
                                timepicker: false,
                                format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                onSelectDate: function (dp, $input) {
                                    var yearT = new Date(dp).getFullYear() - 0;
                                    var yearTH = yearT + 543;
                                    var fulldate = $input.val();
                                    var fulldateTH = fulldate.replace(yearT, yearTH);
                                    $("<%= "#" + Leasing_Date_str_TBx.ClientID %>").val(fulldateTH);
                                },
                            });
                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                            $("<%= "#" + Leasing_Date_str_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
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
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_Date_end_Lbl" runat="server"> ถึงวันที่ </asp:Label>
                    <div class="form-group input-group" id="Leasing_Date_end">
                        <asp:TextBox ID="Leasing_Date_end_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                    </div>
                    <script type="text/javascript">
                        $(function () {

                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                            // กรณีใช้แบบ input
                            $("#Leasing_Date_end").datetimepicker({
                                timepicker: false,
                                format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                onSelectDate: function (dp, $input) {
                                    var yearT = new Date(dp).getFullYear() - 0;
                                    var yearTH = yearT + 543;
                                    var fulldate = $input.val();
                                    var fulldateTH = fulldate.replace(yearT, yearTH);
                                    $("<%= "#" + Leasing_Date_end_TBx.ClientID %>").val(fulldateTH);
                                },
                            });
                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                            $("<%= "#" + Leasing_Date_end_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
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

            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Label6" runat="server" CssClass="checkbox" > รหัสสัญญา <asp:CheckBox ID="Leasing_Code_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Leasing_Code_ChkBx_All_CheckedChanged" AutoPostBack="true" /> </asp:Label>
                    <asp:CheckBoxList ID="Leasing_Code_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="4">
                    </asp:CheckBoxList>
                </div>
                <div class="form-group col-xs-6">
                    <asp:Label ID="Label1" runat="server" CssClass="checkbox" > สาขา <asp:CheckBox ID="Branch_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Branch_ChkBx_All_CheckedChanged" AutoPostBack="true" /> </asp:Label>
                    <asp:CheckBoxList ID="Branch_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="6">
                    </asp:CheckBoxList>
                </div>
                <div class="form-group col-xs-4">
                    <asp:Label ID="Label2" runat="server" CssClass="checkbox" > เขตบริการ <asp:CheckBox ID="Zone_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Zone_ChkBx_All_CheckedChanged" AutoPostBack="true" /> </asp:Label>
                    <asp:CheckBoxList ID="Zone_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="3">
                    </asp:CheckBoxList>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                </div>
            </div>

            <hr>

        </div>

        <div class="panel-body">
        </div>
    </div>

</asp:Content>
