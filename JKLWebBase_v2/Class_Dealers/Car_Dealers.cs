namespace JKLWebBase_v2.Class_Dealers
{
    public class Car_Dealers
    {
        public string Dealer_id { get; set; } //รหัสนายหน้า
        public string Dealer_fname { get; set; } //ชื่อ
        public string Dealer_lname { get; set; } //นามสกุล
        public string Dealer_idcard { get; set; } //รหัสบัตรประชาชน
        public string Dealer_address_no { get; set; } //เลขที่บ้าน
        public string Dealer_vilage { get; set; } //หมู่บ้าน
        public string Dealer_vilage_no { get; set; } //หมู่ที่
        public string Dealer_alley { get; set; } //ซอย
        public string Dealer_road { get; set; } //ถนน
        public string Dealer_subdistrict { get; set; } //ตำบล
        public string Dealer_district { get; set; } //อำเภอ
        public int Dealer_province { get; set; } //จังหวัด
        public string Dealer_country { get; set; } //ประเทศ
        public string Dealer_zipcode { get; set; } //รหัสไปรษณีย์
        public int Dealer_status { get; set; } //รหัสไปรษณีย์
        public string Dealer_save_date { get; set; }

    }
}