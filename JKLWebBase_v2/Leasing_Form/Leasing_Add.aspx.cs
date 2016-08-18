using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Leasing_Form
{
    public partial class Leasing_Add : System.Web.UI.Page
    {
        private Base_Car_Types_Manager ctm = new Base_Car_Types_Manager();
        private Base_Car_Brand_Manager cbm = new Base_Car_Brand_Manager();
        private Base_Car_Models_Manager cmm = new Base_Car_Models_Manager();
        private TH_Provinces_Manager thpvm = new TH_Provinces_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCarType();
                _loadCarBrand();
                _loadCarYear();
                _loadCarUsed();
                _loadThaiProvinces();
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Leasing_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add");
        }

        protected void link_Add_Bondsman_1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_5_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Leasing_Form/Leasing_Add_Bondsman");
        }

        protected void Car_Brand_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Car_Brand_DDL.SelectedIndex != 0)
            {
                _loadCarModels(int.Parse(Car_Brand_DDL.SelectedValue));
            }

            Car_Model_DDL.Focus();
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลประเภทรภ
        private void _loadCarType()
        {
            List<Base_Car_Types> lct = ctm.getCarBrands();
            Car_Type_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < lct.Count; i++)
            {
                Base_Car_Types ct = lct[i];
                Car_Type_DDL.Items.Add(new ListItem(ct.car_type_name.ToString(), ct.car_type_id.ToString()));
            }
        }

        // ดึงข้อมูลยี่ห้อรถ
        private void _loadCarBrand()
        {
            List<Base_Car_Brands> lcb = cbm.getCarBrands();
            Car_Brand_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < lcb.Count; i++)
            {
                Base_Car_Brands cb = lcb[i];
                Car_Brand_DDL.Items.Add(new ListItem(cb.car_brand_name_eng.ToString() + " ( " + cb.car_brand_name_th.ToString() + " ) ", cb.car_brand_id.ToString()));
            }
        }

        // ดึงข้อมูลรุ่นรถ
        private void _loadCarModels(int index)
        {
            List<Base_Car_Models> lcm = cmm.getCarBrands(index);
            if (lcm.Count > 0)
            {
                Car_Model_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
                for (int i = 0; i < lcm.Count; i++)
                {
                    Base_Car_Models cm = lcm[i];
                    Car_Model_DDL.Items.Add(new ListItem(cm.car_model_name.ToString(), cm.car_model_id.ToString()));
                }
            }
            else
            {
                Car_Model_DDL.Items.Clear();
            }
        }

        // ปีรถ
        private void _loadCarYear()
        {
            int year_list = DateTime.Now.Year;
            while (year_list >= 1957)
            {
                int year_th = year_list + 543;
                Car_Year_DDL.Items.Add(new ListItem(year_th.ToString(), year_list.ToString()));
                year_list--;
            }
        }

        // สภาพรถ
        private void _loadCarUsed()
        {
            Car_Year_DDL.Items.Add(new ListItem("รถใหม่", "0"));
            Car_Year_DDL.Items.Add(new ListItem("ใช้แล้ว", "1"));
        }

        // รหัสสัญญา
        private void _loadLeasingCode()
        {
            
        }

        // สาขา
        private void _loadBrands()
        {

        }

        // เขตบริการ
        private void _loadZoneService()
        {

        }

        // ระยะเวลาชำระเงิน
        private void _loadTotalPaymentTime()
        {

        }

        // ศาล
        private void _loadCourt()
        {

        }

        // กำหนดชำระทุกวันที่
        private void _loadPaymentSchedule()
        {

        }

        // เชื้อชาติ
        private void _loadOrigin()
        {

        }

        // สัญชาติ
        private void _loadNationality()
        {

        }

        // สถานะภาพการสมรส
        private void _loadPersonStatus()
        {

        }

        // ชื่อเต้นท์รถ
        private void _loadTentsCar()
        {

        }

        // สถานะภาพของผู้อาศัย
        private void _loadHomeStatus()
        {

        }

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> lth_pv = thpvm.getProvinces();
            Car_Old_Owner_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Current_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Cust_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Dealer_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Home_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Idcard_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Spouse_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Spouse_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < lth_pv.Count; i++)
            {
                TH_Provinces cb = lth_pv[i];
                Car_Old_Owner_Province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
                Current_Cust_Province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
                Cust_job_province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
                Dealer_province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
                Home_Cust_Province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
                Idcard_Cust_Province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
                Spouse_province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
                Spouse_job_province_DDL.Items.Add(new ListItem(cb.Province_name.ToString(), cb.Province_id.ToString()));
            }
        }
    }
}
 