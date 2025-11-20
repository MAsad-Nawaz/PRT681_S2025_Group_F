using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetExamResultDetailInput
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
        [JsonProperty("sr_id")]
        public int SR_ID { get; set; }
        [JsonProperty("session_id")]
        public int Session_ID { get; set; }
        [JsonProperty("term_id")]
        public int Term_ID { get; set; }
    }
}