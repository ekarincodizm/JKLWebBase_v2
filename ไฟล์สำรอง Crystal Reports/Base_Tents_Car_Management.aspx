<%@ Page Title="จัดการข้อมูลเต็นท์รถ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Tents_Car_Management.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Tents_Car_Management" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>จัดการข้อมูลเต็นท์รถ </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="Tent_name_Lbl" runat="server"> ชื่อเต็นท์รถ </asp:Label>
                    <asp:TextBox ID="Tent_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-9">
                    <asp:Label ID="Tent_local_Lbl" runat="server"> ที่อยู่เต็นท์รถ </asp:Label>
                    <asp:TextBox ID="Tent_local_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Save_Btn_Click"><i class="fa fa-save fa-fw"></i> บันทึก </asp:LinkButton>
                </div>
            </div>

            <hr>

            <%
                if (Session["List_Base_Tents_Car"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th > ชื่อเต็นท์รถ </th>
                            <th > ที่อยู่เต็นท์รถ </th>
                            <th style="width: 5%;"></th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Base_Tents_Car> list_data = (List<Base_Tents_Car>)Session["List_Base_Tents_Car"];

                            for (int i = 0; i < list_data.Count; i++)
                            {
                                Base_Tents_Car bs_data = list_data[i];

                                string ogn_code = CryptographyCode.GenerateSHA512String(bs_data.Tent_car_id.ToString());
                        %>
                        <tr>
                            <td><%= bs_data.Tent_name %></td>
                            <td><%= bs_data.Tent_local %></td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-warning" href="/Form_Base/Base_Tents_Car_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_data.Tent_car_id.ToString()) %>&mode=e" target="_parent" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit fa-fw"></i></a>
                            </td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-danger" href="/Form_Base/Base_Tents_Car_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_data.Tent_car_id.ToString()) %>&mode=r" target="_parent" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
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
