<%@ Page Title="เพิ่มรูปบ้าน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Leasing_Home_Img.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Home_Img" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h4 class="page-header"> เพิ่มรูปบ้าน </h4>
    </div>
    <ul class="nav nav-tabs">
      <li role="presentation" ><asp:LinkButton ID="link_Customer_Add" runat="server"  ><i class="fa fa-male fa-fw"></i> ผู้ทำสัญญา </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Leasing_Add" runat="server" ><i class="fa fa-book fa-fw"></i> สัญญาเช่า - ซื้อ </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Dealers_Add" runat="server" ><i class="fa fa-male fa-fw"></i> นายหน้า </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_1" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 1</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_2" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 2</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_3" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 3</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_4" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 4</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_5" runat="server" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 5</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Car_Img" runat="server" ><i class="fa fa-car fa-fw"></i>รูปรถ</asp:LinkButton></li>
      <li role="presentation" class="active" ><asp:LinkButton ID="link_Add_Home_Img" runat="server" ><i class="fa fa-home fa-fw"></i> รูปบ้าน</asp:LinkButton></li>
    </ul>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
               
                <!-- Modal -->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div class="modal-dialog modal-md" role="document">
                    <div class="modal-content">
                      <div class="modal-header-popup">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><i class="fa fa-remove fa-fw"></i></button>
                        <h4 class="modal-title" id="myModalLabel"> เพิ่มรูปบ้าน </h4>
                      </div>
                      <div class="modal-body">
                        <div class="row">
                            <div class="form-group col-xs-6">
                                <asp:Label ID="Photo_Home_1" runat="server" >รูปที่ 1</asp:Label>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                            <div class="col-xs-6">
                                <asp:Label ID="Label1" runat="server" >รูปที่ 2</asp:Label>
                                <asp:FileUpload ID="FileUpload2" runat="server" />
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="form-group col-xs-6">
                                <asp:Label ID="Label2" runat="server" >รูปที่ 3</asp:Label>
                                <asp:FileUpload ID="FileUpload3" runat="server" />
                            </div>
                            <div class="col-xs-6">
                                <asp:Label ID="Label3" runat="server" >รูปที่ 4</asp:Label>
                                <asp:FileUpload ID="FileUpload4" runat="server" />
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="form-group col-xs-6">
                                <asp:Label ID="Label4" runat="server" >รูปที่ 5</asp:Label>
                                <asp:FileUpload ID="FileUpload5" runat="server" />
                            </div>
                            <div class="col-xs-6">
                                <asp:Label ID="Label5" runat="server" >รูปที่ 6</asp:Label>
                                <asp:FileUpload ID="FileUpload6" runat="server" />
                            </div>
                        </div> 
                        <hr />
                        <div class="row">
                            <div class="form-group col-xs-6">
                                <asp:Label ID="Label6" runat="server" >รูปที่ 7</asp:Label>
                                <asp:FileUpload ID="FileUpload7" runat="server" />
                            </div>
                            <div class="col-xs-6">
                                <asp:Label ID="Label7" runat="server" >รูปที่ 8</asp:Label>
                                <asp:FileUpload ID="FileUpload8" runat="server" />
                            </div>
                        </div> 
                        <hr />
                        <div class="row">
                            <div class="form-group col-xs-6">
                                <asp:Label ID="Label8" runat="server" >รูปที่ 9</asp:Label>
                                <asp:FileUpload ID="FileUpload9" runat="server" />
                            </div>
                            <div class="col-xs-6">
                                <asp:Label ID="Label9" runat="server" >รูปที่ 10</asp:Label>
                                <asp:FileUpload ID="FileUpload10" runat="server" />
                            </div>
                        </div>  
                    </div>
                      <div class="modal-footer">
                        <asp:LinkButton ID="LinkButton9" runat="server" CssClass="btn btn-primary btn_block"><i class="fa fa-upload fa-fw"></i> Upload </asp:LinkButton>
                      </div>
                    </div>
                  </div>
                </div>
                <!-- /.Modal -->

                <!-- รูปบ้าน -->
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-12">
                            <h6> <strong> รูปบ้าน </strong> <button type="button" class="btn btn-sm btn-info" data-toggle="modal" data-target="#myModal" style="float: right"><i class="fa fa-upload fa-fw"></i><i class="fa fa-image fa-fw"></i> เพิ่มรูปบ้าน </button> </h6>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%"/>
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%"/>
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%"/>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%"/>
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%"/>
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton7" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%"/>
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%"/>
                        </div>
                    </div>
                </div>
                <!-- /.รูปบ้าน -->

                <hr />

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:LinkButton ID="Home_Img_Save_Btn" runat="server" CssClass="btn btn-md btn-primary btn_block"><i class="fa fa-save fa-fw"></i> บันทึก </asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>