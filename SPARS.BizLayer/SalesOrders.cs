// -----------------------------------------------------------------------
// <copyright file="Company.cs" company="Visionary Computer Solutions">
// © 2014 Visionary Computer Solutions Pvt. Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace SSS.BizLayer
{
    using SPARS.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Reflection;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SalesOrders: DBEntity, IDBEntity
    {
        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int SalesOrderNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerPO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string OrderPlacedBy { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime OrderDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime SODate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SalesType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Status { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool SpecialOrder { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Region { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string BillToAddress { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShipToAddress { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool DropShipAddress { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShipToWHS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime ShippingDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime CancelDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShipVia { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int ShippingPriority { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? PriceCategory { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? PaymentTerm { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? DiscountDays { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? DueDays { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double? PaymentDiscount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double SalesDiscount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool SpecialPricing { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool SpecialDescription { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LoadPrice { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double LoadPercentage { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string TaxID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double TaxRate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ARCAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string STLAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string FCRAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string DRVAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal OpenCredit { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int TotalQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int TotalQtyShipped { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal ServiceCharges { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal SHCharges { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal TaxAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal TotalAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string OrderTakenBy { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool GeneratePickingTicket { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SpecialInstruction { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? BlanketOrder { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SalesEvent { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int ADDUser { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime ADDDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? MODUser { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? MODDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string WarehouseID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool MCE_Allowed { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? CCPaymentNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? CashReceiptNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Not_Shipable { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LastActivityReason { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PriceFormat { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? CollateralCheckNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int AdvancePayments { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AdvancePaymentType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PeriodID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? ReleasedUser { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? ReleasedDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShowEventID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string EmailAddress { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ContactName { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ContactPhoneNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? TotalBales { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? TagProcessed { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string EDI_Canceled { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Converted_To { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Converted_From { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Converted_User { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? Converted_Date { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? ExportAllowed_855 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Exported_855 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Exported_855UserNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? Exported_855Date { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int IsEmailSent { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double? SHChargesPer { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string OnHold { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int CancelOrder_IsEmailSent { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShipComplete { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string IncludeDeclareValue { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal? DeclareValueAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Ship_ServiceMethod { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ServiceStandard { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal? ShippingCost { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Signature_Required_forDelivery { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Doc_IsEmailSent { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AddressType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerComments { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? OverrideShipVia { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? IsManualBaling { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? ReviewforBilling { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ExternalOrderNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RadiusMessage { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempSalesOrdersNo { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempUserNo { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int UserNo { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static string TableName { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static string PrimaryKeyName { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static string InsertQueryStart { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static string EndingPropertyName { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private static List<PropertyInfo> DBProperties { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public SalesOrders()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public SalesOrders(DBConnector connection)
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private void SetupDBEntity()
        {
            if (string.IsNullOrEmpty(SalesOrders.TableName))
            {
                SalesOrders.TableName = "SalesOrders";
            }

            if (string.IsNullOrEmpty(SalesOrders.PrimaryKeyName))
            {
                SalesOrders.PrimaryKeyName = "SalesOrdersID";
            }

            if (string.IsNullOrEmpty(SalesOrders.EndingPropertyName))
            {
                SalesOrders.EndingPropertyName = "UsedInShippingQuotes";
            }

            if (SalesOrders.DBProperties == null)
            {
                SalesOrders.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(SalesOrders.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, SalesOrders.TableName, SalesOrders.EndingPropertyName, ref query, SalesOrders.DBProperties);

                SalesOrders.InsertQueryStart = query;
            }
        }

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

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetList(string criteria, string fields, ref DataTable data, string orderby = "")
        {
            string query = string.Empty;

            if (string.IsNullOrEmpty(fields))
            {
                query = "SELECT * FROM [" + SalesOrders.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + SalesOrders.TableName + "]";
            }

            if (!string.IsNullOrEmpty(criteria))
            {
                query += " WHERE " + criteria;
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                query += " ORDER BY " + orderby;
            }

            return this.Connection.GetData(query, ref data);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetViewList(string criteria, string fields, ref DataTable data, string orderby = "")
        {
            string query = string.Empty;

            if (string.IsNullOrEmpty(fields))
            {
                query = "SELECT * FROM [VW_" + SalesOrders.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + SalesOrders.TableName + "]";
            }

            if (!string.IsNullOrEmpty(criteria))
            {
                query += " WHERE " + criteria;
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                query += " ORDER BY " + orderby;
            }

            return this.Connection.GetData(query, ref data);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int GetMax()
        {
            DataTable data = new DataTable();
            int maxNo = 1;

            if (!this.GetList(string.Empty, "MAX(" + SalesOrders.PrimaryKeyName + ")", ref data))
            {
                return maxNo;
            }

            maxNo = DBConnector.ConvertNullAsInteger(data.Rows[0][0], 0) + 1;

            data.Dispose();

            return maxNo;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(int SalesOrderNo)
        {
            this.SalesOrderNo = SalesOrderNo;
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + SalesOrders.TableName, SalesOrders.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + SalesOrders.TableName, PropertyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObjectFromQuery(string query)
        {
            DataTable data = new DataTable();

            if (!this.Connection.GetData(query, ref data))
            {
                return false;
            }

            this.PopulateObject(this, data, SalesOrders.DBProperties, SalesOrders.EndingPropertyName);

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + SalesOrders.TableName, SalesOrders.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Result SaveNew()
        {
            bool l_Process = false;
            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();


            try
            {
                //this.CompyID = this.GetMax();
                l_Query = this.PrepareUpdateQuery(this, ("Temp_" + SalesOrders.TableName), ("Temp" + SalesOrders.PrimaryKeyName), SalesOrders.EndingPropertyName, SalesOrders.DBProperties);
                l_Trans = this.Connection.BeginTransaction();
                l_Process = this.Connection.Execute(l_Query);
                if (l_Process)
                {
                    l_Result = this.PreSaveChecks();
                    if (l_Result.IsSuccess)
                    {
                        l_Query = "EXEC sp_Company_Create ";

                        PublicFunction.FieldToParam(this.TempSalesOrdersNo, ref l_Param, PublicFunction.FieldTypes.Number);
                        l_Query += " " + l_Param;

                        PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                        l_Query += ", " + l_Param;

                        this.Connection.GetData(l_Query, ref l_Data);
                        l_Result.Populate(l_Data);
                    }

                }

            }
            catch (Exception ex)
            {
                l_Process = false;
                throw;
            }
            finally
            {
                l_Data.Dispose();
                if ((l_Trans && l_Result.IsSuccess))
                {
                    this.Connection.CommitTransaction();
                }
                else if (l_Trans)
                {
                    this.Connection.RollbackTransaction();
                }

            }
            return l_Result;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool Modify()
        {
            bool process = false;
            bool trans = false;
            string query = string.Empty;

            try
            {
                query = this.PrepareUpdateQuery(this, SalesOrders.TableName, SalesOrders.PrimaryKeyName, SalesOrders.EndingPropertyName, SalesOrders.DBProperties);

                trans = this.Connection.BeginTransaction();

                process = this.Connection.Execute(query);
            }
            catch (Exception)
            {
                process = false;
                throw;
            }
            finally
            {
                if (trans && process)
                {
                    this.Connection.CommitTransaction();
                }
                else if (trans)
                {
                    this.Connection.RollbackTransaction();
                }
            }

            return process;
        }


        public Result Delete()
        {
            return this.Delete(this.SalesOrderNo);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool DeleteAll(int SalesOrderNo)
        {
            bool process = false;
            bool trans = false;
            string query = string.Empty;

            try
            {
                query = this.PrepareDeleteAllQuery(SalesOrders.TableName, SalesOrders.PrimaryKeyName, SalesOrderNo.ToString());

                trans = this.Connection.BeginTransaction();

                process = this.Connection.Execute(query);
            }
            catch (Exception)
            {
                process = false;
                throw;
            }
            finally
            {
                if (trans && process)
                {
                    this.Connection.CommitTransaction();
                }
                else if (trans)
                {
                    this.Connection.RollbackTransaction();
                }
            }

            return process;
        }

        // '' <summary>
        // '' TODO: Update summary.
        // '' </summary>
        public Result Delete(int SalesOrderNo)
        {

            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();

            try
            {
                this.SalesOrderNo = SalesOrderNo;
                l_Trans = this.Connection.BeginTransaction();

                l_Query = "EXEC sp_Company_Delete ";
                PublicFunction.FieldToParam(this.SalesOrderNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += " " + l_Param;

                PublicFunction.FieldToParam(this.UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);
                l_Result.Populate(l_Data);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                l_Data.Dispose();
                if ((l_Trans && l_Result.IsSuccess))
                {
                    this.Connection.CommitTransaction();
                }
                else if (l_Trans)
                {
                    this.Connection.RollbackTransaction();
                }

            }
            return l_Result;
        }


        /// <summary>
        /// TODO: Update summary.
        /// </summary>

        public Result PreSaveChecks()
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            Result l_Result = new Result();

            try
            {
                l_Query = "EXEC sp_Company_PreSaveCheck";
                PublicFunction.FieldToParam(this.TempSalesOrdersNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += " " + l_Param;

                PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_Query += ", " + l_Param;

                //PublicFunction.FieldToParam(Convert.ToInt32(this.DocumentMode), ref l_Param, PublicFunction.FieldTypes.Number);
                //l_Query += ", " + l_Param;

                this.Connection.GetData(l_Query, ref l_Data);
                l_Result.Populate(l_Data);
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

        public int CheckExternalOrderNo(string p_CustomerID, string p_ExternalOrderNo)
        {
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            DataTable l_Data = new DataTable();
            int l_SaleOrderNo = 0;

            try
            {
                PublicFunction.FieldToParam(p_CustomerID, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + " CustomerID = " + l_Param;

                PublicFunction.FieldToParam(p_ExternalOrderNo, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + " AND ExternalOrderNo =  " + l_Param;
                l_SQL = l_SQL + " AND Status <> 9 ";

                if (this.GetList(l_SQL, "*", ref l_Data))
                {
                    if (l_Data.Rows.Count > 0)
                    {
                        l_SaleOrderNo = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["SalesOrderNo"], string.Empty).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            finally
            {
                l_Data.Dispose();
            }

            return l_SaleOrderNo;
        }
    }
}
