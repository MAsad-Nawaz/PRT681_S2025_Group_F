using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using SSS.BizLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace SSS.Mobile.API.Models
{
    public class SPARSMobileAPIAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            RequestData<VoidClass> l_RequestData = new RequestData<VoidClass>();
            string l_ErrorDescription = string.Empty;
            string l_ResponseJson = string.Empty;
            int l_RequestID = 0;
            try
            {
                l_RequestID = PublicFunction.SMARequestLog("UserName: " + context.UserName + " Password: " + context.Password, "GrantResourceOwnerCredentials", PublicFunction.GetUserIP(),0);
                l_RequestData.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                if (l_CommonFunctions.VerifyLogin(context.UserName, PublicFunction.SPARSEncrypt(context.Password), context.Scope[0].ToString(),ref l_Data))
                {                   
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim("UserNo",l_Data.Rows[0]["UserNo"].ToString()));
                    context.Validated(new ClaimsIdentity(identity));
                }
                else
                {
                    l_ErrorDescription = Convert.ToString(l_Data.Rows[0]["Description"]);
                    l_CommonFunctions.SetResponseType<VoidClass>(l_RequestData, GlobalDeclarations.ResponseType.Error, GlobalDeclarations.ErrorCodes.Loginfailed, l_ErrorDescription);
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();  
                }
                PublicFunction.SMAResponseLog(JsonConvert.SerializeObject(l_RequestData), l_RequestID, "GrantResourceOwnerCredentials", PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                context.Rejected();  
                throw;
            }

   
        }
    }
}