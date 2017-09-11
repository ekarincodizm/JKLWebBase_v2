using System.Collections.Generic;

using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Class_Customers
{
    public class Customers
    {
        public string Cust_id { get; set; } /// รหัสลูกค้า
        public string Cust_Idcard { get; set; } /// รหัสบัตรประชาชนลูกค้า
        public string Cust_Fname { get; set; } /// ชื่อลูกค้า
        public string Cust_LName { get; set; } /// นามสกุลลูกค้า
        public string Cust_B_date { get; set; } /// วันเกิด
        public int Cust_Age { get; set; } /// อายุ
        public string Cust_Idcard_without { get; set; } /// ออกบัตรประชาชนที่
        public string Cust_Idcard_start { get; set; } /// วันที่ออกบัตร
        public string Cust_Idcard_expire { get; set; } /// วันที่บัตรหมดอายุ
        public Base_Nationalitys ctm_ntnlt { get; set; } /// สัญชาติ
        public Base_Origins ctm_org { get; set; } /// เชื้อชาติ
        public string Cust_Tel { get; set; } /// เบอร์โทรศัพท์ลูกค้า
        public string Cust_Email { get; set; } /// อีเมล์ลูกค้า
        public Base_Person_Status ctm_pstt { get; set; } /// สถานะภาพการสมรส
        public string Cust_Marry_idcard { get; set; } /// รหัสบัตรประชาชนคู่สมรส
        public string Cust_Marry_Fname { get; set; } /// ชื่อคู่สมรส
        public string Cust_Marry_Lname { get; set; } /// นามสกลคู่สมรส
        public Base_Nationalitys ctm_marry_ntnlt { get; set; } /// สัญชาติคู่สมรส
        public Base_Origins ctm_marry_org { get; set; } /// เชื้อชาติคู่สมรส
        public string Cust_Marry_Address_no { get; set; } /// ที่อยู่ของคู่สมรส เลขที่
        public string Cust_Marry_vilage { get; set; } /// ชื่อหมู่บ้าน
        public string Cust_Marry_vilage_no { get; set; } /// หมู่ที่
        public string Cust_Marry_alley { get; set; } /// ตรอก/ซอย
        public string Cust_Marry_road { get; set; } /// ถนน
        public string Cust_Marry_subdistrict { get; set; } /// ตำบล / แขวง
        public string Cust_Marry_district { get; set; } /// อำเภอ / เขต
        public string Cust_Marry_province { get; set; } /// จังหวัด
        public string Cust_Marry_country { get; set; } /// ประเทศ
        public string Cust_Marry_zipcode { get; set; } /// รหัสไปรษณีย์
        public string Cust_Marry_tel { get; set; } /// เบอร์โทรศัพท์ของคู่สมรส
        public string Cust_Marry_email { get; set; } /// อีเมล์ของคู่สมรส
        public string Cust_Marry_job { get; set; } /// อาชีพของคู่สมรส
        public string Cust_Marry_job_position { get; set; } /// อายุงานของคู่สมรส
        public int Cust_Marry_job_long { get; set; } /// ระยะเวลาทำงานของคู่สมรส
        public double Cust_Marry_job_salary { get; set; } /// เงินเดือนของคู่สมรส
        public string Cust_Marry_job_local_name { get; set; } /// ชื่อที่ทำงานของคู่สมรส
        public string Cust_Marry_job_address_no { get; set; } /// ที่อยู่ที่ทำงานของคู่สมรส เลขที่
        public string Cust_Marry_job_vilage { get; set; } /// ชื่อหมู่บ้านที่ทำงาน
        public string Cust_Marry_job_vilage_no { get; set; } /// หมู่ที่
        public string Cust_Marry_job_alley { get; set; } /// ตรอก/ซอย
        public string Cust_Marry_job_road { get; set; } /// ถนน
        public string Cust_Marry_job_subdistrict { get; set; } /// ตำบล / แขวง
        public string Cust_Marry_job_district { get; set; } /// อำเภอ / เขต
        public string Cust_Marry_job_province { get; set; } /// จังหวัด
        public string Cust_Marry_job_country { get; set; } /// ประเทศ
        public string Cust_Marry_job_zipcode { get; set; } /// รหัสไปรษณีย์
        public string Cust_Marry_job_tel { get; set; } /// เบอร์โทรศัพท์ที่ทำงานของคู่สมรส
        public string Cust_Job { get; set; } /// อาชีพลูกค้า
        public string Cust_Job_position { get; set; } /// ตำแหน่งงานลูกค้า
        public int Cust_Job_long { get; set; } /// อายุงานลูกค้า
        public double Cust_Job_salary { get; set; } /// เงินเดือนลูกค้า
        public string Cust_Job_local_name { get; set; } /// ชื่อสถานที่ทำงานลูกค้า
        public string Cust_Job_address_no { get; set; } /// ที่อยู่ที่ทำงานลูกค้า เลขที่
        public string Cust_Job_vilage { get; set; } /// ชื่อหมู่บ้าน
        public string Cust_Job_vilage_no { get; set; } /// หมู่ที่
        public string Cust_Job_alley { get; set; } /// ตรอก/ซอย
        public string Cust_Job_road { get; set; } /// ถนน
        public string Cust_Job_subdistrict { get; set; } /// ตำบล / แขวง
        public string Cust_Job_district { get; set; } /// อำเภอ / เขต
        public string Cust_Job_province { get; set; } /// จังหวัด
        public string Cust_Job_country { get; set; } /// ประเทศ
        public string Cust_Job_zipcode { get; set; } /// รหัสไปรษณีย์
        public string Cust_Job_tel { get; set; } /// เบอร์โทรศัพท์ที่ทำงาน
        public string Cust_Job_email { get; set; } /// อีเมล์ที่ทำงานลูกค้า
        public string Cust_Home_address_no { get; set; } /// ที่อยู่ตามทะเบียนบ้านลูกค้า เลขที่
        public string Cust_Home_vilage { get; set; } /// ชื่อหมู่บ้าน
        public string Cust_Home_vilage_no { get; set; } /// หมู่ที่
        public string Cust_Home_alley { get; set; } /// ตรอก/ซอย
        public string Cust_Home_road { get; set; } /// ถนน
        public string Cust_Home_subdistrict { get; set; } /// ตำบล / แขวง
        public string Cust_Home_district { get; set; } /// อำเภอ / เขต
        public string Cust_Home_province { get; set; } /// จังหวัด
        public string Cust_Home_country { get; set; } /// ประเทศ
        public string Cust_Home_zipcode { get; set; } /// รหัสไปรษณีย์
        public string Cust_Home_tel { get; set; } /// เบอร์โทรศัพท์
        public string Cust_Home_GPS_Latitude { get; set; } /// ตำแหน่งละติจูดจากดาวเทียม
        public string Cust_Home_GPS_Longitude { get; set; } /// ตำแหน่งลองติจูดจากดาวเทียม
        public Base_Home_Status ctm_home_stt { get; set; } /// สถานะภาพอยู่อาศัย
        public string Cust_Idcard_address_no { get; set; } /// ที่อยู่ตามบัตรประชาชนลูกค้า เลขที่
        public string Cust_Idcard_vilage { get; set; } /// ชื่อหมู่บ้าน
        public string Cust_Idcard_vilage_no { get; set; } /// หมู่ที่
        public string Cust_Idcard_alley { get; set; } /// ตรอก/ซอย
        public string Cust_Idcard_road { get; set; } /// ถนน
        public string Cust_Idcard_subdistrict { get; set; } /// ตำบล / แขวง
        public string Cust_Idcard_district { get; set; } /// อำเภอ / เขต
        public string Cust_Idcard_province { get; set; } /// จังหวัด
        public string Cust_Idcard_country { get; set; } /// ประเทศ
        public string Cust_Idcard_zipcode { get; set; } /// รหัสไปรษณีย์
        public string Cust_Idcard_tel { get; set; } /// เบอร์โทรศัพท์
        public Base_Home_Status ctm_idcard_stt { get; set; } /// สถานะภาพอยู่อาศัย
        public string Cust_Current_address_no { get; set; } /// ที่อยู่ปัจจุบันลูกค้า เลขที่
        public string Cust_Current_vilage { get; set; } /// ชื่อหมู่บ้าน
        public string Cust_Current_vilage_no { get; set; } /// หมู่ที่
        public string Cust_Current_alley { get; set; } /// ตรอก/ซอย
        public string Cust_Current_road { get; set; } /// ถนน
        public string Cust_Current_subdistrict { get; set; } /// ตำบล / แขวง
        public string Cust_Current_district { get; set; } /// อำเภอ / เขต
        public string Cust_Current_province { get; set; } /// จังหวัด
        public string Cust_Current_country { get; set; } /// ประเทศ
        public string Cust_Current_zipcode { get; set; } /// รหัสไปรษณีย์
        public string Cust_Current_tel { get; set; } /// เบอร์โทรศัพท์
        public Base_Home_Status ctm_current_stt { get; set; } /// สถานะภาพอยู่อาศัย
        public string Cust_save_date { get; set; } /// วันเวลาที่ทำการบันทึก
        public List<Customers_Home_Photo> list_ctm_photo { get; set; }
    }
}