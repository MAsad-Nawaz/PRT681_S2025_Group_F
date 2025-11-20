using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class PickingLocationLog
    {
        [JsonProperty("serial_no")]
        public int SerialNo { get; set; }
    }
}