using System.IO;
using System.Text;

namespace JKLWebBase_v2.Global_Class
{
    public class Log_Error
    {
        public static void _writeErrorFile(string txtError)
        {
            string fileName = "Error " + DateTimeUtility._dateToFile() + ".log";
            FileStream fs = new FileStream("Logs_Error/"+fileName, FileMode.Append);
            StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
            w.WriteLine(DateTimeUtility._dateTimeToText() + " " + txtError);
            w.Flush();
            w.Close();
            fs.Close();
        }
    }
}