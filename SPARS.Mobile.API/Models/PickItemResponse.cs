using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PickItemResponse
    {
        [JsonProperty("picked_item")]
        public PickingScannedItem PickingScannedItem { get; set; }
    }
}