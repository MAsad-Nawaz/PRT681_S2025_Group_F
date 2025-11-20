using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetShipmentCountInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        //[MaxLength(3)]
        [JsonProperty("TotalShipmentCount")]
        public int TotalShipmentCount { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        //[MaxLength(3)]
        [JsonProperty("ConfirmShipmentCount")]
        public int ConfirmShipmentCount { get; set; }


    }
}