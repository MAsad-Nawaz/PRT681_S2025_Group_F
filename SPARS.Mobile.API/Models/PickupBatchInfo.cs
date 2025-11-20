using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PickupBatchInfo
    {
        [JsonProperty("floor_no")]
        public string FloorNo { get; set; }

        [JsonProperty("row_no")]
        public string RowNo { get; set; }

        [JsonProperty("picked")]
        public int Picked { get; set; }

        [JsonProperty("to_pick")]
        public int ToPick { get; set; }

        [JsonProperty("location_id")]
        public string LocationID { get; set; }

        //[JsonProperty("items_count")]
        //public string ItemsCount { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("shipping_company")]
        public string ShippingCompany { get; set; }

        [JsonProperty("pickup_batch_no")]
        public int BatchNo { get; set; }
    }
}