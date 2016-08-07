<%@ Page Title="เพิ่มสัญญาเช่า-ซื้อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Leasing_Add.aspx.cs" Inherits="JKLWebBase_v2.Leasing_Form.Leasing_Add" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header"> เพิ่มข้อมูลสัญญาเช่า-ซื้อ </h1>
    </div>
    <ul class="nav nav-tabs">
      <li role="presentation" class="active"><asp:LinkButton ID="link_Leasing_Add" runat="server" OnClick="link_Leasing_Add_Click" ><i class="fa fa-book fa-fw"></i> ข้อมูลสัญญา </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_1" runat="server" Enabled="false" OnClick="link_Add_Bondsman_1_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 1</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_2" runat="server" Enabled="false" OnClick="link_Add_Bondsman_2_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 2</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_3" runat="server" Enabled="false" OnClick="link_Add_Bondsman_3_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 3</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_4" runat="server" Enabled="false" OnClick="link_Add_Bondsman_4_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 4</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_5" runat="server" Enabled="false" OnClick="link_Add_Bondsman_5_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 5</asp:LinkButton></li>
    </ul>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
               
                <!-- ข้อมูลรถ -->
                <div class="panel-heading">
                    ข้อมูลรถ
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Car_Type_Lbl" runat="server" >ประเภทรถ</asp:Label>
                            <asp:DropDownList ID="Car_Type_DDL" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_brand_Lbl" runat="server" >ยี่ห้อรถ</asp:Label>
                            <asp:DropDownList ID="Car_Brand_DDL" runat="server" CssClass="form-control" OnSelectedIndexChanged="Car_Brand_DDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Model_Lbl" runat="server" >รุ่นรถ</asp:Label>
                            <asp:DropDownList ID="Car_Model_DDL" runat="server" CssClass="form-control" ></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Color_Lbl" runat="server" >สีรถ</asp:Label>
                            <asp:TextBox ID="Car_Color_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Plate_Lbl" runat="server" >เลขทะเบียนรถ</asp:Label>
                            <asp:TextBox ID="Car_Plate_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Engine_No_Lbl" runat="server" >เลขเครื่องรถ</asp:Label>
                            <asp:TextBox ID="Engine_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Chassis_No_Lbl" runat="server" >เลขตัวถังรถ</asp:Label>
                            <asp:TextBox ID="Chassis_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class=" col-xs-1">
                            <asp:Label ID="Car_Year_Lbl" runat="server" >ปี</asp:Label>
                            <asp:DropDownList ID="Car_Year_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Used_Lbl" runat="server" >สภาพรถ</asp:Label>
                            <asp:DropDownList ID="Car_Used_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Distance_Lbl" runat="server" >ระยะทาง</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Distance_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">กิโลเมตร</span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Register_Date_Lbl" runat="server" >วันที่จดทะเบียน</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Register_Date_TBx" runat="server" CssClass="form-control" TextMode="Date" data-date-inline-picker="true"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Next_Register_Date_Lbl" runat="server" >วันที่ต่อทะเบียน</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Next_Register_Date_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Tax_Value_Lbl" runat="server" >ค่าต่อภาษี</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Tax_Value_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Car_Credits_Lbl" runat="server" >สินเชื่อ</asp:Label>
                            <asp:TextBox ID="Car_Credits_Tbx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Dealer_Lbl" runat="server" >ตัวแทนรถ</asp:Label>
                            <asp:TextBox ID="Car_Dealer_Tbx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Lbl" runat="server" >เจ้าของรถเดิม</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Tbx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Idcard_Lbl" runat="server" >เลขบัตรประชาชน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Idcard_Tbx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Idcard_Str_Lbl" runat="server" >วันที่ออกบัตร</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Old_Owner_Idcard_Str_Tbx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Idcard_Exp_Lbl" runat="server" >วันที่หมดอายุ</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Old_Owner_Idcard_Exp_Tbx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Address_No_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="txt_17_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Vilage_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Vilage_No_Lbl" runat="server" >หมู่ที่</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Vilage_No_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_alley_Lbl" runat="server" >ซอย</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_alley_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Road_Lbl" runat="server" >ถนน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Road_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Subdistrict_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_District_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_District_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Province_Lbl" runat="server" >จังหวัด</asp:Label>
                            <asp:DropDownList ID="Car_Old_Owner_Province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Contry_Lbl" runat="server" >ประเทศ</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Contry_Tbx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Zipcode_Tbx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                รูปรถ
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_1_Lbl" runat="server" >รูปที่ 1 </asp:Label>
                                        <asp:FileUpload ID="Car_img_1" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_6_Lbl" runat="server" >รูปที่ 6 </asp:Label>
                                         <asp:FileUpload ID="Car_img_6" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_2_Lbl" runat="server" >รูปที่ 2 </asp:Label>
                                        <asp:FileUpload ID="Car_img_2" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_7_Lbl" runat="server" >รูปที่ 7 </asp:Label>
                                        <asp:FileUpload ID="Car_img_7" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_3_Lbl" runat="server" >รูปที่ 3 </asp:Label>
                                        <asp:FileUpload ID="Car_img_3" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_8_Lbl" runat="server" >รูปที่ 8 </asp:Label>
                                        <asp:FileUpload ID="Car_img_8" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_4_Lbl" runat="server" >รูปที่ 4 </asp:Label>
                                        <asp:FileUpload ID="Car_img_4" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_9_Lbl" runat="server" >รูปที่ 9 </asp:Label>
                                        <asp:FileUpload ID="Car_img_9" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_5_Lbl" runat="server" >รูปที่ 5 </asp:Label>
                                        <asp:FileUpload ID="Car_img_5" runat="server" CssClass="form-control"/>
                                    </div>
                                    <div class="form-group col-xs-6">
                                        <asp:Label ID="Car_img_10_Lbl" runat="server" >รูปที่ 10 </asp:Label>
                                        <asp:FileUpload ID="Car_img_10" runat="server" CssClass="form-control"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.ข้อมูลรถ -->

                <!-- ข้อมูลสัญญา -->
                <div class="panel-heading">
                    ข้อมูลสัญญา
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Deps_No_Lbl" runat="server" >เลขที่รับฝาก</asp:Label>
                            <asp:TextBox ID="Deps_No_Tbx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Leasing_Code_Lbl" runat="server" >รหัสสัญญา</asp:Label>
                            <asp:DropDownList ID="Leasing_Code_Tbx" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Leasing_No_Lbl" runat="server" >เลขที่สัญญา</asp:Label>
                            <asp:TextBox ID="Leasing_No_Tbx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Branch_Lbl" runat="server" >สาขา</asp:Label>
                            <asp:DropDownList ID="Branch_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Zone_Lbl" runat="server" >เขตบริการ</asp:Label>
                            <asp:DropDownList ID="Zone_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Leasing_Date_Lbl" runat="server" >วันที่ทำสัญญา</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Leasing_Date_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="TotalPaymentTime_Lbl" runat="server" >ระยะเวลาชำระะเงิน</asp:Label>
                            <asp:DropDownList ID="TotalPaymentTime_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Court_Lbl" runat="server" >ศาล</asp:Label>
                            <asp:DropDownList ID="Court_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Person_Receive_Trasfer_Lbl" runat="server" >ผู้รับโอน</asp:Label>
                            <asp:TextBox ID="Person_Receive_Trasfer_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลสัญญา -->

                <!-- ข้อมูลการประเมิน -->
                <div class="panel-heading">
                    ข้อมูลการประเมิน
                </div>
                <div class="panel-body">
                    
                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ข้อมูลประเมินการเช่า-ซื้อ
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-2">
                                        <asp:Label ID="Payment_Schedule_Lbl" runat="server" >กำหนดชำระทุกวันที่</asp:Label>
                                        <asp:DropDownList ID="Payment_Schedule_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="First_Payment_Date_Lbl" runat="server" >วันที่เริ่มชำระ</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="First_Payment_Date_Tbx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Require_Lbl" runat="server" > ยอดจัด </asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Require_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Interest_Rate_Lbl" runat="server" >อัตราดอกเบี้ย</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Interest_Rate_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon"> % </span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Period_Lbl" runat="server" > จำนวนงวดทั้งหมด </asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Period_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon"> งวด </span>
                                        </div>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Calculate_Lbl" runat="server" > คำนวน </asp:Label>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon"> <i class="fa fa-gears fa-fw"></i> </span>
                                            <asp:LinkButton ID="Calculate_Btn" runat="server" CssClass="btn btn-xs btn-success"> คำนวน </asp:LinkButton>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                อัตราการเช่า-ซื้อ
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Sum_Lbl" runat="server" >ยอดรวม</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Sum_Tbx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Interest_Lbl" runat="server" >ดอกเบี้ย</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Interest_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Tax_Lbl" runat="server" >ภาษี</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Tax_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Leasing_Lbl" runat="server" >ยอดเช่า-ซื้อ</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Leasing_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                อัตราการชำระเงิน/งวด
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-xs-2">
                                        <asp:Label ID="Period_Cal_Lbl" runat="server" >ค่างวด</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Period_Cal_Tbx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท / งวด</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Tax_per_m_Lbl" runat="server" >ภาษี / งวด</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Tax_per_m_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท / งวด</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Period_pure_Lbl" runat="server" >ค่างวดสุดธิ</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Period_pure_Tbx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท / งวด</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Period_Payment_Lbl" runat="server" >ค่างวดจ่ายจริง</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Period_Payment_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท / งวด</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลการประเมิน -->

                <!-- ข้อมูลนายหน้า -->
                <div class="panel-heading">
                    ข้อมูลนายหน้า
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_idcard_Lbl" runat="server" >เลขบัตรประชาชน</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Dealer_idcard_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="input-group-addon"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_fname_Lbl" runat="server" >ชื่อ</asp:Label>
                            <asp:TextBox ID="Dealer_fname_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_lname_Lbl" runat="server" >นามสกุล</asp:Label>
                            <asp:TextBox ID="Dealer_lname_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_address_no_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="Dealer_address_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Dealer_vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                            <asp:TextBox ID="Dealer_vilage_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_alley_Lbl" runat="server" >ซอย</asp:Label>
                            <asp:TextBox ID="Dealer_alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_road_Lbl" runat="server" >ถนน</asp:Label>
                            <asp:TextBox ID="Dealer_road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Dealer_subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_district_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                            <asp:TextBox ID="Dealer_district_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_province_Lbl" runat="server" >จังหวัด</asp:Label>
                            <asp:DropDownList ID="Dealer_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Dealer_country_Lbl" runat="server" >ประเทศ</asp:Label>
                            <asp:TextBox ID="Dealer_country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Dealer_zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Dealer_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Dealer_receive_Lbl" runat="server" >ค่านายหน้า</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Dealer_receive_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <span class="input-group-addon">บาท</span>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลนายหน้า -->

                <!-- ข้อมูลผู้ทำสัญญา -->
                <div class="panel-heading">
                    ข้อมูลผู้ทำสัญญา
                </div>
                <div class="panel-body">
                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ข้อมูลทั่วไป
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Cust_idcard_Lbl" runat="server" >เลขบัตรประชาชน</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Cust_idcard_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="input-group-addon"><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_Fname_Lbl" runat="server" >ชื่อ</asp:Label>
                                        <asp:TextBox ID="Cust_Fname_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_LName_Lbl" runat="server" >นามสกุล</asp:Label>
                                        <asp:TextBox ID="Cust_LName_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Cust_Origin_Lbl" runat="server" >เชื้อชาติ</asp:Label>
                                        <asp:DropDownList ID="Cust_Origin_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Cust_Nationality_Lbl" runat="server" >สัญชาติ</asp:Label>
                                        <asp:DropDownList ID="Cust_Nationality_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_Idcard_start_Lbl" runat="server" >วันที่ออกบัตร</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Cust_Idcard_start_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_Idcard_expire_Lbl" runat="server" >วันที่หมดอายุ</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Cust_Idcard_expire_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Cust_B_date_Lbl" runat="server" >วันเกิด</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Cust_B_date_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Cust_Idcard_without_Lbl" runat="server" >ออกโดย</asp:Label>
                                        <asp:TextBox ID="Cust_Idcard_without_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_status_Lbl" runat="server" >สถานะภาพการสมรส</asp:Label>
                                        <asp:DropDownList ID="Cust_status_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Tent_car_Lbl" runat="server" >ชื่อเต้นท์รถ</asp:Label>
                                        <asp:DropDownList ID="Tent_car_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Check_receive_person_Lbl" runat="server" >ชื่อผู้รับเช็ค</asp:Label>
                                        <asp:TextBox ID="Check_receive_person_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Check_number_Lbl" runat="server" >หมายเลขเช็ค</asp:Label>
                                        <asp:TextBox ID="Check_number_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Check_payment_Lbl" runat="server" >ยอดจ่ายเช็ค</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Check_payment_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Check_receive_date_Lbl" runat="server" >วันที่รับเช็ค</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Check_receive_date_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ที่อยู่ตามบัตรประชาชน
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Idcard_Cust_Address_no_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Address_no_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Idcard_Cust_Vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Vilage_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Idcard_Cust_Vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Vilage_no_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Idcard_Cust_Alley_Lbl" runat="server" >ซอย</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Alley_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Idcard_Cust_Road_Lbl" runat="server" >ถนน</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Road_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Idcard_Cust_Subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Subdistrict_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Idcard_Cust_District_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_District_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Idcard_Cust_Province_Lbl" runat="server" >จังหวัด</asp:Label>
                                        <asp:DropDownList ID="Idcard_Cust_Province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Idcard_Cust_Country_Lbl" runat="server" >ประเทศ</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Country_Tbx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Idcard_Cust_Zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Zipcode_Tbx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Idcard_Cust_Tel_Lbl" runat="server" >เบอร์ติดต่อ</asp:Label>
                                        <asp:TextBox ID="Idcard_Cust_Tel_Tbx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Idcard_Cust_Home_status_Lbl" runat="server" >สถานะภาพ</asp:Label>
                                        <asp:DropDownList ID="Idcard_Cust_Home_status_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ที่อยู่ตามทะเบียนบ้าน <asp:LinkButton ID="Home_Copy_Idcard_btn" runat="server" CssClass="btn btn-sm btn-success"><i class="fa fa-copy fa-fw"></i> ตามบัตรประชาชน </asp:LinkButton>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Home_Cust_Address_no_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Address_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Home_Cust_Vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Home_Cust_Vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Vilage_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Home_Cust_Alley_Lbl" runat="server" >ซอย</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_Road_Lbl" runat="server" >ถนน</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_Subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_District_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                                        <asp:TextBox ID="Home_Cust_District_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_Province" runat="server" >จังหวัด</asp:Label>
                                        <asp:DropDownList ID="Home_Cust_Province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Home_Cust_Country_Lbl" runat="server" >ประเทศ</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Home_Cust_Zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_Tel_Lbl" runat="server" >เบอร์ติดต่อ</asp:Label>
                                        <asp:TextBox ID="Home_Cust_Tel_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_Home_status_id_Lbl" runat="server" >สถานะภาพ</asp:Label>
                                        <asp:DropDownList ID="Home_Cust_Home_status_id_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_Gps_Latitude_Lbl" runat="server" >ละติจูด (Latitude) </asp:Label>
                                        <asp:TextBox ID="Home_Cust_Gps_Latitude_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Home_Cust_Gps_Longitudee_Lbl" runat="server" >ลองจิจูด (Longitude) </asp:Label>
                                        <asp:TextBox ID="Home_Cust_Gps_Longitude_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row col-lg-12">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            รูปบ้าน
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_1_Lbl" runat="server" >รูปที่ 1 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_1" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_6_Lbl" runat="server" >รูปที่ 6 </asp:Label>
                                                     <asp:FileUpload ID="img_Home_6" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_2_Lbl" runat="server" >รูปที่ 2 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_2" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_7_Lbl" runat="server" >รูปที่ 7 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_7" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_3_Lbl" runat="server" >รูปที่ 3 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_3" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_8_Lbl" runat="server" >รูปที่ 8 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_8" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_4_Lbl" runat="server" >รูปที่ 4 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_4" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_9_Lbl" runat="server" >รูปที่ 9 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_9" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_5_Lbl" runat="server" >รูปที่ 5 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_5" runat="server" CssClass="form-control"/>
                                                </div>
                                                <div class="form-group col-xs-6">
                                                    <asp:Label ID="img_Home_10_Lbl" runat="server" >รูปที่ 10 </asp:Label>
                                                    <asp:FileUpload ID="img_Home_10" runat="server" CssClass="form-control"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ที่อยู่ปัจจุบัน 
                                <asp:LinkButton ID="Current_Copy_Idcard_btn" runat="server" CssClass="btn btn-sm btn-success"><i class="fa fa-copy fa-fw"></i> ตามบัตรประชาชน </asp:LinkButton>
                                <asp:LinkButton ID="Current_Copy_Home_btn" runat="server" CssClass="btn btn-sm btn-info"><i class="fa fa-copy fa-fw"></i> ตามทะเบียนบ้าน </asp:LinkButton>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Current_Cust_Address_no_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Address_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Current_Cust_Vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Current_Cust_Vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Vilage_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Current_Cust_Alley_Lbl" runat="server" >ซอย</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Current_Cust_Road_Lbl" runat="server" >ถนน</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Current_Cust_Subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Current_Cust_District_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                                        <asp:TextBox ID="Current_Cust_District_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Current_Cust_Province_Lbl" runat="server" >จังหวัด</asp:Label>
                                        <asp:DropDownList ID="Current_Cust_Province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Current_Cust_Country_Lbl" runat="server" >ประเทศ</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Current_Cust_Zipcode" runat="server" >รหัสไปรษณีย์</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Current_Cust_Tel" runat="server" >เบอร์ติดต่อ</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Tel_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Current_Cust_Home_status_id_Lbl" runat="server" >สถานะภาพ</asp:Label>
                                        <asp:DropDownList ID="Current_Cust_Home_status_id_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ข้อมูลการทำงาน
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Cust_job_Lbl" runat="server" >อาชีพ</asp:Label>
                                        <asp:TextBox ID="Cust_job_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_position_Lbl" runat="server" >ตำแหน่ง</asp:Label>
                                        <asp:TextBox ID="Cust_job_position_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_long_Lbl" runat="server" >อายุงาน</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Cust_job_long_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">ปี</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_salary_Lbl" runat="server" >รายได้</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Cust_job_salary_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Cust_job_local_name_Lbl" runat="server" >ชื่อสถานประกอบการ (ที่ทำงาน)</asp:Label>
                                        <asp:TextBox ID="Cust_job_local_name_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Cust_job_address_no_Lbl" runat="server" >ที่อยู่ที่ทำงาน เลขที่</asp:Label>
                                        <asp:TextBox ID="Cust_job_address_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Cust_job_vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                                        <asp:TextBox ID="Cust_job_vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Cust_job_vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                                        <asp:TextBox ID="Cust_job_vilage_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Cust_job_alley_Lbl" runat="server" >ซอย</asp:Label>
                                        <asp:TextBox ID="Cust_job_alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_road_Lbl" runat="server" >ถนน</asp:Label>
                                        <asp:TextBox ID="Cust_job_road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                                        <asp:TextBox ID="Cust_job_subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_district_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                                        <asp:TextBox ID="Cust_job_district_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_province_Lbl" runat="server" >จังหวัด</asp:Label>
                                        <asp:DropDownList ID="Cust_job_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Cust_job_contry_Lbl" runat="server" >ประเทศ</asp:Label>
                                        <asp:TextBox ID="Cust_job_contry_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Cust_job_zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                                        <asp:TextBox ID="Cust_job_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_tel_Lbl" runat="server" >โทรศัพท์</asp:Label>
                                        <asp:TextBox ID="Cust_job_tel_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_job_email_Lbl" runat="server" >อีเมล์</asp:Label>
                                        <asp:TextBox ID="Cust_job_email_TBx" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ข้อมูลคู่สมรส
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Spouse_idcard_Lbl" runat="server" >รหัสบัตรประชาชน</asp:Label>
                                        <asp:TextBox ID="Spouse_idcard_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_Fname_Lbl" runat="server" >ชื่อ</asp:Label>
                                        <asp:TextBox ID="Spouse_Fname_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_Lname_Lbl" runat="server" >นามสกุล</asp:Label>
                                        <asp:TextBox ID="Spouse_Lname_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_Origin_Lbl" runat="server" >เชื้อชาติ</asp:Label>
                                        <asp:DropDownList ID="Spouse_Origin_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_Nationality_Lbl" runat="server" >สัญชาติ</asp:Label>
                                        <asp:DropDownList ID="Spouse_Nationality_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_address_no_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                                        <asp:TextBox ID="Spouse_address_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                                        <asp:TextBox ID="Spouse_vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                                        <asp:TextBox ID="Spouse_vilage_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_alley_Lbl" runat="server" >ซอย</asp:Label>
                                        <asp:TextBox ID="Spouse_alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Spouse_road_Lbl" runat="server" >ถนน</asp:Label>
                                        <asp:TextBox ID="Spouse_road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                                        <asp:TextBox ID="Spouse_subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_district_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                                        <asp:TextBox ID="Spouse_district_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_province_Lbl" runat="server" >จังหวัด</asp:Label>
                                        <asp:DropDownList ID="Spouse_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_country_Lbl" runat="server" >ประเทศ</asp:Label>
                                        <asp:TextBox ID="Spouse_country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                                        <asp:TextBox ID="Spouse_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Spouse_job_Lbl" runat="server" >อาชีพ</asp:Label>
                                        <asp:TextBox ID="Spouse_job_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_position_Lbl" runat="server" >ตำแหน่ง</asp:Label>
                                        <asp:TextBox ID="Spouse_job_position_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_long_Lbl" runat="server" >อายุงาน</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Spouse_job_long_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">ปี</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_salary_Lbl" runat="server" >รายได้</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Spouse_job_salary_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Spouse_job_local_name_Lbl" runat="server" >ชื่อสถานประกอบการ (ที่ทำงาน)</asp:Label>
                                        <asp:TextBox ID="Spouse_job_local_name_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Spouse_job_address_no_Lbl" runat="server" >ที่อยู่ที่ทำงาน เลขที่</asp:Label>
                                        <asp:TextBox ID="Spouse_job_address_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_job_vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                                        <asp:TextBox ID="Spouse_job_vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_job_vilage_no_Lbl" runat="server" >หมู่ที่</asp:Label>
                                        <asp:TextBox ID="Spouse_job_vilage_no_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_job_alley_Lbl" runat="server" >ซอย</asp:Label>
                                        <asp:TextBox ID="Spouse_job_alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_road_Lbl" runat="server" >ถนน</asp:Label>
                                        <asp:TextBox ID="Spouse_job_road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                                        <asp:TextBox ID="Spouse_job_subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_district_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                                        <asp:TextBox ID="Spouse_job_district_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_province_Lbl" runat="server" >จังหวัด</asp:Label>
                                        <asp:DropDownList ID="Spouse_job_province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-1">
                                        <asp:Label ID="Spouse_job_country_Lbl" runat="server" >ประเทศ</asp:Label>
                                        <asp:TextBox ID="Spouse_job_country_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Spouse_job_zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                                        <asp:TextBox ID="Spouse_job_zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_job_tel_Lbl" runat="server" >โทรศัพท์</asp:Label>
                                        <asp:TextBox ID="Spouse_job_tel_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_tel_Lbl" runat="server" >มือถือ</asp:Label>
                                        <asp:TextBox ID="Spouse_tel_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Spouse_email_Lbl" runat="server" >อีเมล์</asp:Label>
                                        <asp:TextBox ID="Spouse_email_TBx" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.ข้อมูลผู้ทำสัญญา -->

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:LinkButton ID="btn_Save" runat="server" CssClass="btn btn-default btn-primary btn_block" OnClick="btn_Save_Click"><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>

