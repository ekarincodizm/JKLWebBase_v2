using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using System;
using System.IO;

namespace JKLWebBase_v2.Global_Class
{
    public class Messages_Logs
    {
        public static string _messageLogsAccess(string name, string username, string compamy, int Access_status)
        {
            string message = "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Date Time : {0}", DateTimeUtility._dateTimeToText() + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Username : {0}", username + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Company : {0}", compamy + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Name : {0}", name + " </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Login Status : {0}", Access_status == 1 ? " เข้าสู่ระบบสำเร็จ  </p>" : " เข้าสู่ระบบไม่สำเร็จ  </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;

            return message;
        }

        public static string _messageLogsLogout(string name, string username, string compamy, int Access_status)
        {
            string message = "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Date Time : {0}", DateTimeUtility._dateTimeToText() + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Username : {0}", username + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Company : {0}", compamy + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Name : {0}", name + " </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Logout Status : {0}", Access_status == 1 ? " ออกจากระบบสำเร็จ  </p>" : " ออกจากระบบสำเร็จไม่สำเร็จ  </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;

            return message;
        }

        public static string _messageLogsNormal(string name, string logDetails, string username, string compamy)
        {
            string message = "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Date Time : {0}", DateTimeUtility._dateTimeToText() + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Username : {0}", username + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Company : {0}", compamy + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Name : {0}", name + " </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Messages : {0}", logDetails + " </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;

            return message;
        }

        public static string _messageLogsWarning(string name, string logDetails, string username, string compamy)
        {
            string message = "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Date Time : {0}", DateTimeUtility._dateTimeToText() + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Username : {0}", username + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Company : {0}", compamy + " </p>");
            message += Environment.NewLine;
            message += string.Format("<p> Name : {0}", name + " </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;
            message += string.Format("<p> Messages : {0}", logDetails + " </p>");
            message += Environment.NewLine;
            message += "<p> ------------------------------------------------------------------------------------ </p>";
            message += Environment.NewLine;

            return message;
        }

        public static void _writeSQLCodeToMYSQL(string filename, string sqlcommand)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string message = sqlcommand;
            message += Environment.NewLine;

