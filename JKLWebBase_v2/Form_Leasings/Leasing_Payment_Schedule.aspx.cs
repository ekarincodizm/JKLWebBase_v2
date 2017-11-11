using System;
using System.Collections.Generic;
using System.Web.UI;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Payment_Schedule : Page
    {
        private Car_Leasings cls = new Car_Leasings();
        private Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
        private Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Leasings"] != null)
            {
                cls = (Car_Leasings)Session["Leasings"];

                List<Car_Leasings_Payment> list_cls_pay = cls_pay_mng.getRealPaymentInfo(cls.Leasing_id);

                Session["list_cls_pay"] = list_cls_pay;
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Add");
            }
        }
    }
}