<%@ Page Title="ค้นหาข้อมูลผู้ใช้งาน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account_Search.aspx.cs" Inherits="JKLWebBase_v2.Form_Account.Account_Search" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Account" %>
<%@ Import Namespace="JKLWebBase_v2.Manager_Account" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>
<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>ค้นหาผู้ใช้งาน </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="Username_md_Lbl" runat="server"> ชื่อผู้ใช้งาน </asp:Label>
                    <asp:TextBox ID="Username_md_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Label ID="Account_F_name_Lbl" runat="server"> ชื่อ - นามสกุล </asp:Label>
                    <asp:TextBox ID="Account_F_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Label ID="Account_Idcard_Lbl" runat="server"> รหัสบัตรประชาชน </asp:Label>
                    <asp:TextBox ID="Account_Idcard_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="Company_Lbl" runat="server" CssClass="checkbox">สาขา
                        <asp:CheckBox ID="Company_ChkBxL_All" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="Company_ChkBxL_All_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="Company_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="10">
                    </asp:CheckBoxList>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-12">
                    <asp:Label ID="level_Lbl" runat="server" CssClass="checkbox">ตำแหน่ง
                        <asp:CheckBox ID="level_ChkBxL_ALL" runat="server" Text="เลือกทั้งหมด" ForeColor="Red" OnCheckedChanged="level_ChkBxL_ALL_CheckedChanged" AutoPostBack="true" />
                    </asp:Label>
                    <asp:CheckBoxList ID="level_ChkBxL" runat="server" RepeatDirection="Horizontal" CssClass="checkbox" RepeatColumns="4">
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
                if (Session["List_Account"] != null)
                {
                    Base_Companys package_login = (Base_Companys)Session["Package"];
                    Account_Login acc_lgn_lv = (Account_Login)Session["Login"];
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="width: 5%;"># </th>
                            <th style="width: 25%;">ชื่อผู้ใช้งาน </th>
                            <th style="width: 20%;">ชื่อ - นามสกุล </th>
                            <th style="width: 20%;">ตำแหน่ง </th>
                            <th style="width: 10%;">วันที่</th>
                            <th style="width: 10%;">สถานะ</th>
                            <% if (acc_lgn_lv.acc_lv.level_access == 9) { %>
                            <th style="width: 5%;"></th>
                            <% } %>
                            <th style="width: 5%;"></th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Account_Login> list_data = (List<Account_Login>)Session["List_Account"];
                            int row_str = (int)Session["row_str"];

                            for (int i = 0; i < list_data.Count; i++)
                            {
                                Account_Login acc_lgn = list_data[i];

                                string ogn_code = CryptographyCode.GenerateSHA512String(acc_lgn.Account_id);
                        %>
                        <tr>

                            <td><%= row_str + i + 1 %></td>
                            <td><%= acc_lgn.resu %></td>
                            <td><%= acc_lgn.Account_F_name %></td>
                            <td><%= acc_lgn.acc_lv.level_name_TH + " ( "  + acc_lgn.acc_lv.level_name_ENG + " )" %></td>
                            <td><%= DateTimeUtility.convertDateToPageRealServer(acc_lgn.Account_Save_Date) %></td>
                            <td>
                                <% 
                                    if (acc_lgn.Account_status == 3 || acc_lgn.Account_status == 0)
                                    {
                                        Response.Write("<label class='label label-danger' > ลาออก </label>");
                                    }
                                    else if (acc_lgn.Account_status == 2)
                                    {
                                        Response.Write("<label class='label label-warning' > ห้ามใช้งานชั่วคราว </label>");
                                    }
                                    else if (acc_lgn.Account_status == 1)
                                    {
                                        Response.Write("<label class='label label-success' >  ปกติ  </label>");
                                    }
                                %>
                            </td>
                            <% if (acc_lgn_lv.acc_lv.level_access == 9) { %>
                            <td>
                                <a class="btn btn-xs btn-info" href="Activity_Log_Prv?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, acc_lgn.Account_id) %>" data-toggle="tooltip" data-placement="top" title="Logs"><i class="fa fa-list-alt fa-fw"></i></a>
                            </td>
                            <% } %>
                            <td>
                                <a class="btn btn-xs btn-warning" href="Account_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, acc_lgn.Account_id) %>&mode=e" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit"></i></a>
                            </td>
                            <td>
                                <a class="btn btn-xs btn-danger" href="Account_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, acc_lgn.Account_id) %>&mode=r" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
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
