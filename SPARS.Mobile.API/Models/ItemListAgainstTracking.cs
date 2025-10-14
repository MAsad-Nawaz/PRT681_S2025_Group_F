using System;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class ItemAgainstTracking
    {
        [JsonProperty("itemID")]
        public string itemID { get; set; }

        [JsonProperty("ConfirmedStatus")]
        public string ConfirmedStatus { get; set; }
    }
}