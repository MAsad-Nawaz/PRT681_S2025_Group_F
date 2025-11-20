using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PullingInfoInput
    {
        [JsonProperty("warehoues_id")]
        public int WarehouseID { get; set; }

        [JsonProperty("pickup_batch_no")]
        public int PickupBatchNo { get; set; }
    }
}