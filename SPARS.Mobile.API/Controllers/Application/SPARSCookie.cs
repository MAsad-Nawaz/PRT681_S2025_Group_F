using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSS.BizLayer;

namespace SSS.Mobile.API.Controllers.Application
{
    public class SPARSCookie
    {
        public static void SetUserCookie(string l_Data)
        {
            SPARSCookieManager.CreateAndUpdateCookie(GlobalDeclarations.g_UserIDCookie, GlobalDeclarations.g_UserTokenExpireTime, l_Data);
        }

        public static string GetUserCookie()
        {
            return SPARSCookieManager.GetCookieValue(GlobalDeclarations.g_UserIDCookie);
        }

        public static void ClearUserCookie()
        {
            SPARSCookieManager.ExpireCookie(GlobalDeclarations.g_UserIDCookie);
        }
    }
}