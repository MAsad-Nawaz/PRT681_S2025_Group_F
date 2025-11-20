using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class ResultRemarksInput
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
        [JsonProperty("session_id")]
        public int Session_ID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        //[MaxLength(3)]
        [JsonProperty("term_id")]
        public int Term_ID { get; set; }
    }
}