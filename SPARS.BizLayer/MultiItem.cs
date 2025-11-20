using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
    class MultiItem
    {
        public string Description { get; set; }
       
        public string ID { get; set; }

        public string Value { get; set; }

        public Object Data { get; set; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
