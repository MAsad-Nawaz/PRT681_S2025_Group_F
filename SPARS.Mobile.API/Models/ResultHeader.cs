using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ResultHeader
    {
        /// <summary>
        /// Type of Repsonse
        /// </summary>
        [JsonProperty("status")]
        public string Type { get; set; }

        /// <summary>
        /// Response Code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Respones Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}