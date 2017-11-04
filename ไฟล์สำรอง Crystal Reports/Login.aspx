<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JKLWebBase_v2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %></title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Styles.Render("~/Content/bootstrap/css") %>
    </asp:PlaceHolder>
    <!--<webopt:bundlereference runat="server" path="~/Content/bootstrap/css" />-->
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">

            <!-- Alert MessagesBox -->
            <asp:Panel ID="Alert_Warning_Panel" runat="server" Visible="false" CssClass="login-panel">
                <div class="col-md-7 col-md-offset-3">
                    <div class="alert alert-warning" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true"><i class="glyphicon glyphicon-remove fa-fw"></i></span>
                        </button>
                        <div class="modal-header">
                            <h6 class="modal-title"><i class="fa fa-warning fa-fw"></i>!! แจ้งเตือน !! </h6>
                        </div>
                        <div class="modal-body">
                            <p>
                                <asp:Label ID="alert_warning_Lbl" runat="server"> ** กรุณาติดต่อฝ่าย IT เพื่อขอใช้งานการเข้าโปรแกรม ** </asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <!-- Alert MessagesBox -->

            <asp:Panel ID="Login_panel" runat="server">
                <div class="row">
                    <div class="col-md-7 col-md-offset-3">
                        <div class="login-panel panel panel-primary">
                            <div class="panel-heading">
                                <h3><strong><span class="fa fa-sign-in fa-fw"></span>เข้าสู่ระบบ JaiKwang Financial Management System </strong></h3>
                            </div>
                            <div class="panel-body">
                                <p>
                                    <asp:Label ID="alert_danger_Lbl" runat="server" Visible="false" ForeColor="Red"> ชื่อผู้ใช้งาน ถูกระงับการใช้งานชั่วคราว กรุณาติดต่อเจ้าหน้าที่ฝ่าย IT </asp:Label>
                                </p>
                                <fieldset>
                                    <div class="form-group">
                                        <asp:Label runat="server" CssClass="col-md-2 control-label"><h5> Username  </h5></asp:Label>
                                        <asp:TextBox runat="server" ID="Username_TBx" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" CssClass="col-md-2 control-label"><h5>  Password  </h5></asp:Label>
                                        <asp:TextBox runat="server" ID="Password_TBx" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <!-- Change this to a button or input when using this as a form -->
                                    <div class="col-xs-6 col-md-offset-3">
                                        <asp:Button runat="server" ID="btn_Login" Text="Log in" CssClass="btn btn-lg btn-success btn-block" OnClick="btn_Login_Click" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

        </div>
    </form>

</body>
</html>
