using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class PickingScannedItem
    {
        [JsonProperty("location_id")]
        public string PickingLocation { get; set; }

        [JsonProperty("sku")]
        public string SKU { get; set; }

        [JsonProperty("total_picked_qty")]
        public int TotalPickedQuantity { get; set; }

        [JsonProperty("line_count")]
        public int LineCount { get; set; }
    }
}