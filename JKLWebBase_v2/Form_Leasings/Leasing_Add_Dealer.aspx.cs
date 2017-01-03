using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Dealers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Dealers;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Add_Dealer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadThaiProvinces();
                _loadDealerStatus();
            }

            if (Session["Leasings"] == null)
            {
                Session["Class_Active"] = 2;
                Response.Redirect("/Form_Leasings/Leasing_Add");
            }
        }

        protected void Dealer_idcard_TBx_TextChanged(object sender, EventArgs e)
        {
            _CheckDealer();
        }

        protected void Dealer_search_Btn_Click(object sender, EventArgs e)
        {
            _CheckDealer();
        }

        protected void Dealer_percen_TBx_TextChanged(object sender, EventArgs e)
        {
            _CalculatedCommission();
        }

        protected void Dealer_Add_Save_Btn_Click(object sender, EventArgs e)
        {
            if (Session["chk_Dealser"] == null)
            {
                _AddDealer();
            }
            else
            {
                Car_Leasings cls_tmp = (Car_Leasings)Session["Leasings"];
                Dealers cdl_tmp = (Dealers)Session["chk_Dealser"];

                _AddDealer_Value(cdl_tmp.Dealer_id, cls_tmp.Leasing_id);
            }

            Session["Class_Active"] = 4;

            Session["Number_Of_Bondsman"] = "1";

            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadThaiProvinces()
        {
            List<TH_Provinces> list_data = new TH_Provinces_Manager().getProvinces();
            Dealer_province_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                TH_Provinces data = list_data[i];
                Dealer_province_DDL.Items.Add(new ListItem(data.Province_name, data.Province_id.ToString()));
            }
            Dealer_province_DDL.SelectedValue = "39";
        }

        // ประเภทนายหน้า
        private void _loadDealerStatus()
        {
            Dealer_status_DDL.Items.Add(new ListItem("บุคคลธรรมดา", "0"));
            Dealer_status_DDL.Items.Add(new ListItem("นิติบุคคล", "1"));
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Calculate   Function                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // คำนวนค่านายหน้า
        private void _CalculatedCommission()
        {
            if (!String.IsNullOrEmpty(Dealer_commission_TBx.Text) && !String.IsNullOrEmpty(Dealer_percen_TBx.Text))
            {
                double commission = Convert.ToDouble(Dealer_commission_TBx.Text); // ค่านายหน้า
                double percen = Convert.ToDouble(Dealer_percen_TBx.Text) / 100; // % หัก ณ ที่จ่าย
                double loss_com = commission * percen; // ค่าหัก ณ ที่จ่าย

                Dealer_cash_TBx.Text = loss_com.ToString("#,##0.00"); // ค่าหัก ณ ที่จ่าย
                Dealer_net_com_TBx.Text = (commission - loss_com).ToString("#,##0.00"); // ค่านายหน้าสุทธิ
            }
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckDealer()
        {
            Dealers cdl = new Dealers_Manager().getDealerByIdCard(Dealer_idcard_TBx.Text);
            Customers ctm = (Customers)Session["Customer_Leasing"];

            if (ctm.Cust_idcard == Dealer_idcard_TBx.Text)
            {
                Alert_Danger_Panel.Visible = true;
                alert_header_danger_Lbl.Text = "เลขบัตรประชาชนซ้ำ";
                alert_danger_Lbl.Text = "เลขบัตรประชาชน " + Dealer_idcard_TBx.Text + " ของนายหน้านี้ ไม่สามารถใช้งานได้ เนื่องจากตรงกับผู้ทำสัญญา";

                Dealer_Add_Save_Btn.Visible = false;
            }
            else
            {
                Alert_Danger_Panel.Visible = false;
                Dealer_Add_Save_Btn.Visible = true;

                if (cdl.Dealer_id != null)
                {
                    _GetDealer(cdl);

                    Session["chk_Dealser"] = cdl;

                    Alert_Warning_Panel.Visible = false;
                }
                else
                {
                    Alert_Danger_Panel.Visible = false;
                    Alert_Id_Card_Lbl.Text = "ไม่พบเลขบัตรประชาชน " + Dealer_idcard_TBx.Text + " นี้ในระบบข้อมูลนายหน้า";

                    Dealer_idcard_TBx.Focus();

                    _ClearDealer();
                }
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************              Get Data And Replace To Form Function                 ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _GetDealer(Dealers cdl)
        {
            Dealer_fname_TBx.Text = cdl.Dealer_fname;
            Dealer_lname_TBx.Text = cdl.Dealer_lname;
            Dealer_idcard_TBx.Text = cdl.Dealer_idcard;
            Dealer_address_no_TBx.Text = cdl.Dealer_address_no;
            Dealer_vilage_TBx.Text = cdl.Dealer_vilage.IndexOf('.') >= 1 ? cdl.Dealer_vilage.Split('.')[1] : "";
            Dealer_vilage_no_TBx.Text = cdl.Dealer_vilage_no.IndexOf('.') >= 1 ? cdl.Dealer_vilage_no.Split('.')[1] : "";
            Dealer_alley_TBx.Text = cdl.Dealer_alley.IndexOf('.') >= 1 ? cdl.Dealer_alley.Split('.')[1] : "";
            Dealer_road_TBx.Text = cdl.Dealer_road.IndexOf('.') >= 1 ? cdl.Dealer_road.Split('.')[1] : "";
            Dealer_subdistrict_TBx.Text = cdl.Dealer_subdistrict.IndexOf('.') >= 1 ? cdl.Dealer_subdistrict.Split('.')[1] : "";
            Dealer_district_TBx.Text = cdl.Dealer_district.IndexOf('.') >= 1 ? cdl.Dealer_district.Split('.')[1] : "";
            Dealer_province_DDL.SelectedValue = cdl.Dealer_province.ToString();
            Dealer_country_TBx.Text = cdl.Dealer_country;
            Dealer_zipcode_TBx.Text = cdl.Dealer_zipcode;
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Clear Data Function                         ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _ClearDealer()
        {
            Dealer_fname_TBx.Text = "";
            Dealer_lname_TBx.Text = "";
            Dealer_idcard_TBx.Text = "";
            Dealer_address_no_TBx.Text = "";
            Dealer_vilage_TBx.Text = "";
            Dealer_vilage_no_TBx.Text = "";
            Dealer_alley_TBx.Text = "";
            Dealer_road_TBx.Text = "";
            Dealer_subdistrict_TBx.Text = "";
            Dealer_district_TBx.Text = "";
            Dealer_province_DDL.SelectedValue = "39";
            Dealer_country_TBx.Text = "ประเทศไทย";
            Dealer_zipcode_TBx.Text = "";
            Dealer_commission_TBx.Text = "";
            Dealer_percen_TBx.Text = "";
            Dealer_cash_TBx.Text = "";
            Dealer_net_com_TBx.Text = "";
            Dealer_com_code_TBx.Text = "";
            Dealer_bookcode_TBx.Text = "";
            Dealer_date_print_TBx.Text = "";
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _AddDealer()
        {
            Dealers_Manager cdl_mng = new Dealers_Manager();
            Dealers cdl = new Dealers();

            cdl.Dealer_id = cdl_mng.generateDealerID();
            cdl.Dealer_fname = string.IsNullOrEmpty(Dealer_fname_TBx.Text) ? "" : Dealer_fname_TBx.Text;
            cdl.Dealer_lname = string.IsNullOrEmpty(Dealer_lname_TBx.Text) ? "" : Dealer_lname_TBx.Text;
            cdl.Dealer_idcard = string.IsNullOrEmpty(Dealer_idcard_TBx.Text) ? "" : Dealer_idcard_TBx.Text;
            cdl.Dealer_address_no = string.IsNullOrEmpty(Dealer_address_no_TBx.Text) ? "" : Dealer_address_no_TBx.Text;
            cdl.Dealer_vilage = string.IsNullOrEmpty(Dealer_vilage_TBx.Text) ? "บ.-" : "บ." + Dealer_vilage_TBx.Text;
            cdl.Dealer_vilage_no = string.IsNullOrEmpty(Dealer_vilage_no_TBx.Text) ? "ม.-" : "ม." + Dealer_vilage_no_TBx.Text;
            cdl.Dealer_alley = string.IsNullOrEmpty(Dealer_alley_TBx.Text) ? "ซ.-" : "ซ." + Dealer_alley_TBx.Text;
            cdl.Dealer_road = string.IsNullOrEmpty(Dealer_road_TBx.Text) ? "ถ.-" : "ถ." + Dealer_road_TBx.Text;
            cdl.Dealer_subdistrict = string.IsNullOrEmpty(Dealer_subdistrict_TBx.Text) ? "ต.-" : "ต." + Dealer_subdistrict_TBx.Text;
            cdl.Dealer_district = string.IsNullOrEmpty(Dealer_district_TBx.Text) ? "อ.-" : "อ." + Dealer_district_TBx.Text;
            cdl.Dealer_province = Dealer_province_DDL.SelectedIndex <= 0 ? 39 : Convert.ToInt32(Dealer_province_DDL.SelectedValue);
            cdl.Dealer_country = string.IsNullOrEmpty(Dealer_country_TBx.Text) ? "" : Dealer_country_TBx.Text;
            cdl.Dealer_zipcode = string.IsNullOrEmpty(Dealer_zipcode_TBx.Text) ? "" : Dealer_zipcode_TBx.Text;

            cdl_mng.addDealer(cdl);

            Car_Leasings cls_tmp = (Car_Leasings)Session["Leasings"];

            _AddDealer_Value(cdl.Dealer_id, cls_tmp.Leasing_id);

            
        }

        private void _AddDealer_Value(string Dealer_id, string Leasing_id)
        {
            Dealers_Manager cdl_mng = new Dealers_Manager();
            Dealers_Values cdlval = new Dealers_Values();

            cdlval.Dealer_id = Dealer_id;
            cdlval.Dealer_commission = string.IsNullOrEmpty(Dealer_commission_TBx.Text) ? 0 : Convert.ToDouble(Dealer_commission_TBx.Text);
            cdlval.Dealer_percen = string.IsNullOrEmpty(Dealer_percen_TBx.Text) ? 0 : Convert.ToDouble(Dealer_percen_TBx.Text);
            cdlval.Dealer_cash = string.IsNullOrEmpty(Dealer_cash_TBx.Text) ? 0 : Convert.ToDouble(Dealer_cash_TBx.Text);
            cdlval.Dealer_net_com = string.IsNullOrEmpty(Dealer_net_com_TBx.Text) ? 0 : Convert.ToDouble(Dealer_net_com_TBx.Text);
            cdlval.Dealer_com_code = string.IsNullOrEmpty(Dealer_com_code_TBx.Text) ? "" : Dealer_com_code_TBx.Text;
            cdlval.Dealer_bookcode = string.IsNullOrEmpty(Dealer_bookcode_TBx.Text) ? "" : Dealer_bookcode_TBx.Text;
            cdlval.Dealer_date_print = string.IsNullOrEmpty(Dealer_date_print_TBx.Text) ? DateTimeUtility._dateNOW() : DateTimeUtility.convertDateToMYSQL(Dealer_date_print_TBx.Text);
            cdlval.Leasing_id = Leasing_id;

            cdl_mng.addDealerValues(cdlval);

            Dealers_Values dlr = cdl_mng.getDealerValues(Dealer_id, Leasing_id);

            Session["Dealers_Leasing"] = string.IsNullOrEmpty(dlr.Dealer_id) ? null : dlr;
        }
    }
}