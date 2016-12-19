<%@ Page Title="ค้นหาข้อมูลผู้ติดต่อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer_Search.aspx.cs" Inherits="JKLWebBase_v2.Form_Customer.Customer_Search" %>

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
                            <th style="text-align: center; width: 5%;"># </th>
                            <th style="text-align: center; width: 10%;">รหัสบัตรประชาชน </th>
                            <th style="text-align: center; width: 20%;">ชื่อ - นามสกุล </th>
                            <th style="text-align: center; width: 55%;">ที่อยู่ตามทะเบียนบ้าน </th>
                            <th style="text-align: center; width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Customers> list_cust = (List<Customers>)Session["List_Customers"];
                            RijndaelEnhanced encode = new RijndaelEnhanced("jkl");

                            for (int i = 0; i < list_cust.Count; i++)
                            {
                                Customers ctm = list_cust[i];
                                Customers_Address ctm_add = new Customers_Address_Manager().getCustomersAddressByCustomerId(ctm.Cust_id, 2);
                                string address = "";
                                address += string.IsNullOrEmpty(ctm_add.Cust_Address_no) ? "" : ctm_add.Cust_Address_no;
                                address += string.IsNullOrEmpty(ctm_add.Cust_Vilage) ? "" : " บ." + ctm_add.Cust_Vilage;
                                address += string.IsNullOrEmpty(ctm_add.Cust_Vilage_no) ? "" : " ม." + ctm_add.Cust_Vilage_no;
                                address += string.IsNullOrEmpty(ctm_add.Cust_Alley) ? "" : " ซ." + ctm_add.Cust_Alley;
                                address += string.IsNullOrEmpty(ctm_add.Cust_Road) ? "" : " ถ." + ctm_add.Cust_Road;
                                address += string.IsNullOrEmpty(ctm_add.Cust_Subdistrict) ? "" : " ต." + ctm_add.Cust_Subdistrict;
                                address += string.IsNullOrEmpty(ctm_add.Cust_District) ? "" : " อ." + ctm_add.Cust_District;
                                address += ctm_add.Cust_Province == 0 ? "" : " จ." + ctm_add.Cust_Province;
                                address += string.IsNullOrEmpty(ctm_add.Cust_Zipcode) ? "" : " " + ctm_add.Cust_Zipcode;

                                string ogn_code = CryptographyCode.GenerateSHA512String(ctm.Cust_idcard);
                        %>
                        <tr>
                            <td style="text-align: center;"><%= i + 1 %></td>
                            <td style="text-align: center;"><%= ctm.Cust_idcard %></td>
                            <td><%= ctm.Cust_Fname + " " + ctm.Cust_LName %></td>
                            <td><%= address %></td>
                            <td>
                                <a class="btn btn-xs btn-warning btn-block" href="Customer_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, ctm.Cust_idcard) %>"><i class="fa fa-edit"></i>แก้ไข </a>
                            </td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>

            <nav aria-label="...">
                <ul class="pager">
                    <li>
                        <asp:LinkButton ID="link_Previous" runat="server"> <i class="fa fa-arrow-left fa-fw"></i> ก่อนหน้า </asp:LinkButton>
                    </li>
                    <li>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="pagination" ForeColor="#cc0000" Font-Bold="true" >
                            <asp:ListItem>หน้า</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <asp:LinkButton ID="link_Next" runat="server"> ต่อไป <i class="fa fa-arrow-right fa-fw"></i> </asp:LinkButton>
                    </li>
                </ul>
            </nav>
            <%  
                }
            %>
        </div>
    </div>
</asp:Content>
