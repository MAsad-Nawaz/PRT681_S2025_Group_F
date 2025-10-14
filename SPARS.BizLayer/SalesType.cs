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
    public class SalesType : DBEntity, IDBEntity
    {
        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SalesTypeID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Description { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RevenueAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string DiscountAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string COGSAccount { get; set; }


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
        /// TODO: Update summary.
        /// </summary>
        public int TempSalesTypeID { get; set; }

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
        public SalesType()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public SalesType(DBConnector connection)
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private void SetupDBEntity()
        {
            if (string.IsNullOrEmpty(SalesType.TableName))
            {
                SalesType.TableName = "SalesType";
            }

            if (string.IsNullOrEmpty(SalesType.PrimaryKeyName))
            {
                SalesType.PrimaryKeyName = "SalesTypeID";
            }

            if (string.IsNullOrEmpty(SalesType.EndingPropertyName))
            {
                SalesType.EndingPropertyName = "MODUser";
            }

            if (SalesType.DBProperties == null)
            {
                SalesType.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(SalesType.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, SalesType.TableName, SalesType.EndingPropertyName, ref query, SalesType.DBProperties);

                SalesType.InsertQueryStart = query;
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
                query = "SELECT * FROM [" + SalesType.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + SalesType.TableName + "]";
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
                query = "SELECT * FROM [VW_" + SalesType.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + SalesType.TableName + "]";
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

            if (!this.GetList(string.Empty, "MAX(" + SalesType.PrimaryKeyName + ")", ref data))
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
        public bool GetObject(string SalesTypeID)
        {
            this.SalesTypeID = SalesTypeID;
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + SalesType.TableName, SalesType.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + SalesType.TableName, PropertyName));
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

            this.PopulateObject(this, data, SalesType.DBProperties, SalesType.EndingPropertyName);

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + SalesType.TableName, SalesType.PrimaryKeyName));
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
                l_Query = this.PrepareUpdateQuery(this, ("Temp_" + SalesType.TableName), ("Temp" + SalesType.PrimaryKeyName), SalesType.EndingPropertyName, SalesType.DBProperties);
                l_Trans = this.Connection.BeginTransaction();
                l_Process = this.Connection.Execute(l_Query);
                if (l_Process)
                {
                    l_Result = this.PreSaveChecks();
                    if (l_Result.IsSuccess)
                    {
                        l_Query = "EXEC sp_Company_Create ";

                        PublicFunction.FieldToParam(this.TempSalesTypeID, ref l_Param, PublicFunction.FieldTypes.Number);
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
                query = this.PrepareUpdateQuery(this, SalesType.TableName, SalesType.PrimaryKeyName, SalesType.EndingPropertyName, SalesType.DBProperties);

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
            return this.Delete(this.SalesTypeID);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool DeleteAll(string CompyID)
        {
            bool process = false;
            bool trans = false;
            string query = string.Empty;

            try
            {
                query = this.PrepareDeleteAllQuery(SalesType.TableName, SalesType.PrimaryKeyName, SalesTypeID);

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
        public Result Delete(string SalesTypeID)
        {

            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();

            try
            {
                this.SalesTypeID = SalesTypeID;
                l_Trans = this.Connection.BeginTransaction();

                l_Query = "EXEC sp_Company_Delete ";
                PublicFunction.FieldToParam(this.SalesTypeID, ref l_Param, PublicFunction.FieldTypes.Number);
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
                PublicFunction.FieldToParam(this.TempSalesTypeID, ref l_Param, PublicFunction.FieldTypes.Number);
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
