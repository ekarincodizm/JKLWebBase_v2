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
            return DateTime.Now.ToString();
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

        public static string convertDateTime(string datetime)
        {
            if (!datetime.Equals(""))
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
            if (!datetime.Equals(""))
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

        public static string convertDateToPage(string datetime)
        {
            if (!datetime.Equals(""))
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
    }
}