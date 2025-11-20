using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetTeachersResponse
    {
        [JsonProperty("get_teachers_data")]
        public List<GetTeachers> GetTeachersData { get; set;}
    }
}