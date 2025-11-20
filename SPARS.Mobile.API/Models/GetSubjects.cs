using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetSubjects
    {
        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("section_name")]
        public string Section_Name { get; set; }

        [JsonProperty("sb_code")]
        public string SB_Code { get; set; }

        [JsonProperty("sb_description")]
        public string SB_Description { get; set; }

        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        [JsonProperty("sb_type_name")]
        public string SB_Type_Name { get; set; }

        [JsonProperty("emp_name")]
        public string EMP_Name { get; set; }

        [JsonProperty("class_name")]
        public string Class_Name { get; set; }



    }
}