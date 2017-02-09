<%@ Page Title="หนังสือรับรองการเช่า - ซื้อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Certified_Leasing_Result_Prv.aspx.cs" Inherits="JKLWebBase_v2.Reports_Leasings.Certified_Leasing.Certified_Leasing_Result_Prv" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h4 class="page-header">หนังสือยืนยันการชำระเงิน </h4>
    </div>

    <div class="panel panel-primary">
        <div class="panel-body">
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Print_Date_Lbl" runat="server">วันที่
                        <asp:RequiredFieldValidator ID="RFV_Print_Date_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Print_Date_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>

                </div>
                <div class="form-group col-xs-2">
                    <asp:TextBox ID="Print_Date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Registrar_Lbl" runat="server">เรียน นายทะเบียน
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Print_Date_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>

                </div>
                <div class="form-group col-xs-4">
                    <asp:TextBox ID="Registrar_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="Car_Lbl" runat="server">โดยหนังสือฉบับนี้ ทางห้างหุ้นส่วนจำกัดฯ ขอรับรองว่า รถ
                        <asp:RequiredFieldValidator ID="RFV_Car_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Car_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-9">
                    <asp:TextBox ID="Car_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Model_Lbl" runat="server">รุ่น
                        <asp:RequiredFieldValidator ID="RFV_Model_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Model_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class=" form-group col-xs-3">
                    <asp:TextBox ID="Model_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Car_Engine_Lbl" runat="server">หมายเลขเครื่องยนต์
                        <asp:RequiredFieldValidator ID="RFV_Car_Engine_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Car_Engine_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-3">
                    <asp:TextBox ID="Car_Engine_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Car_Chassis_Lbl" runat="server">หมายเลขตัวรถ
                        <asp:RequiredFieldValidator ID="RFV_Car_Chassis_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Car_Chassis_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-3">
                    <asp:TextBox ID="Car_Chassis_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="Ctm_Name_Lbl" runat="server">ซึ่ง ทางห้างหุ้นส่วนจำกัดฯ ได้ตกลงให้
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Name_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Name_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-6">
                    <asp:TextBox ID="Ctm_Name_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Ctm_Address_No_Lbl" runat="server">อยู่บ้านเลขที่
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Address_No_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Address_No_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-2">
                    <asp:TextBox ID="Ctm_Address_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Ctm_Moo_Lbl" runat="server">หมู่ที่
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Moo_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Moo_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class=" form-group col-xs-1">
                    <asp:TextBox ID="Ctm_Moo_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Ctm_Alley_Lbl" runat="server">ตรอก/ซอย
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Alley_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Alley_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-1">
                    <asp:TextBox ID="Ctm_Alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Ctm_Road_Lbl" runat="server">ถนน
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Road_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Road_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-3">
                    <asp:TextBox ID="Ctm_Road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Ctm_Subdistrict_Lbl" runat="server">ตำบล
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Subdistrict_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Subdistrict_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-3">
                    <asp:TextBox ID="Ctm_Subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Ctm_District_Lbl" runat="server">อำเภอ
                        <asp:RequiredFieldValidator ID="RFV_Ctm_District_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_District_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class=" form-group col-xs-5">
                    <asp:TextBox ID="Ctm_District_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Ctm_Province_Lbl" runat="server">จังหวัด
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Province_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Province_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-5">
                    <asp:TextBox ID="Ctm_Province_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Car_II_Lbl" runat="server">เป็นผู้เช่า - ซื้อรถ
                        <asp:RequiredFieldValidator ID="RFV_Car_II_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Car_II_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class=" form-group col-xs-8">
                    <asp:TextBox ID="Car_II_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Leasing_Date_Lbl" runat="server">คันดังกล่าวในวันที่
                        <asp:RequiredFieldValidator ID="RFV_Leasing_Date_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Leasing_Date_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-2">
                    <asp:TextBox ID="Leasing_Date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2 col-md-offset-2">
                    <asp:Label ID="Finance_Lbl" runat="server">ยอดจัดไฟแนนซ์
                        <asp:RequiredFieldValidator ID="RFV_Finance_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Finance_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-4">
                    <div class="form-group input-group">
                        <asp:TextBox ID="Finance_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2 col-md-offset-2">
                    <asp:Label ID="Interest_Lbl" runat="server">ดอกเบี้ย
                        <asp:RequiredFieldValidator ID="RFV_Interest_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Interest_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-4">
                    <div class="form-group input-group">
                        <asp:TextBox ID="Interest_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2 col-md-offset-2">
                    <asp:Label ID="Total_Finance_Lbl" runat="server">รวมยอดจัดไฟแนนซ์และดอกเบี้ย
                        <asp:RequiredFieldValidator ID="RFV_Total_Finance_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Total_Finance_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-4">
                    <div class="form-group input-group">
                        <asp:TextBox ID="Total_Finance_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2 col-md-offset-2">
                    <asp:Label ID="Total_Period_Lbl" runat="server">แบ่งชำระเป็น
                        <asp:RequiredFieldValidator ID="RFV_Total_Period_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Total_Period_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-1">
                    <asp:TextBox ID="Total_Period_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-1">
                    <asp:Label ID="Payment_Period_Lbl" runat="server">งวดๆ ละ
                        <asp:RequiredFieldValidator ID="RFV_Payment_Period_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Payment_Period_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-2">
                    <div class="form-group input-group">
                        <asp:TextBox ID="Payment_Period_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2 col-md-offset-2">
                    <asp:Label ID="Period_Pay_Lbl" runat="server">ค่างวด
                        <asp:RequiredFieldValidator ID="RFV_Period_Pay_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Period_Pay_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-4">
                    <div class="form-group input-group">
                        <asp:TextBox ID="Period_Pay_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2 col-md-offset-2">
                    <asp:Label ID="Period_Vat_Lbl" runat="server">ภาษีมูลค่าเพิ่ม
                        <asp:RequiredFieldValidator ID="RFV_Period_Vat_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Period_Vat_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-4">
                    <div class="form-group input-group">
                        <asp:TextBox ID="Period_Vat_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2 col-md-offset-2">
                    <asp:Label ID="Total_Period_Payment_Lbl" runat="server">รวมค่างวดและภาษีมูลค่าเพิ่ม
                        <asp:RequiredFieldValidator ID="RFV_Total_Period_Payment_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Total_Period_Payment_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-4">
                    <div class="form-group input-group">
                        <asp:TextBox ID="Total_Period_Payment_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon">บาท</span>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="For_Lbl" runat="server">เนื่องจากความจำเป็นในการจัดพิมพ์สัญญาเช่า - ซื้อเพื่อ
                        <asp:RequiredFieldValidator ID="RFV_For_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="For_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-9">
                    <asp:TextBox ID="For_TBx" runat="server" CssClass="form-control" Text="จัดไฟแนนซ์"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Car_III_Lbl" runat="server">รถ
                        <asp:RequiredFieldValidator ID="RFV_Car_III_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Car_III_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-8">
                    <asp:TextBox ID="Car_III_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-3">
                    <asp:Label ID="Sub_Car_III_Lbl" runat="server">คันดังกล่าว ห้างหุ้นส่วนจำกัดฯ ขอเสนอหนังสือฉบับนี้แทน พร้อมกันนี้ </asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-2">
                    <asp:Label ID="Ctm_Name_II_Lbl" runat="server">ห้างหุ้นส่วนจำกัดฯ ได้ให้
                        <asp:RequiredFieldValidator ID="RFV_Ctm_Name_II_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Ctm_Name_II_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-7">
                    <asp:TextBox ID="Ctm_Name_II_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-3">
                    <asp:Label ID="Sub_Ctm_Name_II_Lbl" runat="server">( ผู้เช่า - ซื้อ ) ลงนามในท้ายหนังสือ เพื่อเป็นการยืนยันร่วมกัน </asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-3">
                    <asp:Label ID="For_II_Lbl" runat="server">จึงเรียนมาเพื่อขอให้ท่านได้โปรดพิจารณาอนุมัติการ
                        <asp:RequiredFieldValidator ID="RFV_For_II_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="For_II_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-9">
                    <asp:TextBox ID="For_II_TBx" runat="server" CssClass="form-control" Text="จัดไฟแนนซ์"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-1">
                    <asp:Label ID="Car_IV_Lbl" runat="server">รถ
                        <asp:RequiredFieldValidator ID="RFV_Car_IV_TBx" runat="server" ErrorMessage=" ** " CssClass="text-danger" ControlToValidate="Car_IV_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation" ></asp:RequiredFieldValidator>
                    </asp:Label>
                </div>
                <div class="form-group col-xs-8">
                    <asp:TextBox ID="Car_IV_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-xs-3">
                    <asp:Label ID="Sub_Car_IV_Lbl" runat="server"> คันดังกล่าวในนาม ห้างหุ้นส่วนจำกัดฯ </asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-2">
                    <asp:LinkButton ID="Export_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Export_Btn_Click" ValidationGroup="Save_Validation" CausesValidation="true"><i class="fa fa-print fa-fw"></i> พิมพ์ </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
