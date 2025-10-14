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
//using SPARS.AndroidScannerAPI.Models;


namespace SSS.Mobile.API.Controllers
{
    [AuthorizeUser]
    [RoutePrefix("api/ExamSchedule")]
    public class ExamScheduleController : ServiceController
    {

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetExamScheduleData")]
        public RequestData<GetExamScheduleDataResponse> GetExamScheduleData(GetExamScheduleDataInput l_GetExamScheduleDataInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetExamScheduleDataResponse> l_GetExamScheduleDataResponse = new RequestData<GetExamScheduleDataResponse>();
            l_GetExamScheduleDataResponse.RequestResults.ResultDetails = new GetExamScheduleDataResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetExamScheduleDataInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetExamScheduleDataResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetExamScheduleDataResponse.RequestResults.ResultDetails = l_CommonFunctions.GetExamScheduleData(l_GetExamScheduleDataInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetExamScheduleDataResponse>(l_GetExamScheduleDataResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetExamScheduleDataResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetExamScheduleDataResponse>(l_GetExamScheduleDataResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetExamScheduleDataResponse;
        }

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetExamScheduleDetail")]
        public RequestData<GetExamScheduleDetailResponse> GetExamScheduleDetail(GetExamScheduleDetailInput l_GetExamScheduleDetailInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetExamScheduleDetailResponse> l_GetExamScheduleDetailResponse = new RequestData<GetExamScheduleDetailResponse>();
            l_GetExamScheduleDetailResponse.RequestResults.ResultDetails = new GetExamScheduleDetailResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetExamScheduleDetailInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetExamScheduleDetailResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetExamScheduleDetailResponse.RequestResults.ResultDetails = l_CommonFunctions.GetExamScheduleDetail(l_GetExamScheduleDetailInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetExamScheduleDetailResponse>(l_GetExamScheduleDetailResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetExamScheduleDetailResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetExamScheduleDetailResponse>(l_GetExamScheduleDetailResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetExamScheduleDetailResponse;
        }

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("DownloadExamSchedule")]
        public string DownloadExamSchedule()
        {
            return "";
        }

    }
}
