namespace JKLWebBase_v2.Class_Agents
{
    public class Agents_Commission
    {
        public string Leasing_id { get; set; } /// รหัสลิสซิ่ง
        public Agents cag { get; set; } /// รหัสลิสซิ่ง
        public double Agent_commission { get; set; } /// ค่านายหน้า
        public double Agent_percen { get; set; } /// % หัก ณ ที่จ่าย
        public double Agent_cash { get; set; } /// หัก ณ ที่จ่าย
        public double Agent_net_com { get; set; } /// ค่านายหน้าสุทธิ
        public string Agent_num_code { get; set; } /// เลขที่ใบหัก ณ ที่จ่าย
        public string Agent_book_code { get; set; } /// เล่มที่
        public string Agent_date_print { get; set; } /// วันที่ออก
        public string Agent_value_save_date { get; set; } /// วันที่บันทึกข้อมูล
    }
}