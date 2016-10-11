namespace JKLWebBase_v2.Class_Leasings
{
    public class Car_Leasings
    {
        public string Leasing_id { get; set; } //ลำดับเลขสัญญาณา
        public string Deps_no { get; set; } //เลขที่รับฝาก
        public string Leasing_no { get; set; } //เลขที่สัญญา
        public int Leasing_code_id { get; set; } //รหัสสัญญา
        public string Leasing_date { get; set; } //วันที่ทำสัญญา
        public int Branch_id { get; set; } //สาขา
        public int Zone_id { get; set; } //เขต
        public int Court_id { get; set; } //กรณีส่งฟ้องศาล
        public string PeReT { get; set; } //ผู้รับโอน (Person Receive Transfer)
        public int TotalPaymentTime { get; set; } //ระยะเวลาชำระเงิน
        public double Total_require { get; set; } //ยอดจัด
        public double Interest_rate { get; set; } //อัตราดอกเบี้ย
        public int Total_period { get; set; } //จำนวนงวดทั้งหมด
        public double Total_sum { get; set; } //ยอดรวม
        public double Total_Interest { get; set; } //ดอกเบี้ยทั้งหมด
        public double Total_Tax { get; set; } //ภาษีทั้งหมด
        public double Total_leasing { get; set; } //ยอดเช่าซื้อ
        public double Period_cal { get; set; } //ค่างวด/เดือน
        public double Tax_per_m { get; set; } //ภาษี/เดือน
        public double Period_pure { get; set; } //ค่างวดสุทธิ/เดือน
        public double Period_payment { get; set; } //ค่างวดจ่ายจริง/เดือน
        public int Payment_schedule { get; set; } //กำหนดชำระทุกวันที่
        public string First_payment_date { get; set; } //วันที่เริ่มชำระ
        public int Car_type { get; set; } //ประเภทรถ
        public int Car_brand { get; set; } //ยี่ห้อรถ
        public int Car_model { get; set; } //รุ่นรถ
        public string Car_color { get; set; } //สีรถ
        public string Car_license_plate { get; set; } //เลขทะเบียนรถ
        public string Car_engine_no { get; set; } //เลขตัวเครื่อง
        public string Car_chassis_no { get; set; } //เลขตัวถัง
        public string Car_year { get; set; } //ปีรถ
        public int Car_used_id { get; set; } //สภาพรถ
        public int Car_distance { get; set; } //ระยะทาง
        public string Car_register_date { get; set; } //วันที่จัดทะเบียน
        public string Car_next_register_date { get; set; } //วันที่ต่อทะเบียน
        public double Car_tax_value { get; set; } //ค่าต่อภาษี
        public string Car_credits { get; set; } //สินเชื่อ
        public string Car_dealer { get; set; } //ตัวแทนรถ
        public string Car_old_owner { get; set; } //เจ้าของรถเดิม
        public string Car_old_owner_idcard { get; set; } //เลขบัตรประชาชนเจ้าของรถเดิม
        public string Car_old_owner_idcard_str { get; set; } //วันที่ออกบัตรเจ้าของรถเดิม
        public string Car_old_owner_idcard_exp { get; set; } //วันที่หมดอายุบัตรเจ้าของรถเดิม
        public string Car_old_owner_address_no { get; set; } //บ้านเลขที่เจ้าของรถเดิม
        public string Car_old_owner_vilage { get; set; } //หมู่บ้าน
        public string Car_old_owner_vilage_no { get; set; } //หมู่ที่
        public string Car_old_owner_alley { get; set; } //ซอย
        public string Car_old_owner_road { get; set; } //ถนน
        public string Car_old_owner_subdistrict { get; set; } //ตำบล
        public string Car_old_owner_district { get; set; } //อำเภอ
        public int Car_old_owner_province { get; set; } //จังหวัด
        public string Car_old_owner_contry { get; set; } //ประเทศ
        public string Car_old_owner_zipcode { get; set; } //รหัสไปรษณีย์
        public string Cust_idcard { get; set; } //ผู้ทำสัญญา
        public int Tent_car_id { get; set; } //รหัสเต็นท์รถ
        public string Check_receive_person { get; set; } //ชื่อผู้รับเช็ค
        public string Check_number { get; set; } //หมายเลขเช็ค
        public double Check_payment { get; set; } //ยอดจ่ายเช็ค
        public string Check_receive_date { get; set; } //วันที่รับเช็ค
        public string Contract_status { get; set; } //สถานะสัญญา
    }
}