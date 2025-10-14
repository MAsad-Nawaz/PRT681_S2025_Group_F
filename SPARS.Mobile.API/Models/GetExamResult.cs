using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetExamResult
    {
        [JsonProperty("sr_id")]
        public int SR_ID { get; set; }

        [JsonProperty("exm_status")]
        public string EXM_Status { get; set; }

        [JsonProperty("exm_name")]
        public string EXM_Name { get; set; }

        [JsonProperty("percentage")]
        public int Percentage { get; set; }

        [JsonProperty("grand_total")]
        public string GrandTotal { get; set; }

        [JsonProperty("exam_grade")]
        public string ExamGrade { get; set; }

        [JsonProperty("exmr_obtained_marks")]
        public int EXMR_Obtained_Marks { get; set; }

        [JsonProperty("exmr_total_marks")]
        public int EXMR_Total_Marks { get; set; }
        [JsonProperty("grade_postion")]
        public string GradePostion { get; set; }
        [JsonProperty("session_id")]
        public int Session_ID { get; set; }
        [JsonProperty("term_id")]
        public int Term_ID { get; set; }
    }
}