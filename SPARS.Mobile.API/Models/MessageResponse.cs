using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class MessageResponse
    {
        public string Status { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }
    }
}