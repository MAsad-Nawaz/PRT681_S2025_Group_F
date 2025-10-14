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
    public class Companys : DBEntity, IDBEntity
    {

        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CompID { get; set; }


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

        public string Zip { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Country { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Phone { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Fax { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UPCCode { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string TaxID1 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string TaxID2 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string TaxID3 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime SysDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int FYPeriods { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int ADDUser { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime ADDdate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PeriodID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? MODuser { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string CurrFYear { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? MODdate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RugPicturePath { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string OAKPicturePath { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PictureExtention { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RNo { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempKeyNo { get; set; }

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
        public Companys()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Companys(DBConnector connection)
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private void SetupDBEntity()
        {
            if (string.IsNullOrEmpty(Companys.TableName))
            {
                Companys.TableName = "Company";
            }

            if (string.IsNullOrEmpty(Companys.PrimaryKeyName))
            {
                Companys.PrimaryKeyName = "CompID";
            }

            if (string.IsNullOrEmpty(Companys.EndingPropertyName))
            {
                Companys.EndingPropertyName = "RNo";
            }

            if (Companys.DBProperties == null)
            {
                Companys.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(Companys.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, Companys.TableName, Companys.EndingPropertyName, ref query, Companys.DBProperties);

                Companys.InsertQueryStart = query;
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
                query = "SELECT * FROM [" + Companys.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + Companys.TableName + "]";
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
                query = "SELECT * FROM [VW_" + Companys.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + Companys.TableName + "]";
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

            if (!this.GetList(string.Empty, "MAX(" + Companys.PrimaryKeyName + ")", ref data))
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
        public bool GetObject(string CompyID)
        {
            this.CompID = CompID;
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Companys.TableName, Companys.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Companys.TableName, PropertyName));
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

            this.PopulateObject(this, data, Companys.DBProperties, Companys.EndingPropertyName);

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Companys.TableName, Companys.PrimaryKeyName));
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
                l_Query = this.PrepareUpdateQuery(this, ("Temp_" + Companys.TableName), ("Temp" + Companys.PrimaryKeyName), Companys.EndingPropertyName, Companys.DBProperties);
                l_Trans = this.Connection.BeginTransaction();
                l_Process = this.Connection.Execute(l_Query);
                if (l_Process)
                {
                    l_Result = this.PreSaveChecks();
                    if (l_Result.IsSuccess)
                    {
                        l_Query = "EXEC sp_Company_Create ";

                        PublicFunction.FieldToParam(this.TempKeyNo, ref l_Param, PublicFunction.FieldTypes.Number);
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
                query = this.PrepareUpdateQuery(this, Companys.TableName, Companys.PrimaryKeyName, Companys.EndingPropertyName, Companys.DBProperties);

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
            return this.Delete(this.CompID);
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
                query = this.PrepareDeleteAllQuery(Companys.TableName, Companys.PrimaryKeyName, CompID);

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
        public Result Delete(string CompyID)
        {

            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();

            try
            {
                this.CompID = CompyID;
                l_Trans = this.Connection.BeginTransaction();

                l_Query = "EXEC sp_Company_Delete ";
                PublicFunction.FieldToParam(this.CompID, ref l_Param, PublicFunction.FieldTypes.Number);
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
                PublicFunction.FieldToParam(this.TempKeyNo, ref l_Param, PublicFunction.FieldTypes.Number);
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
