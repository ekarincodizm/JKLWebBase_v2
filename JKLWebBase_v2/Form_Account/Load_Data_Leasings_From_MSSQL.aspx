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

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-grou col-md-3">
                                <asp:LinkButton ID="link_load_paymnet" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="link_load_paymnet_Click"> <i class="fa fa-download fa-fw"></i> โหลดข้อมูลการชำระเงิน </asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-lg-12">
                            <div class="form-group col-xs-3">
                                <asp:Label ID="Recond_Amount_Lbl" runat="server"> จำนวนข้อมูลสัญญา (Rows) </asp:Label>
                                <asp:TextBox ID="Recond_Amount_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Leasing_id_Lbl" runat="server"> ค้นหาตำแหน่งจาก รหัสสัญญา</asp:Label>
                                <asp:TextBox ID="Leasing_id_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Index_of_Lbl" runat="server"> ตำแหน่ง รหัสสัญญา (i) </asp:Label>
                                <asp:TextBox ID="Index_of_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="Search_Index_of_Btn" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="Search_Index_of_Btn_Click"> <i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group col-xs-3">
                                <asp:Label ID="Part_Lbl" runat="server"> Part File </asp:Label>
                                <asp:TextBox ID="Part_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Str_Row_Lbl" runat="server"> ตำแหน่งเริ่ม </asp:Label>
                                <asp:TextBox ID="Str_Row_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="End_Row_Lbl" runat="server"> ตำแหน่งสิ้นสุด </asp:Label>
                                <asp:TextBox ID="End_Row_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="Start_Transfer_data_Btn" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="Start_Transfer_data_Btn_Click"> <i class="fa fa-download fa-fw"></i> เริ่มย้ายข้อมูล </asp:LinkButton>
                            </div>
                            <div class="form-grou col-md-3">
                                <asp:LinkButton ID="link_fix_fine" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" OnClick="link_fix_fine_Click"> <i class="fa fa-download fa-fw"></i> Fix ข้อมูลค่าปรับ </asp:LinkButton>
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
