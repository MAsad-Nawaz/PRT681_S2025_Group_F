using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
 public class UserSetup
    {

     public long SalesOrderNo { get; set; }

     public bool IsSetCustomerPO { get; set; }

     public string UserID { get; set; }

     public int UserNo { get; set; }

     public string ConnectionString { get; set; }
     
     public DBConnector Connection;

    }
}
