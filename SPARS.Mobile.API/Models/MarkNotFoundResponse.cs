using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class MarkNotFoundResponse
    {
        [JsonProperty("item_not_found")]
        public ItemNotFound ItemNotFound { get; set; }
    }
}