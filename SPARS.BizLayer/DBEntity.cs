// -----------------------------------------------------------------------
// <copyright file="DBEntity.cs" company="Visionary Computer Solutions">
// © 2014 Visionary Computer Solutions Pvt. Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace SSS.BizLayer
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Web.Script.Serialization;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DBEntity
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [ScriptIgnore]
        public DBConnector Connection { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [ScriptIgnore]
        public Dictionary<string, string> Relacements { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        [ScriptIgnore]
        public List<string> ExtraFields { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public DBEntity()
        {
            this.Connection = new DBConnector();
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public DBEntity(DBConnector connection)
        {
            this.Connection = connection;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public void PrepareQueries(object instance, string tableName, string endingPropertyName, ref string insertQueryStart, List<PropertyInfo> properties)
        {
            DBEntity entity = (DBEntity)instance;
            string name = string.Empty;

            insertQueryStart = "INSERT INTO [" + tableName + "] (";

            foreach (PropertyInfo property in properties)
            {
                name = this.GetFieldName(property.Name);

                insertQueryStart += "[" + name + "],";

                if (string.Compare(name, endingPropertyName) == 0)
                {
                    break;
                }
            }

            if (entity.ExtraFields != null)
            {
                foreach (string field in entity.ExtraFields)
                {
                    insertQueryStart += "[" + this.GetFieldName(field) + "],";
                }
            }

            insertQueryStart = insertQueryStart.Substring(0, insertQueryStart.Length - 1);
            insertQueryStart += ") VALUES (";
        }

        private string GetFieldName(string name)
        {
            if (this.Relacements == null || !this.Relacements.ContainsKey(name))
            {
                return name;
            }

            return this.Relacements[name];
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public string PrepareInsertQuery(object instance, string insertQueryStart, string endingPropertyName, List<PropertyInfo> properties)
        {
            string query = string.Empty;
            string param = string.Empty;
            DBEntity entity = (DBEntity)instance;

            foreach (PropertyInfo property in properties)
            {
                DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);
                query += param + ",";

                if (string.Compare(property.Name, endingPropertyName) == 0)
                {
                    break;
                }
            }

            if (entity.ExtraFields != null)
            {
                PropertyInfo property;
                Type type = instance.GetType();

                foreach (string field in entity.ExtraFields)
                {
                    property = type.GetProperty(field);

                    if (property != null)
                    {
                        DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);
                        query += param + ",";
                    }
                }
            }

            query = query.Substring(0, query.Length - 1);
            query = insertQueryStart + query + ")";

            return query;
        }

        /// <summary>
        /// Prepares Update Query Using All The Required Parameters.
        /// </summary>
        /// <param name="instance">Instance of the Class for which The Update Query Is Prepared.</param>
        /// <param name="tableName">Name of the Table The Update Query Will Update.</param>
        /// <param name="primaryKey">Primar Key of the Table.</param>
        /// <param name="endingPropertyName">Last Property in the Table</param>
        /// <param name="properties">List of Properties/Columns in the Table. </param>
        /// <returns>Update Query</returns>
        public string PrepareUpdateQuery(object instance, string tableName, string primaryKey, string endingPropertyName, List<PropertyInfo> properties)
        {
            string criteria = string.Empty;
            string query = string.Empty;
            string param = string.Empty;
            string name = string.Empty;
            DBEntity entity = (DBEntity)instance;

            foreach (PropertyInfo property in properties)
            {
                name = this.GetFieldName(property.Name);

                param = string.Empty;
                DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);

                if (string.IsNullOrEmpty(criteria) && name.CompareTo(primaryKey) == 0)
                {
                    criteria = " WHERE [" + primaryKey + "] = " + param;
                }
                else
                {
                    query += "[" + name + "] = " + param + ",";
                }

                if (string.Compare(name, endingPropertyName) == 0)
                {
                    break;
                }
            }

            if (entity.ExtraFields != null)
            {
                PropertyInfo property;
                Type type = instance.GetType();

                foreach (string field in entity.ExtraFields)
                {
                    property = type.GetProperty(field);
                    name = this.GetFieldName(field);

                    DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);

                    if (string.IsNullOrEmpty(criteria) && name.CompareTo(primaryKey) == 0)
                    {
                        criteria = " WHERE [" + primaryKey + "] = " + param;
                    }
                    else
                    {
                        query += "[" + name + "] = " + param + ",";
                    }
                }
            }

            if (string.IsNullOrEmpty(criteria))
            {
                return string.Empty;
            }

            query = query.Substring(0, query.Length - 1);
            query = "UPDATE [" + tableName + "] SET " + query + criteria;

            return query;
        }


        /// <summary>
        /// Prepares Update Query Using All The Required Parameters.
        /// </summary>
        /// <param name="instance">Instance of the Class for which The Update Query Is Prepared.</param>
        /// <param name="tableName">Name of the Table The Update Query Will Update.</param>
        /// <param name="primaryKey">Primar Key of the Table.</param>
        /// <param name="endingPropertyName">Last Property in the Table</param>
        /// <param name="properties">List of Properties/Columns in the Table. </param>
        /// <returns>Update Query</returns>
        public string PrepareUpdateQuery(object instance, string tableName, List<string> primaryKeys, string endingPropertyName, List<PropertyInfo> properties)
        {
            string criteria = string.Empty;
            string query = string.Empty;
            string param = string.Empty;
            string name = string.Empty;
            DBEntity entity = (DBEntity)instance;

            foreach (PropertyInfo property in properties)
            {
                name = this.GetFieldName(property.Name);

                param = string.Empty;
                DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);

                if (primaryKeys.Contains(name))
                {
                    if (string.IsNullOrEmpty(criteria))
                    {
                        criteria = " WHERE [" + name + "] = " + param;
                    }
                    else
                    {
                        criteria += " AND [" + name + "] = " + param;
                    }
                }
                else
                {
                    query += "[" + name + "] = " + param + ",";
                }

                if (string.Compare(name, endingPropertyName) == 0)
                {
                    break;
                }
            }

            if (entity.ExtraFields != null)
            {
                PropertyInfo property;
                Type type = instance.GetType();

                foreach (string field in entity.ExtraFields)
                {
                    property = type.GetProperty(field);
                    name = this.GetFieldName(field);

                    DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);

                    if (primaryKeys.Contains(name))
                    {
                        if (string.IsNullOrEmpty(criteria))
                        {
                            criteria = " WHERE [" + name + "] = " + param;
                        }
                        else
                        {
                            criteria += " AND [" + name + "] = " + param;
                        }
                    }
                    else
                    {
                        query += "[" + name + "] = " + param + ",";
                    }
                }
            }

            if (string.IsNullOrEmpty(criteria))
            {
                return string.Empty;
            }

            query = query.Substring(0, query.Length - 1);
            query = "UPDATE [" + tableName + "] SET " + query + criteria;

            return query;
        }


        /// <summary>
        /// Prepares the Delete Query Using Required Parameters.
        /// </summary>
        /// <param name="instance"> Instance of the Class for which The Update Query Is Prepared. </param>
        /// <param name="tableName"Name of the Table The Update Query Will Update.></param>
        /// <param name="primaryKey">Primar Key of the Table.</param>
        /// <returns>Query to Delete a Recod From DB.</returns>
        public string PrepareDeleteQuery(object instance, string tableName, string primaryKey)
        {
            string criteria = string.Empty;

            criteria = this.PrepareCriteria(instance, primaryKey);
            if (string.IsNullOrEmpty(criteria))
            {
                return string.Empty;
            }

            return "DELETE FROM [" + tableName + "]" + criteria;
        }


        /// <summary>
        /// Prepares the Delete Query Using Required Parameters.
        /// </summary>
        /// <param name="instance"> Instance of the Class for which The Update Query Is Prepared. </param>
        /// <param name="tableName"Name of the Table The Update Query Will Update.></param>
        /// <param name="primaryKey">Primar Key of the Table.</param>
        /// <returns>Query to Delete a Recod From DB.</returns>
        public string PrepareDeleteQuery(object instance, string tableName, List<string> primaryKeys)
        {
            string criteria = string.Empty;

            criteria = this.PrepareCriteria(instance, primaryKeys);
            if (string.IsNullOrEmpty(criteria))
            {
                return string.Empty;
            }

            return "DELETE FROM [" + tableName + "]" + criteria;
        }


        /// <summary>
        /// Prepares the Delete Query Using Required Parameters to Delete .
        /// </summary>
        /// <param name="instance"> Instance of the Class for which The Update Query Is Prepared. </param>
        /// <param name="tableName"Name of the Table The Update Query Will Update.></param>
        /// <param name="primaryKey">Primar Key of the Table.</param>
        /// <returns>Query to Delete a Recod From DB.</returns>
        public string PrepareDeleteAllQuery(string tableName, string primaryKey, string value)
        {
            string criteria = string.Empty;

            criteria = " WHERE [" + primaryKey + "] IN (" + value + ")";

            return "DELETE FROM [" + tableName + "]" + criteria;
        }

        /// <summary>
        /// Prepares Query to Get All the data of a certain Column
        /// </summary>
        /// <param name="instance"> Instance of the Class for which The Update Query Is Prepared. </param>
        /// <param name="tableName"Name of the Table The Update Query Will Update.></param>
        /// <param name="primaryKey">Primar Key of the Table.</param>
        /// <returns>Query to Get the Obejct</returns>
        public string PrepareGetObjectQuery(object instance, string tableName, string primaryKey)
        {
            string criteria = string.Empty;

            criteria = this.PrepareCriteria(instance, primaryKey);
            if (string.IsNullOrEmpty(criteria))
            {
                return string.Empty;
            }

            return "SELECT * FROM [" + tableName + "]" + criteria;
        }

        /// <summary>
        /// Prepares Query to Get All the data of a certain Column
        /// </summary>
        /// <param name="instance"> Instance of the Class for which The Update Query Is Prepared. </param>
        /// <param name="tableName"Name of the Table The Update Query Will Update.></param>
        /// <param name="primaryKey">Primar Key of the Table.</param>
        /// <returns>Query to Get the Obejct</returns>
        public string PrepareGetObjectQuery(object instance, string tableName, List<string> primaryKeys)
        {
            string criteria = string.Empty;

            criteria = this.PrepareCriteria(instance, primaryKeys);
            if (string.IsNullOrEmpty(criteria))
            {
                return string.Empty;
            }

            return "SELECT * FROM [" + tableName + "]" + criteria;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public void PopulateObject(object instance, DataTable data, List<PropertyInfo> properties, string endingPropertyName)
        {
            DataRow row = null;
            string name = string.Empty;

            if (data.Rows.Count < 1)
            {
                return;
            }

            row = data.Rows[0];

            PopulateObjectFromRow(instance, data, properties, endingPropertyName, row);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public void PopulateObjectFromRow(object instance, DataTable data, List<PropertyInfo> properties, string endingPropertyName, DataRow row)
        {
            string name = string.Empty;

            try
            {
            foreach (PropertyInfo property in properties)
            {
                name = this.GetFieldName(property.Name);

                if (string.Compare(name, endingPropertyName) == 0)
                {
                    if (data.Columns.Contains(name))
                    {
                        PopulateProperty(instance, name, property, row);
                    }

                    break;
                }

                if (data.Columns.Contains(name))
                {
                    PopulateProperty(instance, name, property, row);
                }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PopulateProperty(object instance, string name, PropertyInfo property, DataRow row)
        {
            PublicFunction.FieldTypes type = GetFieldType(property);

            switch (type)
            {
                case PublicFunction.FieldTypes.Boolean:
                    property.SetValue(instance, DBConnector.ConvertNullAsBoolean(row[name], false), null);
                    break;
                case PublicFunction.FieldTypes.Date:
                case PublicFunction.FieldTypes.NullableDate:
                    property.SetValue(instance, DBConnector.ConvertNullAsDateTime(row[name], DateTime.MinValue), null);
                    break;
                case PublicFunction.FieldTypes.String:
                case PublicFunction.FieldTypes.NullableString:
                    property.SetValue(instance, DBConnector.ConvertNullAsString(row[name], string.Empty), null);
                    break;
                case PublicFunction.FieldTypes.Number:
                case PublicFunction.FieldTypes.NullableNumber:
                    property.SetValue(instance, DBConnector.ConvertNullAsInteger(row[name], 0), null);
                    break;
                case PublicFunction.FieldTypes.NumberDouble:
                case PublicFunction.FieldTypes.NullableDouble:
                    property.SetValue(instance, DBConnector.ConvertNullAsDouble(row[name], 0), null);
                    break;
                default:
                    property.SetValue(instance, DBConnector.ConvertNullAsFloat(row[name], 0), null);
                    break;
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private PublicFunction.FieldTypes GetFieldType(PropertyInfo property)
        {
            if (property.PropertyType == Type.GetType("System.String"))
            {
                return PublicFunction.FieldTypes.String;
            }
            else if (property.PropertyType.IsGenericType)
            {
                Type[] types = property.PropertyType.GetGenericArguments();

                if (types.Length == 0)
                {
                    return PublicFunction.FieldTypes.Number;
                }

                if (types[0] == Type.GetType("System.String"))
                {
                    if (property.PropertyType == Type.GetType("System.Nullable"))
                    {
                        return PublicFunction.FieldTypes.NullableString;
                    }

                    return PublicFunction.FieldTypes.String;
                }
                else if (types[0] == Type.GetType("System.DateTime"))
                {
                    if (property.PropertyType == Type.GetType("System.Nullable"))
                    {
                        return PublicFunction.FieldTypes.NullableDate;
                    }

                    return PublicFunction.FieldTypes.Date;
                }
                else if (types[0] == Type.GetType("System.Boolean"))
                {
                    return PublicFunction.FieldTypes.Boolean;
                }
                else if (types[0] == Type.GetType("System.Double"))
                {
                    return PublicFunction.FieldTypes.NumberFloat;
                }
                else if (types[0] == Type.GetType("System.Int32") ||
                        types[0] == Type.GetType("System.Int16") ||
                        types[0] == Type.GetType("System.Int64") ||
                        types[0] == Type.GetType("System.UInt16") ||
                        types[0] == Type.GetType("System.UInt32") ||
                        types[0] == Type.GetType("System.UInt64"))
                {
                    if (property.PropertyType == Type.GetType("System.Nullable"))
                    {
                        return PublicFunction.FieldTypes.NullableNumber;
                    }

                    return PublicFunction.FieldTypes.Number;
                }

                if (property.PropertyType == Type.GetType("System.Nullable"))
                {
                    return PublicFunction.FieldTypes.NullableFloat;
                }

                return PublicFunction.FieldTypes.NumberFloat;
            }
            else if (property.PropertyType == Type.GetType("System.DateTime"))
            {
                return PublicFunction.FieldTypes.Date;
            }
            else if (property.PropertyType == Type.GetType("System.Boolean"))
            {
                return PublicFunction.FieldTypes.Boolean;
            }
            else if (property.PropertyType == Type.GetType("System.Double"))
            {
                return PublicFunction.FieldTypes.NumberFloat;
            }                
            else if (property.PropertyType == Type.GetType("System.Int32") ||
                    property.PropertyType == Type.GetType("System.Int16") ||
                    property.PropertyType == Type.GetType("System.Int64") ||
                    property.PropertyType == Type.GetType("System.UInt16") ||
                    property.PropertyType == Type.GetType("System.UInt32") ||
                    property.PropertyType == Type.GetType("System.UInt64"))
            {
                return PublicFunction.FieldTypes.Number;
            }

            return PublicFunction.FieldTypes.NumberFloat;
        }

        /// <summary>
        /// Prepares the Criteria for Any CRUD Operation
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="primaryKey"></param>
        private string PrepareCriteria(object instance, string primaryKey)
        {
            string criteria = string.Empty;
            string param = string.Empty;
            PropertyInfo property = instance.GetType().GetProperty(primaryKey);

            DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);
            criteria = " WHERE [" + primaryKey + "] = " + param;

            return criteria;
        }

        private string PrepareCriteria(object instance, List<string> primaryKeys)
        {
            string criteria = string.Empty;
            string param = string.Empty;
            PropertyInfo property = null;
            dynamic instanceType = instance.GetType();

            foreach (string key in primaryKeys)
            {
                property = instanceType.GetProperty(key);
                DBConnector.FieldToParam(property.GetValue(instance, null), this.GetFieldType(property), ref param);

                if (string.IsNullOrEmpty(criteria))
                {
                    criteria = " WHERE [" + key + "] = " + param;
                }
                else
                {
                    criteria += " AND [" + key + "] = " + param;
                }
            }

            return criteria;
        }
    }
}
