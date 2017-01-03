﻿namespace JKLWebBase_v2.Class_Dealers
{
    public class Dealers_Values
    {
        public string Dealer_id { get; set; } //รหัสนายหน้า
        public double Dealer_commission { get; set; } //ค่านายหน้า
        public double Dealer_percen { get; set; } //% หัก ณ ที่จ่าย
        public double Dealer_cash { get; set; } //หัก ณ ที่จ่ายเป็นเงิน
        public double Dealer_net_com { get; set; } //ค่านายหน้าสุทธิ
        public string Dealer_com_code { get; set; } //เลขที่ใบหัก ณ ที่จ่าย
        public string Dealer_bookcode { get; set; } //เล่มที่
        public string Dealer_date_print { get; set; } //วันที่ออก
        public string Dealer_value_save_date { get; set; } //วันที่บันทึกข้อมูล
        public string Leasing_id { get; set; } //รหัสสัญญา
        public Dealers dlr { get; set; }
    }
}