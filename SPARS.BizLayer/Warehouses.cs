using SPARS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSS.BizLayer
{
    public class Warehouses : DBEntity, IDBEntity
    {
        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string WarehouseID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Description { get; set; }


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

        public string Phone1 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Phone2 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string FAX { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Email { get; set; }


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

        public string ManagerID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double ManagerCommission { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string WebWareHouse { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string DefaultWebWareHouse { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string BusinessDivisionID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Country { get; set; }

         /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempWarehouseID { get; set; }

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
        public Warehouses()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Warehouses(DBConnector connection)
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private void SetupDBEntity()
        {
            if (string.IsNullOrEmpty(Warehouses.TableName))
            {
                Warehouses.TableName = "Warehouses";
            }

            if (string.IsNullOrEmpty(Warehouses.PrimaryKeyName))
            {
                Warehouses.PrimaryKeyName = "WarehouseID";
            }

            if (string.IsNullOrEmpty(Warehouses.EndingPropertyName))
            {
                Warehouses.EndingPropertyName = "Country";
            }

            if (Warehouses.DBProperties == null)
            {
                Warehouses.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(Warehouses.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, Warehouses.TableName, Warehouses.EndingPropertyName, ref query, Warehouses.DBProperties);

                Warehouses.InsertQueryStart = query;
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
                query = "SELECT * FROM [" + Warehouses.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + Warehouses.TableName + "]";
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
                query = "SELECT * FROM [VW_" + Warehouses.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + Warehouses.TableName + "]";
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


            if (!this.GetList(string.Empty, "MAX(" + Warehouses.PrimaryKeyName + ")", ref data))
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
        public bool GetObject(string WarehouseID)
        {
            this.WarehouseID = WarehouseID;
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Warehouses.TableName, Warehouses.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Warehouses.TableName, PropertyName));
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

            this.PopulateObject(this, data, Warehouses.DBProperties, Warehouses.EndingPropertyName);

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Warehouses.TableName, Warehouses.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Result SaveNew()
        {
            Result l_Result = new Result();
            bool l_Process = false;
            //bool l_Trans = false;
            //string l_Query = String.Empty;
            //string l_Param = String.Empty;
            //DataTable l_Data = new DataTable();
            


            //try
            //{
            //    //this.CompyID = this.GetMax();
            //    l_Query = this.PrepareUpdateQuery(this, ("Temp_" + Items.TableName), ("Temp" + Items.PrimaryKeyName), Items.EndingPropertyName, Items.DBProperties);
            //    l_Trans = this.Connection.BeginTransaction();
            //    l_Process = this.Connection.Execute(l_Query);
            //    if (l_Process)
            //    {
            //        l_Result = this.PreSaveChecks();
            //        if (l_Result.IsSuccess)
            //        {
            //            l_Query = "EXEC sp_Company_Create ";

            //            PublicFunction.FieldToParam(this.TempItemID, ref l_Param, PublicFunction.FieldTypes.Number);
            //            l_Query += " " + l_Param;

            //            PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
            //            l_Query += ", " + l_Param;

            //            this.Connection.GetData(l_Query, ref l_Data);
            //            l_Result.Populate(l_Data);
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //    l_Process = false;
            //    throw;
            //}
            //finally
            //{
            //    l_Data.Dispose();
            //    if ((l_Trans && l_Result.IsSuccess))
            //    {
            //        this.Connection.CommitTransaction();
            //    }
            //    else if (l_Trans)
            //    {
            //        this.Connection.RollbackTransaction();
            //    }

            //}

            return l_Result;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool Modify()
        {
            bool process = false;
            //bool trans = false;
            //string query = string.Empty;

            //try
            //{
            //    query = this.PrepareUpdateQuery(this, Items.TableName, Items.PrimaryKeyName, Items.EndingPropertyName, Items.DBProperties);

            //    trans = this.Connection.BeginTransaction();

            //    process = this.Connection.Execute(query);
            //}
            //catch (Exception)
            //{
            //    process = false;
            //    throw;
            //}
            //finally
            //{
            //    if (trans && process)
            //    {
            //        this.Connection.CommitTransaction();
            //    }
            //    else if (trans)
            //    {
            //        this.Connection.RollbackTransaction();
            //    }
            //}

            return process;
        }


        public Result Delete()
        {
            return this.Delete(this.WarehouseID);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool DeleteAll(string CompyID)
        {
            bool process = false;
            //bool trans = false;
            //string query = string.Empty;

            //try
            //{
            //    query = this.PrepareDeleteAllQuery(Items.TableName, Items.PrimaryKeyName, ItemID);

            //    trans = this.Connection.BeginTransaction();

            //    process = this.Connection.Execute(query);
            //}
            //catch (Exception)
            //{
            //    process = false;
            //    throw;
            //}
            //finally
            //{
            //    if (trans && process)
            //    {
            //        this.Connection.CommitTransaction();
            //    }
            //    else if (trans)
            //    {
            //        this.Connection.RollbackTransaction();
            //    }
            //}

            return process;
        }

        // '' <summary>
        // '' TODO: Update summary.
        // '' </summary>
        public Result Delete(string WarehouseID)
        {

            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();

            //try
            //{
            //    this.WarehouseID = WarehouseID;
            //    l_Trans = this.Connection.BeginTransaction();

            //    l_Query = "EXEC sp_Warehouse_Delete ";
            //    PublicFunction.FieldToParam(this.WarehouseID, ref l_Param, PublicFunction.FieldTypes.Number);
            //    l_Query += " " + l_Param;

            //    PublicFunction.FieldToParam(this.UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
            //    l_Query += ", " + l_Param;

            //    this.Connection.GetData(l_Query, ref l_Data);
            //    l_Result.Populate(l_Data);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    l_Data.Dispose();
            //    if ((l_Trans && l_Result.IsSuccess))
            //    {
            //        this.Connection.CommitTransaction();
            //    }
            //    else if (l_Trans)
            //    {
            //        this.Connection.RollbackTransaction();
            //    }

            //}
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

            //try
            //{
            //    l_Query = "EXEC sp_Company_PreSaveCheck";
            //    PublicFunction.FieldToParam(this.TempItemID, ref l_Param, PublicFunction.FieldTypes.Number);
            //    l_Query += " " + l_Param;

            //    PublicFunction.FieldToParam(this.TempUserNo, ref l_Param, PublicFunction.FieldTypes.Number);
            //    l_Query += ", " + l_Param;

            //    //PublicFunction.FieldToParam(Convert.ToInt32(this.DocumentMode), ref l_Param, PublicFunction.FieldTypes.Number);
            //    //l_Query += ", " + l_Param;

            //    this.Connection.GetData(l_Query, ref l_Data);
            //    l_Result.Populate(l_Data);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    l_Data.Dispose();
            //}

            return l_Result;
        }
    }
}
