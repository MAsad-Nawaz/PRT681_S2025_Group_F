using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class FloorResponse
    {
        [JsonProperty("floor_no")]
        public List<string> Floors { get; set; }
    }
}