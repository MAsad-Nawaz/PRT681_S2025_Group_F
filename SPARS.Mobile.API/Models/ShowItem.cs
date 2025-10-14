using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ShowItem
    {
        [JsonProperty("pickup_batch_no")]
        public int PickupBatchNo { get; set; }

        [JsonProperty("item_id")]
        public string ItemID { get; set; }

        [JsonProperty("location_id")]
        public string PickingLocation { get; set; }

        [JsonProperty("pickup_date")]
        public string PickupDate { get; set; }

        [JsonProperty("label_printed_date")]
        public string LabelPrintedDate { get; set; }

        [JsonProperty("sku")]
        public string SKU { get; set; }

        [JsonProperty("line_no")]
        public int LineNo { get; set; }

        [JsonProperty("picking_ticket_no")]
        public int PickingTicketNo { get; set; }

        [JsonProperty("label_printed")]
        public string LabelPrinted { get; set; }

        [JsonProperty("pickup_time")]
        public string PickupTime { get; set; }
    }
}