using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PickupBatchResponse
    {
        [JsonProperty("batch_no")]
        public List<int> BatchNo { get; set; }

        [JsonProperty("floor_no")]
        public List<string> FloorNo { get; set; }

        [JsonProperty("row_no")]
        public List<string> RowNo { get; set; }

        [JsonProperty("shipping_company")]
        public List<string> ShippingCompany { get; set; }
    }
}