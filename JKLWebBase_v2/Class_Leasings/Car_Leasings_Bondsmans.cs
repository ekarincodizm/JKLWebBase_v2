
using JKLWebBase_v2.Class_Customers;

namespace JKLWebBase_v2.Class_Leasings
{
    public class Car_Leasings_Bondsmans
    {
        public string Leasing_id { get; set; } //ลำดับเลขสัญญา
        public int Bondsman_no { get; set; } //ลำดับผู้คำประกัน
        public string Cust_id { get; set; } //รหัสผู้ค้ำประกัน
        public string Bondsman_save_date { get; set; }
        public Customers ctm { get; set; }

    }
}