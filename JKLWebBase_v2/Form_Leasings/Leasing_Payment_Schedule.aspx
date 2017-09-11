<%@ Page Title="ตารางการผ่อนชำระ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Payment_Schedule.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Payment_Schedule" %>

<%@ Register TagPrefix="nav_menu" TagName="Tab_Menu" Src="Tabs_Menu_Leasings.ascx" %>

<%@ Register TagPrefix="print_menu_leasing" TagName="Print_Menu" Src="Print_Menu_Leasing.ascx" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Print Menu Button -->
    <print_menu_leasing:Print_Menu ID="Print_Menu1" runat="server" />

    <!-- ./Print Menu Button -->

    <div class="col-lg-12">
        <h4 class="page-header">ตารางการผ่อนชำระ </h4>
    </div>

    <!-- Tab MenuBar -->
    <nav_menu:Tab_Menu ID="nav_tabs" runat="server" />

    <!-- ./Tab MenuBar -->

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">

                <!-- ข้อมูลการผ่อนชำระ -->
                <div class="panel-heading">
                    ข้อมูลการผ่อนชำระ
                </div>
                <div class="panel-body">
                    <%
                        if (Session["list_cls_pay"] != null)
                        {
                    %>
                    <div class="table-responsive">
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th style="width: 5%;">งวดที่</th>
                                    <th style="width: 8%;">วันที่กำหนดชำระ</th>
                                    <th style="width: 6%;">ค่างวดที่ต้องชำระ (บาท)</th>
                                    <th style="width: 5%;">ค่างวด (บาท)</th>
                                    <th style="width: 5%;">มูลค่าต่องวด (บาท)</th>
                                    <th style="width: 6%;">เงินต้นต่องวด (บาท)</th>
                                    <th style="width: 6%;">ดอกเบี้ยต่องวด (บาท)</th>
                                    <th style="width: 6%;">ภาษีต่องวด (บาท)</th>
                                    <th style="width: 5%;">ค่าปรับ (บาท)</th>
                                    <th style="width: 5%;">ครั้งที่</th>
                                    <th style="width: 8%;">วันที่ชำระ </th>
                                    <th style="width: 5%;">ยอดชำระ (บาท)</th>
                                    <th style="width: 6%;">ยอดชำระค่าปรับ (บาท)</th>
                                    <th style="width: 15%;">ใบเสร็จ</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    List<Car_Leasings_Payment> list_cls_pay = (List<Car_Leasings_Payment>)Session["list_cls_pay"];

                                    for (int i = 0; i < list_cls_pay.Count; i++)
                                    {
                                        Car_Leasings_Payment cls_pay = list_cls_pay[i];

                                        if (Convert.ToDateTime(cls_pay.Period_schedule) < DateTime.Now && cls_pay.Period_payment_status == -1)
                                        {
                                %>
                                <tr style="background-color: lightcoral;"">
                                <%      }
                                        else if (cls_pay.Period_payment_status == 1)
                                        {
                                %>
                                <tr style="background-color: lightyellow;"">
                                <%      }
                                        else if (cls_pay.Period_payment_status == 9)
                                        {
                                %>
                                <tr style="background-color: lightgreen;">
                                <%      }
                                        else
                                        {
                                %>
                                <tr>
                                <%      } %>
                                    <td><%= cls_pay.Period_no %> </td>
                                    <td><%= DateTimeUtility.convertDateToPageRealServer(cls_pay.Period_schedule) %> </td>
                                    <td><%= cls_pay.Period_current.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_cash.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_value.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_principle.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_interst.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_vat.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_fine.ToString("#,###.00") %>  </td>
                                    <td><%= cls_pay.Count_payment == 0 ? "-" : cls_pay.Count_payment.ToString() %> </td>
                                    <td><%= string.IsNullOrEmpty(cls_pay.Real_payment_date)? "-" : DateTimeUtility.convertDateToPageRealServer(cls_pay.Real_payment_date) %>  </td>
                                    <td><%= cls_pay.Real_payment == 0 ? "0.00" : cls_pay.Real_payment.ToString("#,###.00") %>  </td>
                                    <th><%= cls_pay.Real_payment_fine.ToString("#,###.00") %> </th>
                                    <td><%= string.IsNullOrEmpty(cls_pay.Bill_no)? "-" : cls_pay.Bill_no %>  </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                    <%  
                        }
                    %>
                </div>
                <!-- ./ข้อมูลการผ่อนชำระ -->

            </div>
        </div>
    </div>

</asp:Content>
