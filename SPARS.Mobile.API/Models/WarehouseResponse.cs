using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class WarehouseResponse
    {
        [JsonProperty("warehouses")]
        public List<Warehouse> WarehouseList { get; set; }
    }
}