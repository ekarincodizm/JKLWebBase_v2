using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace JKLWebBase_v2.Global_Class
{
    public class Log_Error
    {
        public static void _writeErrorDebug(string txtError)
        {
            string mainDirectoryPath = "C:/Error_Log/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string message = "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Date Time : {0}", DateTimeUtility._dateTimeToText());
            message += Environment.NewLine;
            message += txtError;
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            string path = mainDirectoryPath + "Error " + DateTimeUtility._dateToFile() + ".log";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeErrorFile(string txtError, Exception ex)
        {
            string mainDirectoryPath = "C:/Error_Log/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string message = "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Date Time : {0}", DateTimeUtility._dateTimeToText());
            message += Environment.NewLine;
            message += txtError;
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message : {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrac : {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source : {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite : {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            string path = mainDirectoryPath + "Error " + DateTimeUtility._dateToFile() + ".log";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void _writeErrorFile(string txtError, MySqlException ex)
        {
            string mainDirectoryPath = "C:/Error_Log/";

            if (!Directory.Exists(mainDirectoryPath))
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }

            string message = "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Date Time : {0}", DateTimeUtility._dateTimeToText());
            message += Environment.NewLine;
            message += txtError;
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message : {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrac : {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source : {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite : {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            string path = mainDirectoryPath + "Error " + DateTimeUtility._dateToFile() + ".log";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}