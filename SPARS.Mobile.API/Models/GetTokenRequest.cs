using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class GetTokenRequest
    {
        public string Company { get; set; }

        public string Key { get; set; }
    }
}