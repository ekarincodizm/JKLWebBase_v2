using System.Collections.Generic;

using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Class_Customers
{
    public class Customers
    {
        public string Cust_id { get; set; } //รหัสลูกค้า
        public string Cust_idcard { get; set; } //รหัสบัตรประชาชนลูกค้า
        public string Cust_Fname { get; set; } //ชื่อลูกค้า
        public string Cust_LName { get; set; } //นามสกุลลูกค้า
        public string Cust_B_date { get; set; } //วันเกิด
        public int Cust_age { get; set; } //อายุ
        public string Cust_Idcard_without { get; set; } //ออกบัตรประชาชนที่
        public string Cust_Idcard_start { get; set; } //วันที่ออกบัตร
        public string Cust_Idcard_expire { get; set; } //วันที่บัตรหมดอายุ
        public int Cust_Nationality { get; set; } //สัญชาติ
        public int Cust_Origin { get; set; } //เชื้อชาติ
        public string Cust_job { get; set; } //อาชีพ
        public string Cust_job_position { get; set; } //ตำแหน่งงาน
        public int Cust_job_long { get; set; } //อายุงาน
        public string Cust_job_local_name { get; set; } //ชื่อสถานที่ทำงาน
        public string Cust_job_address_no { get; set; } //ที่อยู่ที่ทำงาน เลขที่
        public string Cust_job_vilage { get; set; } //หมู่บ้าน
        public string Cust_job_vilage_no { get; set; } //หมู่ที่
        public string Cust_job_alley { get; set; } //ซอย
        public string Cust_job_road { get; set; } //ถนน
        public string Cust_job_subdistrict { get; set; } //ตำบล / แขวง
        public string Cust_job_district { get; set; } //อำเภอ / เขต
        public int Cust_job_province { get; set; } //จังหวัด
        public string Cust_job_country { get; set; } //ประเทศ
        public string Cust_job_zipcode { get; set; } //รหัสไปรษณีย์
        public string Cust_job_tel { get; set; } //เบอร์โทรศัพท์
        public string Cust_job_email { get; set; } //อีเมล์
        public double Cust_job_salary { get; set; } //เงินเดือน
        public int Cust_status_id { get; set; } //รหัสสถานะภาพการสมรส
        public string Cust_save_date { get; set; }
        public Base_Nationalitys bs_ntn { get; set; }
        public Base_Origins bs_org { get; set; }
        public TH_Provinces th_pv_job_ctm { get; set; }
        public Base_Person_Status bs_ps_st { get; set; }
        public List<Customers_Address> list_add { get; set; }
        public List<Customers_Homeaddress_Photo> list_photo { get; set; }
        public Customers_Spouse ctm_marry { get; set; }
    }
}