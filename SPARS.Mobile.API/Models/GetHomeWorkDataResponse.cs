using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetHomeWorkDataResponse
    {
        [JsonProperty("get_homework_data")]
        public List<GetHomeWorkData> GetHomeWorkData { get; set; }
    }

    public class GetHomeWorkBadgeDataResponse
    {
        [JsonProperty("get_homework_data")]
        public List<GetHomeWorkBadgeData> GetHomeWorkData { get; set; }
    }

    public class GetHomeWorkBadgeStatusDataResponse
    {
        [JsonProperty("get_homework_data")]
        public List<GetHomeWorkBadgeStatusData> GetHomeWorkData { get; set; }
    }
}