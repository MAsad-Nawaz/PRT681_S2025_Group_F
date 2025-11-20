using SSS.BizLayer;
using SPARS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Printing;
using System.Management;
using System.Globalization;
using System.IO;

namespace SSS.Mobile.API.Models
{
    public class CommonFunctions : DBEntity
    {
        public void UseConnection(string p_ConnectionString, DBConnector p_Connection = null)
        {
            try
            {
                if (string.IsNullOrEmpty(p_ConnectionString))
                {
                    this.Connection = p_Connection;
                    // Warning!!! Optional parameters not supported
                }
                else
                {
                    this.Connection = new DBConnector(p_ConnectionString);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }


        }
        
        public void SetResponseType<T>(RequestData<T> p_ResponseData, MessageResponse p_MessageResponse, string p_Description = "")
        {
            try
            {
                p_ResponseData.RequestResults.ResultHeader.Code = Convert.ToString(p_MessageResponse.Code);
                p_ResponseData.RequestResults.ResultHeader.Type = Convert.ToString(p_MessageResponse.Status);
                if (string.IsNullOrEmpty(p_Description))
                {
                    p_ResponseData.RequestResults.ResultHeader.Description = p_MessageResponse.Description;
                }
                else
                {
                    p_ResponseData.RequestResults.ResultHeader.Description = p_Description;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public void SetResponseType<T>(RequestData<T> p_ResponseData, Enum p_SelectedResponseType, Enum p_ResponseCode, string p_Description = "")
        {
            try
            {
                p_ResponseData.RequestResults.ResultHeader.Code = Convert.ToString(Convert.ToInt32(p_ResponseCode));
                p_ResponseData.RequestResults.ResultHeader.Type = p_SelectedResponseType.ToString();
                if (string.IsNullOrEmpty(p_Description))
                {
                    p_ResponseData.RequestResults.ResultHeader.Description = PublicFunction.GetEnumDescription(p_ResponseCode);
                }
                else
                {
                    p_ResponseData.RequestResults.ResultHeader.Description = p_Description;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public WarehouseResponse GetWarehouse(int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            WarehouseResponse l_Warehouses = new WarehouseResponse();
            List<Warehouse> l_ListWarehouses = new List<Warehouse>();

            try
            {
                l_Query = "EXEC SSS_MA_GetWarehouse ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param;


                this.Connection.GetData(l_Query, ref l_Data);

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        foreach (DataRow l_DataRows in l_Data.Rows)
                        {
                            Warehouse l_Warehouse = new Warehouse();
                            l_Warehouse.Id = PublicFunction.ConvertNull(l_DataRows["Id"], "").ToString();
                            l_Warehouse.Description = PublicFunction.ConvertNull(l_DataRows["Description"], "").ToString();
                            l_ListWarehouses.Add(l_Warehouse);
                        }
                        l_Warehouses.WarehouseList = l_ListWarehouses;
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_Warehouses;
        }

        public bool VerifyLogin(string p_UserID, string p_Password,string p_firebasetoken, ref DataTable p_Data)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            bool l_Result = false;

            try
            {
                l_Query = "EXEC SSS_MA_LoginVerify ";

                PublicFunction.FieldToParam(p_UserID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;

                PublicFunction.FieldToParam(p_Password, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", " + l_Param;
                PublicFunction.FieldToParam(p_firebasetoken, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);

                p_Data = l_Data;

                if (PublicFunction.ConvertNull(l_Data.Rows[0]["Success"], "").ToString() == "True" && PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], "").ToString() == "100")
                {
                    l_Result = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_Result;
        }

        public void SetErrorResponse(Enum l_Enum, ref MessageResponse p_MessageResponse)
        {
            p_MessageResponse.Status =  GlobalDeclarations.ResponseType.Error.ToString();
            p_MessageResponse.Code = Convert.ToInt32(l_Enum);
            p_MessageResponse.Description = PublicFunction.GetEnumDescription(l_Enum);
        }

        public void SetSuccessResponse(Enum l_Enum, ref MessageResponse p_MessageResponse)
        {
            p_MessageResponse.Status = GlobalDeclarations.ResponseType.Success.ToString();
            p_MessageResponse.Code = Convert.ToInt32(l_Enum);
            p_MessageResponse.Description = PublicFunction.GetEnumDescription(l_Enum);
        }

        public GetPrintersResponse GetPrintersList(int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetPrintersResponse l_GetPrintersResponse = new GetPrintersResponse();
            try
            {
                var server = new PrintServer();
                var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Shared, EnumeratedPrintQueueTypes.Connections });

                l_GetPrintersResponse.Printers = new List<string>();
                foreach (PrintQueue pq in queues)
                {
                    l_GetPrintersResponse.Printers.Add(pq.Name.ToString());
                }

                if (l_GetPrintersResponse.Printers.Count > 0)
                {
                    SetSuccessResponse(GlobalDeclarations.SuccessCodes.OperationCompleted, ref p_MessageResponse);
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {

            }
            return l_GetPrintersResponse;
        }

        public VerifyItemAgainstTrackingResponse VerifyItemAgainstTracking(VerifyItemAgainstTrackingInput p_VerifyItemAgainstTrackingInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            VerifyItemAgainstTrackingResponse l_VerifyItemAgainstTrackingResponse = new VerifyItemAgainstTrackingResponse();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "Exec SAP_ShipmentStatus ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.NullableNumber);
                l_Query += l_Param;

                PublicFunction.FieldToParam(p_VerifyItemAgainstTrackingInput.TrackingNo, ref l_Param, PublicFunction.FieldTypes.NullableString);
                l_Query += ", @p_TrackingNo= " + l_Param;

                PublicFunction.FieldToParam(p_VerifyItemAgainstTrackingInput.itemID, ref l_Param, PublicFunction.FieldTypes.NullableString);
                l_Query += ", @p_ItemID= " + l_Param;

                PublicFunction.FieldToParam(p_VerifyItemAgainstTrackingInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.NullableString);
                l_Query += ", @p_WHSID= " + l_Param;

                PublicFunction.FieldToParam(p_VerifyItemAgainstTrackingInput.ShippingCompany, ref l_Param, PublicFunction.FieldTypes.NullableString);
                l_Query += ", @p_Shipvia= " + l_Param;

                PublicFunction.FieldToParam(p_VerifyItemAgainstTrackingInput.ContainerNo, ref l_Param, PublicFunction.FieldTypes.NullableString);
                l_Query += ", @p_ContainerNo= " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);

                //l_Data = l_Dataset.Tables[1];
                if (l_Data.Rows.Count > 0)
                {
                    //p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0][""], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["MsgID"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ErrorMessage"], "").ToString();

                    if (Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["MsgID"], 0)) == 0)
                    {
                        p_MessageResponse.Status = GlobalDeclarations.ResponseType.Success.ToString();
                        p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["MsgID"], 0));
                        p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ErrorMessage"], "").ToString();
                    }
                    else
                    {
                        p_MessageResponse.Status = GlobalDeclarations.ResponseType.Exception.ToString();
                        p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["MsgID"], 0));
                        p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ErrorMessage"], "").ToString();
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_VerifyItemAgainstTrackingResponse;
        }

        public GetShipmentCountResponse GetShipmentCount(GetShipmentCountInput p_ShipmentCountInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetShipmentCountResponse l_ShipmentCountResponse = new GetShipmentCountResponse();
            //l_ShipmentCountResponse.TotalShipmentCount = new GetShipmentCountResponse();
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "Exec SAP_ShipmentCount ";

                //PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                //l_Query += l_Param;

                PublicFunction.FieldToParam(p_ShipmentCountInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += "@p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_ShipmentCountInput.TotalShipmentCount, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_TotalShipmentCount = " + l_Param;
                

                PublicFunction.FieldToParam(p_ShipmentCountInput.ConfirmShipmentCount, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_ConfirmShipmentCount = " + l_Param;
                

                this.Connection.GetData(l_Query, ref l_Data);
                if (l_Data.Rows.Count > 0)
                {
                    //p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    //p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    //p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    //if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                   // {
                    SetSuccessResponse(GlobalDeclarations.SuccessCodes.OperationCompleted, ref p_MessageResponse);
                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            //PickupBatchInfo l_PickupBatchInfo = new PickupBatchInfo();
                            //l_PickupBatchInfo.Show = PublicFunction.ConvertNull(l_Row["Show"], "").ToString();
                            //l_PickupBatchInfo.FloorNo = PublicFunction.ConvertNull(l_Row["FloorNo"], "").ToString();
                            //l_PickupBatchInfo.RowNo = PublicFunction.ConvertNull(l_Row["RowNo"], "").ToString();
                            l_ShipmentCountResponse.TotalShipmentCount = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["TotalShipmentCount"], 0));
                            l_ShipmentCountResponse.ConfirmShipmentCount = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["ConfirmShipmentCount"], 0));
                            //l_PickupBatchInfo.LocationID = PublicFunction.ConvertNull(l_Row["LocationID"], "").ToString();
                            ////l_PickupBatchInfo.ItemsCount = PublicFunction.ConvertNull(l_Row["Count"], "").ToString();
                            //l_PickupBatchInfo.Status = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Status"], 0));
                            //l_PickupBatchInfo.ShippingCompany = PublicFunction.ConvertNull(l_Row["ShipCompany"], "").ToString();
                            //l_PickupBatchInfo.BatchNo = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["BatchNo"], 0));

                            //p_ShipmentCountInput.PickupBatchInfo.Add(l_PickupBatchInfo);
                        }
                    //}
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_ShipmentCountResponse;
        }


        public VerifyTrackingNumberResponse VerifyTrackingNumber(VerifyTrackingNumberInput p_VerifyTrackingNumberInputInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            VerifyTrackingNumberResponse l_VerifyTrackingNumberResponse = new VerifyTrackingNumberResponse();
            List<ItemAgainstTracking> l_itemlist = new List<ItemAgainstTracking>();

            try
            {
                l_Query = "Exec sp_ShipmentTrackingStatus ";

                //PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                //l_Query += l_Param;

                //PublicFunction.FieldToParam(p_VerifyTrackingNumberInputInput.TrackingNo, ref l_Param, PublicFunction.FieldTypes.String);
                //l_Query += l_Param;


                PublicFunction.FieldToParam(p_VerifyTrackingNumberInputInput.TrackingNo, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += "@p_TrackingNo = " + l_Param;

                PublicFunction.FieldToParam(p_VerifyTrackingNumberInputInput.IsReturnItem, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_IsReturnItem = " + l_Param;
                



                this.Connection.GetData(l_Query, ref l_Data);

                if (l_Data.Rows.Count > 0)
                {

                    //if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    //{
                    
                    //}
                    if (Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0)) == 100)
                    {

                        p_MessageResponse.Status = GlobalDeclarations.ResponseType.Success.ToString();
                        p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                        p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["Description"], "").ToString();

                        if (p_VerifyTrackingNumberInputInput.IsReturnItem !=0)
                        {
                            foreach (DataRow l_DataRows in l_Data.Rows)
                            {
                                ItemAgainstTracking l_ItemAgainstTracking = new ItemAgainstTracking();

                                l_ItemAgainstTracking.itemID = PublicFunction.ConvertNull(l_DataRows["ItemID"], "").ToString();
                                l_ItemAgainstTracking.ConfirmedStatus =  PublicFunction.ConvertNull(l_DataRows["ConfirmedStatus"], "").ToString();
                                l_itemlist.Add(l_ItemAgainstTracking);
                            }


                            l_VerifyTrackingNumberResponse.items = l_itemlist;
                        }
                        
                    }
                    else
                    {
                        p_MessageResponse.Status = GlobalDeclarations.ResponseType.Exception.ToString();
                        p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                        p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["Description"], "").ToString();
                    }

                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_VerifyTrackingNumberResponse;
        }

        #region Profile

        public GetProfileResponse GetProfile(GetProfileInput p_GetProfileInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetProfileResponse l_GetProfileResponse = new GetProfileResponse();
            l_GetProfileResponse.Profile = new List<ProfileData>();
            l_GetProfileResponse.ParentsData = new List<ParentData>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_GetProfile ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = "+ l_Param;

                PublicFunction.FieldToParam(p_GetProfileInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                this.Connection.GetDataSP(l_Query, ref l_Dataset);

                l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            ProfileData l_ProfileData = new ProfileData();

                            l_ProfileData.STD_Roll_No = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["STD_Roll_No"], ""));
                            l_ProfileData.STD_Name = PublicFunction.ConvertNull(l_Row["STD_Name"], "").ToString();
                            l_ProfileData.STD_CNIC = PublicFunction.ConvertNull(l_Row["STD_CNIC"], "").ToString();
                            l_ProfileData.STD_Gender = PublicFunction.ConvertNull(l_Row["STD_Gender"], "").ToString();
                            l_ProfileData.STD_DOB = PublicFunction.ConvertNull(l_Row["STD_DOB"], "").ToString().Trim();
                            l_ProfileData.STD_Maling_Address = PublicFunction.ConvertNull(l_Row["STD_Maling_Address"], "").ToString();
                            l_ProfileData.STD_Permanent_Address = PublicFunction.ConvertNull(l_Row["STD_Permanent_Address"], "").ToString();
                            l_ProfileData.STD_Email = PublicFunction.ConvertNull(l_Row["STD_Email"], "").ToString();
                            l_ProfileData.STD_Phone = PublicFunction.ConvertNull(l_Row["STD_Phone"], "").ToString();
                            l_ProfileData.WarehouseID = PublicFunction.ConvertNull(l_Row["WarehouseID"], "").ToString();
                            l_ProfileData.STD_Image_Base64 = PublicFunction.ConvertNull(l_Row["STD_Image_Base64"], "").ToString();
                            l_ProfileData.STD_Image_Name = PublicFunction.ConvertNull(l_Row["STD_Image_Name"], "").ToString();
                            l_ProfileData.ADDUser = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["ADDUser"], ""));
                            l_ProfileData.Class_Name = PublicFunction.ConvertNull(l_Row["Class_Name"], "").ToString();
                            l_ProfileData.Section_Name = PublicFunction.ConvertNull(l_Row["Section_Name"], "").ToString();
                            l_ProfileData.STD_Category_Name = PublicFunction.ConvertNull(l_Row["STD_Category_Name"], "").ToString();
                            l_ProfileData.Reliogion = PublicFunction.ConvertNull(l_Row["Reliogion"], "").ToString();
                            l_ProfileData.BloodGroup = PublicFunction.ConvertNull(l_Row["BloodGroup"], "").ToString();
                            //l_ProfileData.AsOnDate = PublicFunction.ConvertNull(l_Row["AsOnDate"], "").ToString();
                            l_ProfileData.AdmissionNo = PublicFunction.ConvertNull(l_Row["AdmissionNo"], "").ToString();
                            l_ProfileData.AdmissionDate = PublicFunction.ConvertNull(l_Row["AdmissionDate"], "").ToString();

