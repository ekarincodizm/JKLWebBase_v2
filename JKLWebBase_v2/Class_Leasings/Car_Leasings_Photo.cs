namespace JKLWebBase_v2.Class_Leasings
{
    public class Car_Leasings_Photo
    {
        public string Leasing_id { get; set; } //ลำดับเลขสัญญา
        public int Car_img_num { get; set; } //ลำดับรูปรถ
        public string Car_img_old_name { get; set; } //ชื่อเดิมรูปภาพ
        public string Car_img_path { get; set; } //ที่เก็บไฟล์รูปภาพ
        public string Car_img_full_path { get; set; }
        public string Car_img_local_path { get; set; }
        public string Car_img_save_date { get; set; }

    }
}