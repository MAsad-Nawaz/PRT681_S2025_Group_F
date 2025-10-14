using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ShowItemsResponse
    {
        [JsonProperty("all_items")]
        public List<ShowItem> ShowItems { get; set; }
    }
}