using System;

namespace JKLWebBase_v2.Global_Class
{
    public class DateTimeUtility
    {
        public static string _dateToFile()
        {
            DateTime calendar = DateTime.Today;
            string yy = calendar.Year.ToString();
            string mm = calendar.Month.ToString();
            string dd = calendar.Day.ToString();
            if (int.Parse(dd) < 10)
            {
                dd = "0" + dd;
            }
            if (int.Parse(mm) < 10)
            {
                mm = "0" + mm;
            }
            return yy + "-" + mm + "-" + dd;
        }

        public static string _dateTimeToText()
        {
            return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public static string _dateNOW()
        {
            string[] dt = DateTime.Now.ToString().Split(' ');
            string[] date = dt[0].Split('/');
            if (int.Parse(date[0]) < 10)
            {
                date[0] = "0" + int.Parse(date[0]);
            }
            if (int.Parse(date[1]) < 10)
            {
                date[1] = "0" + int.Parse(date[1]);
            }

            return (int.Parse(date[2]) - 543) + "-" + date[1] + "-" + date[0];
        }
        public static string _dateNOWForServer()
        {
            string[] dt = DateTime.Now.ToString("dd/MM/yyyy").Split(' ');
            string[] date = dt[0].Split('/');
            if (int.Parse(date[0]) < 10)
            {
                date[0] = "0" + int.Parse(date[0]);
            }
            if (int.Parse(date[1]) < 10)
            {
                date[1] = "0" + int.Parse(date[1]);
            }

            return date[2] + "-" + date[1] + "-" + date[0];
        }

        public static string _dateTimeNOW()
        {
            string[] dt = DateTime.Now.ToString().Split(' ');
            string[] date = dt[0].Split('/');
            if (int.Parse(date[0]) < 10)
            {
                date[0] = "0" + int.Parse(date[0]);
            }
            if (int.Parse(date[1]) < 10)
            {
                date[1] = "0" + int.Parse(date[1]);
            }

            return (int.Parse(date[2]) - 543) + "-" + date[1] + "-" + date[0] + " " + dt[1];
        }

        public static string _dateTimeNOWForServer()
        {
            string[] dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Split(' ');
            string[] date = dt[0].Split('/');
            if (int.Parse(date[0]) < 10)
            {
                date[0] = "0" + int.Parse(date[0]);
            }
            if (int.Parse(date[1]) < 10)
            {
                date[1] = "0" + int.Parse(date[1]);
            }

            return date[2] + "-" + date[1] + "-" + date[0] + " " + dt[1];
        }

        public static string convertDateTime(string datetime)
        {
            if (!string.IsNullOrEmpty(datetime))
            {
                string[] dt = datetime.Split(' ');
                string[] date = dt[0].Split('/');
                if (int.Parse(date[0]) < 10)
                {
                    date[0] = "0" + date[0];
                }
                if (int.Parse(date[1]) < 10)
                {
                    date[1] = "0" + date[1];
                }
                if (int.Parse(date[2]) > 2543)
                {
                    date[2] = (int.Parse(date[2]) - 543).ToString();
                }
                return date[2] + "-" + date[1] + "-" + date[0];
            }
            else
            {
                return datetime;
            }
        }

        public static string convertDateToMYSQL(string datetime)
        {
            if (!string.IsNullOrEmpty(datetime))
            {
                string[] dt = datetime.Split(' ');
                string[] date = dt[0].Split('/');

                return (int.Parse(date[2]) - 543) + "-" + date[1] + "-" + date[0];
            }
            else
            {
                return datetime;
            }
        }

        public static string convertDateToMYSQLRealServer(string datetime)
        {
            if (!string.IsNullOrEmpty(datetime))
            {
                string[] dt = datetime.Split(' ');
                string[] date = dt[0].Split('/');

                return (int.Parse(date[2])) + "-" + date[0] + "-" + date[1];
            }
            else
            {
                return datetime;
            }
        }

        public static string convertDateToPage(string datetime)
        {
            if (!string.IsNullOrEmpty(datetime))
            {
                if(datetime.IndexOf("/") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('/');
                    if (int.Parse(date[0]) < 10)
                    {
                        date[0] = "0" + int.Parse(date[0]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }
                    datetime = date[0] + "/" + date[1] + "/" + date[2];
                }
                else if (datetime.IndexOf("-") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('-');
                    if (int.Parse(date[2]) < 10)
                    {
                        date[2] = "0" + int.Parse(date[2]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }
                    datetime = date[2] + "/" + date[1] + "/" + (int.Parse(date[0]) + 543);
                }
                return datetime;
            }
            else
            {
                return datetime;
            }
        }

        public static string convertDateToPageRealServer(string datetime)
        {
            if (!string.IsNullOrEmpty(datetime))
            {
                if (datetime.IndexOf("/") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('/');
                    if (int.Parse(date[0]) < 10)
                    {
                        date[0] = "0" + int.Parse(date[0]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }
                    datetime = date[1] + "/" + date[0] + "/" + (int.Parse(date[2]) + 543);
                }
                else if (datetime.IndexOf("-") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('-');
                    if (int.Parse(date[2]) < 10)
                    {
                        date[2] = "0" + int.Parse(date[2]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }
                    datetime = date[2] + "/" + date[1] + "/" + (int.Parse(date[0]) + 543);
                }
                return datetime;
            }
            else
            {
                return datetime;
            }
        }


        public static string convertDateTimeToPage(string datetime)
        {
            if (!string.IsNullOrEmpty(datetime))
            {
                if (datetime.IndexOf("/") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('/');
                    if (int.Parse(date[0]) < 10)
                    {
                        date[0] = "0" + int.Parse(date[0]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }

                    datetime = date[0] + "/" + date[1] + "/" + date[2] + " " + dt[1];
                }
                else if (datetime.IndexOf("-") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('-');
                    if (int.Parse(date[2]) < 10)
                    {
                        date[2] = "0" + int.Parse(date[2]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }

                    datetime = date[2] + "/" + date[1] + "/" + (int.Parse(date[0]) + 543) + " " + dt[1];
                }

                return datetime;
            }
            else
            {
                return datetime;
            }
        }

        public static string convertDateTimeToPageRealServer(string datetime)
        {
            if (!string.IsNullOrEmpty(datetime))
            {
                if (datetime.IndexOf("/") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('/');
                    if (int.Parse(date[0]) < 10)
                    {
                        date[0] = "0" + int.Parse(date[0]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }

                    datetime = date[0] + "/" + date[1] + "/" + (int.Parse(date[2]) + 543) + " " + dt[1];
                }
                else if (datetime.IndexOf("-") > 0)
                {
                    string[] dt = datetime.Split(' ');
                    string[] date = dt[0].Split('-');
                    if (int.Parse(date[2]) < 10)
                    {
                        date[2] = "0" + int.Parse(date[2]);
                    }
                    if (int.Parse(date[1]) < 10)
                    {
                        date[1] = "0" + int.Parse(date[1]);
                    }

                    datetime = date[2] + "/" + date[1] + "/" + (int.Parse(date[0]) + 543) + " " + dt[1];
                }

                return datetime;
            }
            else
            {
                return datetime;
            }
        }

        public static string convertMonthToThai(string mm)
        {
            string mm_th = string.Empty;
            if (mm == "01") { mm_th = "มกราคม"; }
            else if (mm == "02") { mm_th = "กุมภาพันธ์"; }
            else if (mm == "03") { mm_th = "มีนาคม"; }
            else if (mm == "04") { mm_th = "เมษายน"; }
            else if (mm == "05") { mm_th = "พฤษภาคม"; }
            else if (mm == "06") { mm_th = "มิถุนายน"; }
            else if (mm == "07") { mm_th = "กรกฎาคม"; }
            else if (mm == "08") { mm_th = "สิงหาคม"; }
            else if (mm == "09") { mm_th = "กันยายน"; }
            else if (mm == "10") { mm_th = "ตุลาคม"; }
            else if (mm == "11") { mm_th = "พฤศจิกายน"; }
            else if (mm == "12") { mm_th = "ธันวาคม"; }

            return mm_th;
        }
    }
}