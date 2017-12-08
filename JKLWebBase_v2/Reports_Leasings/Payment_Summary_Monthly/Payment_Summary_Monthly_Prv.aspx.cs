using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Reports_Leasings.Payment_Summary_Monthly
{
    public partial class Payment_Summary_Monthly_Prv : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();
        string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            /// แสดงสาขาทุกสาขา เฉพาะผู้เกี่ยวข้อง
            if (acc_lgn.acc_lv.level_access >= 7)
            {
                Comapnys_Panel.Visible = true;
            }
            else
            {
                Comapnys_Panel.Visible = false;
            }

            /// แสดงปุ่มการออกรายงาน เฉพาะผู้เกี่ยวข้อง
            if (acc_lgn.acc_lv.level_access >= 5)
            {
                Export_Reported_mod_I_Btn.Visible = true;
                Export_Reported_mod_II_Btn.Visible = true;
            }
            else if (acc_lgn.acc_lv.level_access <= 4)
            {
                Export_Reported_mod_I_Btn.Visible = true;
                Export_Reported_mod_II_Btn.Visible = false;
            }
            else
            {
                Export_Reported_mod_I_Btn.Visible = false;
                Export_Reported_mod_II_Btn.Visible = false;
            }

            if (!IsPostBack)
            {
                _loadCompanys();
                _loadLeasingCode();
                _loadZoneService();
                _loadMonth();
                _loadYear();

                /// Acticity Logs System
                ///  

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " เข้าหน้าออกรายงานประจำเดือน ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
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

        protected void Company_ChkBxL_All_CheckedChanged(object sender, EventArgs e)
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

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Get Value in CheckBoxList                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private string _getCheckedCompany()
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
            return Company_id_inline;
        }

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
            return leasing_Code_inline;
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
            return zone_id_inline;
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

        // เดือน
        private void _loadMonth()
        {
            Month_DDL.Items.Add(new ListItem("มกราคม", "01"));
            Month_DDL.Items.Add(new ListItem("กุมภาพันธ์", "02"));
            Month_DDL.Items.Add(new ListItem("มีนาคม", "03"));
            Month_DDL.Items.Add(new ListItem("เมษายน", "04"));
            Month_DDL.Items.Add(new ListItem("พฤษภาคม", "05"));
            Month_DDL.Items.Add(new ListItem("มิถุนายน", "06"));
            Month_DDL.Items.Add(new ListItem("กรกฎาคม", "07"));
            Month_DDL.Items.Add(new ListItem("สิงหาคม", "08"));
            Month_DDL.Items.Add(new ListItem("กันยายน", "09"));
            Month_DDL.Items.Add(new ListItem("ตุลาคม", "10"));
            Month_DDL.Items.Add(new ListItem("พฤศจิกายน", "11"));
            Month_DDL.Items.Add(new ListItem("ธันวาคม", "12"));
        }

        // ปี
        private void _loadYear()
        {
            int year_list = DateTime.Now.Year;
            while (year_list >= 1957)
            {
                int year_th = year_list + 543; /// พ.ศ.
                // int year_th = year_list; /// ค.ศ.
                Year_DDL.Items.Add(new ListItem(year_th.ToString(), year_list.ToString()));
                year_list--;
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Export Data to PDF                               ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        protected void Export_Reported_mod_I_Click(object sender, EventArgs e)
        {
            string month = Month_DDL.SelectedValue;
            string year = Year_DDL.SelectedValue;

            package_login = (Base_Companys)Session["Package"];

            string Company_id_inline = _getCheckedCompany() == "" ? package_login.Company_id.ToString() : _getCheckedCompany();
            string leasing_Code_inline = _getCheckedLeasing_Code();
            string zone_id_inline = _getCheckedZone();

            Session["Company_id_inline_rpt"] = Company_id_inline;
            Session["leasing_Code_inline_rpt"] = leasing_Code_inline;
            Session["zone_id_inline_rpt"] = zone_id_inline;

            Session["month"] = month;
            Session["year"] = year;

            Session["mode"] = 1;

            /// Response.Redirect("/Reports_Leasings/Payment_Summary_Daily/Payment_Summary_Daily_Export");

            ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type = 'text/javascript'> window.open('/Reports_Leasings/Payment_Summary_Monthly/Payment_Summary_Monthly_Export'); </script>");
        }

        protected void Export_Reported_mod_II_Click(object sender, EventArgs e)
        {
            string month = Month_DDL.SelectedValue;
            string year = Year_DDL.SelectedValue;

            package_login = (Base_Companys)Session["Package"];

            string Company_id_inline = _getCheckedCompany() == "" ? package_login.Company_id.ToString() : _getCheckedCompany();
            string leasing_Code_inline = _getCheckedLeasing_Code();
            string zone_id_inline = _getCheckedZone();

            Session["Company_id_inline_rpt"] = Company_id_inline;
            Session["leasing_Code_inline_rpt"] = leasing_Code_inline;
            Session["zone_id_inline_rpt"] = zone_id_inline;

            Session["month"] = month;
            Session["year"] = year;

            Session["mode"] = 2;

            /// Response.Redirect("/Reports_Leasings/Payment_Summary_Daily/Payment_Summary_Daily_Export");

            ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type = 'text/javascript'> window.open('/Reports_Leasings/Payment_Summary_Monthly/Payment_Summary_Monthly_Export'); </script>");
        }
    }
}