using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Class_Account
{
    public class Computer_Clients
    {
        public string Computer_id { get; set; } /// รหัสเครื่อง
        public string Computer_name { get; set; } /// ชื่อเครื่อง
        public string Computer_track_Latitude { get; set; } /// GPS Tracking
        public string Computer_track_Longitude { get; set; } /// GPS Tracking
        public string Computer_map_location { get; set; } /// GPS MAP Tracking
        public Base_Companys bs_cpn { get; set; } /// สำนักงาน
        public string Computer_Save_Date { get; set; } /// วันที่บันทึก

    }
}