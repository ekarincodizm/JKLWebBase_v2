using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Managers_Leasings;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Payment_Schedule : Page
    {
        Car_Leasings cls = new Car_Leasings();
        Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
        Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

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