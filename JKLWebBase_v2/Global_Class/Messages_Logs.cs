using System;

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
            message += string.Format("<p> Login Status : {0}", Access_status == 1? " เข้าสู่ระบบสำเร็จ  </p>" : " เข้าสู่ระบบไม่สำเร็จ  </p>");
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
    }
}