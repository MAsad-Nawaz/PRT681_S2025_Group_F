using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class RequestResults<T>
    {
        /// <summary>
        /// Result Header
        /// </summary>
        [JsonProperty("result_header")]
        public ResultHeader ResultHeader { get; set; }

        /// <summary>
        /// Generic Object
        /// </summary>
        [JsonProperty("result_details")]
        public T ResultDetails { get; set; }

        public RequestResults()
        {
            ResultHeader = new ResultHeader();
        }
    }
}