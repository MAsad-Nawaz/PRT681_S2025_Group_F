using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class ResponseLogin
    {
        public string BearerToken { get; set; }

        public DateTime IssueTime { get; set; }

        public DateTime ExpiryTime { get; set; }

    }
}