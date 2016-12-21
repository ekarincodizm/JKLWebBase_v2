namespace JKLWebBase_v2.Class_Customers
{
    public class Customers_Address
    {
        public string Cust_id { get; set; } //รหัสลูกค้า
        public int Cust_Address_type_id { get; set; } //ประเภทที่อยู่
        public string Cust_Address_no { get; set; } //ที่อยู่ เลขที่
        public string Cust_Vilage { get; set; } //หมู่บ้าน
        public string Cust_Vilage_no { get; set; } //หมู่ที่
        public string Cust_Alley { get; set; } //ซอย
        public string Cust_Road { get; set; } //ถนน
        public string Cust_Subdistrict { get; set; } //ตำบล / แขวง
        public string Cust_District { get; set; } //อำเภอ / เขต
        public int Cust_Province { get; set; } //จังหวัด
        public string Cust_Country { get; set; } //ประเทศ
        public string Cust_Zipcode { get; set; } //รหัสไปรษณีย์
        public string Cust_Tel { get; set; } //เบอร์ติดต่อ
        public int Cust_Home_status_id { get; set; } //รหัสสถานะภาพอยู่อาศัย
        public string Cust_Gps_Latitude { get; set; } //ตำแหน่งละติจูดจากดาวเทียม
        public string Cust_Gps_Longitude { get; set; } //ตำแหน่งลองติจูดจากดาวเทียม
        public string Cust_Address_Save_date { get; set; }
        public string Cust_Address_type_name { get; set; }
        public string Cust_Province_name { get; set; }
        public string Cust_Home_status_name { get; set; }
        public string Address_inline { get; set; }

    }
}