using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using SSS.Mobile.API.Models;
using SSS.Mobile.API.Providers;
using SSS.Mobile.API.Results;
using System.Data;
using SSS.BizLayer;
using System.Net;
using SSS.Mobile.API.Models.SPARSToken;
using SSS.Mobile.API.Controllers.Application;
using SSS.Mobile.API.Filters;
using System.Web.Http.Filters;
using System.Xml;
using System.Web.Script.Serialization;
using System.Reflection;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Http.Description;
//using SPARS.AndroidScannerAPI.Models;

namespace SSS.Mobile.API.Controllers
{
    [AuthorizeUser]
    [RoutePrefix("api/Profile")]

    public class ProfileController : ServiceController
    {
        /// <summary>
        /// This method is used to get data of Printers.
        /// </summary>
        ///

        [HttpPost]
        [Route("GetProfile")]
        public RequestData<GetProfileResponse> GetProfile(GetProfileInput l_GetProfileInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetProfileResponse> l_GetProfileResponse = new RequestData<GetProfileResponse>();
            l_GetProfileResponse.RequestResults.ResultDetails = new GetProfileResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetProfileInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetProfileResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetProfileResponse.RequestResults.ResultDetails = l_CommonFunctions.GetProfile(l_GetProfileInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetProfileResponse>(l_GetProfileResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetProfileResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetProfileResponse>(l_GetProfileResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetProfileResponse;
        }

        
    }
}
