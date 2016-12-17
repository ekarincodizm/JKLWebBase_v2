<%@ Page Title="ตารางการผ่อนชำระ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Payment_Schedule.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Payment_Schedule" %>

<%@ Register TagPrefix="nav_menu" TagName="Tab_Menu" Src="Tabs_Menu_Leasings.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                                <tr>
                                    <td>1</td>
                                    <td>02/01/2560</td>
                                    <td>2,500.00</td>
                                    <td>1,780.00</td>
                                    <td>2,420.00</td>
                                    <td>1,920.00</td>
                                    <td>500.00</td>
                                    <td>80.00</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>02/02/2560</td>
                                    <td>2,500.00</td>
                                    <td>1,780.00</td>
                                    <td>2,420.00</td>
                                    <td>1,920.00</td>
                                    <td>500.00</td>
                                    <td>80.00</td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>02/03/2560</td>
                                    <td>2,500.00</td>
                                    <td>1,780.00</td>
                                    <td>2,420.00</td>
                                    <td>1,920.00</td>
                                    <td>500.00</td>
                                    <td>80.00</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
                <!-- ./ข้อมูลการผ่อนชำระ -->

            </div>
        </div>
    </div>

</asp:Content>
