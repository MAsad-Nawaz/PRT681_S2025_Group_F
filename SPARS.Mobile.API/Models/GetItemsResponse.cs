using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class GetItemsResponse
    {
        [JsonProperty("items")]
        public List<Items> BatchLocationItems { get; set; }

        //[JsonProperty("batch_locationitems_details")]
        //public List<ItemDetails> ItemDetails { get; set; }

        //[JsonProperty("batch_locationitems_detailsall")]
        //public List<BatchLocationItemDetailsAll> BatchLocationItemDetailsAll { get; set; }
    }
}