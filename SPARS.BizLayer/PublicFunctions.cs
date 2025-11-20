using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

namespace SSS.BizLayer
{

    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Security.Cryptography;
    using System.Net;
    using System.Reflection;
    using System.ComponentModel;
    using System.Runtime.InteropServices.WindowsRuntime;

    public static class PublicFunction
    {
        public static bool g_Session = true;
        const int icDATE = 1;
        const int icBOOLEAN = 2;
        const int icFOREIGN_KEY = 3;
        const int icNUMBER = 4;
        const int icSTRING = 5;
        const int icNON_EMPTY_STRING = 6;
        const int icNULLABLE_STRING = 7;
        const int icNULLABLE_number = 8;

        const int icNULLABLE_date = 9;
        const string  scCS = ", ";
        const string scSQ = "'";

        const string scNULL = "NULL";

        public enum FieldTypes
        {
	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        Number,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        NullableNumber,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        NumberFloat,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        NullableFloat,

            /// <summary>
            /// TODO: Update summary.
            /// </summary>
            NumberDouble,

            /// <summary>
            /// TODO: Update summary.
            /// </summary>
            NullableDouble,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        String,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        NullableString,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        Date,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        NullableDate,

	        /// <summary>
	        /// TODO: Update summary.
	        /// </summary>
	        Boolean
        }

        public enum CTRL_TYPE
        {
	        scDATA_GRID,
	        scDATA_READER,
	        scDATA_REPEATER
        }

        public enum COL_TYPE
        {
	        icDATE,
	        icBOOLEAN,
	        icFOREIGN_KEY,
	        icNUMBER,
	        icSTRING,
	        icNON_EMPTY_STRING,
	        icNULLABLE_STRING,
	        icNULLABLE_NUMBER,
	        icNULLABLE_date
        }

        public static string DoQuotes(string sData)
        {
            int iLast;
            string sPart = string.Empty;
            if ((sData.Length == 0))
            {
                return string.Empty;
            }

            
            iLast = (sData.IndexOf(scSQ) + 1);
            while (iLast > 0)
            {
                sPart = (sPart
                            + (sData.Substring(0, (iLast - 1))
                            + (scSQ + scSQ)));
                sData = sData.Substring(iLast, (sData.Length - iLast));
                iLast = (sData.IndexOf(scSQ) + 1);
            }

            sData = sPart + sData;
            return sData.Trim();
        }
        //public static string DoQuotes(string sData)
        //{
        //    string functionReturnValue = string.Empty;
        //    int iLast = 0;
        //    string sPart = string.Empty;

        //    functionReturnValue = string.Empty;

        //    if (sData.Length == 0)
        //        return functionReturnValue;
        //    iLast = sData.IndexOf(scSQ);
        //    while (iLast > 0) {
        //        sPart = sPart + sData.Substring(0, iLast - 1) + scSQ + scSQ;
        //        sData = sData.Substring(iLast, sData.Length - iLast);
        //        iLast = sData.IndexOf(scSQ);
        //    }
        //    sData = sPart + sData;
        //    functionReturnValue = sData.Trim();
        //    return functionReturnValue;
        //}

        public static object ConvertNull(object Data, object DefaultValue)
        {
	        object functionReturnValue = null;
	        if (DBNull.Value.Equals(Data) == true) {
		        functionReturnValue = DefaultValue;
	        } else {
		        functionReturnValue = Data;
	        }
	        return functionReturnValue;
        }

