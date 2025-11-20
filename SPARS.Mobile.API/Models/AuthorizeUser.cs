using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace SSS.Mobile.API.Models
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {   
            base.OnAuthorization(actionContext);
        }
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            RequestData<VoidClass> l_RequestData = new RequestData<VoidClass>();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            l_CommonFunctions.SetResponseType<VoidClass>(l_RequestData, HttpStatusCode.Forbidden, HttpStatusCode.Forbidden, "You are not Authorized to access this resource");
            base.HandleUnauthorizedRequest(actionContext);

            actionContext.Response = actionContext.Request.CreateResponse(
                    l_RequestData
                );
        }
    }
}