using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PickupBatchInfoResponse
    {
        [JsonProperty("locations")]
        public List<PickupBatchInfo> PickupBatchInfo { get; set; }
    }
}