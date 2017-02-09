using System;
using System.Web.UI;

namespace JKLWebBase_v2.Form_Main
{
    public partial class Print_Menu_Leasing : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer_Leasing"] != null && Session["Leasings"] != null)
            {
                Print_Menu_panel.Visible = true;

                if(Session["Agents_Leasing"] != null)
                {
                    Print_Withholding_Tax.Visible = true;
                }
                else
                {
                    Print_Withholding_Tax.Visible = false;
                }
            }
            else
            {
                Print_Menu_panel.Visible = false;
            }
        }
    }
}