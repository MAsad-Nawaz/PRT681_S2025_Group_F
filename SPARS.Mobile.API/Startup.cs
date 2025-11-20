using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using SSS.Mobile.API.Models;

[assembly: OwinStartup(typeof(SSS.Mobile.API.Startup))]

namespace SSS.Mobile.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
    
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath=new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                Provider = new SPARSMobileAPIAuthProvider()
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());  

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            ConfigureAuth(app);
        }
    }
}
