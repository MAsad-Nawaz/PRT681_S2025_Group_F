using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ItemsAvailableSKUInput
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
    }
}