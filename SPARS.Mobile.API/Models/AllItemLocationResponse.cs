using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class AllItemLocationResponse
    {
        [JsonProperty("all_items_locations")]
        public List<AllItemLocation> AllItemsLocations { get; set; }
    }
}