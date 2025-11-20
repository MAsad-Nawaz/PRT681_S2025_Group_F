using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
   public class UserMenuInfo
    {
        public bool HasFullRights { get; set; }

        public List<string> HiddenPanelInterfaces { get; set; }
    }
}
