using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class PickItemInput
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
        [JsonProperty("line_no")]
        public int LineNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("bale_no")]
        public int BaleNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(17)]
        [JsonProperty("item_id")]
        public string ItemID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(10)]
        [JsonProperty("sku")]
        public string SKU { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(11)]
        [JsonProperty("location_id")]
        public string PickingLocation { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("serial_no")]
        public int SerialNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("paper_less")]
        public bool PaperLess { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [JsonProperty("pickup_batch_no_selected")]
        public int BatchNoSelected { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("floor_no_selected")]
        public string FloorNoSelected { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("row_no_selected")]
        public string RowNoSelected { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(50)]
        [JsonProperty("shipping_company_selected")]
        public string ShippingCompanySelected { get; set; }
    }
}