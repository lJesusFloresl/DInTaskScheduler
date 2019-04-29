namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// All constants will be writted here!
    /// </summary>
    public static class Constants
    {
        #region Generic

        public const string CONTROLLER_ROUTE = "api/[controller]";
        public const string OK = "Ok";
        public const string ERROR = "Error - {0}";

        #endregion

        #region Validation

        public const string NOT_FOUND = "Not data found";
        public const string DUPLICATE_DATA = "This record is already exists";
        public const string REQUIRED = "This field is required";
        public const string INVALID_DATE = "This field is an invalid date";
        public const string INVALID_VALUE = "This field is not valid";
        public const string EMPTY_CREDENTIALS = "Empty Credentials";
        public const string USER_AUTHENTICATE_ERROR = "Invalid user credentials";
        public const string USER_AUTHENTICATE_INACTIVE = "The user is inactive";
        public const string USER_ALREADY_EXISTS = "The user with email account is already registred";
        public const string USER_NOT_FOUND = "The user doesn't exists";
        public const string CANNOT_DELETE = "The item is already in use, you can't delete it before delete related data";
        //public const string REGISTER_USER_MAIL_SUBJECT = "DIBrave - Registro de Usuario";
        public const string APP_AUTHENTICATE_ERROR = "Invalid application credentials";
        public const string APP_AUTHENTICATE_INACTIVE = "The application is inactive";
        public const string APP_NOT_FOUND = "The application doesn't exists";
        public const string ERROR_REPORT_MAIL_NOT_SENDED = "Mail report cannot send to all destinataries";
        public const string ERROR_REPORT_EMPTY_MAILS = "Email list is empty or invalid";
        public const string SUCCESS_EXECUTE_SERVICE = "Service job executed successfully";
        public const string ERROR_EXECUTE_SERVICE = "Error in service job execution";

        #endregion

        #region Format

        public const string FORMAT_DATE_DDMMYYYY = "dd/MM/yyyy";
        public const string FORMAT_DATETIME_DDMMYYYY_HHMMSS = "dd/MM/yyyy HH:mm:ss";
        public const string FORMAT_COMPLETE_NAME = "{0} {1} {2}";
        public const string FORMAT_MONEY = "${0:#0.00}";
        public const string FORMAT_EXCEPTION = "{0}: {1}";

        #endregion

        #region Templates

        //public const string TEMPLATE_REGISTRY_USER_HTML = "RegistryUser.html";

        #endregion
    }
}
