using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class UnPickItemResponse
    {
        [JsonProperty("unpick_item")]
        public UnPickItem UnpickItem { get; set; }
    }
}