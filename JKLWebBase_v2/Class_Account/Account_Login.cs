using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Class_Account
{
    public class Account_Login
    {
        public string Account_id { get; set; } /// รหัสผู้ใช้งาน
        public string Username_md { get; set; } /// ชื่อผู้ใช้งาน
        public string Password_md { get; set; } /// รหัสผ่าน
        public Account_Level acc_lv { get; set; } /// สิทธิ์การเข้าถึงข้อมูล
        public string Account_Idcard { get; set; } /// รหัสบัตรประชาชน
        public string Account_F_name { get; set; } /// ชื่อ - นามสกุล
        public string Account_N_Name { get; set; } /// ชื่อเล่น
        public string Account_Address_pri { get; set; } /// ที่อยู่
        public string Account_Tel { get; set; } /// เบอร์โทรศัพท์
        public string Account_Email { get; set; } /// อีเมล์
        public Base_Companys bs_cpn { get; set; } /// สำนักงาน
        public string resu { get; set; } /// forward back u
        public string ssap { get; set; } /// forward back p
        public int Account_status { get; set; } /// สถานะผู้ใช้งาน
        public string Account_Save_Date { get; set; } /// สร้างเมื่อวันที่

    }
}