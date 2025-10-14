using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
    public class Result
    {
        public Result()
        {
            this.DocumentDataList = new List<string>();
            this.BatchList=new  List<BatchNoList>();
            this.ConfirmItemsList = new List<ConfirmItems>();
            this.BackOrder = new List<VendorShipmentList>();
            this.ReceiveOrder = new List<VendorShipmentList>();

            //this.BatchList = new List<string>();
        }


        public List<BatchNoList> BatchList { get; set; }

        public List<ConfirmItems> ConfirmItemsList { get; set; }

        public List<VendorShipmentList> BackOrder { get; set; }

        public List<VendorShipmentList> ReceiveOrder { get; set; }

        public int Code { get; set; }

        //public int MessageID
        public string Description { get; set; }

        public int ErrorLevel { get; set; }

        public int ErrorType { get; set; }

        public string ErrorID { get; set; }

        public string MessageID { get; set; }
        
        public bool IsSuccess { get; set; }

        public bool DocumentNo { get; set; }

        public string DocumentKey { get; set; }

        public string P1 { get; set; }

        public string P2 { get; set; }

        public string P3 { get; set; }

        public string P4 { get; set; }

        public string P5 { get; set; }

        public string P6 { get; set; }

        public int UserNo { get; set; }

        public string UserID { get; set; }

        public int TotalQtyToPick { get; set; }
		
        public int TotalPickedQty { get; set; }
		
        public int TotalBatchQty { get; set; }
		
        public string ShipVia { get; set; }
		
        public int PickingTicketNo { get; set; }

        public int Line_No { get; set; }

        public string CustomerID { get; set; }
        
        public string PickItem { get; set; }

        public int BaleNo { get; set; }

        public int QTY { get; set; }

        public int PickUpBatchNo { get; set; }

        public string SKU { get; set; }
        
        public string LabelPrintedDate { get; set; }

        public string PickingLocation { get; set; }

        public string Floor { get; set; }
        
        public string Row { get; set; }
        
        public string ItemID { get; set; }

        public int IDX { get; set; }

        public string CustomerPO { get; set; }

        public string WarehouseID { get; set; }

        public string Itemtype { get; set; }

        public string PickupDate { get; set; }
        
        public string TotalShipmentCount { get; set; }

        public string ConfirmShipmentCount { get; set; }
        
        public List<string> DocumentDataList {get; set;}
        public int l_MsgID { get; internal set; }

        public int PackingID { get; set; }

        //public List<string> BatchList { get; set; }


        public static Result GetSuccessResult()
        {
            Result l_Result = new Result();
            // With...
            l_Result.Code = (int)GlobalDeclarations.SuccessCodes.OperationCompleted;
            l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
            l_Result.IsSuccess = true;

            return l_Result;
        }

        //public static Result GetFailureResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.OperationFailed;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetInvalidSKUResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.InvalidSKU;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetNoRecordResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.NoRecord;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetDuplicateRecordResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.DuplicateDocument;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetPreSaveResult(string p_ErrorCode)
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.PreSaveError;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;
        //    l_Result.ErrorID = p_ErrorCode;

        //    return l_Result;
        //}

        //public static Result GetDocumentAssociationResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ExceptionCodes.DeleteDocumentAssociation;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetPriceCategoryResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.CheckPriceCategory;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetDefaultAddress()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.CheckDefaultAddress;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result CheckCustomerAddresses()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.DeleteCustomerAddress;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetDuplicateCarrierCodeResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.DuplicateCarrierCode;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        //public static Result GetDesignIDLengthResult()
        //{
        //    Result l_Result = new Result();

        //    l_Result.Code = (int)GlobalDeclarations.ErrorCodes.DesignIDLength;
        //    l_Result.Description = PublicFunction.GetMessageDescription(l_Result.Code);
        //    l_Result.IsSuccess = false;

        //    return l_Result;
        //}

        public void Populate(DataTable p_Data)
        {
            DocumentNo = false;

            foreach (DataRow l_Row in p_Data.Rows)
            {
                foreach (DataColumn l_Column in p_Data.Columns)
                {

                    if (string.Compare(l_Column.ColumnName, "Success", true) == 0)
                    {

                        IsSuccess = DBConnector.ConvertNullAsBoolean(l_Row[l_Column], false);
                    }
                    else if ((string.Compare(l_Column.ColumnName, "Code", true) == 0))
                    {
                        Code = DBConnector.ConvertNullAsInteger(l_Row[l_Column], 0);
                    }
                    else if (((string.Compare(l_Column.ColumnName, "Description", true) == 0)
                                || ((string.Compare(l_Column.ColumnName, "ErrorMessage", true) == 0)
                                || (string.Compare(l_Column.ColumnName, "ErrDesc", true) == 0))))
                    {
                        Description = DBConnector.ConvertNullAsString(l_Row[l_Column], String.Empty);
                    }
                    else if ((string.Compare(l_Column.ColumnName, "MessageLevel", true) == 0))
                    {
                        ErrorLevel = DBConnector.ConvertNullAsInteger(l_Row[l_Column], 0);
                    }
                    else if ((string.Compare(l_Column.ColumnName, "ErrorNumber", true) == 0))
                    {
                        ErrorID = DBConnector.ConvertNullAsString(l_Row[l_Column], String.Empty);
                    }
                    else if ((string.Compare(l_Column.ColumnName, "MessageID", true) == 0))
                    {
                        MessageID = DBConnector.ConvertNullAsString(l_Row[l_Column], String.Empty);
                    }
                    else if (((string.Compare(l_Column.ColumnName, "ErrorState", true) == 0)
                                || (string.Compare(l_Column.ColumnName, "MessageType", true) == 0)))
                    {
                        ErrorType = DBConnector.ConvertNullAsInteger(l_Row[l_Column], 0);
                    }
                    //else if (string.IsNullOrEmpty(DocumentNo.ToString()) && (l_Column.ColumnName Like "Temp*No" OrElse l_Column.ColumnName Like "Temp*ID" OrElse l_Column.ColumnName Like "*No" OrElse l_Column.ColumnName Like "*ID" OrElse l_Column.ColumnName = "TempAccount"))
                    //{

                    //    DocumentNo = DBConnector.ConvertNullAsBoolean(l_Row[l_Column], false);
                    //    DocumentKey = l_Column.ColumnName;
                    //}
                    else if ((string.Compare(l_Column.ColumnName, "P1", true) == 0))
                    {
                        P1 = DBConnector.ConvertNullAsString(l_Row[l_Column], String.Empty);
                    }
                    else if ((string.Compare(l_Column.ColumnName, "UserNO", true) == 0))
                    {
                        UserNo = DBConnector.ConvertNullAsInteger(l_Row[l_Column], 0);
                    }
                    else if ((string.Compare(l_Column.ColumnName, "WarehouseID", true) == 0))
                    {
                        WarehouseID = DBConnector.ConvertNullAsString(l_Row[l_Column], "");
                    }

                }

                break;
            }

            //this.Data = p_Data.Copy;
        }

        public static implicit operator List<object>(Result v)
        {
            throw new NotImplementedException();
        }
    }
}
