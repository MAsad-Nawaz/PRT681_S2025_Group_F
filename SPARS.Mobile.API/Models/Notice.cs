using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class Notice
    {
    }

    public class GetnoticeDataInput
    {
        /// <summary>
        /// Required
        /// </summary>
        [MaxLength(3)]
        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

    }

    public class GetNoticeDataResponse
    {
        [JsonProperty("get_notice_data")]
        public List<GetNoticeData> GetNoticeData { get; set; }
    }

    public class GetNoticeData
    {
        [JsonProperty("notice_id")]
        public int NoticeID { get; set; }

        [JsonProperty("notice_title")]
        public string NoticeTitle { get; set; }

        [JsonProperty("notice_description")]
        public string NoticeDescription { get; set; }

        [JsonProperty("notice_issue_date")]
        public string NoticeDate { get; set; }

        [JsonProperty("notice_expiry_date")]
        public string NoticeExpiryDate { get; set; }

        [JsonProperty("notice_file_name")]
        public string NoticeFileName { get; set; }

        [JsonProperty("notice_file_path")]
        public string NoticeFilePath { get; set; }

    }
}