using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class ItemDetails
    {
        [JsonProperty("pickup_batch_no")]
        public int PickupBatchNo { get; set; }

        //[JsonProperty("item_id")]
        //public string ItemID { get; set; }

        [JsonProperty("picking_ticket_no")]
        public int PickingTicketNo { get; set; }

        [JsonProperty("line_no")]
        public int LineNo { get; set; }

        [JsonProperty("bale_no")]
        public int BaleNo { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("sku")]
        public string SKU { get; set; }

        //[JsonProperty("upc")]
        //public string UPC { get; set; }

        //[JsonProperty("upc_5digit")]
        //public string UPC5Digit { get; set; }

        [JsonProperty("boxline_no")]
        public int BoxLineNo { get; set; }

        //[JsonProperty("serial_no")]
        //public int SerialNo { get; set; }
    }
}