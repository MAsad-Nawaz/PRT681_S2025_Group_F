using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class ProcedureMessage
    {
        [JsonProperty("message_level")]
        public int MessageLevel { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}