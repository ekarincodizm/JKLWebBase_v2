using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Managers_Leasings;


namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Add_Car_Img : System.Web.UI.Page
    {
        Customers ctm = new Customers();
        Car_Leasings cls = new Car_Leasings();

        Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Leasings"] != null)
            {
                cls = (Car_Leasings)Session["Leasings"];
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Add");
            }

            if (!IsPostBack)
            {
                if (Session["Remove_Message"] != null)
                {
                    Alert_Danger_Panel.Visible = false;
                    Alert_Success_Panel.Visible = true;

                    alert_header_success_Lbl.Text = "ลบรูปภาพสำเร็จ";
                    alert_success_Lbl.Text = "ระบบได้ลบข้อมลรูปภาพเป็นที่เรียบร้อยแล้ว";
                }

                if (Session["Uploaded_Leasing"] != null)
                {
                    if (Session["Uploaded_Leasing"].Equals("1"))
                    {
                        Alert_Danger_Panel.Visible = false;
                        Alert_Success_Panel.Visible = true;

                        alert_header_success_Lbl.Text = "อัพโหลดภาพสำเร็จ";
                        alert_success_Lbl.Text = "ระบบได้เพิ่มข้อมลรูปภาพเป็นที่เรียบร้อยแล้ว";
                    }
                    else if (Session["Uploaded_Leasing"].Equals("0"))
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
            ctm = (Customers)Session["Customer_Leasing"];

            string server_path = Server.MapPath("/");

            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = ctm.Cust_id;

            string mainDirectoryPath = server_path + "\\Uploaded_Images\\" + mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            cls = (Car_Leasings)Session["Leasings"];

            /* Create Sub Folder for Save Images of Car */
            string subDirectory = "Car_Images_"+cls.Leasing_id;

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
                        cls_mng = new Car_Leasings_Manager();
                        string number_img = cls_mng.getLastNumberLeasingsCarPhotoId(cls.Leasing_id);
                        string digit = cls_mng.generateLeasingsCarDigitID();

                        string old_name = userPostedFile.FileName;
                        string new_name = number_img + "_" + cls.Leasing_id + "_" + digit + Path.GetExtension(userPostedFile.FileName);

                        string db_path = "../Uploaded_Images/" + mainDirectory + "/" + subDirectory + "/" + new_name;
                        string db_full_path = subDirectoryPath.Replace('\\', '/') + "/" + new_name;
                        string db_local_path = subDirectoryPath + "\\" + new_name;

                        userPostedFile.SaveAs(subDirectoryPath + "\\" + Path.GetFileName(old_name).Replace(old_name, new_name));

                        Car_Leasings_Photo cls_photo = new Car_Leasings_Photo();

                        cls_photo.Leasing_id = cls.Leasing_id;
                        cls_photo.Car_img_num = Convert.ToInt32(number_img);
                        cls_photo.Car_img_old_name = old_name;
                        cls_photo.Car_img_path = db_path;
                        cls_photo.Car_img_full_path = db_full_path;
                        cls_photo.Car_img_local_path = db_local_path;

                        cls_mng.addLeasingsCarPhoto(cls_photo);

                    }
                }
                catch (Exception ex)
                {
                    Session["Uploaded_Leasing"] = 0;
                    string error = "ไม่สามารถ Upload รูปภาพนี้ได้ ";
                    Log_Error._writeErrorFile(error, ex);
                }
            }

            Session["Uploaded_Leasing"] = 1;

            _GetHomePhoto();
        }

        private void _GetHomePhoto()
        {
            cls = (Car_Leasings)Session["Leasings"];

            List<Car_Leasings_Photo> list_cls_photo = cls_mng.getLeasingsCarPhoto(cls.Leasing_id);

            Session["list_cls_photo"] = list_cls_photo;
        }
    }
}