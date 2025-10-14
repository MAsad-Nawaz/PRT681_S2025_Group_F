using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetItemsInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(11)]
        [JsonProperty("location_id")]
        public string LocationID { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [JsonProperty("pickup_batch_no")]
        public int BatchNo { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("floor_no")]
        public string FloorNo { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("row_no")]
        public string RowNo { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(50)]
        [JsonProperty("shipping_company")]
        public string ShippingCompany { get; set; }
    }
}