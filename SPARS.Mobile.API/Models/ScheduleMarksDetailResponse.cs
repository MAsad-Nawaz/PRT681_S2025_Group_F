using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class ScheduleMarksDetailResponse
    {
        [JsonProperty("schedule_marks_detail")]
        public List<ScheduleMarks> ScheduleMarksDetail { get; set; }
    }
}