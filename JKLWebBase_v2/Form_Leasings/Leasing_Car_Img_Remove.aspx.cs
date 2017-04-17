using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;

using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Car_Img_Remove : Page
    {
        private Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
        private Car_Leasings_Photo cls_photo = new Car_Leasings_Photo();
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
                    string Leasing_id = code[1];
                    string number_img = code[2];

                    cls_photo = cls_mng.getLeasingsCarPhotoSelected(Leasing_id, number_img);

                    if (string.IsNullOrEmpty(cls_photo.Car_img_path))
                    {
                        cls_mng.removeLeasingsCarPhoto(cls_photo.Leasing_id, cls_photo.Car_img_num);
                    }
                    else
                    {
                        File.Delete(cls_photo.Car_img_local_path);
                        cls_mng.removeLeasingsCarPhoto(cls_photo.Leasing_id, cls_photo.Car_img_num);
                    }

                    Session["Remove_Message"] = 1;
                    Session["Class_Active_Customer"] = 9;
                    Response.Redirect("/Form_Leasings/Leasing_Car_Img");

                }
            }
        }
    }
}