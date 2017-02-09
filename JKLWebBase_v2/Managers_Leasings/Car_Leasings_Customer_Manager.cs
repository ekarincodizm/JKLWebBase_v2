using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

using JKLWebBase_v2.Global_Class;
using JKLWebBase_v2.Class_Base;
using JKLWebBase_v2.Class_Customers;
using JKLWebBase_v2.Class_Leasings;

namespace JKLWebBase_v2.Managers_Leasings
{
    public class Car_Leasings_Customer_Manager
    {
        string error = string.Empty;

        public Customers getCustomersLeasing(string i_Leasing_id, string i_Cust_idcard)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                ////
                /// :: StoredProcedure :: [ g_car_leasings_customers ] :: 
                /// g_car_leasings_customers (IN i_Leasing_id varchar(50), IN i_Cust_idcard varchar(20))
                /// 
                ////

                con.Open();
                MySqlCommand cmd = new MySqlCommand("g_car_leasings_customers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_Leasing_id", i_Leasing_id);
                cmd.Parameters.AddWithValue("@i_Cust_idcard", i_Cust_idcard);

                MySqlDataReader reader = cmd.ExecuteReader();

                Car_Leasings cls = new Car_Leasings();

                if (reader.Read())
                {
                    
                    int defaultNum = 0;
                    string defaultString = "";

                    cls.Leasing_id = reader.IsDBNull(0) ? defaultString : reader.GetString(0);
                    cls.Deps_no = reader.IsDBNull(1) ? defaultString : reader.GetString(1);
                    cls.Leasing_no = reader.IsDBNull(2) ? defaultString : reader.GetString(2);

                    cls.bs_ls_code = new Base_Leasing_Code();
                    cls.bs_ls_code.Leasing_code_id = reader.IsDBNull(3) ? defaultNum : reader.GetInt32(3);
                    cls.bs_ls_code.Leasing_code_name = reader.IsDBNull(4) ? defaultString : reader.GetString(4);

                    cls.Leasing_date = reader.IsDBNull(5) ? defaultString : reader.GetString(5);

                    cls.bs_cpn = new Base_Companys();
                    cls.bs_cpn.Company_id = reader.IsDBNull(6) ? defaultNum : reader.GetInt32(6);
                    cls.bs_cpn.Company_code = reader.IsDBNull(7) ? defaultString : reader.GetString(7);
                    cls.bs_cpn.Company_N_name = reader.IsDBNull(8) ? defaultString : reader.GetString(8);
                    cls.bs_cpn.Company_F_name = reader.IsDBNull(9) ? defaultString : reader.GetString(9);
                    cls.bs_cpn.Company_tax_id = reader.IsDBNull(10) ? defaultString : reader.GetString(10);
                    cls.bs_cpn.Company_tax_subcode = reader.IsDBNull(11) ? defaultString : reader.GetString(11);
                    cls.bs_cpn.Company_address_no = reader.IsDBNull(12) ? defaultString : reader.GetString(12);
                    cls.bs_cpn.Company_vilage = reader.IsDBNull(13) ? defaultString : reader.GetString(13);
                    cls.bs_cpn.Company_vilage_no = reader.IsDBNull(14) ? defaultString : reader.GetString(14);
                    cls.bs_cpn.Company_alley = reader.IsDBNull(15) ? defaultString : reader.GetString(15);
                    cls.bs_cpn.Company_road = reader.IsDBNull(16) ? defaultString : reader.GetString(16);
                    cls.bs_cpn.Company_subdistrict = reader.IsDBNull(17) ? defaultString : reader.GetString(17);
                    cls.bs_cpn.Company_district = reader.IsDBNull(18) ? defaultString : reader.GetString(18);
                    cls.bs_cpn.Company_province_id = reader.IsDBNull(19) ? defaultNum : reader.GetInt32(19);
                    cls.bs_cpn.Company_province_name = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    cls.bs_cpn.Company_country = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    cls.bs_cpn.Company_zipcode = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    cls.bs_cpn.Company_tel = reader.IsDBNull(23) ? defaultString : reader.GetString(23);
                    cls.bs_cpn.Company_Save_date = reader.IsDBNull(24) ? defaultString : reader.GetString(24);

                    cls.bs_zn = new Base_Zone_Service();
                    cls.bs_zn.Zone_id = reader.IsDBNull(25) ? defaultNum : reader.GetInt32(25);
                    cls.bs_zn.Zone_code = reader.IsDBNull(26) ? defaultString : reader.GetString(26);
                    cls.bs_zn.Zone_name = reader.IsDBNull(27) ? defaultString : reader.GetString(27);

                    cls.bs_ct = new Base_Courts();
                    cls.bs_ct.Court_id = reader.IsDBNull(28) ? defaultNum : reader.GetInt32(28);
                    cls.bs_ct.Court_name = reader.IsDBNull(29) ? defaultString : reader.GetString(29);

                    cls.PeReT = reader.IsDBNull(30) ? defaultString : reader.GetString(30);

                    cls.TotalPaymentTime = reader.IsDBNull(31) ? defaultNum : reader.GetInt32(31);
                    cls.Total_require = reader.IsDBNull(32) ? defaultNum : reader.GetDouble(32);
                    cls.Vat_rate = reader.IsDBNull(33) ? defaultNum : reader.GetDouble(33);
                    cls.Interest_rate = reader.IsDBNull(34) ? defaultNum : reader.GetDouble(34);
                    cls.Total_period = reader.IsDBNull(35) ? defaultNum : reader.GetInt32(35);
                    cls.Total_sum = reader.IsDBNull(36) ? defaultNum : reader.GetDouble(36);
                    cls.Total_Interest = reader.IsDBNull(37) ? defaultNum : reader.GetDouble(37);
                    cls.Total_Tax = reader.IsDBNull(38) ? defaultNum : reader.GetDouble(38);
                    cls.Total_leasing = reader.IsDBNull(39) ? defaultNum : reader.GetDouble(39);
                    cls.Total_Net_leasing = reader.IsDBNull(40) ? defaultNum : reader.GetDouble(40);
                    cls.Period_cal = reader.IsDBNull(41) ? defaultNum : reader.GetDouble(41);
                    cls.Period_interst = reader.IsDBNull(42) ? defaultNum : reader.GetDouble(42);
                    cls.Period_tax = reader.IsDBNull(43) ? defaultNum : reader.GetDouble(43);
                    cls.Period_pure = reader.IsDBNull(44) ? defaultNum : reader.GetDouble(44);
                    cls.Period_payment = reader.IsDBNull(45) ? defaultNum : reader.GetDouble(45);
                    cls.Period_require = reader.IsDBNull(46) ? defaultNum : reader.GetDouble(46);
                    cls.Total_period_length = reader.IsDBNull(47) ? defaultString : reader.GetString(47);
                    cls.Total_period_lose = reader.IsDBNull(48) ? defaultNum : reader.GetInt32(48);
                    cls.Total_period_left = reader.IsDBNull(49) ? defaultNum : reader.GetInt32(49);
                    cls.Total_payment_left = reader.IsDBNull(50) ? defaultNum : reader.GetDouble(50);
                    cls.Payment_schedule = reader.IsDBNull(51) ? defaultNum : reader.GetInt32(51);
                    cls.First_payment_date = reader.IsDBNull(52) ? defaultString : reader.GetString(52);
                    cls.Car_register_date = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                    cls.Car_license_plate = reader.IsDBNull(54) ? defaultString : reader.GetString(54);

                    cls.cls_plate_pv = new TH_Provinces();
                    cls.cls_plate_pv.Province_id = reader.IsDBNull(55) ? defaultNum : reader.GetInt32(55);
                    cls.cls_plate_pv.Province_name = reader.IsDBNull(56) ? defaultString : reader.GetString(56);

                    cls.Car_type = reader.IsDBNull(57) ? defaultString : reader.GetString(57);
                    cls.Car_feature = reader.IsDBNull(58) ? defaultString : reader.GetString(58);

                    cls.bs_cbrn = new Base_Car_Brands();
                    cls.bs_cbrn.car_brand_id = reader.IsDBNull(59) ? defaultNum : reader.GetInt32(59);
                    cls.bs_cbrn.car_brand_name_eng = reader.IsDBNull(60) ? defaultString : reader.GetString(60);
                    cls.bs_cbrn.car_brand_name_th = reader.IsDBNull(61) ? defaultString : reader.GetString(61);

                    cls.Car_model = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    cls.Car_year = reader.IsDBNull(63) ? defaultString : reader.GetString(63);
                    cls.Car_color = reader.IsDBNull(64) ? defaultString : reader.GetString(64);
                    cls.Car_engine_no = reader.IsDBNull(65) ? defaultString : reader.GetString(65);
                    cls.Car_engine_no_at = reader.IsDBNull(66) ? defaultString : reader.GetString(66);
                    cls.Car_engine_brand = reader.IsDBNull(67) ? defaultString : reader.GetString(67);
                    cls.Car_chassis_no = reader.IsDBNull(68) ? defaultString : reader.GetString(68);
                    cls.Car_chassis_no_at = reader.IsDBNull(69) ? defaultString : reader.GetString(69);
                    cls.Car_fual_type = reader.IsDBNull(70) ? defaultString : reader.GetString(70);
                    cls.Car_gas_No = reader.IsDBNull(71) ? defaultString : reader.GetString(71);
                    cls.Car_used_id = reader.IsDBNull(72) ? defaultNum : reader.GetInt32(72);
                    cls.Car_distance = reader.IsDBNull(73) ? defaultNum : reader.GetDouble(73);
                    cls.Car_next_register_date = reader.IsDBNull(74) ? defaultString : reader.GetString(74);
                    cls.Car_tax_value = reader.IsDBNull(75) ? defaultNum : reader.GetDouble(75);
                    cls.Car_credits = reader.IsDBNull(76) ? defaultString : reader.GetString(76);
                    cls.Car_agent = reader.IsDBNull(77) ? defaultString : reader.GetString(77);
                    cls.Car_old_owner = reader.IsDBNull(78) ? defaultString : reader.GetString(78);
                    cls.Car_old_owner_idcard = reader.IsDBNull(79) ? defaultString : reader.GetString(79);
                    cls.Car_old_owner_b_date = reader.IsDBNull(80) ? defaultString : reader.GetString(80);
                    cls.Car_old_owner_address_no = reader.IsDBNull(81) ? defaultString : reader.GetString(81);
                    cls.Car_old_owner_vilage = reader.IsDBNull(82) ? defaultString : reader.GetString(82);
                    cls.Car_old_owner_vilage_no = reader.IsDBNull(83) ? defaultString : reader.GetString(83);
                    cls.Car_old_owner_alley = reader.IsDBNull(84) ? defaultString : reader.GetString(84);
                    cls.Car_old_owner_road = reader.IsDBNull(85) ? defaultString : reader.GetString(85);
                    cls.Car_old_owner_subdistrict = reader.IsDBNull(86) ? defaultString : reader.GetString(86);
                    cls.Car_old_owner_district = reader.IsDBNull(87) ? defaultString : reader.GetString(87);

                    cls.cls_owner_pv = new TH_Provinces();
                    cls.cls_owner_pv.Province_id = reader.IsDBNull(88) ? defaultNum : reader.GetInt32(88);
                    cls.cls_owner_pv.Province_name = reader.IsDBNull(89) ? defaultString : reader.GetString(89);

                    cls.Car_old_owner_contry = reader.IsDBNull(90) ? defaultString : reader.GetString(90);
                    cls.Car_old_owner_zipcode = reader.IsDBNull(91) ? defaultString : reader.GetString(91);

                    cls.tent_car = new Base_Tents_Car();
                    cls.tent_car.Tent_car_id = reader.IsDBNull(92) ? defaultNum : reader.GetInt32(92);
                    cls.tent_car.Tent_name = reader.IsDBNull(93) ? defaultString : reader.GetString(93);
                    cls.tent_car.Tent_local = reader.IsDBNull(94) ? defaultString : reader.GetString(94);

                    cls.Cheque_receiver = reader.IsDBNull(95) ? defaultString : reader.GetString(95);
                    cls.Cheque_bank = reader.IsDBNull(96) ? defaultString : reader.GetString(96);
                    cls.Cheque_bank_branch = reader.IsDBNull(97) ? defaultString : reader.GetString(97);
                    cls.Cheque_number = reader.IsDBNull(98) ? defaultString : reader.GetString(98);
                    cls.Cheque_sum = reader.IsDBNull(99) ? defaultNum : reader.GetDouble(99);
                    cls.Cheque_receive_date = reader.IsDBNull(100) ? defaultString : reader.GetString(100);
                    cls.Guarantee = reader.IsDBNull(101) ? defaultString : reader.GetString(101);

                    cls.bs_ls_stt = new Base_Leasing_Status();
                    cls.bs_ls_stt.Contract_Status_id = reader.IsDBNull(102) ? defaultNum : reader.GetInt32(102);
                    cls.bs_ls_stt.Contract_Status_name = reader.IsDBNull(103) ? defaultString : reader.GetString(103);

                    cls.Leasings_save_date = reader.IsDBNull(104) ? defaultString : reader.GetString(104);

                    cls.ctm = new Customers();
                    cls.ctm.Cust_id = reader.IsDBNull(105) ? defaultString : reader.GetString(105);
                    cls.ctm.Cust_Idcard = reader.IsDBNull(106) ? defaultString : reader.GetString(106);
                    cls.ctm.Cust_Fname = reader.IsDBNull(107) ? defaultString : reader.GetString(107);
                    cls.ctm.Cust_LName = reader.IsDBNull(108) ? defaultString : reader.GetString(108);
                    cls.ctm.Cust_B_date = reader.IsDBNull(109) ? defaultString : reader.GetString(109);
                    cls.ctm.Cust_Age = reader.IsDBNull(110) ? defaultNum : reader.GetInt32(110);
                    cls.ctm.Cust_Idcard_without = reader.IsDBNull(111) ? defaultString : reader.GetString(111);
                    cls.ctm.Cust_Idcard_start = reader.IsDBNull(112) ? defaultString : reader.GetString(112);
                    cls.ctm.Cust_Idcard_expire = reader.IsDBNull(113) ? defaultString : reader.GetString(113);

                    cls.ctm.ctm_ntnlt = new Base_Nationalitys();
                    cls.ctm.ctm_ntnlt.Nationality_id = reader.IsDBNull(114) ? defaultNum : reader.GetInt32(114);
                    cls.ctm.ctm_ntnlt.Nationality_name_ENG = reader.IsDBNull(115) ? defaultString : reader.GetString(115);
                    cls.ctm.ctm_ntnlt.Nationality_name_TH = reader.IsDBNull(116) ? defaultString : reader.GetString(116);

                    cls.ctm.ctm_org = new Base_Origins();
                    cls.ctm.ctm_org.Origin_id = reader.IsDBNull(117) ? defaultNum : reader.GetInt32(117);
                    cls.ctm.ctm_org.Origin_name_ENG = reader.IsDBNull(118) ? defaultString : reader.GetString(118);
                    cls.ctm.ctm_org.Origin_name_TH = reader.IsDBNull(119) ? defaultString : reader.GetString(119);

                    cls.ctm.Cust_Tel = reader.IsDBNull(120) ? defaultString : reader.GetString(120);
                    cls.ctm.Cust_Email = reader.IsDBNull(121) ? defaultString : reader.GetString(121);

                    cls.ctm.ctm_pstt = new Base_Person_Status();
                    cls.ctm.ctm_pstt.person_status_id = reader.IsDBNull(122) ? defaultNum : reader.GetInt32(122);
                    cls.ctm.ctm_pstt.person_status_name = reader.IsDBNull(123) ? defaultString : reader.GetString(123);

                    cls.ctm.Cust_Marry_idcard = reader.IsDBNull(124) ? defaultString : reader.GetString(124);
                    cls.ctm.Cust_Marry_Fname = reader.IsDBNull(125) ? defaultString : reader.GetString(125);
                    cls.ctm.Cust_Marry_Lname = reader.IsDBNull(126) ? defaultString : reader.GetString(126);

                    cls.ctm.ctm_marry_ntnlt = new Base_Nationalitys();
                    cls.ctm.ctm_marry_ntnlt.Nationality_id = reader.IsDBNull(127) ? defaultNum : reader.GetInt32(127);
                    cls.ctm.ctm_marry_ntnlt.Nationality_name_ENG = reader.IsDBNull(128) ? defaultString : reader.GetString(128);
                    cls.ctm.ctm_marry_ntnlt.Nationality_name_TH = reader.IsDBNull(129) ? defaultString : reader.GetString(129);

                    cls.ctm.ctm_marry_org = new Base_Origins();
                    cls.ctm.ctm_marry_org.Origin_id = reader.IsDBNull(130) ? defaultNum : reader.GetInt32(130);
                    cls.ctm.ctm_marry_org.Origin_name_ENG = reader.IsDBNull(131) ? defaultString : reader.GetString(131);
                    cls.ctm.ctm_marry_org.Origin_name_TH = reader.IsDBNull(132) ? defaultString : reader.GetString(132);

                    cls.ctm.Cust_Marry_Address_no = reader.IsDBNull(133) ? defaultString : reader.GetString(133);
                    cls.ctm.Cust_Marry_vilage = reader.IsDBNull(134) ? defaultString : reader.GetString(134);
                    cls.ctm.Cust_Marry_vilage_no = reader.IsDBNull(135) ? defaultString : reader.GetString(135);
                    cls.ctm.Cust_Marry_alley = reader.IsDBNull(136) ? defaultString : reader.GetString(136);
                    cls.ctm.Cust_Marry_road = reader.IsDBNull(137) ? defaultString : reader.GetString(137);
                    cls.ctm.Cust_Marry_subdistrict = reader.IsDBNull(138) ? defaultString : reader.GetString(138);
                    cls.ctm.Cust_Marry_district = reader.IsDBNull(139) ? defaultString : reader.GetString(139);

                    cls.ctm.ctm_marry_pv = new TH_Provinces();
                    cls.ctm.ctm_marry_pv.Province_id = reader.IsDBNull(140) ? defaultNum : reader.GetInt32(140);
                    cls.ctm.ctm_marry_pv.Province_name = reader.IsDBNull(141) ? defaultString : reader.GetString(141);

                    cls.ctm.Cust_Marry_country = reader.IsDBNull(142) ? defaultString : reader.GetString(142);
                    cls.ctm.Cust_Marry_zipcode = reader.IsDBNull(143) ? defaultString : reader.GetString(143);
                    cls.ctm.Cust_Marry_tel = reader.IsDBNull(144) ? defaultString : reader.GetString(144);
                    cls.ctm.Cust_Marry_email = reader.IsDBNull(145) ? defaultString : reader.GetString(145);
                    cls.ctm.Cust_Marry_job = reader.IsDBNull(146) ? defaultString : reader.GetString(146);
                    cls.ctm.Cust_Marry_job_position = reader.IsDBNull(147) ? defaultString : reader.GetString(147);
                    cls.ctm.Cust_Marry_job_long = reader.IsDBNull(148) ? defaultNum : reader.GetInt32(148);
                    cls.ctm.Cust_Marry_job_salary = reader.IsDBNull(149) ? defaultNum : reader.GetDouble(149);
                    cls.ctm.Cust_Marry_job_local_name = reader.IsDBNull(150) ? defaultString : reader.GetString(150);
                    cls.ctm.Cust_Marry_job_address_no = reader.IsDBNull(151) ? defaultString : reader.GetString(151);
                    cls.ctm.Cust_Marry_job_vilage = reader.IsDBNull(152) ? defaultString : reader.GetString(152);
                    cls.ctm.Cust_Marry_job_vilage_no = reader.IsDBNull(153) ? defaultString : reader.GetString(153);
                    cls.ctm.Cust_Marry_job_alley = reader.IsDBNull(154) ? defaultString : reader.GetString(154);
                    cls.ctm.Cust_Marry_job_road = reader.IsDBNull(155) ? defaultString : reader.GetString(155);
                    cls.ctm.Cust_Marry_job_subdistrict = reader.IsDBNull(156) ? defaultString : reader.GetString(156);
                    cls.ctm.Cust_Marry_job_district = reader.IsDBNull(157) ? defaultString : reader.GetString(157);

                    cls.ctm.ctm_marry_job_pv = new TH_Provinces();
                    cls.ctm.ctm_marry_job_pv.Province_id = reader.IsDBNull(158) ? defaultNum : reader.GetInt32(158);
                    cls.ctm.ctm_marry_job_pv.Province_name = reader.IsDBNull(159) ? defaultString : reader.GetString(159);

                    cls.ctm.Cust_Marry_job_country = reader.IsDBNull(160) ? defaultString : reader.GetString(160);
                    cls.ctm.Cust_Marry_job_zipcode = reader.IsDBNull(161) ? defaultString : reader.GetString(161);
                    cls.ctm.Cust_Marry_job_tel = reader.IsDBNull(162) ? defaultString : reader.GetString(162);
                    cls.ctm.Cust_Job = reader.IsDBNull(163) ? defaultString : reader.GetString(163);
                    cls.ctm.Cust_Job_position = reader.IsDBNull(164) ? defaultString : reader.GetString(164);
                    cls.ctm.Cust_Job_long = reader.IsDBNull(165) ? defaultNum : reader.GetInt32(165);
                    cls.ctm.Cust_Job_salary = reader.IsDBNull(166) ? defaultNum : reader.GetDouble(166);
                    cls.ctm.Cust_Job_local_name = reader.IsDBNull(167) ? defaultString : reader.GetString(167);
                    cls.ctm.Cust_Job_address_no = reader.IsDBNull(168) ? defaultString : reader.GetString(168);
                    cls.ctm.Cust_Job_vilage = reader.IsDBNull(169) ? defaultString : reader.GetString(169);
                    cls.ctm.Cust_Job_vilage_no = reader.IsDBNull(170) ? defaultString : reader.GetString(170);
                    cls.ctm.Cust_Job_alley = reader.IsDBNull(171) ? defaultString : reader.GetString(171);
                    cls.ctm.Cust_Job_road = reader.IsDBNull(172) ? defaultString : reader.GetString(172);
                    cls.ctm.Cust_Job_subdistrict = reader.IsDBNull(173) ? defaultString : reader.GetString(173);
                    cls.ctm.Cust_Job_district = reader.IsDBNull(174) ? defaultString : reader.GetString(174);

                    cls.ctm.ctm_job_pv = new TH_Provinces();
                    cls.ctm.ctm_job_pv.Province_id = reader.IsDBNull(175) ? defaultNum : reader.GetInt32(175);
                    cls.ctm.ctm_job_pv.Province_name = reader.IsDBNull(176) ? defaultString : reader.GetString(176);

                    cls.ctm.Cust_Job_country = reader.IsDBNull(177) ? defaultString : reader.GetString(177);
                    cls.ctm.Cust_Job_zipcode = reader.IsDBNull(178) ? defaultString : reader.GetString(178);
                    cls.ctm.Cust_Job_tel = reader.IsDBNull(179) ? defaultString : reader.GetString(179);
                    cls.ctm.Cust_Job_email = reader.IsDBNull(180) ? defaultString : reader.GetString(180);
                    cls.ctm.Cust_Home_address_no = reader.IsDBNull(181) ? defaultString : reader.GetString(181);
                    cls.ctm.Cust_Home_vilage = reader.IsDBNull(182) ? defaultString : reader.GetString(182);
                    cls.ctm.Cust_Home_vilage_no = reader.IsDBNull(183) ? defaultString : reader.GetString(183);
                    cls.ctm.Cust_Home_alley = reader.IsDBNull(184) ? defaultString : reader.GetString(184);
                    cls.ctm.Cust_Home_road = reader.IsDBNull(185) ? defaultString : reader.GetString(185);
                    cls.ctm.Cust_Home_subdistrict = reader.IsDBNull(186) ? defaultString : reader.GetString(186);
                    cls.ctm.Cust_Home_district = reader.IsDBNull(187) ? defaultString : reader.GetString(187);

                    cls.ctm.ctm_home_pv = new TH_Provinces();
                    cls.ctm.ctm_home_pv.Province_id = reader.IsDBNull(188) ? defaultNum : reader.GetInt32(188);
                    cls.ctm.ctm_home_pv.Province_name = reader.IsDBNull(189) ? defaultString : reader.GetString(189);

                    cls.ctm.Cust_Home_country = reader.IsDBNull(190) ? defaultString : reader.GetString(190);
                    cls.ctm.Cust_Home_zipcode = reader.IsDBNull(191) ? defaultString : reader.GetString(191);
                    cls.ctm.Cust_Home_tel = reader.IsDBNull(192) ? defaultString : reader.GetString(192);
                    cls.ctm.Cust_Home_GPS_Latitude = reader.IsDBNull(193) ? defaultString : reader.GetString(193);
                    cls.ctm.Cust_Home_GPS_Longitude = reader.IsDBNull(194) ? defaultString : reader.GetString(194);

                    cls.ctm.ctm_home_stt = new Base_Home_Status();
                    cls.ctm.ctm_home_stt.Home_status_id = reader.IsDBNull(195) ? defaultNum : reader.GetInt32(195);
                    cls.ctm.ctm_home_stt.Home_status_name = reader.IsDBNull(196) ? defaultString : reader.GetString(196);

                    cls.ctm.Cust_Idcard_address_no = reader.IsDBNull(197) ? defaultString : reader.GetString(197);
                    cls.ctm.Cust_Idcard_vilage = reader.IsDBNull(198) ? defaultString : reader.GetString(198);
                    cls.ctm.Cust_Idcard_vilage_no = reader.IsDBNull(199) ? defaultString : reader.GetString(199);
                    cls.ctm.Cust_Idcard_alley = reader.IsDBNull(200) ? defaultString : reader.GetString(200);
                    cls.ctm.Cust_Idcard_road = reader.IsDBNull(201) ? defaultString : reader.GetString(201);
                    cls.ctm.Cust_Idcard_subdistrict = reader.IsDBNull(202) ? defaultString : reader.GetString(202);
                    cls.ctm.Cust_Idcard_district = reader.IsDBNull(203) ? defaultString : reader.GetString(203);

                    cls.ctm.ctm_idcard_pv = new TH_Provinces();
                    cls.ctm.ctm_idcard_pv.Province_id = reader.IsDBNull(204) ? defaultNum : reader.GetInt32(204);
                    cls.ctm.ctm_idcard_pv.Province_name = reader.IsDBNull(205) ? defaultString : reader.GetString(205);

                    cls.ctm.Cust_Idcard_country = reader.IsDBNull(206) ? defaultString : reader.GetString(206);
                    cls.ctm.Cust_Idcard_zipcode = reader.IsDBNull(207) ? defaultString : reader.GetString(207);
                    cls.ctm.Cust_Idcard_tel = reader.IsDBNull(208) ? defaultString : reader.GetString(208);

                    cls.ctm.ctm_idcard_stt = new Base_Home_Status();
                    cls.ctm.ctm_idcard_stt.Home_status_id = reader.IsDBNull(209) ? defaultNum : reader.GetInt32(209);
                    cls.ctm.ctm_idcard_stt.Home_status_name = reader.IsDBNull(210) ? defaultString : reader.GetString(210);

                    cls.ctm.Cust_Current_address_no = reader.IsDBNull(211) ? defaultString : reader.GetString(211);
                    cls.ctm.Cust_Current_vilage = reader.IsDBNull(212) ? defaultString : reader.GetString(212);
                    cls.ctm.Cust_Current_vilage_no = reader.IsDBNull(213) ? defaultString : reader.GetString(213);
                    cls.ctm.Cust_Current_alley = reader.IsDBNull(214) ? defaultString : reader.GetString(214);
                    cls.ctm.Cust_Current_road = reader.IsDBNull(215) ? defaultString : reader.GetString(215);
                    cls.ctm.Cust_Current_subdistrict = reader.IsDBNull(216) ? defaultString : reader.GetString(216);
                    cls.ctm.Cust_Current_district = reader.IsDBNull(217) ? defaultString : reader.GetString(217);

                    cls.ctm.ctm_current_pv = new TH_Provinces();
                    cls.ctm.ctm_current_pv.Province_id = reader.IsDBNull(218) ? defaultNum : reader.GetInt32(218);
                    cls.ctm.ctm_current_pv.Province_name = reader.IsDBNull(219) ? defaultString : reader.GetString(219);

                    cls.ctm.Cust_Current_country = reader.IsDBNull(220) ? defaultString : reader.GetString(220);
                    cls.ctm.Cust_Current_zipcode = reader.IsDBNull(221) ? defaultString : reader.GetString(221);
                    cls.ctm.Cust_Current_tel = reader.IsDBNull(222) ? defaultString : reader.GetString(222);

                    cls.ctm.ctm_current_stt = new Base_Home_Status();
                    cls.ctm.ctm_current_stt.Home_status_id = reader.IsDBNull(223) ? defaultNum : reader.GetInt32(223);
                    cls.ctm.ctm_current_stt.Home_status_name = reader.IsDBNull(224) ? defaultString : reader.GetString(224);

                    cls.ctm.Cust_save_date = reader.IsDBNull(225) ? defaultString : reader.GetString(225);
                }

