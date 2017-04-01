<%@ Page Title="ค้นหาข้อมูลนายหน้า" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agents_Search.aspx.cs" Inherits="JKLWebBase_v2.Form_Agents.Agents_Search" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Agents" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Agents" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6> ค้นหาข้อมูลนายหน้า </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Agent_Idcard_Lbl" runat="server"> รหัสบัตรประชาชน </asp:Label>
                    <asp:TextBox ID="Agent_Idcard_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Agent_Fname_Lbl" runat="server"> ชื่อ </asp:Label>
                    <asp:TextBox ID="Agent_Fname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Agent_Lname_Lbl" runat="server"> นามสกุล </asp:Label>
                    <asp:TextBox ID="Agent_Lname_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Search_Btn_Click"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                </div>
            </div>

            <hr>
            <%
                if (Session["List_Agents"] != null)
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
                            <th style="text-align: center; width: 8%;"> ประเภท </th>
                            <th style="text-align: center; width: 2%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Agents> list_cag = (List<Agents>)Session["List_Agents"];
                            int row_str = (int)Session["row_str"];

                            for (int i = 0; i < list_cag.Count; i++)
                            {
                                Agents cag = list_cag[i];

                                string Address = "";
                                Address += string.IsNullOrEmpty(cag.Agent_Address_no) ? "" : cag.Agent_Address_no;
                                Address += string.IsNullOrEmpty(cag.Agent_Vilage_no) ? "" : cag.Agent_Vilage_no.IndexOf('.') >= 1 ? cag.Agent_Vilage_no.Split('.')[1] == "-" ? "" : " " + cag.Agent_Vilage_no : "";
                                Address += string.IsNullOrEmpty(cag.Agent_Vilage) ? "" : cag.Agent_Vilage.IndexOf('.') >= 1 ? cag.Agent_Vilage.Split('.')[1] == "-" ? "" : " " + cag.Agent_Vilage : "";
                                Address += string.IsNullOrEmpty(cag.Agent_Alley) ? "" : cag.Agent_Alley.IndexOf('.') >= 1 ? cag.Agent_Alley.Split('.')[1] == "-" ? "" : " " + cag.Agent_Alley : "";
                                Address += string.IsNullOrEmpty(cag.Agent_Road) ? "" : cag.Agent_Road.IndexOf('.') >= 1 ? cag.Agent_Road.Split('.')[1] == "-" ? "" : " " + cag.Agent_Road : "";
                                Address += string.IsNullOrEmpty(cag.Agent_Subdistrict) ? "" : cag.Agent_Subdistrict.IndexOf('.') >= 1 ? cag.Agent_Subdistrict.Split('.')[1] == "-" ? "" : " " + cag.Agent_Subdistrict : "";
                                Address += string.IsNullOrEmpty(cag.Agent_District) ? "" : cag.Agent_District.IndexOf('.') >= 1 ? cag.Agent_District.Split('.')[1] == "-" ? "" : " " + cag.Agent_District : "";
                                Address += string.IsNullOrEmpty(cag.cag_pv.Province_name) ? "" : " จ." + cag.cag_pv.Province_name;

                                string ogn_code = CryptographyCode.GenerateSHA512String(cag.Agent_Idcard);
                        %>
                        <tr>
                            <td style="text-align: center;"><%= row_str + i + 1 %></td>
                            <td style="text-align: center;"><%= cag.Agent_Idcard %></td>
                            <td><%= cag.Agent_Fname + " " + cag.Agent_Lname %></td>
                            <td><%= Address %></td>
                            <td><%= cag.Agent_Status_name %></td>
                            <td>
                                <a class="btn btn-xs btn-warning btn-block" href="Agents_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, cag.Agent_Idcard, "") %>" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit"></i> </a>
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
