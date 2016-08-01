using System;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace JKLWebBase_v2.Global_Class
{
    public class MySQLConnection
    {
        public static MySqlConnection connectionMySQL()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(conn);
                return con;
            }
            catch (MySqlException ex)
            {
                string error = "ไม่สามารถเชื่อมต่อไปยังฐานข้อมูล MySQL Server ได้ " + ex.Message.ToString();

                return null;
            }
            catch (Exception ex)
            {
                string error = "ไม่สามารถติดต่อฐานข้อมูล MySQL Server ได้ " + ex.Message.ToString();
                return null;
            }
        }
    }
}