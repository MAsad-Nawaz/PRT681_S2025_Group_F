using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class UnPickItemInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("pickup_batch_no")]
        public int PickupBatchNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("picking_ticket_no")]
        public int PickingTicketNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("line_no")]
        public int LineNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(17)]
        [JsonProperty("item_id")]
        public string ItemID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(11)]
        [JsonProperty("location_id")]
        public string PickingLocation { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(10)]
        [JsonProperty("sku")]
        public string SKU { get; set; }
    }
}