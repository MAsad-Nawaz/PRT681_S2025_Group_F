using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ItemsAvailableSKUResponse
    {
        [JsonProperty("item_id")]
        public List<ItemsAvailableSKU> ItemsAvailableSKUs{ get; set; }
    }
}