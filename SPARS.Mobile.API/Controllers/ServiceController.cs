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
    [RoutePrefix("api/Service")]
    public class ServiceController : ApiController
    {

        //#region LoginScreen

        //    /// <summary>
        //    /// This method is used to get list of warehouses against user.
        //    /// </summary>
        //    [HttpPost]
        //    [Route("GetWarehouse")]
        //    public RequestData<WarehouseResponse> GetWarehouse()
        //    {
        //        int l_UserNo = Convert.ToInt32(getClaims("UserNo"));                
        //        CommonFunctions l_CommonFunctions = new CommonFunctions();
        //        int l_RequestID = 0;
        //        string l_ResponseJson = string.Empty;
        //        MessageResponse l_MessageResponse = new MessageResponse();
        //        RequestData<WarehouseResponse> l_WarehouseResponse = new RequestData<WarehouseResponse>();
        //        l_WarehouseResponse.RequestResults.ResultDetails = new WarehouseResponse();

        //        try
        //        {
        //            l_RequestID = PublicFunction.SMARequestLog(l_UserNo.ToString(), MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //            l_WarehouseResponse.RequestHeader.Id = l_RequestID.ToString();
        //            l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //            l_WarehouseResponse.RequestResults.ResultDetails = l_CommonFunctions.GetWarehouse(l_UserNo, ref l_MessageResponse);
        //            l_CommonFunctions.SetResponseType<WarehouseResponse>(l_WarehouseResponse, l_MessageResponse);
        //            l_ResponseJson = JsonConvert.SerializeObject(l_WarehouseResponse);
        //            PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //            l_CommonFunctions.SetResponseType<WarehouseResponse>(l_WarehouseResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured, ex.Message);
        //            throw;
        //        }

        //        return l_WarehouseResponse;
        //    }

        //#endregion

        //#region PaperLessActualPickup

        ///// <summary>
        ///// This method is used to get data of Printers.
        ///// </summary>
        /////

        //[HttpPost]
        //[Route("GetPrinters")]
        //private RequestData<GetPrintersResponse> GetPrinters(GetPrintersInput l_GetPrintersInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<GetPrintersResponse> l_GetPrintersResponse = new RequestData<GetPrintersResponse>();
        //    l_GetPrintersResponse.RequestResults.ResultDetails = new GetPrintersResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_GetPrintersInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_GetPrintersResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_GetPrintersResponse.RequestResults.ResultDetails = l_CommonFunctions.GetPrintersList(l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<GetPrintersResponse>(l_GetPrintersResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_GetPrintersResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<GetPrintersResponse>(l_GetPrintersResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_GetPrintersResponse;
        //}


        ///// <summary>
        ///// This method is used to get data of Batches.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetPickupBatches")]
        //public RequestData<BatchesResponse> GetPickupBatches(BatchesInput p_BatchesInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<BatchesResponse> l_BatchesResponse = new RequestData<BatchesResponse>();
        //    l_BatchesResponse.RequestResults.ResultDetails = new BatchesResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(p_BatchesInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_BatchesResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_BatchesResponse.RequestResults.ResultDetails = l_CommonFunctions.GetBatches(p_BatchesInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<BatchesResponse>(l_BatchesResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_BatchesResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<BatchesResponse>(l_BatchesResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //    }

        //    return l_BatchesResponse;
        //}

        ///// <summary>
        ///// This method is used to get data of Floors.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetPickupFloor")]
        //public RequestData<FloorResponse> GetPickupFloor(FloorInput p_FloorInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<FloorResponse> l_FloorResponse = new RequestData<FloorResponse>();
        //    l_FloorResponse.RequestResults.ResultDetails = new FloorResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(p_FloorInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_FloorResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_FloorResponse.RequestResults.ResultDetails = l_CommonFunctions.GetFloors(p_FloorInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<FloorResponse>(l_FloorResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_FloorResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<FloorResponse>(l_FloorResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //    }

        //    return l_FloorResponse;
        //}

        ///// <summary>
        ///// This method is used to get data of Rows.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetPickupRows")]
        //public RequestData<RowResponse> GetPickupRows(RowInput p_RowInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<RowResponse> l_RowResponse = new RequestData<RowResponse>();
        //    l_RowResponse.RequestResults.ResultDetails = new RowResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(p_RowInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_RowResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_RowResponse.RequestResults.ResultDetails = l_CommonFunctions.GetRows(p_RowInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<RowResponse>(l_RowResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_RowResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<RowResponse>(l_RowResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //    }

        //    return l_RowResponse;
        //}

        ///// <summary>
        ///// This method is used to get data of ShipCompanies.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetPickupShippingCompany")]
        //public RequestData<ShippingCompanyResponse> GetPickupShippingCompany()
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<ShippingCompanyResponse> l_ShippingCompanyResponse = new RequestData<ShippingCompanyResponse>();
        //    l_ShippingCompanyResponse.RequestResults.ResultDetails = new ShippingCompanyResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject("NO INPUT");
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_ShippingCompanyResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_ShippingCompanyResponse.RequestResults.ResultDetails = l_CommonFunctions.GetShippingComapny(l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<ShippingCompanyResponse>(l_ShippingCompanyResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_ShippingCompanyResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<ShippingCompanyResponse>(l_ShippingCompanyResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //    }

        //    return l_ShippingCompanyResponse;
        //}

        ///// <summary>
        ///// This method is used to get data of locations Grid.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetPickupBatchInfo")]
        //public RequestData<PickupBatchInfoResponse> GetPickupBatchInfo(PickupBatchInfoInput l_PickupBatchInfoInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<PickupBatchInfoResponse> l_PickupBatchInfoResponse = new RequestData<PickupBatchInfoResponse>();
        //    l_PickupBatchInfoResponse.RequestResults.ResultDetails = new PickupBatchInfoResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_PickupBatchInfoInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_PickupBatchInfoResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_PickupBatchInfoResponse.RequestResults.ResultDetails = l_CommonFunctions.GetPickupBatchInfoData(l_PickupBatchInfoInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<PickupBatchInfoResponse>(l_PickupBatchInfoResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_PickupBatchInfoResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<PickupBatchInfoResponse>(l_PickupBatchInfoResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_PickupBatchInfoResponse;
        //}

        ///// <summary>
        ///// This method is used to get data of Items Grid against locations.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetItems")]
        //public RequestData<GetItemsResponse> GetItems(GetItemsInput l_GetItemsInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<GetItemsResponse> l_GetItemsResponse = new RequestData<GetItemsResponse>();
        //    l_GetItemsResponse.RequestResults.ResultDetails = new GetItemsResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_GetItemsInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_GetItemsResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_GetItemsResponse.RequestResults.ResultDetails = l_CommonFunctions.GetItemsData(l_GetItemsInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<GetItemsResponse>(l_GetItemsResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_GetItemsResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<GetItemsResponse>(l_GetItemsResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_GetItemsResponse;
        //}

        ///// <summary>
        ///// This method is used to Get data of Show Items(Button Click).
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("ShowAllItems")]
        //public RequestData<ShowItemsResponse> ShowAllItems(ShowItemsInput l_ShowItemsInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<ShowItemsResponse> l_ShowItemsResponse = new RequestData<ShowItemsResponse>();
        //    l_ShowItemsResponse.RequestResults.ResultDetails = new ShowItemsResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_ShowItemsInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_ShowItemsResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_ShowItemsResponse.RequestResults.ResultDetails = l_CommonFunctions.GetAllItems(l_ShowItemsInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<ShowItemsResponse>(l_ShowItemsResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_ShowItemsResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<ShowItemsResponse>(l_ShowItemsResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_ShowItemsResponse;
        //}

        ///// <summary>
        ///// This method is used to Unpick Items(Button Click).
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("UnPickItem")]
        //public RequestData<UnPickItemResponse> UnPickItem(UnPickItemInput l_UnPickItemInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<UnPickItemResponse> l_UnPickItemResponse = new RequestData<UnPickItemResponse>();
        //    l_UnPickItemResponse.RequestResults.ResultDetails = new UnPickItemResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_UnPickItemInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_UnPickItemResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_UnPickItemResponse.RequestResults.ResultDetails = l_CommonFunctions.RemovePulledItem(l_UnPickItemInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<UnPickItemResponse>(l_UnPickItemResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_UnPickItemResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<UnPickItemResponse>(l_UnPickItemResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_UnPickItemResponse;
        //}

        ///// <summary>
        ///// This method is used to set Item Not Found(Button Click).
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("MarkNotFound")]
        //public RequestData<MarkNotFoundResponse> MarkNotFound(MarkNotFoundInput l_ItemNotFoundInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<MarkNotFoundResponse> l_UnPickItemResponse = new RequestData<MarkNotFoundResponse>();
        //    l_UnPickItemResponse.RequestResults.ResultDetails = new MarkNotFoundResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_ItemNotFoundInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_UnPickItemResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_UnPickItemResponse.RequestResults.ResultDetails = l_CommonFunctions.SetItemNotFound(l_ItemNotFoundInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<MarkNotFoundResponse>(l_UnPickItemResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_UnPickItemResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<MarkNotFoundResponse>(l_UnPickItemResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_UnPickItemResponse;
        //}

        ///// <summary>
        ///// This method is used to set Items Locations Details.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetAllItemLocations")]
        //public RequestData<AllItemLocationResponse> GetAllItemLocations(AllItemLocationInput l_AllItemLocationInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<AllItemLocationResponse> l_AllItemLocationResponse = new RequestData<AllItemLocationResponse>();
        //    l_AllItemLocationResponse.RequestResults.ResultDetails = new AllItemLocationResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_AllItemLocationInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_AllItemLocationResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_AllItemLocationResponse.RequestResults.ResultDetails = l_CommonFunctions.GetAllItemLocation(l_AllItemLocationInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<AllItemLocationResponse>(l_AllItemLocationResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_AllItemLocationResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<AllItemLocationResponse>(l_AllItemLocationResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //    }

        //    return l_AllItemLocationResponse;
        //}

        ///// <summary>
        ///// This method is used to set Location.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("ChangeLocation")]
        //public RequestData<ChangeItemLocationResponse> ChangeLocation(ChangeItemLocationInput l_ChangeItemLocationInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<ChangeItemLocationResponse> l_ChangeItemLocationResponse = new RequestData<ChangeItemLocationResponse>();
        //    l_ChangeItemLocationResponse.RequestResults.ResultDetails = new ChangeItemLocationResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_ChangeItemLocationInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_ChangeItemLocationResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_ChangeItemLocationResponse.RequestResults.ResultDetails = l_CommonFunctions.ChangeItemlocation(l_ChangeItemLocationInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<ChangeItemLocationResponse>(l_ChangeItemLocationResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_ChangeItemLocationResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<ChangeItemLocationResponse>(l_ChangeItemLocationResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_ChangeItemLocationResponse;
        //}

        ///// <summary>
        ///// This method is used to Pick Scanned Item.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("PickItem")]
        //public RequestData<PickItemResponse> PickItem(PickItemInput l_PickItemInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<PickItemResponse> l_ChangeItemLocationResponse = new RequestData<PickItemResponse>();
        //    l_ChangeItemLocationResponse.RequestResults.ResultDetails = new PickItemResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_PickItemInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_ChangeItemLocationResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_ChangeItemLocationResponse.RequestResults.ResultDetails = l_CommonFunctions.PickingScannedItem(l_PickItemInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<PickItemResponse>(l_ChangeItemLocationResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_ChangeItemLocationResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<PickItemResponse>(l_ChangeItemLocationResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_ChangeItemLocationResponse;
        //}

        //[HttpPost]
        //[Route("APIVersion")]
        //public RequestData<VoidClass> APIVersion()
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = "NO_INPUT";
        //    string l_ResponseJson = string.Empty;
        //    RequestData<VoidClass> l_VoidResponse = new RequestData<VoidClass>();
        //    l_VoidResponse.RequestResults.ResultDetails = new VoidClass();

        //    try
        //    {
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_VoidResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_VoidResponse);
        //        l_CommonFunctions.SetResponseType<VoidClass>(l_VoidResponse, GlobalDeclarations.ResponseType.Success, GlobalDeclarations.SuccessCodes.OperationCompleted);

        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<VoidClass>(l_VoidResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_VoidResponse;
        //}

        //#endregion

        //#region ConfirmShipment 

        //[HttpPost]
        //[Route("VerifyTrackingNumber")]
        //public RequestData<VerifyTrackingNumberResponse> VerifyTrackingNumber(VerifyTrackingNumberInput p_VerifyTrackingNumberInputInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<VerifyTrackingNumberResponse> l_GetConfirmShipmentItemsResponse = new RequestData<VerifyTrackingNumberResponse>();
        //    l_GetConfirmShipmentItemsResponse.RequestResults.ResultDetails = new VerifyTrackingNumberResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(p_VerifyTrackingNumberInputInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_GetConfirmShipmentItemsResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_GetConfirmShipmentItemsResponse.RequestResults.ResultDetails = l_CommonFunctions.VerifyTrackingNumber(p_VerifyTrackingNumberInputInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<VerifyTrackingNumberResponse>(l_GetConfirmShipmentItemsResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_GetConfirmShipmentItemsResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<VerifyTrackingNumberResponse>(l_GetConfirmShipmentItemsResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //    }

        //    return l_GetConfirmShipmentItemsResponse;
        //}


        ///// <summary>
        ///// This method is used to ConfirmShipment.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("VerifyItemAgainstTracking")]
        //public RequestData<VerifyItemAgainstTrackingResponse> VerifyItemAgainstTracking(VerifyItemAgainstTrackingInput l_VerifyItemAgainstTrackingInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<VerifyItemAgainstTrackingResponse> l_VerifyItemAgainstTrackingResponse = new RequestData<VerifyItemAgainstTrackingResponse>();
        //    l_VerifyItemAgainstTrackingResponse.RequestResults.ResultDetails = new VerifyItemAgainstTrackingResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(l_VerifyItemAgainstTrackingInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_VerifyItemAgainstTrackingResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_VerifyItemAgainstTrackingResponse.RequestResults.ResultDetails = l_CommonFunctions.VerifyItemAgainstTracking(l_VerifyItemAgainstTrackingInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<VerifyItemAgainstTrackingResponse>(l_VerifyItemAgainstTrackingResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_VerifyItemAgainstTrackingResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<VerifyItemAgainstTrackingResponse>(l_VerifyItemAgainstTrackingResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //        throw;
        //    }

        //    return l_VerifyItemAgainstTrackingResponse;
        //}


        ///// <summary>
        ///// This method is used to get data of Batches.
        ///// </summary>
        /////
        //[HttpPost]
        //[Route("GetShipmentCount")]
        //public RequestData<GetShipmentCountResponse> GetShipmentCount(GetShipmentCountInput p_ShipmentCountInput)
        //{
        //    int l_UserNo = Convert.ToInt32(getClaims("UserNo"));
        //    DataTable l_Data = new DataTable();
        //    CommonFunctions l_CommonFunctions = new CommonFunctions();
        //    MessageResponse l_MessageResponse = new MessageResponse();
        //    int l_RequestID = 0;
        //    string l_RequestJson = string.Empty;
        //    string l_ResponseJson = string.Empty;
        //    RequestData<GetShipmentCountResponse> l_ShipmentCountResponse = new RequestData<GetShipmentCountResponse>();
        //    l_ShipmentCountResponse.RequestResults.ResultDetails = new GetShipmentCountResponse();

        //    try
        //    {
        //        l_RequestJson = JsonConvert.SerializeObject(p_ShipmentCountInput);
        //        l_RequestID = PublicFunction.SMARequestLog(l_RequestJson, MethodBase.GetCurrentMethod().Name, PublicFunction.GetUserIP(), l_UserNo);
        //        l_ShipmentCountResponse.RequestHeader.Id = l_RequestID.ToString();
        //        l_CommonFunctions.UseConnection(GlobalDeclarations.g_ConnectionString);
        //        l_ShipmentCountResponse.RequestResults.ResultDetails = l_CommonFunctions.GetShipmentCount(p_ShipmentCountInput, l_UserNo, ref l_MessageResponse);
        //        l_CommonFunctions.SetResponseType<GetShipmentCountResponse>(l_ShipmentCountResponse, l_MessageResponse);
        //        l_ResponseJson = JsonConvert.SerializeObject(l_ShipmentCountResponse);
        //        PublicFunction.SMAResponseLog(l_ResponseJson, l_RequestID, MethodBase.GetCurrentMethod().Name, PublicFunction.GetLocalIP());
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
        //        l_CommonFunctions.SetResponseType<GetShipmentCountResponse>(l_ShipmentCountResponse, GlobalDeclarations.ResponseType.Exception, GlobalDeclarations.ExceptionCodes.ExceptionOccured);
        //    }

        //    return l_ShipmentCountResponse;
        //}


        //#endregion

        #region PrivateMethods

        [ApiExplorerSettings(IgnoreApi = true)]
        public string getClaims(string p_ClaimType)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var claims = principal.Claims.Select(x => new { type = x.Type, value = x.Value });
            var UserNo = claims.Where(x => x.type == p_ClaimType).FirstOrDefault().value;
            return UserNo;

        }

        #endregion
    }
}
