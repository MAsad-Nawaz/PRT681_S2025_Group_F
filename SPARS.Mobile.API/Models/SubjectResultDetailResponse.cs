using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class SubjectResultDetailResponse
    {
        [JsonProperty("sub_result_detail")]
        public List<GetSubResultDetail> SubResultDetail { get; set; }
    }
}