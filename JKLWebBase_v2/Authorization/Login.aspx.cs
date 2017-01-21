using System;

namespace JKLWebBase_v2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Main/Main_JKL_Form");
        }
    }
}