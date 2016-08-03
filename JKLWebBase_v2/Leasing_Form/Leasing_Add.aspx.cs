using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Managers;
using JKLWebBase_v2.Class_Models;

namespace JKLWebBase_v2.Leasing_Form
{
    public partial class Leasing_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Car_Brand_Manager cbm = new Car_Brand_Manager();
            List<Car_Brands> car_brand = cbm.getCarBrands();
            for (int i = 0; i < car_brand.Count; i++)
            {
                Car_Brands cb = car_brand[i];
                Car_Brand_DDL.Items.Add(new ListItem(cb.car_brand_name_eng.ToString() + " ( " + cb.car_brand_name_th.ToString() + " ) ", cb.car_brand_id.ToString()));
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
    }
}