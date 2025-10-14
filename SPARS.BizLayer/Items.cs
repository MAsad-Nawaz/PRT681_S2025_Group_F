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
    public class Items : DBEntity, IDBEntity
    {
        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ItemID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RugID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Description { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string AlternateItemID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ItemType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Owner { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ExpenseAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RevenueAccount { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool Discontinued { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string DefaultVendor { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Country { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UPC { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string BarCode { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Category { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Collection { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Design { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? Color { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Size { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double? Weight { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double Area { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double Volume { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string Location { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LocationType { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal StdCost { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal LastCost { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal AvgCost { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OnHandQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OnCPurchaseQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OnSOrderQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OnPickQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int ShippedQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OnConsQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OnBorderQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int OnPorderQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int InTransitQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? ArivalDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int ReorderLevel { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int MinOrderQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int LeadTime { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int PTD_SoldQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int PTD_BorderQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int YTD_SoldQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int YTD_BorderQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int YTD_ConsQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal PTD_Sales { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal PTD_Returns { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal YTD_Sales { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal YTD_Returns { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal YTD_Orders { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public decimal YTD_Receipts { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastOrderDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int LastOrderQty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LastVendor { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastSaleDate { get; set; }


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

        public byte[] Picture { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string PictureName { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? WEBRug { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? DiscontinuedDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string UPC5Digit { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public bool? Remove_HangTag { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? AvgMoVol { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double? Height { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double? Width { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public double? Length { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string RollRunner { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? LastImgUpdatedUserNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? LastImgUpdatedDate { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ShapeID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? BackingNO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? ConstructionNO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? FiberNO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? StyleforFilter { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? MaterialforFilter { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? SizeforFilter { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? PrimaryColor1 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? PrimaryColor2 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? SecondaryColor1 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? SecondaryColor2 { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? ProductCare { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string LCode { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string SETItem { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ProductDescription { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? ConstructionForFilterNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public string ItemStatus { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? RugsIndicatorNO { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? ETA_Qty { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public DateTime? ETA_Date { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? BrandNo { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? PackageTypeID { get; set; }


        /// <summary>
        ///   TODO: Update summary.
        /// </summary>

        public int? OpenPackingCount { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public int TempItemID { get; set; }

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
        public Items()
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public Items(DBConnector connection)
        {
            this.SetupDBEntity();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private void SetupDBEntity()
        {
            if (string.IsNullOrEmpty(Items.TableName))
            {
                Items.TableName = "Items";
            }

            if (string.IsNullOrEmpty(Items.PrimaryKeyName))
            {
                Items.PrimaryKeyName = "ItemID";
            }

            if (string.IsNullOrEmpty(Items.EndingPropertyName))
            {
                Items.EndingPropertyName = "OpenPackingCount";
            }

            if (Items.DBProperties == null)
            {
                Items.DBProperties = new List<PropertyInfo>(this.GetType().GetProperties());
            }

            if (string.IsNullOrEmpty(Items.InsertQueryStart))
            {

                string query = string.Empty;

                this.PrepareQueries(this, Items.TableName, Items.EndingPropertyName, ref query, Items.DBProperties);

                Items.InsertQueryStart = query;
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
                query = "SELECT * FROM [" + Items.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [" + Items.TableName + "]";
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
                query = "SELECT * FROM [VW_" + Items.TableName + "]";
            }
            else
            {
                query = "SELECT " + fields + " FROM [VW_" + Items.TableName + "]";
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


            if (!this.GetList(string.Empty, "MAX(" + Items.PrimaryKeyName + ")", ref data))
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
        public bool GetObject(string ItemID)
        {
            this.ItemID = ItemID;
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Items.TableName, Items.PrimaryKeyName));
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject(string PropertyName, string PropertyValue)
        {
            PropertyInfo property = this.GetType().GetProperty(PropertyName);

            property.SetValue(this, PropertyValue, null);
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Items.TableName, PropertyName));
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

            this.PopulateObject(this, data, Items.DBProperties, Items.EndingPropertyName);

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetObject()
        {
            return this.GetObjectFromQuery(this.PrepareGetObjectQuery(this, "VW_" + Items.TableName, Items.PrimaryKeyName));
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
            return this.Delete(this.ItemID);
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
        public Result Delete(string ItemID)
        {

            bool l_Trans = false;
            string l_Query = String.Empty;
            string l_Param = String.Empty;
            DataTable l_Data = new DataTable();
            Result l_Result = new Result();

            //try
            //{
            //    this.ItemID = ItemID;
            //    l_Trans = this.Connection.BeginTransaction();

            //    l_Query = "EXEC sp_Company_Delete ";
            //    PublicFunction.FieldToParam(this.ItemID, ref l_Param, PublicFunction.FieldTypes.Number);
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
