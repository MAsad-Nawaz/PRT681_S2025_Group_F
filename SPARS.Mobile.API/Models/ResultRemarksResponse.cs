using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class ResultRemarksResponse
    {
        [JsonProperty("OverallRemark")]
        public string OverallRemark { get; set; }

        [JsonProperty("RR_Art_Name")]
        public string RR_Art_Name { get; set; }

        [JsonProperty("RR_Attandance_Name")]
        public string RR_Attandance_Name { get; set; }

        [JsonProperty("RR_Class_Work_Name")]
        public string RR_Class_Work_Name { get; set; }

        [JsonProperty("RR_Conduct_Name")]
        public string RR_Conduct_Name { get; set; }

        [JsonProperty("RR_Effort_Name")]
        public string RR_Effort_Name { get; set; }

        [JsonProperty("RR_Home_Work_Name")]
        public string RR_Home_Work_Name { get; set; }

        [JsonProperty("RR_Punctually_Name")]
        public string RR_Punctually_Name { get; set; }

        [JsonProperty("RR_Project_Work_Name")]
        public string RR_Project_Work_Name { get; set; }

        [JsonProperty("RR_Games_Name")]
        public string RR_Games_Name { get; set; }

        [JsonProperty("RR_Work_Presentation_Name")]
        public string RR_Work_Presentation_Name { get; set; }

        [JsonProperty("STD_Percentage")]
        public int STD_Percentage { get; set; }
    }
}