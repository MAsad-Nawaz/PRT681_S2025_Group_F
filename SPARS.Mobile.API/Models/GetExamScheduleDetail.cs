using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetExamScheduleDetail
    {
        [JsonProperty("exm_id")]
        public int EXM_ID { get; set; }

        [JsonProperty("exm_name")]
        public string EXM_Name { get; set; }

        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("class_room")]
        public string ClassRoom { get; set; }

        [JsonProperty("exmsc_date")]
        public string EXMSC_Date { get; set; }

        [JsonProperty("exmsc_start_time")]
        public string EXMSC_Start_Time { get; set; }

        [JsonProperty("exmsc_end_time")]
        public string EXMSC_End_Time { get; set; }
    }
}