            string path = mainDirectoryPath + filename + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeInsertCustomerToMYSQL(Customers ctm, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Customer/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL i_customers(";
            message += "'" + ctm.Cust_id + "'";
            message += ",'" + ctm.Cust_Idcard + "'";
            message += ",'" + ctm.Cust_Fname + "'";
            message += ",'" + ctm.Cust_LName + "'";
            message += string.IsNullOrEmpty(ctm.Cust_B_date) ? ",null" : ",'" + ctm.Cust_B_date + "'";
            message += "," + ctm.Cust_Age + "";
            message += ",'" + ctm.Cust_Idcard_without + "'";
            message += string.IsNullOrEmpty(ctm.Cust_Idcard_start) ? ",null" : ",'" + ctm.Cust_Idcard_start + "'";
            message += string.IsNullOrEmpty(ctm.Cust_Idcard_expire) ? ",null" : ",'" + ctm.Cust_Idcard_expire + "'";
            message += "," + ctm.ctm_ntnlt.Nationality_id + "";
            message += "," + ctm.ctm_org.Origin_id + "";
            message += ",'" + ctm.Cust_Tel + "'";
            message += ",'" + ctm.Cust_Email + "'";
            message += "," + ctm.ctm_pstt.person_status_id + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_idcard + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_Fname + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_Lname + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.ctm_marry_ntnlt.Nationality_id + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.ctm_marry_org.Origin_id + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_Address_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_vilage + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_vilage_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_alley + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_road + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_subdistrict + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_district + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_province + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_country + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_zipcode + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_tel + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_email + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_position + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.Cust_Marry_job_long + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.Cust_Marry_job_salary + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_local_name + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_address_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_vilage + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_vilage_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_alley + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_road + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_subdistrict + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_district + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_province + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_country + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_zipcode + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_tel + "'";
            message += ",'" + ctm.Cust_Job.Trim() + "'";
            message += ",'" + ctm.Cust_Job_position.Trim() + "'";
            message += "," + ctm.Cust_Job_long + "";
            message += "," + ctm.Cust_Job_salary + "";
            message += ",'" + ctm.Cust_Job_local_name.Trim() + "'";
            message += ",'" + ctm.Cust_Job_address_no + "'";
            message += ",'" + ctm.Cust_Job_vilage + "'";
            message += ",'" + ctm.Cust_Job_vilage_no + "'";
            message += ",'" + ctm.Cust_Job_alley + "'";
            message += ",'" + ctm.Cust_Job_road + "'";
            message += ",'" + ctm.Cust_Job_subdistrict + "'";
            message += ",'" + ctm.Cust_Job_district + "'";
            message += ",'" + ctm.Cust_Job_province + "'";
            message += ",'" + ctm.Cust_Job_country + "'";
            message += ",'" + ctm.Cust_Job_zipcode + "'";
            message += ",'" + ctm.Cust_Job_tel + "'";
            message += ",'" + ctm.Cust_Job_email + "'";
            message += ",'" + ctm.Cust_Home_address_no + "'";
            message += ",'" + ctm.Cust_Home_vilage + "'";
            message += ",'" + ctm.Cust_Home_vilage_no + "'";
            message += ",'" + ctm.Cust_Home_alley + "'";
            message += ",'" + ctm.Cust_Home_road + "'";
            message += ",'" + ctm.Cust_Home_subdistrict + "'";
            message += ",'" + ctm.Cust_Home_district + "'";
            message += ",'" + ctm.Cust_Home_province + "'";
            message += ",'" + ctm.Cust_Home_country + "'";
            message += ",'" + ctm.Cust_Home_zipcode + "'";
            message += ",'" + ctm.Cust_Home_tel + "'";
            message += ",'" + ctm.Cust_Home_GPS_Latitude + "'";
            message += ",'" + ctm.Cust_Home_GPS_Longitude + "'";
            message += "," + ctm.ctm_home_stt.Home_status_id + "";
            message += ",'" + ctm.Cust_Idcard_address_no + "'";
            message += ",'" + ctm.Cust_Idcard_vilage + "'";
            message += ",'" + ctm.Cust_Idcard_vilage_no + "'";
            message += ",'" + ctm.Cust_Idcard_alley + "'";
            message += ",'" + ctm.Cust_Idcard_road + "'";
            message += ",'" + ctm.Cust_Idcard_subdistrict + "'";
            message += ",'" + ctm.Cust_Idcard_district + "'";
            message += ",'" + ctm.Cust_Idcard_province + "'";
            message += ",'" + ctm.Cust_Idcard_country + "'";
            message += ",'" + ctm.Cust_Idcard_zipcode + "'";
            message += ",'" + ctm.Cust_Idcard_tel + "'";
            message += "," + ctm.ctm_idcard_stt.Home_status_id + "";
            message += ",'" + ctm.Cust_Current_address_no + "'";
            message += ",'" + ctm.Cust_Current_vilage + "'";
            message += ",'" + ctm.Cust_Current_vilage_no + "'";
            message += ",'" + ctm.Cust_Current_alley + "'";
            message += ",'" + ctm.Cust_Current_road + "'";
            message += ",'" + ctm.Cust_Current_subdistrict + "'";
            message += ",'" + ctm.Cust_Current_district + "'";
            message += ",'" + ctm.Cust_Current_province + "'";
            message += ",'" + ctm.Cust_Current_country + "'";
            message += ",'" + ctm.Cust_Current_zipcode + "'";
            message += ",'" + ctm.Cust_Current_tel + "'";
            message += "," + ctm.ctm_current_stt.Home_status_id + "";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Customer_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeUpdateCustomerToMYSQL(Customers ctm, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "UPDATE_Customer/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL u_customers(";
            message += "'" + ctm.Cust_id + "'";
            message += ",'" + ctm.Cust_Idcard + "'";
            message += ",'" + ctm.Cust_Fname + "'";
            message += ",'" + ctm.Cust_LName + "'";
            message += string.IsNullOrEmpty(ctm.Cust_B_date) ? ",null" : ",'" + ctm.Cust_B_date + "'";
            message += "," + ctm.Cust_Age + "";
            message += ",'" + ctm.Cust_Idcard_without + "'";
            message += string.IsNullOrEmpty(ctm.Cust_Idcard_start) ? ",null" : ",'" + ctm.Cust_Idcard_start + "'";
            message += string.IsNullOrEmpty(ctm.Cust_Idcard_expire) ? ",null" : ",'" + ctm.Cust_Idcard_expire + "'";
            message += "," + ctm.ctm_ntnlt.Nationality_id + "";
            message += "," + ctm.ctm_org.Origin_id + "";
            message += ",'" + ctm.Cust_Tel + "'";
            message += ",'" + ctm.Cust_Email + "'";
            message += "," + ctm.ctm_pstt.person_status_id + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_idcard + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_Fname + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_Lname + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.ctm_marry_ntnlt.Nationality_id + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.ctm_marry_org.Origin_id + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_Address_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_vilage + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_vilage_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_alley + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_road + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_subdistrict + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_district + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_province + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_country + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_zipcode + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_tel + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_email + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_position + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.Cust_Marry_job_long + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + ctm.Cust_Marry_job_salary + "";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_local_name + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_address_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_vilage + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_vilage_no + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_alley + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_road + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_subdistrict + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_district + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_province + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_country + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_zipcode + "'";
            message += ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + ctm.Cust_Marry_job_tel + "'";
            message += ",'" + ctm.Cust_Job.Trim() + "'";
            message += ",'" + ctm.Cust_Job_position.Trim() + "'";
            message += "," + ctm.Cust_Job_long + "";
            message += "," + ctm.Cust_Job_salary + "";
            message += ",'" + ctm.Cust_Job_local_name.Trim() + "'";
            message += ",'" + ctm.Cust_Job_address_no + "'";
            message += ",'" + ctm.Cust_Job_vilage + "'";
            message += ",'" + ctm.Cust_Job_vilage_no + "'";
            message += ",'" + ctm.Cust_Job_alley + "'";
            message += ",'" + ctm.Cust_Job_road + "'";
            message += ",'" + ctm.Cust_Job_subdistrict + "'";
            message += ",'" + ctm.Cust_Job_district + "'";
            message += ",'" + ctm.Cust_Job_province + "'";
            message += ",'" + ctm.Cust_Job_country + "'";
            message += ",'" + ctm.Cust_Job_zipcode + "'";
            message += ",'" + ctm.Cust_Job_tel + "'";
            message += ",'" + ctm.Cust_Job_email + "'";
            message += ",'" + ctm.Cust_Home_address_no + "'";
            message += ",'" + ctm.Cust_Home_vilage + "'";
            message += ",'" + ctm.Cust_Home_vilage_no + "'";
            message += ",'" + ctm.Cust_Home_alley + "'";
            message += ",'" + ctm.Cust_Home_road + "'";
            message += ",'" + ctm.Cust_Home_subdistrict + "'";
            message += ",'" + ctm.Cust_Home_district + "'";
            message += ",'" + ctm.Cust_Home_province + "'";
            message += ",'" + ctm.Cust_Home_country + "'";
            message += ",'" + ctm.Cust_Home_zipcode + "'";
            message += ",'" + ctm.Cust_Home_tel + "'";
            message += ",'" + ctm.Cust_Home_GPS_Latitude + "'";
            message += ",'" + ctm.Cust_Home_GPS_Longitude + "'";
            message += "," + ctm.ctm_home_stt.Home_status_id + "";
            message += ",'" + ctm.Cust_Idcard_address_no + "'";
            message += ",'" + ctm.Cust_Idcard_vilage + "'";
            message += ",'" + ctm.Cust_Idcard_vilage_no + "'";
            message += ",'" + ctm.Cust_Idcard_alley + "'";
            message += ",'" + ctm.Cust_Idcard_road + "'";
            message += ",'" + ctm.Cust_Idcard_subdistrict + "'";
            message += ",'" + ctm.Cust_Idcard_district + "'";
            message += ",'" + ctm.Cust_Idcard_province + "'";
            message += ",'" + ctm.Cust_Idcard_country + "'";
            message += ",'" + ctm.Cust_Idcard_zipcode + "'";
            message += ",'" + ctm.Cust_Idcard_tel + "'";
            message += "," + ctm.ctm_idcard_stt.Home_status_id + "";
            message += ",'" + ctm.Cust_Current_address_no + "'";
            message += ",'" + ctm.Cust_Current_vilage + "'";
            message += ",'" + ctm.Cust_Current_vilage_no + "'";
            message += ",'" + ctm.Cust_Current_alley + "'";
            message += ",'" + ctm.Cust_Current_road + "'";
            message += ",'" + ctm.Cust_Current_subdistrict + "'";
            message += ",'" + ctm.Cust_Current_district + "'";
            message += ",'" + ctm.Cust_Current_province + "'";
            message += ",'" + ctm.Cust_Current_country + "'";
            message += ",'" + ctm.Cust_Current_zipcode + "'";
            message += ",'" + ctm.Cust_Current_tel + "'";
            message += "," + ctm.ctm_current_stt.Home_status_id + "";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_UPDATE_Customer_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeInsertLeasingsToMYSQL(Car_Leasings cls, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Leasings/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL i_car_leasings(";
            message += "'" + cls.Leasing_id + "'";
            message += ",'" + cls.Deps_no + "'";
            message += ",'" + cls.Leasing_no + "'";
            message += "," + cls.bs_ls_code.Leasing_code_id + "";
            message += ",'" + cls.Leasing_date + "'";
            message += "," + cls.bs_cpn.Company_id + "";
            message += "," + cls.bs_zn.Zone_id + "";
            message += "," + cls.bs_ct.Court_id + "";
            message += ",'" + cls.PeReT + "'";
            message += "," + cls.TotalPaymentTime + "";
            message += "," + cls.Total_require + "";
            message += "," + cls.Vat_rate + "";
            message += "," + cls.Interest_rate + "";
            message += "," + cls.Total_period + "";
            message += "," + cls.Total_sum + "";
            message += "," + cls.Total_Interest + "";
            message += "," + cls.Total_Tax + "";
            message += "," + cls.Total_leasing + "";
            message += "," + cls.Total_Net_leasing + "";
            message += "," + cls.Period_cal + "";
            message += "," + cls.Period_interst + "";
            message += "," + cls.Period_tax + "";
            message += "," + cls.Period_pure + "";
            message += "," + cls.Period_payment + "";
            message += "," + cls.Period_require + "";
            message += ",'" + cls.Total_period_length + "'";
            message += ",null";
            message += "," + cls.Total_period_left + "";
            message += "," + cls.Total_payment_left + "";
            message += "," + cls.Payment_schedule + "";
            message += string.IsNullOrEmpty(cls.First_payment_date)? ",null" : ",'" + cls.First_payment_date + "'";
            message += string.IsNullOrEmpty(cls.Car_register_date) ? ",null" : ",'" + cls.Car_register_date + "'";
            message += ",'" + cls.Car_license_plate + "'";
            message += ",'" + cls.Car_license_plate_province + "'";
            message += ",'" + cls.Car_type + "'";
            message += ",'" + cls.Car_feature + "'";
            message += "," + cls.bs_cbrn.car_brand_id + "";
            message += ",'" + cls.Car_model + "'";
            message += ",'" + cls.Car_year + "'";
            message += ",'" + cls.Car_color + "'";
            message += ",'" + cls.Car_engine_no + "'";
            message += ",'" + cls.Car_engine_no_at + "'";
            message += ",'" + cls.Car_engine_brand + "'";
            message += ",'" + cls.Car_chassis_no + "'";
            message += ",'" + cls.Car_chassis_no_at + "'";
            message += ",'" + cls.Car_fual_type + "'";
            message += ",'" + cls.Car_gas_No + "'";
            message += "," + cls.Car_used_id + "";
            message += "," + cls.Car_distance + "";
            message += string.IsNullOrEmpty(cls.Car_next_register_date) ? ",null" : ",'" + cls.Car_next_register_date + "'";
            message += "," + cls.Car_tax_value + "";
            message += ",'" + cls.Car_credits + "'";
            message += ",'" + cls.Car_agent + "'";
            message += ",'" + cls.Car_old_owner + "'";
            message += ",'" + cls.Car_old_owner_idcard + "'";
            message += string.IsNullOrEmpty(cls.Car_old_owner_b_date) ? ",null" : ",'" + cls.Car_old_owner_b_date + "'";
            message += ",'" + cls.Car_old_owner_address_no + "'";
            message += ",'" + cls.Car_old_owner_vilage + "'";
            message += ",'" + cls.Car_old_owner_vilage_no + "'";
            message += ",'" + cls.Car_old_owner_alley + "'";
            message += ",'" + cls.Car_old_owner_road + "'";
            message += ",'" + cls.Car_old_owner_subdistrict + "'";
            message += ",'" + cls.Car_old_owner_district + "'";
            message += ",'" + cls.Car_old_owner_province + "'";
            message += ",'" + cls.Car_old_owner_contry + "'";
            message += ",'" + cls.Car_old_owner_zipcode + "'";
            message += "," + cls.tent_car.Tent_car_id + "";
            message += ",'" + cls.Cheque_receiver + "'";
            message += ",'" + cls.Cheque_bank + "'";
            message += ",'" + cls.Cheque_bank_branch + "'";
            message += ",'" + cls.Cheque_number + "'";
            message += "," + cls.Cheque_sum + "";
            message += string.IsNullOrEmpty(cls.Cheque_receive_date) ? ",null" : ",'" + cls.Cheque_receive_date + "'";
            message += ",'" + cls.Guarantee + "'";
            message += "," + cls.bs_ls_stt.Contract_Status_id + "";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Leasings_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeInsertCustomerLeasingsToMYSQL(Car_Leasings cls, Customers ctm, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Leasings_Customer/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL i_car_leasings_customer(";
            message += "'" + cls.Leasing_id + "'";
            message += ",'" + ctm.Cust_id + "'";
            message += ",'" + ctm.Cust_Idcard + "'";
            message += ",'" + ctm.Cust_Fname + "'";
            message += ",'" + ctm.Cust_LName + "'";
            message += string.IsNullOrEmpty(ctm.Cust_B_date) ? ",null" : ",'" + ctm.Cust_B_date + "'";
            message += "," + ctm.Cust_Age + "";
            message += ",'" + ctm.Cust_Idcard_without + "'";
            message += string.IsNullOrEmpty(ctm.Cust_Idcard_start) ? ",null" : ",'" + ctm.Cust_Idcard_start + "'";
            message += string.IsNullOrEmpty(ctm.Cust_Idcard_expire) ? ",null" : ",'" + ctm.Cust_Idcard_expire + "'";
            message += "," + ctm.ctm_ntnlt.Nationality_id + "";
            message += "," + ctm.ctm_org.Origin_id + "";
            message += ",'" + ctm.Cust_Tel + "'";
            message += ",'" + ctm.Cust_Email + "'";
            message += "," + ctm.ctm_pstt.person_status_id + "";
            message += ",'" + ctm.Cust_Marry_idcard + "'";
            message += ",'" + ctm.Cust_Marry_Fname + "'";
            message += ",'" + ctm.Cust_Marry_Lname + "'";
            message += "," + ctm.ctm_marry_ntnlt.Nationality_id + "";
            message += "," + ctm.ctm_marry_org.Origin_id + "";
            message += ",'" + ctm.Cust_Marry_Address_no + "'";
            message += ",'" + ctm.Cust_Marry_vilage + "'";
            message += ",'" + ctm.Cust_Marry_vilage_no + "'";
            message += ",'" + ctm.Cust_Marry_alley + "'";
            message += ",'" + ctm.Cust_Marry_road + "'";
            message += ",'" + ctm.Cust_Marry_subdistrict + "'";
            message += ",'" + ctm.Cust_Marry_district + "'";
            message += ",'" + ctm.Cust_Marry_province + "'";
            message += ",'" + ctm.Cust_Marry_country + "'";
            message += ",'" + ctm.Cust_Marry_zipcode + "'";
            message += ",'" + ctm.Cust_Marry_tel + "'";
            message += ",'" + ctm.Cust_Marry_email + "'";
            message += ",'" + ctm.Cust_Marry_job + "'";
            message += ",'" + ctm.Cust_Marry_job_position + "'";
            message += "," + ctm.Cust_Marry_job_long + "";
            message += "," + ctm.Cust_Marry_job_salary + "";
            message += ",'" + ctm.Cust_Marry_job_local_name + "'";
            message += ",'" + ctm.Cust_Marry_job_address_no + "'";
            message += ",'" + ctm.Cust_Marry_job_vilage + "'";
            message += ",'" + ctm.Cust_Marry_job_vilage_no + "'";
            message += ",'" + ctm.Cust_Marry_job_alley + "'";
            message += ",'" + ctm.Cust_Marry_job_road + "'";
            message += ",'" + ctm.Cust_Marry_job_subdistrict + "'";
            message += ",'" + ctm.Cust_Marry_job_district + "'";
            message += ",'" + ctm.Cust_Marry_job_province + "'";
            message += ",'" + ctm.Cust_Marry_job_country + "'";
            message += ",'" + ctm.Cust_Marry_job_zipcode + "'";
            message += ",'" + ctm.Cust_Marry_job_tel + "'";
            message += ",'" + ctm.Cust_Job.Trim() + "'";
            message += ",'" + ctm.Cust_Job_position.Trim() + "'";
            message += "," + ctm.Cust_Job_long + "";
            message += "," + ctm.Cust_Job_salary + "";
            message += ",'" + ctm.Cust_Job_local_name.Trim() + "'";
            message += ",'" + ctm.Cust_Job_address_no + "'";
            message += ",'" + ctm.Cust_Job_vilage + "'";
            message += ",'" + ctm.Cust_Job_vilage_no + "'";
            message += ",'" + ctm.Cust_Job_alley + "'";
            message += ",'" + ctm.Cust_Job_road + "'";
            message += ",'" + ctm.Cust_Job_subdistrict + "'";
            message += ",'" + ctm.Cust_Job_district + "'";
            message += ",'" + ctm.Cust_Job_province + "'";
            message += ",'" + ctm.Cust_Job_country + "'";
            message += ",'" + ctm.Cust_Job_zipcode + "'";
            message += ",'" + ctm.Cust_Job_tel + "'";
            message += ",'" + ctm.Cust_Job_email + "'";
            message += ",'" + ctm.Cust_Home_address_no + "'";
            message += ",'" + ctm.Cust_Home_vilage + "'";
            message += ",'" + ctm.Cust_Home_vilage_no + "'";
            message += ",'" + ctm.Cust_Home_alley + "'";
            message += ",'" + ctm.Cust_Home_road + "'";
            message += ",'" + ctm.Cust_Home_subdistrict + "'";
            message += ",'" + ctm.Cust_Home_district + "'";
            message += ",'" + ctm.Cust_Home_province + "'";
            message += ",'" + ctm.Cust_Home_country + "'";
            message += ",'" + ctm.Cust_Home_zipcode + "'";
            message += ",'" + ctm.Cust_Home_tel + "'";
            message += ",'" + ctm.Cust_Home_GPS_Latitude + "'";
            message += ",'" + ctm.Cust_Home_GPS_Longitude + "'";
            message += "," + ctm.ctm_home_stt.Home_status_id + "";
            message += ",'" + ctm.Cust_Idcard_address_no + "'";
            message += ",'" + ctm.Cust_Idcard_vilage + "'";
            message += ",'" + ctm.Cust_Idcard_vilage_no + "'";
            message += ",'" + ctm.Cust_Idcard_alley + "'";
            message += ",'" + ctm.Cust_Idcard_road + "'";
            message += ",'" + ctm.Cust_Idcard_subdistrict + "'";
            message += ",'" + ctm.Cust_Idcard_district + "'";
            message += ",'" + ctm.Cust_Idcard_province + "'";
            message += ",'" + ctm.Cust_Idcard_country + "'";
            message += ",'" + ctm.Cust_Idcard_zipcode + "'";
            message += ",'" + ctm.Cust_Idcard_tel + "'";
            message += "," + ctm.ctm_idcard_stt.Home_status_id + "";
            message += ",'" + ctm.Cust_Current_address_no + "'";
            message += ",'" + ctm.Cust_Current_vilage + "'";
            message += ",'" + ctm.Cust_Current_vilage_no + "'";
            message += ",'" + ctm.Cust_Current_alley + "'";
            message += ",'" + ctm.Cust_Current_road + "'";
            message += ",'" + ctm.Cust_Current_subdistrict + "'";
            message += ",'" + ctm.Cust_Current_district + "'";
            message += ",'" + ctm.Cust_Current_province + "'";
            message += ",'" + ctm.Cust_Current_country + "'";
            message += ",'" + ctm.Cust_Current_zipcode + "'";
            message += ",'" + ctm.Cust_Current_tel + "'";
            message += "," + ctm.ctm_current_stt.Home_status_id + "";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Leasings_Customer_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeInsertGuarantorLeasingsToMYSQL(Car_Leasings_Guarator cls_grt, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Leasings_Guarantor_" + cls_grt.Guarantor_no + "/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL i_car_leasings_guarantor(";
            message += "'" + cls_grt.cls.Leasing_id + "'";
            message += "," + cls_grt.Guarantor_no + "";
            message += ",'" + cls_grt.ctm.Cust_id + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard + "'";
            message += ",'" + cls_grt.ctm.Cust_Fname + "'";
            message += ",'" + cls_grt.ctm.Cust_LName + "'";
            message += string.IsNullOrEmpty(cls_grt.ctm.Cust_B_date) ? ",null" : ",'" + cls_grt.ctm.Cust_B_date + "'";
            message += "," + cls_grt.ctm.Cust_Age + "";
            message += ",'" + cls_grt.ctm.Cust_Idcard_without + "'";
            message += string.IsNullOrEmpty(cls_grt.ctm.Cust_Idcard_expire) ? ",null" : ",'" + cls_grt.ctm.Cust_Idcard_start + "'";
            message += string.IsNullOrEmpty(cls_grt.ctm.Cust_Idcard_expire) ? ",null" : ",'" + cls_grt.ctm.Cust_Idcard_expire + "'";
            message += "," + cls_grt.ctm.ctm_ntnlt.Nationality_id + "";
            message += "," + cls_grt.ctm.ctm_org.Origin_id + "";
            message += ",'" + cls_grt.ctm.Cust_Tel + "'";
            message += ",'" + cls_grt.ctm.Cust_Email + "'";
            message += "," + cls_grt.ctm.ctm_pstt.person_status_id + "";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_idcard + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_Fname + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_Lname + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + cls_grt.ctm.ctm_marry_ntnlt.Nationality_id + "";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + cls_grt.ctm.ctm_marry_org.Origin_id + "";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_Address_no + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_vilage + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_vilage_no + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_alley + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_road + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_subdistrict + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_district + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_province + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_country + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_zipcode + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_tel + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_email + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_position + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + cls_grt.ctm.Cust_Marry_job_long + "";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : "," + cls_grt.ctm.Cust_Marry_job_salary + "";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_local_name + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_address_no + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_vilage + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_vilage_no + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_alley + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_road + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_subdistrict + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_district + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_province + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_country + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_zipcode + "'";
            message += cls_grt.ctm.ctm_pstt.person_status_id != 2 ? ",null" : ",'" + cls_grt.ctm.Cust_Marry_job_tel + "'";
            message += ",'" + cls_grt.ctm.Cust_Job.Trim() + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_position.Trim() + "'";
            message += "," + cls_grt.ctm.Cust_Job_long + "";
            message += "," + cls_grt.ctm.Cust_Job_salary + "";
            message += ",'" + cls_grt.ctm.Cust_Job_local_name.Trim() + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_address_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_vilage + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_vilage_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_alley + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_road + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_subdistrict + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_district + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_province + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_country + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_zipcode + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_tel + "'";
            message += ",'" + cls_grt.ctm.Cust_Job_email + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_address_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_vilage + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_vilage_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_alley + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_road + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_subdistrict + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_district + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_province + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_country + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_zipcode + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_tel + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_GPS_Latitude + "'";
            message += ",'" + cls_grt.ctm.Cust_Home_GPS_Longitude + "'";
            message += "," + cls_grt.ctm.ctm_home_stt.Home_status_id + "";
            message += ",'" + cls_grt.ctm.Cust_Idcard_address_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_vilage + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_vilage_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_alley + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_road + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_subdistrict + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_district + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_province + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_country + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_zipcode + "'";
            message += ",'" + cls_grt.ctm.Cust_Idcard_tel + "'";
            message += "," + cls_grt.ctm.ctm_idcard_stt.Home_status_id + "";
            message += ",'" + cls_grt.ctm.Cust_Current_address_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_vilage + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_vilage_no + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_alley + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_road + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_subdistrict + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_district + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_province + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_country + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_zipcode + "'";
            message += ",'" + cls_grt.ctm.Cust_Current_tel + "'";
            message += "," + cls_grt.ctm.ctm_current_stt.Home_status_id + "";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Leasings_Guarantor_" + cls_grt.Guarantor_no + "_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeInsertAgentsToMYSQL(Agents cag, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Agents/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL i_car_agents(";
            message += "'" + cag.Agent_id + "'";
            message += ",'" + cag.Agent_Fname + "'";
            message += ",'" + cag.Agent_Lname + "'";
            message += ",'" + cag.Agent_Idcard + "'";
            message += ",'" + cag.Agent_Address_no + "'";
            message += ",'" + cag.Agent_Vilage + "'";
            message += ",'" + cag.Agent_Vilage_no + "'";
            message += ",'" + cag.Agent_Alley + "'";
            message += ",'" + cag.Agent_Road + "'";
            message += ",'" + cag.Agent_Subdistrict + "'";
            message += ",'" + cag.Agent_District + "'";
            message += ",'" + cag.Agent_Province + "'";
            message += ",'" + cag.Agent_Country + "'";
            message += ",'" + cag.Agent_Zipcode + "'";
            message += ",'" + cag.Agent_Status + "'";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Agents_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeInsertAgentsCommissionToMYSQL(Agents_Commission cag_com, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Agents_Commission/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL i_car_agents_commission(";
            message += "'" + cag_com.Leasing_id + "'";
            message += ",'" + cag_com.cag.Agent_id + "'";
            message += "," + cag_com.Agent_commission + "";
            message += "," + cag_com.Agent_percen + "";
            message += "," + cag_com.Agent_cash + "";
            message += "," + cag_com.Agent_net_com + "";
            message += ",'" + cag_com.Agent_num_code + "'";
            message += ",'" + cag_com.Agent_book_code + "'";
            message += string.IsNullOrEmpty(cag_com.Agent_value_save_date) ? ",null" : ",'" + cag_com.Agent_date_print + "'";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Agents_Commission_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeInsertCarLeasingsPaymentToMYSQL(Car_Leasings_Payment cls_pay, int type, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Car_Leasings_Payment/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL i_car_leasings_real_payment_mod_I(";
            message += "'" + cls_pay.Leasing_id + "'";
            message += "," + cls_pay.Period_fee + "";
            message += "," + cls_pay.Period_track + "";
            message += "," + cls_pay.Total_payment_fine + "";
            message += "," + cls_pay.Discount + "";
            message += "," + cls_pay.Real_payment + "";
            message += ",'" + cls_pay.Bill_no + "'";
            message += string.IsNullOrEmpty(cls_pay.Real_payment_date) ? "," + null : ",'" + cls_pay.Real_payment_date + "'";
            message += ",'" + cls_pay.acc_lgn.Account_id + "'";
            message += "," + cls_pay.bs_cpn.Company_id + "";
            message += ",'" + cls_pay.Bill_no_manual_ref + "'";
            message += "," + type + "";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Car_Leasings_Payment_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeSQLCodeCalPeriodFineToMYSQL(string Leasing_id, int part)
        {
            string mainDirectoryPath = "C:/SQL_Command/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string subDirectoryPath = mainDirectoryPath + "INSERT_Car_Leasings_Payment/";

            if (!Directory.Exists(subDirectoryPath))
            {
                Directory.CreateDirectory(subDirectoryPath);
            }

            string message = "CALL cal_period_fine_by_id(";
            message += "'" + Leasing_id + "'";
            message += ");";
            message += Environment.NewLine;

            string path = subDirectoryPath + "Code_INSERT_Car_Leasings_Payment_" + DateTimeUtility._dateNOW() + "_part_" + part + ".txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}