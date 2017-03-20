<%@ Page Title="จัดการข้อมูลยี่ห้อรถ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Car_Brands_Management.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Car_Brands_Management" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>จัดการข้อมูลยี่ห้อรถ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Value_1_Lbl" runat="server"> ชื่อยี่ห้อรถภาษาอังกฤษ </asp:Label>
                    <asp:TextBox ID="Value_1_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Value_2_Lbl" runat="server"> ชื่อยี่ห้อรถภาษาไทย </asp:Label>
                    <asp:TextBox ID="Value_2_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Save_Btn_Click"><i class="fa fa-save fa-fw"></i> เพิ่ม </asp:LinkButton>
                </div>
            </div>

            <hr>

            <%
                if (Session["List_Base_Car_Brands"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th > ชื่อยี่ห้อรถภาษาอังกฤษ </th>
                            <th > ชื่อยี่ห้อรถภาษาไทย </th>
                            <th style="width: 5%;"></th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Base_Car_Brands> list_data = (List<Base_Car_Brands>)Session["List_Base_Car_Brands"];

                            for (int i = 0; i < list_data.Count; i++)
                            {
                                Base_Car_Brands bs_data = list_data[i];

                                string ogn_code = CryptographyCode.GenerateSHA512String(bs_data.car_brand_id.ToString());
                        %>
                        <tr>
                            <td><%= bs_data.car_brand_name_eng %></td>
                            <td><%= bs_data.car_brand_name_th %></td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-warning" href="/Form_Base/Base_Car_Brands_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_data.car_brand_id.ToString()) %>&mode=e" target="_parent" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit fa-fw"></i></a>
                            </td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-danger" href="/Form_Base/Base_Car_Brands_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_data.car_brand_id.ToString()) %>&mode=r" target="_parent" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
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