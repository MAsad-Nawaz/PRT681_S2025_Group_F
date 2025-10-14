using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace SSS.Mobile.API.Models
{
    public class RowInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [Required]
        [JsonProperty("pickup_batch_no")]
        public int BatchNo { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("floor_no")]
        public string FloorNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }
    }
}