<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Print_Menu_Leasing.ascx.cs" Inherits="JKLWebBase_v2.Form_Main.Print_Menu_Leasing" %>

<asp:Panel ID="Print_Menu_panel" runat="server">
    <div class="panel panel-primary">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:HyperLink ID="Print_Front_Card" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary" NavigateUrl="/Reports/Leasings/Front_Card/Front_Card_Prv" >พิมพ์หน้าการ์ด</asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Payment_Schedule" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary" NavigateUrl="/Reports/Leasings/Payment_Schedule/Payment_Schedule_Prv"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (แม่แบบ) </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Full_Payment_Schedule" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary" NavigateUrl="/Reports/Leasings/Payment_Schedule/Payment_Schedule_Prv"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (เต็ม) </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Half_Payment_Schedule" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary" NavigateUrl="/Reports/Leasings/Payment_Schedule/Payment_Schedule_Prv"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (อักษรลอย) </asp:HyperLink>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:HyperLink ID="Print_SH" runat="server" Target="_blank" CssClass="btn btn-sm btn-success" NavigateUrl="/Reports/Leasings/Leasing_SH1/Car_Leasing_SH1_P1"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ซ.1 </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_KH1" runat="server" Target="_blank" CssClass="btn btn-sm btn-success" NavigateUrl="/Reports/Leasings/Leasing_KH1/Car_Leasing_KH1_P1"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ข.1 </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_KH2" runat="server" Target="_blank" CssClass="btn btn-sm btn-success" NavigateUrl="/Reports/Leasings/Leasing_KH2/Car_Leasing_KH2_P1"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ข.2 </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_P_NG_D_3" runat="server" Target="_blank" CssClass="btn btn-sm btn-warning" > <i class="fa fa-print fa-fw"></i> พิมพ์ใบหัก ณ ที่จ่าย </asp:HyperLink>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:HyperLink ID="Print_Half_Certified" runat="server" Target="_blank" CssClass="btn btn-sm btn-info" NavigateUrl="/Reports/Leasings/Certified_Leasing/Certified_Leasing_Half"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือรับรองการเช่าซื้อ (อักษรลอย) </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Half_Confirm" runat="server" Target="_blank" CssClass="btn btn-sm btn-info" NavigateUrl="/Reports/Leasings/Confirm_Payment/Confirm_Payment_Half"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือยืนยันการชำระเงิน (อักษรลอย) </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Full_Certified" runat="server" Target="_blank" CssClass="btn btn-sm btn-info" NavigateUrl="/Reports/Leasings/Certified_Leasing/Certified_Leasing_Full"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือรับรองการเช่าซื้อ (เต็ม) </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Full_Confirm" runat="server" Target="_blank" CssClass="btn btn-sm btn-info" NavigateUrl="/Reports/Leasings/Confirm_Payment/Confirm_Payment_Full"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือยืนยันการชำระเงิน (เต็ม) </asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
