<%@ Page Title="ผู้ค้ำประกัน" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leasing_Add_Bondsman.aspx.cs" Inherits="JKLWebBase_v2.Leasing_Form.Leasing_Add_Bondsman_1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Alert MessagesBox -->
    <asp:Panel ID="Alert_Warning_Panel" runat="server" Visible="false">
    <div class="col-md-6 col-md-offset-3">
        <div class="alert alert-warning" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
               <span aria-hidden="true">&times;</span>
            </button>
            <div class="modal-header">
              <h6 class="modal-title"><i class="fa fa-warning fa-fw"></i> !! แจ้งเตือน !! </h6>
            </div>
            <div class="modal-body">
              <p> <asp:Label ID="Alert_Id_Card_Lbl" runat="server" > ไม่พบเลขบัตรประชาชน . . . นี้ในระบบ </asp:Label> </p>
            </div>
        </div>
    </div>
    </asp:Panel>
    <!-- Alert MessagesBox -->

    <div class="col-lg-12">
        <h4 class="page-header"> เพิ่มข้อมูลผู้ค้ำประกันคนที่ <asp:Label ID="Number_Of_Bondsman" runat="server"></asp:Label> </h4>
    </div>
    <ul class="nav nav-tabs">
      <li role="presentation" ><asp:LinkButton ID="link_Customer_Add" runat="server" OnClick="link_Customer_Add_Click"><i class="fa fa-male fa-fw"></i> ผู้ทำสัญญา </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Leasing_Add" runat="server" OnClick="link_Leasing_Add_Click"><i class="fa fa-book fa-fw"></i> สัญญาเช่า - ซื้อ </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Dealers_Add" runat="server" OnClick="link_Dealers_Add_Click"><i class="fa fa-male fa-fw"></i> นายหน้า </asp:LinkButton></li>
      <li role="presentation" <%= Session["Number_Of_Bondsman"].ToString().Equals("1") ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_1" runat="server" OnClick="link_Add_Bondsman_1_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 1 </asp:LinkButton></li>
      <li role="presentation" <%= Session["Number_Of_Bondsman"].ToString().Equals("2") ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_2" runat="server" OnClick="link_Add_Bondsman_2_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 2 </asp:LinkButton></li>
      <li role="presentation" <%= Session["Number_Of_Bondsman"].ToString().Equals("3") ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_3" runat="server" OnClick="link_Add_Bondsman_3_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 3 </asp:LinkButton></li>
      <li role="presentation" <%= Session["Number_Of_Bondsman"].ToString().Equals("4") ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_4" runat="server" OnClick="link_Add_Bondsman_4_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 4 </asp:LinkButton></li>
      <li role="presentation" <%= Session["Number_Of_Bondsman"].ToString().Equals("5") ? "class='active'" : "" %> ><asp:LinkButton ID="link_Add_Bondsman_5" runat="server" OnClick="link_Add_Bondsman_5_Click"><i class="fa fa-group fa-fw"></i> ผู้ค้ำประกัน 5 </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Car_Img" runat="server" OnClick="link_Add_Car_Img_Click"><i class="fa fa-car fa-fw"></i> รูปรถ </asp:LinkButton></li>
      <li role="presentation" ><asp:LinkButton ID="link_Add_Home_Img" runat="server" OnClick="link_Add_Home_Img_Click"><i class="fa fa-home fa-fw"></i> รูปบ้าน </asp:LinkButton></li>
    </ul>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <!-- Modal -->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                      </div>
                      <div class="modal-body">
                        ...
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                      </div>
                    </div>
                  </div>
                </div>
                <!-- Modal -->

                <!-- ข้อมูลผู้ทำสัญญา -->
                <div class="panel-heading">
                    ข้อมูลผู้ทำสัญญา <button  type="button" Class="btn btn-sm btn-info" data-toggle="modal" data-target="#myModal"><i class="fa fa-search fa-fw"></i> ค้นหา </button>
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
                                            <asp:TextBox ID="Cust_idcard_TBx" runat="server" CssClass="form-control" OnTextChanged="Cust_idcard_TBx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:LinkButton ID="Cust_Search_Btn" runat="server" CssClass="input-group-addon search" OnClick="Cust_Search_Btn_Click" ><i class="fa fa-search fa-fw"></i> ค้นหา </asp:LinkButton>
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
                                        <div class="form-group input-group" id="Cust_Idcard_start">
                                            <asp:TextBox ID="Cust_Idcard_start_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                        <script type="text/javascript">   
                                            $(function(){
	
	                                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
	
	                                            // กรณีใช้แบบ input
                                                $("#Cust_Idcard_start").datetimepicker({
                                                    timepicker:false,
                                                    format:'d-m-Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                                    lang:'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
		                                            onSelectDate:function(dp,$input){
			                                            var yearT=new Date(dp).getFullYear()-0;  
			                                            var yearTH=yearT+543;
			                                            var fulldate=$input.val();
			                                            var fulldateTH=fulldate.replace(yearT,yearTH);
			                                            $("<%= "#" + Cust_Idcard_start_TBx.ClientID %>").val(fulldateTH);
		                                            },
                                                });

	                                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                                $("<%= "#" + Cust_Idcard_start_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
		                                            var dateValue=$(this).val();
		                                            if(dateValue!=""){
				                                            var arr_date=dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
				                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
				                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
				                                            if(e.type=="mouseenter"){
					                                            var yearT=arr_date[2]-543;
				                                            }		
				                                            if(e.type=="mouseleave"){
					                                            var yearT=parseInt(arr_date[2])+543;
				                                            }	
				                                            dateValue=dateValue.replace(arr_date[2],yearT);
				                                            $(this).val(dateValue);													
		                                            }		
	                                            });
                                            });
                                        </script>   
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_Idcard_expire_Lbl" runat="server" >วันที่หมดอายุ</asp:Label>
                                        <div class="form-group input-group" id="Cust_Idcard_expire">
                                            <asp:TextBox ID="Cust_Idcard_expire_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                                       </div>
                                       <script type="text/javascript">   
                                            $(function(){
	
	                                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
	
	                                            // กรณีใช้แบบ input
	                                            $("#Cust_Idcard_expire").datetimepicker({
                                                    timepicker:false,
                                                    format:'d-m-Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                                    lang:'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
		                                            onSelectDate:function(dp,$input){
			                                            var yearT=new Date(dp).getFullYear()-0;  
			                                            var yearTH=yearT+543;
			                                            var fulldate=$input.val();
			                                            var fulldateTH=fulldate.replace(yearT,yearTH);
			                                            $("<%= "#" + Cust_Idcard_expire_TBx.ClientID %>").val(fulldateTH);
		                                            },
                                                });

	                                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                                $("<%= "#" + Cust_Idcard_expire_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
		                                            var dateValue=$(this).val();
		                                            if(dateValue!=""){
				                                            var arr_date=dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
				                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
				                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
				                                            if(e.type=="mouseenter"){
					                                            var yearT=arr_date[2]-543;
				                                            }		
				                                            if(e.type=="mouseleave"){
					                                            var yearT=parseInt(arr_date[2])+543;
				                                            }	
				                                            dateValue=dateValue.replace(arr_date[2],yearT);
				                                            $(this).val(dateValue);													
		                                            }		
	                                            });
                                            });
                                        </script>  
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-xs-2">
                                        <asp:Label ID="Cust_B_date_Lbl" runat="server" >วันเกิด</asp:Label>
                                        <div class="form-group input-group date" id="Cust_B_date">
                                            <asp:TextBox ID="Cust_B_date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="input-group-addon date"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                        <script type="text/javascript">   
                                            $(function(){
	
	                                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
	
	                                            // กรณีใช้แบบ input
	                                            $("#Cust_B_date").datetimepicker({
                                                    timepicker:false,
                                                    format:'d-m-Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                                    lang:'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
		                                            onSelectDate:function(dp,$input){
			                                            var yearT=new Date(dp).getFullYear()-0;  
			                                            var yearTH=yearT+543;
			                                            var fulldate=$input.val();
			                                            var fulldateTH=fulldate.replace(yearT,yearTH);
			                                            $("<%= "#" + Cust_B_date_TBx.ClientID %>").val(fulldateTH);
		                                            },
                                                });

	                                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                                $("<%= "#" + Cust_B_date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
		                                            var dateValue=$(this).val();
		                                            if(dateValue!=""){
				                                            var arr_date=dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
				                                            // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
				                                            //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
				                                            if(e.type=="mouseenter"){
					                                            var yearT=arr_date[2]-543;
				                                            }		
				                                            if(e.type=="mouseleave"){
					                                            var yearT=parseInt(arr_date[2])+543;
				                                            }	
				                                            dateValue=dateValue.replace(arr_date[2],yearT);
				                                            $(this).val(dateValue);													
		                                            }		
	                                            });
                                            });
                                        </script>   
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label ID="Cust_Idcard_without_Lbl" runat="server" >ออกโดย</asp:Label>
                                        <asp:TextBox ID="Cust_Idcard_without_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Cust_status_Lbl" runat="server" >สถานะภาพการสมรส</asp:Label>
                                        <asp:DropDownList ID="Cust_status_DDL" runat="server" CssClass="form-control" OnSelectedIndexChanged="Cust_status_DDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                                ที่อยู่ตามทะเบียนบ้าน <asp:LinkButton ID="Home_Copy_Idcard_btn" runat="server" CssClass="btn btn-sm btn-success" OnClick="Home_Copy_Idcard_btn_Click"><i class="fa fa-copy fa-fw"></i> ตามบัตรประชาชน </asp:LinkButton>
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
                                        <asp:Label ID="Home_Cust_Province_Lbl" runat="server" >จังหวัด</asp:Label>
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
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                ที่อยู่ปัจจุบัน 
                                <asp:LinkButton ID="Current_Copy_Idcard_btn" runat="server" CssClass="btn btn-sm btn-success" OnClick="Current_Copy_Idcard_btn_Click"><i class="fa fa-copy fa-fw"></i> ตามบัตรประชาชน </asp:LinkButton>
                                <asp:LinkButton ID="Current_Copy_Home_btn" runat="server" CssClass="btn btn-sm btn-info" OnClick="Current_Copy_Home_btn_Click"><i class="fa fa-copy fa-fw"></i> ตามทะเบียนบ้าน </asp:LinkButton>
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
                                        <asp:Label ID="Current_Cust_Zipcode_Lbl" runat="server" >รหัสไปรษณีย์</asp:Label>
                                        <asp:TextBox ID="Current_Cust_Zipcode_TBx" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:Label ID="Current_Cust_Tel_Lbl" runat="server" >เบอร์ติดต่อ</asp:Label>
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
                                    <div class="col-xs-3">
                                        <asp:Label ID="Cust_job_position_Lbl" runat="server" >ตำแหน่ง</asp:Label>
                                        <asp:TextBox ID="Cust_job_position_TBx" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1">
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
                                            <span class="input-group-addon"> บาท </span>
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

                    <asp:Panel ID="Spouse_Panel" runat="server" Visible="false">
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
                                            <span class="input-group-addon"> บาท </span>
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
                    </asp:Panel>

                </div>
                <!-- /.ข้อมูลผู้ทำสัญญา -->

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:LinkButton ID="Customer_Add_Save_Btn" runat="server" CssClass="btn btn-md btn-primary btn-block" OnClick="Customer_Add_Save_Btn_Click"><i class="fa fa-save fa-fw"></i>บันทึก</asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>