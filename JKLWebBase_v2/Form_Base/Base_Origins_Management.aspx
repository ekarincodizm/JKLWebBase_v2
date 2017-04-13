<%@ Page Title="จัดการข้อมูลเชื้อชาติ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Origins_Management.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Origins_Management" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>จัดการข้อมูลเชื้อชาติ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="Origin_name_ENG_Lbl" runat="server"> ชื่อเชื้อชาติภาษาอังกฤษ </asp:Label>
                    <asp:TextBox ID="Origin_name_ENG_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Label ID="Origin_name_TH_Lbl" runat="server"> ชื่อเชื้อชาติภาษาไทย </asp:Label>
                    <asp:TextBox ID="Origin_name_TH_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Save_Btn_Click"><i class="fa fa-save fa-fw"></i> บันทึก </asp:LinkButton>
                </div>
            </div>

            <hr>

            <%
                if (Session["List_Base_Origin"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th > ชื่อเชื้อชาติภาษาอังกฤษ </th>
                            <th > ชื่อเชื้อชาติภาษาไทย </th>
                            <th style="width: 5%;"></th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Base_Origins> list_bs_ntn = (List<Base_Origins>)Session["List_Base_Origin"];

                            for (int i = 0; i < list_bs_ntn.Count; i++)
                            {
                                Base_Origins bs_ntn = list_bs_ntn[i];

                                string ogn_code = CryptographyCode.GenerateSHA512String(bs_ntn.Origin_id.ToString());
                        %>
                        <tr>
                            <td><%= bs_ntn.Origin_name_ENG %></td>
                            <td><%= bs_ntn.Origin_name_TH %></td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-warning" href="/Form_Base/Base_Origins_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_ntn.Origin_id.ToString()) %>&mode=e" target="_parent" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit fa-fw"></i></a>
                            </td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-danger" href="/Form_Base/Base_Origins_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_ntn.Origin_id.ToString()) %>&mode=r" target="_parent" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
                            </td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>
            <%  
                }
            %>
        </div>
    </div>

</asp:Content>
