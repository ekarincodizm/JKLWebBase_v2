using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;


namespace JKLWebBase_v2.Reports_Leasings.Total_Balance_Payment
{
    public partial class Total_Balance_Payment_Prv : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCompanys();
                _loadLeasingCode();
                _loadZoneService();
            }
        }


        protected void Leasing_Code_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Leasing_Code_ChkBxL.Items.Count;

            if (Leasing_Code_ChkBx_All.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    Leasing_Code_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Leasing_Code_ChkBxL.Items[i].Selected = false;
                }
            }
        }

        protected void Company_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Company_ChkBxL.Items.Count;

            if (Company_ChkBx_All.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    Company_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Company_ChkBxL.Items[i].Selected = false;
                }
            }
        }

        protected void Zone_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Zone_ChkBxL.Items.Count;

            if (Zone_ChkBx_All.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    Zone_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Zone_ChkBxL.Items[i].Selected = false;
                }
            }
        }

        protected void Export_Reported_Btn_Click(object sender, EventArgs e)
        {
            string deposit_no = string.IsNullOrEmpty(Deps_No_TBx.Text) ? "" : Deps_No_TBx.Text;
            string leasing_no = string.IsNullOrEmpty(Leasing_No_TBx.Text) ? "" : Leasing_No_TBx.Text;
            string idcard = string.IsNullOrEmpty(Cust_Idcard_TBx.Text) ? "" : Cust_Idcard_TBx.Text;
            string fname = string.IsNullOrEmpty(Cust_FName_TBx.Text) ? "" : Cust_FName_TBx.Text;
            string lname = string.IsNullOrEmpty(Cust_LName_TBx.Text) ? "" : Cust_LName_TBx.Text;
            string lost_str = string.IsNullOrEmpty(Lost_Payment_str_TBx.Text) ? "0" : Lost_Payment_str_TBx.Text;
            string lost_end = string.IsNullOrEmpty(Lost_Payment_end_TBx.Text) ? "0" : Lost_Payment_end_TBx.Text;
            string district = string.IsNullOrEmpty(district_TBx.Text) ? "" : district_TBx.Text;
            string province = string.IsNullOrEmpty(province_TBx.Text) ? "" : province_TBx.Text;
            string leasing_Code_inline = _getCheckedLeasing_Code();
            string Company_id_inline = _getCheckedBranch();
            string zone_id_inline = _getCheckedZone();

            Session["deposit_no_rpt"] = deposit_no;
            Session["leasing_no_rpt"] = leasing_no;
            Session["idcard_rpt"] = idcard;
            Session["fname_rpt"] = fname;
            Session["lname_rpt"] = lname;
            Session["lost_str_rpt"] = lost_str;
            Session["lost_end_rpt"] = lost_end;
            Session["district_rpt"] = district;
            Session["leasing_Code_inline_rpt"] = leasing_Code_inline;
            Session["Company_id_inline_rpt"] = Company_id_inline;
            Session["zone_id_inline_rpt"] = zone_id_inline;

            ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type = 'text/javascript'> window.open('/Reports_Leasings/Total_Balance_Payment/Total_Balance_Payment_Export'); </script>");
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // รหัสสัญญา
        private void _loadLeasingCode()
        {
            List<Base_Leasing_Code> list_data = new Base_Leasing_Code_Manager().getLeasingCode();
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Leasing_Code data = list_data[i];
                if (string.IsNullOrEmpty(data.Leasing_code_S_Name))
                {
                    Leasing_Code_ChkBxL.Items.Add(new ListItem(data.Leasing_code_name, data.Leasing_code_id.ToString()));
                }
                else
                {
                    Leasing_Code_ChkBxL.Items.Add(new ListItem(data.Leasing_code_name + " ( " + data.Leasing_code_S_Name + " ) ", data.Leasing_code_id.ToString()));
                }

            }
        }

        // สาขา
        private void _loadCompanys()
        {
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanys(0, 0);
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Companys data = list_data[i];
                Company_ChkBxL.Items.Add(new ListItem(data.Company_code + " ( " + data.Company_N_name + " ) ", data.Company_id.ToString()));
            }
        }

        // เขตบริการ
        private void _loadZoneService()
        {
            List<Base_Zone_Service> list_data = new Base_Zone_Service_Manager().getZoneService();
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Zone_Service data = list_data[i];
                Zone_ChkBxL.Items.Add(new ListItem(data.Zone_code + " " + data.Zone_name, data.Zone_id.ToString()));
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Get Value in CheckBoxList                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private string _getCheckedLeasing_Code()
        {
            string leasing_Code_inline = "";
            int count = 1;

            for (int i = 0; i < Leasing_Code_ChkBxL.Items.Count; i++)
            {
                if (Leasing_Code_ChkBxL.Items[i].Selected && count == 1)
                {
                    leasing_Code_inline += Leasing_Code_ChkBxL.Items[i].Value;
                    count++;
                }
                else if (Leasing_Code_ChkBxL.Items[i].Selected)
                {
                    leasing_Code_inline += "," + Leasing_Code_ChkBxL.Items[i].Value;
                    count++;
                }
            }

            if (Leasing_Code_ChkBx_All.Checked == true)
            {
                leasing_Code_inline = "";
            }

            return leasing_Code_inline;
        }

        private string _getCheckedBranch()
        {
            string Company_id_inline = "";
            int count = 1;

            for (int i = 0; i < Company_ChkBxL.Items.Count; i++)
            {
                if (Company_ChkBxL.Items[i].Selected && count == 1)
                {
                    Company_id_inline += Company_ChkBxL.Items[i].Value;
                    count++;
                }
                else if (Company_ChkBxL.Items[i].Selected)
                {
                    Company_id_inline += "," + Company_ChkBxL.Items[i].Value;
                    count++;
                }
            }

            if (Company_ChkBx_All.Checked == true)
            {
                Company_id_inline = "";
            }

            return Company_id_inline;
        }

        private string _getCheckedZone()
        {
            string zone_id_inline = "";
            int count = 1;

            for (int i = 0; i < Zone_ChkBxL.Items.Count; i++)
            {
                if (Zone_ChkBxL.Items[i].Selected && count == 1)
                {
                    zone_id_inline += Zone_ChkBxL.Items[i].Value;
                    count++;
                }
                else if (Zone_ChkBxL.Items[i].Selected)
                {
                    zone_id_inline += "," + Zone_ChkBxL.Items[i].Value;
                    count++;
                }
            }

            if (Zone_ChkBx_All.Checked == true)
            {
                zone_id_inline = "";
            }

            return zone_id_inline;
        }
    }
}