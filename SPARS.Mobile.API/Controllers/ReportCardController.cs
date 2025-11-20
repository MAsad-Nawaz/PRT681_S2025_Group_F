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
    [RoutePrefix("api/ReportCard")]
    public class ReportCardController : ServiceController
    {

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetExamResult")]
        public RequestData<GetExamResultResponse> GetExamResult(GetExamResultInput l_GetExamResultInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetExamResultResponse> l_GetExamResultResponse = new RequestData<GetExamResultResponse>();
            l_GetExamResultResponse.RequestResults.ResultDetails = new GetExamResultResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetExamResultInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetExamResultResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetExamResultResponse.RequestResults.ResultDetails = l_CommonFunctions.GetExamResult(l_GetExamResultInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetExamResultResponse>(l_GetExamResultResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetExamResultResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetExamResultResponse>(l_GetExamResultResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetExamResultResponse;
        }

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetExamResultDetail")]
        public RequestData<GetExamResultDetailResponse> GetExamResultDetail(GetExamResultDetailInput l_GetExamResultDetailInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetExamResultDetailResponse> l_GetExamResultDetailResponse = new RequestData<GetExamResultDetailResponse>();
            l_GetExamResultDetailResponse.RequestResults.ResultDetails = new GetExamResultDetailResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetExamResultDetailInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetExamResultDetailResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetExamResultDetailResponse.RequestResults.ResultDetails = l_CommonFunctions.GetExamResultDetail(l_GetExamResultDetailInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetExamResultDetailResponse>(l_GetExamResultDetailResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetExamResultDetailResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetExamResultDetailResponse>(l_GetExamResultDetailResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetExamResultDetailResponse;
        }

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetSubResultDetail")]
        public RequestData<SubjectResultDetailResponse> GetSubResultDetail(SubjectResultDetailInput l_SubjectResultDetailInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<SubjectResultDetailResponse> l_SubjectResultDetailResponse = new RequestData<SubjectResultDetailResponse>();
            l_SubjectResultDetailResponse.RequestResults.ResultDetails = new SubjectResultDetailResponse();
            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_SubjectResultDetailInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_SubjectResultDetailResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_SubjectResultDetailResponse.RequestResults.ResultDetails = l_CommonFunctions.GetSubResultDetail(l_SubjectResultDetailInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<SubjectResultDetailResponse>(l_SubjectResultDetailResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_SubjectResultDetailResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<SubjectResultDetailResponse>(l_SubjectResultDetailResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }
            return l_SubjectResultDetailResponse;
        }
        [HttpPost]
        [Route("GetScheduleMarksDetail")]
        public RequestData<ScheduleMarksDetailResponse> GetScheduleMarksDetail(ScheduleMarksDetailInput l_ScheduleMarksDetailInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<ScheduleMarksDetailResponse> l_ScheduleMarksDetailResponse = new RequestData<ScheduleMarksDetailResponse>();
            l_ScheduleMarksDetailResponse.RequestResults.ResultDetails = new ScheduleMarksDetailResponse();
            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_ScheduleMarksDetailInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_ScheduleMarksDetailResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_ScheduleMarksDetailResponse.RequestResults.ResultDetails = l_CommonFunctions.GetScheduleMarksDetail(l_ScheduleMarksDetailInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<ScheduleMarksDetailResponse>(l_ScheduleMarksDetailResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_ScheduleMarksDetailResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<ScheduleMarksDetailResponse>(l_ScheduleMarksDetailResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }
            return l_ScheduleMarksDetailResponse;
        }
        [HttpPost]
        [Route("GetAssesmentMarksDetail")]
        public RequestData<ScheduleMarksDetailResponse> GetAssesmentMarksDetail(ScheduleMarksDetailInput l_ScheduleMarksDetailInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<ScheduleMarksDetailResponse> l_ScheduleMarksDetailResponse = new RequestData<ScheduleMarksDetailResponse>();
            l_ScheduleMarksDetailResponse.RequestResults.ResultDetails = new ScheduleMarksDetailResponse();
            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_ScheduleMarksDetailInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_ScheduleMarksDetailResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_ScheduleMarksDetailResponse.RequestResults.ResultDetails = l_CommonFunctions.GetAssesmentMarksDetail(l_ScheduleMarksDetailInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<ScheduleMarksDetailResponse>(l_ScheduleMarksDetailResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_ScheduleMarksDetailResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<ScheduleMarksDetailResponse>(l_ScheduleMarksDetailResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }
            return l_ScheduleMarksDetailResponse;
        }
        [HttpPost]
        [Route("RemarksDetail")]
        public RequestData<ResultRemarksResponse> RemarksDetail(ResultRemarksInput l_ResultRemarksInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<ResultRemarksResponse> l_ResultRemarksResponse = new RequestData<ResultRemarksResponse>();
            l_ResultRemarksResponse.RequestResults.ResultDetails = new ResultRemarksResponse();
            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_ResultRemarksInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_ResultRemarksResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_ResultRemarksResponse.RequestResults.ResultDetails = l_CommonFunctions.RemarksDetail(l_ResultRemarksInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<ResultRemarksResponse>(l_ResultRemarksResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_ResultRemarksResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<ResultRemarksResponse>(l_ResultRemarksResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }
            return l_ResultRemarksResponse;
        }
        [HttpPost]
        [Route("DownloadReportCard")]
        public string DownloadReportCard()
        {
            return "";
        }

    }
}
