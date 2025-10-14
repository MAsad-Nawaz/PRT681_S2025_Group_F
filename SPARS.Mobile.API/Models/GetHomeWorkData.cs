using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class GetHomeWorkData
    {
        [JsonProperty("ahw_id")]
        public int AHW_ID { get; set; }

        [JsonProperty("class_id")]
        public int Class_ID { get; set; }

        [JsonProperty("section_id")]
        public int Section_ID { get; set; }

        [JsonProperty("sb_id")]
        public int SB_ID { get; set; }

        [JsonProperty("sb_code")]
        public string SB_Code { get; set; }

        [JsonProperty("emp_name")]
        public string EMP_Name { get; set; }

        [JsonProperty("section_name")]
        public string Section_Name { get; set; }

        [JsonProperty("submission_date")]
        public string Submission_Date { get; set; }

        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("evaluation_date")]
        public string Evaluation_Date { get; set; }

        [JsonProperty("assign_date")]
        public string Assign_Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("warehouse_id")]
        public string WarehouseID { get; set; }

        [JsonProperty("class_name")]
        public string Class_Name { get; set; }

        [JsonProperty("submission_by")]
        public string Submission_By { get; set; }

        [JsonProperty("status_id")]
        public int Status_ID { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("assigned_homeWork_path")]
        public string Assigned_HomeWork_Path { get; set; }

        [JsonProperty("submit_homeWork_path")]
        public string Submit_HomeWork_Path { get; set; }
    }

    public class GetHomeWorkBadgeData
    {
        [JsonProperty("row_id")]
        public int RowID { get; set; }

        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("sb_id")]
        public int SB_ID { get; set; }

        [JsonProperty("sb_code")]
        public string SB_Code { get; set; }

        [JsonProperty("warehouseid")]
        public string WarehouseID { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("pending_count")]
        public int PendingCount { get; set; }

        [JsonProperty("submitted_count")]
        public int SubmittedCount { get; set; }

        [JsonProperty("background_color")]
        public string BackgroundColor { get; set; }

        [JsonProperty("text_color")]
        public string TextColor { get; set; }
    }

    public class GetHomeWorkBadgeStatusData
    {
        [JsonProperty("row_id")]
        public int RowID { get; set; }

        [JsonProperty("sb_name")]
        public string SB_Name { get; set; }

        [JsonProperty("sb_id")]
        public int SB_ID { get; set; }

        [JsonProperty("sb_code")]
        public string SB_Code { get; set; }

        [JsonProperty("warehouseid")]
        public string WarehouseID { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("status_id")]
        public int Status_ID { get; set; }

        [JsonProperty("status_description")]
        public string Status_Description { get; set; }

        [JsonProperty("background_color")]
        public string BackgroundColor { get; set; }

        [JsonProperty("text_color")]
        public string TextColor { get; set; }
    }
}