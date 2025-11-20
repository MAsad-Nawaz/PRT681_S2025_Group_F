// -----------------------------------------------------------------------
// <copyright file="Users.cs" company="Visionary Computer Solutions">
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
    public class Users : DBEntity, IDBEntity
    {

        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UserID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int UserNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PassWord { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LastName { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string FirstName { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Description { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastLogInDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastLogOutDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LogInDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool LogInStatus { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LogOutDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string TerminalID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Blocked { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ActiveModule { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string VendorID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Restricted { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool AllowUserDefinePC { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Version { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? WebAccess { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastWebActivity { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool AllowMultiplePeriodEntry { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string TerminalServer { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AddRugsWithoutPO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowCreateWebUser { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowConfimBOFulFillment { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string FullCustomerAccess { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowAccountsManually { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowPOConfirmation { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UserSignature { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AdminUser { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string IsWarehousePicker { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? AllowVoidConfirmedPS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? AllowUpdateTrackingNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? AllowWebDashboard { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowToCreateItemPOS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowtoApproveDelivery { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowDeliveryCalendar { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowPOSRefund { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowChangesAfterApproval { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowVoidPOPOS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowVoidUnProcessedPOPOS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowDeliveriesinPastDates { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowDeliveryonLockedDates { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowUnlimitedDeliveries { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowPOInProgress { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowVoidPOSTransferToStore { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowModifyPOSTransferToStore { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowtoReplacementAtPOS { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowModifyCustomerNote { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowDeleteCustomerNote { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PriceProtected { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PriceAccessCode { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowVoidPOSFromNextDay { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? RestrictOperationLocationWise { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string WarehouseID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowVoidInvoices { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UserGroup { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShowB2BPriceRugProfile { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowWebReport { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SalesAnalysis { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CommissionAnalysis { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ARAnalysis { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CanHoldShipmentList { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowROLLLengthChange { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShowCcInfo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowtoDeleteCustomCutPiece { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowtoVoidActualCut { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowPOChangeAfterConfirm { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowIssueNegativeInvoice { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AllowSpecialOAKForCredit { get; set; }

     
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempUserNo { get; set; }


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
        public Users()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Users(DBConnector connection)
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private void SetupDBEntity()
        {
            if (string.IsNullOrEmpty(Users.TableName))
            {
                Users.TableName = "Users";
            }

            if (string.IsNullOrEmpty(Users.PrimaryKeyName))
            {
                Users.PrimaryKeyName = "KeyNo";
            }

            if (string.IsNullOrEmpty(Users.EndingPropertyName))
            {
                Users.EndingPropertyName = "ModDate";
            }

            if (Users.DBProperties == null)
            {
                Users.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(Users.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, Users.TableName, Users.EndingPropertyName, ref query, Users.DBProperties);

                Users.InsertQueryStart = query;
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
                query = "SELECT * FROM [" + Users.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + Users.TableName + "]";
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
                query = "SELECT * FROM [VW_" + Users.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + Users.TableName + "]";
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

            if (!this.GetList(string.Empty, "MAX(" + Users.PrimaryKeyName + ")", ref data))
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
        public bool GetObject(int UserNo)
        {
            this.UserNo = UserNo;
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Users.TableName, Users.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Users.TableName, PropertyName));
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

            this.PopulateObject(this, data, Users.DBProperties, Users.EndingPropertyName);

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Users.TableName, Users.PrimaryKeyName));
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
                this.UserNo = this.GetMax();
                l_Query = this.PrepareUpdateQuery(this, ("Temp_" + Users.TableName), ("Temp" + Users.PrimaryKeyName), Users.EndingPropertyName, Users.DBProperties);
                l_Trans = this.Connection.BeginTransaction();
                l_Process = this.Connection.Execute(l_Query);
                if (l_Process)
                {
                    l_Result = this.PreSaveChecks();
                    if (l_Result.IsSuccess)
                    {
                        l_Query = "EXEC sp_Users_Create ";

                        PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                        l_Query += " " + l_Param;

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
                query = this.PrepareUpdateQuery(this, Users.TableName, Users.PrimaryKeyName, Users.EndingPropertyName, Users.DBProperties);

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
            return this.Delete(this.UserNo);
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
                query = this.PrepareDeleteAllQuery(Users.TableName, Users.PrimaryKeyName, groupNos);

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
        public Result Delete(int UserNo)
        {

            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();

            try
            {
                this.UserNo = UserNo;
                l_Trans = this.Connection.BeginTransaction();

                l_Query = "EXEC sp_Users_Delete ";

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
                l_Query = "EXEC sp_Users_PreSaveCheck";
               
                PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
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
            }
            return l_Result;
        }
        public Result VerifyLogin(string UserID, string Password)
        {
            string l_Query = String.Empty;
            DataTable l_Data = new DataTable();
            string l_Param = String.Empty;
            Result l_Result = new Result();

            try
            {
                l_Query = "EXEC sp_SMA_LoginVerify";

                PublicFunction.FieldToParam(UserID, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += l_Param;

                PublicFunction.FieldToParam(Password, ref l_Param, PublicFunction.FieldTypes.String);
                l_Query += ", " + l_Param;

                //PublicFunction.FieldToParam(WareHouseID, ref l_Param, PublicFunction.FieldTypes.String);
                //l_Query += ", " + l_Param;

                //PublicFunction.FieldToParam(Server, ref l_Param, PublicFunction.FieldTypes.String);
                //l_Query += ", " + l_Param;


                //PublicFunction.FieldToParam(Database, ref l_Param, PublicFunction.FieldTypes.String);
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
    }
}
