using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class CurrentWeekTimeTableResponse
    {
        [JsonProperty("get_timetable")]
        public List<GetTimeTable> GetTimeTable { get; set; }
    }
}