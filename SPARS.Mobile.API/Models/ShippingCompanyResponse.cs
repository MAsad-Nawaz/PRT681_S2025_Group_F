using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SSS.Mobile.API.Models
{
    public class ShippingCompanyResponse
    {
        [JsonProperty("shipping_company")]
        public List<string> ShippingCompanies { get; set; }
    }
}