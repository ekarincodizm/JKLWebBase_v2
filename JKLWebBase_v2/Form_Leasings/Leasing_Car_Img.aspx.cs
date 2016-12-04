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
        Car_Leasings cls = new Car_Leasings();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Leasings"] != null)
            {
                cls = (Car_Leasings)Session["Leasings"];
            }
            else
            {
                //Response.Redirect("/Form_Leasings/Leasing_Add");
            }
        }

        protected void Upload_Btn_Click(object sender, EventArgs e)
        {
            string root_path = "C:\\inetpub\\wwwroot\\JKLWebBase\\Uploaded_Images";

            /* Create Main Folder for Detected Images of Contact Leasing  */
            string mainDirectory = "Leasing_id";

            string mainDirectoryPath = root_path + "\\"+ mainDirectory;

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            /* Create Sub Folder for Save Images of Car */
            string subDirectory = "Car_Images";

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
                        string old_name = userPostedFile.FileName;
                        string new_name = "MaxNumber_LeasingId_Car_Digit" + Path.GetExtension(userPostedFile.FileName);

                        string db_path = "\\" + mainDirectory + "\\" + subDirectory + "\\" + new_name;

                        userPostedFile.SaveAs(mainDirectoryPath + "\\" + Path.GetFileName(old_name).Replace(old_name, new_name));

                    }
                }
                catch (Exception Ex)
                {
                }
            }

            
        }
    }
}