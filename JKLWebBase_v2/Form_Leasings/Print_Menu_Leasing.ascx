﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Print_Menu_Leasing.ascx.cs" Inherits="JKLWebBase_v2.Form_Main.Print_Menu_Leasing" %>

<asp:Panel ID="Print_Menu_panel" runat="server">
    <div class="panel panel-primary">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:HyperLink ID="Print_Front_Card" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" NavigateUrl="/Reports_Leasings/Front_Card/Front_Card_Prv" > <i class="fa fa-print fa-fw"></i>  พิมพ์หน้าการ์ด</asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Payment_Schedule" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" NavigateUrl="/Reports_Leasings/Payment_Schedule/Payment_Schedule_Prv?mod=1"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (แม่แบบ) </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Full_Payment_Schedule" runat="server" Target="_blank" CssClass="btn btn-sm btn-primary btn-block" NavigateUrl="/Reports_Leasings/Payment_Schedule/Payment_Schedule_Prv?mod=2"> <i class="fa fa-print fa-fw"></i> พิมพ์ตารางการผ่อนชำระ (เต็ม) </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Withholding_Tax" runat="server" Target="_blank" CssClass="btn btn-sm btn-warning btn-block" NavigateUrl="/Reports_Leasings/Withholding_Tax/Withholding_Tax_Prv"> <i class="fa fa-print fa-fw"></i> พิมพ์ใบหัก ณ ที่จ่าย </asp:HyperLink>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:HyperLink ID="Print_SH" runat="server" Target="_blank" CssClass="btn btn-sm btn-success btn-block" NavigateUrl="/Reports_Leasings/Leasing_SH1/Car_Leasing_SH1"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ซ.1 </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_KH1" runat="server" Target="_blank" CssClass="btn btn-sm btn-success btn-block" NavigateUrl="/Reports_Leasings/Leasing_KH1/Car_Leasing_KH1"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ข.1 </asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_KH2" runat="server" Target="_blank" CssClass="btn btn-sm btn-success btn-block" NavigateUrl="/Reports_Leasings/Leasing_KH2/Car_Leasing_KH2"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือสัญญา ข.2 </asp:HyperLink>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group col-md-3">
                        <asp:HyperLink ID="Print_Half_Certified" runat="server" Target="_blank" CssClass="btn btn-sm btn-info btn-block" NavigateUrl="/Reports_Leasings/Certified_Leasing/Certified_Leasing_Result_Prv"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือรับรองการเช่า - ซื้อ</asp:HyperLink>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="Print_Half_Confirm" runat="server" Target="_blank" CssClass="btn btn-sm btn-info btn-block" NavigateUrl="/Reports_Leasings/Confirm_Payment/Confirm_Payment_Web_Outline"> <i class="fa fa-print fa-fw"></i> พิมพ์หนังสือยืนยันการชำระเงิน </asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
