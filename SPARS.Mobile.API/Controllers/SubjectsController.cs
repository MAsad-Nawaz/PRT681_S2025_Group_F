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

namespace SSS.Mobile.API.Controllers
{
    [AuthorizeUser]
    [RoutePrefix("api/Subjects")]
    public class SubjectsController : ServiceController
    {
        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetSubjectsList")]
        public RequestData<GetSubjectsResponse> GetSubjectsList(GetSubjectsInput l_GetSubjectsInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetSubjectsResponse> l_GetSubjectsResponse = new RequestData<GetSubjectsResponse>();
            l_GetSubjectsResponse.RequestResults.ResultDetails = new GetSubjectsResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetSubjectsInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetSubjectsResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetSubjectsResponse.RequestResults.ResultDetails = l_CommonFunctions.GetSubjectsList(l_GetSubjectsInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetSubjectsResponse>(l_GetSubjectsResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetSubjectsResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetSubjectsResponse>(l_GetSubjectsResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetSubjectsResponse;
        }

    }
}
