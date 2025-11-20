using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PickupBatchInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("warehouse_id")]
        public string WareHouseID { get; set; }
    }
}