﻿<%@ Page Title="เพิ่มรูปรถ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Car_Img.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Add_Car_Img" %>

<%@ Register TagPrefix="nav_menu" TagName="Tab_Menu" Src="Tabs_Menu_Leasings.ascx" %>

<%@ Register TagPrefix="print_menu_leasing" TagName="Print_Menu" Src="Print_Menu_Leasing.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Print Menu Button -->
    <print_menu_leasing:Print_Menu id="Print_Menu1" runat="server" />

    <!-- ./Print Menu Button -->

    <div class="col-lg-12">
        <h4 class="page-header">เพิ่มรูปรถ </h4>
    </div>

    <!-- Tab MenuBar -->
    <nav_menu:Tab_Menu ID="nav_tabs" runat="server" />

    <!-- ./Tab MenuBar -->

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">

                <!-- Modal -->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-md" role="document">
                        <div class="modal-content">
                            <div class="modal-header-popup">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><i class="fa fa-remove fa-fw"></i></button>
                                <h4 class="modal-title" id="myModalLabel">เพิ่มรูปรถ </h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_1_Lbl" runat="server">รูปที่ 1
                                            <asp:RegularExpressionValidator ID="Car_img_1_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_1" runat="server" />

                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Label ID="Car_img_2_Lbl" runat="server">รูปที่ 2
                                            <asp:RegularExpressionValidator ID="Car_img_2_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_2" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_2" runat="server" />
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_3_Lbl" runat="server">รูปที่ 3
                                            <asp:RegularExpressionValidator ID="Car_img_3_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_3" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_3" runat="server" />
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Label ID="Car_img_4_Lbl" runat="server">รูปที่ 4
                                            <asp:RegularExpressionValidator ID="Car_img_4_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_4" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_4" runat="server" />
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_5_Lbl" runat="server">รูปที่ 5
                                            <asp:RegularExpressionValidator ID="Car_img_5_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_5" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_5" runat="server" />
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Label ID="Car_img_6_Lbl" runat="server">รูปที่ 6
                                            <asp:RegularExpressionValidator ID="Car_img_6_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_6" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_6" runat="server" />
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_7_Lbl" runat="server">รูปที่ 7
                                            <asp:RegularExpressionValidator ID="Car_img_7_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_7" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_7" runat="server" />
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Label ID="Car_img_8_Lbl" runat="server">รูปที่ 8
                                            <asp:RegularExpressionValidator ID="Car_img_8_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_8" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_8" runat="server" />
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_9_Lbl" runat="server">รูปที่ 9
                                            <asp:RegularExpressionValidator ID="Car_img_9_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_9" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_9" runat="server" />
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Label ID="Car_img_10_Lbl" runat="server">รูปที่ 10
                                            <asp:RegularExpressionValidator ID="Car_img_10_REV" CssClass="text-danger" runat="server" ErrorMessage=" นามสกุลไฟล์ ไม่ถูกต้องตามรูปแบบ (*.png, *.jpg, *.gif, *.jpeg) " ControlToValidate="Car_img_10" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$"> </asp:RegularExpressionValidator>
                                        </asp:Label>
                                        <asp:FileUpload ID="Car_img_10" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:LinkButton ID="Upload_Btn" runat="server" CssClass="btn btn-primary btn_block" OnClick="Upload_Btn_Click"><i class="fa fa-upload fa-fw"></i> Upload </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.Modal -->

                <!-- รูปรถ -->
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-12">
                            <h6><strong>รูปรถ </strong>
                                <button type="button" class="btn btn-sm btn-success" data-toggle="modal" data-target="#myModal" style="float: right"><i class="fa fa-upload fa-fw"></i><i class="fa fa-image fa-fw"></i>เพิ่มรูปรถ </button>
                            </h6>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton9" runat="server" CssClass="btn btn-success left" ><i class="fa fa-download fa-fw"></i> download </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i> remove </asp:LinkButton>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton7" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                        <div class="col-xs-6 col-sm-3">
                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="btn btn-danger right"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images_web/default-img.jpg" Width="100%" />
                        </div>
                    </div>
                </div>
                <!-- /.รูปรถ -->

            </div>
        </div>
    </div>
</asp:Content>
