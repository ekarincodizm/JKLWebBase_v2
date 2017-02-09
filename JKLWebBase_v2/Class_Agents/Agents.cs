using System.Collections.Generic;

using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Class_Agents
{
    public class Agents
    {
        public string Agent_id { get; set; } /// รหัสนายหน้า
        public string Agent_Fname { get; set; } /// ชื่อ
        public string Agent_Lname { get; set; } /// นามสกุล
        public string Agent_Idcard { get; set; } /// รหัสบัตรประชาชน
        public string Agent_Address_no { get; set; } /// เลขที่บ้าน
        public string Agent_Vilage { get; set; } /// หมู่บ้าน
        public string Agent_Vilage_no { get; set; } /// หมู่ที่
        public string Agent_Alley { get; set; } /// ซอย
        public string Agent_Road { get; set; } /// ถนน
        public string Agent_Subdistrict { get; set; } /// ตำบล
        public string Agent_District { get; set; } /// อำเภอ
        public TH_Provinces cag_pv { get; set; } /// จังหวัด
        public string Agent_Country { get; set; } /// ประเทศ
        public string Agent_Zipcode { get; set; } /// รหัสไปรษณีย์
        public int Agent_Status { get; set; } /// 0 = บุคคลธรรมดา, 1 = นิติบุคคล
        public string Agent_Status_name { get; set; } /// ประเภทนายหน้า
        public string Agent_save_date { get; set; } /// วันที่บันทึกข้อมูล

    }
}