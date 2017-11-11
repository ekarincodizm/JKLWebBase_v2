using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Class_Agents;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Managers_Leasings;
using JKLWebBase_v2.Managers_Agents;
using JKLWebBase_v2.Class_Account;
using JKLWebBase_v2.Manager_Account;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Edit_Customer : Page
    {
        private Customers ctm = new Customers();
        private Agents_Manager cag_mng = new Agents_Manager();
        private Customers_Manager ctm_mng = new Customers_Manager();
        private Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();
        private Car_Leasings_Customer_Manager cls_ctm_mng = new Car_Leasings_Customer_Manager();
        private Car_Leasings_Guarantor_Manager cls_grt_mng = new Car_Leasings_Guarantor_Manager();

        private Base_Companys package_login = new Base_Companys();
        private Account_Login acc_lgn = new Account_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            if (acc_lgn.acc_lv.level_access < 7)
            {
                Save_Btn.Visible = false;
            }

            if (!IsPostBack)
            {
                _loadHomeStatus();
                _loadNationality();
                _loadOrigin();
                _loadPersonStatus();
                _loadThaiProvinces();

                Marry_Panel.Visible = false;

                if (Request.Params["code"] == null && Session["Customer_Leasing"] == null)
                {
                    Session["Class_Active"] = 1;
                    Response.Redirect("/Form_Leasings/Leasing_Add_Customer");
                }
                else if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string leasing_id = code[1];
                    string idcard = code[2];
                    string Leasing_no = code[3];

                    if (Request.Params["mode"] == "e")
                    {
                        ctm = cls_ctm_mng.getCustomersLeasing(leasing_id, idcard);

                        if (ctm != null) { Session["Customer_Leasing"] = ctm; }

                        Car_Leasings cls = cls_mng.getCarLeasingById(leasing_id);

                        if (cls != null) { Session["Leasings"] = cls; }

                        Agents_Commission cag_com = cag_mng.getAgentCommission("", cls.Leasing_id);

                        if (cag_com.cag != null) { Session["Agents_Leasing"] = cag_com; }

                        List<Car_Leasings_Guarator> list_cls_bsm = cls_grt_mng.getAllGuarantors(cls.Leasing_id, "", "");

                        for (int i = 1; i <= 5; i++)
                        {
                            if (list_cls_bsm.Count > 0 && i <= list_cls_bsm.Count)
                            {
                                Car_Leasings_Guarator cls_bsm = list_cls_bsm[i - 1];

                                Session["Guarantor_" + cls_bsm.Guarantor_no] = ctm_mng.getCustomersByIdCard(cls_bsm.ctm.Cust_Idcard);
                            }
                        }

                        _GetCustomer(ctm);
                    }
                    else if (Request.Params["mode"] == "r")
                    {
                        cls_mng.removeCarLeasings(leasing_id);

                        /// Acticity Logs System
                        ///  

                        package_login = (Base_Companys)Session["Package"];
                        acc_lgn = (Account_Login)Session["Login"];

                        string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " ลบข้อมูลสัญญาฝาก : " + idcard + " เลขสัญญา : " + Leasing_no, acc_lgn.resu, package_login.Company_N_name);

                        new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

                        /// Acticity Logs System

                        Response.Redirect("/Form_Leasings/Leasing_Search");
                    }
                }
                else
                {
                    ctm = (Customers)Session["Customer_Leasing"];

                    _GetCustomer(ctm);
                }
            }
        }

        protected void Cust_Search_Btn_Click(object sender, EventArgs e)
        {
            _CheckCustomer();
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            _EditCustomer();

            Session.Remove("chk_customer_leasing");

            Session["Class_Active"] = 2;

            if (Session["Leasings"] == null)
            {
                Response.Redirect("/Form_Leasings/Leasing_Add");
            }
            else
            {
                Response.Redirect("/Form_Leasings/Leasing_Edit");
            }
        }

        protected void Cust_status_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cust_status_DDL.SelectedIndex == 2 || Cust_status_DDL.SelectedIndex == 3)
            {
                Marry_Panel.Visible = true;

                Customers ctm_tmp = (Customers)Session["Customer_Leasing"];
                Car_Leasings cls_tmp = (Car_Leasings)Session["Leasings"];

                ctm = cls_ctm_mng.getCustomersLeasing(cls_tmp.Leasing_id, ctm_tmp.Cust_Idcard);

                Marry_idcard_TBx.Text = ctm.Cust_Marry_idcard;
                Marry_Fname_TBx.Text = ctm.Cust_Marry_Fname;
                Marry_Lname_TBx.Text = ctm.Cust_Marry_Lname;
                Marry_Nationality_DDL.SelectedValue = ctm.ctm_marry_ntnlt.Nationality_id.ToString();
                Marry_Origin_DDL.SelectedValue = ctm.ctm_marry_org.Origin_id.ToString();
                Marry_address_no_TBx.Text = ctm.Cust_Marry_Address_no;
                Marry_vilage_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_vilage) ? "" : ctm.Cust_Marry_vilage.IndexOf('.') >= 1 ? ctm.Cust_Marry_vilage.Split('.')[1] : "";
                Marry_vilage_no_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_vilage_no) ? "" : ctm.Cust_Marry_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Marry_vilage_no.Split('.')[1] : "";
                Marry_alley_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_alley) ? "" : ctm.Cust_Marry_alley.IndexOf('.') >= 1 ? ctm.Cust_Marry_alley.Split('.')[1] : "";
                Marry_road_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_road) ? "" : ctm.Cust_Marry_road.IndexOf('.') >= 1 ? ctm.Cust_Marry_road.Split('.')[1] : "";
                Marry_subdistrict_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_subdistrict) ? "" : ctm.Cust_Marry_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Marry_subdistrict.Split('.')[1] : "";
                Marry_district_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_district) ? "" : ctm.Cust_Marry_district.IndexOf('.') >= 1 ? ctm.Cust_Marry_district.Split('.')[1] : "";
                Marry_province_DDL.SelectedValue = string.IsNullOrEmpty(ctm.Cust_Marry_province) ? "" : ctm.Cust_Marry_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Marry_province.Split('.')[1]) : "";
                Marry_country_TBx.Text = ctm.Cust_Marry_country;
                Marry_zipcode_TBx.Text = ctm.Cust_Marry_zipcode;
                Marry_job_TBx.Text = ctm.Cust_Marry_job;
                Marry_job_position_TBx.Text = ctm.Cust_Marry_job_position;
                Marry_job_long_TBx.Text = ctm.Cust_Marry_job_long.ToString();
                Marry_job_salary_TBx.Text = ctm.Cust_Marry_job_salary.ToString();
                Marry_job_local_name_TBx.Text = ctm.Cust_Marry_job_local_name;
                Marry_job_address_no_TBx.Text = ctm.Cust_Marry_job_address_no;
                Marry_job_vilage_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_vilage) ? "" : ctm.Cust_Marry_job_vilage.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_vilage.Split('.')[1] : "";
                Marry_job_vilage_no_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_vilage_no) ? "" : ctm.Cust_Marry_job_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_vilage_no.Split('.')[1] : "";
                Marry_job_alley_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_alley) ? "" : ctm.Cust_Marry_job_alley.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_alley.Split('.')[1] : "";
                Marry_job_road_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_road) ? "" : ctm.Cust_Marry_job_road.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_road.Split('.')[1] : "";
                Marry_job_subdistrict_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_subdistrict) ? "" : ctm.Cust_Marry_job_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_subdistrict.Split('.')[1] : "";
                Marry_job_district_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_district) ? "" : ctm.Cust_Marry_job_district.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_district.Split('.')[1] : "";
                Marry_job_province_DDL.SelectedValue = string.IsNullOrEmpty(ctm.Cust_Marry_job_province) ? "" : ctm.Cust_Marry_job_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Marry_job_province.Split('.')[1]) : "";
                Marry_job_country_TBx.Text = ctm.Cust_Marry_job_country;
                Marry_job_zipcode_TBx.Text = ctm.Cust_Marry_job_zipcode;
                Marry_job_tel_TBx.Text = ctm.Cust_Marry_job_tel;
                Marry_tel_TBx.Text = ctm.Cust_Marry_tel;
                Marry_email_TBx.Text = ctm.Cust_Marry_email;
            }
            else
            {
                Marry_Panel.Visible = false;
            }
        }

        protected void Home_To_Idcard_btn_Click(object sender, EventArgs e)
        {
            _CopyBaseDataAddress(1);
        }

        protected void Idcard_To_Current_btn_Click(object sender, EventArgs e)
        {
            _CopyBaseDataAddress(2);
        }

        protected void Home_To_Current_btn_Click(object sender, EventArgs e)
        {
            _CopyBaseDataAddress(3);
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // เชื้อชาติ
        private void _loadOrigin()
        {
            List<Base_Origins> list_data = new Base_Origins_Manager().getOrigins();
            Cust_Origin_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            Marry_Origin_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Origins data = list_data[i];
                Cust_Origin_DDL.Items.Add(new ListItem(data.Origin_name_TH + " ( " + data.Origin_name_ENG + " ) ", data.Origin_id.ToString()));
                Marry_Origin_DDL.Items.Add(new ListItem(data.Origin_name_TH + " ( " + data.Origin_name_ENG + " ) ", data.Origin_id.ToString()));
            }
        }

        // สัญชาติ
        private void _loadNationality()
        {
            List<Base_Nationalitys> list_data = new Base_Nationalitys_Manager().getNationalitys();
            Cust_Nationality_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            Marry_Nationality_DDL.Items.Add(new ListItem("กรุณาเลือก", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Nationalitys data = list_data[i];
                Cust_Nationality_DDL.Items.Add(new ListItem(data.Nationality_name_TH + " ( " + data.Nationality_name_ENG + " ) ", data.Nationality_id.ToString()));
                Marry_Nationality_DDL.Items.Add(new ListItem(data.Nationality_name_TH + " ( " + data.Nationality_name_ENG + " ) ", data.Nationality_id.ToString()));
            }
        }

        // สถานะภาพการสมรส
        private void _loadPersonStatus()
        {
            List<Base_Person_Status> list_data = new Base_Person_Status_Manager().getPersonStatus();
            Cust_status_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Person_Status data = list_data[i];
                Cust_status_DDL.Items.Add(new ListItem(data.person_status_name, data.person_status_id.ToString()));
            }
        }

        // สถานะภาพของผู้อาศัย
        private void _loadHomeStatus()
        {
            List<Base_Home_Status> list_data = new Base_Home_Status_Manager().getHomeStatus();
            Current_Cust_Home_status_id_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Home_Cust_Home_status_id_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Idcard_Cust_Home_status_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Home_Status data = list_data[i];
                Current_Cust_Home_status_id_DDL.Items.Add(new ListItem(data.Home_status_name, data.Home_status_id.ToString()));
                Home_Cust_Home_status_id_DDL.Items.Add(new ListItem(data.Home_status_name, data.Home_status_id.ToString()));
                Idcard_Cust_Home_status_DDL.Items.Add(new ListItem(data.Home_status_name, data.Home_status_id.ToString()));
            }
        }

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            Current_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Cust_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Home_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Idcard_Cust_Province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Marry_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            Marry_job_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Current_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Cust_job_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Home_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Idcard_Cust_Province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Marry_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
                Marry_job_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }

            Current_Cust_Province_DDL.SelectedValue = "39";
            Cust_job_province_DDL.SelectedValue = "39";
            Home_Cust_Province_DDL.SelectedValue = "39";
            Idcard_Cust_Province_DDL.SelectedValue = "39";
            Marry_province_DDL.SelectedValue = "39";
            Marry_job_province_DDL.SelectedValue = "39";
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckCustomer()
        {
            Customers ctm_tmp = new Customers_Manager().getCustomersByIdCard(Cust_idcard_TBx.Text);

            if (ctm_tmp.Cust_Idcard != null)
            {
                _GetCustomer(ctm_tmp);

                Session["chk_customer_leasing"] = ctm_tmp;

                Alert_Warning_Panel.Visible = false;
            }
            else
            {
                Session.Remove("chk_customer_leasing");

                Alert_Warning_Panel.Visible = true;
                Alert_Id_Card_Lbl.Text = "ไม่พบเลขบัตรประชาชน " + Cust_idcard_TBx.Text + " นี้ในระบบข้อมูลลูกค้า";

                Cust_idcard_TBx.Focus();
            }

        }

        /*******************************************************************************************************************************************************************************
        ****************************************************              Get Data And Replace To Form Function                 ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _GetCustomer(Customers ctm)
        {
            if (ctm != null)
            { 
                Cust_idcard_TBx.Text = ctm.Cust_Idcard;
                Cust_Fname_TBx.Text = ctm.Cust_Fname;
                Cust_LName_TBx.Text = ctm.Cust_LName;
                Cust_B_date_TBx.Text = string.IsNullOrEmpty(ctm.Cust_B_date) ? "" : DateTimeUtility.convertDateToPageRealServer(ctm.Cust_B_date.Split(' ')[0]);
                Cust_Idcard_without_TBx.Text = ctm.Cust_Idcard_without;
                Cust_Idcard_start_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Idcard_start) ? "" : DateTimeUtility.convertDateToPageRealServer(ctm.Cust_Idcard_start.Split(' ')[0]);
                Cust_Idcard_expire_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Idcard_expire) ? "" : DateTimeUtility.convertDateToPageRealServer(ctm.Cust_Idcard_expire.Split(' ')[0]);
                Cust_Nationality_DDL.SelectedValue = ctm.ctm_ntnlt.Nationality_id.ToString();
                Cust_Origin_DDL.SelectedValue = ctm.ctm_org.Origin_id.ToString();
                Cust_Tel_TBx.Text = ctm.Cust_Tel;
                Cust_Email_TBx.Text = ctm.Cust_Email;
                Cust_job_TBx.Text = ctm.Cust_Job;
                Cust_job_position_TBx.Text = ctm.Cust_Job_position;
                Cust_job_long_TBx.Text = ctm.Cust_Job_long.ToString();
                Cust_job_local_name_TBx.Text = ctm.Cust_Job_local_name;
                Cust_job_address_no_TBx.Text = ctm.Cust_Job_address_no;
                Cust_job_vilage_TBx.Text = ctm.Cust_Job_vilage.IndexOf('.') >= 1 ? ctm.Cust_Job_vilage.Split('.')[1] : "";
                Cust_job_vilage_no_TBx.Text = ctm.Cust_Job_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Job_vilage_no.Split('.')[1] : "";
                Cust_job_alley_TBx.Text = ctm.Cust_Job_alley.IndexOf('.') >= 1 ? ctm.Cust_Job_alley.Split('.')[1] : "";
                Cust_job_road_TBx.Text = ctm.Cust_Job_road.IndexOf('.') >= 1 ? ctm.Cust_Job_road.Split('.')[1] : "";
                Cust_job_subdistrict_TBx.Text = ctm.Cust_Job_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Job_subdistrict.Split('.')[1] : "";
                Cust_job_district_TBx.Text = ctm.Cust_Job_district.IndexOf('.') >= 1 ? ctm.Cust_Job_district.Split('.')[1] : "";
                Cust_job_province_DDL.SelectedValue = ctm.Cust_Job_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Job_province.Split('.')[1]) : "";
                Cust_job_contry_TBx.Text = ctm.Cust_Job_country;
                Cust_job_zipcode_TBx.Text = ctm.Cust_Job_zipcode;
                Cust_job_tel_TBx.Text = ctm.Cust_Job_tel;
                Cust_job_email_TBx.Text = ctm.Cust_Job_email;
                Cust_job_salary_TBx.Text = ctm.Cust_Job_salary.ToString();
                Cust_status_DDL.SelectedValue = ctm.ctm_pstt.person_status_id.ToString();

                if (ctm.ctm_pstt.person_status_id == 2 || ctm.ctm_pstt.person_status_id == 3)
                {
                    Marry_Panel.Visible = true;

                    Marry_idcard_TBx.Text = ctm.Cust_Marry_idcard;
                    Marry_Fname_TBx.Text = ctm.Cust_Marry_Fname;
                    Marry_Lname_TBx.Text = ctm.Cust_Marry_Lname;
                    Marry_Nationality_DDL.SelectedValue = ctm.ctm_marry_ntnlt.Nationality_id.ToString();
                    Marry_Origin_DDL.SelectedValue = ctm.ctm_marry_org.Origin_id.ToString();
                    Marry_address_no_TBx.Text = ctm.Cust_Marry_Address_no;
                    Marry_vilage_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_vilage) ? "" : ctm.Cust_Marry_vilage.IndexOf('.') >= 1 ? ctm.Cust_Marry_vilage.Split('.')[1] : "";
                    Marry_vilage_no_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_vilage_no) ? "" : ctm.Cust_Marry_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Marry_vilage_no.Split('.')[1] : "";
                    Marry_alley_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_alley) ? "" : ctm.Cust_Marry_alley.IndexOf('.') >= 1 ? ctm.Cust_Marry_alley.Split('.')[1] : "";
                    Marry_road_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_road) ? "" : ctm.Cust_Marry_road.IndexOf('.') >= 1 ? ctm.Cust_Marry_road.Split('.')[1] : "";
                    Marry_subdistrict_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_subdistrict) ? "" : ctm.Cust_Marry_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Marry_subdistrict.Split('.')[1] : "";
                    Marry_district_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_district) ? "" : ctm.Cust_Marry_district.IndexOf('.') >= 1 ? ctm.Cust_Marry_district.Split('.')[1] : "";
                    Marry_province_DDL.SelectedValue = string.IsNullOrEmpty(ctm.Cust_Marry_province) ? "" : ctm.Cust_Marry_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Marry_province.Split('.')[1]) : "";
                    Marry_country_TBx.Text = ctm.Cust_Marry_country;
                    Marry_zipcode_TBx.Text = ctm.Cust_Marry_zipcode;
                    Marry_job_TBx.Text = ctm.Cust_Marry_job;
                    Marry_job_position_TBx.Text = ctm.Cust_Marry_job_position;
                    Marry_job_long_TBx.Text = ctm.Cust_Marry_job_long.ToString();
                    Marry_job_salary_TBx.Text = ctm.Cust_Marry_job_salary.ToString();
                    Marry_job_local_name_TBx.Text = ctm.Cust_Marry_job_local_name;
                    Marry_job_address_no_TBx.Text = ctm.Cust_Marry_job_address_no;
                    Marry_job_vilage_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_vilage) ? "" : ctm.Cust_Marry_job_vilage.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_vilage.Split('.')[1] : "";
                    Marry_job_vilage_no_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_vilage_no) ? "" : ctm.Cust_Marry_job_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_vilage_no.Split('.')[1] : "";
                    Marry_job_alley_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_alley) ? "" : ctm.Cust_Marry_job_alley.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_alley.Split('.')[1] : "";
                    Marry_job_road_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_road) ? "" : ctm.Cust_Marry_job_road.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_road.Split('.')[1] : "";
                    Marry_job_subdistrict_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_subdistrict) ? "" : ctm.Cust_Marry_job_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_subdistrict.Split('.')[1] : "";
                    Marry_job_district_TBx.Text = string.IsNullOrEmpty(ctm.Cust_Marry_job_district) ? "" : ctm.Cust_Marry_job_district.IndexOf('.') >= 1 ? ctm.Cust_Marry_job_district.Split('.')[1] : "";
                    Marry_job_province_DDL.SelectedValue = string.IsNullOrEmpty(ctm.Cust_Marry_job_province) ? "" : ctm.Cust_Marry_job_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Marry_job_province.Split('.')[1]) : "";
                    Marry_job_country_TBx.Text = ctm.Cust_Marry_job_country;
                    Marry_job_zipcode_TBx.Text = ctm.Cust_Marry_job_zipcode;
                    Marry_job_tel_TBx.Text = ctm.Cust_Marry_job_tel;
                    Marry_tel_TBx.Text = ctm.Cust_Marry_tel;
                    Marry_email_TBx.Text = ctm.Cust_Marry_email;
                }

                // ที่อยู่ตามทะเบียนบ้าน
                Home_Cust_Address_no_TBx.Text = ctm.Cust_Home_address_no;
                Home_Cust_Vilage_TBx.Text = ctm.Cust_Home_vilage.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage.Split('.')[1] : "";
                Home_Cust_Vilage_no_TBx.Text = ctm.Cust_Home_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Home_vilage_no.Split('.')[1] : "";
                Home_Cust_Alley_TBx.Text = ctm.Cust_Home_alley.IndexOf('.') >= 1 ? ctm.Cust_Home_alley.Split('.')[1] : "";
                Home_Cust_Road_TBx.Text = ctm.Cust_Home_road.IndexOf('.') >= 1 ? ctm.Cust_Home_road.Split('.')[1] : "";
                Home_Cust_Subdistrict_TBx.Text = ctm.Cust_Home_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Home_subdistrict.Split('.')[1] : "";
                Home_Cust_District_TBx.Text = ctm.Cust_Home_district.IndexOf('.') >= 1 ? ctm.Cust_Home_district.Split('.')[1] : "";
                Home_Cust_Province_DDL.SelectedValue = ctm.Cust_Home_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Home_province.Split('.')[1]) : "";
                Home_Cust_Country_TBx.Text = ctm.Cust_Home_country;
                Home_Cust_Zipcode_TBx.Text = ctm.Cust_Home_zipcode;
                Home_Cust_Tel_TBx.Text = ctm.Cust_Home_tel;
                Home_Cust_Home_status_id_DDL.SelectedValue = ctm.ctm_home_stt.Home_status_id.ToString();
                Home_Cust_Gps_Latitude_TBx.Text = ctm.Cust_Home_GPS_Latitude;
                Home_Cust_Gps_Longitude_TBx.Text = ctm.Cust_Home_GPS_Longitude;

                // ที่อยู่ตามบัตรประชาชน
                Idcard_Cust_Address_no_TBx.Text = ctm.Cust_Idcard_address_no;
                Idcard_Cust_Vilage_TBx.Text = ctm.Cust_Idcard_vilage.IndexOf('.') >= 1 ? ctm.Cust_Idcard_vilage.Split('.')[1] : "";
                Idcard_Cust_Vilage_no_TBx.Text = ctm.Cust_Idcard_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Idcard_vilage_no.Split('.')[1] : "";
                Idcard_Cust_Alley_TBx.Text = ctm.Cust_Idcard_alley.IndexOf('.') >= 1 ? ctm.Cust_Idcard_alley.Split('.')[1] : "";
                Idcard_Cust_Road_TBx.Text = ctm.Cust_Idcard_road.IndexOf('.') >= 1 ? ctm.Cust_Idcard_road.Split('.')[1] : "";
                Idcard_Cust_Subdistrict_TBx.Text = ctm.Cust_Idcard_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Idcard_subdistrict.Split('.')[1] : "";
                Idcard_Cust_District_TBx.Text = ctm.Cust_Idcard_district.IndexOf('.') >= 1 ? ctm.Cust_Idcard_district.Split('.')[1] : "";
                Idcard_Cust_Province_DDL.SelectedValue = ctm.Cust_Idcard_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Idcard_province.Split('.')[1]) : "";
                Idcard_Cust_Country_TBx.Text = ctm.Cust_Idcard_country;
                Idcard_Cust_Zipcode_TBx.Text = ctm.Cust_Idcard_zipcode;
                Idcard_Cust_Tel_TBx.Text = ctm.Cust_Idcard_tel;
                Idcard_Cust_Home_status_DDL.SelectedValue = ctm.ctm_idcard_stt.Home_status_id.ToString();

                // ที่อยู่ปัจจุบัน
                Current_Cust_Address_no_TBx.Text = ctm.Cust_Current_address_no;
                Current_Cust_Vilage_TBx.Text = ctm.Cust_Current_vilage.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage.Split('.')[1] : "";
                Current_Cust_Vilage_no_TBx.Text = ctm.Cust_Current_vilage_no.IndexOf('.') >= 1 ? ctm.Cust_Current_vilage_no.Split('.')[1] : "";
                Current_Cust_Road_TBx.Text = ctm.Cust_Current_road.IndexOf('.') >= 1 ? ctm.Cust_Current_road.Split('.')[1] : "";
                Current_Cust_Subdistrict_TBx.Text = ctm.Cust_Current_subdistrict.IndexOf('.') >= 1 ? ctm.Cust_Current_subdistrict.Split('.')[1] : "";
                Current_Cust_District_TBx.Text = ctm.Cust_Current_district.IndexOf('.') >= 1 ? ctm.Cust_Current_district.Split('.')[1] : "";
                Current_Cust_Province_DDL.SelectedValue = ctm.Cust_Current_province.IndexOf('.') >= 1 ? Thai_Province._getThaiProvinces(ctm.Cust_Current_province.Split('.')[1]) : "";
                Current_Cust_Country_TBx.Text = ctm.Cust_Current_country;
                Current_Cust_Zipcode_TBx.Text = ctm.Cust_Current_zipcode;
                Current_Cust_Tel_TBx.Text = ctm.Cust_Current_tel;
                Current_Cust_Home_status_id_DDL.SelectedValue = ctm.ctm_current_stt.Home_status_id.ToString();
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Copy Data Function                   ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // copy ข้อมูลที่อยู่แยกตามประเภท
        private void _CopyBaseDataAddress(int type)
        {
            if (type == 1) // copy ที่อยู่ตามทะเบียนบ้าน to ที่อยู่ตามบัตรประชาชน
            {
                Idcard_Cust_Address_no_TBx.Text = Home_Cust_Address_no_TBx.Text;
                Idcard_Cust_Vilage_TBx.Text = Home_Cust_Vilage_TBx.Text;
                Idcard_Cust_Vilage_no_TBx.Text = Home_Cust_Vilage_no_TBx.Text;
                Idcard_Cust_Alley_TBx.Text = Home_Cust_Alley_TBx.Text;
                Idcard_Cust_Road_TBx.Text = Home_Cust_Road_TBx.Text;
                Idcard_Cust_Subdistrict_TBx.Text = Home_Cust_Subdistrict_TBx.Text;
                Idcard_Cust_District_TBx.Text = Home_Cust_District_TBx.Text;
                Idcard_Cust_Province_DDL.SelectedIndex = Home_Cust_Province_DDL.SelectedIndex;
                Idcard_Cust_Country_TBx.Text = Home_Cust_Country_TBx.Text;
                Idcard_Cust_Zipcode_TBx.Text = Home_Cust_Zipcode_TBx.Text;
                Idcard_Cust_Tel_TBx.Text = Home_Cust_Tel_TBx.Text;
                Idcard_Cust_Home_status_DDL.SelectedIndex = Home_Cust_Home_status_id_DDL.SelectedIndex;

                Idcard_Cust_Address_no_TBx.Focus();
            }
            else if (type == 2) // copy ที่อยู่ตามบัตรประชาชน to ที่อยู่ปัจจุบัน
            {
                Current_Cust_Address_no_TBx.Text = Idcard_Cust_Address_no_TBx.Text;
                Current_Cust_Vilage_TBx.Text = Idcard_Cust_Vilage_TBx.Text;
                Current_Cust_Vilage_no_TBx.Text = Idcard_Cust_Vilage_no_TBx.Text;
                Current_Cust_Alley_TBx.Text = Idcard_Cust_Alley_TBx.Text;
                Current_Cust_Road_TBx.Text = Idcard_Cust_Road_TBx.Text;
                Current_Cust_Subdistrict_TBx.Text = Idcard_Cust_Subdistrict_TBx.Text;
                Current_Cust_District_TBx.Text = Idcard_Cust_District_TBx.Text;
                Current_Cust_Province_DDL.SelectedIndex = Idcard_Cust_Province_DDL.SelectedIndex;
                Current_Cust_Country_TBx.Text = Idcard_Cust_Country_TBx.Text;
                Current_Cust_Zipcode_TBx.Text = Idcard_Cust_Zipcode_TBx.Text;
                Current_Cust_Tel_TBx.Text = Idcard_Cust_Tel_TBx.Text;
                Current_Cust_Home_status_id_DDL.SelectedIndex = Idcard_Cust_Home_status_DDL.SelectedIndex;

                Cust_job_TBx.Focus();
            }
            else if (type == 3) // copy ที่อยู่ตามทะเบียนบ้าน to ที่อยู่ปัจจุบัน
            {
                Current_Cust_Address_no_TBx.Text = Home_Cust_Address_no_TBx.Text;
                Current_Cust_Vilage_TBx.Text = Home_Cust_Vilage_TBx.Text;
                Current_Cust_Vilage_no_TBx.Text = Home_Cust_Vilage_no_TBx.Text;
                Current_Cust_Alley_TBx.Text = Home_Cust_Alley_TBx.Text;
                Current_Cust_Road_TBx.Text = Home_Cust_Road_TBx.Text;
                Current_Cust_Subdistrict_TBx.Text = Home_Cust_Subdistrict_TBx.Text;
                Current_Cust_District_TBx.Text = Home_Cust_District_TBx.Text;
                Current_Cust_Province_DDL.SelectedIndex = Home_Cust_Province_DDL.SelectedIndex;
                Current_Cust_Country_TBx.Text = Home_Cust_Country_TBx.Text;
                Current_Cust_Zipcode_TBx.Text = Home_Cust_Zipcode_TBx.Text;
                Current_Cust_Tel_TBx.Text = Home_Cust_Tel_TBx.Text;
                Current_Cust_Home_status_id_DDL.SelectedIndex = Home_Cust_Home_status_id_DDL.SelectedIndex;

                Cust_job_TBx.Focus();
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Edit Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _EditCustomer()
        {
            Customers_Manager ctm_mng = new Customers_Manager();
            Customers ctm = new Customers();

            Customers ctm_tmp = (Customers)Session["Customer_Leasing"];
            Car_Leasings cls = (Car_Leasings)Session["Leasings"];

            ctm.Cust_id = ctm_tmp == null? ctm_mng.generateCustomerID() : ctm_tmp.Cust_id;
            ctm.Cust_Idcard = string.IsNullOrEmpty(Cust_idcard_TBx.Text) ? "" : Cust_idcard_TBx.Text;
            ctm.Cust_Fname = string.IsNullOrEmpty(Cust_Fname_TBx.Text) ? "" : Cust_Fname_TBx.Text;
            ctm.Cust_LName = string.IsNullOrEmpty(Cust_LName_TBx.Text) ? "" : Cust_LName_TBx.Text;
            ctm.Cust_B_date = string.IsNullOrEmpty(Cust_B_date_TBx.Text) ? null : DateTimeUtility.convertDateToMYSQL(Cust_B_date_TBx.Text);
            ctm.Cust_Age = string.IsNullOrEmpty(Cust_B_date_TBx.Text) ? 0 : DateTime.Now.Year - (Convert.ToInt32(Cust_B_date_TBx.Text.Split('/')[2].ToString()) - 543);
            ctm.Cust_Idcard_without = string.IsNullOrEmpty(Cust_Idcard_without_TBx.Text) ? "" : Cust_Idcard_without_TBx.Text;
            ctm.Cust_Idcard_start = string.IsNullOrEmpty(Cust_Idcard_start_TBx.Text) ? null : DateTimeUtility.convertDateToMYSQL(Cust_Idcard_start_TBx.Text);
            ctm.Cust_Idcard_expire = string.IsNullOrEmpty(Cust_Idcard_expire_TBx.Text) ? null : DateTimeUtility.convertDateToMYSQL(Cust_Idcard_expire_TBx.Text);

            ctm.ctm_ntnlt = new Base_Nationalitys();
            ctm.ctm_ntnlt.Nationality_id = Cust_Nationality_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Cust_Nationality_DDL.SelectedValue);

            ctm.ctm_org = new Base_Origins();
            ctm.ctm_org.Origin_id = Cust_Origin_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Cust_Origin_DDL.SelectedValue);

            ctm.Cust_Tel = string.IsNullOrEmpty(Cust_Tel_TBx.Text) ? "" : Cust_Tel_TBx.Text;
            ctm.Cust_Email = string.IsNullOrEmpty(Cust_Email_TBx.Text) ? "" : Cust_Email_TBx.Text;
            ctm.Cust_Job = string.IsNullOrEmpty(Cust_job_TBx.Text) ? "" : Cust_job_TBx.Text;
            ctm.Cust_Job_position = string.IsNullOrEmpty(Cust_job_position_TBx.Text) ? "" : Cust_job_position_TBx.Text;
            ctm.Cust_Job_long = string.IsNullOrEmpty(Cust_job_long_TBx.Text) ? 0 : Convert.ToInt32(Cust_job_long_TBx.Text);
            ctm.Cust_Job_local_name = string.IsNullOrEmpty(Cust_job_local_name_TBx.Text) ? "" : Cust_job_local_name_TBx.Text;
            ctm.Cust_Job_address_no = string.IsNullOrEmpty(Cust_job_address_no_TBx.Text) ? "" : Cust_job_address_no_TBx.Text;
            ctm.Cust_Job_vilage = string.IsNullOrEmpty(Cust_job_vilage_TBx.Text) ? "บ.-" : "บ." + Cust_job_vilage_TBx.Text;
            ctm.Cust_Job_vilage_no = string.IsNullOrEmpty(Cust_job_vilage_no_TBx.Text) ? "ม.-." : "ม." + Cust_job_vilage_no_TBx.Text;
            ctm.Cust_Job_alley = string.IsNullOrEmpty(Cust_job_alley_TBx.Text) ? "ซ.-" : "ซ." + Cust_job_alley_TBx.Text;
            ctm.Cust_Job_road = string.IsNullOrEmpty(Cust_job_road_TBx.Text) ? "ถ.-" : "ถ." + Cust_job_road_TBx.Text;
            ctm.Cust_Job_subdistrict = string.IsNullOrEmpty(Cust_job_subdistrict_TBx.Text) ? "ต.-" : "ต." + Cust_job_subdistrict_TBx.Text;
            ctm.Cust_Job_district = string.IsNullOrEmpty(Cust_job_district_TBx.Text) ? "อ.-" : "อ." + Cust_job_district_TBx.Text;
            ctm.Cust_Job_province = Cust_job_province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Cust_job_province_DDL.SelectedItem.Text;
            ctm.Cust_Job_country = string.IsNullOrEmpty(Cust_job_contry_TBx.Text) ? "" : Cust_job_contry_TBx.Text;
            ctm.Cust_Job_zipcode = string.IsNullOrEmpty(Cust_job_zipcode_TBx.Text) ? "" : Cust_job_zipcode_TBx.Text;
            ctm.Cust_Job_tel = string.IsNullOrEmpty(Cust_job_tel_TBx.Text) ? "" : Cust_job_tel_TBx.Text;
            ctm.Cust_Job_email = string.IsNullOrEmpty(Cust_job_email_TBx.Text) ? "" : Cust_job_email_TBx.Text;
            ctm.Cust_Job_salary = string.IsNullOrEmpty(Cust_job_salary_TBx.Text) ? 0 : Convert.ToDouble(Cust_job_salary_TBx.Text);

            ctm.ctm_pstt = new Base_Person_Status();
            ctm.ctm_pstt.person_status_id = Cust_status_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Cust_status_DDL.SelectedValue);

            ctm.Cust_Marry_idcard = string.IsNullOrEmpty(Marry_idcard_TBx.Text) ? "" : Marry_idcard_TBx.Text;
            ctm.Cust_Marry_Fname = string.IsNullOrEmpty(Marry_Fname_TBx.Text) ? "" : Marry_Fname_TBx.Text;
            ctm.Cust_Marry_Lname = string.IsNullOrEmpty(Marry_Lname_TBx.Text) ? "" : Marry_Lname_TBx.Text;

            ctm.ctm_marry_ntnlt = new Base_Nationalitys();
            ctm.ctm_marry_ntnlt.Nationality_id = Marry_Nationality_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Marry_Nationality_DDL.SelectedValue);

            ctm.ctm_marry_org = new Base_Origins();
            ctm.ctm_marry_org.Origin_id = Marry_Origin_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Marry_Origin_DDL.SelectedValue);

            ctm.Cust_Marry_Address_no = string.IsNullOrEmpty(Marry_address_no_TBx.Text) ? "" : Marry_address_no_TBx.Text;
            ctm.Cust_Marry_vilage = string.IsNullOrEmpty(Marry_vilage_TBx.Text) ? "บ.-" : "บ." + Marry_vilage_TBx.Text;
            ctm.Cust_Marry_vilage_no = string.IsNullOrEmpty(Marry_vilage_no_TBx.Text) ? "ม.-" : "ม." + Marry_vilage_no_TBx.Text;
            ctm.Cust_Marry_alley = string.IsNullOrEmpty(Marry_alley_TBx.Text) ? "ซ.-" : "ซ." + Marry_alley_TBx.Text;
            ctm.Cust_Marry_road = string.IsNullOrEmpty(Marry_road_TBx.Text) ? "ถ.-" : "ถ." + Marry_road_TBx.Text;
            ctm.Cust_Marry_subdistrict = string.IsNullOrEmpty(Marry_subdistrict_TBx.Text) ? "ต.-" : "ต." + Marry_subdistrict_TBx.Text;
            ctm.Cust_Marry_district = string.IsNullOrEmpty(Marry_district_TBx.Text) ? "อ.-" : "อ." + Marry_district_TBx.Text;
            ctm.Cust_Marry_province = Marry_province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Marry_province_DDL.SelectedItem.Text;
            ctm.Cust_Marry_country = string.IsNullOrEmpty(Marry_country_TBx.Text) ? "" : Marry_country_TBx.Text;
            ctm.Cust_Marry_zipcode = string.IsNullOrEmpty(Marry_zipcode_TBx.Text) ? "" : Marry_zipcode_TBx.Text;

            ctm.Cust_Marry_job = string.IsNullOrEmpty(Marry_job_TBx.Text) ? "" : Marry_job_TBx.Text;
            ctm.Cust_Marry_job_position = string.IsNullOrEmpty(Marry_job_position_TBx.Text) ? "" : Marry_job_position_TBx.Text;
            ctm.Cust_Marry_job_long = string.IsNullOrEmpty(Marry_job_long_TBx.Text) ? 0 : Convert.ToInt32(Marry_job_long_TBx.Text);
            ctm.Cust_Marry_job_salary = string.IsNullOrEmpty(Marry_job_salary_TBx.Text) ? 0 : Convert.ToDouble(Marry_job_salary_TBx.Text);
            ctm.Cust_Marry_job_local_name = string.IsNullOrEmpty(Marry_job_local_name_TBx.Text) ? "" : Marry_job_local_name_TBx.Text;
            ctm.Cust_Marry_job_address_no = string.IsNullOrEmpty(Marry_job_address_no_TBx.Text) ? "" : Marry_job_address_no_TBx.Text;
            ctm.Cust_Marry_job_vilage = string.IsNullOrEmpty(Marry_job_vilage_TBx.Text) ? "บ.-" : "บ." + Marry_job_vilage_TBx.Text;
            ctm.Cust_Marry_job_vilage_no = string.IsNullOrEmpty(Marry_job_vilage_no_TBx.Text) ? "ม.-" : "ม." + Marry_job_vilage_no_TBx.Text;
            ctm.Cust_Marry_job_alley = string.IsNullOrEmpty(Marry_job_alley_TBx.Text) ? "ซ.-" : "ซ." + Marry_job_alley_TBx.Text;
            ctm.Cust_Marry_job_road = string.IsNullOrEmpty(Marry_job_road_TBx.Text) ? "ถ.-" : "ถ." + Marry_job_road_TBx.Text;
            ctm.Cust_Marry_job_subdistrict = string.IsNullOrEmpty(Marry_job_subdistrict_TBx.Text) ? "ต.-" : "ต." + Marry_job_subdistrict_TBx.Text;
            ctm.Cust_Marry_job_district = string.IsNullOrEmpty(Marry_job_district_TBx.Text) ? "อ.-" : "อ." + Marry_job_district_TBx.Text;
            ctm.Cust_Marry_job_province = Marry_job_province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Marry_job_province_DDL.SelectedItem.Text;
            ctm.Cust_Marry_job_country = string.IsNullOrEmpty(Marry_job_country_TBx.Text) ? "" : Marry_job_country_TBx.Text;
            ctm.Cust_Marry_job_zipcode = string.IsNullOrEmpty(Marry_job_zipcode_TBx.Text) ? "" : Marry_job_zipcode_TBx.Text;
            ctm.Cust_Marry_job_tel = string.IsNullOrEmpty(Marry_job_tel_TBx.Text) ? "" : Marry_job_tel_TBx.Text;
            ctm.Cust_Marry_tel = string.IsNullOrEmpty(Marry_tel_TBx.Text) ? "" : Marry_tel_TBx.Text;
            ctm.Cust_Marry_email = string.IsNullOrEmpty(Marry_email_TBx.Text) ? "" : Marry_email_TBx.Text;

            ctm.Cust_Home_address_no = string.IsNullOrEmpty(Home_Cust_Address_no_TBx.Text) ? "" : Home_Cust_Address_no_TBx.Text;
            ctm.Cust_Home_vilage = string.IsNullOrEmpty(Home_Cust_Vilage_TBx.Text) ? "บ.-" : "บ." + Home_Cust_Vilage_TBx.Text;
            ctm.Cust_Home_vilage_no = string.IsNullOrEmpty(Home_Cust_Vilage_no_TBx.Text) ? "ม.-" : "ม." + Home_Cust_Vilage_no_TBx.Text;
            ctm.Cust_Home_alley = string.IsNullOrEmpty(Home_Cust_Alley_TBx.Text) ? "ซ.-" : "ซ." + Home_Cust_Alley_TBx.Text;
            ctm.Cust_Home_road = string.IsNullOrEmpty(Home_Cust_Road_TBx.Text) ? "ถ.-" : "ถ." + Home_Cust_Road_TBx.Text;
            ctm.Cust_Home_subdistrict = string.IsNullOrEmpty(Home_Cust_Subdistrict_TBx.Text) ? "ต.-" : "ต." + Home_Cust_Subdistrict_TBx.Text;
            ctm.Cust_Home_district = string.IsNullOrEmpty(Home_Cust_District_TBx.Text) ? "อ.-" : "อ." + Home_Cust_District_TBx.Text;
            ctm.Cust_Home_province = Home_Cust_Province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Home_Cust_Province_DDL.SelectedItem.Text;
            ctm.Cust_Home_country = string.IsNullOrEmpty(Home_Cust_Country_TBx.Text) ? "" : Home_Cust_Country_TBx.Text;
            ctm.Cust_Home_zipcode = string.IsNullOrEmpty(Home_Cust_Zipcode_TBx.Text) ? "" : Home_Cust_Zipcode_TBx.Text;
            ctm.Cust_Home_tel = string.IsNullOrEmpty(Home_Cust_Tel_TBx.Text) ? "" : Home_Cust_Tel_TBx.Text;

            ctm.ctm_home_stt = new Base_Home_Status();
            ctm.ctm_home_stt.Home_status_id = Home_Cust_Home_status_id_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Home_Cust_Home_status_id_DDL.SelectedValue);

            ctm.Cust_Home_GPS_Latitude = string.IsNullOrEmpty(Home_Cust_Gps_Latitude_TBx.Text) ? "" : Home_Cust_Gps_Latitude_TBx.Text;
            ctm.Cust_Home_GPS_Longitude = string.IsNullOrEmpty(Home_Cust_Gps_Longitude_TBx.Text) ? "" : Home_Cust_Gps_Longitude_TBx.Text;

            ctm.Cust_Idcard_address_no = string.IsNullOrEmpty(Idcard_Cust_Address_no_TBx.Text) ? "" : Idcard_Cust_Address_no_TBx.Text;
            ctm.Cust_Idcard_vilage = string.IsNullOrEmpty(Idcard_Cust_Vilage_TBx.Text) ? "บ.-" : "บ." + Idcard_Cust_Vilage_TBx.Text;
            ctm.Cust_Idcard_vilage_no = string.IsNullOrEmpty(Idcard_Cust_Vilage_no_TBx.Text) ? "ม.-" : "ม." + Idcard_Cust_Vilage_no_TBx.Text;
            ctm.Cust_Idcard_alley = string.IsNullOrEmpty(Idcard_Cust_Alley_TBx.Text) ? "ซ.-" : "ซ." + Idcard_Cust_Alley_TBx.Text;
            ctm.Cust_Idcard_road = string.IsNullOrEmpty(Idcard_Cust_Road_TBx.Text) ? "ถ.-" : "ถ." + Idcard_Cust_Road_TBx.Text;
            ctm.Cust_Idcard_subdistrict = string.IsNullOrEmpty(Idcard_Cust_Subdistrict_TBx.Text) ? "ต.-" : "ต." + Idcard_Cust_Subdistrict_TBx.Text;
            ctm.Cust_Idcard_district = string.IsNullOrEmpty(Idcard_Cust_District_TBx.Text) ? "อ.-" : "อ." + Idcard_Cust_District_TBx.Text;
            ctm.Cust_Idcard_province = Idcard_Cust_Province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Idcard_Cust_Province_DDL.SelectedItem.Text;
            ctm.Cust_Idcard_country = string.IsNullOrEmpty(Idcard_Cust_Country_TBx.Text) ? "" : Idcard_Cust_Country_TBx.Text;
            ctm.Cust_Idcard_zipcode = string.IsNullOrEmpty(Idcard_Cust_Zipcode_TBx.Text) ? "" : Idcard_Cust_Zipcode_TBx.Text;
            ctm.Cust_Idcard_tel = string.IsNullOrEmpty(Idcard_Cust_Tel_TBx.Text) ? "" : Idcard_Cust_Tel_TBx.Text;

            ctm.ctm_idcard_stt = new Base_Home_Status();
            ctm.ctm_idcard_stt.Home_status_id = Idcard_Cust_Home_status_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Idcard_Cust_Home_status_DDL.SelectedValue);

            ctm.Cust_Current_address_no = string.IsNullOrEmpty(Current_Cust_Address_no_TBx.Text) ? "" : Current_Cust_Address_no_TBx.Text;
            ctm.Cust_Current_vilage = string.IsNullOrEmpty(Current_Cust_Vilage_TBx.Text) ? "บ.-" : "บ." + Current_Cust_Vilage_TBx.Text;
            ctm.Cust_Current_vilage_no = string.IsNullOrEmpty(Current_Cust_Vilage_no_TBx.Text) ? "ม.-" : "ม." + Current_Cust_Vilage_no_TBx.Text;
            ctm.Cust_Current_alley = string.IsNullOrEmpty(Current_Cust_Alley_TBx.Text) ? "ซ.-" : "ซ." + Current_Cust_Alley_TBx.Text;
            ctm.Cust_Current_road = string.IsNullOrEmpty(Current_Cust_Road_TBx.Text) ? "ถ.-" : "ถ." + Current_Cust_Road_TBx.Text;
            ctm.Cust_Current_subdistrict = string.IsNullOrEmpty(Current_Cust_Subdistrict_TBx.Text) ? "ต.-" : "ต." + Current_Cust_Subdistrict_TBx.Text;
            ctm.Cust_Current_district = string.IsNullOrEmpty(Current_Cust_District_TBx.Text) ? "อ.-" : "อ." + Current_Cust_District_TBx.Text;
            ctm.Cust_Current_province = Current_Cust_Province_DDL.SelectedIndex <= 0 ? "จ.-" : "จ." + Current_Cust_Province_DDL.SelectedItem.Text;
            ctm.Cust_Current_country = string.IsNullOrEmpty(Current_Cust_Country_TBx.Text) ? "" : Current_Cust_Country_TBx.Text;
            ctm.Cust_Current_zipcode = string.IsNullOrEmpty(Current_Cust_Zipcode_TBx.Text) ? "" : Current_Cust_Zipcode_TBx.Text;
            ctm.Cust_Current_tel = string.IsNullOrEmpty(Current_Cust_Tel_TBx.Text) ? "" : Current_Cust_Tel_TBx.Text;

            ctm.ctm_current_stt = new Base_Home_Status();
            ctm.ctm_current_stt.Home_status_id = Current_Cust_Home_status_id_DDL.SelectedIndex <= 0 ? 1 : Convert.ToInt32(Current_Cust_Home_status_id_DDL.SelectedValue);

            if (ctm_tmp == null) { ctm_mng.addCustomers(ctm); } else { ctm_mng.editCustomers(ctm); }

            if (ctm_tmp == null) { cls_ctm_mng.addCustomersLeasing(cls, ctm); } else { cls_ctm_mng.editCustomersLeasing(cls, ctm); }
            

            Session["Customer_Leasing"] = ctm;

            /// Acticity Logs System
            ///  

            package_login = (Base_Companys)Session["Package"];
            acc_lgn = (Account_Login)Session["Login"];

            string message = Messages_Logs._messageLogsNormal(acc_lgn.Account_F_name, " แก้ไขข้อมูลผู้ทำสัญญาเช่า-ซื้อ ในสัญญา : " + cls.Leasing_no + " เลขที่ฝาก : " + cls.Deps_no, acc_lgn.resu, package_login.Company_N_name);

            new Activity_Log_Manager().addActivityLogs(message, acc_lgn.Account_id, package_login.Company_id);

            /// Acticity Logs System
        }
    }
}