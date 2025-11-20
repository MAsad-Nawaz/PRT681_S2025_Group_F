using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class ScheduleMarks
    {
        [JsonProperty("result_date")]
        public string ResultDate { get; set; }

        [JsonProperty("exmr_obtained_marks")]
        public int EXMR_Obtained_Marks { get; set; }

        [JsonProperty("EXMR_Total_Marks")]
        public int EXMR_Total_Marks { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("exmr_remarks")]
        public string EXMR_Remarks { get; set; }
    }
}