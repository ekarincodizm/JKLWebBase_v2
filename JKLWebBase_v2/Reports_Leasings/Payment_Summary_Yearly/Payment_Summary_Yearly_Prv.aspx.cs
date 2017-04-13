﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Class_Account;

namespace JKLWebBase_v2.Reports_Leasings.Payment_Summary_Yearly
{
    public partial class Payment_Summary_Yearly_Prv : Page
    {
        string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Base_Companys package_login = new Base_Companys();
            Account_Login acc_lgn = new Account_Login();

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
            else if (acc_lgn.acc_lv.level_access <= 3)
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
                _loadYear();
            }
        }

        protected void Company_ChkBxL_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Company_ChkBxL.Items.Count;

            if (Company_ChkBxL_All.Checked)
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

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

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
            string year = Year_DDL.SelectedValue;

            Base_Companys package_login = new Base_Companys();

            package_login = (Base_Companys)Session["Package"];

            string Company_id_inline = _getCheckedCompany() == "" ? package_login.Company_id.ToString() : _getCheckedCompany();
            Session["Company_id_inline_rpt"] = Company_id_inline;

            Session["year"] = year;

            Session["mode"] = 1;

            /// Response.Redirect("/Reports_Leasings/Payment_Summary_Daily/Payment_Summary_Daily_Export");

            ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type = 'text/javascript'> window.open('/Reports_Leasings/Payment_Summary_Yearly/Payment_Summary_Yearly_Export'); </script>");
        }

        protected void Export_Reported_mod_II_Click(object sender, EventArgs e)
        {
            string year = Year_DDL.SelectedValue;

            Base_Companys package_login = new Base_Companys();

            package_login = (Base_Companys)Session["Package"];

            string Company_id_inline = _getCheckedCompany() == "" ? package_login.Company_id.ToString() : _getCheckedCompany();
            Session["Company_id_inline_rpt"] = Company_id_inline;

            Session["year"] = year;

            Session["mode"] = 2;

            /// Response.Redirect("/Reports_Leasings/Payment_Summary_Daily/Payment_Summary_Daily_Export");

            ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type = 'text/javascript'> window.open('/Reports_Leasings/Payment_Summary_Yearly/Payment_Summary_Yearly_Export'); </script>");
        }
    }
}