                return cls.ctm;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Customer_Manager --> getCustomersLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Customer_Manager --> getCustomersLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool addCustomersLeasing(Car_Leasings cls,Customers ctm)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// <summary>
                /// :: StoredProcedure :: [ i_car_leasings_customer ] :: 
                /// i_car_leasings_customer ( IN i_Leasing_id VARCHAR(50), IN i_Cust_id VARCHAR(50), IN i_Cust_Idcard VARCHAR(20), IN i_Cust_Fname VARCHAR(255), IN i_Cust_LName VARCHAR(255),
	            ///   IN i_Cust_B_date DATE, IN i_Cust_Age INT(11), IN i_Cust_Idcard_without VARCHAR(255), IN i_Cust_Idcard_start DATE,
	            ///   IN i_Cust_Idcard_expire DATE, IN i_Cust_Nationality_id INT(11), IN i_Cust_Origin_id INT(11), IN i_Cust_Tel VARCHAR(255),
	            ///   IN i_Cust_Email VARCHAR(255), IN i_Cust_Status_id INT(11), IN i_Cust_Marry_idcard VARCHAR(20), IN i_Cust_Marry_Fname VARCHAR(255),
	            ///   IN i_Cust_Marry_Lname VARCHAR(255), IN i_Cust_Marry_Nationality INT(11), IN i_Cust_Marry_Origin INT(11), IN i_Cust_Marry_Address_no VARCHAR(255),
	            ///   IN i_Cust_Marry_vilage VARCHAR(255), IN i_Cust_Marry_vilage_no VARCHAR(255), IN i_Cust_Marry_alley VARCHAR(255), IN i_Cust_Marry_road VARCHAR(255),
	            ///   IN i_Cust_Marry_subdistrict VARCHAR(255), IN i_Cust_Marry_district VARCHAR(255), IN i_Cust_Marry_province_id INT(11), IN i_Cust_Marry_country VARCHAR(255),
	            ///   IN i_Cust_Marry_zipcode VARCHAR(255), IN i_Cust_Marry_tel VARCHAR(255), IN i_Cust_Marry_email VARCHAR(255), IN i_Cust_Marry_job VARCHAR(255),
	            ///   IN i_Cust_Marry_job_position VARCHAR(255), IN i_Cust_Marry_job_long INT(11), IN i_Cust_Marry_job_salary DOUBLE(10,2), IN i_Cust_Marry_job_local_name VARCHAR(255),
	            ///   IN i_Cust_Marry_job_address_no VARCHAR(255), IN i_Cust_Marry_job_vilage VARCHAR(255), IN i_Cust_Marry_job_vilage_no VARCHAR(255), IN i_Cust_Marry_job_alley VARCHAR(255),
	            ///   IN i_Cust_Marry_job_road VARCHAR(255), IN i_Cust_Marry_job_subdistrict VARCHAR(255), IN i_Cust_Marry_job_district VARCHAR(255), IN i_Cust_Marry_job_province_id INT(11),
	            ///   IN i_Cust_Marry_job_zipcode VARCHAR(255), IN i_Cust_Marry_job_tel VARCHAR(255), IN i_Cust_Job VARCHAR(255), IN i_Cust_Job_position VARCHAR(255),
	            ///   IN i_Cust_Job_long INT(11), IN i_Cust_Job_salary DOUBLE(10,2), IN i_Cust_Job_local_name VARCHAR(255), IN i_Cust_Job_address_no VARCHAR(255),
	            ///   IN i_Cust_Job_vilage VARCHAR(255), IN i_Cust_Job_vilage_no VARCHAR(255), IN i_Cust_Job_alley VARCHAR(255), IN i_Cust_Job_road VARCHAR(255),
	            ///   IN i_Cust_Job_subdistrict VARCHAR(255), IN i_Cust_Job_district VARCHAR(255), IN i_Cust_Job_province_id INT(11), IN i_Cust_Job_country VARCHAR(255),
	            ///   IN i_Cust_Job_zipcode VARCHAR(255), IN i_Cust_Job_tel VARCHAR(255), IN i_Cust_Job_email VARCHAR(255), IN i_Cust_Home_address_no VARCHAR(255),
	            ///   IN i_Cust_Home_vilage VARCHAR(255), IN i_Cust_Home_vilage_no VARCHAR(255), IN i_Cust_Home_alley VARCHAR(255), IN i_Cust_Home_road VARCHAR(255),
	            ///   IN i_Cust_Home_subdistrict VARCHAR(255), IN i_Cust_Home_district VARCHAR(255), IN i_Cust_Home_province_id INT(11), IN i_Cust_Home_country VARCHAR(255),
	            ///   IN i_Cust_Home_zipcode VARCHAR(255), IN i_Cust_Home_tel VARCHAR(255), IN i_Cust_Home_GPS_Latitude VARCHAR(255), IN i_Cust_Home_GPS_Longitude VARCHAR(255),
	            ///   IN i_Cust_Home_Status_id INT(11), IN i_Cust_Idcard_address_no VARCHAR(255), IN i_Cust_Idcard_vilage VARCHAR(255), IN i_Cust_Idcard_vilage_no VARCHAR(255),
	            ///   IN i_Cust_Idcard_alley VARCHAR(255), IN i_Cust_Idcard_road VARCHAR(255), IN i_Cust_Idcard_subdistrict VARCHAR(255), IN i_Cust_Idcard_district VARCHAR(255),
	            ///   IN i_Cust_Idcard_province_id INT(11), IN i_Cust_Idcard_country VARCHAR(255), IN i_Cust_Idcard_zipcode VARCHAR(255), IN i_Cust_Idcard_tel VARCHAR(255),
	            ///   IN i_Cust_Idcard_Status_id INT(11), IN i_Cust_Current_address_no VARCHAR(255), IN i_Cust_Current_vilage VARCHAR(255), IN i_Cust_Current_vilage_no VARCHAR(255),
	            ///   IN i_Cust_Current_alley VARCHAR(255), IN i_Cust_Current_road VARCHAR(255), IN i_Cust_Current_subdistrict VARCHAR(255), IN i_Cust_Current_district VARCHAR(255),
	            ///   IN i_Cust_Current_province_id INT(11), IN i_Cust_Current_country VARCHAR(255), IN i_Cust_Current_zipcode VARCHAR(255), IN i_Cust_Current_tel VARCHAR(255),
	            ///   IN i_Cust_Current_Status_id INT(11))
                /// </summary>

