using JKLWebBase_v2.Class_Base;

namespace JKLWebBase_v2.Class_Account
{
    public class Activity_Log
    {
        public string log_id { get; set; }
        public string log_date { get; set; }
        public string log_details { get; set; } 
        public Account_Level acc_login { get; set; }
        public Base_Companys bs_cpn { get; set; }
    }
}