using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SSS.Mobile.API.Models
{
    public class DownloadHomeWorkResponse
    {

        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        [JsonProperty("ahw_id")]
        public int AHW_ID { get; set; }

        [JsonProperty("file_name")]
        public string File_Name { get; set; }

        [JsonProperty("file_path")]
        public string File_Path { get; set; }

        [JsonProperty("file_base64")]
        public string File_Base64 { get; set; }
    }
    public class DownloadResponse
    {

        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        [JsonProperty("key_id")]
        public int Key_ID { get; set; }

        [JsonProperty("file_name")]
        public string File_Name { get; set; }

        [JsonProperty("file_path")]
        public string File_Path { get; set; }

        [JsonProperty("file_base64")]
        public string File_Base64 { get; set; }
    }
}