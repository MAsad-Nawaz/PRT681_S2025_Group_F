using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class PickingLocationLogInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(11)]
        [JsonProperty("location_id")]
        public string LocationID { get; set; }
    }
}