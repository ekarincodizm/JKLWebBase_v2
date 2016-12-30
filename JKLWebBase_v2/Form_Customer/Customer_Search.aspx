﻿<%@ Page Title="ค้นหาข้อมูลผู้ติดต่อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer_Search.aspx.cs" Inherits="JKLWebBase_v2.Form_Customer.Customer_Search" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Customers" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Customers" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>ค้นหาข้อมูลผู้ติดต่อ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Customer_Idcard_Lbl" runat="server"> รหัสบัตรประชาชน </asp:Label>
                    <asp:TextBox ID="Customer_Idcard_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Customer_Fname_Lbl" runat="server"> ชื่อ </asp:Label>
                    <asp:TextBox ID="Customer_Fname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Customer_Lname_Lbl" runat="server"> นามสกุล </asp:Label>
                    <asp:TextBox ID="Customer_Lname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Search_Btn_Click"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                </div>
            </div>

            <hr>
            <%
                if (Session["List_Customers"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="text-align: center; width: 3%;"># </th>
                            <th style="text-align: center; width: 10%;">รหัสบัตรประชาชน </th>
                            <th style="text-align: center; width: 20%;">ชื่อ - นามสกุล </th>
                            <th style="text-align: center; width: 57%;">ที่อยู่ตามทะเบียนบ้าน </th>
                            <th style="text-align: center; width: 8%;">โทรศัพท์ </th>
                            <th style="text-align: center; width: 2%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Customers> list_cust = (List<Customers>)Session["List_Customers"];
                            int row_str = (int)Session["row_str"];

                            for (int i = 0; i < list_cust.Count; i++)
                            {
                                Customers ctm = list_cust[i];
                                Customers_Address ctm_add = new Customers_Address_Manager().getCustomersAddressByCustomerId(ctm.Cust_id, 2);

                                string ogn_code = CryptographyCode.GenerateSHA512String(ctm.Cust_idcard);
                        %>
                        <tr>
                            <td style="text-align: center;"><%= row_str + i + 1 %></td>
                            <td style="text-align: center;"><%= ctm.Cust_idcard %></td>
                            <td><%= ctm.Cust_Fname + " " + ctm.Cust_LName %></td>
                            <td><%= ctm_add.Address_inline %></td>
                            <td><%= ctm_add.Cust_Tel %></td>
                            <td>
                                <a class="btn btn-xs btn-warning btn-block" href="Customer_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, ctm.Cust_idcard, "") %>" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit"></i> </a>
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
