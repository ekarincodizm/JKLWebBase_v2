using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;

using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Customer
{
    public partial class Customer_Home_Photo_Remove : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (!IsPostBack)
            {
                if (Session["Uploaded"] != null)
                {
                    Session.Remove("Uploaded");
                }

                    if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string Cust_id = code[1];
                    string number_img = code[2];

                    Customers_Manager ctm_mng = new Customers_Manager();
                    Customers_Home_Photo ctm_home_photo = ctm_mng.getCustomersHomePhotoSelected(Cust_id, number_img);

                    if (string.IsNullOrEmpty(ctm_home_photo.Home_img_path))
                    {
                        ctm_mng.removeCustomersHomePhoto(ctm_home_photo.Cust_id, ctm_home_photo.Home_img_num);
                    }
                    else
                    {
                        File.Delete(ctm_home_photo.Home_img_local_path);
                        ctm_mng.removeCustomersHomePhoto(ctm_home_photo.Cust_id, ctm_home_photo.Home_img_num);
                    }

                    Session["Remove_Message"] = 1;
                    Session["Class_Active_Customer"] = 2;
                    Response.Redirect("/Form_Customer/Customer_Home_Photo");

                }
            }
        }
    }
}