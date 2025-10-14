using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetTimeTable
    {
        [JsonProperty("time_table_id")]
        public int CLSTT_ID { get; set; }

        [JsonProperty("section_name")]
        public string Section_Name { get; set; }

        [JsonProperty("class_name")]
        public string Class_Name { get; set; }

        [JsonProperty("wd_name")]
        public string WD_Name { get; set; }

        [JsonProperty("wd_id")]
        public string WD_ID { get; set; }

        [JsonProperty("term_name")]
        public string Term_Name { get; set; }

        [JsonProperty("session_code")]
        public string Session_Code { get; set; }

        [JsonProperty("clstt_status_description")]
        public string Status_Description { get; set; }

        [JsonProperty("time_table_detail")]
        public List<GetTimeTableDetail> TimeTableDetail { get; set; }
        
    }

    public class GetTimeTableDetail
    {
       
        [JsonProperty("time_table_id")]
        public int CLSTT_ID { get; set; }

        [JsonProperty("emp_name")]
        public string EMP_Name { get; set; }

        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("wd_name")]
        public string WD_Name { get; set; }

        [JsonProperty("wd_id")]
        public string WD_ID { get; set; }

        [JsonProperty("clsr_name")]
        public string CLSR_Name { get; set; }

        [JsonProperty("clstt_start_time")]
        public string CLSTT_Start_Time { get; set; }

        [JsonProperty("clstt_end_time")]
        public string CLSTT_End_Time { get; set; }

    }
}