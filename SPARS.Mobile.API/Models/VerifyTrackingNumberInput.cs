using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class VerifyTrackingNumberInput
    {
        /// <summary>
        /// Required
        /// </summary>
        //[MaxLength(3)]
        [JsonProperty("Tracking_No")]
        public string TrackingNo { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        
        [JsonProperty("IsReturnItem")]
        public int IsReturnItem { get; set; }
    }
}