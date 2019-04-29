namespace DInTaskSchedulerApi.Application.Configurations
{
    /// <summary>
    /// Contains Swagger settings for the API
    /// </summary>
    public static class SwaggerConfig
    {
        public const string ApiVersion = "v1";
        public const string ContactName = "DIBrave Partners";
        public const string DocInfoTitle = "DIBrave Task Scheduler API";
        public const string DocInfoDescription = "DIBrave API REST Task Scheduler Services";
        public const string JsonVersion = "v1";
        public const string JwtAuthentication = "Bearer";
        public const string JwtDescrption = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"";
        public const string JwtName = "Authorization";
        public const string JwtIn = "header";
        public const string JwtType = "apiKey";

        /// <summary>
        /// Get swagger endpoint
        /// </summary>
        /// <returns>Url</returns>
        public static string GetEndpointUrl()
        {
            return "/swagger/" + ApiVersion + "/swagger.json";
        }
    }
}
