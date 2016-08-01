using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace JKLWebBase_v2.Global_Class
{
    public class MSSQLConnection
    {
        public static SqlConnection connectionMSSQL()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MSSQLConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(conn);
                return con;
            }
            catch (SqlException ex)
            {
                string error = "ไม่สามารถเชื่อมต่อไปยังฐานข้อมูล Microsoft SQL Server ได้ " + ex.Message.ToString();

                return null;
            }
            catch (Exception ex)
            {
                string error = "ไม่สามารถติดต่อฐานข้อมูล Microsoft SQL Server ได้ " + ex.Message.ToString();
                return null;
            }
        }
    }
}