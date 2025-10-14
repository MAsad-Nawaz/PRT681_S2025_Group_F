using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSS.BizLayer;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class RequestHeader
    {
        /// <summary>
        /// API Version
        /// </summary>
        [JsonProperty("version")]
        public string Version { get { return GlobalDeclarations.g_APIVersion; } }

        /// <summary>
        /// Request Id
        /// </summary>
        [JsonProperty("request_id")]
        public string Id { get; set; }
    }
}