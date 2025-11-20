using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetSubjectsInput
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
        [JsonProperty("class_name")]
        public string Class_Name { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("section_name")]
        public string Section_Name { get; set; }
    }
}