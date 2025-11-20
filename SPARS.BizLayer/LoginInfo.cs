using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
    public class LoginInfo
    {
        public string UserID { get; set; }
        public GlobalDeclarations.UserGroups UserGroup { get; set; }
        public string ConnectionString { get; set; }
        public string EDILOGConnectionString { get; set; }
        public string SPARSConnectionString { get; set; }
        public string MenuTag { get; set; }

        public string LoginLocation { get; set; }

        public bool RestrictOperationLocationWise { get; set; }
   
        public bool UserWarehouses { get; set; }

        public String ClientMachine { get; set; }
        public bool IsScannerUser { get; set; }

        public string AccessToken { get; set; }
        
        public string PeriodID { get; set; }

        public string APIKey { get; set; }

        public string RemoteUserDSN { get; set; }

        public string RemoteSQLServerUID { get; set; }

        public string RemoteSQLServerPsswd { get; set; }

        public string RemoteSQLServerDS { get; set; }

        public string AdminUser { get; set; }

        public bool IsOnWeb { get; set; }

        public bool IsIntialized { get; set; }

        public bool IsB2BVendor { get; set; }

        public bool IsSalesRepVendor { get; set; }

        public bool IsB2BCustomer { get; set; }

        public string ActiveRole { get; set; }
      
        public string SelectedModule { get; set; }
        
        public string ExpirationDate { get; set; }
        
        public bool IsRestricted { get; set; }
        
        public string WarehouseList { get; set; }
        
        public int UserNo { get; set; }

        public Dictionary<string,UserMenuInfo>  MenuInfo { get; set; }

        public Companys Company { get; set; }
        
    }
}
