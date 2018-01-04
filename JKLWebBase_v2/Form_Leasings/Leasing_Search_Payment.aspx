<%@ Page Title="ค้นหาสัญญาเช่า-ซื้อ และ ชำระค่างวดเช่า - ซื้อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Search_Payment.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Search_Payment" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>ค้นหาสัญญาเช่า-ซื้อ และ ชำระค่างวดเช่า - ซื้อ </h6>
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
                <div class="col-xs-3">
                    <asp:Label ID="Car_Plate_Lbl" runat="server"> เลขทะเบียนรถ </asp:Label>
                    <asp:TextBox ID="Car_Plate_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Label6" runat="server" CssClass="checkbox">รหัสสัญญา
                        <asp:CheckBox ID="Leasing_Code_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Leasing_Code_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Leasing_Code_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="10">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Label1" runat="server" CssClass="checkbox">สาขา
                        <asp:CheckBox ID="Company_ChkBx_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Company_ChkBx_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Company_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="10">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Label2" runat="server" CssClass="checkbox">เขตบริการ
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
                            <th style="width: 5%;">สถานะ </th>
                            <th style="width: 10%;">เลขที่ฝาก </th>
                            <th style="width: 12%;">เลขที่สัญญา </th>
                            <th style="width: 16%;">ชื่อ - นามสกุล </th>
                            <th style="width: 8%;">วันที่ทำสัญญา </th>
                            <th style="width: 8%;">ยอดเช่า - ซื้อ </th>
                            <th style="width: 5%;">งวดทั้งหมด </th>
                            <th style="width: 5%;">งวดคงเหลือ </th>
                            <th style="width: 5%;">ค่างวด</th>
                            <th style="width: 8%;">ยอดคงค้าง</th>
                            <th style="width: 8%;">ขาดชำระ (งวด)</th>
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
                            <td>
                                <% 
                                    if (cls.bs_ls_stt.Contract_Status_id == 1)
                                    {
                                        Response.Write("<label class='label label-success' > " + cls.bs_ls_stt.Contract_Status_name + " </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 2)
                                    {
                                        Response.Write("<label class='label label-warning' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 3)
                                    {
                                        Response.Write("<label class='label label-warning' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 4)
                                    {
                                        Response.Write("<label class='label label-danger' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 5)
                                    {
                                        Response.Write("<label class='label label-danger' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 6)
                                    {
                                        Response.Write("<label class='label label-danger' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 7)
                                    {
                                        Response.Write("<label class='label label-info' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 8)
                                    {
                                        Response.Write("<label class='label label-info' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                    else if (cls.bs_ls_stt.Contract_Status_id == 9)
                                    {
                                        Response.Write("<label class='label label-info' >  " + cls.bs_ls_stt.Contract_Status_name + "  </label>");
                                    }
                                %>
                            </td>
                            <td><%= cls.Deps_no %></td>
                            <td><%= cls.Leasing_no %></td>
                            <td><%= cls.ctm.Cust_Fname + " " + cls.ctm.Cust_LName + " " + cls.Car_license_plate + " " + cls.Car_license_plate_province + " " + cls.Leasing_Comment %></td>
                            <td><%= DateTimeUtility.convertDateToPageRealServer(cls.Leasing_date) %></td>
                            <td style="color: #2fba00;"><%= cls.Total_Net_leasing.ToString("#,###.00") %></td>
                            <td><%= cls.Total_period %></td>
                            <td><%= cls.Total_period_left %></td>
                            <td><%= cls.Period_payment.ToString("#,###.00") %></td>
                            <td <%= cls.Total_payment_left == 0 ? "style='color: #2fba00;'" : "style='color: #ff0000;'" %>><%= cls.Total_payment_left.ToString("#,###.00") %></td>
                            <td style="color: #ff0000;"><%= cls.Total_period_lose %></td>
                            <td>
                                <a class="btn btn-xs btn-success" href="Leasing_Payment?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, cls.Leasing_id, cls.ctm.Cust_Idcard) %>" data-toggle="tooltip" data-placement="top" title="ชำระค่างวด"><i class="fa fa-money fa-fw"></i> ชำระค่างวด </a>
                            </td>
                        </tr>
                        <% } %>
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
            <%  
                }
            %>
        </div>

    </div>

</asp:Content>
