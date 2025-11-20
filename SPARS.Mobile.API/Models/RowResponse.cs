using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class RowResponse
    {
        [JsonProperty("row_no")]
        public List<string> Rows { get; set; }
    }
}