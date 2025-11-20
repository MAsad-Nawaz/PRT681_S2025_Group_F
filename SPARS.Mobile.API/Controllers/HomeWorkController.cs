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
    
    [RoutePrefix("api/HomeWork")]
    public class HomeWorkController : ServiceController
    {

        /// <summary>
        /// This method is used for GetHomeWorkData.
        /// </summary>
        [HttpPost]
        [Route("GetHomeWorkData")]
        public RequestData<GetHomeWorkDataResponse> GetHomeWorkData(GetHomeWorkBadgeDataInput l_GetHomeWorkDataInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetHomeWorkDataResponse> l_GetHomeWorkDataResponse = new RequestData<GetHomeWorkDataResponse>();
            l_GetHomeWorkDataResponse.RequestResults.ResultDetails = new GetHomeWorkDataResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetHomeWorkDataInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetHomeWorkDataResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetHomeWorkDataResponse.RequestResults.ResultDetails = l_CommonFunctions.GetHomeWorkData(l_GetHomeWorkDataInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetHomeWorkDataResponse>(l_GetHomeWorkDataResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetHomeWorkDataResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetHomeWorkDataResponse>(l_GetHomeWorkDataResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetHomeWorkDataResponse;
        }

        /// <summary>
        /// This method is used for GetHomeWorkData.
        /// </summary>
        [HttpPost]
        [Route("GetHomeWorkBadgeData")]
        public RequestData<GetHomeWorkBadgeDataResponse> GetHomeWorkBadgeData(GetHomeWorkDataInput l_GetHomeWorkDataInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetHomeWorkBadgeDataResponse> l_GetHomeWorkDataResponse = new RequestData<GetHomeWorkBadgeDataResponse>();
            l_GetHomeWorkDataResponse.RequestResults.ResultDetails = new GetHomeWorkBadgeDataResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetHomeWorkDataInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetHomeWorkDataResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetHomeWorkDataResponse.RequestResults.ResultDetails = l_CommonFunctions.GetHomeWorkBadgeData(l_GetHomeWorkDataInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetHomeWorkBadgeDataResponse>(l_GetHomeWorkDataResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetHomeWorkDataResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetHomeWorkBadgeDataResponse>(l_GetHomeWorkDataResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetHomeWorkDataResponse;
        }

        /// <summary>
        /// This method is used for GetHomeWorkData.
        /// </summary>
        [HttpPost]
        [Route("GetHomeWorkBadgeStatusData")]
        public RequestData<GetHomeWorkBadgeStatusDataResponse> GetHomeWorkBadgeStatusData(GetHomeWorkBadgeStatusDataInput l_GetHomeWorkDataInput)
        {
            int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
            DataTable l_Data = new DataTable();
            CommonFunctions l_CommonFunctions = new CommonFunctions();
            MessageResponse l_MessageResponse = new MessageResponse();
            int l_RequestID = 0;
            string l_RequestJson = string.Empty;
            string l_ResponseJson = string.Empty;
            RequestData<GetHomeWorkBadgeStatusDataResponse> l_GetHomeWorkDataResponse = new RequestData<GetHomeWorkBadgeStatusDataResponse>();
            l_GetHomeWorkDataResponse.RequestResults.ResultDetails = new GetHomeWorkBadgeStatusDataResponse();

            try
            {
                l_RequestJson = JsonConvert.SerializeObject(l_GetHomeWorkDataInput);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_GetHomeWorkDataResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_GetHomeWorkDataResponse.RequestResults.ResultDetails = l_CommonFunctions.GetHomeWorkBadgeStatusData(l_GetHomeWorkDataInput, l_UserNo, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<GetHomeWorkBadgeStatusDataResponse>(l_GetHomeWorkDataResponse, l_MessageResponse);
                l_ResponseJson = JsonConvert.SerializeObject(l_GetHomeWorkDataResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<GetHomeWorkBadgeStatusDataResponse>(l_GetHomeWorkDataResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_GetHomeWorkDataResponse;
        }

        /// <summary>
        /// This method is used for Authnticate Users.
        /// </summary>

        [HttpPost]
        [Route("GetHomeWorkDetail")]
        public string GetFeeDetail()
        {
            return "";
        }

        [HttpGet]
        public IHttpActionResult DownloadHomeWork(int homeWorkID, string warehouseID)
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
            RequestData<DownloadHomeWorkResponse> l_DownloadHomeWorkResponse = new RequestData<DownloadHomeWorkResponse>();
            l_DownloadHomeWorkResponse.RequestResults.ResultDetails = new DownloadHomeWorkResponse();
            FileResult l_FileResult = null;
            try
            {

                l_RequestJson = JsonConvert.SerializeObject(homeWorkID);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_DownloadHomeWorkResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
                l_DownloadHomeWorkResponse.RequestResults.ResultDetails = l_CommonFunctions.DownloadHomeWork(homeWorkID, l_UserNo, warehouseID, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<DownloadHomeWorkResponse>(l_DownloadHomeWorkResponse, l_MessageResponse);

                l_FilePath = l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Path;
                l_FileName = l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Name;

                if (!string.IsNullOrEmpty(l_FilePath) && !string.IsNullOrEmpty(l_FileName))
                {
                    if (File.Exists(Path.Combine(l_FilePath, l_FileName)))
                    {
                        l_FileResult = new FileResult(Path.Combine(l_FilePath, l_FileName));
                        //l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Base64 = PublicFunction.ConvertFileToBase64(Path.Combine(l_FilePath, l_FileName));
                    }
                }


                l_ResponseJson = JsonConvert.SerializeObject(l_DownloadHomeWorkResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<DownloadHomeWorkResponse>(l_DownloadHomeWorkResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_FileResult;
            //string filePath = @"D:\MyData\Documents\faisalcvlhr.pdf";
            //return new FileResult(filePath);
        }

        [HttpPost]
        public RequestData<VoidClass> SubmitHomeWork()
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
            RequestData<VoidClass> l_DownloadHomeWorkResponse = new RequestData<VoidClass>();
            l_DownloadHomeWorkResponse.RequestResults.ResultDetails = new VoidClass();
            SubmitHomeWorkModel model = new SubmitHomeWorkModel();


            try
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<SubmitHomeWorkModel>(HttpContext.Current.Request.Form["SubmitHomeWorkModel"].ToString());
                model.UserNo = l_UserNo;
                l_RequestJson = JsonConvert.SerializeObject(model);
                l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
                l_DownloadHomeWorkResponse.RequestHeader.Id = l_RequestID.ToString();
                l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);

                HttpFileCollection files = HttpContext.Current.Request.Files;
                HttpPostedFile postFile = null;
                string filePath = string.Empty;
                for (int count = 0; count <= files.Count - 1; count++)
                {
                    postFile = files[count];
                    byte[] fileBytes = PublicFunction.GetFileContent(postFile.InputStream);
                    filePath = PublicFunction.CreateFileToServerPath(GlobalDeclarations.g_UploadPath);
                    PublicFunction.WriteFileToServer(filePath, postFile.FileName , fileBytes);
                }

                if (postFile != null)
                {
                    model.FileName = postFile.FileName;
                    model.FilePath = filePath;
                }

                l_CommonFunctions.SubmitHomeWork(model, ref l_MessageResponse);
                l_CommonFunctions.SetResponseType<VoidClass>(l_DownloadHomeWorkResponse, l_MessageResponse);

                //l_FilePath = l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Path;
                //l_FileName = l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Name;

                //if (!string.IsNullOrEmpty(l_FilePath) && !string.IsNullOrEmpty(l_FileName))
                //{
                //    if (File.Exists(Path.Combine(l_FilePath, l_FileName)))
                //    {
                //        l_FileResult = new FileResult(Path.Combine(l_FilePath, l_FileName));
                //        //l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Base64 = PublicFunction.ConvertFileToBase64(Path.Combine(l_FilePath, l_FileName));
                //    }
                //}


                l_ResponseJson = JsonConvert.SerializeObject(l_DownloadHomeWorkResponse);
                PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                l_CommonFunctions.SetResponseType<VoidClass>(l_DownloadHomeWorkResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
                throw;
            }

            return l_DownloadHomeWorkResponse;
            //string filePath = @"D:\MyData\Documents\faisalcvlhr.pdf";
            //return new FileResult(filePath);
        }

        ///// <summary>
        ///// This method is used for DownloadHomeWork.
        ///// </summary>
        //[HttpPost]
        //[Route("DownloadHomeWork")]
        //public RequestData<DownloadHomeWorkResponse> DownloadHomeWork(DownloadHomeWorkInput l_DownloadHomeWorkInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    string l_FilePath = string.Empty;
        //    string l_FileName = string.Empty;
        //    RequestData<DownloadHomeWorkResponse> l_DownloadHomeWorkResponse = new RequestData<DownloadHomeWorkResponse>();
        //    l_DownloadHomeWorkResponse.RequestResults.ResultDetails = new DownloadHomeWorkResponse();

        //    try
        //    {

        //        l_RequestJson = JsonConvert.SerializeObject(l_DownloadHomeWorkInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_DownloadHomeWorkResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_DownloadHomeWorkResponse.RequestResults.ResultDetails = l_CommonFunctions.DownloadHomeWork(l_DownloadHomeWorkInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<DownloadHomeWorkResponse>(l_DownloadHomeWorkResponse, l_MessageResponse);

        //        l_FilePath = l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Path;
        //        l_FileName = l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Name;

        //        if (!string.IsNullOrEmpty(l_FilePath) && !string.IsNullOrEmpty(l_FileName))
        //        {
        //            if (File.Exists(Path.Combine(l_FilePath, l_FileName)))
        //            {
        //                l_DownloadHomeWorkResponse.RequestResults.ResultDetails.File_Base64 = PublicFunction.ConvertFileToBase64(Path.Combine(l_FilePath, l_FileName));
        //            }
        //        }


        //        l_ResponseJson = JsonConvert.SerializeObject(l_DownloadHomeWorkResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<DownloadHomeWorkResponse>(l_DownloadHomeWorkResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_DownloadHomeWorkResponse;
        //}
    }
}
