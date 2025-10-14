using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class ChangeItemLocation
    {
        [JsonProperty("location_id")]
        public string PickingLocation { get; set; }

        [JsonProperty("sku")]
        public string SKU { get; set; }


        [JsonProperty("line_count")]
        public string LineCount { get; set; }
    }
}