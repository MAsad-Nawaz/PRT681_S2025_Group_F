using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SSS.BizLayer;
using System.Configuration;
using System.IO;

namespace SSS.Mobile.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalDeclarations.g_ApplicationPath = Server.MapPath("~/");
            GlobalDeclarations.g_ApplicationLogPath = Path.Combine(Server.MapPath("~/"),ConfigurationManager.AppSettings["LogsPath"]);
            GlobalDeclarations.g_ConnectionString = PublicFunction.Decrypt(ConfigurationManager.AppSettings["ConnectionString"]);
            GlobalDeclarations.g_SPARSConnectionString = PublicFunction.Decrypt(ConfigurationManager.AppSettings["SPARSConnectionString"]);
            GlobalDeclarations.g_UserTokenExpireTime = Convert.ToInt32(ConfigurationManager.AppSettings["UserTokenExpireTime"]);
            GlobalDeclarations.g_UserTokenRenewTime = Convert.ToInt32(ConfigurationManager.AppSettings["UserTokenRenewTime"]);
            GlobalDeclarations.g_SiteURL = ConfigurationManager.AppSettings["SiteAccessURL"];
            GlobalDeclarations.g_SecurityKey = PublicFunction.Decrypt(ConfigurationManager.AppSettings["SecurityTokenKey"]);
            GlobalDeclarations.g_EDILOGConnectionString = PublicFunction.Decrypt(ConfigurationManager.AppSettings["EDILOGConnectionString"]);
            GlobalDeclarations.g_UserNo = Convert.ToInt32(ConfigurationManager.AppSettings["UserNo"]);
            GlobalDeclarations.g_ServerName = PublicFunction.Decrypt(ConfigurationManager.AppSettings["ServerName"]);
            GlobalDeclarations.g_DataBaseName =PublicFunction.Decrypt( ConfigurationManager.AppSettings["DataBaseName"]);
            GlobalDeclarations.g_UserID = PublicFunction.Decrypt(ConfigurationManager.AppSettings["UserID"]);
            GlobalDeclarations.g_Password = PublicFunction.Decrypt(ConfigurationManager.AppSettings["Password"]);
            GlobalDeclarations.g_UserCount = ConfigurationManager.AppSettings["UserCount"];
            GlobalDeclarations.g_UploadPath = ConfigurationManager.AppSettings["UploadPath"];
            GlobalDeclarations.g_AllowedLogin = ConfigurationManager.AppSettings["AllowedLogin"];
            
        }
    }
}
