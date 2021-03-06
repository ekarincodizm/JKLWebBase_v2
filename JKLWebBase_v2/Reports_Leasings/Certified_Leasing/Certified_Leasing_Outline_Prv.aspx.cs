﻿using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Managers_Base;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKLWebBase_v2.Reports_Leasings.Certified_Leasing
{
    public partial class Certified_Leasing_Outline_Prv : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null || Session["Package"] == null)
            {
                Response.Redirect("/Authorization/Login");
            }

            if (!IsPostBack)
            {
                _loadCompany();
            }
        }

        protected void Export_Btn_Click(object sender, EventArgs e)
        {
            string Company_Name = Company_Name_DDl.SelectedValue == "0" ? "" : Company_Name_DDl.SelectedItem.Text;
            string Company_Address = string.IsNullOrEmpty(Company_Address_TBx.Text) ? "" : Company_Address_TBx.Text;
            string SubCompany_Address_1 = string.IsNullOrEmpty(SubCompany_Address_1_TBx.Text) ? "" : SubCompany_Address_1_TBx.Text;
            string SubCompany_Address_2 = string.IsNullOrEmpty(SubCompany_Address_2_TBx.Text) ? "" : SubCompany_Address_2_TBx.Text;
            string SubCompany_Address_3 = string.IsNullOrEmpty(SubCompany_Address_3_TBx.Text) ? "" : SubCompany_Address_3_TBx.Text;

            Session["Company_Values"] = Company_Name + "|" + Company_Address + "|" + SubCompany_Address_1 + "|" + SubCompany_Address_2 + "|" + SubCompany_Address_3;

            Response.Redirect("/Reports_Leasings/Certified_Leasing/Certified_Leasing");
        }

        private void _loadCompany()
        {
            List<Base_Companys> list_data = new Base_Companys_Manager().getCompanysForWebReport();
            Company_Name_DDl.Items.Add(new ListItem("--------  กรุณาเลือก  --------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Companys data = list_data[i];
                Company_Name_DDl.Items.Add(new ListItem(data.Company_F_name, data.Company_tax_id));
            }
        }

        protected void Company_Name_DDl_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clearText();

            if (Company_Name_DDl.SelectedValue != "0")
            {
                List<Base_Companys> list_data = new Base_Companys_Manager().getCompanysAddressForWebReport(Company_Name_DDl.SelectedValue);

                for (int i = 0; i < list_data.Count; i++)
                {
                    Base_Companys data = list_data[i];

                    string address = "";

                    if (data.Company_tax_subcode == "000")
                    {
                        address += data.Company_address_no;
                        address += data.Company_vilage.Split('.')[1] == "-" ? "" : " " + data.Company_vilage;
                        address += data.Company_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Company_vilage_no;
                        address += data.Company_alley.Split('.')[1] == "-" ? "" : " " + data.Company_alley;
                        address += data.Company_road.Split('.')[1] == "-" ? "" : " " + data.Company_road;
                        address += data.Company_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Company_subdistrict;
                        address += data.Company_district.Split('.')[1] == "-" ? "" : " " + data.Company_district;
                        address += " จ." + data.Company_province;

                        Company_Address_TBx.Text = "สำนักงานใหญ่ : " + address;
                    }
                    else if (data.Company_tax_subcode == "001")
                    {
                        address += data.Company_address_no;
                        address += data.Company_vilage.Split('.')[1] == "-" ? "" : " " + data.Company_vilage;
                        address += data.Company_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Company_vilage_no;
                        address += data.Company_alley.Split('.')[1] == "-" ? "" : " " + data.Company_alley;
                        address += data.Company_road.Split('.')[1] == "-" ? "" : " " + data.Company_road;
                        address += data.Company_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Company_subdistrict;
                        address += data.Company_district.Split('.')[1] == "-" ? "" : " " + data.Company_district;
                        address += " จ." + data.Company_province;

                        SubCompany_Address_1_TBx.Text = data.Company_N_name + " : " + address;
                    }
                    else if (data.Company_tax_subcode == "002")
                    {
                        address += data.Company_address_no;
                        address += data.Company_vilage.Split('.')[1] == "-" ? "" : " " + data.Company_vilage;
                        address += data.Company_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Company_vilage_no;
                        address += data.Company_alley.Split('.')[1] == "-" ? "" : " " + data.Company_alley;
                        address += data.Company_road.Split('.')[1] == "-" ? "" : " " + data.Company_road;
                        address += data.Company_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Company_subdistrict;
                        address += data.Company_district.Split('.')[1] == "-" ? "" : " " + data.Company_district;
                        address += " จ." + data.Company_province;

                        SubCompany_Address_1_TBx.Text = data.Company_N_name + " : " + address;
                    }
                    else if (data.Company_tax_subcode == "003")
                    {
                        address += data.Company_address_no;
                        address += data.Company_vilage.Split('.')[1] == "-" ? "" : " " + data.Company_vilage;
                        address += data.Company_vilage_no.Split('.')[1] == "-" ? "" : " " + data.Company_vilage_no;
                        address += data.Company_alley.Split('.')[1] == "-" ? "" : " " + data.Company_alley;
                        address += data.Company_road.Split('.')[1] == "-" ? "" : " " + data.Company_road;
                        address += data.Company_subdistrict.Split('.')[1] == "-" ? "" : " " + data.Company_subdistrict;
                        address += data.Company_district.Split('.')[1] == "-" ? "" : " " + data.Company_district;
                        address += " จ." + data.Company_province;

                        SubCompany_Address_1_TBx.Text = data.Company_N_name + " : " + address;
                    }
                }
            }
        }

        private void _clearText()
        {
            Company_Address_TBx.Text = "";
            SubCompany_Address_1_TBx.Text = "";
            SubCompany_Address_2_TBx.Text = "";
            SubCompany_Address_3_TBx.Text = "";
        }
    }
}