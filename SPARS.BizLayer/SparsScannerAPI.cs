using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
    public class SparsScannerAPI
    {
        public DBConnector Connection { get; set; }

        string m_ItemType = String.Empty;
        int m_BaleNo = 0;
        int m_CurrentPickupBatchNo;
        int m_CurrentPickingTicketRowIDX = 0;
        string m_PickUpDate = String.Empty;
        string m_LabelPrintedDate = String.Empty;
        string m_Floor = String.Empty;
        string m_Row = String.Empty;
        bool m_FloorDisable = false;
        bool m_RowDisable = false;


        public void UseConnection(string p_ConnectionString, DBConnector p_Connection = null)
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


        public List<String> GetPickBatcehs(int p_UserNo)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            List<string> l_List = new List<string>();

            try
            {
                l_Query = "EXEC sp_SMA_GetUserAssignedBatch ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param;


                this.Connection.GetData(l_Query, ref l_Data);

                foreach (DataRow l_DataRows in l_Data.Rows)
                {
                    l_List.Add(l_DataRows["BatchNo"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_List;
        }

        public List<String> GetWarehouseID(String p_UserID)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            List<string> l_List = new List<string>();

            try
            {
                l_Query = "EXEC sp_SMA_GetWarehouseID ";

                PublicFunction.FieldToParam(p_UserID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;


                this.Connection.GetData(l_Query, ref l_Data);

                foreach (DataRow l_DataRows in l_Data.Rows)
                {
                    l_List.Add(l_DataRows["WarehouseID"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_List;
        }
        public List<String> GetFloor(int p_PickUpBatchNo, int p_UserNo)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            List<string> l_List = new List<string>();

            try
            {
                l_Query = "EXEC sp_SMA_GetFloor ";

                PublicFunction.FieldToParam(p_PickUpBatchNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param;


                this.Connection.GetData(l_Query, ref l_Data);

                foreach (DataRow l_DataRows in l_Data.Rows)
                {
                    l_List.Add(l_DataRows["FloorNo"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_List;
        }
       
        public List<String> GetRow(int p_PickUpBatchNo, int p_UserNo, string p_Floor)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            List<string> l_List = new List<string>();

            try
            {
                l_Query = "EXEC sp_SMA_GetRow ";

                PublicFunction.FieldToParam(p_PickUpBatchNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_Floor, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;



                this.Connection.GetData(l_Query, ref l_Data);

                foreach (DataRow l_DataRows in l_Data.Rows)
                {
                    l_List.Add(l_DataRows["RowNo"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_List;
        }



        public Result GetLocations(string p_ItemID, int p_UserNO, string p_WarehouseID)
        {
            DataTable l_DataTable = new DataTable();
            string l_Query = string.Empty;
            DataTable l_Data = new DataTable();
            string l_param = string.Empty;
            List<string> l_List = new List<string>();
            DataSet l_DataSet = new DataSet();
            Result l_Result = new Result();

            try
            {
                l_Query = "EXEC SP_SMA_PSGetPullingLocations ";

                PublicFunction.FieldToParam(p_UserNO, ref l_param, PublicFunction.FieldTypes.Number);
                l_Query += l_param + ",";

                PublicFunction.FieldToParam(p_ItemID, ref l_param, PublicFunction.FieldTypes.String);
                l_Query += l_param + ",";

                PublicFunction.FieldToParam(p_WarehouseID, ref l_param, PublicFunction.FieldTypes.String);

                l_Query += l_param;

                this.Connection.GetDataSP(l_Query, ref l_DataSet);


                if (l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true)
                {
                    l_Result.IsSuccess = false;
                    l_Result.Description = l_DataSet.Tables[0].Rows[0].ToString();
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.NoSearchData;
                }
                else
                {
                    l_Result.IsSuccess = true;
                    l_Result.Description = PublicFunction.GetMessageDescription((int)GlobalDeclarations.SuccessCodes.OperationCompleted);
                    l_Result.Code = (int)GlobalDeclarations.SuccessCodes.OperationCompleted;

                    if ((l_DataSet.Tables.Count > 0))
                    {
                        l_DataTable = l_DataSet.Tables[0];
                    }

                    foreach (DataRow l_DataRows in l_DataTable.Rows)
                    {
                        l_List.Add(l_DataRows["LocationID"].ToString());
                    }
                    l_Result.DocumentDataList = l_List;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                l_Data.Dispose();
            }
            return l_Result;
        }


        public Result GetPullingLineInfo(int p_IDX,int p_UserNo, int p_PickUpBatchNo, string p_Floor, string p_Row, string p_WarehouseID)
        {
            DataTable l_DataTable_PullingLine = null/* TODO Change to default(_) if this is not a reference type */;
            DataTable l_DataTable_Exception = null/* TODO Change to default(_) if this is not a reference type */;
            DataSet l_DataSet = new DataSet();
            string l_Message = string.Empty;
            DataTable l_OutputParamsDataTable;
            int l_TotalQtyToPick = 0;
            int l_TotalPickedQty = 0;
            int l_TotalBatchQty = 0;
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            string l_ShipVia = string.Empty;
            string l_Query = string.Empty;
            Result l_Result = new Result();
            Result l_PullingInfo = new Result();
            List<string> l_List = new List<string>();
        

            try
            {
                l_OutputParamsDataTable = new DataTable();

                if (p_PickUpBatchNo > 0)
                {
                    l_PullingInfo = GetPullingInfo( p_UserNo, p_WarehouseID, p_PickUpBatchNo);
                    if (!l_PullingInfo.IsSuccess)
                    {
                        return l_PullingInfo;
                    }
                }

                l_Query = "EXEC sp_SMA_PSGetPullingLine ";

                PublicFunction.FieldToParam(p_IDX, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";
                PublicFunction.FieldToParam(p_PickUpBatchNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_Floor, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_Row, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;


                this.Connection.GetDataSP(l_Query, ref l_DataSet);


                if ((l_DataSet) == null || l_DataSet.Tables.Count <= 0)
                {
                    l_Result.Description = "Cannot find record against this PickupBatchNo[" + p_PickUpBatchNo.ToString() + "]";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;
                }

                if (l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true)
                    l_DataTable_Exception = l_DataSet.Tables[0];
                else
                {
                    l_DataTable_PullingLine = l_DataSet.Tables[0];
                    l_OutputParamsDataTable = l_DataSet.Tables[1];
                }

                if (l_DataTable_Exception != null && l_DataTable_Exception.Rows.Count > 0)
                {
                    l_Result.IsSuccess = false;
                    l_Result.Description = l_DataSet.Tables[0].Rows[0].ToString();
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError; ;
                    return l_Result;
                }

                if (l_OutputParamsDataTable != null && l_OutputParamsDataTable.Rows.Count > 0)
                {
                    l_TotalQtyToPick = Convert.ToInt32(l_OutputParamsDataTable.Rows[0]["TotalQtyToPick"].ToString());
                    l_TotalPickedQty = Convert.ToInt32(l_OutputParamsDataTable.Rows[0]["TotalPickedQty"].ToString());
                    l_TotalBatchQty = Convert.ToInt32(l_OutputParamsDataTable.Rows[0]["TotalPickedQty"].ToString());
                  
                    l_Message = l_OutputParamsDataTable.Rows[0]["Message"].ToString();

                    l_Result.TotalQtyToPick = l_TotalQtyToPick;
                    l_Result.TotalPickedQty = l_TotalPickedQty;
                    l_Result.TotalBatchQty = l_TotalQtyToPick;

                    l_Result.MessageID = l_Message;
                }

                if (l_DataTable_PullingLine != null && l_DataTable_PullingLine.Rows.Count > 0)
                {

                    foreach (DataRow l_Row in l_DataTable_PullingLine.Rows)
                    {

                        l_Result.ShipVia = Convert.ToString(l_Row["ShipVia"]);
                        l_Result.PickingTicketNo = Convert.ToInt32(l_Row["PickingTicketNo"].ToString());
                        l_Result.Line_No = Convert.ToInt32(l_Row["Line_No"].ToString());
                        l_Result.CustomerID = Convert.ToString(l_Row["CustomerID"]);
                        l_Result.CustomerPO = Convert.ToString(l_Row["CustomerPO"]);
                        l_Result.PickItem = Convert.ToString(l_Row["ItemID"]);
                        l_Result.SKU = Convert.ToString(l_Row["SKU"]);
                        l_Result.Itemtype = Convert.ToString(l_Row["ItemType"]);
                        l_Result.BaleNo = Convert.ToInt32(l_Row["BaleNO"]);
                        l_Result.PickupDate = Convert.ToString(l_Row["PickupDate"]);
                        l_Result.LabelPrintedDate = Convert.ToString(l_Row["LabelPrintedDate"]);
                        l_Result.DocumentDataList.Add(Convert.ToString(l_Row["LocationID"]));

                        break;
                    }

                }

                l_Result.IsSuccess = true;
                l_Result.Description = PublicFunction.GetMessageDescription((int)GlobalDeclarations.SuccessCodes.OperationCompleted);
           
            }

            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            finally
            {
                l_DataSet.Dispose();
            }
            return l_Result;
        }

        public Result GetScannedItem(int p_PickingTicketNo, int p_LineNo, int p_UserNO, int p_PickupBatchNO, int p_BaleNo, string p_ItemID, string p_SKU, string p_PickingLocation, string p_Floor, string p_Row, int p_IDX, string p_WareshouseID, string p_LastPickedItem, string p_ItemType, int p_TotalPickupBatchQty)
        {
            DataTable l_DataTable_Exception = null;
            DataSet l_DataSet = new DataSet();
            int l_ErrorLevel;
            string l_ErrorMessage;
            DataRow l_ErrorRow;
            string l_ScannedItem;
            string l_FirstCharofScannedItem;
            string l_Param = String.Empty;
            string l_SQL = String.Empty;
            string l_Query = string.Empty;
            Result l_Result = new Result();
            DataTable l_OutputParamsDataTable;
            //int l_IDX = 0;


            try
            {

                if ((p_PickupBatchNO == 0))
                {
                    l_Result.Description = "Cannot find record against this PickupBatchNo [" + p_PickupBatchNO.ToString() + "]";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;
                }

                l_ScannedItem = p_ItemID;
                l_FirstCharofScannedItem = l_ScannedItem.ToUpper().Substring(0, 1);
                if ((l_ScannedItem.Length == 13) && (l_FirstCharofScannedItem == "P") && l_ScannedItem != p_LastPickedItem)
                {
                    try
                    {
                        p_PickingTicketNo = Convert.ToInt32(l_ScannedItem.Substring(1, 8));
                        p_LineNo = Convert.ToInt32(l_ScannedItem.Substring(9, 4));

                        if (string.IsNullOrEmpty(p_PickingTicketNo.ToString()) || string.IsNullOrEmpty(p_LineNo.ToString()))
                        {
                            // TODO: Exit Try: Warning!!! cannot be translated
                        }

                        l_Query = " Exec SP_SMA_GetIDXOfScannedPackingID ";
                        PublicFunction.FieldToParam(p_PickingTicketNo, ref l_Param, PublicFunction.FieldTypes.Number);

                        l_Query += l_Param + ",";
                        PublicFunction.FieldToParam(p_LineNo, ref l_Param, PublicFunction.FieldTypes.Number);

                        l_Query += l_Param;

                        this.Connection.GetDataSP(l_Query, ref l_DataSet);

                        if ((l_DataSet) == null || l_DataSet.Tables.Count <= 0)
                        {
                            l_Result.Description = "Cannot find record against this PickupBatchNo[" + p_PickingTicketNo.ToString() + "]";
                            l_Result.IsSuccess = false;
                            //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                            return l_Result;
                        }


                        p_IDX = Convert.ToInt32(PublicFunction.ConvertNull(l_DataSet.Tables[0].Rows[0]["IDX"], -1).ToString());

                        if (p_IDX == -1)
                        {
                            l_Result.Description = "Can not get any Info against this PackingID[" + (l_ScannedItem + "]");
                            l_Result.IsSuccess = false;
                            //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                            return l_Result;
                        }

                        this.m_CurrentPickingTicketRowIDX = Convert.ToInt32(PublicFunction.ConvertNull(l_DataSet.Tables[0].Rows[0]["IDX"], 0));

                        this.m_Floor = p_Floor;
                        this.m_Row = p_Row;
                        GetPullingLineInfo(p_IDX, p_UserNO, p_PickupBatchNO, p_Floor, p_Row, p_WareshouseID);
                        return l_Result;
                    }

                    catch (Exception ex)
                    {
                        ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);

                    }

                }

                if ((p_ItemType.ToUpper() == "O"))
                {

                    if ((string.IsNullOrEmpty(l_ScannedItem) && string.IsNullOrEmpty(p_SKU)))
                    {
                        l_Result.Description = "Scan Oak Item";
                        l_Result.IsSuccess = false;
                        //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                        return l_Result;

                    }

                }
                else if (string.IsNullOrEmpty(l_ScannedItem))
                {
                    l_Result.Description = "Scan Prog Item";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;


                }

                if (string.IsNullOrEmpty(p_PickingLocation))
                {
                    l_Result.Description = "Select a picking location";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;

                }

                l_Query = " Exec SP_SMA_PSSetPulledItem ";
                PublicFunction.FieldToParam(p_UserNO, ref  l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickupBatchNO, ref  l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickingTicketNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";
                PublicFunction.FieldToParam(p_LineNo, ref  l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_BaleNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_ItemID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_SKU, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickingLocation, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                if (p_Floor != null)
                {

                    PublicFunction.FieldToParam(((p_Floor == "") ? "" : p_Floor), ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param + ",";
                }
                else
                {
                    PublicFunction.FieldToParam("", ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param + ",";
                }

                if (p_Row != null)
                {
                    PublicFunction.FieldToParam(((p_Row == "") ? "" : p_Row), ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param;
                }
                else
                {
                    PublicFunction.FieldToParam("", ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param;
                }

                this.Connection.GetDataSP(l_Query, ref l_DataSet);

                if (((l_DataSet == null) || (l_DataSet.Tables.Count <= 0)))
                {
                    l_Result.Description = "Getting error during picking this Item [" + (l_ScannedItem + "]");
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;


                }

                if ((l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true))
                {
                    l_DataTable_Exception = l_DataSet.Tables[0];
                }
                else
                {
                    l_OutputParamsDataTable = l_DataSet.Tables[0];
                }

                if ((!(l_DataTable_Exception == null) && (l_DataTable_Exception.Rows.Count > 0)))
                {
                    l_ErrorRow = l_DataTable_Exception.Rows[0];
                    l_ErrorMessage = PublicFunction.ConvertNull(l_ErrorRow["ErrorMessage"], String.Empty).ToString();
                    l_ErrorLevel = Convert.ToInt32(PublicFunction.ConvertNull(l_ErrorRow["MessageLevel"], 0).ToString());

                    if ((l_ErrorLevel == 0))
                    {
                        l_Result.Description = l_ErrorMessage;
                        l_Result.IsSuccess = false;
                        //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                        return l_Result;

                    }

                    l_Result.Description = l_ErrorMessage;
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;

                }

                l_Result.TotalQtyToPick = 0;
                l_Result.TotalPickedQty = 0;
                l_Result.SKU = string.Empty;
                l_Result.DocumentDataList = new List<string>();

                if ((!(l_DataSet == null) && (l_DataSet.Tables.Count > 0)))
                {
                    if (p_IDX + 1 <= p_TotalPickupBatchQty)
                    {
                        l_Result = GetPullingLineInfo(p_IDX + 1, p_UserNO, p_PickupBatchNO, p_Floor, p_Row, p_WareshouseID);
                        //l_Result.SKU = Convert.ToString(PublicFunction.ConvertNull(l_DataSet.Tables[0].Rows[0]["SKU"], String.Empty));
                    }
                    
                }
            }

            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return l_Result;

        }
        
        public Result RemovePickedItem(int p_UserNO, int p_PickupBatchNO, int p_PickingTicketNo, int p_LineNo, string p_ItemID, string p_PickingLocation, string p_SKU, string p_Floor, string p_Row)
        {
            DataTable l_OutputParamDataTable = null;
            DataTable l_DataTable_Exception = null;
            DataSet l_DataSet = new DataSet();
            int l_ErrorLevel;
            string l_ErrorMessage;
            DataRow l_ErrorRow;
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            string l_Query = string.Empty;
            Result l_Result = new Result();
            try

{
                l_Query = "EXEC SP_SMA_PSRemovePulledItem ";

                PublicFunction.FieldToParam(p_UserNO, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickupBatchNO, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickingTicketNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_LineNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_ItemID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickingLocation, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_SKU, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                if (p_Floor != null)
                {
                    PublicFunction.FieldToParam(((p_Floor == "") ? "" : p_Floor), ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param + ",";
                }
                else
                {
                    PublicFunction.FieldToParam("", ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param + ",";
                }

                if (p_Row !=null)
                {
                    PublicFunction.FieldToParam(((p_Row == "") ? "" : p_Row), ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param;
                }
                else
                {
                    PublicFunction.FieldToParam("", ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param;
                }

                this.Connection.GetDataSP(l_Query, ref l_DataSet);

                if (((l_DataSet == null) || (l_DataSet.Tables.Count <= 0)))
                {

                    l_Result.Description = "Getting error during removed picked item";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;
                   
                }


                if ((l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true))
                {
                    l_DataTable_Exception = l_DataSet.Tables[0];
                }
                else
                {
                    l_OutputParamDataTable = l_DataSet.Tables[0];
                }

                if ((!(l_DataTable_Exception == null)&& (l_DataTable_Exception.Rows.Count > 0)))
                {

                    l_ErrorRow = l_DataTable_Exception.Rows[0];
                    l_ErrorMessage = PublicFunction.ConvertNull(l_ErrorRow["ErrorMessage"], String.Empty).ToString();
                    l_ErrorLevel = Convert.ToInt32(PublicFunction.ConvertNull(l_ErrorRow["MessageLevel"], 0).ToString());

                    if ((l_ErrorLevel == 0))
                    {
                        l_Result.Description = l_ErrorMessage;
                        l_Result.IsSuccess = false;
                        //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                        return l_Result;

                    }

                    l_Result.Description = l_ErrorMessage;
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;
                }

                if ((!(l_DataSet == null) && (l_DataSet.Tables.Count > 0)))
                {

                    l_Result.Description = "Picked Item Remove Sucessfully";
                    l_Result.IsSuccess = true;
                    //l_Result.Code = (int)GlobalDeclarations.SuccessCodes.GenericSuccess;
                    return l_Result;
                }
            }
               
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return l_Result;
         
        }
        
        public Result ChangeLocation(int p_UserNO, int p_PickupBatchNO, int p_PickingTicketNo, int p_LineNo, int p_BaleNo, string p_PickingLocation, int p_IDX, string p_Floor, string p_Row, string p_WareshouseID)
        {
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            string l_Query = string.Empty;
            DataSet l_DataSet = new DataSet();
            Result l_Result = new Result();
            DataTable l_DataTable_Exception = new DataTable();

            try
            {
                l_Query = "SP_SMA_PSSetLocation ";

                PublicFunction.FieldToParam(p_UserNO, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickupBatchNO, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickingTicketNo, ref  l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_LineNo,ref  l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_BaleNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PickingLocation,ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;

                this.Connection.GetDataSP(l_Query, ref l_DataSet);

                if ((!(l_DataSet == null) && (l_DataSet.Tables.Count > 0)))
                {
                    if (l_DataSet.Tables.Count == 1 && l_DataSet.Tables[0].Columns.Contains("ErrorMessage"))
                    {
                        l_DataTable_Exception = l_DataSet.Tables[0];
                    }

                    if (l_DataTable_Exception != null && l_DataTable_Exception.Rows.Count > 0)
                    {
                        l_Result.IsSuccess = false;
                        l_Result.ErrorLevel = Convert.ToInt32(l_DataTable_Exception.Rows[0]["MessageLevel"].ToString());
                        l_Result.Description = l_DataTable_Exception.Rows[0]["ErrorMessage"].ToString();
                        //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                        return l_Result;

                    }

                    l_Result = GetPullingLineInfo(p_IDX, p_UserNO, p_PickupBatchNO, p_Floor, p_Row, p_WareshouseID);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return l_Result;

        }

        public Result ShowListofBatchNo(int p_IDX, int p_UserNO, int p_PickupBatchNO, string p_Floor, string p_Row, string p_WarehouseID)
        {
            DataTable l_DataTable_PullingLine = null/* TODO Change to default(_) if this is not a reference type */;
            DataTable l_DataTable_Exception = null/* TODO Change to default(_) if this is not a reference type */;
            DataSet l_DataSet = new DataSet();
            string l_Message = string.Empty;
            DataTable l_OutputParamsDataTable;
            int l_TotalQtyToPick = 0;
            int l_TotalPickedQty = 0;
            int l_TotalBatchQty = 0;
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            string l_ShipVia = string.Empty;
            string l_Query = string.Empty;
            Result l_Result = new Result();
            Result l_PullingInfo = new Result();
            List<string> l_List = new List<string>();


            try
            {
                l_OutputParamsDataTable = new DataTable();

                if (p_PickupBatchNO > 0)
                {
                    l_PullingInfo = GetPullingInfo(p_UserNO, p_WarehouseID, p_PickupBatchNO);
                    if (!l_PullingInfo.IsSuccess)
                    {
                        return l_PullingInfo;
                    }
                }

                l_Query = "EXEC sp_SMA_PSGetPullingLine ";

                PublicFunction.FieldToParam(p_IDX, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";
                PublicFunction.FieldToParam(p_UserNO, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";
                PublicFunction.FieldToParam(p_PickupBatchNO, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_Floor, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_Row, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_WarehouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;


                this.Connection.GetDataSP(l_Query, ref l_DataSet);


                if ((l_DataSet) == null || l_DataSet.Tables.Count <= 0)
                {
                    l_Result.Description = "Cannot find record against this PickupBatchNo[" + p_PickupBatchNO.ToString() + "]";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;
                }

                if (l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true)
                    l_DataTable_Exception = l_DataSet.Tables[0];
                else
                {
                    l_DataTable_PullingLine = l_DataSet.Tables[0];
                    l_OutputParamsDataTable = l_DataSet.Tables[1];
                }

                if (l_DataTable_Exception != null && l_DataTable_Exception.Rows.Count > 0)
                {
                    l_Result.IsSuccess = false;
                    l_Result.Description = l_DataSet.Tables[0].Rows[0].ToString();
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError; ;
                    return l_Result;
                }

                if (l_OutputParamsDataTable != null && l_OutputParamsDataTable.Rows.Count > 0)
                {
                    l_TotalQtyToPick = Convert.ToInt32(l_OutputParamsDataTable.Rows[0]["TotalQtyToPick"].ToString());
                    l_TotalPickedQty = Convert.ToInt32(l_OutputParamsDataTable.Rows[0]["TotalPickedQty"].ToString());
                    l_TotalBatchQty = Convert.ToInt32(l_OutputParamsDataTable.Rows[0]["TotalPickedQty"].ToString());

                    l_Message = l_OutputParamsDataTable.Rows[0]["Message"].ToString();

                    l_Result.TotalQtyToPick = l_TotalQtyToPick;
                    l_Result.TotalPickedQty = l_TotalPickedQty;
                    l_Result.TotalBatchQty = l_TotalQtyToPick;

                    l_Result.MessageID = l_Message;
                }

                if (l_DataTable_PullingLine != null && l_DataTable_PullingLine.Rows.Count > 0)
                {
                    
                    foreach (DataRow l_Row in l_DataTable_PullingLine.Rows)
                    {
                        BatchNoList l_BatchList = new BatchNoList();
                        l_BatchList.PickingLocation = PublicFunction.ConvertNull(l_Row["LocationID"],"").ToString();
                        l_BatchList.ItemID =  PublicFunction.ConvertNull(l_Row["ItemID"],"").ToString();
                        l_BatchList.PickUpDate = Convert.ToString( PublicFunction.ConvertNull(l_Row["PickUpDate"], ""));
                        l_BatchList.ShipVia=PublicFunction.ConvertNull(l_Row["ShipVia"],"").ToString();
                        l_BatchList.PickingTicketNo = Convert.ToInt32( PublicFunction.ConvertNull(l_Row["PickingTicketNo"],""));
                        l_BatchList.Line_No=Convert.ToInt32( PublicFunction.ConvertNull(l_Row["Line_No"],""));
                        l_BatchList.CustomerID=PublicFunction.ConvertNull(l_Row["CustomerID"],"").ToString();
                        l_BatchList.CustomerPO=PublicFunction.ConvertNull(l_Row["CustomerPO"],"").ToString();
                        l_BatchList.SKU = PublicFunction.ConvertNull(l_Row["SKU"],"").ToString();
                        l_BatchList.IDX = Convert.ToInt32( PublicFunction.ConvertNull(l_Row["IDX"],""));
                        l_BatchList.BaleNo = Convert.ToInt32(PublicFunction.ConvertNull(l_Row["BaleNo"], ""));
                        l_BatchList.Itemtype = PublicFunction.ConvertNull(l_Row["Itemtype"],"").ToString();
                        l_BatchList.LabelPrintedDate = Convert.ToDateTime(PublicFunction.ConvertNull(l_Row["LabelPrintedDate"], null));
                        l_Result.BatchList.Add(l_BatchList);
                    }

                }

                l_Result.IsSuccess = true;
                l_Result.Description = PublicFunction.GetMessageDescription((int)GlobalDeclarations.SuccessCodes.OperationCompleted);

            }

            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            finally
            {
                l_DataSet.Dispose();
            }
            return l_Result;

        }
        
        private string ConvertNull(DataTable l_DataTable_PullingLine, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public Result GetPullingInfo(int p_UserNo, string p_WHSID, int p_PickUpBatchNo )
        {
            DataTable l_DataTable_Exception;
            DataSet l_DataSet = new DataSet();
            Result l_Result = new Result();
            string l_Query = string.Empty;
            string l_Params = string.Empty;

            l_DataTable_Exception = null/* TODO Change to default(_) if this is not a reference type */;

            try
            {
                l_Query = " EXECUTE sp_SMA_PSGetPullingInfo ";
               
                 PublicFunction. FieldToParam(p_UserNo, ref l_Params, PublicFunction.FieldTypes.Number);
                 l_Query = (l_Query + (" @p_UserNo ="+ (l_Params + ",")));


                PublicFunction. FieldToParam(p_WHSID,ref  l_Params, PublicFunction.FieldTypes.String);
                l_Query = (l_Query + (" @p_WHSID = "+ (l_Params + ",")));
          
                PublicFunction. FieldToParam(p_PickUpBatchNo, ref l_Params, PublicFunction.FieldTypes.Number);
                l_Query = (l_Query + (" @p_PickupBatchNO = " + l_Params));

                this.Connection.GetDataSP(l_Query, ref l_DataSet);


                if (l_DataSet.Tables.Count == 1 && l_DataSet.Tables[0].Columns.Contains("ErrorMessage"))
                {
                    l_DataTable_Exception = l_DataSet.Tables[0];
                }

                if (l_DataTable_Exception != null && l_DataTable_Exception.Rows.Count > 0)
                {
                    l_Result.IsSuccess = false;
                    l_Result.ErrorLevel = Convert.ToInt32(l_DataTable_Exception.Rows[0]["MessageLevel"].ToString());
                    l_Result.Description = l_DataTable_Exception.Rows[0]["ErrorMessage"].ToString();
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;

                }

                l_Result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                l_DataSet.Dispose();
            }
            return l_Result;
        }


        public Result GetDataAgainstTrackingNo(int p_UserNo,string p_TrackingNo,string p_WareshouseID,string p_ShipVia)
        {

        DataTable l_DataTable = new DataTable();
        DataSet l_DataSet = new DataSet();
        DataRow l_DataRow = null;
        int l_MsgID;
        string l_Message;
        string l_Query = string.Empty;
        Result l_Result = new Result();
        string l_TrackingNo = String.Empty;
        string l_SQL = String.Empty;
        string l_Param = String.Empty;
      
        try 
        {
            if (string.IsNullOrEmpty(p_TrackingNo))
            {
                    l_Result.Description = "Tracking # is not scanned.";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;
            }
            

            l_Query = "EXEC SP_SMA_GetShipmentStatus ";

            PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
             l_Query += l_Param + ",";


            PublicFunction.FieldToParam(p_TrackingNo,ref l_Param, PublicFunction.FieldTypes.String);
             l_Query += l_Param + ",";

             PublicFunction.FieldToParam(p_WareshouseID, ref  l_Param, PublicFunction.FieldTypes.String);
              l_Query += l_Param + ",";

              PublicFunction.FieldToParam(p_ShipVia, ref l_Param, PublicFunction.FieldTypes.String);
            l_Query += l_Param;

             this.Connection.GetDataSP(l_Query, ref l_DataSet);
            
            if (((l_DataSet == null) || (l_DataSet.Tables.Count <= 0))) 
            {

                    l_Result.Description = (("Cannot verify Tracking No." + (Environment.NewLine + "Try Again.")));
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;
                
            }

            if ((l_DataSet.Tables.Count > 0))
            {
                l_DataTable = l_DataSet.Tables[0];
            }

            if (((l_DataTable.Rows.Count > 0) && l_DataTable.Columns.Contains("ErrorMessage")))
            {
                l_DataRow = l_DataTable.Rows[0];
                l_Message = Convert.ToString( PublicFunction.ConvertNull(l_DataRow["ErrorMessage"], String.Empty));
                l_MsgID = Convert.ToInt32(PublicFunction.ConvertNull(l_DataRow["MsgID"], 0));
                if ((l_MsgID == 1))
                {
                    if (l_Message.Contains("Tracking")) 
                    {

                        l_Result.Description = l_Message;
                        return l_Result;
                    }
                    else if (l_Message.Contains("Shipment"))
                    {
                        l_Result.Description = l_Message;
                        return l_Result;


                    }
                    else if (l_Message.Contains("Confimred"))
                    {
                        l_Result.Description = l_Message;
                        return l_Result;

                    }
                    else
                    {
                        l_Result.Description = l_Message;
                        return l_Result;

                    }
        
                }
                else if ((l_MsgID == 2)) 
                {
                    l_Result.Description = l_Message;
                    l_Result.IsSuccess = false;
                    return l_Result;

                }
    
                // TODO: Exit Function: Warning!!! Need to return the value
                return l_Result;
            }

            if ((!(l_DataTable == null) && (l_DataTable.Rows.Count > 0)))
            {

                foreach (DataRow l_Row in l_DataTable.Rows)
                {
                        
                     ConfirmItems l_ConfirmItems = new ConfirmItems();

                        l_ConfirmItems.ItemID =PublicFunction.ConvertNull(l_Row["ItemID"], "").ToString();

                        l_ConfirmItems.ConfirmedStatus = Convert.ToString(PublicFunction.ConvertNull(l_Row["Confirmed_Status"], String.Empty));

                    l_Result.ConfirmItemsList.Add(l_ConfirmItems);
                    l_Result.IsSuccess = true;
                    }
                return l_Result;
            }
            
           
        }
        catch (Exception ex) 
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
        }
        
        return l_Result;
    }


        public Result VerifyItemIDTextBoxAgainstTrackingNo(int p_UserNo, string p_TrackingNo, string p_ItemID, string p_WareshouseID, string p_ShipVia, string p_TotalShipmentCount, string p_ConfirmShipmentCount)
        {
            DataTable l_DataTable = null;
            DataSet l_DataSet = new DataSet();
            DataRow l_DataRow = null;
            int l_MsgID,l_PackingID;
            string l_Message = String.Empty;
            string l_TrackingNo = String.Empty;
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            Result l_Result = new Result();
            string l_Query = string.Empty;
            try
            {
              

                if (string.IsNullOrEmpty(p_TrackingNo))
                {

                    l_Result.Description = "Tracking # is not scanned.";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    
                    return l_Result;


                 
                }

                if (string.IsNullOrEmpty(p_ItemID))
                {

                    l_Result.Description = "Item ID or Package ID is not scanned.";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;

                    return l_Result;



                }

                if (p_ShipVia=="LTL")
                {
                    l_Query = "Exec SP_SMA_ShipmentStatus_LTL ";
                }
                else
                {
                    l_Query = "Exec SP_SMA_ShipmentStatus ";
                }

                PublicFunction.FieldToParam(p_UserNo,ref  l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_TrackingNo, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_ItemID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_WareshouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";


                if (p_ShipVia == "F")
                {
                    PublicFunction.FieldToParam(p_ShipVia, ref l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param;
                }
                else if (p_ShipVia == "U")
                {
                    PublicFunction.FieldToParam(p_ShipVia, ref  l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param;
                }

                else if (p_ShipVia == "LTL") {
                    PublicFunction.FieldToParam(p_ShipVia, ref  l_Param, PublicFunction.FieldTypes.String);
                    l_Query += l_Param ;
                }

                this.Connection.GetDataSP(l_Query, ref l_DataSet);

                if (((l_DataSet == null)|| (l_DataSet.Tables.Count <= 0)))
                {

                    l_Result.Description = (("Cannot verify ItemID against Tracking No."+ (Environment.NewLine + "Please try again.")));
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;

                    
                }

                if ((l_DataSet.Tables.Count > 0))
                {
                    l_DataTable = l_DataSet.Tables[0];
                }

                if ((l_DataTable.Rows.Count > 0))
                {
                    l_DataRow = l_DataTable.Rows[0];
                    l_Message = Convert.ToString( PublicFunction.ConvertNull(l_DataRow["ErrorMessage"], String.Empty));
                    l_MsgID = Convert.ToInt32( PublicFunction.ConvertNull(l_DataRow["MsgID"], 0));
                 



                    if ((l_MsgID == 0))
                    {
                        DataRow[] l_DataRRow = l_DataSet.Tables[1].Select("Confirmed_Status = 'C'");
                        if (l_DataRRow.Length > 0)
                        {

                            l_Result.Description = l_Message;
                            l_Result.IsSuccess = true;
                            l_Result.Code = 1;
                            l_Result.P1 = Convert.ToString(0);
                            l_Result.MessageID = Convert.ToString(l_MsgID);
                            return l_Result;

                        }
                        else
                        {
                            l_Result.Description = l_Message;
                            l_Result.IsSuccess = true;
                            l_Result.P1 = Convert.ToString(1);
                            l_Result.MessageID = Convert.ToString(l_MsgID);
                        }

                        GetShipmentCount(p_WareshouseID, p_TotalShipmentCount, p_ConfirmShipmentCount);
                    }
                    else if ((l_MsgID == 1))
                    {
                        if (l_Message.Contains("Confimred"))
                        {

                            l_Result.Description = l_Message;
                            l_Result.IsSuccess = false;
                            l_Result.MessageID = Convert.ToString(l_MsgID);
                            return l_Result;
                         
                        }
                        else
                        {

                            l_Result.Description = l_Message;
                            l_Result.MessageID = Convert.ToString(l_MsgID);
                            return l_Result;

                        }

                    }
                    else if ((l_MsgID == 2))
                    {
                        l_Result.Description = l_Message;
                        l_Result.IsSuccess = false;

                        return l_Result;


                    }

                }

            }
            catch (Exception ex)
            {
                
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
           
            return l_Result;
        }


        public Result ConfirmPackage(string p_TrackingNo)
        {
            DataTable l_DataTable = null;
            DataSet l_DataSet = new DataSet();
            DataRow l_DataRow = null;
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Query = string.Empty;
            Result l_Result = new Result();
      
            try
            {
                l_Query = "EXEC SP_SMA_ConfirmPackageShipment ";

                PublicFunction.FieldToParam(p_TrackingNo, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;

                this.Connection.GetDataSP(l_Query, ref l_DataSet);


                if ((!(l_DataSet == null) && (l_DataSet.Tables.Count > 0)))
                {
                     l_Result.Description = l_DataSet.Tables[0].Rows[0]["Message"].ToString();
                     l_Result.IsSuccess = true;
                    return l_Result;
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return l_Result;
        }


        public Result GetShipmentCount(string p_WareshouseID, string p_TotalShipmentCount, string p_ConfirmShipmentCount) 
         {

            DataSet l_DataSet = new DataSet();
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            Result l_Result = new Result();
            string l_Query = string.Empty;
            try
            {
                l_Query = "Exec SP_SMA_ShipmentCount ";

                PublicFunction.FieldToParam(p_WareshouseID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_TotalShipmentCount, ref  l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_ConfirmShipmentCount,ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;

                this.Connection.GetDataSP(l_Query, ref l_DataSet);
            
                if (((l_DataSet == null) || (l_DataSet.Tables.Count <= 0)))
                {

                    l_Result.Description = (("Data Not Found."));
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;
                    return l_Result;

                }

                l_Result.ConfirmShipmentCount = Convert.ToString( PublicFunction.ConvertNull(l_DataSet.Tables[0].Rows[0]["ConfirmShipmentCount"],string.Empty));
                l_Result.TotalShipmentCount = Convert.ToString(PublicFunction.ConvertNull(l_DataSet.Tables[0].Rows[0]["TotalShipmentCount"], string.Empty));



                l_Result.Description = "Count Table Found.";
                l_Result.IsSuccess = true;
                //l_Result.Code = (int)GlobalDeclarations.SuccessCodes.GenericSuccess;
            }

            catch (Exception ex)
        {
            ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
       
        }
        return l_Result;
    }

        public Result GetShipmentListData(int p_UserNo, string p_PackingSlipNo) 
        {
             DataSet l_DataSet = new DataSet();
            // Warning!!! Optional parameters not supported
            DataTable l_ScanReciptItem = null;
            DataTable l_DataTable = new DataTable();
            DataRow l_DataRow = null;
            int l_Errorlevel;
            string l_ErrorMessage;
            DataRow l_ErrorRow;
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            Result l_Result = new Result();
            string l_Query = string.Empty;
            DataTable l_DataTable_Exception = null;
            List<string> l_List = new List<string>();


            try
            {
                l_Query = "Exec SP_SMA_GetShipmentListData ";

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PackingSlipNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param;

                this.Connection.GetDataSP(l_Query, ref l_DataSet);

                if (((l_DataSet == null) || (l_DataSet.Tables.Count <= 0)))
                {
                    return l_Result;
                }

                if ((l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true))
                {
                    l_ErrorRow = l_DataSet.Tables[0].Rows[0];
                    l_ErrorMessage = Convert.ToString(PublicFunction.ConvertNull(l_ErrorRow["ErrorMessage"], string.Empty));
                    l_Errorlevel = Convert.ToInt32(PublicFunction.ConvertNull(l_ErrorRow["MessageLevel"], ""));

                    l_Result.Description = l_ErrorMessage;
                    l_Result.IsSuccess = false;
                    return l_Result;
                }
                l_ScanReciptItem = l_DataSet.Tables[1];
                if (l_ScanReciptItem != null && l_ScanReciptItem.Rows.Count > 0)
                {

                    foreach (DataRow l_Row in l_ScanReciptItem.Rows)
                    {
                        if (PublicFunction.ConvertNull(l_Row["LocationID"], "").ToString() == "Back Order List")
                        {
                            VendorShipmentList l_BackOrder = new VendorShipmentList();
                            l_BackOrder.ItemID = PublicFunction.ConvertNull(l_Row["ItemID"], "").ToString();
                            l_BackOrder.LocationID = PublicFunction.ConvertNull(l_Row["LocationID"], "").ToString();
                            l_BackOrder.QTY = PublicFunction.ConvertNull(l_Row["QTY"], "").ToString();
                            l_Result.BackOrder.Add(l_BackOrder);
                        }
                        else
                        {

                            VendorShipmentList l_ReceiveOrder = new VendorShipmentList();
                            l_ReceiveOrder.ItemID = PublicFunction.ConvertNull(l_Row["ItemID"], "").ToString();
                            l_ReceiveOrder.LocationID = PublicFunction.ConvertNull(l_Row["LocationID"], "").ToString();
                            l_ReceiveOrder.QTY = PublicFunction.ConvertNull(l_Row["QTY"], "").ToString();
                            l_Result.ReceiveOrder.Add(l_ReceiveOrder);
                        }
                        }
                }

                l_Result.IsSuccess = true;
                l_Result.Description = PublicFunction.GetMessageDescription((int)GlobalDeclarations.SuccessCodes.OperationCompleted);
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        return l_Result;
    }
        
        public Result AddItemIDToGrid(int p_UserNo, string p_PackingSlipNo, string p_ItemID, string p_LocationID, bool p_Redbin, int p_ForceFully, bool p_IsReceiveItemEnable, bool p_Greenbin)
        {
            DataTable l_DataTable;
            DataTable l_DataTable_Exception;
            DataSet l_DataSet = new DataSet();
            int l_Errorlevel;
            string l_ErrorMessage;
            DataRow l_ErrorRow;
            Result l_Result = new Result();
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            string l_Query = string.Empty;
            int l_RedBinFlag = 0;
            string l_LocationID = String.Empty;
            try
            {
                if (string.IsNullOrEmpty(p_PackingSlipNo))
                {

                    l_Result.Description = "Invalid vendor\'s shipment list number.";
                    l_Result.IsSuccess = false;
                    //     l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;

                    return l_Result;
                }

                if (string.IsNullOrEmpty(p_ItemID))
                {

                    l_Result.Description = "Item is not scanned.";
                    l_Result.IsSuccess = false;
                    // l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;

                    return l_Result;
                }
                l_Query = "Exec SP_SMA_SetShipmentList ";
                if (p_IsReceiveItemEnable == true)
                {
                    l_Query = "Exec SP_SMA_UndoShipmentList ";
                }

                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PackingSlipNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_ItemID, ref  l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_LocationID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_Redbin, ref  l_Param, PublicFunction.FieldTypes.Boolean);
                l_Query += l_Param + ",";

             
                PublicFunction.FieldToParam(p_ForceFully, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param;

                this.Connection.GetDataSP(l_Query, ref l_DataSet);

                if (((l_DataSet == null)|| (l_DataSet.Tables.Count <= 0)))
                {
                    return l_Result;
                }

                if ((l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true))
                {
                    l_DataTable_Exception = l_DataSet.Tables[0];
                    l_ErrorRow = l_DataSet.Tables[0].Rows[0];
                    l_ErrorMessage = Convert.ToString( PublicFunction.ConvertNull(l_ErrorRow["ErrorMessage"], string.Empty));
                    l_Errorlevel = Convert.ToInt16( PublicFunction.ConvertNull(l_ErrorRow["MessageLevel"], 0));
                    if ((l_Errorlevel == 0))
                    {
                        l_Result.Description = l_ErrorMessage;
                        l_Result.IsSuccess = false;
                        return l_Result;
                    }
                    else if ((l_Errorlevel == 1))
                    {
                        this.AddItemIDToGrid(p_UserNo, p_PackingSlipNo, p_ItemID, p_LocationID, true, p_ForceFully, p_IsReceiveItemEnable, p_Greenbin);
                        l_Result.Description = PublicFunction.GetMessageDescription((int)GlobalDeclarations.SuccessCodes.OperationCompleted);
                        l_Result.P1 = p_Redbin == false ? "1" : "0";
                        l_Result.IsSuccess = true;
                        return l_Result;
                    }

                    else
                    {
                        l_Result.Description = l_ErrorMessage;
                        l_Result.IsSuccess = false;
                        return l_Result;
                    }
                  
                }

                 l_DataTable = l_DataSet.Tables[0];

                {
                    l_Result.Description = PublicFunction.GetMessageDescription((int)GlobalDeclarations.SuccessCodes.OperationCompleted);
                    l_Result.P1 = p_Redbin == true ? "1" : "0"; 
                    l_Result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return l_Result;
        }

        public Result UndoItemIDFromGrid(int p_UserNo, string p_PackingSlipNo, string p_ItemID, string p_LocationID, bool p_Redbin, int p_ForceFully, bool p_IsReceiveItemEnable, bool p_Greenbin)
        {
            DataTable l_DataTable;
            DataTable l_DataTable_Exception;
            DataSet l_DataSet = new DataSet();
            int l_Errorlevel;
            string l_ErrorMessage;
            DataRow l_ErrorRow;
            Result l_Result = new Result();
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            string l_Query = string.Empty;
            int l_RedBinFlag = 0;
            string l_LocationID = String.Empty;
            try
            {
                if (string.IsNullOrEmpty(p_PackingSlipNo))
                {

                    l_Result.Description = "Invalid vendor\'s shipment list number.";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;

                    return l_Result;
                }

                if (string.IsNullOrEmpty(p_ItemID))
                {

                    l_Result.Description = "Item is not scanned.";
                    l_Result.IsSuccess = false;
                    //l_Result.Code = (int)GlobalDeclarations.ErrorCodes.GenericError;

                    return l_Result;
                }
               
                    l_Query = "Exec SP_SMA_UndoShipmentList ";
                
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_PackingSlipNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_ItemID, ref  l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_LocationID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param + ",";

                PublicFunction.FieldToParam(p_Redbin, ref  l_Param, PublicFunction.FieldTypes.Boolean);
                l_Query += l_Param + ",";


                PublicFunction.FieldToParam(p_ForceFully, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += l_Param;

                this.Connection.GetDataSP(l_Query, ref l_DataSet);

                if (((l_DataSet == null) || (l_DataSet.Tables.Count <= 0)))
                {
                    return l_Result;
                }

                if ((l_DataSet.Tables[0].Columns.Contains("ErrorMessage") == true))
                {
                    l_DataTable_Exception = l_DataSet.Tables[0];
                    l_ErrorRow = l_DataSet.Tables[0].Rows[0];
                    l_ErrorMessage = Convert.ToString(PublicFunction.ConvertNull(l_ErrorRow["ErrorMessage"], string.Empty));
                    l_Errorlevel = Convert.ToInt16(PublicFunction.ConvertNull(l_ErrorRow["MessageLevel"], 0));
                    if ((l_Errorlevel == 0))
                    {
                        l_Result.Description = l_ErrorMessage;
                        l_Result.IsSuccess = false;
                        return l_Result;
                    }
                    else if ((l_Errorlevel == 1))
                    {
                        l_Result = this.UndoItemIDFromGrid(p_UserNo, p_PackingSlipNo, p_ItemID, p_LocationID, true, p_ForceFully, p_IsReceiveItemEnable, p_Greenbin);
                        return l_Result;
                    }
                    
                    else
                    {
                        l_Result.Description = l_ErrorMessage;
                        l_Result.IsSuccess = false;
                        return l_Result;
                    }

                }

                l_DataTable = l_DataSet.Tables[0];

                {
                    l_Result.Description = PublicFunction.GetMessageDescription((int)GlobalDeclarations.SuccessCodes.OperationCompleted);
                    l_Result.P1 = p_Redbin == true ? "1" : "0";
                    l_Result.IsSuccess = true;
                    return l_Result;
                   
                }
                return l_Result;
    
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return l_Result;
        }        
        private string ConvertNull(object p, string v)
        {
            throw new NotImplementedException();
        }
    }
}

