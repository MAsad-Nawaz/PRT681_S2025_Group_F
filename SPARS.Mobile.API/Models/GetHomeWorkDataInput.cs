using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SSS.Mobile.API.Models
{
    public class GetHomeWorkDataInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("sb_id")]
        public string SB_ID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("status_id")]
        public string Status_ID { get; set; }
    }

    public class GetHomeWorkBadgeStatusDataInput 
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("sb_id")]
        public int SB_ID { get; set; }
    }

    public class GetHomeWorkBadgeDataInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("sb_id")]
        public string SB_ID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("status_id")]
        public string Status_ID { get; set; }
    }

    public class SubmitHomeWorkModel
    {
        /// <summary>
        /// Required
        /// </summary>
       
        [JsonProperty("AHWID")]
        public int AHWID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("WarehouseID")]
        public string WarehouseID { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("FileName")]
        public string FileName { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("FileType")]
        public string FileType { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("FilePath")]
        public string FilePath { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        [JsonProperty("UserNo")]
        public int UserNo { get; set; }
    }
}