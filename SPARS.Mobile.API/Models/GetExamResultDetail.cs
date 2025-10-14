using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SSS.Mobile.API.Models
{
    public class GetExamResultDetail
    {
        [JsonProperty("term_id")]
        public int Term_ID { get; set; }

        [JsonProperty("sr_id")]
        public int SR_ID { get; set; }

        [JsonProperty("sb_id")]
        public int SB_ID { get; set; }

        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("term_name")]
        public string Term_Name { get; set; }
        [JsonProperty("exam_reuslt")]
        public string ExamResult { get; set; }

        //[JsonProperty("exmsc_passing_marks")]
        //public int EXMSC_Passing_Marks { get; set; }

        [JsonProperty("exmr_obtained_marks")]
        public string EXMR_Obtained_Marks { get; set; }

        [JsonProperty("grand_total")]
        public string GrandTotal { get; set; }
        //[JsonProperty("exm_name")]
        //public string EXM_Name { get; set; }

        //[JsonProperty("total_obtained_marks")]
        //public int TotalMarksObtained { get; set; }

        //[JsonProperty("total_marks")]
        //public int TotalMarks { get; set; }

        [JsonProperty("marks_percentage")]
        public int MarksPercentage { get; set; }

        [JsonProperty("exam_grade")]
        public string ExamGrade { get; set; }

        [JsonProperty("subject_exam_reuslt")]
        public string SubjectExamResult { get; set; }
        [JsonProperty("session_id")]
        public int Session_ID { get; set; }
    }
}