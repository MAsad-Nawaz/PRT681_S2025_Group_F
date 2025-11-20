using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class BatchesResponse
    {
        [JsonProperty("batch_no")]
        public List<int> Batches { get; set; }
    }
}