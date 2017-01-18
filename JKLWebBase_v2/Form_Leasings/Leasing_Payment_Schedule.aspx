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
                                    <th>งวดที่</th>
                                    <th>วันที่กำหนดชำระ</th>
                                    <th>ค่างวดที่ต้องชำระ (บาท)</th>
                                    <th>ค่างวด (บาท)</th>
                                    <th>มูลค่าต่องวด (บาท)</th>
                                    <th>เงินต้นต่องวด (บาท)</th>
                                    <th>ดอกเบี้ยต่องวด (บาท)</th>
                                    <th>ภาษีต่องวด (บาท)</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    List<Car_Leasings_Payment> list_cls_pay = (List<Car_Leasings_Payment>)Session["list_cls_pay"];

                                    for (int i = 0; i < list_cls_pay.Count; i++)
                                    {
                                        Car_Leasings_Payment cls_pay = list_cls_pay[i];
                                %>
                                <tr>
                                    <td><%= cls_pay.Period_no %> </td>
                                    <td><%= DateTimeUtility.convertDateToPage(cls_pay.Period_schedule) %> </td>
                                    <td><%= cls_pay.Period_current.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_cash.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_value.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_principle.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_interst.ToString("#,###.00") %> </td>
                                    <td><%= cls_pay.Period_vat.ToString("#,###.00") %> </td>
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
