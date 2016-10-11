<%@ Page Title="เพิ่มสัญญาเช่า-ซื้อ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Add.aspx.cs" Inherits="JKLWebBase_v2.Leasing_Form.Leasing_Add" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header"> เพิ่มข้อมูลสัญญาเช่า-ซื้อ </h1>
    </div>
    <ul class="nav nav-tabs">
      <li role="presentation" ><asp:LinkButton ID="link_Customer_Add" runat="server"  ><i class="fa fa-male fa-fw"></i> ผู้ทำสัญญา </asp:LinkButton></li>
      <li role="presentation" class="active"><asp:LinkButton ID="link_Leasing_Add" runat="server" Enabled="false" ><i class="fa fa-book fa-fw"></i> สัญญาเช่า - ซื้อ </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Dealers_Add" runat="server" Enabled="false" ><i class="fa fa-male fa-fw"></i> นายหน้า </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_1" runat="server" Enabled="false" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 1</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_2" runat="server" Enabled="false" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 2</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_3" runat="server" Enabled="false" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 3</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_4" runat="server" Enabled="false" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 4</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Bondsman_5" runat="server" Enabled="false" ><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 5</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Car_Img" runat="server" Enabled="false" ><i class="fa fa-car fa-fw"></i>รูปรถ</asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Home_Img" runat="server" Enabled="false" ><i class="fa fa-home fa-fw"></i> รูปบ้าน</asp:LinkButton></li>
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
                                <asp:TextBox ID="Car_Register_Date_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
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
                            <asp:TextBox ID="Car_Credits_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Dealer_Lbl" runat="server" >ตัวแทนรถ</asp:Label>
                            <asp:TextBox ID="Car_Dealer_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Lbl" runat="server" >เจ้าของรถเดิม</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Idcard_Lbl" runat="server" >เลขบัตรประชาชน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Idcard_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Idcard_Str_Lbl" runat="server" >วันที่ออกบัตร</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Old_Owner_Idcard_Str_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Idcard_Exp_Lbl" runat="server" >วันที่หมดอายุ</asp:Label>
                            <div class="form-group input-group">
                                <asp:TextBox ID="Car_Old_Owner_Idcard_Exp_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Address_No_Lbl" runat="server" >ที่อยู่ เลขที่</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Address_No_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Vilage_Lbl" runat="server" >หมู่บ้าน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Vilage_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Vilage_No_Lbl" runat="server" >หมู่ที่</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Vilage_No_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_alley_Lbl" runat="server" >ซอย</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_alley_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Road_Lbl" runat="server" >ถนน</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Road_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Subdistrict_Lbl" runat="server" >ตำบล / แขวง</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Subdistrict_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_District_Lbl" runat="server" >อำเภอ / เขต</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_District_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Province_Lbl" runat="server" >จังหวัด</asp:Label>
                            <asp:DropDownList ID="Car_Old_Owner_Province_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Car_Old_Owner_Contry_Lbl" runat="server" >ประเทศ</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Contry_TBx" runat="server" CssClass="form-control" Text="ประเทศไทย"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Label ID="Car_Old_Owner_Zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                            <asp:TextBox ID="Car_Old_Owner_Zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
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
                <!-- /.ข้อมูลรถ -->

                <!-- ข้อมูลสัญญา -->
                <div class="panel-heading">
                    ข้อมูลสัญญา
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-xs-2">
                            <asp:Label ID="Deps_No_Lbl" runat="server" >เลขที่รับฝาก</asp:Label>
                            <asp:TextBox ID="Deps_No_TBx" runat="server" CssClass="form-control" OnTextChanged="Deps_No_Tbx_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Leasing_Code_Lbl" runat="server" >รหัสสัญญา</asp:Label>
                            <asp:DropDownList ID="Leasing_Code_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:Label ID="Leasing_No_Lbl" runat="server" >เลขที่สัญญา</asp:Label>
                            <asp:TextBox ID="Leasing_No_TBx" runat="server" CssClass="form-control"></asp:TextBox>
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
                            <asp:Label ID="TotalPaymentTime_Lbl" runat="server" >ระยะเวลาชำระเงิน</asp:Label>
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
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Payment_Schedule_Lbl" runat="server" >กำหนดชำระทุกวันที่</asp:Label>
                                        <asp:DropDownList ID="Payment_Schedule_DDL" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="First_Payment_Date_Lbl" runat="server" >วันที่เริ่มชำระ</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="First_Payment_Date_TBx" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
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
                                    <div class="col-xs-1">
                                        <asp:Label ID="Interest_Rate_Lbl" runat="server" >อัตราดอกเบี้ย</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Interest_Rate_TBx" runat="server" CssClass="form-control" TextMode="Number" ></asp:TextBox>
                                            <span class="input-group-addon"> % </span>
                                        </div>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Vat_Lbl" runat="server" > ภาษีมูลค่าเพิ่ม </asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Vat_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon"> % </span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Period_Lbl" runat="server" > ระยะเวลา </asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Period_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            <span class="input-group-addon"> งวด </span>
                                        </div>
                                    </div>
                                    <div class="col-xs-1">
                                        <asp:Label ID="Calculate_Lbl" runat="server" > คำนวน </asp:Label>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon"> <i class="fa fa-gears fa-fw"></i> </span>
                                            <asp:LinkButton ID="Calculate_Btn" runat="server" CssClass="btn btn-xs btn-success" OnClick="Calculate_Btn_Click"> คำนวน </asp:LinkButton>
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
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Total_Sum_Lbl" runat="server" >ยอดรวม</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Sum_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Interest_Lbl" runat="server" >ดอกเบี้ย</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Interest_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Tax_Lbl" runat="server" >ภาษี</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Tax_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-addon">บาท</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Total_Leasing_Lbl" runat="server" >ยอดเช่า-ซื้อ</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Total_Leasing_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Period_Cal_Lbl" runat="server" >ค่างวด</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Period_Cal_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-addon">บาท / งวด</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Tax_per_m_Lbl" runat="server" >ภาษี / งวด</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Tax_per_m_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-addon">บาท / งวด</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Period_pure_Lbl" runat="server" >ค่างวดสุดธิ</asp:Label>
                                        <div class="form-group input-group">
                                            <asp:TextBox ID="Period_pure_TBx" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            <span class="input-group-addon">บาท / งวด</span>
                                        </div>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Period_Payment_Lbl" runat="server" >ค่างวดจ่ายจริง</asp:Label>
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
                <!-- /.ข้อมูลการประเมิน -->

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:LinkButton ID="Leasing_Add_Save_Btn" runat="server" CssClass="btn btn-default btn-primary btn_block" OnClick="Leasing_Add_Save_Btn_Click" ><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>

