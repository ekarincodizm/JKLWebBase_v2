using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Print_Menu_Leasing : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer_Leasing"] != null && Session["Leasings"] != null)
            {
                Print_Menu_panel.Visible = true;
            }
            else
            {
                Print_Menu_panel.Visible = false;
            }
        }
    }
}