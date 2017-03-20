using System;
using System.Web.UI;

namespace JKLWebBase_v2
{
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["lct"] != null)
                {
                    string lct = Request.Params["lct"];
                }
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {

            Response.Redirect("/Form_Main/Main_JKL_Form");
        }
    }
}