                            l_GetProfileResponse.Profile.Add(l_ProfileData);
                        }

                        l_Data = l_Dataset.Tables[2];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            ParentData l_ParentData = new ParentData();
                            l_ParentData.STD_Member_Name = PublicFunction.ConvertNull(l_Row["STD_Member_Name"], "").ToString();
                            //l_ParentData.STD_Member_CNIC = PublicFunction.ConvertNull(l_Row["STD_Member_CNIC"], "").ToString();
                            l_ParentData.STD_Member_Email = PublicFunction.ConvertNull(l_Row["STD_Member_Email"], "").ToString();
                            l_ParentData.STD_Member_Relation = PublicFunction.ConvertNull(l_Row["STD_Member_Relation"], "").ToString();
                            l_ParentData.STD_Member_Phone = PublicFunction.ConvertNull(l_Row["STD_Member_Phone"], "").ToString();
                            l_ParentData.STD_Member_Profession = PublicFunction.ConvertNull(l_Row["STD_Member_Profession"], "").ToString();
                            l_ParentData.STD_Member_Image_Base64 = PublicFunction.ConvertNull(l_Row["STD_Member_Image_Base64"], "").ToString();
                            l_ParentData.STD_Member_IsGuardian = Convert.ToBoolean(PublicFunction.ConvertNull(l_Row["STD_Member_IsGuardian"],""));

