﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Agents;


namespace JKLWebBase_v2.Form_Agents
{
    public partial class Agents_Edit : Page
    {
        Agents cag = new Agents();
        Agents_Manager cag_mng = new Agents_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("List_Agents");

                _loadThaiProvinces();
                _loadAgentStatus();

                if (Request.Params["code"] == null)
                {
                    Response.Redirect("/Form_Agents/Agents_Add");

                }
                else if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string idcard = code[1];

                    cag = cag_mng.getAgentByIdCard(idcard);

                    Session["chk_agent"] = cag;

                    _GetAgent(cag);
                }
            }

            Alert_Success_Panel.Visible = false;
        }

        protected void Agent_search_Btn_Click(object sender, EventArgs e)
        {
            _CheckAgent();
        }

        protected void Agent_Add_Save_Btn_Click(object sender, EventArgs e)
        {
            _EditAgent();

            Session.Remove("chk_agent");

            Alert_Success_Panel.Visible = true;
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
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckAgent()
        {
            Agents cag = new Agents_Manager().getAgentByIdCard(Agent_idcard_TBx.Text);
            if (cag.Agent_id != null)
            {
                _GetAgent(cag);

                Session["chk_agent"] = cag;

                Alert_Warning_Panel.Visible = false;
                Alert_Success_Panel.Visible = false;
            }
            else
            {
                Session.Remove("chk_agent");

                Alert_Warning_Panel.Visible = true;
                Alert_Success_Panel.Visible = false;
                Alert_Id_Card_Lbl.Text = "ไม่พบเลขบัตรประชาชน " + Agent_idcard_TBx.Text + " นี้ในระบบข้อมูลนายหน้า";

                Agent_idcard_TBx.Focus();

                _ClearAgent();
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
            Agent_vilage_TBx.Text = cag.Agent_Vilage.IndexOf('.') >= 1 ? cag.Agent_Vilage.Split('.')[1] : "" ;
            Agent_vilage_no_TBx.Text = cag.Agent_Vilage_no.IndexOf('.') >= 1 ? cag.Agent_Vilage_no.Split('.')[1] : "";
            Agent_alley_TBx.Text = cag.Agent_Alley.IndexOf('.') >= 1 ? cag.Agent_Alley.Split('.')[1] : "";
            Agent_road_TBx.Text = cag.Agent_Road.IndexOf('.') >= 1 ? cag.Agent_Road.Split('.')[1] : "";
            Agent_subdistrict_TBx.Text = cag.Agent_Subdistrict.IndexOf('.') >= 1 ? cag.Agent_Subdistrict.Split('.')[1] : "";
            Agent_district_TBx.Text = cag.Agent_District.IndexOf('.') >= 1 ? cag.Agent_District.Split('.')[1] : "";
            Agent_province_DDL.SelectedValue = cag.cag_pv.Province_id.ToString();
            Agent_country_TBx.Text = cag.Agent_Country;
            Agent_zipcode_TBx.Text = cag.Agent_Zipcode;
            Agent_status_DDL.SelectedValue = cag.Agent_Status.ToString();
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
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _EditAgent()
        {
            Agents_Manager cag_mng = new Agents_Manager();
            Agents cag = new Agents();

            if (Session["chk_agent"] != null)
            {
                Agents cag_tmp = (Agents)Session["chk_agent"];

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
        }

    }
}