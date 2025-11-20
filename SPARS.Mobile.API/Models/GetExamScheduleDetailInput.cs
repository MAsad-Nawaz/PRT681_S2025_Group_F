using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetExamScheduleDetailInput
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
        [JsonProperty("exm_id")]
        public string EXM_ID { get; set; }
    }
}