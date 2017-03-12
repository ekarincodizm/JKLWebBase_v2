using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Managers_Agents;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Remove_Payment : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string leasing_id = code[1];
                    string bill_no = code[2];
                    string idcard = (string)Session["ctm_leasing_payment"];


                    Car_Leasings_Payment_Manager cls_pay_mng = new Car_Leasings_Payment_Manager();

                    cls_pay_mng.removePayment(leasing_id, bill_no);

                    string ogn_code = CryptographyCode.GenerateSHA512String(leasing_id);

                    Response.Redirect("/Form_Leasings/Leasing_Payment?code=" + CryptographyCode.EncodeTOAddressBar(ogn_code, leasing_id, idcard));
                }
            }
        }
    }
}