        public static string SPARSEncrypt(string strInput)
        {
            string functionReturnValue = null;
            functionReturnValue = string.Empty;

            try
            {
                char[] strKey = {'v'};
                int iCount = 0;
                int lngPtr = 0;
                char[] strInputArray = strInput.ToArray<char>();

                for (iCount = 0; iCount < strInput.Length; iCount++)
                {
                    if (strInputArray[iCount] != strKey[lngPtr])
                    {
                        strInputArray[iCount] = Convert.ToChar(((int)strInputArray[iCount]) ^ ((int)strKey[lngPtr ]));
                        //lngPtr = ((lngPtr + 1) % strKey.Length);
                    }
                }
                //functionReturnValue = ASCIIEncoding.ASCII.GetString(ASCIIEncoding.ASCII.GetBytes(strInputArray));
                functionReturnValue = new string(strInputArray);
                return functionReturnValue;
            }
            catch
            {
            }
            return functionReturnValue;
        }

        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        public static bool FieldToParam(object value, ref string param, FieldTypes type)
        {
	        bool process = false;

	        try {
		        string sV = null;

		        process = false;

		        if (value == null) {
                    param = scNULL;
			        return true;
		        }

		        switch (type) {
			        case FieldTypes.Boolean:
				        param = Convert.ToInt32(value).ToString();

				        if (string.Compare(param, "-1") == 0) {
					        param = "1";
				        }

				        process = true;
				        break; // TODO: might not be correct. Was : Exit Select

			        case FieldTypes.Date:
			        case FieldTypes.NullableDate:
				        sV = value.ToString().Trim();

				        if (sV == "12:00:00 AM") 
                        {
					        if (type == FieldTypes.NullableDate) 
                            {
                                param = scNULL;
					        } 
                            else 
                            {
						        param = "'" + Convert.ToString(value) + "'";
					        }
				        }
                        else if (sV == "01/01/0001 12:00:00 AM" || sV == "1/1/0001 12:00:00 AM")
                        {
                            if (type == FieldTypes.NullableDate)
                            {
                                param = scNULL;
                            }
                            else
                            {
                                param = "'" + Convert.ToString(value) + "'";
                            }
                        }
                        else if (sV == "")
                        {
                            if (type == FieldTypes.NullableDate)
                            {
                                param = scNULL;
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
				        break; // TODO: might not be correct. Was : Exit Select

			        case FieldTypes.Number:
			        case FieldTypes.NullableNumber:
				        if (Convert.ToInt32(value) == 0) {
					        if (type == FieldTypes.NullableNumber) {
                                param = scNULL;
					        } else {
						        param = Convert.ToString(value);
					        }
				        } else {
					        param = Convert.ToString(value);
				        }

				        process = true;
				        break; // TODO: might not be correct. Was : Exit Select

			        case FieldTypes.String:
			        case FieldTypes.NullableString:
				        sV = value.ToString().Trim();

				        if (string.IsNullOrEmpty(sV)) 
                        {
					        if (type == FieldTypes.NullableString) 
                            {
                                param = scNULL;
					        } 
                            else 
                            {
						        sV = sV.Replace("[", string.Empty);
						        sV = sV.Replace("]", string.Empty);
						        param = "'" + DoQuotes(sV) + "'";
					        }
				        } 
                        else 
                        {
					        sV = sV.Replace("[", string.Empty);
					        sV = sV.Replace("]", string.Empty);
					        param = "'" + DoQuotes(sV) + "'";
				        }
				        process = true;
				        break; // TODO: might not be correct. Was : Exit Select

			        case FieldTypes.NumberFloat:
			        case FieldTypes.NullableFloat:
				        if (Convert.ToDecimal(value) == 0) {
					        if (type == FieldTypes.NullableFloat) {
                                param = scNULL;
					        } else {
						        param = Convert.ToString(value);
					        }
				        } else {
					        param = Convert.ToString(value);
				        }

				        process = true;
				        break; // TODO: might not be correct. Was : Exit Select

		        }
	        } 
            catch (Exception generatedExceptionName) 
            {
                throw generatedExceptionName;
		        //TODO: Implement Log
	        }

	        return process;
        }
        
        /// <summary>
        /// Get value of the tag name from ini file.
        /// </summary>
        /// <param name="p_TagName">INI tag name .</param>
        /// <returns>It returns the string value</returns>
        public static string ReadINI(string p_TagName)
        {
            string l_FunctionReutrnValue = string.Empty;
            XmlDocument l_Xml = new XmlDocument();

            try
            {
                l_Xml.Load(GlobalDeclarations.g_ApplicationLogPath + ".config");

                foreach (XmlNode l_Node in l_Xml.DocumentElement["appSettings"].ChildNodes)
                {
                    if (l_Node.Attributes["key"].Value == p_TagName)
                    {
                        l_FunctionReutrnValue = l_Node.Attributes["value"].Value;                     
                    }
                }           
            }
            catch (XmlException ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return l_FunctionReutrnValue;
        }

        public static bool WriteConf(string p_Key, string p_Value)
        {
            bool l_FunctionReutrnValue = false;
            XmlNode l_Node = null;
            XmlDocument l_Xml = new XmlDocument();

            try
            {
                l_Xml.Load(GlobalDeclarations.g_ApplicationLogPath  + ".config");

                foreach (XmlNode l_Nde in l_Xml.DocumentElement["appSettings"].ChildNodes)
                {
                    if (l_Nde.Attributes["key"].Value == p_Key)
                    {
                        l_Node = l_Nde;
                    }
                }

                if (l_Node == null)
                {
                    return l_FunctionReutrnValue;
                }

                l_Node.Attributes["value"].Value = p_Value;
                l_Xml.Save(GlobalDeclarations.g_ApplicationPath + ".config");

                l_FunctionReutrnValue = true;
            }
            catch (XmlException ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            finally
            {

                l_Node = null;
            }
            return l_FunctionReutrnValue;
        }

        public static string GetMessageDescription(int Code)
        {
            return String.Empty;
            //switch (Code)
            //{
            //    case (int) GlobalDeclarations.ErrorCodes.NoSession:
            //        return "Session not found or Session timeout. Please login again";                   
            //    case (int)GlobalDeclarations.ErrorCodes.NotAuthorize:
            //        return "You are not authorized to perform this action. Please login again";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.NoSearchData:
            //        return "No search data available for the document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.ViewDocument:
            //        return "Unable to view the document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.NoReportData:
            //        return "No report info available.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.VoidDocument:
            //        return "Unable to void the document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.NoRecord:
            //        return "No record found.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.OperationFailed:
            //        return "Operation failed.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.AddDetail:
            //        return "Unable to add the detail.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.EditDetail:
            //        return "Unable to edit the detail.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.SaveDocument:
            //        return "Unable to save the document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.ModifyDocument:
            //        return "Unable to modify the document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.DuplicateDocument:
            //        return "Document value already exist.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.CancelDocument:
            //        return "Unable to cancel the document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.CloseDocument:
            //        return "Unable to close the document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.InvalidSKU:
            //        return "SKU is invalid.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.CreateDocument:
            //        return "Unable to open new/create document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.EditDocument:
            //        return "Unable to open edit document.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.ImportDocument:
            //        return "Unable to import document(s).";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.GenericError:
            //        return "Operation failed.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.DeleteDocument:
            //        return "Delete document failed, Please try again.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.CancelDocumentLine:
            //        return "Document line cancellation failed.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.OperationCompleted:
            //        return "Operation completed successfully.";
                    
            //    //case (int)GlobalDeclarations.SuccessCodes.LoadDocument:
            //    //    return "Loaded document list successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.SearchDocument:
            //        return "Searched document list successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.ViewDocument:
            //        return "View document successful.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.VoidDocument:
            //        return "Document voided successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.ReceiveCompleteDocument:
            //        return "Document received successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.AddDetail:
            //        return "The detail line added successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.EditDetail:
            //        return "The detail line edited successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.SaveDocument:
            //        return "The document is saved successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.DeleteDocument:
            //        return "The document is Deleted successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.ModifyDocument:
            //        return "The document is modified successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.CloseDocument:
            //        return "The document has been closed successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.CreateDocument:
            //        return "Create document is loaded successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.EditDocument:
            //        return "Edit document is loaded successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.ImportDocument:
            //        return "Documents(s) imported successfully";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.ValidDocument:
            //        return "Valid documents";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.GenericSuccess:
            //        return "Operation completed successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.FileUpload:
            //        return "File has been uploaded successfully.";
                    
            //    case (int)GlobalDeclarations.SuccessCodes.ValidAPIKey:
            //        return "API key authorized successfully.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.ExceptionOccured:
            //        return "Operation failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.LoadDocument:
            //        return "Loading documents failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.SearchDocument:
            //        return "Searching documents failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.ViewDocument:
            //        return "Viewing document failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.ReportData:
            //        return "Report Viewing failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.VoidDocument:
            //        return "Voiding document failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.AddDetail:
            //        return "Adding detail failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.EditDetail:
            //        return "Editing detail failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.SaveDocument:
            //        return "Saving document failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.ModifyDocument:
            //        return "Modifying document failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.DeleteDocumentAssociation:
            //        return "This document has some association in Database! It can\'t be Deleted";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.CloseDocument:
            //        return "Cancelling document failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.GenericException:
            //        return "Operation failed, please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.FileUpload:
            //        return "File Upload failed, Please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.APIKeyValidation:
            //        return "Unable to authorize API Key.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.PreSaveError:
            //        return "Operation failed, data is not valid.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.FileUpload:
            //        return "File not found. Please select a file again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.CreateDocument:
            //        return "Creating document failed, Please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.ImportDocument:
            //        return "Failed to import document(s).";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.EditDocument:
            //        return "Editing document failed, Please try again.";
                    
            //    case (int)GlobalDeclarations.ExceptionCodes.DeleteDocument:
            //        return "Delete document failed, Please try again.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.CheckPriceCategory:
            //        return "Price Category cannot be blocked because it is assigned to a Customer.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.DeleteCustomerAddress:
            //        return "This Address have some references to other documents and can not be deleted.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.CheckDefaultAddress:
            //        return "Default Address cannot be deleted.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.DuplicateCarrierCode:
            //        return "SCACCodeNo already exists.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.DesignIDLength:
            //        return "Design ID is required and should have 5 characters.";
                    
            //    case (int)GlobalDeclarations.ErrorCodes.InvalidAPIKey:
            //        return "Invalid API Key.";
            //    case (int)GlobalDeclarations.ErrorCodes.NotAuthorizeAPI:
            //        return "You are not authorized to perform this action.";
            //    case (int)GlobalDeclarations.ErrorCodes.Loginfailed:
            //        return "Login failed please try again.";
            //    default:
            //        return String.Empty;
                    
            //}
        }

 

        public static bool SetupConnectionString(LoginInfo p_LoginInfo)
        {
            //MultiItem l_DSNItem;
            //string[] l_Parts = Regex.Split(GlobalDeclarations.g_ConnectionString, ";");
            //string l_strConnect = String.Empty;
            //string l_strDSN = String.Empty;
            //object l_ConnSessionObj = new object();
            //string[] l_ConnectionStringParts;
            //bool l_Process = false;

            //p_LoginInfo.ConnectionString = GlobalDeclarations.g_ConnectionString;
            //p_LoginInfo.EDILOGConnectionString = GlobalDeclarations.g_EDILOGConnectionString;
            //l_ConnectionStringParts = Regex.Split(p_LoginInfo.ConnectionString, ";");
            //p_LoginInfo.RemoteUserDSN = ConfigurationManager.AppSettings["DSNName"];
            //p_LoginInfo.RemoteSQLServerUID = l_ConnectionStringParts[2].Split("=")[1];
            //p_LoginInfo.RemoteSQLServerPsswd = l_ConnectionStringParts[3].Split("=")[1];
            //p_LoginInfo.RemoteSQLServerDS = l_ConnectionStringParts[0].Split("=")[1];
            //p_LoginInfo.RemoteSQLServerDB = l_ConnectionStringParts[1].Split("=")[1];

            //l_Process = true;
            //return l_Process;

            //if ((l_Parts.Count < 3))
            //{
            //    // TODO: Exit Function: Warning!!! Need to return the value
            //    return;
            //}

            //if (!p_LoginInfo.SPARSConnectionString.Contains("DSN="))
            //{
            //    p_LoginInfo.ConnectionString = p_LoginInfo.SPARSConnectionString;
            //    return true;

            //}

            //l_DSNItem = DSN.GetDSNInfo(l_Parts[0].Split("=")[1]);
            //if ((l_DSNItem == null))
            //{
            //    l_strDSN = ConfigurationManager.AppSettings("ConnectionStringNet");
            //    l_Parts = ConfigurationManager.AppSettings("ConnectionStringNetDSN").Split(";");
            //    builder = new SqlConnectionStringBuilder(l_strDSN);
            //    p_LoginInfo.RemoteUserDSN = l_Parts[0].Split("=")[1];
            //    p_LoginInfo.RemoteSQLServerUID = builder.UserID;
            //    p_LoginInfo.RemoteSQLServerPsswd = builder.Password;
            //    p_LoginInfo.RemoteSQLServerDS = builder.DataSource;
            //    p_LoginInfo.RemoteSQLServerDB = ((builder.AttachDBFilename == String.Empty) ? builder.InitialCatalog : builder.AttachDBFilename);
            //}
            //else
            //{
            //    l_strDSN = ("Server="
            //                + (l_DSNItem.ID + (";Database="
            //                + (l_DSNItem.Value + ";"))));
            //    p_LoginInfo.RemoteUserDSN = l_Parts[0].Split("=")[1];
            //    p_LoginInfo.RemoteSQLServerUID = GetConnectionPart(l_Parts, "UID");
            //    p_LoginInfo.RemoteSQLServerPsswd = GetConnectionPart(l_Parts, "PWD");
            //    p_LoginInfo.RemoteSQLServerDS = l_DSNItem.ID;
            //    p_LoginInfo.RemoteSQLServerDB = l_DSNItem.Value;
            //    if (((l_Parts.Count == 3)
            //                || ((l_Parts.Count == 4)
            //                && string.IsNullOrEmpty(l_Parts[3]))))
            //    {
            //        l_strConnect = (l_Parts[1] + (";" + l_Parts[2]));
            //    }
            //    else if ((l_Parts.Count == 4))
            //    {
            //        l_strConnect = (l_Parts[2] + (";" + l_Parts[3]));
            //    }

            //}

            //p_LoginInfo.ConnectionString = (l_strDSN + l_strConnect);
            return true;
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();

            try
            {
                DateTime dt = DateTime.Parse(strDate);

                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }     

        public static int SDERequestLog(string p_Message)
        {
            DataTable l_Data = new DataTable();
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            int l_RequestID = 0;
            DBConnector l_Connection = new DBConnector(GlobalDeclarations.g_ConnectionString);
            try
            {
                l_SQL = "EXEC  Sp_SDE_RequestLog ";
                PublicFunction.FieldToParam(p_Message, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(GlobalDeclarations.g_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_SQL = l_SQL + l_Param;
                l_Connection.GetData(l_SQL, ref l_Data);
                if (l_Data.Rows.Count <= 0)
                {
                    return 0;
                }
                l_RequestID = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["RequestID"], string.Empty).ToString());
                l_Data.Dispose();
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return l_RequestID;
        }
        public static int SDEResponsLog(string p_Message, int p_RequestID)
        {
            DataTable l_Data = new DataTable();
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            int l_ResponseID = 0;
            DBConnector l_Connection = new DBConnector(GlobalDeclarations.g_ConnectionString);
            try
            {
                l_SQL = "EXEC  Sp_SDE_ResponsLog ";
                PublicFunction.FieldToParam(p_Message, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(p_RequestID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(GlobalDeclarations.g_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_SQL = l_SQL + l_Param;
                l_Connection.GetData(l_SQL, ref l_Data);
                if (l_Data.Rows.Count <= 0)
                {
                    return 0;
                }
                l_ResponseID = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseID"], string.Empty).ToString());
                l_Data.Dispose();


            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return l_ResponseID;
        }
        public static bool SetupConfiguration(ref UserSetup p_UserSetup)
        {
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            DataTable l_dt = new DataTable();
            string l_DocNo = string.Empty;
            string l_UserID = string.Empty;
            bool l_Process = false;
            string l_ServerName = string.Empty;
            string l_DataBaseName = string.Empty;
            string l_User = string.Empty;
            string l_Password = string.Empty;
            int l_UserCount = 0;
            string l_SQLUserID = string.Empty;
            string l_SQLPassword = string.Empty;

            DBConnector l_Connection = new DBConnector(GlobalDeclarations.g_ConnectionString);

            l_ServerName = GlobalDeclarations.g_ServerName;
            l_DataBaseName = GlobalDeclarations.g_DataBaseName;
            l_User = GlobalDeclarations.g_UserID;
            l_Password = GlobalDeclarations.g_Password;
            l_UserCount = Convert.ToInt32 (GlobalDeclarations.g_UserCount);

            for (int l_Index = 1; l_Index <= l_UserCount; l_Index++)
            {
                l_DocNo = l_User + l_Index;

                l_SQL = "SELECT * FROM LockedDocuments";

                PublicFunction.FieldToParam(l_DocNo,ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL += " WHERE TableName='Users' AND KeyColumn='UserID' AND DocNo=" + l_Param;

                if (!l_Connection.GetData(l_SQL, ref l_dt)) 
                {
                    l_UserID = l_DocNo;
                    break;
                }
            }

            if (l_UserID == string.Empty)
                return l_Process;

            p_UserSetup.ConnectionString = GlobalDeclarations.g_ConnectionString;

            l_dt.Dispose();

            l_SQL = "SELECT UserNo FROM Users";

            PublicFunction.FieldToParam(l_UserID, ref l_Param, PublicFunction.FieldTypes.String);
            l_SQL += " WHERE UserID=" + l_Param;

            if (!l_Connection.GetData(l_SQL, ref l_dt))
            {
                return l_Process;
            }

            p_UserSetup.UserNo = Convert.ToInt32(PublicFunction.ConvertNull(l_dt.Rows[0]["UserNo"], 0));

            l_SQL = "INSERT INTO LockedDocuments VALUES(";

            PublicFunction.FieldToParam(p_UserSetup.UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
            l_SQL += l_Param;

            PublicFunction.FieldToParam("Users", ref l_Param, PublicFunction.FieldTypes.String);
            l_SQL += "," + l_Param;

            PublicFunction.FieldToParam("UserID", ref l_Param, PublicFunction.FieldTypes.String);
            l_SQL += "," + l_Param;

            PublicFunction.FieldToParam(l_UserID, ref l_Param, PublicFunction.FieldTypes.String);
            l_SQL += "," + l_Param + ")";

            l_Connection.Execute(l_SQL);

            p_UserSetup.Connection = new DBConnector(p_UserSetup.ConnectionString);

            p_UserSetup.UserID = l_UserID;
            l_Process = true;

            return l_Process;
        }

        public static string Encrypt(string toEncrypt, bool useHashing = true)
        {
            byte[] keyArray = null;
           
            byte[] resultArray = null;

            try
            {
                if (string.IsNullOrEmpty(toEncrypt))
                {
                    return string.Empty;
                }

                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                string key = "Magnum Opus";
                TripleDESCryptoServiceProvider tdes;
                ICryptoTransform cTransform;

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                cTransform = tdes.CreateEncryptor();
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }


            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public static string Decrypt(string cipherString, bool useHashing = true)
        {
            byte[] keyArray;
            byte[] resultArray = null;

            try
            {
                if (string.IsNullOrEmpty(cipherString))
                {
                    return string.Empty;
                }

                byte[] toEncryptArray = Convert.FromBase64String(cipherString);
                string key = "Magnum Opus";
                TripleDESCryptoServiceProvider tdes;
                ICryptoTransform cTransform;


                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                {
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                }
                    

                tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                cTransform = tdes.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
            }

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string GetUserIP()
        {
            string VisitorsIPAddr = String.Empty;

            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else if ((HttpContext.Current.Request.UserHostAddress.Length != 0))
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }

            if (VisitorsIPAddr == "::1")
            {
                VisitorsIPAddr = "127.0.0.1";
            }


            return VisitorsIPAddr;
        }

        public static string GetLocalIP()
        {
            string VisitorsIPAddr = String.Empty;
            string host = Dns.GetHostName();
            string LocalHostaddress = Dns.GetHostByName(host).AddressList[0].ToString();
            if ((LocalHostaddress != String.Empty))
            {
                VisitorsIPAddr = LocalHostaddress;
            }

            if (VisitorsIPAddr == "::1")
            {
                VisitorsIPAddr = "127.0.0.1";
            }


            return VisitorsIPAddr;
        }

        /// <summary>
        /// Get Description of Enum
        /// </summary>
        public static string GetEnumDescription(Enum p_Enum)
        {
            try
            {
                FieldInfo l_FieldInfo = p_Enum.GetType().GetField(p_Enum.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])l_FieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                else
                {
                    return p_Enum.ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Saves Request Data to Database
        /// </summary>
        public static int SMARequestLog(string p_Message, string p_MethodName, string p_IPAddress,int p_UserNo)
        {
            DataTable l_Data = new DataTable();
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            int l_RequestID = 0;
            DBConnector l_Connection = new DBConnector(GlobalDeclarations.g_ConnectionString);
            try
            {
                l_SQL = "EXEC  SSS_MA_RequestLog ";
                PublicFunction.FieldToParam(p_Message, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(p_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(p_IPAddress, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(p_MethodName, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param;
                l_Connection.GetData(l_SQL, ref l_Data);
                if (l_Data.Rows.Count <= 0)
                {
                    return 0;
                }
                l_RequestID = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["RequestID"], string.Empty).ToString());
                l_Data.Dispose();
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            return l_RequestID;
        }

        /// <summary>
        /// Saves Response Data to Database
        /// </summary>
        public static int SMAResponseLog(string p_Message, int p_RequestID, string p_MethodName, string p_IPAddress)
        {
            DataTable l_Data = new DataTable();
            string l_SQL = string.Empty;
            string l_Param = string.Empty;
            int l_ResponseID = 0;
            DBConnector l_Connection = new DBConnector(GlobalDeclarations.g_ConnectionString);
            try
            {
                l_SQL = "EXEC  SSS_MA_ResponseLog ";
                PublicFunction.FieldToParam(p_Message, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(p_RequestID, ref l_Param, PublicFunction.FieldTypes.Number);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(GlobalDeclarations.g_UserNo, ref l_Param, PublicFunction.FieldTypes.Number);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(p_IPAddress, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param + ",";
                PublicFunction.FieldToParam(p_MethodName, ref l_Param, PublicFunction.FieldTypes.String);
                l_SQL = l_SQL + l_Param;
                l_Connection.GetData(l_SQL, ref l_Data);
                if (l_Data.Rows.Count <= 0)
                {
                    return 0;
                }
                l_ResponseID = Convert.ToInt32(PublicFunction.ConvertNull(l_Data.Rows[0]["ResponseID"], string.Empty).ToString());
                l_Data.Dispose();


            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace);
                throw;
            }
            return l_ResponseID;
        }

        public static string ConvertFileToBase64(string fileName) 
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        /// <summary>
        /// Get bytes for provided file stream
        /// </summary>
        /// <remarks>CR:001</remarks>
        /// <param name="inputstm"></param>
        /// <returns></returns>
        public static Byte[] GetFileContent(Stream inputstm)
        {
            Stream fs = inputstm;
            BinaryReader br = new BinaryReader(fs);
            Int32 lnt = Convert.ToInt32(fs.Length);

            byte[] bytes = br.ReadBytes(lnt);

            #region "Clear IO resources"

            br.Close();
            br.Dispose();
            fs.Close();
            fs.Dispose();

            #endregion

            return bytes;
        }

        public static string CreateFileToServerPath(string path)
        {
            System.DateTime l_ServerDate = DateTime.Now;
            string l_FolderPath = l_ServerDate.Month + "-" + l_ServerDate.Day + "-" + l_ServerDate.Year + "-" + GlobalDeclarations.g_UserID;
            string l_Path = Path.Combine(path, l_FolderPath);
            return l_Path;
        }

        public static void WriteFileToServer(string path,string fileName, byte[] bytes)
        {
            //System.DateTime l_ServerDate = DateTime.Now;
            //string l_FolderPath = l_ServerDate.Month + "-" + l_ServerDate.Day + "-" + l_ServerDate.Year + "-" + GlobalDeclarations.g_UserID;
            string l_Path = path;
            string l_FileName = fileName;

            if (!Directory.Exists(l_Path))
            {
                System.IO.Directory.CreateDirectory(l_Path);
            }

            File.WriteAllBytes(Path.Combine(l_Path, l_FileName), bytes);
        }
    }
   
}
