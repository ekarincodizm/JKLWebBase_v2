using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using System.Collections.Generic;

namespace JKLWebBase_v2.Class_Leasings
{
    public class Car_Leasings
    {
        public string Leasing_id { get; set; } /// รหัสลิสซิ่ง
        public string Deps_no { get; set; } /// เลขที่รับฝาก
        public string Leasing_no { get; set; } /// เลขที่สัญญา
        public Base_Leasing_Code bs_ls_code { get; set; } /// รหัสสัญญา
        public string Leasing_date { get; set; } /// วันที่ทำสัญญา
        public Base_Companys bs_cpn { get; set; } /// สำนักงาน
        public Base_Zone_Service bs_zn { get; set; } /// เขต
        public Base_Courts bs_ct { get; set; } /// กรณีส่งฟ้องศาล
        public string PeReT { get; set; } /// ผู้รับโอน (Person Receive Transfer)
        public int TotalPaymentTime { get; set; } /// ระยะเวลาชำระเงิน
        public double Total_require { get; set; } /// ยอดจัด / เงินต้น
        public double Vat_rate { get; set; } /// อัตราภาษี
        public double Interest_rate { get; set; } /// อัตราดอกเบี้ย
        public int Total_period { get; set; } /// ระยะเวลา / จำนวนงวด
        public double Total_sum { get; set; } /// ยอดรวม / มูลค่า
        public double Total_Interest { get; set; } /// ดอกเบี้ยทั้งหมด
        public double Total_Tax { get; set; } /// ภาษีมูลค่าเพิ่ม
        public double Total_leasing { get; set; } /// ยอดเช่า - ซื้อ
        public double Total_Net_leasing { get; set; } /// ยอดเช่า - ซื้อสุทธิ (ชำระจริง)
        public double Period_cal { get; set; } /// มูลค่า/เดือน
        public double Period_interst { get; set; } /// ดอกเบี้ย/เดือน
        public double Period_tax { get; set; } /// ภาษี/เดือน
        public double Period_pure { get; set; } /// ค่างวด/เดือน
        public double Period_payment { get; set; } /// ค่างวดสุทธิ/เดือน (ชำระจริง)
        public double Period_require { get; set; } /// เงินต้น / งวด
        public string Total_period_length { get; set; } /// จำนวนงวดที่ขาดชำระ (ช่วง) ex. 2 - 5 เป็นต้น
        public int Total_period_lose { get; set; } /// จำนวนงวดทั้งหมดที่ขาดชำระ
        public int Total_period_left { get; set; } /// จำนวนงวดทั้งหมดที่ยังไม่ได้ชำระ
        public double Total_payment_left { get; set; } /// ยอดเช่า - ซื้อคงเหลือทั้งหมด
        public int Payment_schedule { get; set; } /// กำหนดชำระทุกวันที่
        public string First_payment_date { get; set; } /// วันที่เริ่มชำระ
        public string Car_register_date { get; set; } /// วันที่จัดทะเบียน
        public string Car_license_plate { get; set; } /// เลขทะเบียนรถ
        public string Car_license_plate_province { get; set; } /// เลขทะเบียนรถจังหวัด
        public string Car_type { get; set; } /// ประเภทรถ
        public string Car_feature { get; set; } /// ลักษณะ
        public Base_Car_Brands bs_cbrn { get; set; } /// ยี่ห้อรถ
        public string Car_model { get; set; } /// แบบรถ
        public string Car_year { get; set; } /// ปีรถ
        public string Car_color { get; set; } /// สีรถ
        public string Car_engine_no { get; set; } /// เลขตัวเครื่อง
        public string Car_engine_no_at { get; set; } /// เลขตัวเครื่องอยู่ที่
        public string Car_engine_brand { get; set; } /// ยี่ห้อเครื่องยนต์
        public string Car_chassis_no { get; set; } /// เลขตัวถัง
        public string Car_chassis_no_at { get; set; } /// เลขตัวถังอยู่ที่
        public string Car_fual_type { get; set; } /// เชื้อเพลิง
        public string Car_gas_No { get; set; } /// เลขถังแก๊ส
        public int Car_used_id { get; set; } /// สภาพรถ
        public double Car_distance { get; set; } /// ระยะทาง
        public string Car_next_register_date { get; set; } /// วันที่ต่อทะเบียน
        public double Car_tax_value { get; set; } /// ค่าต่อภาษี
        public string Car_credits { get; set; } /// สินเชื่อ
        public string Car_agent { get; set; } /// ตัวแทนรถ
        public string Car_old_owner { get; set; } /// เจ้าของรถเดิม
        public string Car_old_owner_idcard { get; set; } /// เลขบัตรประชาชนเจ้าของรถเดิม
        public string Car_old_owner_b_date { get; set; } /// วันเกิดเจ้าของรถเดิม
        public string Car_old_owner_address_no { get; set; } /// บ้านเลขที่เจ้าของรถเดิม
        public string Car_old_owner_vilage { get; set; } /// หมู่บ้าน
        public string Car_old_owner_vilage_no { get; set; } /// หมู่ที่
        public string Car_old_owner_alley { get; set; } /// ซอย
        public string Car_old_owner_road { get; set; } /// ถนน
        public string Car_old_owner_subdistrict { get; set; } /// ตำบล
        public string Car_old_owner_district { get; set; } /// อำเภอ
        public string Car_old_owner_province { get; set; } /// จังหวัด
        public string Car_old_owner_contry { get; set; } /// ประเทศ
        public string Car_old_owner_zipcode { get; set; } /// รหัสไปรษณีย์
        public Base_Tents_Car tent_car { get; set; } /// รหัสเต็นท์รถ
        public string Cheque_receiver { get; set; } /// ชื่อผู้รับเช็ค / โอน
        public string Cheque_bank { get; set; } /// ธนาคาร
        public string Cheque_bank_branch { get; set; } /// สาขา
        public string Cheque_number { get; set; } /// หมายเลขเช็ค / เลขบัญชีธนาคาร
        public double Cheque_sum { get; set; } /// ยอดจ่ายเช็ค / โอน
        public string Cheque_receive_date { get; set; } /// วันที่รับเช็ค / โอน
        public string Guarantee { get; set; } /// หลักประกันในการค้ำประกัน
        public Base_Leasing_Status bs_ls_stt { get; set; } /// สถานะสัญญา
        public string Leasing_Comment { get; set; } /// หมายเหตุ
        public string Leasings_save_date { get; set; } /// วันที่บันทึกข้อมูล
        public string last_payment_date { get; set; } /// วันที่บันทึกข้อมูล
        public Customers ctm { get; set; } /// ผู้ทำสัญญา
        public List<Car_Leasings_Guarator> list_cls_grt { get; set; } /// ผู้ค้ำประกัน
    }
}