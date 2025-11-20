using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PullingInfoResponse
    {
        [JsonProperty("warehoues_id")]
        public ProcedureMessage Message { get; set; }

        [JsonProperty("pulling_info")]
        public PullingInfo PullingInfo { get; set; }
    }
}