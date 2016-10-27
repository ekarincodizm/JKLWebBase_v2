<%@ Page Title="เพิ่มรูปรถ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Leasing_Car_Img.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Add_Car_Img" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header"> เพิ่มรูปรถ </h1>
    </div>
    <ul class="nav nav-tabs">
      <li role="presentation" ><asp:LinkButton ID="link_Customer_Add" runat="server"  ><i class="fa fa-male fa-fw"></i> ผู้ทำสัญญา </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Leasing_Add" runat="server" ><i class="fa fa-book fa-fw"></i> สัญญาเช่า - ซื้อ </asp:LinkButton></li>
      <li role="presentation" class="active"><asp:LinkButton ID="link_Dealers_Add" runat="server" ><i class="fa fa-male fa-fw"></i> นายหน้า </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_1" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 1</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_2" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 2</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_3" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 3</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_4" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 4</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_5" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 5</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Car_Img" runat="server" ><i class="fa fa-car fa-fw"></i>รูปรถ</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Home_Img" runat="server" ><i class="fa fa-home fa-fw"></i> รูปบ้าน</asp:LinkButton></li>
    </ul>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
               
                <!-- ข้อมูลนายหน้า -->
                <div class="panel-heading">
                    ข้อมูลนายหน้า
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_idcard_Lbl" runat="server" >เลขบัตรประชาชน</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Dealer_idcard_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                <asp:LinkButton ID="Dealer_search_Btn" runat="server" CssClass="input-group-addon"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_fname_Lbl" runat="server" >ชื่อ</asp:Label>
                            <asp:TextBox ID="Dealer_fname_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_lname_Lbl" runat="server" >นามสกุล</asp:Label>
                            <asp:TextBox ID="Dealer_lname_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_address_no_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="Dealer_address_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Dealer_vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                            <asp:TextBox ID="Dealer_vilage_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_alley_Lbl" runat="server" >ซอย</asp:Label>
                            <asp:TextBox ID="Dealer_alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_road_Lbl" runat="server" >ถนน</asp:Label>
                            <asp:TextBox ID="Dealer_road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Dealer_subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_district_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                            <asp:TextBox ID="Dealer_district_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_province_Lbl" runat="server" >จังหวัด</asp:Label>
                            <asp:DropDownList ID="Dealer_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_country_Lbl" runat="server" >ประเทศ</asp:Label>
                            <asp:TextBox ID="Dealer_country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Dealer_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_receive_Lbl" runat="server" >ค่านายหน้า</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Dealer_receive_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Label1" runat="server" >หัก ณ ที่จ่าย</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">%</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Label2" runat="server" >ค่าหัก ณ ที่จ่าย</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Label3" runat="server" >ค่านายหน้าสุทธิ</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Label4" runat="server" >เล่มที่</asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Label5" runat="server" >เลขใบหักภาษี ณ ที่จ่าย</asp:Label>
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลนายหน้า -->

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:LinkButton ID="Dealer_Add_Save_Btn" runat="server" CssClass="btn btn-default btn-primary btn_block" OnClick="Dealer_Add_Save_Btn_Click" ><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>