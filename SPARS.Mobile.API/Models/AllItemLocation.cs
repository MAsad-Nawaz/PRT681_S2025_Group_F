using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class AllItemLocation
    {
        [JsonProperty("location_id")]
        public string LocationID { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("location_qty")]
        public string LocationQuantity { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("user_id")]
        public string UserID { get; set; }
    }
}