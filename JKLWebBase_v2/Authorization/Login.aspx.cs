using System;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2
{
    public partial class Login : System.Web.UI.Page
    {
        Computer_Clients com_c = new Computer_Clients();
        COM_Client_Manager com_c_mng = new COM_Client_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            com_c.Computer_track_Latitude = Latitude_TBx.Text;
            com_c.Computer_track_Longitude = Longitude_TBx.Text;

            com_c_mng.addComputerClient(com_c);

            Response.Redirect("/Form_Main/Main_JKL_Form");
        }
    }
}