using System;
using System.Web.UI;

namespace JKLWebBase_v2.Form_Customer
{
    public partial class Tab_Menu_Customer : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] != null || Request.Params["code"] != null)
            {
                link_Customer_Add.Enabled = true;
                link_Customer_Home_Photo.Enabled = true;
            }
            else
            {
                link_Customer_Add.Enabled = true;
                link_Customer_Home_Photo.Enabled = false;
            }
        }

        protected void link_Customer_Add_Click(object sender, EventArgs e)
        {
            Session["Class_Active_Customer"] = 1;

            if (Session["Customer"] == null && Request.Params["code"] == null)
            {
                Response.Redirect("/Form_Customer/Customer_Add");
            }
            else
            {
                Response.Redirect("/Form_Customer/Customer_Edit");
            }
        }

        protected void link_Customer_Home_Photo_Click(object sender, EventArgs e)
        {
            Session["Class_Active_Customer"] = 2;

            if (Session["Customer"] == null && Request.Params["code"] == null)
            {
                Response.Redirect("/Form_Customer/Customer_Add");
            }
            else
            {
                Response.Redirect("/Form_Customer/Customer_Home_Photo");
            }
        }
    }
}