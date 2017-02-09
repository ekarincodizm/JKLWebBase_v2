using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;

namespace JKLWebBase_v2.Class_Leasings
{
    public class Car_Leasings_Guarator
    {
        public Car_Leasings cls { get; set; } /// สัญญา
        public int Guarantor_no { get; set; } /// ลำดับผู้ค้ำประกัน
        public Customers ctm { get; set; } /// ลูกค้า
    }
}