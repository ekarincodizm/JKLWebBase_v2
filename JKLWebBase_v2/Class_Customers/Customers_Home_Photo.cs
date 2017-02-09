using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JKLWebBase_v2.Class_Customers
{
    public class Customers_Home_Photo
    {

        public string Cust_id { get; set; } /// รหัสลูกค้า
        public int Home_img_num { get; set; } /// รูปที่
        public string Home_img_old_name { get; set; } /// ชื่อเดิมรูปภาพ
        public string Home_img_path { get; set; } /// ที่เก็บไฟล์รูปภาพ
        public string Home_img_full_path { get; set; } /// ที่เก็บไฟล์รูปภาพ
        public string Home_img_local_path { get; set; } /// ที่เก็บไฟล์รูปภาพ
        public string Home_img_save_date { get; set; } /// วันที่บันทึก



    }
}