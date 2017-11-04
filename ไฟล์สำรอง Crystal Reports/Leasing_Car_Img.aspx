<%@ Page Title="เพิ่มรูปรถ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Car_Img.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Add_Car_Img" %>

<%@ Register TagPrefix="nav_menu" TagName="Tab_Menu" Src="Tabs_Menu_Leasings.ascx" %>

<%@ Register TagPrefix="print_menu_leasing" TagName="Print_Menu" Src="Print_Menu_Leasing.ascx" %>

<%@ Import Namespace="JKLWebBase_v2.Class_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Managers_Leasings" %>
<%@ Import Namespace="JKLWebBase_v2.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Print Menu Button -->
    <print_menu_leasing:Print_Menu ID="Print_Menu1" runat="server" />

    <!-- ./Print Menu Button -->

    <!-- Alert MessagesBox -->
    <div class="row">
        <asp:Panel ID="Alert_Danger_Panel" runat="server" Visible="false">
            <div class="col-md-7 col-md-offset-3">
                <div class="alert alert-warning" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="glyphicon glyphicon-remove fa-fw"></i></span>
                    </button>
                    <div class="modal-header">
                        <h6 class="modal-title"><i class="fa fa-warning fa-fw"></i>
                            <asp:Label ID="alert_header_danger_Lbl" runat="server"> </asp:Label>
                        </h6>
                    </div>
                    <div class="modal-body">
                        <p>
                            <asp:Label ID="alert_danger_Lbl" runat="server"> </asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="Alert_Success_Panel" runat="server" Visible="false">
            <div class="col-md-7 col-md-offset-3">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true"><i class="glyphicon glyphicon-remove fa-fw"></i></span>
                    </button>
                    <div class="modal-header">
                        <h6 class="modal-title"><i class="fa fa-thumbs-o-up fa-fw"></i>
                            <asp:Label ID="alert_header_success_Lbl" runat="server"> </asp:Label>
                        </h6>
                    </div>
                    <div class="modal-body">
                        <p>
                            <asp:Label ID="alert_success_Lbl" runat="server"> </asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <!-- Alert MessagesBox -->

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
                    <%
                        if (Session["list_cls_photo"] != null)
                        {
                            List<Car_Leasings_Photo> list_cls_photo = (List<Car_Leasings_Photo>)Session["list_cls_photo"];
                            int col = 1;
                            for (int i = 0; i < list_cls_photo.Count; i++)
                            {
                                Car_Leasings_Photo cls_photo = list_cls_photo[i];

                                string ogn_code = CryptographyCode.GenerateSHA512String(cls_photo.Leasing_id);

                    %>
                    <%= (i % 4) == 0 ? "<div class='row'>" : "" %>
                    <div class="form-group col-xs-6 col-sm-3">
                        <a class="btn btn-danger right" href="Leasing_Car_Img_Remove?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, cls_photo.Leasing_id, cls_photo.Car_img_num.ToString()) %>" data-toggle="tooltip" data-placement="left" title="ลบ"><i class="fa fa-trash-o"></i></a>
                        <img alt="<%=cls_photo.Car_img_old_name %>" src="<%= string.IsNullOrEmpty(cls_photo.Car_img_path)? "../Images_web/default-img.jpg" : cls_photo.Car_img_path %>" width="100%" height="250px" />
                    </div>
                    <%= col == 4? "</div>" : "" %>
                    <%
                                if (col == 4) { col = 1; } else { col++; }
                            }
                        }
                    %>
                </div>
                <!-- /.รูปรถ -->

            </div>
        </div>
    </div>
</asp:Content>
