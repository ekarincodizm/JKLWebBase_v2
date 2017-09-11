using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Agents;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Form_Agents
{
    public partial class Agents_Add : Page
    {
        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadThaiProvinces();
                _loadAgentstatus();
            }

            Alert_Warning_Panel.Visible = false;
            Alert_Success_Panel.Visible = false;
        }

        protected void Agent_idcard_TBx_TextChanged(object sender, EventArgs e)
        {
            _CheckAgent();
        }

        protected void Agent_search_Btn_Click(object sender, EventArgs e)
        {
            _CheckAgent();
        }

        protected void Agent_Add_Save_Btn_Click(object sender, EventArgs e)
        {
            _AddAgent();

            Session.Remove("chk_agent");

            Alert_Success_Panel.Visible = true;

            /// Acticity Logs System
            ///  

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " เพิ่มข้อมูลนายหน้า ", acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System
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
        private void _loadAgentstatus()
        {
            Agent_status_DDL.Items.Add(new ListItem("บุคคลธรรมดา", "1"));
            Agent_status_DDL.Items.Add(new ListItem("นิติบุคคล", "2"));
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
            Agent_vilage_TBx.Text = string.IsNullOrEmpty(cag.Agent_Vilage) ? "" : cag.Agent_Vilage.IndexOf('.') >= 1 ? cag.Agent_Vilage.Split('.')[1] : "";
            Agent_vilage_no_TBx.Text = string.IsNullOrEmpty(cag.Agent_Vilage_no) ? "" : cag.Agent_Vilage_no.IndexOf('.') >= 1 ? cag.Agent_Vilage_no.Split('.')[1] : "";
            Agent_alley_TBx.Text = string.IsNullOrEmpty(cag.Agent_Alley) ? "" : cag.Agent_Alley.IndexOf('.') >= 1 ? cag.Agent_Alley.Split('.')[1] : "";
            Agent_road_TBx.Text = string.IsNullOrEmpty(cag.Agent_Road) ? "" : cag.Agent_Road.IndexOf('.') >= 1 ? cag.Agent_Road.Split('.')[1] : "";
            Agent_subdistrict_TBx.Text = string.IsNullOrEmpty(cag.Agent_Subdistrict) ? "" : cag.Agent_Subdistrict.IndexOf('.') >= 1 ? cag.Agent_Subdistrict.Split('.')[1] : "";
            Agent_district_TBx.Text = string.IsNullOrEmpty(cag.Agent_District) ? "" : cag.Agent_District.IndexOf('.') >= 1 ? cag.Agent_District.Split('.')[1] : "";
            Agent_province_DDL.SelectedValue = string.IsNullOrEmpty(cag.Agent_Province) ? "0" : cag.Agent_Province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(cag.Agent_Province.Split('.')[1]) : "0";
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
            Agent_status_DDL.SelectedValue = "0";
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _AddAgent()
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
                cag.Agent_Province = Agent_province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Agent_province_DDL.SelectedItem.Text;
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
                cag.Agent_Province = Agent_province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Agent_province_DDL.SelectedItem.Text;
                cag.Agent_Country = string.IsNullOrEmpty(Agent_country_TBx.Text) ? "" : Agent_country_TBx.Text;
                cag.Agent_Zipcode = string.IsNullOrEmpty(Agent_zipcode_TBx.Text) ? "" : Agent_zipcode_TBx.Text;

                cag_mng.addAgent(cag);
            }
        }
    }
}