                con.Open();
                MySqlCommand cmd = new MySqlCommand("i_car_leasings_customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Cust_id", ctm.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard", ctm.Cust_Idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", ctm.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", ctm.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", ctm.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_Age", ctm.Cust_Age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", ctm.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", ctm.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", ctm.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality_id", ctm.ctm_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Origin_id", ctm.ctm_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Tel", ctm.Cust_Tel);
                cmd.Parameters.AddWithValue("@i_Cust_Email", ctm.Cust_Email);
                cmd.Parameters.AddWithValue("@i_Cust_Status_id", ctm.ctm_pstt.person_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_idcard", ctm.Cust_Marry_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Fname", ctm.Cust_Marry_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Lname", ctm.Cust_Marry_Lname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Nationality", ctm.ctm_marry_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Origin", ctm.ctm_marry_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Address_no", ctm.Cust_Marry_Address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage", ctm.Cust_Marry_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage_no", ctm.Cust_Marry_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_alley", ctm.Cust_Marry_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_road", ctm.Cust_Marry_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_subdistrict", ctm.Cust_Marry_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_district", ctm.Cust_Marry_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province_id", ctm.ctm_marry_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_country", ctm.Cust_Marry_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_zipcode", ctm.Cust_Marry_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_tel", ctm.Cust_Marry_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_email", ctm.Cust_Marry_email);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job", ctm.Cust_Marry_job);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_position", ctm.Cust_Marry_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_long", ctm.Cust_Marry_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_salary", ctm.Cust_Marry_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_local_name", ctm.Cust_Marry_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_address_no", ctm.Cust_Marry_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage", ctm.Cust_Marry_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage_no", ctm.Cust_Marry_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_alley", ctm.Cust_Marry_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_road", ctm.Cust_Marry_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_subdistrict", ctm.Cust_Marry_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_district", ctm.Cust_Marry_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province_id", ctm.ctm_marry_job_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_country", ctm.Cust_Marry_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_zipcode", ctm.Cust_Marry_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_tel", ctm.Cust_Marry_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job", ctm.Cust_Job);
                cmd.Parameters.AddWithValue("@i_Cust_Job_position", ctm.Cust_Job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Job_long", ctm.Cust_Job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Job_salary", ctm.Cust_Job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Job_local_name", ctm.Cust_Job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Job_address_no", ctm.Cust_Job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage", ctm.Cust_Job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage_no", ctm.Cust_Job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_alley", ctm.Cust_Job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Job_road", ctm.Cust_Job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Job_subdistrict", ctm.Cust_Job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Job_district", ctm.Cust_Job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Job_province_id", ctm.ctm_job_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Job_country", ctm.Cust_Job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Job_zipcode", ctm.Cust_Job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Job_tel", ctm.Cust_Job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job_email", ctm.Cust_Job_email);
                cmd.Parameters.AddWithValue("@i_Cust_Home_address_no", ctm.Cust_Home_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage", ctm.Cust_Home_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage_no", ctm.Cust_Home_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_alley", ctm.Cust_Home_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Home_road", ctm.Cust_Home_road);
                cmd.Parameters.AddWithValue("@i_Cust_Home_subdistrict", ctm.Cust_Home_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Home_district", ctm.Cust_Home_district);
                cmd.Parameters.AddWithValue("@i_Cust_Home_province_id", ctm.ctm_home_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Home_country", ctm.Cust_Home_country);
                cmd.Parameters.AddWithValue("@i_Cust_Home_zipcode", ctm.Cust_Home_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Home_tel", ctm.Cust_Home_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Latitude", ctm.Cust_Home_GPS_Latitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Longitude", ctm.Cust_Home_GPS_Longitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_Status_id", ctm.ctm_home_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_address_no", ctm.Cust_Idcard_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage", ctm.Cust_Idcard_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage_no", ctm.Cust_Idcard_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_alley", ctm.Cust_Idcard_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_road", ctm.Cust_Idcard_road);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_subdistrict", ctm.Cust_Idcard_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_district", ctm.Cust_Idcard_district);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province_id", ctm.ctm_idcard_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_country", ctm.Cust_Idcard_country);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_zipcode", ctm.Cust_Idcard_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_tel", ctm.Cust_Idcard_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_Status_id", ctm.ctm_idcard_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_address_no", ctm.Cust_Current_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage", ctm.Cust_Current_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage_no", ctm.Cust_Current_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_alley", ctm.Cust_Current_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Current_road", ctm.Cust_Current_road);
                cmd.Parameters.AddWithValue("@i_Cust_Current_subdistrict", ctm.Cust_Current_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Current_district", ctm.Cust_Current_district);
                cmd.Parameters.AddWithValue("@i_Cust_Current_province_id", ctm.ctm_current_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_country", ctm.Cust_Current_country);
                cmd.Parameters.AddWithValue("@i_Cust_Current_zipcode", ctm.Cust_Current_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Current_tel", ctm.Cust_Current_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Current_Status_id", ctm.ctm_current_stt.Home_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Customer_Manager --> addCustomersLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Customer_Manager --> addCustomersLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool editCustomersLeasing(Car_Leasings cls, Customers ctm)
        {
            MySqlConnection con = MySQLConnection.connectionMySQL();
            try
            {
                /// <summary>
                /// :: StoredProcedure :: [ u_customers ] :: 
                /// u_customers ( IN i_Cust_id VARCHAR(50), IN i_Cust_Idcard VARCHAR(20), IN i_Cust_Fname VARCHAR(255), IN i_Cust_LName VARCHAR(255),
                ///   IN i_Cust_B_date DATE, IN i_Cust_Age INT(11), IN i_Cust_Idcard_without VARCHAR(255), IN i_Cust_Idcard_start DATE,
                ///   IN i_Cust_Idcard_expire DATE, IN i_Cust_Nationality_id INT(11), IN i_Cust_Origin_id INT(11), IN i_Cust_Tel VARCHAR(255),
                ///   IN i_Cust_Email VARCHAR(255), IN i_Cust_Status_id INT(11), IN i_Cust_Marry_idcard VARCHAR(20), IN i_Cust_Marry_Fname VARCHAR(255),
                ///   IN i_Cust_Marry_Lname VARCHAR(255), IN i_Cust_Marry_Nationality INT(11), IN i_Cust_Marry_Origin INT(11), IN i_Cust_Marry_Address_no VARCHAR(255),
                ///   IN i_Cust_Marry_vilage VARCHAR(255), IN i_Cust_Marry_vilage_no VARCHAR(255), IN i_Cust_Marry_alley VARCHAR(255), IN i_Cust_Marry_road VARCHAR(255),
                ///   IN i_Cust_Marry_subdistrict VARCHAR(255), IN i_Cust_Marry_district VARCHAR(255), IN i_Cust_Marry_province_id INT(11), IN i_Cust_Marry_country VARCHAR(255),
                ///   IN i_Cust_Marry_zipcode VARCHAR(255), IN i_Cust_Marry_tel VARCHAR(255), IN i_Cust_Marry_email VARCHAR(255), IN i_Cust_Marry_job VARCHAR(255),
                ///   IN i_Cust_Marry_job_position VARCHAR(255), IN i_Cust_Marry_job_long INT(11), IN i_Cust_Marry_job_salary DOUBLE(10,2), IN i_Cust_Marry_job_local_name VARCHAR(255),
                ///   IN i_Cust_Marry_job_address_no VARCHAR(255), IN i_Cust_Marry_job_vilage VARCHAR(255), IN i_Cust_Marry_job_vilage_no VARCHAR(255), IN i_Cust_Marry_job_alley VARCHAR(255),
                ///   IN i_Cust_Marry_job_road VARCHAR(255), IN i_Cust_Marry_job_subdistrict VARCHAR(255), IN i_Cust_Marry_job_district VARCHAR(255), IN i_Cust_Marry_job_province_id INT(11),
                ///   IN i_Cust_Marry_job_zipcode VARCHAR(255), IN i_Cust_Marry_job_tel VARCHAR(255), IN i_Cust_Job VARCHAR(255), IN i_Cust_Job_position VARCHAR(255),
                ///   IN i_Cust_Job_long INT(11), IN i_Cust_Job_salary DOUBLE(10,2), IN i_Cust_Job_local_name VARCHAR(255), IN i_Cust_Job_address_no VARCHAR(255),
                ///   IN i_Cust_Job_vilage VARCHAR(255), IN i_Cust_Job_vilage_no VARCHAR(255), IN i_Cust_Job_alley VARCHAR(255), IN i_Cust_Job_road VARCHAR(255),
                ///   IN i_Cust_Job_subdistrict VARCHAR(255), IN i_Cust_Job_district VARCHAR(255), IN i_Cust_Job_province_id INT(11), IN i_Cust_Job_country VARCHAR(255),
                ///   IN i_Cust_Job_zipcode VARCHAR(255), IN i_Cust_Job_tel VARCHAR(255), IN i_Cust_Job_email VARCHAR(255), IN i_Cust_Home_address_no VARCHAR(255),
                ///   IN i_Cust_Home_vilage VARCHAR(255), IN i_Cust_Home_vilage_no VARCHAR(255), IN i_Cust_Home_alley VARCHAR(255), IN i_Cust_Home_road VARCHAR(255),
                ///   IN i_Cust_Home_subdistrict VARCHAR(255), IN i_Cust_Home_district VARCHAR(255), IN i_Cust_Home_province_id INT(11), IN i_Cust_Home_country VARCHAR(255),
                ///   IN i_Cust_Home_zipcode VARCHAR(255), IN i_Cust_Home_tel VARCHAR(255), IN i_Cust_Home_GPS_Latitude VARCHAR(255), IN i_Cust_Home_GPS_Longitude VARCHAR(255),
                ///   IN i_Cust_Home_Status_id INT(11), IN i_Cust_Idcard_address_no VARCHAR(255), IN i_Cust_Idcard_vilage VARCHAR(255), IN i_Cust_Idcard_vilage_no VARCHAR(255),
                ///   IN i_Cust_Idcard_alley VARCHAR(255), IN i_Cust_Idcard_road VARCHAR(255), IN i_Cust_Idcard_subdistrict VARCHAR(255), IN i_Cust_Idcard_district VARCHAR(255),
                ///   IN i_Cust_Idcard_province_id INT(11), IN i_Cust_Idcard_country VARCHAR(255), IN i_Cust_Idcard_zipcode VARCHAR(255), IN i_Cust_Idcard_tel VARCHAR(255),
                ///   IN i_Cust_Idcard_Status_id INT(11), IN i_Cust_Current_address_no VARCHAR(255), IN i_Cust_Current_vilage VARCHAR(255), IN i_Cust_Current_vilage_no VARCHAR(255),
                ///   IN i_Cust_Current_alley VARCHAR(255), IN i_Cust_Current_road VARCHAR(255), IN i_Cust_Current_subdistrict VARCHAR(255), IN i_Cust_Current_district VARCHAR(255),
                ///   IN i_Cust_Current_province_id INT(11), IN i_Cust_Current_country VARCHAR(255), IN i_Cust_Current_zipcode VARCHAR(255), IN i_Cust_Current_tel VARCHAR(255),
                ///   IN i_Cust_Current_Status_id INT(11))
                /// </summary>

                con.Open();
                MySqlCommand cmd = new MySqlCommand("u_car_leasings_customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@i_Leasing_id", cls.Leasing_id);
                cmd.Parameters.AddWithValue("@i_Cust_id", ctm.Cust_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard", ctm.Cust_Idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Fname", ctm.Cust_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_LName", ctm.Cust_LName);
                cmd.Parameters.AddWithValue("@i_Cust_B_date", ctm.Cust_B_date);
                cmd.Parameters.AddWithValue("@i_Cust_Age", ctm.Cust_Age);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_without", ctm.Cust_Idcard_without);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_start", ctm.Cust_Idcard_start);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_expire", ctm.Cust_Idcard_expire);
                cmd.Parameters.AddWithValue("@i_Cust_Nationality_id", ctm.ctm_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Origin_id", ctm.ctm_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Tel", ctm.Cust_Tel);
                cmd.Parameters.AddWithValue("@i_Cust_Email", ctm.Cust_Email);
                cmd.Parameters.AddWithValue("@i_Cust_Status_id", ctm.ctm_pstt.person_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_idcard", ctm.Cust_Marry_idcard);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Fname", ctm.Cust_Marry_Fname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Lname", ctm.Cust_Marry_Lname);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Nationality", ctm.ctm_marry_ntnlt.Nationality_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Origin", ctm.ctm_marry_org.Origin_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_Address_no", ctm.Cust_Marry_Address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage", ctm.Cust_Marry_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_vilage_no", ctm.Cust_Marry_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_alley", ctm.Cust_Marry_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_road", ctm.Cust_Marry_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_subdistrict", ctm.Cust_Marry_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_district", ctm.Cust_Marry_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province_id", ctm.ctm_marry_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_country", ctm.Cust_Marry_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_zipcode", ctm.Cust_Marry_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_tel", ctm.Cust_Marry_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_email", ctm.Cust_Marry_email);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job", ctm.Cust_Marry_job);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_position", ctm.Cust_Marry_job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_long", ctm.Cust_Marry_job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_salary", ctm.Cust_Marry_job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_local_name", ctm.Cust_Marry_job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_address_no", ctm.Cust_Marry_job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage", ctm.Cust_Marry_job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_vilage_no", ctm.Cust_Marry_job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_alley", ctm.Cust_Marry_job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_road", ctm.Cust_Marry_job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_subdistrict", ctm.Cust_Marry_job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_district", ctm.Cust_Marry_job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province_id", ctm.ctm_marry_job_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_country", ctm.Cust_Marry_job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_zipcode", ctm.Cust_Marry_job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_tel", ctm.Cust_Marry_job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job", ctm.Cust_Job);
                cmd.Parameters.AddWithValue("@i_Cust_Job_position", ctm.Cust_Job_position);
                cmd.Parameters.AddWithValue("@i_Cust_Job_long", ctm.Cust_Job_long);
                cmd.Parameters.AddWithValue("@i_Cust_Job_salary", ctm.Cust_Job_salary);
                cmd.Parameters.AddWithValue("@i_Cust_Job_local_name", ctm.Cust_Job_local_name);
                cmd.Parameters.AddWithValue("@i_Cust_Job_address_no", ctm.Cust_Job_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage", ctm.Cust_Job_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Job_vilage_no", ctm.Cust_Job_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Job_alley", ctm.Cust_Job_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Job_road", ctm.Cust_Job_road);
                cmd.Parameters.AddWithValue("@i_Cust_Job_subdistrict", ctm.Cust_Job_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Job_district", ctm.Cust_Job_district);
                cmd.Parameters.AddWithValue("@i_Cust_Job_province_id", ctm.ctm_job_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Job_country", ctm.Cust_Job_country);
                cmd.Parameters.AddWithValue("@i_Cust_Job_zipcode", ctm.Cust_Job_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Job_tel", ctm.Cust_Job_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Job_email", ctm.Cust_Job_email);
                cmd.Parameters.AddWithValue("@i_Cust_Home_address_no", ctm.Cust_Home_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage", ctm.Cust_Home_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Home_vilage_no", ctm.Cust_Home_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Home_alley", ctm.Cust_Home_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Home_road", ctm.Cust_Home_road);
                cmd.Parameters.AddWithValue("@i_Cust_Home_subdistrict", ctm.Cust_Home_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Home_district", ctm.Cust_Home_district);
                cmd.Parameters.AddWithValue("@i_Cust_Home_province_id", ctm.ctm_home_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Home_country", ctm.Cust_Home_country);
                cmd.Parameters.AddWithValue("@i_Cust_Home_zipcode", ctm.Cust_Home_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Home_tel", ctm.Cust_Home_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Latitude", ctm.Cust_Home_GPS_Latitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_GPS_Longitude", ctm.Cust_Home_GPS_Longitude);
                cmd.Parameters.AddWithValue("@i_Cust_Home_Status_id", ctm.ctm_home_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_address_no", ctm.Cust_Idcard_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage", ctm.Cust_Idcard_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_vilage_no", ctm.Cust_Idcard_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_alley", ctm.Cust_Idcard_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_road", ctm.Cust_Idcard_road);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_subdistrict", ctm.Cust_Idcard_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_district", ctm.Cust_Idcard_district);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province_id", ctm.ctm_idcard_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_country", ctm.Cust_Idcard_country);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_zipcode", ctm.Cust_Idcard_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_tel", ctm.Cust_Idcard_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_Status_id", ctm.ctm_idcard_stt.Home_status_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_address_no", ctm.Cust_Current_address_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage", ctm.Cust_Current_vilage);
                cmd.Parameters.AddWithValue("@i_Cust_Current_vilage_no", ctm.Cust_Current_vilage_no);
                cmd.Parameters.AddWithValue("@i_Cust_Current_alley", ctm.Cust_Current_alley);
                cmd.Parameters.AddWithValue("@i_Cust_Current_road", ctm.Cust_Current_road);
                cmd.Parameters.AddWithValue("@i_Cust_Current_subdistrict", ctm.Cust_Current_subdistrict);
                cmd.Parameters.AddWithValue("@i_Cust_Current_district", ctm.Cust_Current_district);
                cmd.Parameters.AddWithValue("@i_Cust_Current_province_id", ctm.ctm_current_pv.Province_id);
                cmd.Parameters.AddWithValue("@i_Cust_Current_country", ctm.Cust_Current_country);
                cmd.Parameters.AddWithValue("@i_Cust_Current_zipcode", ctm.Cust_Current_zipcode);
                cmd.Parameters.AddWithValue("@i_Cust_Current_tel", ctm.Cust_Current_tel);
                cmd.Parameters.AddWithValue("@i_Cust_Current_Status_id", ctm.ctm_current_stt.Home_status_id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                error = "MysqlException ==> Managers_Leasings --> Car_Leasings_Customer_Manager --> editCustomersLeasing() ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            catch (Exception ex)
            {
                error = "Exception ==> Managers_Leasings --> Car_Leasings_Customer_Manager --> editCustomersLeasing( ";
                Log_Error._writeErrorFile(error, ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}