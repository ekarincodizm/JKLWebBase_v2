﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Agents;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Add_Agent : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadThaiProvinces();
                _loadAgentStatus();
            }

            if (Session["Leasings"] == null)
            {
                Session["Class_Active"] = 2;
                Response.Redirect("/Form_Leasings/Leasing_Add");
            }
        }

        protected void Agent_idcard_TBx_TextChanged(object sender, EventArgs e)
        {
            _CheckAgent();
        }

        protected void Agent_search_Btn_Click(object sender, EventArgs e)
        {
            _CheckAgent();
        }

        protected void Agent_percen_TBx_TextChanged(object sender, EventArgs e)
        {
            _CalculatedCommission();
        }

        protected void Agent_Add_Save_Btn_Click(object sender, EventArgs e)
        {
            _AddAgent();

            Session.Remove("chk_agent_leasing");

            Session["Class_Active"] = 4;

            Session["Number_Of_Guarantor"] = "1";

            Response.Redirect("/Form_Leasings/Leasing_Add_Guarantor");
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            Agent_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Agent_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }
            Agent_province_DDL.SelectedValue = "39";
        }

        // ประเภทนายหน้า
        private void _loadAgentStatus()
        {
            Agent_status_DDL.Items.Add(new ListItem("บุคคลธรรมดา", "0"));
            Agent_status_DDL.Items.Add(new ListItem("นิติบุคคล", "1"));
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Calculate   Function                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // คำนวนค่านายหน้า
        private void _CalculatedCommission()
        {
            if (!String.IsNullOrEmpty(Agent_commission_TBx.Text) && !String.IsNullOrEmpty(Agent_percen_TBx.Text))
            {
                double commission = Convert.ToDouble(Agent_commission_TBx.Text); // ค่านายหน้า
                double percen = Convert.ToDouble(Agent_percen_TBx.Text) / 100; // % หัก ณ ที่จ่าย
                double loss_com = Math.Ceiling(commission * percen); // ค่าหัก ณ ที่จ่าย

                Agent_cash_TBx.Text = loss_com.ToString("#,##0.00"); // ค่าหัก ณ ที่จ่าย
                Agent_net_com_TBx.Text = (commission - loss_com).ToString("#,##0.00"); // ค่านายหน้าสุทธิ
            }
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckAgent()
        {
            Agents cag = new Agents_Manager().getAgentByIdCard(Agent_idcard_TBx.Text);

            Customers ctm = (Customers)Session["Customer_Leasing"];

            if (ctm.Cust_Idcard == Agent_idcard_TBx.Text)
            {
                Session.Remove("chk_agent_leasing");

                Alert_Danger_Panel.Visible = true;
                alert_header_danger_Lbl.Text = "เลขบัตรประชาชนซ้ำ";
                alert_danger_Lbl.Text = "เลขบัตรประชาชน " + Agent_idcard_TBx.Text + " ของนายหน้านี้ ไม่สามารถใช้งานได้ เนื่องจากตรงกับผู้ทำสัญญา";

                Agent_Add_Save_Btn.Visible = false;
            }
            else
            {
                Alert_Danger_Panel.Visible = false;
                Agent_Add_Save_Btn.Visible = true;

                if (cag.Agent_id != null)
                {
                    _GetAgent(cag);

                    Session["chk_agent_leasing"] = cag;

                    Alert_Warning_Panel.Visible = false;
                }
                else
                {
                    Session.Remove("chk_agent_leasing");

                    Alert_Danger_Panel.Visible = false;
                    Alert_Id_Card_Lbl.Text = "ไม่พบเลขบัตรประชาชน " + Agent_idcard_TBx.Text + " นี้ในระบบข้อมูลนายหน้า";

                    Agent_idcard_TBx.Focus();

                    _ClearAgent();
                }
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************              Get Data And Replace To Form Function                 ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _GetAgent(Agents cag)
        {
            Agent_fname_TBx.Text = cag.Agent_Fname;
            Agent_lname_TBx.Text = cag.Agent_Lname;
            Agent_idcard_TBx.Text = cag.Agent_Idcard;
            Agent_address_no_TBx.Text = cag.Agent_Address_no;
            Agent_vilage_TBx.Text = string.IsNullOrEmpty(cag.Agent_Vilage) ? "" : cag.Agent_Vilage.IndexOf('.') >= 1 ? cag.Agent_Vilage.Split('.')[1] : "";
            Agent_vilage_no_TBx.Text = string.IsNullOrEmpty(cag.Agent_Vilage_no) ? "" : cag.Agent_Vilage_no.IndexOf('.') >= 1 ? cag.Agent_Vilage_no.Split('.')[1] : "";
            Agent_alley_TBx.Text = string.IsNullOrEmpty(cag.Agent_Alley) ? "" : cag.Agent_Alley.IndexOf('.') >= 1 ? cag.Agent_Alley.Split('.')[1] : "";
            Agent_road_TBx.Text = string.IsNullOrEmpty(cag.Agent_Road) ? "" : cag.Agent_Road.IndexOf('.') >= 1 ? cag.Agent_Road.Split('.')[1] : "";
            Agent_subdistrict_TBx.Text = string.IsNullOrEmpty(cag.Agent_Subdistrict) ? "" : cag.Agent_Subdistrict.IndexOf('.') >= 1 ? cag.Agent_Subdistrict.Split('.')[1] : "";
            Agent_district_TBx.Text = string.IsNullOrEmpty(cag.Agent_District) ? "" : cag.Agent_District.IndexOf('.') >= 1 ? cag.Agent_District.Split('.')[1] : "";
            Agent_province_DDL.SelectedValue = string.IsNullOrEmpty(cag.cag_pv.Province_id.ToString()) ? "" : cag.cag_pv.Province_id.ToString();
            Agent_country_TBx.Text = cag.Agent_Country;
            Agent_zipcode_TBx.Text = cag.Agent_Zipcode;
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Clear Data Function                         ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _ClearAgent()
        {
            Agent_fname_TBx.Text = "";
            Agent_lname_TBx.Text = "";
            Agent_idcard_TBx.Text = "";
            Agent_address_no_TBx.Text = "";
            Agent_vilage_TBx.Text = "";
            Agent_vilage_no_TBx.Text = "";
            Agent_alley_TBx.Text = "";
            Agent_road_TBx.Text = "";
            Agent_subdistrict_TBx.Text = "";
            Agent_district_TBx.Text = "";
            Agent_province_DDL.SelectedValue = "39";
            Agent_country_TBx.Text = "ประเทศไทย";
            Agent_zipcode_TBx.Text = "";
            Agent_commission_TBx.Text = "";
            Agent_percen_TBx.Text = "";
            Agent_cash_TBx.Text = "";
            Agent_net_com_TBx.Text = "";
            Agent_com_code_TBx.Text = "";
            Agent_bookcode_TBx.Text = "";
            Agent_date_print_TBx.Text = "";
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _AddAgent()
        {
            Agents_Manager cag_mng = new Agents_Manager();
            Agents cag = new Agents();

            if(Session["chk_agent_leasing"] != null)
            {
                Agents cag_tmp = (Agents)Session["chk_agent_leasing"];

                cag.Agent_id = cag_tmp.Agent_id;
                cag.Agent_Fname = string.IsNullOrEmpty(Agent_fname_TBx.Text) ? "" : Agent_fname_TBx.Text;
                cag.Agent_Lname = string.IsNullOrEmpty(Agent_lname_TBx.Text) ? "" : Agent_lname_TBx.Text;
                cag.Agent_Idcard = string.IsNullOrEmpty(Agent_idcard_TBx.Text) ? "" : Agent_idcard_TBx.Text;
                cag.Agent_Address_no = string.IsNullOrEmpty(Agent_address_no_TBx.Text) ? "" : Agent_address_no_TBx.Text;
                cag.Agent_Vilage = string.IsNullOrEmpty(Agent_vilage_TBx.Text) ? "บ.-" : "บ." + Agent_vilage_TBx.Text;
                cag.Agent_Vilage_no = string.IsNullOrEmpty(Agent_vilage_no_TBx.Text) ? "ม.-" : "ม." + Agent_vilage_no_TBx.Text;
                cag.Agent_Alley = string.IsNullOrEmpty(Agent_alley_TBx.Text) ? "ซ.-" : "ซ." + Agent_alley_TBx.Text;
                cag.Agent_Road = string.IsNullOrEmpty(Agent_road_TBx.Text) ? "ถ.-" : "ถ." + Agent_road_TBx.Text;
                cag.Agent_Subdistrict = string.IsNullOrEmpty(Agent_subdistrict_TBx.Text) ? "ต.-" : "ต." + Agent_subdistrict_TBx.Text;
                cag.Agent_District = string.IsNullOrEmpty(Agent_district_TBx.Text) ? "อ.-" : "อ." + Agent_district_TBx.Text;

                cag.cag_pv = new TH_Provinces();
                cag.cag_pv.Province_id = Agent_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Agent_province_DDL.SelectedValue);

                cag.Agent_Country = string.IsNullOrEmpty(Agent_country_TBx.Text) ? "" : Agent_country_TBx.Text;
                cag.Agent_Zipcode = string.IsNullOrEmpty(Agent_zipcode_TBx.Text) ? "" : Agent_zipcode_TBx.Text;

                cag_mng.editAgent(cag);

            }
            else
            {
                cag.Agent_id = cag_mng.generateAgentID();
                cag.Agent_Fname = string.IsNullOrEmpty(Agent_fname_TBx.Text) ? "" : Agent_fname_TBx.Text;
                cag.Agent_Lname = string.IsNullOrEmpty(Agent_lname_TBx.Text) ? "" : Agent_lname_TBx.Text;
                cag.Agent_Idcard = string.IsNullOrEmpty(Agent_idcard_TBx.Text) ? "" : Agent_idcard_TBx.Text;
                cag.Agent_Address_no = string.IsNullOrEmpty(Agent_address_no_TBx.Text) ? "" : Agent_address_no_TBx.Text;
                cag.Agent_Vilage = string.IsNullOrEmpty(Agent_vilage_TBx.Text) ? "บ.-" : "บ." + Agent_vilage_TBx.Text;
                cag.Agent_Vilage_no = string.IsNullOrEmpty(Agent_vilage_no_TBx.Text) ? "ม.-" : "ม." + Agent_vilage_no_TBx.Text;
                cag.Agent_Alley = string.IsNullOrEmpty(Agent_alley_TBx.Text) ? "ซ.-" : "ซ." + Agent_alley_TBx.Text;
                cag.Agent_Road = string.IsNullOrEmpty(Agent_road_TBx.Text) ? "ถ.-" : "ถ." + Agent_road_TBx.Text;
                cag.Agent_Subdistrict = string.IsNullOrEmpty(Agent_subdistrict_TBx.Text) ? "ต.-" : "ต." + Agent_subdistrict_TBx.Text;
                cag.Agent_District = string.IsNullOrEmpty(Agent_district_TBx.Text) ? "อ.-" : "อ." + Agent_district_TBx.Text;

                cag.cag_pv = new TH_Provinces();
                cag.cag_pv.Province_id = Agent_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Agent_province_DDL.SelectedValue);

                cag.Agent_Country = string.IsNullOrEmpty(Agent_country_TBx.Text) ? "" : Agent_country_TBx.Text;
                cag.Agent_Zipcode = string.IsNullOrEmpty(Agent_zipcode_TBx.Text) ? "" : Agent_zipcode_TBx.Text;

                cag_mng.addAgent(cag);
            }

            Car_Leasings cls_tmp = (Car_Leasings)Session["Leasings"];

            Agents_Commission cag_com = new Agents_Commission();

            cag_com.Leasing_id = cls_tmp.Leasing_id;

            cag_com.cag = new Agents();
            cag_com.cag = cag;

            cag_com.Agent_commission = string.IsNullOrEmpty(Agent_commission_TBx.Text) ? 0 : Convert.ToDouble(Agent_commission_TBx.Text);
            cag_com.Agent_percen = string.IsNullOrEmpty(Agent_percen_TBx.Text) ? 0 : Convert.ToDouble(Agent_percen_TBx.Text);
            cag_com.Agent_cash = string.IsNullOrEmpty(Agent_cash_TBx.Text) ? 0 : Convert.ToDouble(Agent_cash_TBx.Text);
            cag_com.Agent_net_com = string.IsNullOrEmpty(Agent_net_com_TBx.Text) ? 0 : Convert.ToDouble(Agent_net_com_TBx.Text);
            cag_com.Agent_num_code = string.IsNullOrEmpty(Agent_com_code_TBx.Text) ? "" : Agent_com_code_TBx.Text;
            cag_com.Agent_book_code = string.IsNullOrEmpty(Agent_bookcode_TBx.Text) ? "" : Agent_bookcode_TBx.Text;
            cag_com.Agent_date_print = string.IsNullOrEmpty(Agent_date_print_TBx.Text) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(Agent_date_print_TBx.Text);

            cag_mng.addAgentCommission(cag_com);

            cag_com = cag_mng.getAgentCommission(cag_com.cag.Agent_id, cls_tmp.Leasing_id);

            Session["Agents_Leasing"] = string.IsNullOrEmpty(cag_com.cag.Agent_id) ? null : cag_com;
        }
    }
}