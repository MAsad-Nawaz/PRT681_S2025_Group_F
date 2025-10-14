using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class ChangeItemLocationResponse
    {
        [JsonProperty("change_item_location")]
        public ChangeItemLocation ChangeItemLocation { get; set; }
    }
}