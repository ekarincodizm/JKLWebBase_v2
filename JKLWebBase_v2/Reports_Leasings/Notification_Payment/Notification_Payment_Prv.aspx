<%@ Page Title="รายงานแจ้งเตือนชำระค่างวด" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification_Payment_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports_Leasings.Notification_Payment.Notification_Payment_Prv" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>รายงานแจ้งเตือนชำระค่างวด </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="Deps_No_Lbl" runat="server"> เลขที่ฝาก </asp:Label>
                    <asp:TextBox ID="Deps_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Label ID="Leasing_No_Lbl" runat="server"> เลขที่สัญญา </asp:Label>
                    <asp:TextBox ID="Leasing_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Cust_Idcard_Lbl" runat="server"> รหัสบัตรประชาชน </asp:Label>
                    <asp:TextBox ID="Cust_Idcard_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Cust_FName_Lbl" runat="server"> ชื่อ </asp:Label>
                    <asp:TextBox ID="Cust_FName_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Cust_LName_Lbl" runat="server"> นามสกุล </asp:Label>
                    <asp:TextBox ID="Cust_LName_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-3">
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
                <div class="col-xs-3">
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
                    <asp:Label ID="Lost_Payment_str_Lbl" runat="server"> ระยะเวลาขาดชำระ </asp:Label>
                    <asp:TextBox ID="Lost_Payment_str_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Lost_Payment_end_Lbl" runat="server"> ถึง </asp:Label>
                    <asp:TextBox ID="Lost_Payment_end_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="district_Lbl" runat="server"> อำเภอ / เขต</asp:Label>
                    <asp:TextBox ID="district_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="province_Lbl" runat="server"> จังหวัด </asp:Label>
                    <asp:TextBox ID="province_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Leasing_Code_Lbl" runat="server" CssClass="checkbox">รหัสสัญญา
                        <asp:CheckBox ID="Leasing_Code_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Leasing_Code_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Leasing_Code_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="9">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Company_Lbl" runat="server" CssClass="checkbox">สาขา
                        <asp:CheckBox ID="Company_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Company_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Company_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="10">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Zone_Lbl" runat="server" CssClass="checkbox">เขตบริการ
                        <asp:CheckBox ID="Zone_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Zone_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Zone_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="9">
                    </asp:CheckBoxList>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Search_Btn_Click"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                </div>
                <div class="col-md-2">
                    <asp:LinkButton ID="Export_Reported_Btn" runat="server" CssClass="btn btn-sm btn-success btn-block" OnClick="Export_Reported_Btn_Click"><i class="fa fa-print fa-fw"></i> ออกรายงานทั้งหมด </asp:LinkButton>
                </div>
            </div>

            <hr>

            <%
                if (Session["List_Leasings"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="width: 5%;"> # </th>
                            <th style="width: 10%;">เลขที่ฝาก </th>
                            <th style="width: 10%;">เลขที่สัญญา </th>
                            <th style="width: 25%;">ชื่อ - นามสกุล </th>
                            <th style="width: 10%;">ยอดเช่า - ซื้อ </th>
                            <th style="width: 5%;">งวดทั้งหมด </th>
                            <th style="width: 5%;">งวดคงเหลือ </th>
                            <th style="width: 10%;">ยอดคงค้าง</th>
                            <th style="width: 10%;">ขาดชำระ (งวด)</th>
                            <th style="width: 10%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Car_Leasings> list_cust = (List<Car_Leasings>)Session["List_Leasings"];

                            for (int i = 0; i < list_cust.Count; i++)
                            {
                                Car_Leasings cls = list_cust[i];

                                string ogn_code = CryptographyCode.GenerateSHA512String(cls.Leasing_id);
                        %>
                        <tr>
                            <td><%= i+1 %></td>
                            <td><%= cls.Deps_no %></td>
                            <td><%= cls.Leasing_no %></td>
                            <td><%= cls.ctm.Cust_Fname + " " + cls.ctm.Cust_LName + " " + cls.Leasing_Comment %></td>
                            <td style="color: #2fba00;"><%= cls.Total_Net_leasing.ToString("#,###.00") %></td>
                            <td><%= cls.Total_period %></td>
                            <td><%= cls.Total_period_left %></td>
                            <td <%= cls.Total_payment_left == 0 ? "style='color: #2fba00;'" : "style='color: #ff0000;'" %>><%= cls.Total_payment_left.ToString("#,###.00") %></td>
                            <td style="color: #ff0000;"><%= cls.Total_period_lose %></td>
                            <td>
                                <a class="btn btn-xs btn-success" href="Notification_Payment_Export?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, cls.Deps_no) %>" target="_blank" data-toggle="tooltip" data-placement="top" title="ออกรายงาน"><i class="fa fa-print fa-fw"></i>ออกรายงาน</a>
                            </td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>

            <%  
                }
            %>

        </div>
    </div>
</asp:Content>
