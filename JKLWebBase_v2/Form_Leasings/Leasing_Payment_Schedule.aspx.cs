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
    public partial class Leasing_Payment_Schedule : System.Web.UI.Page
    {
        Car_Leasings cls = new Car_Leasings();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Leasings"] != null)
            {
                cls = (Car_Leasings)Session["Leasings"];
            }
            else
            {
                //Response.Redirect("/Form_Leasings/Leasing_Add");
            }

        }
    }
}