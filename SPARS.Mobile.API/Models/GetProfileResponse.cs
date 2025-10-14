using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SSS.Mobile.API.Models
{
    public class GetProfileResponse
    {
        [JsonProperty("profile")]
        public List<ProfileData> Profile { get; set; }

        [JsonProperty("parent_data")]
        public List<ParentData> ParentsData { get; set; }
    }
}