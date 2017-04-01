<%@ Page Title="ข้อมูลการใช้งานระบบ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activity_Log_List.aspx.cs" Inherits="JKLWebBase_v2.Form_Account.Activity_Log_List" %>

<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6> ข้อมูลการใช้งานระบบโดยรวม </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label ID="Log_Date_Lbl" runat="server"> วันที่ทำสัญญา </asp:Label>
                    <div class="form-group input-group" id="Log_Date_str">
                        <asp:TextBox ID="Log_Date_str_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                    </div>
                    <script type="text/javascript">
                        $(function () {

                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                            // กรณีใช้แบบ input
                            $("#Log_Date_str").datetimepicker({
                                timepicker: false,
                                format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                onSelectDate: function (dp, $input) {
                                    var yearT = new Date(dp).getFullYear() - 0;
                                    var yearTH = yearT + 543;
                                    var fulldate = $input.val();
                                    var fulldateTH = fulldate.replace(yearT, yearTH);
                                    $("<%= "#" + Log_Date_str_TBx.ClientID %>").val(fulldateTH);
                                },
                            });
                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                            $("<%= "#" + Log_Date_str_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
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
                <div class="col-md-3">
                    <asp:Label ID="Log_Date_end_Lbl" runat="server"> ถึงวันที่ </asp:Label>
                    <div class="form-group input-group" id="Log_Date_end">
                        <asp:TextBox ID="Log_Date_end_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                    </div>
                    <script type="text/javascript">
                        $(function () {

                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                            // กรณีใช้แบบ input
                            $("#Log_Date_end").datetimepicker({
                                timepicker: false,
                                format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                onSelectDate: function (dp, $input) {
                                    var yearT = new Date(dp).getFullYear() - 0;
                                    var yearTH = yearT + 543;
                                    var fulldate = $input.val();
                                    var fulldateTH = fulldate.replace(yearT, yearTH);
                                    $("<%= "#" + Log_Date_end_TBx.ClientID %>").val(fulldateTH);
                                },
                            });
                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                            $("<%= "#" + Log_Date_end_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
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
                <div class="col-md-2">
                    <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Search_Btn_Click"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                </div>
            </div>

            <hr>

            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="width: 10%;">วัน เวลา </th>
                            <th style="width: 70%;"> รายละเอียด </th>
                            <th style="width: 10%;"> ชื่อผู้ใช้งาน </th>
                            <th style="width: 10%;"> สาขา </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td > </td>
                            <td > </td>
                            <td > </td>
                            <td > </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <nav aria-label="...">
                <ul class="pager">
                    <li>
                        <asp:LinkButton ID="link_Previous" runat="server" OnClick="link_Previous_Click"> <i class="fa fa-arrow-left fa-fw"></i> ก่อนหน้า </asp:LinkButton>
                    </li>
                    <li>
                        <asp:DropDownList ID="Paging_DDL" runat="server" CssClass="pagination" ForeColor="#cc0000" Font-Bold="true" OnSelectedIndexChanged="Paging_DDL_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_Next" runat="server" OnClick="link_Next_Click"> ต่อไป <i class="fa fa-arrow-right fa-fw"></i> </asp:LinkButton>
                    </li>
                </ul>
            </nav>
        </div>

    </div>

</asp:Content>