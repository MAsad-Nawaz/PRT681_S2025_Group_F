using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetSubjectsResponse
    {
        [JsonProperty("get_subjects")]
        public List<GetSubjects> GetSubjects { get; set; }
    }
}