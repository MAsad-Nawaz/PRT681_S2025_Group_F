// -----------------------------------------------------------------------
// <copyright file="CustomerAddresses.cs" company="Visionary Computer Solutions">
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
    public class CustomerAddresses : DBEntity, IDBEntity
    {

        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CustomerID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AddressID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string EDIAddressID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Type { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Department { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string FirstName { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LastName { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Title { get; set; }


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

        public string RDC { get; set; }


        /// <summary>
        /// TODO: Update summary.
        /// </summary>

        /// <summary>
        /// TODO: Update summary.
        /// </summary>


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

        public bool ShipInBoxOnly { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string WebAddress { get; set; }
        public string TempCustomerID { get; set; }
        public int TempUserNo { get; set; }
        public int UserNo { get; set; }

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
        public CustomerAddresses()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public CustomerAddresses(DBConnector connection)
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
            if (string.IsNullOrEmpty(CustomerAddresses.TableName))
            {
                CustomerAddresses.TableName = "CustomerAddresses";
            }

            if (string.IsNullOrEmpty(CustomerAddresses.PrimaryKeyName))
            {
                CustomerAddresses.PrimaryKeyName = "CustomerID";
            }

            if (string.IsNullOrEmpty(CustomerAddresses.EndingPropertyName))
            {
                CustomerAddresses.EndingPropertyName = "WebAddress";
            }

            if (CustomerAddresses.DBProperties == null)
            {
                CustomerAddresses.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(CustomerAddresses.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, CustomerAddresses.TableName, CustomerAddresses.EndingPropertyName, ref query, CustomerAddresses.DBProperties);

                CustomerAddresses.InsertQueryStart = query;
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
                query = "SELECT * FROM [" + CustomerAddresses.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + CustomerAddresses.TableName + "]";
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
                query = "SELECT * FROM [VW_" + CustomerAddresses.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + CustomerAddresses.TableName + "]";
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

            if (!this.GetList(string.Empty, "MAX(" + CustomerAddresses.PrimaryKeyName + ")", ref data))
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
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + CustomerAddresses.TableName, CustomerAddresses.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + CustomerAddresses.TableName, PropertyName));
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

            this.PopulateObject(this, data, CustomerAddresses.DBProperties, CustomerAddresses.EndingPropertyName);

            return true;
        }

        public bool GetObjectFromCriteria(string criteria)
        {
            DataTable data = new DataTable();
            string query = string.Empty;

            query = "SELECT * FROM [" + CustomerAddresses.TableName + "]";

            if (!string.IsNullOrEmpty(criteria))
            {
                query += " WHERE " + criteria;
            }

            if (!this.Connection.GetData(query, ref data))
            {
                return false;
            }

            this.PopulateObject(this, data, CustomerAddresses.DBProperties, CustomerAddresses.EndingPropertyName);

            return true;
        }
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + CustomerAddresses.TableName, CustomerAddresses.PrimaryKeyName));
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
            string l_InsertQuery = string.Empty;

            try
            {
                //this.CustomerID = this.GetMax();
                this.PrepareQueries(this, CustomerAddresses.TableName, CustomerAddresses.EndingPropertyName, ref l_InsertQuery, CustomerAddresses.DBProperties);
                l_Query = this.PrepareInsertQuery(this, l_InsertQuery, CustomerAddresses.EndingPropertyName, CustomerAddresses.DBProperties);
                l_Trans = this.Connection.BeginTransaction();
                l_Process = this.Connection.Execute(l_Query);

                l_Result.IsSuccess = l_Process;
                //    l_Result = this.PreSaveChecks();
                //    if (l_Result.IsSuccess)
                //    {
                //        l_Query = "EXEC sp_CustomerAddresses_Create ";

                //        PublicFunction.FieldToParam(this.TempCustomerID, ref l_Param, PublicFunction.FieldTypes.Number);
                //        l_Query += " " + l_Param;

                //        PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                //        l_Query += ", " + l_Param;

                //        this.Connection.GetData(l_Query, ref l_Data);
                //        l_Result.Populate(l_Data);
                //    }

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
                query = this.PrepareUpdateQuery(this, CustomerAddresses.TableName, CustomerAddresses.PrimaryKeyName, CustomerAddresses.EndingPropertyName, CustomerAddresses.DBProperties);

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
                query = this.PrepareDeleteAllQuery(CustomerAddresses.TableName, CustomerAddresses.PrimaryKeyName, groupNos);

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

                l_Query = "EXEC sp_CustomerAddresses_Delete ";
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
                l_Query = "EXEC sp_CustomerAddresses_PreSaveCheck";
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
    }
}
