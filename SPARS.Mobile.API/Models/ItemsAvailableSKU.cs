using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ItemsAvailableSKU
    {
        [JsonProperty("sku")]
        public string SKU { get; set; }

        [JsonProperty("location_id")]
        public string LocationID { get; set; }
    }
}