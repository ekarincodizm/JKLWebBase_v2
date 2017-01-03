using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Dealers;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Dealers;


namespace JKLWebBase_v2.Form_Dealer
{
    public partial class Dealer_Edit : Page
    {
        Dealers cdl = new Dealers();
        Dealers_Manager cdl_mng = new Dealers_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("List_Dealers");

                _loadThaiProvinces();
                _loadDealerStatus();

                if (Request.Params["code"] == null)
                {
                    Response.Redirect("/Form_Dealer/Dealer_Add");

                }
                else if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string idcard = code[1];

                    cdl = cdl_mng.getDealerByIdCard(idcard);

                    Session["Dealer"] = cdl;

                    _GetDealer(cdl);
                }
            }

            Alert_Success_Panel.Visible = false;

            
        }

        protected void Dealer_Add_Save_Btn_Click(object sender, EventArgs e)
        {
            _EditDealer();

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
        ****************************************************              Get Data And Replace To Form Function                 ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _GetDealer(Dealers cdl)
        {
            Dealer_fname_TBx.Text = cdl.Dealer_fname;
            Dealer_lname_TBx.Text = cdl.Dealer_lname;
            Dealer_idcard_TBx.Text = cdl.Dealer_idcard;
            Dealer_address_no_TBx.Text = cdl.Dealer_address_no;
            Dealer_vilage_TBx.Text = cdl.Dealer_vilage.IndexOf('.') >= 1 ? cdl.Dealer_vilage.Split('.')[1] : "" ;
            Dealer_vilage_no_TBx.Text = cdl.Dealer_vilage_no.IndexOf('.') >= 1 ? cdl.Dealer_vilage_no.Split('.')[1] : "";
            Dealer_alley_TBx.Text = cdl.Dealer_alley.IndexOf('.') >= 1 ? cdl.Dealer_alley.Split('.')[1] : "";
            Dealer_road_TBx.Text = cdl.Dealer_road.IndexOf('.') >= 1 ? cdl.Dealer_road.Split('.')[1] : "";
            Dealer_subdistrict_TBx.Text = cdl.Dealer_subdistrict.IndexOf('.') >= 1 ? cdl.Dealer_subdistrict.Split('.')[1] : "";
            Dealer_district_TBx.Text = cdl.Dealer_district.IndexOf('.') >= 1 ? cdl.Dealer_district.Split('.')[1] : "";
            Dealer_province_DDL.SelectedValue = cdl.Dealer_province.ToString();
            Dealer_country_TBx.Text = cdl.Dealer_country;
            Dealer_zipcode_TBx.Text = cdl.Dealer_zipcode;
            Dealer_status_DDL.SelectedValue = cdl.Dealer_status.ToString();
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
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _EditDealer()
        {
            cdl = new Dealers();

            Dealers cdl_tmp = (Dealers)Session["Dealer"];

            cdl.Dealer_id = cdl_tmp.Dealer_id;
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

            cdl_mng.editDealer(cdl);
        }
    }
}