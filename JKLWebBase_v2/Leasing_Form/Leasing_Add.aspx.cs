using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Leasing_Form
{
    public partial class Leasing_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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