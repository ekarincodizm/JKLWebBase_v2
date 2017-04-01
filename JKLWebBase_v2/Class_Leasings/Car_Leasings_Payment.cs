
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Class_Leasings
{
    public class Car_Leasings_Payment
    {
        public string Leasing_id { get; set; } /// รหัสลิสซิ่ง
        public int Period_no { get; set; } /// งวดที่
        public string Period_schedule { get; set; } /// วันที่กำหนดชำระ
        public double Period_current { get; set; } /// ค่างวดที่ต้องชำระ
        public double Period_cash { get; set; } /// ค่างวด
        public double Period_value { get; set; } /// มูลค่าต่องวด
        public double Period_principle { get; set; } /// ค่าเงินต้นต่องวด
        public double Period_interst { get; set; } /// ค่าดอกเบี้ยต่องวด
        public double Period_vat { get; set; } /// ค่าภาษีมูลค่าเพิ่มต่องวด
        public double Period_fine { get; set; } /// ค่าปรับต่องวด
        public double Total_Period_fine { get; set; } /// ยอดค่าปรับคงเหลือ
        public double Total_Period_left { get; set; } /// ค่างวดที่เหลือทั้งหมด
        public int Period_payment_status { get; set; } /// ค่าสถานะเมื่อจ่ายครบงวด
        public string Period_Save_Date { get; set; } /// วันที่บันทึกข้อมูล
        public int Count_payment { get; set; } /// ครั้งที่ชำระเงิน
        public double Period_fee { get; set; } /// ค่าธรรมเนียมต่องวด
        public double Period_track { get; set; } /// ค่าติดตามต่องวด
        public double Discount { get; set; } /// ส่วนลด
        public double Real_payment { get; set; } /// ยอดชำระจริง
        public double Real_payment_fine { get; set; } /// ยอดชำระค่าปรับ
        public double Total_payment_fine { get; set; } /// ยอดค่าปรับคงเหลือ
        public double Total_payment_left { get; set; } /// ค่างวดที่เหลือทั้งหมด
        public string Bill_no { get; set; } /// เลขที่ใบเสร็จ
        public string Real_payment_date { get; set; } /// วันที่ชำระจริง
        public double INN { get; set; } /// ค่างวดที่เหลือทั้งหมด
        public double TNC { get; set; } /// ค่างวดที่เหลือทั้งหมด
        public Account_Login acc_lgn { get; set; } /// พนักงานออกใบเสร็จ
        public Base_Companys bs_cpn { get; set; } /// สาขาที่ชำระเงิน
        public string Payment_save_date { get; set; } /// วันที่จ่ายเงินและบันทึกข้อมูล
    }
}