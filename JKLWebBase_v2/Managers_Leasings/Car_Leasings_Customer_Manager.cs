using System;
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
                    cls.bs_cpn.Company_province = reader.IsDBNull(19) ? defaultString : reader.GetString(19);
                    cls.bs_cpn.Company_country = reader.IsDBNull(20) ? defaultString : reader.GetString(20);
                    cls.bs_cpn.Company_zipcode = reader.IsDBNull(21) ? defaultString : reader.GetString(21);
                    cls.bs_cpn.Company_tel = reader.IsDBNull(22) ? defaultString : reader.GetString(22);
                    cls.bs_cpn.Company_Save_date = reader.IsDBNull(23) ? defaultString : reader.GetString(23);

                    cls.bs_zn = new Base_Zone_Service();
                    cls.bs_zn.Zone_id = reader.IsDBNull(24) ? defaultNum : reader.GetInt32(24);
                    cls.bs_zn.Zone_code = reader.IsDBNull(25) ? defaultString : reader.GetString(25);
                    cls.bs_zn.Zone_name = reader.IsDBNull(26) ? defaultString : reader.GetString(26);

                    cls.bs_ct = new Base_Courts();
                    cls.bs_ct.Court_id = reader.IsDBNull(27) ? defaultNum : reader.GetInt32(27);
                    cls.bs_ct.Court_name = reader.IsDBNull(28) ? defaultString : reader.GetString(28);

                    cls.PeReT = reader.IsDBNull(29) ? defaultString : reader.GetString(29);

                    cls.TotalPaymentTime = reader.IsDBNull(30) ? defaultNum : reader.GetInt32(30);
                    cls.Total_require = reader.IsDBNull(31) ? defaultNum : reader.GetDouble(31);
                    cls.Vat_rate = reader.IsDBNull(32) ? defaultNum : reader.GetDouble(32);
                    cls.Interest_rate = reader.IsDBNull(33) ? defaultNum : reader.GetDouble(33);
                    cls.Total_period = reader.IsDBNull(34) ? defaultNum : reader.GetInt32(34);
                    cls.Total_sum = reader.IsDBNull(35) ? defaultNum : reader.GetDouble(35);
                    cls.Total_Interest = reader.IsDBNull(36) ? defaultNum : reader.GetDouble(36);
                    cls.Total_Tax = reader.IsDBNull(37) ? defaultNum : reader.GetDouble(37);
                    cls.Total_leasing = reader.IsDBNull(38) ? defaultNum : reader.GetDouble(38);
                    cls.Total_Net_leasing = reader.IsDBNull(39) ? defaultNum : reader.GetDouble(39);
                    cls.Period_cal = reader.IsDBNull(40) ? defaultNum : reader.GetDouble(40);
                    cls.Period_interst = reader.IsDBNull(41) ? defaultNum : reader.GetDouble(41);
                    cls.Period_tax = reader.IsDBNull(42) ? defaultNum : reader.GetDouble(42);
                    cls.Period_pure = reader.IsDBNull(43) ? defaultNum : reader.GetDouble(43);
                    cls.Period_payment = reader.IsDBNull(44) ? defaultNum : reader.GetDouble(44);
                    cls.Period_require = reader.IsDBNull(45) ? defaultNum : reader.GetDouble(45);
                    cls.Total_period_length = reader.IsDBNull(46) ? defaultString : reader.GetString(46);
                    cls.Total_period_lose = reader.IsDBNull(47) ? defaultNum : reader.GetInt32(47);
                    cls.Total_period_left = reader.IsDBNull(48) ? defaultNum : reader.GetInt32(48);
                    cls.Total_payment_left = reader.IsDBNull(49) ? defaultNum : reader.GetDouble(49);
                    cls.Payment_schedule = reader.IsDBNull(50) ? defaultNum : reader.GetInt32(50);
                    cls.First_payment_date = reader.IsDBNull(51) ? defaultString : reader.GetString(51);
                    cls.Car_register_date = reader.IsDBNull(52) ? defaultString : reader.GetString(52);
                    cls.Car_license_plate = reader.IsDBNull(53) ? defaultString : reader.GetString(53);
                    cls.Car_license_plate_province = reader.IsDBNull(54) ? defaultString : reader.GetString(54);
                    cls.Car_type = reader.IsDBNull(55) ? defaultString : reader.GetString(55);
                    cls.Car_feature = reader.IsDBNull(56) ? defaultString : reader.GetString(56);

                    cls.bs_cbrn = new Base_Car_Brands();
                    cls.bs_cbrn.car_brand_id = reader.IsDBNull(57) ? defaultNum : reader.GetInt32(57);
                    cls.bs_cbrn.car_brand_name_eng = reader.IsDBNull(58) ? defaultString : reader.GetString(58);
                    cls.bs_cbrn.car_brand_name_th = reader.IsDBNull(59) ? defaultString : reader.GetString(59);

                    cls.Car_model = reader.IsDBNull(60) ? defaultString : reader.GetString(60);
                    cls.Car_year = reader.IsDBNull(61) ? defaultString : reader.GetString(61);
                    cls.Car_color = reader.IsDBNull(62) ? defaultString : reader.GetString(62);
                    cls.Car_engine_no = reader.IsDBNull(63) ? defaultString : reader.GetString(63);
                    cls.Car_engine_no_at = reader.IsDBNull(64) ? defaultString : reader.GetString(64);
                    cls.Car_engine_brand = reader.IsDBNull(65) ? defaultString : reader.GetString(65);
                    cls.Car_chassis_no = reader.IsDBNull(66) ? defaultString : reader.GetString(66);
                    cls.Car_chassis_no_at = reader.IsDBNull(67) ? defaultString : reader.GetString(67);
                    cls.Car_fual_type = reader.IsDBNull(68) ? defaultString : reader.GetString(68);
                    cls.Car_gas_No = reader.IsDBNull(69) ? defaultString : reader.GetString(69);
                    cls.Car_used_id = reader.IsDBNull(70) ? defaultNum : reader.GetInt32(70);
                    cls.Car_distance = reader.IsDBNull(71) ? defaultNum : reader.GetDouble(71);
                    cls.Car_next_register_date = reader.IsDBNull(72) ? defaultString : reader.GetString(72);
                    cls.Car_tax_value = reader.IsDBNull(73) ? defaultNum : reader.GetDouble(73);
                    cls.Car_credits = reader.IsDBNull(74) ? defaultString : reader.GetString(74);
                    cls.Car_agent = reader.IsDBNull(75) ? defaultString : reader.GetString(75);
                    cls.Car_old_owner = reader.IsDBNull(76) ? defaultString : reader.GetString(76);
                    cls.Car_old_owner_idcard = reader.IsDBNull(77) ? defaultString : reader.GetString(77);
                    cls.Car_old_owner_b_date = reader.IsDBNull(78) ? defaultString : reader.GetString(78);
                    cls.Car_old_owner_address_no = reader.IsDBNull(79) ? defaultString : reader.GetString(79);
                    cls.Car_old_owner_vilage = reader.IsDBNull(80) ? defaultString : reader.GetString(80);
                    cls.Car_old_owner_vilage_no = reader.IsDBNull(81) ? defaultString : reader.GetString(81);
                    cls.Car_old_owner_alley = reader.IsDBNull(82) ? defaultString : reader.GetString(82);
                    cls.Car_old_owner_road = reader.IsDBNull(83) ? defaultString : reader.GetString(83);
                    cls.Car_old_owner_subdistrict = reader.IsDBNull(84) ? defaultString : reader.GetString(84);
                    cls.Car_old_owner_district = reader.IsDBNull(85) ? defaultString : reader.GetString(85);
                    cls.Car_old_owner_province = reader.IsDBNull(86) ? defaultString : reader.GetString(86);
                    cls.Car_old_owner_contry = reader.IsDBNull(87) ? defaultString : reader.GetString(87);
                    cls.Car_old_owner_zipcode = reader.IsDBNull(88) ? defaultString : reader.GetString(88);

                    cls.tent_car = new Base_Tents_Car();
                    cls.tent_car.Tent_car_id = reader.IsDBNull(89) ? defaultNum : reader.GetInt32(89);
                    cls.tent_car.Tent_name = reader.IsDBNull(90) ? defaultString : reader.GetString(90);
                    cls.tent_car.Tent_local = reader.IsDBNull(91) ? defaultString : reader.GetString(91);

                    cls.Cheque_receiver = reader.IsDBNull(92) ? defaultString : reader.GetString(92);
                    cls.Cheque_bank = reader.IsDBNull(93) ? defaultString : reader.GetString(93);
                    cls.Cheque_bank_branch = reader.IsDBNull(94) ? defaultString : reader.GetString(94);
                    cls.Cheque_number = reader.IsDBNull(95) ? defaultString : reader.GetString(95);
                    cls.Cheque_sum = reader.IsDBNull(96) ? defaultNum : reader.GetDouble(96);
                    cls.Cheque_receive_date = reader.IsDBNull(97) ? defaultString : reader.GetString(97);
                    cls.Guarantee = reader.IsDBNull(98) ? defaultString : reader.GetString(98);

                    cls.bs_ls_stt = new Base_Leasing_Status();
                    cls.bs_ls_stt.Contract_Status_id = reader.IsDBNull(99) ? defaultNum : reader.GetInt32(99);
                    cls.bs_ls_stt.Contract_Status_name = reader.IsDBNull(100) ? defaultString : reader.GetString(100);

                    cls.Leasing_Comment = reader.IsDBNull(101) ? defaultString : reader.GetString(101);
                    cls.Leasings_save_date = reader.IsDBNull(102) ? defaultString : reader.GetString(102);

                    cls.ctm = new Customers();
                    cls.ctm.Cust_id = reader.IsDBNull(103) ? defaultString : reader.GetString(103);
                    cls.ctm.Cust_Idcard = reader.IsDBNull(104) ? defaultString : reader.GetString(104);
                    cls.ctm.Cust_Fname = reader.IsDBNull(105) ? defaultString : reader.GetString(105);
                    cls.ctm.Cust_LName = reader.IsDBNull(106) ? defaultString : reader.GetString(106);
                    cls.ctm.Cust_B_date = reader.IsDBNull(107) ? defaultString : reader.GetString(107);
                    cls.ctm.Cust_Age = reader.IsDBNull(108) ? defaultNum : reader.GetInt32(108);
                    cls.ctm.Cust_Idcard_without = reader.IsDBNull(109) ? defaultString : reader.GetString(109);
                    cls.ctm.Cust_Idcard_start = reader.IsDBNull(110) ? defaultString : reader.GetString(110);
                    cls.ctm.Cust_Idcard_expire = reader.IsDBNull(111) ? defaultString : reader.GetString(111);

                    cls.ctm.ctm_ntnlt = new Base_Nationalitys();
                    cls.ctm.ctm_ntnlt.Nationality_id = reader.IsDBNull(112) ? defaultNum : reader.GetInt32(112);
                    cls.ctm.ctm_ntnlt.Nationality_name_ENG = reader.IsDBNull(113) ? defaultString : reader.GetString(113);
                    cls.ctm.ctm_ntnlt.Nationality_name_TH = reader.IsDBNull(114) ? defaultString : reader.GetString(114);

                    cls.ctm.ctm_org = new Base_Origins();
                    cls.ctm.ctm_org.Origin_id = reader.IsDBNull(115) ? defaultNum : reader.GetInt32(115);
                    cls.ctm.ctm_org.Origin_name_ENG = reader.IsDBNull(116) ? defaultString : reader.GetString(116);
                    cls.ctm.ctm_org.Origin_name_TH = reader.IsDBNull(117) ? defaultString : reader.GetString(117);

                    cls.ctm.Cust_Tel = reader.IsDBNull(118) ? defaultString : reader.GetString(118);
                    cls.ctm.Cust_Email = reader.IsDBNull(119) ? defaultString : reader.GetString(119);

                    cls.ctm.ctm_pstt = new Base_Person_Status();
                    cls.ctm.ctm_pstt.person_status_id = reader.IsDBNull(120) ? defaultNum : reader.GetInt32(120);
                    cls.ctm.ctm_pstt.person_status_name = reader.IsDBNull(121) ? defaultString : reader.GetString(121);

                    cls.ctm.Cust_Marry_idcard = reader.IsDBNull(122) ? defaultString : reader.GetString(122);
                    cls.ctm.Cust_Marry_Fname = reader.IsDBNull(123) ? defaultString : reader.GetString(123);
                    cls.ctm.Cust_Marry_Lname = reader.IsDBNull(124) ? defaultString : reader.GetString(124);

                    cls.ctm.ctm_marry_ntnlt = new Base_Nationalitys();
                    cls.ctm.ctm_marry_ntnlt.Nationality_id = reader.IsDBNull(125) ? defaultNum : reader.GetInt32(125);
                    cls.ctm.ctm_marry_ntnlt.Nationality_name_ENG = reader.IsDBNull(126) ? defaultString : reader.GetString(126);
                    cls.ctm.ctm_marry_ntnlt.Nationality_name_TH = reader.IsDBNull(127) ? defaultString : reader.GetString(127);

                    cls.ctm.ctm_marry_org = new Base_Origins();
                    cls.ctm.ctm_marry_org.Origin_id = reader.IsDBNull(128) ? defaultNum : reader.GetInt32(128);
                    cls.ctm.ctm_marry_org.Origin_name_ENG = reader.IsDBNull(129) ? defaultString : reader.GetString(129);
                    cls.ctm.ctm_marry_org.Origin_name_TH = reader.IsDBNull(130) ? defaultString : reader.GetString(130);

                    cls.ctm.Cust_Marry_Address_no = reader.IsDBNull(131) ? defaultString : reader.GetString(131);
                    cls.ctm.Cust_Marry_vilage = reader.IsDBNull(132) ? defaultString : reader.GetString(132);
                    cls.ctm.Cust_Marry_vilage_no = reader.IsDBNull(133) ? defaultString : reader.GetString(133);
                    cls.ctm.Cust_Marry_alley = reader.IsDBNull(134) ? defaultString : reader.GetString(134);
                    cls.ctm.Cust_Marry_road = reader.IsDBNull(135) ? defaultString : reader.GetString(135);
                    cls.ctm.Cust_Marry_subdistrict = reader.IsDBNull(136) ? defaultString : reader.GetString(136);
                    cls.ctm.Cust_Marry_district = reader.IsDBNull(137) ? defaultString : reader.GetString(137);
                    cls.ctm.Cust_Marry_province = reader.IsDBNull(138) ? defaultString : reader.GetString(138);
                    cls.ctm.Cust_Marry_country = reader.IsDBNull(139) ? defaultString : reader.GetString(139);
                    cls.ctm.Cust_Marry_zipcode = reader.IsDBNull(140) ? defaultString : reader.GetString(140);
                    cls.ctm.Cust_Marry_tel = reader.IsDBNull(141) ? defaultString : reader.GetString(141);
                    cls.ctm.Cust_Marry_email = reader.IsDBNull(142) ? defaultString : reader.GetString(142);
                    cls.ctm.Cust_Marry_job = reader.IsDBNull(143) ? defaultString : reader.GetString(143);
                    cls.ctm.Cust_Marry_job_position = reader.IsDBNull(144) ? defaultString : reader.GetString(144);
                    cls.ctm.Cust_Marry_job_long = reader.IsDBNull(145) ? defaultNum : reader.GetInt32(145);
                    cls.ctm.Cust_Marry_job_salary = reader.IsDBNull(146) ? defaultNum : reader.GetDouble(146);
                    cls.ctm.Cust_Marry_job_local_name = reader.IsDBNull(147) ? defaultString : reader.GetString(147);
                    cls.ctm.Cust_Marry_job_address_no = reader.IsDBNull(148) ? defaultString : reader.GetString(148);
                    cls.ctm.Cust_Marry_job_vilage = reader.IsDBNull(149) ? defaultString : reader.GetString(149);
                    cls.ctm.Cust_Marry_job_vilage_no = reader.IsDBNull(150) ? defaultString : reader.GetString(150);
                    cls.ctm.Cust_Marry_job_alley = reader.IsDBNull(151) ? defaultString : reader.GetString(151);
                    cls.ctm.Cust_Marry_job_road = reader.IsDBNull(152) ? defaultString : reader.GetString(152);
                    cls.ctm.Cust_Marry_job_subdistrict = reader.IsDBNull(153) ? defaultString : reader.GetString(153);
                    cls.ctm.Cust_Marry_job_district = reader.IsDBNull(154) ? defaultString : reader.GetString(154);
                    cls.ctm.Cust_Marry_job_province = reader.IsDBNull(155) ? defaultString : reader.GetString(155);
                    cls.ctm.Cust_Marry_job_country = reader.IsDBNull(156) ? defaultString : reader.GetString(156);
                    cls.ctm.Cust_Marry_job_zipcode = reader.IsDBNull(157) ? defaultString : reader.GetString(157);
                    cls.ctm.Cust_Marry_job_tel = reader.IsDBNull(158) ? defaultString : reader.GetString(158);

                    cls.ctm.Cust_Job = reader.IsDBNull(159) ? defaultString : reader.GetString(159);
                    cls.ctm.Cust_Job_position = reader.IsDBNull(160) ? defaultString : reader.GetString(160);
                    cls.ctm.Cust_Job_long = reader.IsDBNull(161) ? defaultNum : reader.GetInt32(161);
                    cls.ctm.Cust_Job_salary = reader.IsDBNull(162) ? defaultNum : reader.GetDouble(162);
                    cls.ctm.Cust_Job_local_name = reader.IsDBNull(163) ? defaultString : reader.GetString(163);
                    cls.ctm.Cust_Job_address_no = reader.IsDBNull(164) ? defaultString : reader.GetString(164);
                    cls.ctm.Cust_Job_vilage = reader.IsDBNull(165) ? defaultString : reader.GetString(165);
                    cls.ctm.Cust_Job_vilage_no = reader.IsDBNull(166) ? defaultString : reader.GetString(166);
                    cls.ctm.Cust_Job_alley = reader.IsDBNull(167) ? defaultString : reader.GetString(167);
                    cls.ctm.Cust_Job_road = reader.IsDBNull(168) ? defaultString : reader.GetString(168);
                    cls.ctm.Cust_Job_subdistrict = reader.IsDBNull(169) ? defaultString : reader.GetString(169);
                    cls.ctm.Cust_Job_district = reader.IsDBNull(170) ? defaultString : reader.GetString(170);
                    cls.ctm.Cust_Job_province = reader.IsDBNull(171) ? defaultString : reader.GetString(171);
                    cls.ctm.Cust_Job_country = reader.IsDBNull(172) ? defaultString : reader.GetString(172);
                    cls.ctm.Cust_Job_zipcode = reader.IsDBNull(173) ? defaultString : reader.GetString(173);
                    cls.ctm.Cust_Job_tel = reader.IsDBNull(174) ? defaultString : reader.GetString(174);
                    cls.ctm.Cust_Job_email = reader.IsDBNull(175) ? defaultString : reader.GetString(175);

                    cls.ctm.Cust_Home_address_no = reader.IsDBNull(176) ? defaultString : reader.GetString(176);
                    cls.ctm.Cust_Home_vilage = reader.IsDBNull(177) ? defaultString : reader.GetString(177);
                    cls.ctm.Cust_Home_vilage_no = reader.IsDBNull(178) ? defaultString : reader.GetString(178);
                    cls.ctm.Cust_Home_alley = reader.IsDBNull(179) ? defaultString : reader.GetString(179);
                    cls.ctm.Cust_Home_road = reader.IsDBNull(180) ? defaultString : reader.GetString(180);
                    cls.ctm.Cust_Home_subdistrict = reader.IsDBNull(181) ? defaultString : reader.GetString(181);
                    cls.ctm.Cust_Home_district = reader.IsDBNull(182) ? defaultString : reader.GetString(182);
                    cls.ctm.Cust_Home_province = reader.IsDBNull(183) ? defaultString : reader.GetString(183);
                    cls.ctm.Cust_Home_country = reader.IsDBNull(184) ? defaultString : reader.GetString(184);
                    cls.ctm.Cust_Home_zipcode = reader.IsDBNull(185) ? defaultString : reader.GetString(185);
                    cls.ctm.Cust_Home_tel = reader.IsDBNull(186) ? defaultString : reader.GetString(186);
                    cls.ctm.Cust_Home_GPS_Latitude = reader.IsDBNull(187) ? defaultString : reader.GetString(187);
                    cls.ctm.Cust_Home_GPS_Longitude = reader.IsDBNull(188) ? defaultString : reader.GetString(188);

                    cls.ctm.ctm_home_stt = new Base_Home_Status();
                    cls.ctm.ctm_home_stt.Home_status_id = reader.IsDBNull(189) ? defaultNum : reader.GetInt32(189);
                    cls.ctm.ctm_home_stt.Home_status_name = reader.IsDBNull(190) ? defaultString : reader.GetString(190);

                    cls.ctm.Cust_Idcard_address_no = reader.IsDBNull(191) ? defaultString : reader.GetString(191);
                    cls.ctm.Cust_Idcard_vilage = reader.IsDBNull(192) ? defaultString : reader.GetString(192);
                    cls.ctm.Cust_Idcard_vilage_no = reader.IsDBNull(193) ? defaultString : reader.GetString(193);
                    cls.ctm.Cust_Idcard_alley = reader.IsDBNull(194) ? defaultString : reader.GetString(194);
                    cls.ctm.Cust_Idcard_road = reader.IsDBNull(195) ? defaultString : reader.GetString(195);
                    cls.ctm.Cust_Idcard_subdistrict = reader.IsDBNull(196) ? defaultString : reader.GetString(196);
                    cls.ctm.Cust_Idcard_district = reader.IsDBNull(197) ? defaultString : reader.GetString(197);
                    cls.ctm.Cust_Idcard_province = reader.IsDBNull(198) ? defaultString : reader.GetString(198);
                    cls.ctm.Cust_Idcard_country = reader.IsDBNull(199) ? defaultString : reader.GetString(199);
                    cls.ctm.Cust_Idcard_zipcode = reader.IsDBNull(200) ? defaultString : reader.GetString(200);
                    cls.ctm.Cust_Idcard_tel = reader.IsDBNull(201) ? defaultString : reader.GetString(201);

                    cls.ctm.ctm_idcard_stt = new Base_Home_Status();
                    cls.ctm.ctm_idcard_stt.Home_status_id = reader.IsDBNull(202) ? defaultNum : reader.GetInt32(202);
                    cls.ctm.ctm_idcard_stt.Home_status_name = reader.IsDBNull(203) ? defaultString : reader.GetString(203);

                    cls.ctm.Cust_Current_address_no = reader.IsDBNull(204) ? defaultString : reader.GetString(204);
                    cls.ctm.Cust_Current_vilage = reader.IsDBNull(205) ? defaultString : reader.GetString(205);
                    cls.ctm.Cust_Current_vilage_no = reader.IsDBNull(206) ? defaultString : reader.GetString(206);
                    cls.ctm.Cust_Current_alley = reader.IsDBNull(207) ? defaultString : reader.GetString(207);
                    cls.ctm.Cust_Current_road = reader.IsDBNull(208) ? defaultString : reader.GetString(208);
                    cls.ctm.Cust_Current_subdistrict = reader.IsDBNull(209) ? defaultString : reader.GetString(209);
                    cls.ctm.Cust_Current_district = reader.IsDBNull(210) ? defaultString : reader.GetString(210);
                    cls.ctm.Cust_Current_province = reader.IsDBNull(211) ? defaultString : reader.GetString(211);
                    cls.ctm.Cust_Current_country = reader.IsDBNull(212) ? defaultString : reader.GetString(212);
                    cls.ctm.Cust_Current_zipcode = reader.IsDBNull(213) ? defaultString : reader.GetString(213);
                    cls.ctm.Cust_Current_tel = reader.IsDBNull(214) ? defaultString : reader.GetString(214);

                    cls.ctm.ctm_current_stt = new Base_Home_Status();
                    cls.ctm.ctm_current_stt.Home_status_id = reader.IsDBNull(215) ? defaultNum : reader.GetInt32(215);
                    cls.ctm.ctm_current_stt.Home_status_name = reader.IsDBNull(216) ? defaultString : reader.GetString(216);

                    cls.ctm.Cust_save_date = reader.IsDBNull(217) ? defaultString : reader.GetString(217);
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
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province", ctm.Cust_Marry_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province", ctm.Cust_Marry_job_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Job_province", ctm.Cust_Job_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Home_province", ctm.Cust_Home_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province", ctm.Cust_Idcard_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Current_province", ctm.Cust_Current_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Marry_province", ctm.Cust_Marry_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Marry_job_province", ctm.Cust_Marry_job_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Job_province", ctm.Cust_Job_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Home_province", ctm.Cust_Home_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Idcard_province", ctm.Cust_Idcard_province);
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
                cmd.Parameters.AddWithValue("@i_Cust_Current_province", ctm.Cust_Current_province);
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