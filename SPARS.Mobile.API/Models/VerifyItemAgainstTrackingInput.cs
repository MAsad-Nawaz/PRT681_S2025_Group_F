using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class VerifyItemAgainstTrackingInput
    {

        /// <summary>
        /// Required
        /// </summary>
        //[MaxLength(11)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("tracking_no")]
        public string TrackingNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(17)]
        [JsonProperty("item_id")]
        public string itemID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        //[MaxLength(2)]
        [JsonProperty("ContainerNo")]
        public string ContainerNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        //[MaxLength(50)]
        [JsonProperty("shipping_company")]
        public string ShippingCompany { get; set; }
    }
}