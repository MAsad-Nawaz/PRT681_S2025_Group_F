using System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class GetShipmentCountResponse
    {
        [JsonProperty("totalshipment_count")]
        public int TotalShipmentCount { get; set; }

       
        [JsonProperty("confirmshipment_count")]
        public int ConfirmShipmentCount { get; set; }
    }
}