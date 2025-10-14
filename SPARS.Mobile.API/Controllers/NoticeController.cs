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
using System.IO;
//using SPARS.AndroidScannerAPI.Models;


namespace SSS.Mobile.API.Controllers
{
    [RoutePrefix("api/Notice")]
    public class NoticeController : ServiceController
    {

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetNoticeData")]
        public RequestData<GetNoticeDataResponse> GetNoticeData(GetnoticeDataInput l_GetNoticeInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetNoticeDataResponse> l_GetNoticeDataResponse = new RequestData<GetNoticeDataResponse>();
            l_GetNoticeDataResponse.RequestResults.ResultDetails = new GetNoticeDataResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetNoticeInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetNoticeDataResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetNoticeDataResponse.RequestResults.ResultDetails = l_CommonFunctions.GetNoticeData(l_GetNoticeInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetNoticeDataResponse>(l_GetNoticeDataResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetNoticeDataResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetNoticeDataResponse>(l_GetNoticeDataResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetNoticeDataResponse;
        }

        [HttpGet]
        [Route("DownloadNotice")]
        public IHttpActionResult DownloadNotice(int keyID, string warehouseID)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            string l_FilePath = string.Empty;
            string l_FileName = string.Empty;
            RequestData<DownloadResponse> l_DownloadResponse = new RequestData<DownloadResponse>();
            l_DownloadResponse.RequestResults.ResultDetails = new DownloadResponse();
            FileResult l_FileResult = null;
            try
            {

                l_RequestJson = JsonConvert.SerializeObject(keyID);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_DownloadResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_DownloadResponse.RequestResults.ResultDetails = l_CommonFunctions.DownloadNotice(keyID, l_UserNo, warehouseID, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<DownloadResponse>(l_DownloadResponse, l_MessageResponse);

                l_FilePath = l_DownloadResponse.RequestResults.ResultDetails.File_Path;
                l_FileName = l_DownloadResponse.RequestResults.ResultDetails.File_Name;

                if (!string.IsNullOrEmpty(l_FilePath) && !string.IsNullOrEmpty(l_FileName))
                {
                    if (File.Exists(Path.Combine(l_FilePath, l_FileName)))
                    {
                        l_FileResult = new FileResult(Path.Combine(l_FilePath, l_FileName));
                        //l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Base64 = PublicFunction.ConvertFileToBase64(Path.Combine(l_FilePath, l_FileName));
                    }
                }


                l_ResponseJson = JsonConvert.SerializeObject(l_DownloadResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<DownloadResponse>(l_DownloadResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_FileResult;
            //string filePath = @"D:\MyData\Documents\faisalcvlhr.pdf";
            //return new FileResult(filePath);
        }
        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("GetNoticeDetail")]
        public string GetNoticeDetail()
        {
            return "";
        }

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>
        [HttpPost]
        [Route("DownloadNotice")]
        public string DownloadNotice()
        {
            return "";
        }

    }
}
