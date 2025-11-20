using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using SSS.BizLayer;
using SSS.Mobile.API.Models.SPARSToken;

namespace SSS.Mobile.API.Filters
{
    public class UserAuthorizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //string l_AccessToken = String.Empty;
            //LoginInfo l_LoginInfo;
            //l_AccessToken = AppPublicFunction.GetAccessToken();
            //l_LoginInfo = SPARSToken.ReadToken(l_AccessToken, 0);
            //if (l_LoginInfo == null)
            //{
            //    actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            //}

        }
    }
}