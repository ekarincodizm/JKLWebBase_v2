<%@ Page Title="จัดการข้อมูลสำนักงาน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Base_Company_Management.aspx.cs" Inherits="JKLWebBase_v2.Form_Base.Base_Company_Management" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Base" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h6>จัดการข้อมูลสำนักงาน </h6>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="form-group col-md-2">
                    <asp:Label ID="Company_code_Lbl" runat="server"> โค้ดสาขา </asp:Label>
                    <asp:TextBox ID="Company_code_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Company_N_name_Lbl" runat="server"> ชื่อย่อสาขา </asp:Label>
                    <asp:TextBox ID="Company_N_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Company_F_name_Lbl" runat="server"> ชื่อเต็มสาขา </asp:Label>
                    <asp:TextBox ID="Company_F_name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Company_tax_id_Lbl" runat="server"> รหัสผู้เสียภาษี </asp:Label>
                    <asp:TextBox ID="Company_tax_id_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <asp:Label ID="Company_tax_subcode_Lbl" runat="server">รหัสแบ่งสาขา</asp:Label>
                    <asp:TextBox ID="Company_tax_subcode_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-md-2">
                    <asp:Label ID="Company_address_no_Lbl" runat="server">ที่อยู่ เลขที่</asp:Label>
                    <asp:TextBox ID="Company_address_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Company_vilage_Lbl" runat="server">หมู่บ้าน</asp:Label>
                    <asp:TextBox ID="Company_vilage_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <asp:Label ID="Company_vilage_no_Lbl" runat="server">หมู่ที่</asp:Label>
                    <asp:TextBox ID="Company_vilage_no_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Company_alley_Lbl" runat="server">ซอย</asp:Label>
                    <asp:TextBox ID="Company_alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Company_road_Lbl" runat="server">ถนน</asp:Label>
                    <asp:TextBox ID="Company_road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label ID="Company_subdistrict_Lbl" runat="server">ตำบล / แขวง</asp:Label>
                    <asp:TextBox ID="Company_subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Company_district_Lbl" runat="server">อำเภอ / เขต</asp:Label>
                    <asp:TextBox ID="Company_district_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Company_province_Lbl" runat="server">จังหวัด</asp:Label>
                    <asp:DropDownList ID="Company_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Company_contry_Lbl" runat="server">ประเทศ</asp:Label>
                    <asp:TextBox ID="Company_contry_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Company_zipcode_Lbl" runat="server">รหัสไปรษณีย์</asp:Label>
                    <asp:TextBox ID="Company_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-md-2">
                    <asp:Label ID="Company_tel_Lbl" runat="server">เบอร์์ติดต่อ</asp:Label>
                    <asp:TextBox ID="Company_tel_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-sm btn-primary btn-block" OnClick="Save_Btn_Click"><i class="fa fa-save fa-fw"></i> บันทึก </asp:LinkButton>
                </div>
            </div>

            <hr>

            <%
                if (Session["List_Base_Companys"] != null)
                {
            %>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th style="width: 5%;">โค้ดสาขา </th>
                            <th style="width: 5%;">ชื่อย่อสาขา </th>
                            <th style="width: 20%;">ชื่อเต็มสาขา </th>
                            <th style="width: 5%;">รหัสผู้เสียภาษี </th>
                            <th style="width: 5%;">รหัสแบ่งสาขา </th>
                            <th style="width: 30%;">ที่อยู่สำนักงาน </th>
                            <th style="width: 10%;">เบอร์์ติดต่อ </th>
                            <th style="width: 5%;"></th>
                            <th style="width: 5%;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            List<Base_Companys> list_bs_cpn = (List<Base_Companys>)Session["List_Base_Companys"];

                            int row_str = (int)Session["row_str"];

                            for (int i = 0; i < list_bs_cpn.Count; i++)
                            {
                                Base_Companys bs_cpn = list_bs_cpn[i];

                                string Address = "";
                                Address += string.IsNullOrEmpty(bs_cpn.Company_address_no) ? "" : bs_cpn.Company_address_no;
                                Address += string.IsNullOrEmpty(bs_cpn.Company_vilage_no) ? "" : bs_cpn.Company_vilage_no.IndexOf('.') >= 1 ? bs_cpn.Company_vilage_no.Split('.')[1] == "-" ? "" : " " + bs_cpn.Company_vilage_no : "";
                                Address += string.IsNullOrEmpty(bs_cpn.Company_alley) ? "" : bs_cpn.Company_alley.IndexOf('.') >= 1 ? bs_cpn.Company_alley.Split('.')[1] == "-" ? "" : " " + bs_cpn.Company_vilage : "";
                                Address += string.IsNullOrEmpty(bs_cpn.Company_alley) ? "" : bs_cpn.Company_alley.IndexOf('.') >= 1 ? bs_cpn.Company_alley.Split('.')[1] == "-" ? "" : " " + bs_cpn.Company_alley : "";
                                Address += string.IsNullOrEmpty(bs_cpn.Company_road) ? "" : bs_cpn.Company_road.IndexOf('.') >= 1 ? bs_cpn.Company_road.Split('.')[1] == "-" ? "" : " " + bs_cpn.Company_road : "";
                                Address += string.IsNullOrEmpty(bs_cpn.Company_subdistrict) ? "" : bs_cpn.Company_subdistrict.IndexOf('.') >= 1 ? bs_cpn.Company_subdistrict.Split('.')[1] == "-" ? "" : " " + bs_cpn.Company_subdistrict : "";
                                Address += string.IsNullOrEmpty(bs_cpn.Company_district) ? "" : bs_cpn.Company_district.IndexOf('.') >= 1 ? bs_cpn.Company_district.Split('.')[1] == "-" ? "" : " " + bs_cpn.Company_district : "";
                                Address += string.IsNullOrEmpty(bs_cpn.Company_province_name) ? "" : " จ." + bs_cpn.Company_province_name;

                                string ogn_code = CryptographyCode.GenerateSHA512String(bs_cpn.Company_id.ToString());
                        %>
                        <tr>
                            <td><%= bs_cpn.Company_code %></td>
                            <td><%= bs_cpn.Company_N_name %></td>
                            <td><%= bs_cpn.Company_F_name %></td>
                            <td style="text-align: center;"><%= bs_cpn.Company_tax_id %></td>
                            <td style="text-align: center;"><%= bs_cpn.Company_tax_subcode %></td>
                            <td><%= Address %></td>
                            <td style="text-align: center;"><%= bs_cpn.Company_tel %></td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-warning" href="/Form_Base/Base_Company_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_cpn.Company_id.ToString()) %>&mode=e" target="_parent" data-toggle="tooltip" data-placement="top" title="แก้ไข"><i class="fa fa-edit fa-fw"></i></a>
                            </td>
                            <td style="text-align: center;">
                                <a class="btn btn-xs btn-danger" href="/Form_Base/Base_Company_Edit?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, bs_cpn.Company_id.ToString()) %>&mode=r" target="_parent" data-toggle="tooltip" data-placement="top" title="ลบ"><i class="fa fa-trash-o fa-fw"></i></a>
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
