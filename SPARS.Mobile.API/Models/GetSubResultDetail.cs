using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class GetSubResultDetail
    {
        [JsonProperty("sr_id")]
        public int SR_ID { get; set; }

        [JsonProperty("sb_id")]
        public int SB_ID { get; set; }

        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("obtained_schedule_marks")]
        public int Obtained_Schedule_Marks { get; set; }

        [JsonProperty("total_schedule_marks")]
        public int Total_Schedule_Marks { get; set; }

        [JsonProperty("obtained_assessment_marks")]
        public int Obtained_Assessment_Marks { get; set; }

        [JsonProperty("total_assessment_marks")]
        public int Total_Assessment_Marks { get; set; }

        [JsonProperty("obtained_monthly_marks")]
        public int Obtained_Monthly_Marks { get; set; }

        [JsonProperty("total_monthly_marks")]
        public int Total_Monthly_Marks { get; set; }

        [JsonProperty("obtained_class_work_marks")]
        public int Obtained_Class_Work_Marks { get; set; }

        [JsonProperty("total_class_work_marks")]
        public int Total_Class_Work_Marks { get; set; }

        [JsonProperty("obtained_home_work_marks")]
        public int Obtained_Home_Work_Marks { get; set; }

        [JsonProperty("total_home_work_marks")]
        public int Total_Home_Work_Marks { get; set; }

        [JsonProperty("obtained_mmp_marks")]
        public int Obtained_MMP_Marks { get; set; }

        [JsonProperty("total_mmp_marks")]
        public int Total_MMP_Marks { get; set; }

        [JsonProperty("obtained_course_work_total")]
        public int Obtained_Course_Work_Total { get; set; }

        [JsonProperty("course_work_total")]
        public int Course_Work_Total { get; set; }

        [JsonProperty("section_id")]
        public int Section_ID { get; set; }

        [JsonProperty("class_id")]
        public int Class_ID { get; set; }

        [JsonProperty("session_id")]
        public int Session_ID { get; set; }

        [JsonProperty("term_id")]
        public int Term_ID { get; set; }

        [JsonProperty("std_roll_no")]
        public int STD_Roll_No { get; set; }
    }
}