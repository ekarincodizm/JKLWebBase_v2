<%@ Page Title="จัดการข้อมูลระยะการชำระ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Total_Payment_Management.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Total_Payment_Management" %>


<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>จัดการข้อมูลระยะการชำระ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Value_1_Lbl" runat="server"> ระยะการชำระ </asp:Label>
                    <asp:TextBox ID="Value_1_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Save_Btn_Click"><i class="fa fa-save fa-fw"></i> เพิ่ม </asp:LinkButton>
                </div>
            </div>

            <hr>

            <%
                if (Session["List_Base_Total_Payment"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th > ระยะการชำระ </th>
                            <th style="width: 5%;"></th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Base_Total_Payment> list_data = (List<Base_Total_Payment>)Session["List_Base_Total_Payment"];

                            for (int i = 0; i < list_data.Count; i++)
                            {
                                Base_Total_Payment bs_data = list_data[i];

                                string ogn_code = CryptographyCode.GenerateSHA512String(bs_data.Total_payment_id.ToString());
                        %>
                        <tr>
                            <td><%= bs_data.Total_payment_name %></td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-warning" href="/Form_Base/Base_Car_Brands_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_data.Total_payment_id.ToString()) %>&mode=e" target="_parent" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit fa-fw"></i></a>
                            </td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-danger" href="/Form_Base/Base_Car_Brands_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_data.Total_payment_id.ToString()) %>&mode=r" target="_parent" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
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