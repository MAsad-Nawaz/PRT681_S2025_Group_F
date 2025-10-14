using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ProfileData
    {
        [JsonProperty("std_roll_no")]
        public int STD_Roll_No { get; set; }

        //[JsonProperty("item_id")]
        //public string ItemID { get; set; }

        [JsonProperty("std_name")]
        public string STD_Name { get; set; }

        [JsonProperty("std_cnic")]
        public string STD_CNIC { get; set; }

        [JsonProperty("std_gender")]
        public string STD_Gender { get; set; }

        [JsonProperty("std_dob")]
        public string STD_DOB { get; set; }

        [JsonProperty("std_maling_address")]
        public string STD_Maling_Address { get; set; }

        [JsonProperty("std_permanent_address")]
        public string STD_Permanent_Address { get; set; }

        [JsonProperty("std_email")]
        public string STD_Email { get; set; }

        [JsonProperty("std_phone")]
        public string STD_Phone { get; set; }

        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        [JsonProperty("std_image_base64")]
        public string STD_Image_Base64 { get; set; }

        [JsonProperty("std_image_name")]
        public string STD_Image_Name { get; set; }

        [JsonProperty("add_user")]
        public int ADDUser { get; set; }

        [JsonProperty("class_name")]
        public string Class_Name { get; set; }

        [JsonProperty("section_name")]
        public string Section_Name { get; set; }

        [JsonProperty("std_category_name")]
        public string STD_Category_Name { get; set; }

         [JsonProperty("reliogion")]
        public string Reliogion { get; set; }

         [JsonProperty("blood_group")]
         public string BloodGroup { get; set; }

         //[JsonProperty("as_on_date")]
         //public string AsOnDate { get; set; }

         [JsonProperty("admission_no")]
         public string AdmissionNo { get; set; }

         [JsonProperty("admission_date")]
         public string AdmissionDate { get; set; }

    }
}