                            l_GetProfileResponse.ParentsData.Add(l_ParentData);
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetProfileResponse;
        }

        #endregion

        #region Exams

        public GetExamScheduleDataResponse GetExamScheduleData(GetExamScheduleDataInput p_GetExamScheduleDataInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetExamScheduleDataResponse l_GetExamScheduleDataResponse = new GetExamScheduleDataResponse();
            l_GetExamScheduleDataResponse.GetExamScheduleData = new List<GetExamScheduleData>();
            //l_GetExamScheduleDataResponse.ParentsData = new List<ParentData>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "Exec SSS_MA_GetExamSchedule ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetExamScheduleDataInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                this.Connection.GetDataSP(l_Query, ref l_Dataset);

                l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetExamScheduleData l_GetExamScheduleData = new GetExamScheduleData();

                            l_GetExamScheduleData.EXM_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["EXM_ID"], ""));
                            l_GetExamScheduleData.EXM_Name = PublicFunction.ConvertNull(l_Row["EXM_Name"], "").ToString();
                            l_GetExamScheduleData.EXMSC_Date = PublicFunction.ConvertNull(l_Row["EXMSC_Date"], "").ToString();


                            l_GetExamScheduleDataResponse.GetExamScheduleData.Add(l_GetExamScheduleData);
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetExamScheduleDataResponse;
        }

        public GetExamScheduleDetailResponse GetExamScheduleDetail(GetExamScheduleDetailInput p_GetExamScheduleDetailInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetExamScheduleDetailResponse l_GetExamScheduleDetailResponse = new GetExamScheduleDetailResponse();
            l_GetExamScheduleDetailResponse.GetExamScheduleDetail = new List<GetExamScheduleDetail>();
            //l_GetExamScheduleDetailResponse.ParentsData = new List<ParentData>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "Exec SSS_MA_GetExamScheduleDetail ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetExamScheduleDetailInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_GetExamScheduleDetailInput.EXM_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_EXM_ID = " + l_Param;

                this.Connection.GetDataSP(l_Query, ref l_Dataset);

                l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetExamScheduleDetail l_GetExamScheduleDetail = new GetExamScheduleDetail();

                            l_GetExamScheduleDetail.EXM_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["EXM_ID"], ""));
                            l_GetExamScheduleDetail.EXM_Name = PublicFunction.ConvertNull(l_Row["EXM_Name"], "").ToString();
                            l_GetExamScheduleDetail.EXMSC_Date = PublicFunction.ConvertNull(l_Row["EXMSC_Date"], "").ToString();
                            l_GetExamScheduleDetail.SB_Name = PublicFunction.ConvertNull(l_Row["SB_Name"], "").ToString();
                            l_GetExamScheduleDetail.ClassRoom = PublicFunction.ConvertNull(l_Row["ClassRoom"], "").ToString();
                            l_GetExamScheduleDetail.EXMSC_Start_Time = PublicFunction.ConvertNull(l_Row["EXMSC_Start_Time"], "").ToString();
                            l_GetExamScheduleDetail.EXMSC_End_Time = PublicFunction.ConvertNull(l_Row["EXMSC_End_Time"], "").ToString();


                            l_GetExamScheduleDetailResponse.GetExamScheduleDetail.Add(l_GetExamScheduleDetail);
                        }

                        //l_Data = l_Dataset.Tables[2];

                        //foreach (DataRow l_Row in l_Data.Rows)
                        //{
                        //    ParentData l_ParentData = new ParentData();
                        //    l_ParentData.STD_Member_Name = PublicFunction.ConvertNull(l_Row["STD_Member_Name"], "").ToString();
                        //    //l_ParentData.STD_Member_CNIC = PublicFunction.ConvertNull(l_Row["STD_Member_CNIC"], "").ToString();
                        //    l_ParentData.STD_Member_Email = PublicFunction.ConvertNull(l_Row["STD_Member_Email"], "").ToString();
                        //    l_ParentData.STD_Member_Relation = PublicFunction.ConvertNull(l_Row["STD_Member_Relation"], "").ToString();
                        //    l_ParentData.STD_Member_Phone = PublicFunction.ConvertNull(l_Row["STD_Member_Phone"], "").ToString();
                        //    l_ParentData.STD_Member_Profession = PublicFunction.ConvertNull(l_Row["STD_Member_Profession"], "").ToString();
                        //    l_ParentData.STD_Member_Image_Base64 = PublicFunction.ConvertNull(l_Row["STD_Member_Image_Base64"], "").ToString();
                        //    l_ParentData.STD_Member_IsGuardian = Convert.ToBoolean(PublicFunction.ConvertNull(l_Row["STD_Member_IsGuardian"], ""));

                        //    l_GetExamScheduleDetailResponse.ParentsData.Add(l_ParentData);
                        //}
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetExamScheduleDetailResponse;
        }

        public GetExamResultResponse GetExamResult(GetExamResultInput p_GetExamResultInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetExamResultResponse l_GetExamResultResponse = new GetExamResultResponse();
            l_GetExamResultResponse.GetExamResult = new List<GetExamResult>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            try
            {
                l_Query = "Exec SSS_MA_GetExamResult ";
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;
                PublicFunction.FieldToParam(p_GetExamResultInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;
                this.Connection.GetDataSP(l_Query, ref l_Dataset);
                l_Data = l_Dataset.Tables[0];
                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];
                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetExamResult l_GetExamResult = new GetExamResult();
                            l_GetExamResult.SR_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SR_ID"], ""));
                            l_GetExamResult.EXM_Name = PublicFunction.ConvertNull(l_Row["Term_Name"], "").ToString();
                            l_GetExamResult.EXM_Status = PublicFunction.ConvertNull(l_Row["ExamResultStatus"], "").ToString();
                            l_GetExamResult.Percentage = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Marks_Percentage"], ""));
                            l_GetExamResult.EXMR_Obtained_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Marks"], ""));
                            l_GetExamResult.EXMR_Total_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_Marks"], ""));
                            l_GetExamResult.GrandTotal = String.Concat(l_GetExamResult.EXMR_Obtained_Marks, '/', l_GetExamResult.EXMR_Total_Marks);
                            l_GetExamResult.ExamGrade = PublicFunction.ConvertNull(l_Row["Grade"], "").ToString();
                            l_GetExamResult.GradePostion = PublicFunction.ConvertNull(l_Row["Position"], "").ToString();
                            l_GetExamResult.Session_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Session_ID"], ""));
                            l_GetExamResult.Term_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Term_ID"], ""));
                            l_GetExamResultResponse.GetExamResult.Add(l_GetExamResult);
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetExamResultResponse;
        }
        public GetExamResultDetailResponse GetExamResultDetail(GetExamResultDetailInput p_GetExamResultDetailInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetExamResultDetailResponse l_GetExamResultDetailResponse = new GetExamResultDetailResponse();
            l_GetExamResultDetailResponse.ExamResultDetail = new List<GetExamResultDetail>();
            //l_GetExamResultDetailResponse.ParentsData = new List<ParentData>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "SSS_MA_GetExamResultDetail ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetExamResultDetailInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_GetExamResultDetailInput.SR_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_EXM_ID = " + l_Param;
                PublicFunction.FieldToParam(p_GetExamResultDetailInput.Term_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Term_ID = " + l_Param;
                PublicFunction.FieldToParam(p_GetExamResultDetailInput.Session_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Session_ID = " + l_Param;

                this.Connection.GetDataSP(l_Query, ref l_Dataset);

                l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetExamResultDetail l_GetExamResultDetail = new GetExamResultDetail();

                            l_GetExamResultDetail.SR_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SR_ID"], ""));
                            l_GetExamResultDetail.SB_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SB_ID"], ""));
                            l_GetExamResultDetail.Term_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Term_ID"], ""));
                            l_GetExamResultDetail.Term_Name = PublicFunction.ConvertNull(l_Row["Term_Name"], "").ToString();
                            l_GetExamResultDetail.SB_Name = PublicFunction.ConvertNull(l_Row["SB_Name"], "").ToString();
                            //l_GetExamResultDetail.EXMSC_Passing_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["EXMSC_Passing_Marks"], ""));
                            l_GetExamResultDetail.SubjectExamResult = PublicFunction.ConvertNull(l_Row["SubjectResultStatus"], "").ToString();
                            l_GetExamResultDetail.EXMR_Obtained_Marks = String.Concat( Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Total_Marks"], "")),'/', Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_Marks"], "")));
                            l_GetExamResultDetail.GrandTotal = String.Concat(Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Exam_Marks"], "")), '/', Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Exam_Total"], "")));
                            //l_GetExamResultDetail.TotalMarks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["TotalMarks"], ""));
                            l_GetExamResultDetail.MarksPercentage = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Marks_Percentage"], ""));
                            l_GetExamResultDetail.ExamGrade = PublicFunction.ConvertNull(l_Row["Grade"], "").ToString();
                            l_GetExamResultDetail.ExamResult = PublicFunction.ConvertNull(l_Row["ExamStatus"], "").ToString();
                            l_GetExamResultDetail.Session_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Session_ID"], ""));
                            //l_GetExamResultDetail.Term_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Term_ID"], ""));


                            l_GetExamResultDetailResponse.ExamResultDetail.Add(l_GetExamResultDetail);
                        }

                        //l_Data = l_Dataset.Tables[2];

                        //foreach (DataRow l_Row in l_Data.Rows)
                        //{
                        //    ParentData l_ParentData = new ParentData();
                        //    l_ParentData.STD_Member_Name = PublicFunction.ConvertNull(l_Row["STD_Member_Name"], "").ToString();
                        //    //l_ParentData.STD_Member_CNIC = PublicFunction.ConvertNull(l_Row["STD_Member_CNIC"], "").ToString();
                        //    l_ParentData.STD_Member_Email = PublicFunction.ConvertNull(l_Row["STD_Member_Email"], "").ToString();
                        //    l_ParentData.STD_Member_Relation = PublicFunction.ConvertNull(l_Row["STD_Member_Relation"], "").ToString();
                        //    l_ParentData.STD_Member_Phone = PublicFunction.ConvertNull(l_Row["STD_Member_Phone"], "").ToString();
                        //    l_ParentData.STD_Member_Profession = PublicFunction.ConvertNull(l_Row["STD_Member_Profession"], "").ToString();
                        //    l_ParentData.STD_Member_Image_Base64 = PublicFunction.ConvertNull(l_Row["STD_Member_Image_Base64"], "").ToString();
                        //    l_ParentData.STD_Member_IsGuardian = Convert.ToBoolean(PublicFunction.ConvertNull(l_Row["STD_Member_IsGuardian"], ""));

                        //    l_GetExamResultDetailResponse.ParentsData.Add(l_ParentData);
                        //}
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetExamResultDetailResponse;
        }

        public SubjectResultDetailResponse GetSubResultDetail(SubjectResultDetailInput p_SubjectResultDetailInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            SubjectResultDetailResponse l_SubjectResultDetailResponse = new SubjectResultDetailResponse();
            l_SubjectResultDetailResponse.SubResultDetail = new List<GetSubResultDetail>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            try
            {
                l_Query = "SSS_MA_GetSubjectResultDetail ";
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;
                PublicFunction.FieldToParam(p_SubjectResultDetailInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;
                PublicFunction.FieldToParam(p_SubjectResultDetailInput.SR_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_EXM_ID = " + l_Param;
                PublicFunction.FieldToParam(p_SubjectResultDetailInput.SB_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_SB_ID = " + l_Param;
                PublicFunction.FieldToParam(p_SubjectResultDetailInput.Term_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Term_ID = " + l_Param;
                PublicFunction.FieldToParam(p_SubjectResultDetailInput.Session_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Session_ID = " + l_Param;
                this.Connection.GetDataSP(l_Query, ref l_Dataset);
                l_Data = l_Dataset.Tables[0];
                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];
                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetSubResultDetail l_GetExamResultDetail = new GetSubResultDetail();
                            l_GetExamResultDetail.SR_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SR_ID"], ""));
                            l_GetExamResultDetail.SB_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SB_ID"], ""));
                            l_GetExamResultDetail.Section_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Section_ID"], ""));
                            l_GetExamResultDetail.Class_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Class_ID"], ""));
                            l_GetExamResultDetail.Session_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Session_ID"], ""));
                            l_GetExamResultDetail.Term_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Term_ID"], ""));
                            l_GetExamResultDetail.SB_Name = PublicFunction.ConvertNull(l_Row["SB_Name"], "").ToString();
                            l_GetExamResultDetail.Obtained_Schedule_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Schedule_Marks"], ""));
                            l_GetExamResultDetail.Total_Schedule_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_Schedule_Marks"], ""));
                            l_GetExamResultDetail.Obtained_Assessment_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Assessment_Marks"], ""));
                            l_GetExamResultDetail.Total_Assessment_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_Assessment_Marks"], ""));
                            l_GetExamResultDetail.Obtained_Monthly_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Monthly_Marks"], ""));
                            l_GetExamResultDetail.Total_Monthly_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_Monthly_Marks"], ""));
                            l_GetExamResultDetail.Obtained_Class_Work_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Class_Work_Marks"], ""));
                            l_GetExamResultDetail.Total_Class_Work_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_Class_Work_Marks"], ""));
                            l_GetExamResultDetail.Obtained_Home_Work_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Home_Work_Marks"], ""));
                            l_GetExamResultDetail.Total_Home_Work_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_Home_Work_Marks"], ""));
                            l_GetExamResultDetail.Obtained_MMP_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_MMP_Marks"], ""));
                            l_GetExamResultDetail.Total_MMP_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Total_MMP_Marks"], ""));
                            l_GetExamResultDetail.Obtained_Course_Work_Total = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Obtained_Course_Work_Total"], ""));
                            l_GetExamResultDetail.Course_Work_Total = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Course_Work_Total"], ""));
                            l_GetExamResultDetail.STD_Roll_No = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["STD_Roll_No"], ""));
                            l_SubjectResultDetailResponse.SubResultDetail.Add(l_GetExamResultDetail);
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_SubjectResultDetailResponse;
        }
        public ScheduleMarksDetailResponse GetScheduleMarksDetail(ScheduleMarksDetailInput p_ScheduleMarksDetailInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            ScheduleMarksDetailResponse l_ScheduleMarksDetailResponse = new ScheduleMarksDetailResponse();
            l_ScheduleMarksDetailResponse.ScheduleMarksDetail = new List<ScheduleMarks>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            try
            {
                l_Query = "SSS_MA_ScheduleMarksDetail ";
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.SR_ID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_EXM_ID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.SB_ID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_SB_ID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.Term_ID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_Term_ID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.Session_ID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_Session_ID = " + l_Param;
                this.Connection.GetDataSP(l_Query, ref l_Dataset);
                l_Data = l_Dataset.Tables[0];
                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];
                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            ScheduleMarks l_ScheduleMarks = new ScheduleMarks();
                            l_ScheduleMarks.ResultDate = PublicFunction.ConvertNull(l_Row["ResultDate"], "").ToString();
                            l_ScheduleMarks.EXMR_Obtained_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["EXMR_Obtained_Marks"], ""));
                            l_ScheduleMarks.EXMR_Total_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["EXMR_Total_Marks"], ""));
                            l_ScheduleMarks.Status = PublicFunction.ConvertNull(l_Row["Status"], "").ToString();
                            l_ScheduleMarks.EXMR_Remarks = PublicFunction.ConvertNull(l_Row["EXMR_Remarks"], "").ToString();
                            l_ScheduleMarksDetailResponse.ScheduleMarksDetail.Add(l_ScheduleMarks);
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_ScheduleMarksDetailResponse;
        }
        public ScheduleMarksDetailResponse GetAssesmentMarksDetail(ScheduleMarksDetailInput p_ScheduleMarksDetailInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            ScheduleMarksDetailResponse l_AssesmentMarksDetailResponse = new ScheduleMarksDetailResponse();
            l_AssesmentMarksDetailResponse.ScheduleMarksDetail = new List<ScheduleMarks>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            try
            {
                l_Query = "SSS_MA_AssesmentMarksDetail ";
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.SR_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_EXM_ID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.SB_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_SB_ID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.Term_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Term_ID = " + l_Param;
                PublicFunction.FieldToParam(p_ScheduleMarksDetailInput.Session_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Session_ID = " + l_Param;
                this.Connection.GetDataSP(l_Query, ref l_Dataset);
                l_Data = l_Dataset.Tables[0];
                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];
                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            ScheduleMarks l_ScheduleMarks = new ScheduleMarks();
                            l_ScheduleMarks.ResultDate = PublicFunction.ConvertNull(l_Row["ResultDate"], "").ToString();
                            l_ScheduleMarks.EXMR_Obtained_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["EXMR_Obtained_Marks"], ""));
                            l_ScheduleMarks.EXMR_Total_Marks = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["EXMR_Total_Marks"], ""));
                            l_ScheduleMarks.Status = PublicFunction.ConvertNull(l_Row["Status"], "").ToString();
                            l_ScheduleMarks.EXMR_Remarks = PublicFunction.ConvertNull(l_Row["EXMR_Remarks"], "").ToString();
                            l_AssesmentMarksDetailResponse.ScheduleMarksDetail.Add(l_ScheduleMarks);
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_AssesmentMarksDetailResponse;
        }
        public ResultRemarksResponse RemarksDetail(ResultRemarksInput p_ResultRemarksInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            ResultRemarksResponse l_ResultRemarksResponse = new ResultRemarksResponse();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            try
            {
                l_Query = "SSS_MA_ResultRemarks ";
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;
                PublicFunction.FieldToParam(p_ResultRemarksInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;
                PublicFunction.FieldToParam(p_ResultRemarksInput.Term_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Term_ID = " + l_Param;
                PublicFunction.FieldToParam(p_ResultRemarksInput.Session_ID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Session_ID = " + l_Param;
                this.Connection.GetDataSP(l_Query, ref l_Dataset);
                l_Data = l_Dataset.Tables[0];
                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_Data = l_Dataset.Tables[1];
                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            l_ResultRemarksResponse.OverallRemark = PublicFunction.ConvertNull(l_Row["OverallRemark"], "").ToString();
                            l_ResultRemarksResponse.RR_Art_Name = PublicFunction.ConvertNull(l_Row["RR_Art_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Home_Work_Name = PublicFunction.ConvertNull(l_Row["RR_Home_Work_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Effort_Name = PublicFunction.ConvertNull(l_Row["RR_Effort_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Attandance_Name = PublicFunction.ConvertNull(l_Row["RR_Attandance_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Class_Work_Name = PublicFunction.ConvertNull(l_Row["RR_Class_Work_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Conduct_Name = PublicFunction.ConvertNull(l_Row["RR_Conduct_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Games_Name = PublicFunction.ConvertNull(l_Row["RR_Games_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Project_Work_Name = PublicFunction.ConvertNull(l_Row["RR_Project_Work_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Punctually_Name = PublicFunction.ConvertNull(l_Row["RR_Punctually_Name"], "").ToString();
                            l_ResultRemarksResponse.RR_Work_Presentation_Name = PublicFunction.ConvertNull(l_Row["RR_Work_Presentation_Name"], "").ToString();
                            l_ResultRemarksResponse.STD_Percentage = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["STD_Percentage"], ""));
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_ResultRemarksResponse;
        }
        #endregion

        #region HomeWork

        public GetHomeWorkDataResponse GetHomeWorkData(GetHomeWorkBadgeDataInput p_GetHomeWorkDataInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetHomeWorkDataResponse l_GetHomeWorkDataResponse = new GetHomeWorkDataResponse();
            l_GetHomeWorkDataResponse.GetHomeWorkData = new List<GetHomeWorkData>();
            //l_GetHomeWorkDataResponse.ParentsData = new List<ParentData>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_GetHomeWorkData ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetHomeWorkDataInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_GetHomeWorkDataInput.SB_ID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_SB_ID = " + l_Param;

                PublicFunction.FieldToParam(p_GetHomeWorkDataInput.Status_ID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_Status_ID = " + l_Param;

                
                this.Connection.GetData(l_Query, ref l_Data);

                //l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        //l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetHomeWorkData l_GetHomeWorkData = new GetHomeWorkData();

                            l_GetHomeWorkData.AHW_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["AHW_ID"], ""));
                            l_GetHomeWorkData.Class_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Class_ID"], ""));
                            l_GetHomeWorkData.Section_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Section_ID"], ""));
                            l_GetHomeWorkData.SB_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SB_ID"], 0).ToString());
                            l_GetHomeWorkData.SB_Code = PublicFunction.ConvertNull(l_Row["SB_Code"], "").ToString();
                            l_GetHomeWorkData.EMP_Name = PublicFunction.ConvertNull(l_Row["EMP_Name"], "").ToString();
                            l_GetHomeWorkData.Section_Name = PublicFunction.ConvertNull(l_Row["Section_Name"], "").ToString();
                            l_GetHomeWorkData.SB_Name = PublicFunction.ConvertNull(l_Row["SB_Name"], "").ToString();
                            //l_GetHomeWorkData.STD_Maling_Address = PublicFunction.ConvertNull(l_Row["STD_Maling_Address"], "").ToString();
                            //l_GetHomeWorkData.STD_Permanent_Address = PublicFunction.ConvertNull(l_Row["STD_Permanent_Address"], "").ToString();
                            //l_GetHomeWorkData.STD_Email = PublicFunction.ConvertNull(l_Row["STD_Email"], "").ToString();
                            //l_GetHomeWorkData.STD_Phone = PublicFunction.ConvertNull(l_Row["STD_Phone"], "").ToString();
                            l_GetHomeWorkData.WarehouseID = PublicFunction.ConvertNull(l_Row["WarehouseID"], "").ToString();
                            //l_GetHomeWorkData.STD_Image_Base64 = PublicFunction.ConvertNull(l_Row["STD_Image_Base64"], "").ToString();
                            //l_GetHomeWorkData.STD_Image_Name = PublicFunction.ConvertNull(l_Row["STD_Image_Name"], "").ToString();
                            l_GetHomeWorkData.Status = PublicFunction.ConvertNull(l_Row["Status"], "").ToString();
                            l_GetHomeWorkData.Status_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Status_ID"], 0).ToString());
                            l_GetHomeWorkData.Class_Name = PublicFunction.ConvertNull(l_Row["Class_Name"], "").ToString();
                            l_GetHomeWorkData.Assign_Date = PublicFunction.ConvertNull(l_Row["Assign_Date"], "").ToString();
                            l_GetHomeWorkData.Submission_By = PublicFunction.ConvertNull(l_Row["Submission_By"], "").ToString();
                            l_GetHomeWorkData.Evaluation_Date = PublicFunction.ConvertNull(l_Row["Evaluation_Date"], "").ToString();
                            l_GetHomeWorkData.Submission_Date = PublicFunction.ConvertNull(l_Row["Submission_Date"], "").ToString();
                            l_GetHomeWorkData.Assigned_HomeWork_Path = PublicFunction.ConvertNull(l_Row["Assigned_HomeWork_Path"], "").ToString();
                            l_GetHomeWorkData.Submit_HomeWork_Path = PublicFunction.ConvertNull(l_Row["Submit_HomeWork_Path"], "").ToString();

                            l_GetHomeWorkDataResponse.GetHomeWorkData.Add(l_GetHomeWorkData);
                        }

                        //l_Data = l_Dataset.Tables[2];

                        //foreach (DataRow l_Row in l_Data.Rows)
                        //{
                        //    ParentData l_ParentData = new ParentData();
                        //    l_ParentData.STD_Member_Name = PublicFunction.ConvertNull(l_Row["STD_Member_Name"], "").ToString();
                        //    //l_ParentData.STD_Member_CNIC = PublicFunction.ConvertNull(l_Row["STD_Member_CNIC"], "").ToString();
                        //    l_ParentData.STD_Member_Email = PublicFunction.ConvertNull(l_Row["STD_Member_Email"], "").ToString();
                        //    l_ParentData.STD_Member_Relation = PublicFunction.ConvertNull(l_Row["STD_Member_Relation"], "").ToString();
                        //    l_ParentData.STD_Member_Phone = PublicFunction.ConvertNull(l_Row["STD_Member_Phone"], "").ToString();
                        //    l_ParentData.STD_Member_Profession = PublicFunction.ConvertNull(l_Row["STD_Member_Profession"], "").ToString();
                        //    l_ParentData.STD_Member_Image_Base64 = PublicFunction.ConvertNull(l_Row["STD_Member_Image_Base64"], "").ToString();
                        //    l_ParentData.STD_Member_IsGuardian = Convert.ToBoolean(PublicFunction.ConvertNull(l_Row["STD_Member_IsGuardian"], ""));

                        //    l_GetHomeWorkDataResponse.ParentsData.Add(l_ParentData);
                        //}
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetHomeWorkDataResponse;
        }

        public GetHomeWorkBadgeDataResponse GetHomeWorkBadgeData(GetHomeWorkDataInput p_GetHomeWorkDataInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetHomeWorkBadgeDataResponse l_GetHomeWorkDataResponse = new GetHomeWorkBadgeDataResponse();
            l_GetHomeWorkDataResponse.GetHomeWorkData = new List<GetHomeWorkBadgeData>();
            //l_GetHomeWorkDataResponse.ParentsData = new List<ParentData>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_GetHomeWorkBadgeData ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetHomeWorkDataInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);

                //l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        //l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetHomeWorkBadgeData l_GetHomeWorkData = new GetHomeWorkBadgeData();

                            l_GetHomeWorkData.RowID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["RowID"], ""));
                            l_GetHomeWorkData.SB_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SB_ID"], ""));
                            l_GetHomeWorkData.SB_Name = PublicFunction.ConvertNull(l_Row["SB_Name"], "").ToString();
                            l_GetHomeWorkData.SB_Code = PublicFunction.ConvertNull(l_Row["SB_Code"], "").ToString();
                            l_GetHomeWorkData.TotalCount = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["TotalCount"], ""));
                            l_GetHomeWorkData.PendingCount = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["PendingCount"], ""));
                            l_GetHomeWorkData.SubmittedCount = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SubmittedCount"], ""));
                            l_GetHomeWorkData.BackgroundColor = Convert.ToString(PublicFunction.ConvertNull(l_Row["BackgroundColor"], ""));
                            l_GetHomeWorkData.TextColor = Convert.ToString(PublicFunction.ConvertNull(l_Row["TextColor"], ""));
                            l_GetHomeWorkData.WarehouseID = Convert.ToString(PublicFunction.ConvertNull(l_Row["WarehouseID"], ""));

                            l_GetHomeWorkDataResponse.GetHomeWorkData.Add(l_GetHomeWorkData);
                        }

                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetHomeWorkDataResponse;
        }

        public GetHomeWorkBadgeStatusDataResponse GetHomeWorkBadgeStatusData(GetHomeWorkBadgeStatusDataInput p_GetHomeWorkDataInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetHomeWorkBadgeStatusDataResponse l_GetHomeWorkDataResponse = new GetHomeWorkBadgeStatusDataResponse();
            l_GetHomeWorkDataResponse.GetHomeWorkData = new List<GetHomeWorkBadgeStatusData>();
            //l_GetHomeWorkDataResponse.ParentsData = new List<ParentData>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_GetHomeWorkBadgeStatusData ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetHomeWorkDataInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_GetHomeWorkDataInput.SB_ID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_SB_ID = " + l_Param;

                
                this.Connection.GetData(l_Query, ref l_Data);

                //l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        //l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetHomeWorkBadgeStatusData l_GetHomeWorkData = new GetHomeWorkBadgeStatusData();

                            l_GetHomeWorkData.RowID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["RowID"], ""));
                            l_GetHomeWorkData.SB_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["SB_ID"], ""));
                            l_GetHomeWorkData.SB_Name = PublicFunction.ConvertNull(l_Row["SB_Name"], "").ToString();
                            l_GetHomeWorkData.SB_Code = PublicFunction.ConvertNull(l_Row["SB_Code"], "").ToString();
                            l_GetHomeWorkData.TotalCount = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["TotalCount"], ""));
                            l_GetHomeWorkData.Status_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Status_ID"], ""));
                            l_GetHomeWorkData.Status_Description = Convert.ToString(PublicFunction.ConvertNull(l_Row["Status_Description"], ""));
                            l_GetHomeWorkData.BackgroundColor = Convert.ToString(PublicFunction.ConvertNull(l_Row["BackgroundColor"], ""));
                            l_GetHomeWorkData.TextColor = Convert.ToString(PublicFunction.ConvertNull(l_Row["TextColor"], ""));
                            l_GetHomeWorkData.WarehouseID = Convert.ToString(PublicFunction.ConvertNull(l_Row["WarehouseID"], ""));

                            l_GetHomeWorkDataResponse.GetHomeWorkData.Add(l_GetHomeWorkData);
                        }

                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetHomeWorkDataResponse;
        }

        public DownloadHomeWorkResponse DownloadHomeWork(int p_DownloadHomeWorkInput, int p_UserNo, string warehouseID, ref MessageResponse p_MessageResponse)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            DownloadHomeWorkResponse l_DownloadHomeWorkResponse = new DownloadHomeWorkResponse();
            //List<CheckItemID> l_BatchesList = new List<CheckItemID>();

            try
            {
                l_Query = "EXEC SSS_MA_DownloadHomeWork ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(warehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_DownloadHomeWorkInput, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_AHW_ID = " + l_Param;


                this.Connection.GetData(l_Query, ref l_Data);

                if (l_Data.Rows.Count > 0)
                {
                    //SetSuccessResponse(GlobalDeclarations.SuccessCodes.OperationCompleted, ref p_MessageResponse);
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();

                    if(p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_DownloadHomeWorkResponse.AHW_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["AHW_ID"], ""));
                        l_DownloadHomeWorkResponse.File_Name = PublicFunction.ConvertNull(l_Data.Rows[0]["File_Name"], "").ToString();
                        l_DownloadHomeWorkResponse.File_Path = PublicFunction.ConvertNull(l_Data.Rows[0]["File_Path"], "").ToString();
                        l_DownloadHomeWorkResponse.WarehouseID = PublicFunction.ConvertNull(l_Data.Rows[0]["WarehouseID"], "").ToString();
                    }
                   

                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_Data.Dispose();
            }

            return l_DownloadHomeWorkResponse;
        }

        public DownloadResponse DownloadNotice(int p_NoticeID, int p_UserNo, string warehouseID, ref MessageResponse p_MessageResponse)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            DownloadResponse l_DownloadNoticeResponse = new DownloadResponse();
            //List<CheckItemID> l_BatchesList = new List<CheckItemID>();

            try
            {
                l_Query = "EXEC SSS_MA_DownloadNotice ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(warehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_NoticeID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Notice_ID = " + l_Param;


                this.Connection.GetData(l_Query, ref l_Data);

                if (l_Data.Rows.Count > 0)
                {
                    //SetSuccessResponse(GlobalDeclarations.SuccessCodes.OperationCompleted, ref p_MessageResponse);
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();

                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        l_DownloadNoticeResponse.Key_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Notice_ID"], ""));
                        l_DownloadNoticeResponse.File_Name = PublicFunction.ConvertNull(l_Data.Rows[0]["File_Name"], "").ToString();
                        l_DownloadNoticeResponse.File_Path = PublicFunction.ConvertNull(l_Data.Rows[0]["File_Path"], "").ToString();
                        l_DownloadNoticeResponse.WarehouseID = PublicFunction.ConvertNull(l_Data.Rows[0]["WarehouseID"], "").ToString();
                    }


                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_Data.Dispose();
            }

            return l_DownloadNoticeResponse;
        }


        public bool SubmitHomeWork(SubmitHomeWorkModel model, ref MessageResponse p_MessageResponse)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            bool result = false;

            try
            {
                l_Query = "EXEC SSS_MA_SubmitHomeWork ";

                PublicFunction.FieldToParam(model.UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(model.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(model.AHWID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", @p_AHW_ID = " + l_Param;

                PublicFunction.FieldToParam(model.FileName, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_FileName = " + l_Param;

                PublicFunction.FieldToParam(model.FilePath, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_FilePath = " + l_Param;

                PublicFunction.FieldToParam(model.Description, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_Description = " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);

                if (l_Data.Rows.Count > 0)
                {
                    //SetSuccessResponse(GlobalDeclarations.SuccessCodes.OperationCompleted, ref p_MessageResponse);
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    result = true;
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_Data.Dispose();
            }

            return result;
        }


        #endregion

        #region Subjects

        public GetSubjectsResponse GetSubjectsList(GetSubjectsInput p_GetSubjectsInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetSubjectsResponse l_GetSubjectsResponse = new GetSubjectsResponse();
            l_GetSubjectsResponse.GetSubjects = new List<GetSubjects>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_Subjects ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetSubjectsInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_GetSubjectsInput.Section_Name, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_SectionName = " + l_Param;

                PublicFunction.FieldToParam(p_GetSubjectsInput.Class_Name, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_ClassName = " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);

                //l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        //l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetSubjects l_GetSubjects = new GetSubjects();

                            l_GetSubjects.Class_Name = PublicFunction.ConvertNull(l_Row["Class_Name"], "").ToString();
                            l_GetSubjects.Section_Name = PublicFunction.ConvertNull(l_Row["Section_Name"], "").ToString();
                            l_GetSubjects.SB_Name = PublicFunction.ConvertNull(l_Row["SB_Name"], "").ToString();
                            l_GetSubjects.EMP_Name = PublicFunction.ConvertNull(l_Row["EMP_Name"], "").ToString();
                            l_GetSubjects.SB_Description = PublicFunction.ConvertNull(l_Row["SB_Description"], "").ToString();
                            l_GetSubjects.SB_Code = PublicFunction.ConvertNull(l_Row["SB_Code"], "").ToString();
                            l_GetSubjects.SB_Type_Name = PublicFunction.ConvertNull(l_Row["SB_Type_Name"], "").ToString();
                            l_GetSubjects.WarehouseID = PublicFunction.ConvertNull(l_Row["WarehouseID"], "").ToString();


                            l_GetSubjectsResponse.GetSubjects.Add(l_GetSubjects);
                        }


                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetSubjectsResponse;
        }

        #endregion

        #region Teachers

        public GetTeachersResponse GetStudentTeachersList(GetTeachersInput p_GetTeachersInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetTeachersResponse l_GetTeachersResponse = new GetTeachersResponse();
            l_GetTeachersResponse.GetTeachersData = new List<GetTeachers>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_Teachers ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetTeachersInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_GetTeachersInput.Section_Name, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_SectionName = " + l_Param;

                PublicFunction.FieldToParam(p_GetTeachersInput.Class_Name, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_ClassName = " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);

                //l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        //l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetTeachers l_GetTeachers = new GetTeachers();

                            l_GetTeachers.Class_Name = PublicFunction.ConvertNull(l_Row["Class_Name"], "").ToString();
                            l_GetTeachers.Section_Name = PublicFunction.ConvertNull(l_Row["Section_Name"], "").ToString();
                            l_GetTeachers.EMP_Email = PublicFunction.ConvertNull(l_Row["EMP_Email"], "").ToString();
                            l_GetTeachers.EMP_Name = PublicFunction.ConvertNull(l_Row["EMP_Name"], "").ToString();
                            //l_GetTeachers.Section_Name = PublicFunction.ConvertNull(l_Row["Section_Name"], "").ToString();
                            l_GetTeachers.EMP_Image_Base64 = PublicFunction.ConvertNull(l_Row["EMP_Image_Base64"], "").ToString();
                            l_GetTeachers.EMP_Image_Name = PublicFunction.ConvertNull(l_Row["EMP_Image_Name"], "").ToString();
                            l_GetTeachers.EMP_Phone = PublicFunction.ConvertNull(l_Row["EMP_Phone"], "").ToString();
                            l_GetTeachers.WarehouseID = PublicFunction.ConvertNull(l_Row["WarehouseID"], "").ToString();


                            l_GetTeachersResponse.GetTeachersData.Add(l_GetTeachers);
                        }

                        
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetTeachersResponse;
        }

        #endregion

        #region TimeTable
        public CurrentWeekTimeTableResponse GetCurrentWeekTimeTable(CurrentWeekTimeTableInput p_CurrentWeekTimeTableInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            CurrentWeekTimeTableResponse l_CurrentWeekTimeTableResponse = new CurrentWeekTimeTableResponse();
            l_CurrentWeekTimeTableResponse.GetTimeTable = new List<GetTimeTable>();
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_DataDetail = new DataTable();
            DataTable l_Data = new DataTable();

            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_GetTimetable ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_CurrentWeekTimeTableInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;

                PublicFunction.FieldToParam(p_CurrentWeekTimeTableInput.Section_Name, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_SectionName = " + l_Param;

                PublicFunction.FieldToParam(p_CurrentWeekTimeTableInput.Class_Name, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_ClassName = " + l_Param;

                this.Connection.GetDataSP(l_Query, ref l_Dataset);

                //l_Data = l_Dataset.Tables[0];

                if (l_Dataset.Tables.Count > 0)
                {
                   
                    l_Data = l_Dataset.Tables[0];

                    if (l_Data.Rows.Count > 0)
                    {
                        p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                        p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                        p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                        
                        if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                        {
                            //l_Data = l_Dataset.Tables[1];

                            
                            if (l_Dataset.Tables.Count > 1)
                            {
                                l_DataDetail = l_Dataset.Tables[1];
                            }

                            foreach (DataRow l_Row in l_Data.Rows)
                            {
                                GetTimeTable l_GetTimeTable = new GetTimeTable();
                                l_GetTimeTable.CLSTT_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["CLSTT_ID"], 0).ToString());
                                l_GetTimeTable.Class_Name = PublicFunction.ConvertNull(l_Row["Class_Name"], "").ToString();
                                l_GetTimeTable.Section_Name = PublicFunction.ConvertNull(l_Row["Section_Name"], "").ToString();
                                l_GetTimeTable.WD_ID = PublicFunction.ConvertNull(l_Row["WD_ID"], "").ToString();
                                l_GetTimeTable.WD_Name = PublicFunction.ConvertNull(l_Row["WD_Name"], "").ToString();
                                l_GetTimeTable.Term_Name = PublicFunction.ConvertNull(l_Row["Term_Name"], "").ToString();
                                l_GetTimeTable.Session_Code = PublicFunction.ConvertNull(l_Row["Session_Code"], "").ToString();
                                l_GetTimeTable.Status_Description = PublicFunction.ConvertNull(l_Row["Status_Description"], "").ToString();
                                l_GetTimeTable.TimeTableDetail = new List<GetTimeTableDetail>();

                                DataRow[] result = l_DataDetail.Select("CLSTT_ID = " + l_GetTimeTable.CLSTT_ID + " AND WD_ID = " + l_GetTimeTable.WD_ID);

                                foreach (DataRow l_RowDetail in result)
                                {
                                    GetTimeTableDetail l_detail = new GetTimeTableDetail();
                                    l_detail.CLSTT_ID = Convert.ToInt32(PublicFunction.ConvertNull(l_RowDetail["CLSTT_ID"], 0).ToString());
                                    l_detail.EMP_Name = PublicFunction.ConvertNull(l_RowDetail["EMP_Name"], "").ToString();
                                    l_detail.SB_Name = PublicFunction.ConvertNull(l_RowDetail["SB_Name"], "").ToString();
                                    l_detail.CLSR_Name = PublicFunction.ConvertNull(l_RowDetail["CLSR_Name"], "").ToString();
                                    l_detail.CLSTT_Start_Time = PublicFunction.ConvertNull(l_RowDetail["CLSTT_Start_Time"], "").ToString();
                                    l_detail.CLSTT_End_Time = PublicFunction.ConvertNull(l_RowDetail["CLSTT_End_Time"], "").ToString();
                                    l_GetTimeTable.TimeTableDetail.Add(l_detail);
                                }

                                l_CurrentWeekTimeTableResponse.GetTimeTable.Add(l_GetTimeTable);
                                
                            }


                        }
                    }
                    else
                    {
                        SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
                l_DataDetail.Dispose();
                l_Dataset.Dispose();
            }
            return l_CurrentWeekTimeTableResponse;
        }

        #endregion

        #region Notice

        public GetNoticeDataResponse GetNoticeData(GetnoticeDataInput p_GetHomeWorkDataInput, int p_UserNo, ref MessageResponse p_MessageResponse)
        {
            GetNoticeDataResponse l_GetNoticeDataResponse = new GetNoticeDataResponse();
            l_GetNoticeDataResponse.GetNoticeData = new List<GetNoticeData>();
           
            string l_Query = String.Empty;
            DataSet l_Dataset = new DataSet();
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;

            try
            {
                l_Query = "EXEC SSS_MA_GetNoticeData ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += "@p_UserNo = " + l_Param;

                PublicFunction.FieldToParam(p_GetHomeWorkDataInput.WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", @p_WHSID = " + l_Param;


                this.Connection.GetData(l_Query, ref l_Data);

                //l_Data = l_Dataset.Tables[0];

                if (l_Data.Rows.Count > 0)
                {
                    p_MessageResponse.Status = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseStatus"], "").ToString();
                    p_MessageResponse.Code = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["Code"], 0));
                    p_MessageResponse.Description = PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseDescription"], "").ToString();
                    if (p_MessageResponse.Status.ToUpper() == "SUCCESS")
                    {
                        //l_Data = l_Dataset.Tables[1];

                        foreach (DataRow l_Row in l_Data.Rows)
                        {
                            GetNoticeData l_GetNoticeData = new GetNoticeData();

                            l_GetNoticeData.NoticeID = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["Notice_ID"], ""));
                            l_GetNoticeData.NoticeTitle = Convert.ToString(PublicFunction.ConvertNull(l_Row["Notice_Title"], ""));
                            l_GetNoticeData.NoticeDescription = Convert.ToString(PublicFunction.ConvertNull(l_Row["Notice_Description"], ""));
                            l_GetNoticeData.NoticeDate = Convert.ToString(PublicFunction.ConvertNull(l_Row["Notice_Date"], 0).ToString());
                            l_GetNoticeData.NoticeExpiryDate = Convert.ToString(PublicFunction.ConvertNull(l_Row["Notice_Expiry_Date"], "").ToString());
                            l_GetNoticeData.NoticeFileName = PublicFunction.ConvertNull(l_Row["Notice_File_Name"], "").ToString();
                            l_GetNoticeData.NoticeFilePath = PublicFunction.ConvertNull(l_Row["Notice_File_Path"], "").ToString();

                            l_GetNoticeDataResponse.GetNoticeData.Add(l_GetNoticeData);
                        }
                    }
                }
                else
                {
                    SetErrorResponse(GlobalDeclarations.ErrorCodes.DataNotFound, ref p_MessageResponse);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_GetNoticeDataResponse;
        }

        #endregion
    }
}