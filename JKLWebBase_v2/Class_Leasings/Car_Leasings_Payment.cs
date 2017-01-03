
namespace JKLWebBase_v2.Class_Leasings
{
    public class Car_Leasings_Payment
    {
        public string Leasing_id { get; set; }
        public int Period_no { get; set; } //งวดที่
        public int Count_payment { get; set; } //จำนวนครั้งที่ชำระ
        public string Period_schedule { get; set; } //วันที่กำหนดชำระ
        public double Period_current { get; set; } //ค่างวดที่ต้องชำระ
        public double Period_cash { get; set; } //ค่างวด
        public double Period_value { get; set; } //มูลค่าต่องวด
        public double Period_principle { get; set; } //ค่าเงินต้นต่องวด
        public double Period_interst { get; set; } //ค่าดอกเบี้ยต่องวด
        public double Period_vat { get; set; } //ค่าภาษีมูลค่าเพิ่มต่องวด
        public double Period_fine { get; set; } //ค่าปรับต่องวด
        public double Period_free { get; set; } //ค่าธรรมเนียมต่องวด
        public double Period_track { get; set; } //ค่าติดตามต่องวด
        public double Discount { get; set; } //ส่วนลด
        public double Real_payment { get; set; } //ยอดชำระจริง
        public double Real_payment_fine { get; set; } //ยอดชำระค่าปรับ
        public string Real_payment_date { get; set; } //วันที่ชำระจริง
        public double Total_payment_fine { get; set; } //ยอดค่าปรับคงเหลือ
        public double Total_payment_left { get; set; } //ค่างวดที่เหลือทั้งหมด
        public string Bill_no { get; set; } //เลขที่ใบเสร็จ
        public string Payment_save_date { get; set; } //วันที่จ่ายเงินและบันทึกข้อมูล
        public string Emp_id { get; set; } //พนักงานออกใบเสร็จ
        public int Branch_id { get; set; } //จ่ายที่สาขา
    }
}