using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class Items
    {
        //[JsonProperty("item")]
        //public string Item { get; set; }

        [JsonProperty("item_id")]
        public string ItemID { get; set; }

        [JsonProperty("to_pick")]
        public string ToPick { get; set; }

        [JsonProperty("picked")]
        public string Picked { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        //[JsonProperty("un_pick")]
        //public string UnPick { get; set; }

        //[JsonProperty("action")]
        //public string Action { get; set; }

        //[JsonProperty("not_found")]
        //public string NotFound { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        //[JsonProperty("picked_items")]
        //public int PickupUser { get; set; }

        //[JsonProperty("total_items")]
        //public int PickupBatchNo { get; set; }

        //[JsonProperty("pickup_batch_no")]
        //public int PickupBatchNo { get; set; }

        //[JsonProperty("picking_ticket_no")]
        //public int PickingTicketNo { get; set; }

        [JsonProperty("upc")]
        public string UPC { get; set; }

        [JsonProperty("upc_5digit")]
        public string UPC5Digit { get; set; }

        [JsonProperty("serial_no")]
        public int SerialNo { get; set; }

        [JsonProperty("details")]
        public List<ItemDetails> ItemDetails { get; set; }
    }
}