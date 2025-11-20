// -----------------------------------------------------------------------
// <copyright file="DBConnector.vb" company="Visionary Computer Solutions">
// © 2014 Visionary Computer Solutions Pvt. Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SSS.BizLayer
{
/// <summary>
/// TODO: Update summary.
/// </summary>
    public class DBConnector
    {
        private byte[] RoleCookie;

        private int m_ConnectionTries = 1;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public string ConnectionString
        {
            get { return m_ConnectionString; }
            set { m_ConnectionString = value; }
        }

        private string m_ConnectionString;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static string NullValue
        {
            get { return m_NullValue; }
            set { m_NullValue = value; }
        }

        private static string m_NullValue;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private SqlTransaction Transaction
        {
            get { return m_Transaction; }
            set { m_Transaction = value; }
        }

        private SqlTransaction m_Transaction;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private SqlConnection Connection
        {
            get { return m_Connection; }
            set { m_Connection = value; }
        }

        private SqlConnection m_Connection;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private SqlDataAdapter DataAdapter
        {
            get { return m_DataAdapter; }
            set { m_DataAdapter = value; }
        }

        private SqlDataAdapter m_DataAdapter;

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private SqlCommand Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }

        private SqlCommand m_Command;
        public int CommandTimeout { get; set; }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private bool IsConnected
        {
            get { return (this.Connection.State != ConnectionState.Closed && this.Connection.State != ConnectionState.Broken) ? true : false; }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public DBConnector()
        {
            this.ConnectionString = GlobalDeclarations.g_ConnectionString;

            this.Connection = new SqlConnection(this.ConnectionString);
            this.Command = new SqlCommand();
            this.DataAdapter = new SqlDataAdapter();

            this.CommandTimeout = 30;
            this.Command.CommandTimeout = this.CommandTimeout;

            if (string.IsNullOrEmpty(DBConnector.NullValue))
            {
                DBConnector.NullValue = "NULL";
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public DBConnector(string p_ConnectionString)
        {
            this.ConnectionString = p_ConnectionString;

            this.Connection = new SqlConnection(this.ConnectionString);
            this.Command = new SqlCommand();
            this.DataAdapter = new SqlDataAdapter();

            if (string.IsNullOrEmpty(DBConnector.NullValue))
            {
                DBConnector.NullValue = "NULL";
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private bool OpenConnection(bool p_IsSetRole = true)
        {
            string l_Param = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(this.ConnectionString))
                {
                    throw new Exception("Invalid DBConnector String.");
                }

                if (this.IsConnected)
                {
                    this.Connection.Close();
                }

                this.Connection = new SqlConnection(this.ConnectionString);
                this.Connection.Open();

                this.m_ConnectionTries = 1;

                return true;
            }
            catch (Exception ex)
            {
                if (this.m_ConnectionTries == 100)
                {
                    ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                    return false;
                }

                this.m_ConnectionTries += 1;
                this.OpenConnection(p_IsSetRole);
            }

            return false;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private bool CloseConnection()
        {
            try
            {
                m_ConnectionTries = 1;

                this.Connection.Close();

                return true;
                //TODO: Implement Log
            }
            catch (Exception)
            {
            }

            return false;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetData(string query, ref DataTable data, int p_Timeout = 0)
        {
            DateTime l_Start;
            DateTime l_Stop;
            TimeSpan l_Span;
            try
            {
                SqlCommand l_Command = new SqlCommand();

                if (this.Transaction == null)
                {
                    this.OpenConnection();
                }

                l_Start = DateTime.Now;
                l_Command.Transaction = this.Transaction;
                l_Command.Parameters.Clear();
                l_Command.CommandText = query;
                l_Command.Connection = this.Connection;

                this.DataAdapter.SelectCommand = l_Command;

                if (p_Timeout > 0)
                {
                    l_Command.CommandTimeout = p_Timeout;
                }

                data.Rows.Clear();
                data.Columns.Clear();
                this.DataAdapter.Fill(data);

                l_Stop = DateTime.Now;
                l_Span = l_Stop - l_Start;

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog(query, l_Span.Milliseconds.ToString());
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();
                }

                if (data.Rows.Count <= 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("Exception: " + query);
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();

                    //TODO: Implement Log
                }

                throw;
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetDataSP(string query, ref Hashtable p_Parameters, ref DataTable data, int p_Timeout = 0)
        {
            try
            {
                DateTime l_Start;
                DateTime l_Stop;
                TimeSpan l_Span;
                SqlParameter l_Param = null;
                SqlCommand l_Command = new SqlCommand();

                if (this.Transaction == null)
                {
                    this.OpenConnection();
                }

                l_Start = DateTime.Now;
                l_Command.CommandType = CommandType.StoredProcedure;
                l_Command.CommandText = query;
                l_Command.Connection = this.Connection;
                l_Command.Transaction = this.Transaction;

                if (p_Timeout > 0)
                {
                    l_Command.CommandTimeout = p_Timeout;
                }

                if ((p_Parameters != null))
                {
                    foreach (string l_Key in p_Parameters.Keys)
                    {
                        l_Param = (SqlParameter)p_Parameters[l_Key];
                        l_Command.Parameters.Add(l_Param);
                    }
                }

                this.DataAdapter.SelectCommand = l_Command;

                data.Rows.Clear();
                data.Columns.Clear();
                this.DataAdapter.Fill(data);

                l_Stop = DateTime.Now;
                l_Span = l_Stop - l_Start;

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog(query, l_Span.Milliseconds.ToString());
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();
                }

                if (data.Rows.Count <= 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("Exception: " + query);
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();

                    //TODO: Implement Log
                }

                throw;
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool GetDataSP(string query, ref DataSet data, int p_Timeout = 0)
        {
            DateTime l_Start;
            DateTime l_Stop;
            TimeSpan l_Span;

            try
            {
                SqlCommand l_Command = new SqlCommand();

                if (this.Transaction == null)
                {
                    this.OpenConnection();
                }

                l_Start = DateTime.Now;
                l_Command.Transaction = this.Transaction;
                l_Command.CommandText = query;
                l_Command.Connection = this.Connection;
                l_Command.Transaction = this.Transaction;

                if (p_Timeout > 0)
                {
                    l_Command.CommandTimeout = p_Timeout;
                }

                l_Command.Parameters.Clear();
                this.DataAdapter.SelectCommand = l_Command;

                data.Tables.Clear();
                this.DataAdapter.Fill(data);

                l_Stop = DateTime.Now;
                l_Span = l_Stop - l_Start;

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog(query, l_Span.Milliseconds.ToString());
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();
                }

                if (data.Tables.Count <= 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("Exception: " + query);
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();

                    //TODO: Implement Log
                }

                throw;
            }
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool Execute(string query, int p_Timeout = -1)
        {
            bool process = false;
            DateTime l_Start;
            DateTime l_Stop;
            TimeSpan l_Span;

            try
            {
                l_Start = DateTime.Now;
                SqlCommand l_Command = new SqlCommand();

                if (this.Transaction == null)
                {
                    this.OpenConnection();
                }

                l_Command.Transaction = this.Transaction;
                l_Command.CommandText = query;
                l_Command.CommandType = System.Data.CommandType.Text;
                l_Command.Connection = this.Connection;
                l_Command.CommandTimeout = this.CommandTimeout;

                if (p_Timeout > 0)
                {
                    l_Command.CommandTimeout = p_Timeout;
                }

                if (l_Command.ExecuteNonQuery() > 0)
                {
                    process = true;
                }

                l_Stop = DateTime.Now;
                l_Span = l_Stop - l_Start;

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog(query, l_Span.Milliseconds.ToString());
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();
                }
            }
            catch
            {
                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("Exception: " + query);
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();

                    //TODO: Implement Log
                }

                throw;
            }

            return process;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public object ExecuteScalar(string query, int p_Timeout = -1)
        {
            object functionReturnValue = null;
            DateTime l_Start;
            DateTime l_Stop;
            TimeSpan l_Span;

            try
            {
                SqlCommand l_Command = new SqlCommand();

                if (this.Transaction == null)
                {
                    this.OpenConnection();
                }

                l_Start = DateTime.Now;
                l_Command.Transaction = this.Transaction;
                l_Command.CommandText = query;
                l_Command.CommandType = System.Data.CommandType.Text;
                l_Command.Connection = this.Connection;
                l_Command.CommandTimeout = this.CommandTimeout;

                l_Stop = DateTime.Now;
                l_Span = l_Stop - l_Start;

                if (p_Timeout > 0)
                {
                    l_Command.CommandTimeout = p_Timeout;
                }

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog(query, l_Span.Milliseconds.ToString());
                }

                functionReturnValue = l_Command.ExecuteScalar();

                if (this.Transaction == null)
                {
                    this.CloseConnection();
                }
            }
            catch
            {
                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("Exception: " + query);
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();

                    //TODO: Implement Log
                }

                throw;
            }

            return functionReturnValue;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool ExecuteSP(string query, ref Hashtable p_Parameters, int p_FalseReturnValue = -1, object p_ReturnKey = null)
        {
            bool process = false;
            DateTime l_Start;
            DateTime l_Stop;
            TimeSpan l_Span;

            try
            {
                SqlParameter l_Param = null;
                SqlCommand l_Command = new SqlCommand();

                if (this.Transaction == null)
                {
                    this.OpenConnection();
                }

                l_Start = DateTime.Now;
                l_Command.Transaction = this.Transaction;
                l_Command.CommandText = query;
                l_Command.CommandType = System.Data.CommandType.StoredProcedure;
                l_Command.Connection = this.Connection;

                l_Command.Parameters.Clear();

                if ((p_Parameters != null))
                {
                    foreach (string l_Key in p_Parameters.Keys)
                    {
                        l_Param = (SqlParameter)p_Parameters[l_Key];
                        l_Command.Parameters.Add(l_Param);
                    }
                }

                if (p_ReturnKey == null)
                {
                    if (l_Command.ExecuteNonQuery() > 0)
                    {
                        process = true;
                    }
                }
                else
                {
                    if (l_Command.ExecuteNonQuery() > 0 || p_FalseReturnValue != (int)((SqlParameter)p_Parameters[p_ReturnKey]).Value)
                    {
                        process = true;
                    }
                }

                l_Stop = DateTime.Now;
                l_Span = l_Stop - l_Start;

                if (this.Transaction == null)
                {
                    this.CloseConnection();
                }

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog(query, l_Span.Milliseconds.ToString());
                }
            }
            catch
            {
                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("Exception: " + query);
                }

                if (this.Transaction == null)
                {
                    this.CloseConnection();

                    //TODO: Implement Log
                }

                throw;
            }

            return process;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool BeginTransaction()
        {
            bool process = false;

            try
            {
                process = false;

                if (this.Transaction != null)
                {
                    return process;
                }

                this.OpenConnection();

                this.Transaction = this.Connection.BeginTransaction();
                this.Command.Transaction = this.Transaction;

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("/****************************************Begin Transaction********************************/");
                }

                process = true;
                //TODO: Implement Log
            }
            catch (Exception)
            {
            }

            return process;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool CommitTransaction()
        {
            try
            {
                if (this.Transaction == null)
                {
                    throw new Exception("No Transaction is alive.");
                }

                this.Transaction.Commit();
                this.CloseConnection();

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("/****************************************Commit Transaction********************************/");
                }

                this.Transaction = null;
                this.Command.Transaction = this.Transaction;
                //TODO: Implement Log
            }
            catch (Exception)
            {
            }

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public bool RollbackTransaction()
        {
            try
            {
                if (this.Transaction == null)
                {
                    throw new Exception("No Transaction is alive.");
                }

                this.Transaction.Rollback();
                this.CloseConnection();

                if (GlobalDeclarations.g_WriteQueries)
                {
                    QueryLogger.WriteToQueryLog("/****************************************Rollback Transaction********************************/");
                }

                this.Transaction = null;
                this.Command.Transaction = this.Transaction;
                //TODO: Implement Log
            }
            catch (Exception)
            {
            }

            return true;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static bool FieldToParam(object value, PublicFunction.FieldTypes type, ref string param)
        {
            bool process = false;

            try
            {
                string sV = null;

                process = false;

                if (value == null)
                {
                    param = DBConnector.NullValue;
                    return true;
                }

                switch (type)
                {
                    case PublicFunction.FieldTypes.Boolean:
                        param = Convert.ToInt32(value).ToString();

                        if (string.Compare(param, "-1") == 0)
                        {
                            param = "1";
                        }

                        process = true;
                        break;
                    case PublicFunction.FieldTypes.Date:
                    case PublicFunction.FieldTypes.NullableDate:
                        sV = value.ToString().Trim();

                        if (sV == "12:00:00 AM")
                        {
                            if (type == PublicFunction.FieldTypes.NullableDate)
                            {
                                param = DBConnector.NullValue;
                            }
                            else
                            {
                                param = "'" + Convert.ToString(value) + "'";
                            }
                        }
                        else
                        {
                            param = "'" + Convert.ToString(value) + "'";
                        }

                        process = true;
                        break;
                    case PublicFunction.FieldTypes.Number:
                    case PublicFunction.FieldTypes.NullableNumber:
                        if (Convert.ToInt32(value) == 0)
                        {
                            if (type == PublicFunction.FieldTypes.NullableNumber)
                            {
                                param = DBConnector.NullValue;
                            }
                            else
                            {
                                param = Convert.ToString(value);
                            }
                        }
                        else
                        {
                            param = Convert.ToString(value);
                        }

                        process = true;
                        break;
                    case PublicFunction.FieldTypes.String:
                    case PublicFunction.FieldTypes.NullableString:
                        sV = value.ToString().Trim();

                        if (string.IsNullOrEmpty(sV))
                        {
                            if (type == PublicFunction.FieldTypes.NullableString)
                            {
                                param = DBConnector.NullValue;
                            }
                            else
                            {
                                sV = sV.Replace("[", "");
                                sV = sV.Replace("]", "");
                                param = "'" + DBConnector.DoQuotes(sV) + "'";
                            }
                        }
                        else
                        {
                            sV = sV.Replace("[", "");
                            sV = sV.Replace("]", "");
                            param = "'" + DBConnector.DoQuotes(sV) + "'";
                        }
                        process = true;
                        break;
                    case PublicFunction.FieldTypes.NumberFloat:
                    case PublicFunction.FieldTypes.NullableFloat:
                        if (Convert.ToDecimal(value) == 0)
                        {
                            if (type == PublicFunction.FieldTypes.NullableFloat)
                            {
                                param = DBConnector.NullValue;
                            }
                            else
                            {
                                param = Convert.ToString(value);
                            }
                        }
                        else
                        {
                            param = Convert.ToString(value);
                        }
                        process = true;
                        break;
                }
            }
            catch (Exception)
            {
                //TODO: Implement Log
            }

            return process;
        }

        public static string DoQuotes(string value)
        {
            return value.Replace("'", "''");
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static bool ConvertNullAsBoolean(object value, bool defaultValue)
        {
            if (value == System.DBNull.Value)
            {
                return defaultValue;
            }

            return (bool)value;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static string ConvertNullAsString(object value, string defaultValue)
        {
            if (value == System.DBNull.Value)
            {
                return defaultValue;
            }

            return (string)value;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static int ConvertNullAsInteger(object value, int defaultValue)
        {
            if (value == System.DBNull.Value)
            {
                return defaultValue;
            }

            return Convert.ToInt32(value);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static float ConvertNullAsFloat(object value, float defaultValue)
        {
            if (value == System.DBNull.Value)
            {
                return defaultValue;
            }

            if (Convert.ToInt32(value) == 0)
            {
                value = 0.0;
            }

            return Convert.ToSingle(value);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static double ConvertNullAsDouble(object value, double defaultValue)
        {
            if (value == System.DBNull.Value)
            {
                return defaultValue;
            }

            return Convert.ToDouble(value);
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static DateTime ConvertNullAsDateTime(object value, DateTime defaultValue)
        {
            if (value == System.DBNull.Value)
            {
                return defaultValue;
            }

            return (DateTime)value;
        }
    }
}