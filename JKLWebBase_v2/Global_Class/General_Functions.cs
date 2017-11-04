using System;

namespace JKLWebBase_v2.Global_Class
{
    public class General_Functions
    {
        public static string _getAddressNo(string txtAddress)
        {
            string addressno = string.Empty;

            if (txtAddress.Trim() != "" && txtAddress.Trim() != "-" && txtAddress.Trim().Substring(0, 1) != "ไ" && txtAddress.Trim().Substring(0, 1) != "ป" &&
                txtAddress.Trim().Substring(0, 1) != "*" && txtAddress.Trim().Substring(0, 1) != "ร")
            {
                string[] address = txtAddress.Trim().Split(' ');

                addressno = address[0];

            }

            return addressno;
        }

        public static string _getVilageNo(string txtAddress)
        {
            string vilageno = string.Empty;

            if (txtAddress.Trim() != "" && txtAddress.Trim() != "-" && txtAddress.Trim().Substring(0, 1) != "ไ" && txtAddress.Trim().Substring(0, 1) != "ป" &&
                txtAddress.Trim().Substring(0, 1) != "*" && txtAddress.Trim().Substring(0, 1) != "ร")
            {
                string[] address = txtAddress.Trim().Split(' ');

                int index_subdistict = address.Length - 3;

                for (int i = 1; i < index_subdistict; i++)
                {
                    vilageno = vilageno + address[i] + " ";
                }
            }

            return vilageno;
        }

        public static string _getSubdistrict(string txtAddress)
        {
            string subdistict = string.Empty;

            if (txtAddress.Trim() != "" && txtAddress.Trim() != "-" && txtAddress.Trim().Substring(0, 1) != "ไ" && txtAddress.Trim().Substring(0, 1) != "ป" &&
                txtAddress.Trim().Substring(0, 1) != "*" && txtAddress.Trim().Substring(0, 1) != "ร")
            {
                string[] address = txtAddress.Trim().Split(' ');

                int index = address.Length - 3;

                subdistict = address[index];
            }

            return subdistict;
        }

        public static string _getDistrict(string txtAddress)
        {
            string distict = string.Empty;

            if (txtAddress.Trim() != "" && txtAddress.Trim() != "-" && txtAddress.Trim().Substring(0, 1) != "ไ" && txtAddress.Trim().Substring(0, 1) != "ป" &&
                txtAddress.Trim().Substring(0, 1) != "*" && txtAddress.Trim().Substring(0, 1) != "ร")
            {
                string[] address = txtAddress.Trim().Split(' ');

                int index = address.Length - 2;

                distict = address[index];
            }

            return distict;
        }

        public static string _getProvince(string txtAddress)
        {
            string province = string.Empty;

            if (txtAddress.Trim() != "" && txtAddress.Trim() != "-" && txtAddress.Trim().Substring(0, 1) != "ไ" && txtAddress.Trim().Substring(0,1) != "ป" &&
                txtAddress.Trim().Substring(0, 1) != "*" && txtAddress.Trim().Substring(0, 1) != "ร")
            {

                string[] address = txtAddress.Trim().Split(' ');

                int index = address.Length - 1;

                province = address[index];
            }

            return province;
        }
    }
}