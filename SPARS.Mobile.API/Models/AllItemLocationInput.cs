using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class AllItemLocationInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(17)]
        [JsonProperty("item_id")]
        public string ItemID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [JsonProperty("picking_ticket_no")]
        public int PickingTicketNo { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [JsonProperty("line_no")]
        public int LineNo { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(11)]
        [JsonProperty("location_id")]
        public string LocationID { get; set; }
    }
}