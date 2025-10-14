using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SSS.Mobile.API.Models
{
    public class ParentData
    {
        [JsonProperty("std_member_relation")]
        public string STD_Member_Relation { get; set; }

        [JsonProperty("std_member_name")]
        public string STD_Member_Name { get; set; }

        [JsonProperty("std_member_phone")]
        public string STD_Member_Phone { get; set; }

        [JsonProperty("std_member_profession")]
        public string STD_Member_Profession { get; set; }

        [JsonProperty("std_member_email")]
        public string STD_Member_Email { get; set; }

        [JsonProperty("std_member_image_base64")]
        public string STD_Member_Image_Base64 { get; set; }

        [JsonProperty("std_member_isguardian")]
        public Boolean STD_Member_IsGuardian { get; set; }
    }
}