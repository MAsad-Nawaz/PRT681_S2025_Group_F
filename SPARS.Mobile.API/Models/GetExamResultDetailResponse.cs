using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SSS.Mobile.API.Models
{
    public class GetExamResultDetailResponse
    {
        [JsonProperty("exams_result_detail")]
        public List<GetExamResultDetail> ExamResultDetail { get; set; }
    }
}