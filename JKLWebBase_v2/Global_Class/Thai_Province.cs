using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using System.Collections.Generic;

namespace JKLWebBase_v2.Global_Class
{
    public class Thai_Province
    {
        // ดึงข้อมูลจังหวัดในประเทศไทย
        public static string _getThaiProvinces(string province_name)
        {
            string province_id = "0";

            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();

            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];

                if(data.Province_name == province_name)
                {
                    province_id = data.Province_id.ToString();
                }
            }

            return province_id;
        }
    }
}