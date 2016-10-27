using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Customers;
using JKLWebBase_v2.Managers_Leasings;


namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Car_Dealer_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadThaiProvinces();
                _loadDealerStatus();
            }
        }

        protected void Dealer_idcard_TBx_TextChanged(object sender, EventArgs e)
        {
            if(Dealer_idcard_TBx.Text.Length == 13)
            {
                _CheckDealer();
            }
        }

        protected void Dealer_search_Btn_Click(object sender, EventArgs e)
        {
            _CheckDealer();
        }

        protected void Dealer_Add_Save_Btn_Click(object sender, EventArgs e)
        {

        }

        protected void link_Add_Bondsman_1_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "1";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_2_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "2";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_3_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "3";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_4_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "4";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Bondsman_5_Click(object sender, EventArgs e)
        {
            Session["Number_Of_Bondsman"] = "5";
            Response.Redirect("/Form_Leasings/Leasing_Add_Bondsman");
        }

        protected void link_Add_Car_Img_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Car_Img");
        }

        protected void link_Add_Home_Img_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Leasings/Leasing_Home_Img");
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
        }

        // ดึงข้อมูลจังหวัดในประเทศไทย
        private void _loadDealerStatus()
        {
            Dealer_status_DDL.Items.Add(new ListItem("บุคคลธรรมดา", "0"));
            Dealer_status_DDL.Items.Add(new ListItem("นิติบุคคล", "1"));
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Calculate   Function                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Check Data Function                  ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _CheckDealer()
        {
            Car_Dealers cdler = new Car_Dealers_Manager().getDealerByIdCard(Dealer_idcard_TBx.Text);
            if (!cdler.Equals(null) && cdler != null)
            {

            }
            else
            {
                Alert_Warning_Panel.Visible = true;
                Alert_Id_Card_Lbl.Text = "ไม่พบเลขบัตรประชาชน " + Dealer_idcard_TBx.Text + " นี้ในระบบ";

                Dealer_idcard_TBx.Focus();
            }
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                               Add Data Function                    ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _AddDealer()
        {

            Car_Dealers cdlr = new Car_Dealers();

            cdlr.Dealer_id = new Car_Dealers_Manager().generateDealerID();
            cdlr.Dealer_fname = Dealer_fname_TBx.Text;
            cdlr.Dealer_lname = Dealer_lname_TBx.Text;
            cdlr.Dealer_idcard = Dealer_idcard_TBx.Text;
            cdlr.Dealer_address_no = Dealer_address_no_TBx.Text;
            cdlr.Dealer_vilage = Dealer_vilage_TBx.Text;
            cdlr.Dealer_vilage_no = Dealer_vilage_no_TBx.Text;
            cdlr.Dealer_alley = Dealer_alley_TBx.Text;
            cdlr.Dealer_road = Dealer_road_TBx.Text;
            cdlr.Dealer_subdistrict = Dealer_subdistrict_TBx.Text;
            cdlr.Dealer_district = Dealer_district_TBx.Text;
            cdlr.Dealer_province = Convert.ToInt32(Dealer_province_DDL.SelectedValue);
            cdlr.Dealer_country = Dealer_country_TBx.Text;
            cdlr.Dealer_zipcode = Dealer_zipcode_TBx.Text;

        }
    }
}