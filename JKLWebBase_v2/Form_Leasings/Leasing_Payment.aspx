<%@ Page Title="ชำระเงินค่างวด" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Payment.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Payment" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>
<%@ Import Namespace="JKLWebBase_v2.Class_Account" %>
<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>

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
                            <asp:Label ID="Alert_Id_Card_Lbl" runat="server"> ไม่พบเลขบัตรประชาชน . . . นี้ในระบบ </asp:Label>
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

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    ข้อมูลทั่วไปสัญญา
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Company_N_Name_Lbl" runat="server"> สาขา </asp:Label>
                            <asp:TextBox ID="Company_N_Name_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Zone_Name_Lbl" runat="server"> เขต </asp:Label>
                            <asp:TextBox ID="Zone_Name_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-8">
                            <asp:Label ID="Company_F_Name_Lbl" runat="server"> ชื่อสำนักงาน </asp:Label>
                            <asp:TextBox ID="Company_F_Name_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-6">
                            <asp:Label ID="Customer_H_Address_Lbl" runat="server"> ที่อยู่ตามทะเบียนบ้าน </asp:Label>
                            <asp:TextBox ID="Customer_H_Address_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:Label ID="Customer_C_Address_Lbl" runat="server"> ที่อยู่ปัจจุบัน</asp:Label>
                            <asp:TextBox ID="Customer_C_Address_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <asp:Label ID="Car_Type_Lbl" runat="server"> รถ </asp:Label>
                            <asp:TextBox ID="Car_Type_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Brand_LBl" runat="server"> ยี่ห้อ </asp:Label>
                            <asp:TextBox ID="Car_Brand_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Plate_LBl" runat="server"> เลขทะเบียน </asp:Label>
                            <asp:TextBox ID="Car_Plate_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Chassis_No_LBl" runat="server"> เลขตัวรถ </asp:Label>
                            <asp:TextBox ID="Car_Chassis_No_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Engine_No_LBl" runat="server"> เลขเครื่องยนต์ </asp:Label>
                            <asp:TextBox ID="Car_Engine_No_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Finance_Cost_Lbl" runat="server"> ยอดจัด </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Finance_Cost_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Finance_Value_Lbl" runat="server"> มูลค่า </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Finance_Value_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Payment_Schedule_Lbl" runat="server"> ชำระทุกวันที่ </asp:Label>
                            <asp:TextBox ID="Payment_Schedule_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Frist_Payment_Date_Lbl" runat="server"> วันที่เริ่มชำระ </asp:Label>
                            <asp:TextBox ID="Frist_Payment_Date_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="panel-heading">
                    ข้อมูลสำคัญสัญญา
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Customer_Name_Lbl" runat="server"> ชื่อผู้ทำสัญญา </asp:Label>
                            <asp:TextBox ID="Customer_Name_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Customer_Idcard_Lbl" runat="server"> รหัสบัตรประชาชน </asp:Label>
                            <asp:TextBox ID="Customer_Idcard_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Leasing_Date_Lbl" runat="server"> วันที่ทำสัญญา </asp:Label>
                            <asp:TextBox ID="Leasing_Date_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Deps_No_Lbl" runat="server"> เลขที่รับฝาก </asp:Label>
                            <asp:TextBox ID="Deps_No_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Leasing_No_Lbl" runat="server"> เลขสัญญา </asp:Label>
                            <asp:TextBox ID="Leasing_No_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Leasing_Cost_Lbl" runat="server"> ยอดเช่า - ซื้อ </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Leasing_Cost_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Period_Payment_Lbl" runat="server"> ชำระงวดละ </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Period_Payment_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Period_Amount_Lbl" runat="server"> จำนวนงวด </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Period_Amount_TBx" runat="server" CssClass="form-control" ForeColor="#ff0000" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">งวด</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Agent_Commission_Lbl" runat="server"> ค่านายหน้า </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Agent_Commission_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%
        Base_Companys package_login = (Base_Companys)Session["Package"];
        Account_Login acc_lgn = (Account_Login)Session["Login"];
    %>
    <div class="row">
        <div class="col-md-8">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    ประวัติการชำระเงิน
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th style="width: 5%;">งวดที่</th>
                                            <th style="width: 10%;">กำหนดชำระ</th>
                                            <th style="width: 10%;">วันที่ชำระ </th>
                                            <th style="width: 10%;">ค่าปรับ (บาท)</th>
                                            <th style="width: 10%;">ยอดชำระ (บาท)</th>
                                            <th style="width: 10%;">ยอดคงค้าง (บาท)</th>
                                            <th style="width: 10%;">ยอดชำระค่าปรับ (บาท)</th>
                                            <th style="width: 23%;">ใบเสร็จ</th>
                                            <th style="width: 4%;"></th>
                                            <%              
                                                if (acc_lgn.acc_lv.level_access >= 7)
                                                {
                                            %>
                                            <th style="width: 4%;"></th>
                                            <th style="width: 4%;"></th>
                                            <% } %>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <% 
                                            if (Session["list_cls_pay"] != null)
                                            {
                                                List<Car_Leasings_Payment> list_cls_pay = (List<Car_Leasings_Payment>)Session["list_cls_pay"];

                                                int max_row = 0;

                                                for (int i = 0; i < list_cls_pay.Count; i++)
                                                {
                                                    Car_Leasings_Payment cls_pay = list_cls_pay[i];

                                                    if (cls_pay.Count_payment != 0)
                                                    {
                                                        max_row = i;
                                                    }
                                                }

                                                for (int i = 0; i < list_cls_pay.Count; i++)
                                                {
                                                    Car_Leasings_Payment cls_pay = list_cls_pay[i];

                                                    string ogn_code = CryptographyCode.GenerateSHA512String(cls_pay.Bill_no);
                                        %>
                                        <tr
                                            <% 
                                            if (Convert.ToDateTime(cls_pay.Period_schedule) < DateTime.Now && cls_pay.Period_payment_status == -1)
                                            {
                                        %>
                                            <%= "style='background-color: #cc0000; color: #ffffff;'" %>
                                            <%          }
                                            else if (cls_pay.Period_payment_status == 1)
                                            {
                                        %>
                                            <%= "style='background-color: lightyellow; color: #808080;'" %>
                                            <%          }
                                            else if (cls_pay.Period_payment_status == 9)
                                            {
                                        %>
                                            <%= cls_pay.Period_no % 2 == 0 ? "style='background-color: #ffff80; color: #808080;'"  : "style='background-color: #99e6ff; color: #808080'" %>
                                            <%          } %>>
                                            <td><%= cls_pay.Period_no %>  </td>
                                            <td><%= DateTimeUtility.convertDateToPageRealServer(cls_pay.Period_schedule)  %>  </td>
                                            <td><%= string.IsNullOrEmpty(cls_pay.Real_payment_date)? "-" : DateTimeUtility.convertDateToPageRealServer(cls_pay.Real_payment_date) %>  </td>
                                            <td><%= cls_pay.Period_fine.ToString("#,###.00") %>  </td>
                                            <td><%= cls_pay.Real_payment == 0 ? "0.00" : cls_pay.Real_payment.ToString("#,###.00") %>  </td>
                                            <td><%= string.IsNullOrEmpty(cls_pay.Bill_no)? "-" : cls_pay.Total_payment_left == 0 ? cls_pay.Total_Period_left.ToString("#,###.00") : cls_pay.Total_payment_left.ToString("#,###.00") %>  </td>
                                            <th><%= cls_pay.Real_payment_fine.ToString("#,###.00") %> </th>
                                            <td><%= string.IsNullOrEmpty(cls_pay.Bill_no)? "-" : cls_pay.Bill_no %>  </td>
                                            <td>
                                                <% 
                                                    if (!string.IsNullOrEmpty(cls_pay.Bill_no))
                                                    {
                                                %>
                                                <a class="btn btn-xs btn-info" href="/Reports_Leasings/Bill_Payment_Slip/Bill_Payment_Slip_Prv?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, cls_pay.Leasing_id, cls_pay.Bill_no) %>" target="_blank" data-toggle="tooltip" data-placement="top" title="พิมพ์ใบเสร็จ"><i class="fa fa-print fa-fw"></i></a>
                                                <%  } %>
                                            </td>
                                            <%              
                                                if (acc_lgn.acc_lv.level_access >= 7)
                                                {
                                            %>
                                            <td>
                                                <% 
                                                    if (!string.IsNullOrEmpty(cls_pay.Bill_no) && max_row == i)
                                                    {
                                                %>
                                                <a class="btn btn-xs btn-warning" href="/Form_Leasings/Leasing_Edit_Payment?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, cls_pay.Leasing_id, cls_pay.Bill_no) %>&mode=e" target="_parent" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit fa-fw"></i></a>
                                                <%  } %>
                                            </td>
                                            <td>
                                                <% 
                                                    if (max_row == i)
                                                    {
                                                %>
                                                <a class="btn btn-xs btn-danger" href="/Form_Leasings/Leasing_Edit_Payment?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, cls_pay.Leasing_id, cls_pay.Bill_no) %>&mode=r" target="_parent" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
                                                <%  } %>
                                            </td>
                                            <% } %>
                                        </tr>
                                        <%
                                                }
                                            }
                                        %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    ข้อมูลการชำระเงิน
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-9 col-md-offset-3">
                            <asp:Label ID="Close_Leasing_Lbl" runat="server" Font-Bold="True" Font-Size="46pt" ForeColor="Red" Font-Italic="True"> *** ปิดบัญชี *** </asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Leasing_Comments" runat="server" Font-Bold="True" Font-Size="24pt" ForeColor="Red" Font-Italic="True"> ** หมายเหตุ ** </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <asp:Label ID="Leasing_Comments_Lbl" runat="server" Font-Bold="True" Font-Size="24pt" ForeColor="Red" Font-Italic="True">  </asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Payment_Date_Lbl" runat="server"> วันที่ชำระเงิน </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group" id="Payment_Date">
                                <asp:TextBox ID="Payment_Date_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="20pt" ForeColor="Red"></asp:TextBox>
                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                            <script type="text/javascript">
                                $(function () {

                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                    // กรณีใช้แบบ input
                                    $("#Payment_Date").datetimepicker({
                                        timepicker: false,
                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                        onSelectDate: function (dp, $input) {
                                            var yearT = new Date(dp).getFullYear() - 0;
                                            var yearTH = yearT + 543;
                                            var fulldate = $input.val();
                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                            $("<%= "#" + Payment_Date_TBx.ClientID %>").val(fulldateTH);
                                        },
                                    });
                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                    $("<%= "#" + Payment_Date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
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
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Period_No_Lbl" runat="server"> งวดที่ </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <asp:TextBox ID="Period_No_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="20pt" ForeColor="Red" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Total_Payment_Period_Lbl" runat="server"> รวม </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Total_Payment_Period_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="24pt" ForeColor="Red" ReadOnly="true"> </asp:TextBox>
                                <span class="input-group-addon">งวด</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Total_payment_left_Lbl" runat="server"> ยอดคงค้างทั้งหมด </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Total_payment_left_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="24pt" ForeColor="#00CC00" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Total_period_left_Lbl" runat="server"> ยอดขาดชำระทั้งหมด </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Total_period_left_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="24pt" ForeColor="Red" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Total_payment_fine_Lbl" runat="server"> ยอดค่าปรับค้างชำระ </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Total_payment_fine_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="24pt" ForeColor="#FF6600" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-10 col-md-offset-2">
                            <asp:Label ID="Cal_Status_Lbl" runat="server" Font-Bold="True" Font-Size="36pt" ForeColor="#FF6600"> *** คำนวนการปิดบัญชี *** </asp:Label>
                        </div>
                    </div>

                    <hr />


                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Period_fine_Lbl" runat="server"> ค่าปรับ </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Period_fine_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Italic="True" Font-Size="24pt" ForeColor="Red" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Discount_Lbl" runat="server"> ส่วนลด </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Discount_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Italic="True" Font-Size="24pt" ForeColor="#CC6600" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Cal_Period_Payment_Lbl" runat="server"> ยอดรวมค่างวด </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Cal_Period_Payment_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Italic="True" Font-Size="24pt" ForeColor="Red" Font-Underline="True" ReadOnly="true"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>

                    <hr />

                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Period_free_Lbl" runat="server"> ยอดชำระค่าธรรมเนียม </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Period_free_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Italic="True" Font-Size="24pt" ForeColor="Fuchsia" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Period_track_Lbl" runat="server"> ยอดชำระค่าติดตาม </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Period_track_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Italic="True" Font-Size="24pt" ForeColor="#996633" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Real_Payment_Lbl" runat="server"> ยอดชำระค่างวด </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Real_Payment_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="24pt" ForeColor="#009933" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                            <asp:RequiredFieldValidator ID="RFV_Real_Payment_TBx" runat="server" ErrorMessage=" กรุณากรอกจำนวนเงิน " CssClass="text-danger" ControlToValidate="Real_Payment_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Real_Payment_Fine_Lbl" runat="server"> ยอดชำระค่าปรับ </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Real_Payment_Fine_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="24pt" ForeColor="#990000" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                            <asp:RequiredFieldValidator ID="RFV_Real_Payment_Fine_TBxx" runat="server" ErrorMessage=" กรุณากรอกจำนวนเงิน " CssClass="text-danger" ControlToValidate="Real_Payment_Fine_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Real_Discount_Lbl" runat="server"> ส่วนลด </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <div class="form-group input-group">
                                <asp:TextBox ID="Real_Discount_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="24pt" ForeColor="#FF9900" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                            <asp:RequiredFieldValidator ID="RFV_Real_Discount_TBx" runat="server" ErrorMessage=" กรุณากรอกจำนวนเงิน " CssClass="text-danger" ControlToValidate="Real_Discount_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-5">
                            <asp:Label ID="Bill_No_Manual_Ref_Lbl" runat="server"> เลขใบเสร็จ Ref. </asp:Label>
                        </div>
                        <div class="form-group col-xs-7">
                            <asp:TextBox ID="Bill_No_Manual_Ref_TBx" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="20pt" ForeColor="Red"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Label ID="Note_Lbl" runat="server" Font-Bold="True" Font-Size="18pt" ForeColor="#FF6600"> </asp:Label>
                        </div>
                    </div>

                    <hr />

                    <div class="row">
                        <div class="form-group col-xs-6">
                            <asp:LinkButton ID="Payment_Btn" runat="server" CssClass="btn btn-sm btn-success btn-block" OnClick="Payment_Btn_Click" ValidationGroup="Save_Validation" CausesValidation="true"><i class="fa fa-save fa-fw"></i> ชำระเงิน </asp:LinkButton>
                        </div>
                        <div class="form-group col-xs-6">
                            <asp:LinkButton ID="Calculate_Close_Leasing_Btn" runat="server" CssClass="btn btn-sm btn-warning btn-block" OnClick="Calculate_Close_Leasing_Btn_Click"><i class="fa fa-gears fa-fw"></i> คำนวนปิดบัญชี </asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-6">
                            <asp:LinkButton ID="Back_Before_Page_Btn" runat="server" CssClass="btn btn-sm btn-info btn-block" OnClick="Back_Before_Page_Btn_Click"><i class="fa fa-arrow-circle-left fa-fw"></i> ย้อนกลับ  </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
