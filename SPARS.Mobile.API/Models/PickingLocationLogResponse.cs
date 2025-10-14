using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class PickingLocationLogResponse
    {
        [JsonProperty("picking_location_log")]
        public PickingLocationLog PickingLocationLog { get; set; }
    }
}