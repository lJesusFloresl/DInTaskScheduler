namespace DInTaskScheduler.Tools
{
    public static class Constants
    {
        #region Http

        public const string HTTP_HEADER_CONTENT_TYPE = "content-type";
        public const string HTTP_HEADER_ACCEPT = "accept";
        public const string HTTP_HEADER_AUTHORIZATION = "Authorization";
        public const string HTTP_MEDIA_TYPE = "application/json";
        public const string HTTP_ERROR_API = "Error API - Response: {0}";
        public const string HTTP_BEARER_TOKEN = "Bearer {0}";

        #endregion

        #region Api Routes

        public const string API_ROUTE_APP_LOGIN = "AppAuth/Login";
        public const string API_ROUTE_REPORTING_DAILYSUMMARY = "Reporting/DailySummary";

        #endregion

        #region Format

        public const string FORMAT_LOG_OUTPUT = "[INFO {0:dd/MM/yyyy HH:mm:ss}] - {1}";
        public const string FORMAT_DATE_JSON_YYYYMMDD = "yyyy-MM-dd";
        public const string FORMAT_DATE_DDMMYYYY_HHMMSS = "dd/MM/yyyy HH:mm:ss";

        #endregion

        #region Messages

        public const string ERROR_API_UNAVAILABLE = "Cannot connect with DiBrave API, operation canceled";
        public const string ERROR_MAX_RETRY = "Maximum retries reached, operation canceled";

        #endregion
    }
}
