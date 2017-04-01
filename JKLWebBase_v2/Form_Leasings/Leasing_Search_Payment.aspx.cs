using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Leasings;

namespace JKLWebBase_v2.Form_Leasings
{
    public partial class Leasing_Search_Payment : Page
    {
        Car_Leasings_Manager cls_mng = new Car_Leasings_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadCompanys();
                _loadLeasingCode();
                _loadZoneService();
            }
        }

        protected void Leasing_Code_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Leasing_Code_ChkBxL.Items.Count;

            if (Leasing_Code_ChkBx_All.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    Leasing_Code_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Leasing_Code_ChkBxL.Items[i].Selected = false;
                }
            }
        }

        protected void Company_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Company_ChkBxL.Items.Count;

            if (Company_ChkBx_All.Checked)
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

        protected void Zone_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Zone_ChkBxL.Items.Count;

            if (Zone_ChkBx_All.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    Zone_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Zone_ChkBxL.Items[i].Selected = false;
                }
            }
        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            Session.Remove("List_Leasings");

            Paging_DDL.Items.Clear();

            _getLeasing();
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                        Pageing System                              ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        protected void link_Previous_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            if (current_page > 1)
            {
                int prev = current_page - 1;

                Paging_DDL.SelectedValue = prev.ToString();

                _getMorePayment(prev);
            }
        }
        protected void Paging_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            _getMorePayment(current_page);
        }

        protected void link_Next_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            int next = current_page + 1;

            Paging_DDL.SelectedValue = next.ToString();

            _getMorePayment(next);
        }


        /*******************************************************************************************************************************************************************************
        ****************************************************                   Search Leasing Method                            ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private void _getLeasing()
        {
            string deposit_no = Deps_No_TBx.Text;
            string leasing_no = Leasing_No_TBx.Text;
            string idcard = Cust_Idcard_TBx.Text;
            string name = Cust_Name_TBx.Text.Trim(' ');
            string date_str = DateTimeUtility.convertDateToMYSQL(Leasing_Date_str_TBx.Text);
            string date_end = DateTimeUtility.convertDateToMYSQL(Leasing_Date_end_TBx.Text);
            string leasing_Code_inline = _getCheckedLeasing_Code();
            string Company_id_inline = _getCheckedBranch();
            string zone_id_inline = _getCheckedZone();

            if (!string.IsNullOrEmpty(deposit_no) || !string.IsNullOrEmpty(leasing_no) || !string.IsNullOrEmpty(idcard) || !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(date_str) ||
                !string.IsNullOrEmpty(date_end) || !string.IsNullOrEmpty(leasing_Code_inline) || !string.IsNullOrEmpty(Company_id_inline) || !string.IsNullOrEmpty(zone_id_inline))
            {
                cls_mng = new Car_Leasings_Manager();

                List<Car_Leasings> list_cls_all = cls_mng.getCarLeasing(deposit_no, leasing_no, idcard, string.IsNullOrEmpty(name) ? "" : name.Split(' ')[0], name.IndexOf(' ') <= 0 ? "" : name.Split(' ')[1], date_str, date_end, leasing_Code_inline, Company_id_inline, zone_id_inline, 0, 0);

                int row = list_cls_all.Count;

                _pageCount(row);

                List<Car_Leasings> list_cls = cls_mng.getCarLeasing(deposit_no, leasing_no, idcard, string.IsNullOrEmpty(name) ? "" : name.Split(' ')[0], name.IndexOf(' ') <= 0 ? "" : name.Split(' ')[1], date_str, date_end, leasing_Code_inline, Company_id_inline, zone_id_inline, 0, 20);

                Session["deposit_no"] = deposit_no;
                Session["leasing_no"] = leasing_no;
                Session["idcard"] = idcard;
                Session["name"] = name;
                Session["date_str"] = deposit_no;
                Session["date_end"] = date_end;
                Session["leasing_Code_inline"] = leasing_Code_inline;
                Session["Company_id_inline"] = Company_id_inline;
                Session["zone_id_inline"] = zone_id_inline;
                Session["row_str"] = 0;

                Session["List_Leasings"] = list_cls;
            }
        }

        private void _pageCount(int row)
        {
            int paging = row > 20 ? (row / 20) + 1 : 1;

            for (int i = 1; i <= paging; i++)
            {
                Paging_DDL.Items.Add(new ListItem("" + i, "" + i));
            }

            if (paging == 1)
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = false;
            }
            else if (paging > 1 && Paging_DDL.Items[0].Value == "0")
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = true;
            }
            else
            {
                link_Previous.Enabled = true;
                link_Next.Enabled = true;
            }
        }

        private void _getMorePayment(int current_page)
        {
            string deposit_no = (string)Session["deposit_no"];
            string leasing_no = (string)Session["leasing_no"];
            string idcard = (string)Session["idcard"];
            string name = (string)Session["name"];
            string date_str = (string)Session["date_str"];
            string date_end = (string)Session["date_end"];
            string leasing_Code_inline = (string)Session["leasing_Code_inline"];
            string Company_id_inline = (string)Session["Company_id_inline"];
            string zone_id_inline = (string)Session["zone_id_inline"];

            cls_mng = new Car_Leasings_Manager();

            if (current_page > 1)
            {
                int row_str = (current_page - 1) * 20;

                link_Previous.Enabled = true;

                List<Car_Leasings> list_cls = cls_mng.getCarLeasing(deposit_no, leasing_no, idcard, string.IsNullOrEmpty(name) ? "" : name.Split(' ')[0], name.IndexOf(' ') <= 0 ? "" : name.Split(' ')[1], date_str, date_end, leasing_Code_inline, Company_id_inline, zone_id_inline, 0, 20);

                Session["row_str"] = row_str;

                Session["List_Dealers"] = list_cls;
            }
            else
            {
                link_Previous.Enabled = false;

                List<Car_Leasings> list_cls = cls_mng.getCarLeasing(deposit_no, leasing_no, idcard, string.IsNullOrEmpty(name) ? "" : name.Split(' ')[0], name.IndexOf(' ') <= 0 ? "" : name.Split(' ')[1], date_str, date_end, leasing_Code_inline, Company_id_inline, zone_id_inline, 0, 20);

                Session["row_str"] = 0;

                Session["List_Dealers"] = list_cls;
            }
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Get Value in CheckBoxList                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        private string _getCheckedLeasing_Code()
        {
            string leasing_Code_inline = "";
            int count = 1;

            for (int i = 0; i < Leasing_Code_ChkBxL.Items.Count; i++)
            {
                if (Leasing_Code_ChkBxL.Items[i].Selected && count == 1)
                {
                    leasing_Code_inline += Leasing_Code_ChkBxL.Items[i].Value;
                    count++;
                }
                else if (Leasing_Code_ChkBxL.Items[i].Selected)
                {
                    leasing_Code_inline += "," + Leasing_Code_ChkBxL.Items[i].Value;
                    count++;
                }
            }
            return leasing_Code_inline;
        }

        private string _getCheckedBranch()
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

        private string _getCheckedZone()
        {
            string zone_id_inline = "";
            int count = 1;

            for (int i = 0; i < Zone_ChkBxL.Items.Count; i++)
            {
                if (Zone_ChkBxL.Items[i].Selected && count == 1)
                {
                    zone_id_inline += Zone_ChkBxL.Items[i].Value;
                    count++;
                }
                else if (Zone_ChkBxL.Items[i].Selected)
                {
                    zone_id_inline += "," + Zone_ChkBxL.Items[i].Value;
                    count++;
                }
            }
            return zone_id_inline;
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        // รหัสสัญญา
        private void _loadLeasingCode()
        {
            List<Base_Leasing_Code> list_data = new Base_Leasing_Code_Manager().getLeasingCode();
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Leasing_Code data = list_data[i];
                if (string.IsNullOrEmpty(data.Leasing_code_S_Name))
                {
                    Leasing_Code_ChkBxL.Items.Add(new ListItem(data.Leasing_code_name, data.Leasing_code_id.ToString()));
                }
                else
                {
                    Leasing_Code_ChkBxL.Items.Add(new ListItem(data.Leasing_code_name + " ( " + data.Leasing_code_S_Name + " ) ", data.Leasing_code_id.ToString()));
                }

            }
        }

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

        // เขตบริการ
        private void _loadZoneService()
        {
            List<Base_Zone_Service> list_data = new Base_Zone_Service_Manager().getZoneService();
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Zone_Service data = list_data[i];
                Zone_ChkBxL.Items.Add(new ListItem(data.Zone_code + " " + data.Zone_name, data.Zone_id.ToString()));
            }
        }
    }
}