using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class WarehouseInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("user_id")]
        public string UserID { get; set; }
    }
}