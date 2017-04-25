<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Load_Data_Leasings_From_MSSQL.aspx.cs" Inherits="JKLWebBase_v2.Form_Account.Load_Data_From_MSSQL" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="link_load_customers" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="link_load_customers_Click"> <i class="fa fa-download fa-fw"></i>  โหลดข้อมูลผู้ทำสัญญา </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="link_load_leasings_no_customer" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="link_load_leasings_no_customer_Click"> <i class="fa fa-download fa-fw"></i> โหลดข้อมูลสัญญาเช่า - ซื้อไม่มีผู้ทำสัญญา </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="link_load_leasings" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="link_load_leasings_Click"> <i class="fa fa-download fa-fw"></i> โหลดข้อมูลสัญญาเช่า - ซื้อ </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="link_load_paymnet" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="link_load_paymnet_Click"> <i class="fa fa-download fa-fw"></i> โหลดข้อมูลการชำระเงิน </asp:LinkButton>
                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="link_load_guarantor_1" runat="server" Target="_blank" CssClass="btn btn-sm btn-info btn-block" OnClick="link_load_guarantor_1_Click"> <i class="fa fa-download fa-fw"></i>  โหลดข้อมูลผู้ค้ำประกัน 1 </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="link_load_guarantor_2" runat="server" Target="_blank" CssClass="btn btn-sm btn-info btn-block" OnClick="link_load_guarantor_2_Click"> <i class="fa fa-download fa-fw"></i> โหลดข้อมูลผู้ค้ำประกัน 2 </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="link_load_guarantor_3" runat="server" Target="_blank" CssClass="btn btn-sm btn-info btn-block" OnClick="link_load_guarantor_3_Click"> <i class="fa fa-download fa-fw"></i> โหลดข้อมูลผู้ค้ำประกัน 3 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <asp:TextBox ID="Messages_TBx" runat="server" TextMode="MultiLine" Rows="20" Width="100%"></asp:TextBox>
        </div>
    </div>
</asp:Content>
