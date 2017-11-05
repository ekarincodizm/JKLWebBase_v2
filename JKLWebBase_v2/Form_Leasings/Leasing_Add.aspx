<%@ Page Title="เพิ่มสัญญาเช่า-ซื้อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Add.aspx.cs" Inherits="JKLWebBase_v2.Form_Leasings.Leasing_Add" %>

<%@ Register TagPrefix="nav_menu" TagName="Tab_Menu" Src="Tabs_Menu_Leasings.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h4 class="page-header"> เพิ่มข้อมูลสัญญาเช่า-ซื้อ </h4>
    </div>

    <!-- Tab MenuBar -->
    <nav_menu:Tab_Menu id="nav_tabs" runat="server" />

    <!-- ./Tab MenuBar -->

   <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">

                <!-- ข้อมูลรถ -->
                <div class="panel-heading">
                    ข้อมูลรถ
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Car_Register_Date_Lbl" runat="server">วันที่จดทะเบียน
                                <asp:RequiredFieldValidator ID="RFV_Car_Register_Date_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Register_Date_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <div class="form-group input-group" id="Car_Register_Date">
                                <asp:TextBox ID="Car_Register_Date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                            <script type="text/javascript">
                                $(function () {

                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                    // กรณีใช้แบบ input
                                    $("#Car_Register_Date").datetimepicker({
                                        timepicker: false,
                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                        onSelectDate: function (dp, $input) {
                                            var yearT = new Date(dp).getFullYear() - 0;
                                            var yearTH = yearT + 543;
                                            var fulldate = $input.val();
                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                            $("<%= "#" + Car_Register_Date_TBx.ClientID %>").val(fulldateTH);
                                        },
                                    });
                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                    $("<%= "#" + Car_Register_Date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                        var dateValue = $(this).val();
                                        if (dateValue != "") {
                                            var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                            if (e.type == "mouseenter") {
                                                var yearT = arr_date[2] - 543;
                                            }
                                            if (e.type == "mouseleave") {
                                                var yearT = parseInt(arr_date[2]) + 543;
                                            }
                                            dateValue = dateValue.replace(arr_date[2], yearT);
                                            $(this).val(dateValue);
                                        }
                                    });
                                });
                            </script>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Plate_Lbl" runat="server">เลขทะเบียนรถ
                                <asp:RequiredFieldValidator ID="RFV_Car_Plate_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Plate_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Car_Plate_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Plate_Province_Lbl" runat="server">จังหวัด
                                <asp:RequiredFieldValidator ID="RFV_Car_Plate_Province_DDL" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Plate_Province_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="Car_Plate_Province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Type_Lbl" runat="server">ประเภท
                                <asp:RequiredFieldValidator ID="RFV_Car_Type_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Type_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Car_Type_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Car_Feature_Lbl" runat="server">ลักษณะ
                                <asp:RequiredFieldValidator ID="RFV_Car_Feature_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Feature_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Car_Feature_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_brand_Lbl" runat="server">ยี่ห้อรถ
                                <asp:RequiredFieldValidator ID="RFV_Car_Brand_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="Car_Brand_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="Car_Brand_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Model_Lbl" runat="server">แบบ
                                <asp:RequiredFieldValidator ID="RFV_Car_Model_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Model_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Car_Model_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Year_Lbl" runat="server">ปี</asp:Label>
                            <asp:DropDownList ID="Car_Year_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Car_Color_Lbl" runat="server">สีรถ
                                <asp:RequiredFieldValidator ID="RFV_Car_Color_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Color_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Car_Color_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Chassis_No_Lbl" runat="server">เลขตัวถังรถ
                                <asp:RequiredFieldValidator ID="RFV_Chassis_No_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Chassis_No_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Chassis_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Chassis_No_At_Lbl" runat="server">เลขตัวถังรถอยู่ที่
                                <asp:RequiredFieldValidator ID="RFV_Chassis_No_At_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Chassis_No_At_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Chassis_No_At_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Engine_Brand_Lbl" runat="server">ยี่ห้อเครื่องยนต์
                                <asp:RequiredFieldValidator ID="RFV_Engine_Brand_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Engine_Brand_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Engine_Brand_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Engine_No_Lbl" runat="server">เลขเครื่องยนต์
                                <asp:RequiredFieldValidator ID="RFV_Engine_No_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Engine_No_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Engine_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Engine_No_At_Lbl" runat="server">เลขเครื่องยนต์อยู่ที่
                                <asp:RequiredFieldValidator ID="RFV_Engine_No_At_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Engine_No_At_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Engine_No_At_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Fuel_Type_Lbl" runat="server">เชื้อเพลิง
                                <asp:RequiredFieldValidator ID="RFV_Car_Fuel_Type_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Fuel_Type_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Car_Fuel_Type_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Gas_No_Lbl" runat="server">เลขถังแก๊ส </asp:Label>
                            <asp:TextBox ID="Car_Gas_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Car_Used_Lbl" runat="server">สภาพรถ
                                <asp:RequiredFieldValidator ID="RFV_Car_Used_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="Car_Used_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="Car_Used_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Distance_Lbl" runat="server">ระยะทาง
                                <asp:RequiredFieldValidator ID="RFV_Car_Distance_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Distance_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Distance_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">กิโลเมตร</span>
                            </div>
                        </div>

                        <div class="col-xs-3">
                            <asp:Label ID="Car_Next_Register_Date_Lbl" runat="server">วันที่ต่อทะเบียน
                                <asp:RequiredFieldValidator ID="RFV_Car_Next_Register_Date_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Car_Next_Register_Date_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <div class="form-group input-group" id="Car_Next_Register_Date">
                                <asp:TextBox ID="Car_Next_Register_Date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                            <script type="text/javascript">
                                $(function () {

                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                    // กรณีใช้แบบ input
                                    $("#Car_Next_Register_Date").datetimepicker({
                                        timepicker: false,
                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                        onSelectDate: function (dp, $input) {
                                            var yearT = new Date(dp).getFullYear() - 0;
                                            var yearTH = yearT + 543;
                                            var fulldate = $input.val();
                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                            $("<%= "#" + Car_Next_Register_Date_TBx.ClientID %>").val(fulldateTH);
                                        },
                                    });
                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                    $("<%= "#" + Car_Next_Register_Date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                        var dateValue = $(this).val();
                                        if (dateValue != "") {
                                            var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                            if (e.type == "mouseenter") {
                                                var yearT = arr_date[2] - 543;
                                            }
                                            if (e.type == "mouseleave") {
                                                var yearT = parseInt(arr_date[2]) + 543;
                                            }
                                            dateValue = dateValue.replace(arr_date[2], yearT);
                                            $(this).val(dateValue);
                                        }
                                    });
                                });
                            </script>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Tax_Value_Lbl" runat="server">ค่าต่อภาษี</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Tax_Value_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <asp:Label ID="Tent_car_Lbl" runat="server">ชื่อเต้นท์รถ</asp:Label>
                            <asp:DropDownList ID="Tent_car_DDL" runat="server" CssClass="form-control" OnSelectedIndexChanged="Tent_car_DDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-xs-4">
                            <asp:Label ID="Car_Credits_Lbl" runat="server">สินเชื่อ</asp:Label>
                            <asp:TextBox ID="Car_Credits_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-4">
                            <asp:Label ID="Car_agent_Lbl" runat="server">ตัวแทนรถ</asp:Label>
                            <asp:TextBox ID="Car_agent_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <!-- ข้อมูลเจ้าของรถเดิม -->
                <div class="panel-heading">
                    ข้อมูลเจ้าของรถเดิม
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <asp:Label ID="Car_Old_Owner_Lbl" runat="server">เจ้าของรถเดิม (ล่าสุด) </asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Old_Owner_Idcard_Lbl" runat="server">เลขบัตรประชาชน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Idcard_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_old_owner_b_date_Lbl" runat="server">บัตรหมดอายุ</asp:Label>
                            <div class="form-group input-group" id="Car_Old_Owner_Idcard_Str">
                                <asp:TextBox ID="Car_old_owner_b_date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                            <script type="text/javascript">
                                $(function () {

                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                    // กรณีใช้แบบ input
                                    $("#Car_Old_Owner_Idcard_Str").datetimepicker({
                                        timepicker: false,
                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                        onSelectDate: function (dp, $input) {
                                            var yearT = new Date(dp).getFullYear() - 0;
                                            var yearTH = yearT + 543;
                                            var fulldate = $input.val();
                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                            $("<%= "#" + Car_old_owner_b_date_TBx.ClientID %>").val(fulldateTH);
                                        },
                                    });
                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                    $("<%= "#" + Car_old_owner_b_date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                        var dateValue = $(this).val();
                                        if (dateValue != "") {
                                            var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                            if (e.type == "mouseenter") {
                                                var yearT = arr_date[2] - 543;
                                            }
                                            if (e.type == "mouseleave") {
                                                var yearT = parseInt(arr_date[2]) + 543;
                                            }
                                            dateValue = dateValue.replace(arr_date[2], yearT);
                                            $(this).val(dateValue);
                                        }
                                    });
                                });
                            </script>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Address_No_Lbl" runat="server">ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Address_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <asp:Label ID="Car_Old_Owner_Vilage_Lbl" runat="server">หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Vilage_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Vilage_No_Lbl" runat="server">หมู่ที่</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Vilage_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Old_Owner_alley_Lbl" runat="server">ซอย</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_alley_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Old_Owner_Road_Lbl" runat="server">ถนน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Road_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Car_Old_Owner_Subdistrict_Lbl" runat="server">ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Subdistrict_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Car_Old_Owner_District_Lbl" runat="server">อำเภอ / เขต</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_District_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Province_Lbl" runat="server">จังหวัด</asp:Label>
                            <asp:DropDownList ID="Car_Old_Owner_Province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Contry_Lbl" runat="server">ประเทศ</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Contry_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Zipcode_Lbl" runat="server">รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <!-- /.ข้อมูลเจ้าของรถเดิม -->

                <!-- ข้อมูลเช็คและการโอน -->
                <div class="panel-heading">
                    ข้อมูลเช็คและการโอน
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Cheque_receiver_Lbl" runat="server"> ชื่อผู้รับเช็ค / โอน </asp:Label>
                            <asp:TextBox ID="Cheque_receiver_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Cheque_bank_Lbl" runat="server"> ธนาคาร </asp:Label>
                            <asp:TextBox ID="Cheque_bank_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Cheque_bank_branch_Lbl" runat="server"> สาขา </asp:Label>
                            <asp:TextBox ID="Cheque_bank_branch_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Check_number_Lbl" runat="server">หมายเลขเช็ค / เลขบัญชี </asp:Label>
                            <asp:TextBox ID="Cheque_number_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Cheque_sum_Lbl" runat="server">ยอดจ่ายเช็ค / โอน </asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Cheque_sum_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Cheque_receive_date_Lbl" runat="server">วันที่รับเช็ค / โอน </asp:Label>
                            <div class="form-group input-group" id="Check_receive_date">
                                <asp:TextBox ID="Cheque_receive_date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                            <script type="text/javascript">
                                $(function () {

                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                    // กรณีใช้แบบ input
                                    $("#Check_receive_date").datetimepicker({
                                        timepicker: false,
                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                        onSelectDate: function (dp, $input) {
                                            var yearT = new Date(dp).getFullYear() - 0;
                                            var yearTH = yearT + 543;
                                            var fulldate = $input.val();
                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                            $("<%= "#" + Cheque_receive_date_TBx.ClientID %>").val(fulldateTH);
                                        },
                                    });
                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                    $("<%= "#" + Cheque_receive_date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                        var dateValue = $(this).val();
                                        if (dateValue != "") {
                                            var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                            if (e.type == "mouseenter") {
                                                var yearT = arr_date[2] - 543;
                                            }
                                            if (e.type == "mouseleave") {
                                                var yearT = parseInt(arr_date[2]) + 543;
                                            }
                                            dateValue = dateValue.replace(arr_date[2], yearT);
                                            $(this).val(dateValue);
                                        }
                                    });
                                });
                            </script>
                        </div>
                    </div>
                </div>
                <!-- /.ข้อมูลเช็คและการโอน -->

                <!-- ข้อมูลสัญญา -->
                <div class="panel-heading">
                    ข้อมูลสัญญา
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Deps_No_Lbl" runat="server">เลขที่รับฝาก
                                <asp:RequiredFieldValidator ID="RFV_Deps_No_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Deps_No_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:TextBox ID="Deps_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Leasing_Code_Lbl" runat="server">รหัสสัญญา
                                <asp:RequiredFieldValidator ID="RFV_Leasing_Code_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="Leasing_Code_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="Leasing_Code_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Leasing_No_Lbl" runat="server">เลขที่สัญญา </asp:Label>
                            <asp:TextBox ID="Leasing_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Company_Lbl" runat="server">สาขา
                                <asp:RequiredFieldValidator ID="RFV_Company_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="Company_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="Company_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-3">
                            <asp:Label ID="Zone_Lbl" runat="server">เขตบริการ
                                <asp:RequiredFieldValidator ID="RFV_Zone_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="Zone_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="Zone_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Leasing_Date_Lbl" runat="server">วันที่ทำสัญญา
                                <asp:RequiredFieldValidator ID="RFV_Leasing_Date_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Leasing_Date_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <div class="form-group input-group" id="Leasing_Date">
                                <asp:TextBox ID="Leasing_Date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                            <script type="text/javascript">
                                $(function () {

                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                    // กรณีใช้แบบ input
                                    $("#Leasing_Date").datetimepicker({
                                        timepicker: false,
                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                        onSelectDate: function (dp, $input) {
                                            var yearT = new Date(dp).getFullYear() - 0;
                                            var yearTH = yearT + 543;
                                            var fulldate = $input.val();
                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                            $("<%= "#" + Leasing_Date_TBx.ClientID %>").val(fulldateTH);
                                        },
                                    });
                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                    $("<%= "#" + Leasing_Date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                        var dateValue = $(this).val();
                                        if (dateValue != "") {
                                            var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                            if (e.type == "mouseenter") {
                                                var yearT = arr_date[2] - 543;
                                            }
                                            if (e.type == "mouseleave") {
                                                var yearT = parseInt(arr_date[2]) + 543;
                                            }
                                            dateValue = dateValue.replace(arr_date[2], yearT);
                                            $(this).val(dateValue);
                                        }
                                    });
                                });
                            </script>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="TotalPaymentTime_Lbl" runat="server">ระยะเวลาชำระเงิน
                                <asp:RequiredFieldValidator ID="RFV_TotalPaymentTime_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="TotalPaymentTime_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="TotalPaymentTime_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-3">
                            <asp:Label ID="Court_Lbl" runat="server">ศาล
                                <asp:RequiredFieldValidator ID="RFV_Court_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="Court_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                            </asp:Label>
                            <asp:DropDownList ID="Court_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-6">
                            <asp:Label ID="Person_Receive_Trasfer_Lbl" runat="server">ผู้รับโอน</asp:Label>
                            <asp:TextBox ID="Person_Receive_Trasfer_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:Label ID="Guarantee_Lbl" runat="server">หลักประกัน</asp:Label>
                            <asp:TextBox ID="Guarantee_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลสัญญา -->

                <!-- ข้อมูลการประเมิน -->
                <div class="panel-heading">
                    ข้อมูลการประเมิน
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    ข้อมูลประเมินการเช่า-ซื้อ
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-group col-xs-3">
                                            <asp:Label ID="Payment_Schedule_Lbl" runat="server">กำหนดชำระทุกวันที่
                                            <asp:RequiredFieldValidator ID="RFV_Payment_Schedule_DDL" runat="server" ErrorMessage=" กรุณาเลือก " CssClass="text-danger" ControlToValidate="Payment_Schedule_DDL" SetFocusOnError="true" ValidationGroup="Save_Validation" InitialValue="0"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <asp:DropDownList ID="Payment_Schedule_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="First_Payment_Date_Lbl" runat="server">วันที่เริ่มชำระ
                                            <asp:RequiredFieldValidator ID="RFV_First_Payment_Date_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="First_Payment_Date_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group" id="First_Payment_Date">
                                                <asp:TextBox ID="First_Payment_Date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                                <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                                            </div>
                                            <script type="text/javascript">
                                                $(function () {

                                                    $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                                    // กรณีใช้แบบ input
                                                    $("#First_Payment_Date").datetimepicker({
                                                        timepicker: false,
                                                        format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                                        lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                                        onSelectDate: function (dp, $input) {
                                                            var yearT = new Date(dp).getFullYear() - 0;
                                                            var yearTH = yearT + 543;
                                                            var fulldate = $input.val();
                                                            var fulldateTH = fulldate.replace(yearT, yearTH);
                                                            $("<%= "#" + First_Payment_Date_TBx.ClientID %>").val(fulldateTH);
                                                        },
                                                    });
                                                    // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                                    $("<%= "#" + First_Payment_Date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                                        var dateValue = $(this).val();
                                                        if (dateValue != "") {
                                                            var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                                            if (e.type == "mouseenter") {
                                                                var yearT = arr_date[2] - 543;
                                                            }
                                                            if (e.type == "mouseleave") {
                                                                var yearT = parseInt(arr_date[2]) + 543;
                                                            }
                                                            dateValue = dateValue.replace(arr_date[2], yearT);
                                                            $(this).val(dateValue);
                                                        }
                                                    });
                                                });
                                            </script>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Total_Require_Lbl" runat="server">ยอดจัด / เงินต้น
                                            <asp:RequiredFieldValidator ID="RFV_Total_Require_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Total_Require_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Total_Require_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                <span class="input-group-addon">บาท</span>
                                            </div>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Interest_Rate_Lbl" runat="server">อัตราดอกเบี้ย
                                            <asp:RequiredFieldValidator ID="RFV_Interest_Rate_TBx" runat="server" ErrorMessage=" * " CssClass="text-danger" ControlToValidate="Interest_Rate_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Interest_Rate_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                <span class="input-group-addon">% </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xs-3">
                                            <asp:Label ID="Vat_Lbl" runat="server">ภาษีมูลค่าเพิ่ม
                                            <asp:RequiredFieldValidator ID="RFV_Vat_TBx" runat="server" ErrorMessage=" * " CssClass="text-danger" ControlToValidate="Vat_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Vat_TBx" runat="server" CssClass="form-control" TextMode="Number" Text="7"></asp:TextBox>
                                                <span class="input-group-addon">% </span>
                                            </div>
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:Label ID="Total_Period_Lbl" runat="server">ระยะเวลา / จำนวนงวด
                                            <asp:RequiredFieldValidator ID="RFV_Total_Period_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูล " CssClass="text-danger" ControlToValidate="Total_Period_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Total_Period_TBx" runat="server" CssClass="form-control" TextMode="Number" OnTextChanged="Total_Period_TBx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <span class="input-group-addon">งวด </span>
                                            </div>
                                        </div>
                                        <div class="col-xs-1">
                                            <asp:Label ID="Calculate_Lbl" runat="server"> คำนวน </asp:Label>
                                            <asp:LinkButton ID="Calculate_Btn" runat="server" CssClass="btn btn-sm btn-success" OnClick="Calculate_Btn_Click"> <i class="fa fa-gears fa-fw"></i> คำนวน </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    อัตราการเช่า - ซื้อ
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Total_Sum_Lbl" runat="server">มูลค่า
                                            <asp:RequiredFieldValidator ID="RFV_Total_Sum_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Total_Sum_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Total_Sum_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท</span>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Total_Interest_Lbl" runat="server">ดอกเบี้ย
                                            <asp:RequiredFieldValidator ID="RFV_Total_Interest_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Total_Interest_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Total_Interest_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท</span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Total_Tax_Lbl" runat="server">ภาษี
                                            <asp:RequiredFieldValidator ID="RFV_Total_Tax_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Total_Tax_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Total_Tax_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท</span>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Total_Leasing_Lbl" runat="server">ยอดเช่า-ซื้อ
                                            <asp:RequiredFieldValidator ID="RFV_Total_Leasing_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Total_Leasing_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Total_Leasing_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท</span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group col-xs-7">
                                            <asp:Label ID="Total_Net_Leasing_Lbl" runat="server">ยอดเช่า-ซื้อสุทธิ (ชำระจริง)
                                            <asp:RequiredFieldValidator ID="RFV_Total_Net_Leasing_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Total_Net_Leasing_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Total_Net_Leasing_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="col-md-6">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    อัตราการชำระเงิน / งวด
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Period_require_Lbl" runat="server">เงินต้น / งวด
                                            <asp:RequiredFieldValidator ID="RFV_Period_require_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Period_require_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Period_require_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท / งวด</span>
                                            </div>
                                        </div>

                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Period_interst_Lbl" runat="server">ดอกเบี้ย / งวด
                                            <asp:RequiredFieldValidator ID="RFV_Period_interst_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Period_interst_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Period_interst_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท / งวด</span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Period_tax_Lbl" runat="server">ภาษี / งวด
                                            <asp:RequiredFieldValidator ID="RFV_Period_tax_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Period_tax_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Period_tax_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท / งวด</span>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-6">
                                            <asp:Label ID="Period_Cal_Lbl" runat="server">มูลค่า / งวด
                                            <asp:RequiredFieldValidator ID="RFV_Period_Cal_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Period_Cal_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Period_Cal_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท / งวด</span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <asp:Label ID="Period_pure_Lbl" runat="server">ค่างวด
                                            <asp:RequiredFieldValidator ID="RFV_Period_pure_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Period_pure_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Period_pure_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท / งวด</span>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-7">
                                            <asp:Label ID="Period_Payment_Lbl" runat="server">ค่างวดสุทธิ (ชำระจริง)
                                            <asp:RequiredFieldValidator ID="RFV_Period_Payment_TBx" runat="server" ErrorMessage=" กรุณากรอกข้อมูลและคำนวณ " CssClass="text-danger" ControlToValidate="Period_Payment_TBx" SetFocusOnError="true" ValidationGroup="Save_Validation"></asp:RequiredFieldValidator>
                                            </asp:Label>
                                            <div class="form-group input-group">
                                                <asp:TextBox ID="Period_Payment_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-addon">บาท / งวด</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.ข้อมูลการประเมิน -->

                <hr />

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:LinkButton ID="Leasing_Add_Save_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Leasing_Add_Save_Btn_Click" ValidationGroup="Save_Validation" CausesValidation="true"><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>

