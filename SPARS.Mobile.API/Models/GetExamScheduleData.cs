using System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class GetExamScheduleData
    {
        [JsonProperty("exm_id")]
        public int EXM_ID { get; set; }

        [JsonProperty("exmsc_date")]
        public string EXMSC_Date { get; set; }

        [JsonProperty("exm_name")]
        public string EXM_Name { get; set; }
    }
}