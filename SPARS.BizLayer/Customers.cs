// -----------------------------------------------------------------------
// <copyright file="Customers.cs" company="Visionary Computer Solutions">
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
    public class Customers : DBEntity, IDBEntity
    {

        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string EDICustomerID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Company { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Address1 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Address2 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string City { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string State { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ZIP { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Country { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Phone1 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Phone2 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Fax { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Email { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string URL { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Status { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Category { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Class { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Region { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime Date { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UPSAccountID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShipVia { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Comment { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SaleType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int PriceCategory { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int PaymentTerm { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double SalesDiscount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double ServiceCharges { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool DropShipOnly { get; set; }


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

        public double TaxRate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string TaxID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerTaxID { get; set; }


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

        public double CreditLimit { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double OpenCredit { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double CurrentBalance { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double ConsignmentLimit { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double ConsignmentBalance { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double CPCOBalance { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double CPROBalance { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double OpenSO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double PTD_Sales { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double YTD_Sales { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double YTD_Orders { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double YTD_Payments { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double YTD_Credits { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double YTD_Adjustments { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double YTD_Discounts { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double YTD_Consignments { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastInvoiceDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double LastInvoiceAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastOrderDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double LastOrderAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastPaymentDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double LastPaymentAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double LastCreditAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastCreditDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool MCE_Allowed { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool ASN_Process { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool COD { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Freight_Collect { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool OneItemPerBale { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Print_EDI_Invoice { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool ProcessEDIInbound { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Process_810_Doc { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Special_Lables { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double AccountsSum { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double TotalMerchandize { get; set; }


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

        public bool PrintUCC128Labels { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SDQAddress { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string OldCustomerCode { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double PastDuePercentage { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PriceFormat { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool UniqueSpecialID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerVendorCode { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool EDIPrice { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CommissionSet { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool SeparateFreightCharges { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool AllowDuplicatePOinDS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool RemoveFromMail { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string StockingChargesType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double StockingChargesValue { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? OverLookLimitChecks { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? WEBCustomer { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Remarks { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Generate_ASN { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int DefaultShippingPriority { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string GenerateEDIUPS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string B2BOrderPlacement { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Signature_Required_forDelivery { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UPSShipmentNotification { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UPSNotificationRecepient { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OrderAcknowledgement { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int ShipmentNotification { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string OrderAcknowledgementEmail { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShipmentNotificationEmail { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string OrderAcknowledgementCcEmail { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShipmentNotificationCcEmail { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? DiscFromDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? DiscToDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Automatic_NotShipable { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Export_832 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string DoNot_MergePO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Generate_ASN_Lowes { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? EDI_Export870 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? EDI_Export846 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? EDI_Export832 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? EDI_Export855 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowB2BPromotionalDiscount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string HideSales { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? EDI_Export180 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? SkipPrinting { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double ShippingCharges { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? AllowExpandedLabel { get; set; }


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

        public double DeclareValueAmount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string GenerateGTIN14Labels { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string BillingWithTracking { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LCFP { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ETA_Split { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RDCSoperOrder { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShowPackingSlipOnInvoices { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Generate_ASN_DC { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? PreShipmentDays { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string EDI_846SplitFile { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string DoNotUseForRepZio { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Process_856_Doc { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? PackagePackingSlip { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Generate810StoreWise { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PriorityEDI850FromWHS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? CutOffDate_810 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? CutOffDate_856 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Process_EDI_TMS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowVoidBaleOnShipComplete { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Override_Shipvia { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SmallPackageShipVia { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LTLShipVia { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SmallPackageAccountID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LTLPackageAccountID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? CutOffDate_SkipPrinting { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? AutoInsertNewItems { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SourceID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? GenerateBillofLadingASN { get; set; }

        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Process_856S_Doc { get; set; }


        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempCustomerID { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempUserNo { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int UserNo { get; set; }

        /// <summary>
        ///   TODO: Update summary.
        /// </summary>
        /// 
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
        public Customers()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Customers(DBConnector connection)
        {
            this.SetupDBEntity();
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
        private void SetupDBEntity()
        {
            if (string.IsNullOrEmpty(Customers.TableName))
            {
                Customers.TableName = "Customers";
            }

            if (string.IsNullOrEmpty(Customers.PrimaryKeyName))
            {
                Customers.PrimaryKeyName = "CustomerID";
            }

            if (string.IsNullOrEmpty(Customers.EndingPropertyName))
            {
                Customers.EndingPropertyName = "Process_856S_Doc";
            }

            if (Customers.DBProperties == null)
            {
                Customers.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(Customers.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, Customers.TableName, Customers.EndingPropertyName, ref query, Customers.DBProperties);

                Customers.InsertQueryStart = query;
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
                query = "SELECT * FROM [" + Customers.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + Customers.TableName + "]";
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
                query = "SELECT * FROM [VW_" + Customers.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + Customers.TableName + "]";
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
            string l_Criteria = string.Empty;

            l_Criteria = " isnumeric(customerid) = 1 ";
            l_Criteria = l_Criteria + " AND CustomerID <> '999999' and CustomerID <> '888888' and CustomerID <> '777777' ";
            if (!this.GetList(l_Criteria, "MAX(" + Customers.PrimaryKeyName + ")", ref data))
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
        public bool GetObject(string CustomerID)
        {
            this.CustomerID = CustomerID;
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Customers.TableName, Customers.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Customers.TableName, PropertyName));
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

            this.PopulateObject(this, data, Customers.DBProperties, Customers.EndingPropertyName);

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Customers.TableName, Customers.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Result SaveNew()
        {
            bool l_Process = false;
            bool l_Trans = false;
            string l_InsertQuery = string.Empty;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();


            try
            {
                //this.CustomerID = this.GetMax();
                this.PrepareQueries(this, Customers.TableName, Customers.EndingPropertyName, ref l_InsertQuery, Customers.DBProperties);
                l_Query = this.PrepareInsertQuery(this, l_InsertQuery, Customers.EndingPropertyName, Customers.DBProperties);
                l_Trans = this.Connection.BeginTransaction();
                l_Process = this.Connection.Execute(l_Query);

                l_Result.IsSuccess = l_Process;

                //    //l_Result = this.PreSaveChecks();
                //    //if (l_Result.IsSuccess)

                //    l_Query = "EXEC sp_Customers_Create ";

                //    PublicFunction.FieldToParam(this.TempCustomerID, ref l_Param, PublicFunction.FieldTypes.Number);
                //    l_Query += " " + l_Param;

                //    PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                //    l_Query += ", " + l_Param;

                //    this.Connection.GetData(l_Query, ref l_Data);
                //    l_Result.Populate(l_Data);
                //}


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
                query = this.PrepareUpdateQuery(this, Customers.TableName, Customers.PrimaryKeyName, Customers.EndingPropertyName, Customers.DBProperties);

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
            return this.Delete(this.CustomerID);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool DeleteAll(string groupNos)
        {
            bool process = false;
            bool trans = false;
            string query = string.Empty;

            try
            {
                query = this.PrepareDeleteAllQuery(Customers.TableName, Customers.PrimaryKeyName, groupNos);

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
        public Result Delete(string CustomerID)
        {

            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();

            try
            {
                this.CustomerID = CustomerID;
                l_Trans = this.Connection.BeginTransaction();

                l_Query = "EXEC sp_Customers_Delete ";
                PublicFunction.FieldToParam(this.CustomerID, ref l_Param, PublicFunction.FieldTypes.Number);
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
                l_Query = "EXEC sp_Customers_PreSaveCheck";
                PublicFunction.FieldToParam(this.TempCustomerID, ref l_Param, PublicFunction.FieldTypes.Number);
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
        public int GetTempCustomer()
        {
            DataTable l_dt = new DataTable();
            int l_Number = 0;
            string l_SQL = String.Empty;
            string l_Param = String.Empty;
            l_SQL = "EXEC sp_SDE_GetMaxTempCustomer ";
            PublicFunction.FieldToParam(GlobalDeclarations.g_UserNo,ref l_Param, PublicFunction.FieldTypes.Number);
            l_SQL= l_SQL + l_Param;
            this.Connection.GetData(l_SQL, ref l_dt);
            if (!(l_dt == null))
            {
                l_Number = Convert.ToInt32(PublicFunction.ConvertNull(l_dt.Rows[0]["NextNumber"], 0).ToString());
                if ((l_Number == 0))
                {
                    throw new Exception("Unable to get the Next Number");
                }
            }
            l_dt.Dispose();
            return l_Number;
        }
    }
}
