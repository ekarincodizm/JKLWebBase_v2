﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Form_Base
{
    public partial class Base_Nationalitys_Edit : Page
    {
        private Base_Nationalitys bs_ntn = new Base_Nationalitys();
        private Base_Nationalitys_Manager bs_ntn_mng = new Base_Nationalitys_Manager();
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string Nationality_id = code[1];

                    if (Request.Params["mode"] == "e")
                    {
                        bs_ntn = bs_ntn_mng.getNationalityById(Convert.ToInt32(Nationality_id));

                        _loadNationality(bs_ntn);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        _removeNationality(Nationality_id);

                        Response.Redirect("/Form_Base/Base_Nationalitys_Management");
                    }
                }
            }
        }

        private void _loadNationality(Base_Nationalitys bs_ntn)
        {
            Nationality_name_ENG_TBx.Text = bs_ntn.Nationality_name_ENG;
            Nationality_name_TH_TBx.Text = bs_ntn.Nationality_name_TH;
        }

        private void _editNationality(string Nationality_id)
        {
            if (Request.Params["mode"] == "e")
            {
                Base_Leasing_Code bs_lscd = new Base_Leasing_Code();

                string Nationality_name_ENG = string.IsNullOrEmpty(Nationality_name_ENG_TBx.Text) ? "" : Nationality_name_ENG_TBx.Text;
                string Nationality_name_TH = string.IsNullOrEmpty(Nationality_name_TH_TBx.Text) ? "" : Nationality_name_TH_TBx.Text;

                bs_ntn_mng.editNationality(Convert.ToInt32(Nationality_id), Nationality_name_ENG, Nationality_name_TH);

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลสัญชาติ ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }

        private void _removeNationality(string Nationality_id)
        {
            if (Request.Params["mode"] == "r")
            {
                bs_ntn_mng.removeNationality(Convert.ToInt32(Nationality_id));

                /// Acticity Logs System
                ///  

                package_login = (Base_Companys)Session["Package"];
                acc_lgn = (Account_Login)Session["Login"];

                string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ลบข้อมูลสัญชาติ ", acc_lgn.resu, package_login.Company_N_name);

                new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                /// Acticity Logs System
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string Nationality_id = code[1];

                _editNationality(Nationality_id);
            }

            Response.Redirect("/Form_Base/Base_Nationalitys_Management");
        }

        protected void Back_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Base/Base_Nationalitys_Management");
        }
    }
}