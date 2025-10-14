using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class UnPickItem
    {
        [JsonProperty("picked_items")]
        public int PickedItems { get; set; }
    }
}