using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace SSS.BizLayer
{
    public static class GlobalDeclarations
    {
        public static string g_APIVersion = "1.0.0.1";

        //-------------------------------------------------

        public static string g_UserID;

        public static int g_UserNo;

        public static bool g_WriteQueries = true;

        public static string g_ConnectionString;

        public static string g_SPARSConnectionString;

        public static string g_EDILOGConnectionString;

        public static readonly object _object = new object();

        public static string g_LoginTime;

        public static string g_ApplicationPath;

        public static string g_ApplicationLogPath;

        public static string g_UserIDCookie = "SPARSWEB";

        public static double g_UserTokenExpireTime;

        public static int g_UserTokenRenewTime;

        public static string  g_SiteURL;

        public static string g_SecurityKey;

        public static Dictionary<string, LoginInfo> AccessTokens = new Dictionary<string, LoginInfo> ();

        public static Dictionary<string, string> AccessTokensData = new Dictionary<string, string>();

        public static string g_ServerName;

        public static string g_DataBaseName;

        public static string g_Password;

        public static string g_UserCount;

        public static string g_ApplicationID = "SMA";

        public static string g_UploadPath;

        public static string g_AllowedLogin;

        public enum UserGroups 
        {
            Super = 0,
            Admin = 1,
            User = 2,
            PowerUser = 3
        }

        public enum ResponseType
        {
            
            Success = 100,

            Warning = 200,

            Exception = 900,

            Error = 400
        }

        public enum ErrorCodes 
        {

            [Description("Failed To Login")]
            Loginfailed = 400,

            [Description("Invalid Pulling Batch")]
            InvalidPullingBatch = 401,

            [Description("Batch Already Picked")]
            BatchAlreadyPicked = 403,

            [Description("Data is not updated")]
            DataNotUpdated = 404,

            [Description("Item cannot be found in warehouse")]
            ItemNotFoundInWarehouse = 406,

            [Description("Wrong Item picked, requried another item")]
            WrongItemPicked = 408,

            [Description("Item ID of Picking Ticket Line is already picked")]
            ItemAlreadyPicked = 409,

            [Description("Item is OAK, provide a valid Stock ID")]
            ItemIdOAK = 410,

            [Description("Wrong Stock ID picked, required another Stock Item")]
            WrongStockIdPicked = 411,

            [Description("Stock ID is not Available to Pick, it is reserved")]
            StockIdNotAvailable = 412,

            [Description("Item Never Picked")]
            ItemNeverPicked = 413,

            [Description("Stock ID Not Available")]
            SKUNotAvailable = 414,

            [Description("Invalid Stock")]
            InvalidStock = 417,

            [Description("Item of Picking Ticket is in Shipping. So you cannot un-pick this Item.")]
            ItemShippingCannotUnpick = 439,

            [Description("Item does not belong to this PickingTicket")]
            ItemDoesNotBelong = 440,

            [Description("Picking Ticket is either processed or voided.")]
            PKTProcessed = 443,

            [Description("Invalid Picking Location")]
            InvalidPickingLocation = 444,

            [Description("Data Not Found")]
            DataNotFound = 445,
    }

    public enum SuccessCodes 
    {
        [Description("Operation Completed Successfully")]
        OperationCompleted = 100,

        [Description("Login Verified Successfully")]
        LoginVerified = 101,        
    }

    public enum ExceptionCodes
    {
        [Description("Unexpected Exception Occured")]
        ExceptionOccured = 900,

    }

    public enum WarningCodes
    {
        [Description("Warning")]
        DataNotFound = 200,
    }

    public enum NotificationTypes
    {

        RealTimeNotification = 0,

        Email = 1,

        SMS = 2,
    }
    public enum ImportErrorLevels
    {

        IsSuccess = 1,

        IsWarning = 2,

        IsError = 3,
    }
    public enum Clients
    {
        C2_Momeni = 1,
        C4_Loloi = 3
    }
    }
}