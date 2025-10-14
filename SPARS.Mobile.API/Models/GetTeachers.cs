using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetTeachers
    {
        [JsonProperty("emp_name")]
        public string EMP_Name { get; set; }

        [JsonProperty("section_name")]
        public string Section_Name { get; set; }

        [JsonProperty("emp_email")]
        public string EMP_Email { get; set; }

        [JsonProperty("emp_phone")]
        public string EMP_Phone { get; set; }

        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        [JsonProperty("class_name")]
        public string Class_Name { get; set; }

        [JsonProperty("emp_image_base64")]
        public string EMP_Image_Base64 { get; set; }

        [JsonProperty("emp_image_name")]
        public string EMP_Image_Name { get; set; }
    }
}