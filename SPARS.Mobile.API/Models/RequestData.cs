using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class RequestData<T>
    {
        /// <summary>
        /// Request Header
        /// </summary>
        [JsonProperty("request_header")]
        public RequestHeader RequestHeader { get; set; }

        /// <summary>
        /// Request Response
        /// </summary>
        [JsonProperty("request_results")]
        public RequestResults<T> RequestResults { get; set; }

        public RequestData()
        {
            RequestHeader = new RequestHeader();
            RequestResults = new RequestResults<T>();
        }
    }
}