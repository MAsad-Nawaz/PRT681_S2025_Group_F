using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Mobile.API.Models
{
    public class OutPut
    {
        public OutPut()
        {
            this.ErrorDetail = new List<OutPutErrorDetail>();
        }
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<OutPutErrorDetail> ErrorDetail { get; set; }

        public string ObjectID { get; set; }

    }
}