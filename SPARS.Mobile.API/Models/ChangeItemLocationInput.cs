using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class ChangeItemLocationInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("pickup_batch_no")]
        public int PickupBatchno { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("picking_ticket_no")]
        public int PickingTicketNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(11)]
        [JsonProperty("location_id_from")]
        public string LocationIDFrom { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(11)]
        [JsonProperty("location_id_to")]
        public string LocationIDTo { get; set; }
    }
}