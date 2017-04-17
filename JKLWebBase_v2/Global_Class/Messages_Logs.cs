using System;

namespace JKLWebBase_v2.Global_Class
{
    public class Messages_Logs
    {
        public static string _messageLogsAccess(string txtLogs, string username, string compamy, int Access_status)
        {
            string message = "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Date Time : {0}", DateTimeUtility._dateTimeToText());
            message += Environment.NewLine;
            message += string.Format("Username : {0}", username);
            message += Environment.NewLine;
            message += string.Format("สาขา : {0}", compamy);
            message += Environment.NewLine;
            message += txtLogs;
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Access Status : {0}", Access_status == 1? " เข้าสู่ระบบสำเร็จ " : " เข้าสู่ระบบไม่สำเร็จ ");
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            return message;
        }

        public static string _messageLogsLogout(string txtLogs, string username, string compamy, int Access_status)
        {
            string message = "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Date Time : {0}", DateTimeUtility._dateTimeToText());
            message += Environment.NewLine;
            message += string.Format("Username : {0}", username);
            message += Environment.NewLine;
            message += string.Format("สาขา : {0}", compamy);
            message += Environment.NewLine;
            message += txtLogs;
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Logout Status : {0}", Access_status == 1 ? " ออกจากระบบสำเร็จ " : " ออกจากระบบสำเร็จไม่สำเร็จ ");
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            return message;
        }

        public static string _messageLogsNormal(string txtLogs, string username, string compamy)
        {
            string message = "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Date Time : {0}", DateTimeUtility._dateTimeToText());
            message += Environment.NewLine;
            message += string.Format("Username : {0}", username);
            message += Environment.NewLine;
            message += string.Format("สาขา : {0}", compamy);
            message += Environment.NewLine;
            message += txtLogs;
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            return message;
        }
    }
}