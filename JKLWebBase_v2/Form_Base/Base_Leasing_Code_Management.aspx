<%@ Page Title="จัดการข้อมูลรหัสลิสซิ่ง" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Leasing_Code_Management.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Leasing_Code_Management" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>จัดการข้อมูลรหัสลิสซิ่ง </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Leasing_code_name_Lbl" runat="server"> โค้ด </asp:Label>
                    <asp:TextBox ID="Leasing_code_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_S_Name_Lbl" runat="server"> ชื่อย่อ</asp:Label>
                    <asp:TextBox ID="Leasing_code_S_Name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Label ID="Leasing_code_F_name_Lbl" runat="server"> ชื่อเต็ม </asp:Label>
                    <asp:TextBox ID="Leasing_code_F_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_code_tax_id_Lbl" runat="server"> รหัสผู้เสียภาษี </asp:Label>
                    <asp:TextBox ID="Leasing_code_tax_id_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_tax_subcode_Lbl" runat="server">รหัสแบ่งสาขา</asp:Label>
                    <asp:TextBox ID="Leasing_code_tax_subcode_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_address_no_Lbl" runat="server">ที่อยู่ เลขที่</asp:Label>
                    <asp:TextBox ID="Leasing_code_address_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_vilage_Lbl" runat="server">หมู่บ้าน</asp:Label>
                    <asp:TextBox ID="Leasing_code_vilage_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_vilage_no_Lbl" runat="server">หมู่ที่</asp:Label>
                    <asp:TextBox ID="Leasing_code_vilage_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_alley_Lbl" runat="server">ซอย</asp:Label>
                    <asp:TextBox ID="Leasing_code_alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Leasing_code_road_Lbl" runat="server">ถนน</asp:Label>
                    <asp:TextBox ID="Leasing_code_road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_code_subdistrict_Lbl" runat="server">ตำบล / แขวง</asp:Label>
                    <asp:TextBox ID="Leasing_code_subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_code_district_Lbl" runat="server">อำเภอ / เขต</asp:Label>
                    <asp:TextBox ID="Leasing_code_district_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_code_province_Lbl" runat="server">จังหวัด</asp:Label>
                    <asp:DropDownList ID="Leasing_code_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_contry_Lbl" runat="server">ประเทศ</asp:Label>
                    <asp:TextBox ID="Leasing_code_contry_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Label ID="Leasing_code_zipcode_Lbl" runat="server">รหัสไปรษณีย์</asp:Label>
                    <asp:TextBox ID="Leasing_code_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Label ID="Leasing_code_tel_Lbl" runat="server">เบอร์์ติดต่อ</asp:Label>
                    <asp:TextBox ID="Leasing_code_tel_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Save_Btn_Click"><i class="fa fa-save fa-fw"></i> เพิ่ม </asp:LinkButton>
                </div>
            </div>

            <hr>

            <%
                if (Session["List_Base_Leasing_Code"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="width: 5%;"> รหัสลิสซิ่ง </th>
                            <th style="width: 10%;"> ชื่อย่อ </th>
                            <th style="width: 20%;"> ชื่อเต็ม </th>
                            <th style="width: 15%;"> รหัสผู้เสียภาษี </th>
                            <th style="width: 5%;"> รหัสแบ่งสาขา </th>
                            <th style="width: 35%;"> ที่อยู่ </th>
                            <th style="width: 5%;"></th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Base_Leasing_Code> list_bs_lscd = (List<Base_Leasing_Code>)Session["List_Base_Leasing_Code"];

                            for (int i = 0; i < list_bs_lscd.Count; i++)
                            {
                                Base_Leasing_Code bs_lscd = list_bs_lscd[i];

                                string Address = "";
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_address_no) ? "" : bs_lscd.Leasing_code_address_no;
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_vilage_no) ? "" : bs_lscd.Leasing_code_vilage_no.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_vilage_no.Split('.')[1] == "-" ? "" : " " + bs_lscd.Leasing_code_vilage_no : "";
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_alley) ? "" : bs_lscd.Leasing_code_alley.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_alley.Split('.')[1] == "-" ? "" : " " + bs_lscd.Leasing_code_vilage : "";
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_alley) ? "" : bs_lscd.Leasing_code_alley.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_alley.Split('.')[1] == "-" ? "" : " " + bs_lscd.Leasing_code_alley : "";
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_road) ? "" : bs_lscd.Leasing_code_road.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_road.Split('.')[1] == "-" ? "" : " " + bs_lscd.Leasing_code_road : "";
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_subdistrict) ? "" : bs_lscd.Leasing_code_subdistrict.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_subdistrict.Split('.')[1] == "-" ? "" : " " + bs_lscd.Leasing_code_subdistrict : "";
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_district) ? "" : bs_lscd.Leasing_code_district.IndexOf('.') >= 1 ? bs_lscd.Leasing_code_district.Split('.')[1] == "-" ? "" : " " + bs_lscd.Leasing_code_district : "";
                                Address += string.IsNullOrEmpty(bs_lscd.Leasing_code_province_name) ? "" : " จ." + bs_lscd.Leasing_code_province_name;

                                string ogn_code = CryptographyCode.GenerateSHA512String(bs_lscd.Leasing_code_id.ToString());
                        %>
                        <tr>
                            <td><%= bs_lscd.Leasing_code_name %></td>
                            <td><%= bs_lscd.Leasing_code_S_Name %></td>
                            <td><%= bs_lscd.Leasing_code_F_Name %></td>
                            <td style="text-align: center;"><%= bs_lscd.Leasing_code_Tax_id %></td>
                            <td style="text-align: center;"><%= bs_lscd.Leasing_code_Tax_subcode %></td>
                            <th > <%= Address %> </th>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-warning" href="/Form_Base/Base_Leasing_Code_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_lscd.Leasing_code_id.ToString()) %>&mode=e" target="_parent" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit fa-fw"></i></a>
                            </td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-danger" href="/Form_Base/Base_Leasing_Code_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_lscd.Leasing_code_id.ToString()) %>&mode=r" target="_parent" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
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
