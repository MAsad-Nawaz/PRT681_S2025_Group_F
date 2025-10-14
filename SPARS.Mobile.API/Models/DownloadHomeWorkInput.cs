using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class DownloadHomeWorkInput
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
        [JsonProperty("ahw_id")]
        public int AHW_ID { get; set; }
    }
}