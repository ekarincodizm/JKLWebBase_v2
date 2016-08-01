﻿<%@ Page Title="Login_Test" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JKLWebBase_v2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %>- My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/bootstrap/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3> <span class="fa fa-sign-in fa-fw"></span> เข้าสู่ระบบ JKL Web App </h3>
                    </div>
                    <div class="panel-body">
                        <fieldset>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label"><h5>Username</h5></asp:Label>
                                    <asp:TextBox runat="server" ID="Username" CssClass="form-control" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label"><h5>Password</h5></asp:Label>
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                </div>

                                <!-- Change this to a button or input when using this as a form -->
                                <div class="col-xs-4 col-md-offset-4">
                                    <asp:Button runat="server" ID="btn_Login" Text="Log in" CssClass="btn btn-lg btn-success btn-block" OnClick="btn_Login_Click" />
                                </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
