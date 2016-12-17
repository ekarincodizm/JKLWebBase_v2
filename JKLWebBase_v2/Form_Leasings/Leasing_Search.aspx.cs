using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Drawing;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;
using JKLWebBase_v2.Managers_Base;
using JKLWebBase_v2.Managers_Leasings;

namespace JKLWebBase_v2
{
    public partial class Leasing_Search : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _loadBrands();
                _loadLeasingCode();
                _loadZoneService();
            }
        }

        protected void Leasing_Code_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Leasing_Code_ChkBxL.Items.Count;

            if (Leasing_Code_ChkBx_All.Checked)
            {
                for(int i = 0; i < count; i++)
                {
                    Leasing_Code_ChkBxL.Items[i].Selected = true;
                }
            } else
            {
                for (int i = 0; i < count; i++)
                {
                    Leasing_Code_ChkBxL.Items[i].Selected = false;
                }
            }
        }

        protected void Branch_ChkBx_All_CheckedChanged(object sender, EventArgs e)
        {
            int count = Branch_ChkBxL.Items.Count;

            if (Branch_ChkBx_All.Checked)
            {
                for (int i = 0; i < count; i++)
                {
                    Branch_ChkBxL.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Branch_ChkBxL.Items[i].Selected = false;
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
        private void _loadBrands()
        {
            List<Base_Branchs> list_data = new Base_Branchs_Manager().getBranchs();
            for (int i = 0; i < list_data.Count; i++)
            {
                Base_Branchs data = list_data[i];
                Branch_ChkBxL.Items.Add(new ListItem(data.Branch_code + " ( " + data.Branch_N_name + " ) ", data.Branch_id.ToString()));
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