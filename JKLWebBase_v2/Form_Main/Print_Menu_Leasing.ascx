<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Print_Menu_Leasing.ascx.cs" Inherits="JKLWebBase_v2.Form_Main.Print_Menu_Leasing" %>

<asp:Panel ID="Print_Menu_panel" runat="server">
    <div class="panel panel-primary">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:LinkButton ID="Print_Front_Card" runat="server" CssClass="btn btn-sm btn-primary"> <i class="fa fa-print fa-fw"></i> พิมพ์หน้าการ์ด </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_Payment_Schedule" runat="server" CssClass="btn btn-sm btn-primary"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (แม่แบบ) </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_Full_Payment_Schedule" runat="server" CssClass="btn btn-sm btn-primary"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (เต็ม) </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_Half_Payment_Schedule" runat="server" CssClass="btn btn-sm btn-primary"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (อักษรลอย) </asp:LinkButton>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:LinkButton ID="Print_SH" runat="server" CssClass="btn btn-sm btn-success"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ซ.1 </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_KH1" runat="server" CssClass="btn btn-sm btn-success"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ข.1 </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_KH2" runat="server" CssClass="btn btn-sm btn-success"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ข.2 </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_P_NG_D_3" runat="server" CssClass="btn btn-sm btn-warning"> <i class="fa fa-print fa-fw"></i> พิมพ์ใบหัก ณ ที่จ่าย </asp:LinkButton>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:LinkButton ID="Print_Half_Certified" runat="server" CssClass="btn btn-sm btn-info"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือรับรองการเช่าซื้อ (อักษรลอย) </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_Half_Confirm" runat="server" CssClass="btn btn-sm btn-info"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือยืนยันการชำระเงิน (อักษรลอย) </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_Full_Certified" runat="server" CssClass="btn btn-sm btn-info"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือรับรองการเช่าซื้อ (เต็ม) </asp:LinkButton>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="Print_Full_Confirm" runat="server" CssClass="btn btn-sm btn-info"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือยืนยันการชำระเงิน (เต็ม) </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
