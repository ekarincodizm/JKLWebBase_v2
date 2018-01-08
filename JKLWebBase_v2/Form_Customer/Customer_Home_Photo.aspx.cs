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
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Form_Customer
{
    public partial class Customer_Home_Photo : Page
    {
        private Customers ctm = new Customers();
        private Customers_Manager ctm_mng = new Customers_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            if (!IsPostBack)
            {
                if(Session["Remove_Message"] != null)
                {
                    Alert_Danger_Panel.Visible = false;
                    Alert_Success_Panel.Visible = true;

                    alert_header_success_Lbl.Text = "ลบรูปภาพสำเร็จ";
                    alert_success_Lbl.Text = "ระบบได้ลบข้อมลรูปภาพเป็นที่เรียบร้อยแล้ว";
                }

                if(Session["Uploaded"] != null)
                {
                    if(Session["Uploaded"].Equals("1"))
                    {
                        Alert_Danger_Panel.Visible = false;
                        Alert_Success_Panel.Visible = true;

                        alert_header_success_Lbl.Text = "อัพโหลดภาพสำเร็จ";
                        alert_success_Lbl.Text = "ระบบได้เพิ่มข้อมลรูปภาพเป็นที่เรียบร้อยแล้ว";
                    }
                    else if(Session["Uploaded"].Equals("0"))
                    {
                        Alert_Danger_Panel.Visible = true;
                        Alert_Success_Panel.Visible = false;

                        alert_header_danger_Lbl.Text = "อัพโหลดภาพไม่สำเร็จ";
                        alert_danger_Lbl.Text = "ระบบไม่สามารถอัพโหลดรูปภาพดังกล่าวได้กรุณาตรวจสอบภาพ หรือ ติดต่อผู้เกี่ยวข้อง";
                    }
                }

                _GetHomePhoto();

                if (Session["Remove_Message"] != null)
                {
                    Session.Remove("Remove_Message");
                }
            }
        }

        protected void Upload_Btn_Click(object sender, EventArgs e)
        {
            ctm = (Customers)Session["Customer"];

            string server_path = Server.MapPath("/");

            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = ctm.Cust_id;

            string mainDirectoryPath = server_path + "\\Uploaded_Images\\" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            /* Create Sub Folder for Save Images of Car */
            string subDirectory = "Home_Images";

            string subDirectoryPath = mainDirectoryPath + "\\" + subDirectory;

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }


            /* Get File From TextFile  */
            HttpFileCollection uploadedFiles = Request.Files;

            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFile userPostedFile = uploadedFiles[i];

                try
                {
                    if (userPostedFile.ContentLength > 0)
                    {
                        ctm_mng = new Customers_Manager();
                        string number_img = ctm_mng.getLastNumberPhotoId(ctm.Cust_id);
                        string digit = ctm_mng.generateDigitID();

                        string old_name = userPostedFile.FileName;
                        string new_name = number_img + "_"+ ctm.Cust_id + "_"+ digit + Path.GetExtension(userPostedFile.FileName);

                        string db_path = "../Uploaded_Images/" + mainDirectory + "/" + subDirectory + "/" + new_name;
                        string db_full_path = subDirectoryPath.Replace('\\','/') + "/" + new_name;
                        string db_local_path = subDirectoryPath + "\\" + new_name;

                        userPostedFile.SaveAs(subDirectoryPath + "\\" + Path.GetFileName(old_name).Replace(old_name, new_name));

                        Customers_Home_Photo ctm_photo = new Customers_Home_Photo();

                        ctm_photo.Cust_id = ctm.Cust_id;
                        ctm_photo.Home_img_num = Convert.ToInt32(number_img);
                        ctm_photo.Home_img_old_name = old_name;
                        ctm_photo.Home_img_path = db_path;
                        ctm_photo.Home_img_full_path = db_full_path;
                        ctm_photo.Home_img_local_path = db_local_path;

                        ctm_mng.addCustomersHomePhoto(ctm_photo);

                        /// Acticity Logs System
                        ///  

                        package_login = (Base_Companys)Session["Package"];
                        acc_lgn = (Account_Login)Session["Login"];

                        string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " เพิ่มรูปบ้าน", acc_lgn.resu, package_login.Company_N_name);

                        new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                        /// Acticity Logs System

                    }
                }
                catch (Exception ex)
                {
                    Session["Uploaded"] = 0;
                    string error = "ไม่สามารถ Upload รูปภาพนี้ได้ ";
                    Log_Error._writeErrorFile(error, ex);
                }
            }

            Session["Uploaded"] = 1;

            _GetHomePhoto();
        }

        private void _GetHomePhoto()
        {
            ctm = (Customers)Session["Customer"];

            List<Customers_Home_Photo> list_ctm_photo = ctm_mng.getCustomersHomePhoto(ctm.Cust_id);

            Session["list_ctm_photo"] = list_ctm_photo;
        }
    }
}