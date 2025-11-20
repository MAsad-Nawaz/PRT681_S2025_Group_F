using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class GetExamScheduleDataResponse
    {
        [JsonProperty("GetExamScheduleData")]
        public List<GetExamScheduleData> GetExamScheduleData { get; set; }
    }
}