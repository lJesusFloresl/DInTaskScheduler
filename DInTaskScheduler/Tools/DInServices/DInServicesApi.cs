using DInTaskScheduler.Domain.ViewModels;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DInTaskScheduler.Tools.DInServices
{
    /// <summary>
    /// Class connect with DIn Services Api
    /// </summary>
    public class DInServicesApi
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrlBase;
        private ApplicationTokenViewModel tokenModel;
        private AppAuthViewModel credentials;
        private int tryCounter = 0;

        public DInServicesApi(ApplicationTokenViewModel tokenModel = null)
        {
            this.apiUrlBase = Utils.GetAppSetting("DInApiUrl");
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(this.apiUrlBase);
            this.credentials = new AppAuthViewModel()
            {
                ApiKey = Utils.GetAppSetting("ApiKey"),
                SecretKey = Utils.GetAppSetting("SecretKey"),
                UseHeadQuarter = false,
            };

            if (tokenModel != null)
                this.tokenModel = tokenModel;
            else
                this.tokenModel = new ApplicationTokenViewModel();
        }

        /// <summary>
        /// Get current token
        /// </summary>
        /// <returns>Token</returns>
        public ApplicationTokenViewModel GetCurrentToken()
        {
            CheckToken();
            return tokenModel;
        }

        /// <summary>
        /// Get token for api usage
        /// </summary>
        /// <returns>Token</returns>
        public async Task<ApplicationTokenViewModel> LoginApplication()
        {
            this.httpClient.SetHeaders(tokenModel.Token, true);
            var content = JsonConvert.SerializeObject(this.credentials);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue(Constants.HTTP_MEDIA_TYPE);
            try
            {
                var response = httpClient.PostAsync(Constants.API_ROUTE_APP_LOGIN, byteContent).GetAwaiter().GetResult();
                Stream stream = await response.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                tokenModel = JsonConvert.DeserializeObject<ApplicationTokenViewModel>(json);
            }
            catch
            {
                tokenModel = new ApplicationTokenViewModel();
            }
            return tokenModel;
        }

        /// <summary>
        /// Generate daily summary report
        /// </summary>
        /// <param name="model">Data for report generation</param>
        /// <returns>ServerResponse with execution data</returns>
        public async Task<ServerResponse> GenerateDailySummaryReport(DailySummaryReportFilterViewModel model)
        {
            ServerResponse result;

            try
            {
                CheckToken();
                this.httpClient.SetHeaders(tokenModel.Token);
                var content = JsonConvert.SerializeObject(model);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(Constants.HTTP_MEDIA_TYPE);
                var response = httpClient.PostAsync(Constants.API_ROUTE_REPORTING_DAILYSUMMARY, byteContent).GetAwaiter().GetResult();
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    this.tokenModel = null;
                    this.tokenModel = GetCurrentToken();
                    if (tryCounter < 3)
                    {
                        tryCounter++;
                        return await GenerateDailySummaryReport(model);
                    }
                    else
                    {
                        tryCounter = 0;
                        result = UtilsApi.ErrorResponse(Constants.ERROR_MAX_RETRY);
                    }
                }
                else
                {
                    tryCounter = 0;
                    result = await UtilsApi.GetServerResponse(response);
                }
            }
            catch
            {
                result = UtilsApi.ErrorResponse(Constants.ERROR_API_UNAVAILABLE);
            }

            return result;
        }

        /// <summary>
        /// Execute any endpoint from API
        /// </summary>
        /// <param name="model">Endpoint execution data</param>
        /// <returns>ServerResponse from endpoint</returns>
        public async Task<ServerResponse> ExecuteEndpointTask(EndpointTaskViewModel model)
        {
            ServerResponse result;

            try
            {
                CheckToken();
                this.httpClient.SetHeaders(tokenModel.Token);
                var content = model.Body;
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(Constants.HTTP_MEDIA_TYPE);
                HttpResponseMessage response = null;

                switch (model.HttpMethod)
                {
                    case Enums.HttpMethods.GET:
                        response = httpClient.GetAsync(model.EndpointSufix).GetAwaiter().GetResult();
                        break;
                    case Enums.HttpMethods.POST:
                        response = httpClient.PostAsync(model.EndpointSufix, byteContent).GetAwaiter().GetResult();
                        break;
                    case Enums.HttpMethods.PUT:
                        response = httpClient.PutAsync(model.EndpointSufix, byteContent).GetAwaiter().GetResult();
                        break;
                    case Enums.HttpMethods.DELETE:
                        response = httpClient.DeleteAsync(model.EndpointSufix).GetAwaiter().GetResult();
                        break;
                    case Enums.HttpMethods.OPTIONS:
                    default:
                        break;
                };

                if (response != null && response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    this.tokenModel = null;
                    this.tokenModel = GetCurrentToken();
                    if (tryCounter < 3)
                    {
                        tryCounter++;
                        return await ExecuteEndpointTask(model);
                    }
                    else
                    {
                        tryCounter = 0;
                        result = UtilsApi.ErrorResponse(Constants.ERROR_MAX_RETRY);
                    }
                }
                else
                {
                    tryCounter = 0;
                    result = await UtilsApi.GetServerResponse(response);
                }
            }
            catch
            {
                result = UtilsApi.ErrorResponse(Constants.ERROR_API_UNAVAILABLE);
            }

            return result;
        }

        #region Private Methods

        /// <summary>
        /// Verify token
        /// </summary>
        private void CheckToken()
        {
            if (tokenModel == null || string.IsNullOrEmpty(tokenModel.Token))
                tokenModel = LoginApplication().GetAwaiter().GetResult();
        }

        #endregion
    }
}
