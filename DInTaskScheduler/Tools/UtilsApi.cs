using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DInTaskScheduler.Tools
{
    /// <summary>
    /// Api helpers
    /// </summary>
    public static class UtilsApi
    {
        /// <summary>
        /// Add headers for send requests
        /// </summary>
        public static void SetHeaders(this HttpClient httpClient, string token, bool onlyClear = false)
        {
            httpClient.DefaultRequestHeaders.Clear();
            if (!onlyClear)
            {
                httpClient.DefaultRequestHeaders.Add(Constants.HTTP_HEADER_ACCEPT, Constants.HTTP_MEDIA_TYPE);
                httpClient.DefaultRequestHeaders.Add(Constants.HTTP_HEADER_AUTHORIZATION, string.Format(Constants.HTTP_BEARER_TOKEN, token));
            }
        }

        /// <summary>
        /// Converts api response ServerResponse object
        /// </summary>
        /// <param name="response">Api response</param>
        /// <returns>Objeto ServerResponse</returns>
        public static async Task<ServerResponse> GetServerResponse(HttpResponseMessage response)
        {
            Stream stream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            var serverResponse = JsonConvert.DeserializeObject<ServerResponse>(json);
            return serverResponse;
        }

        /// <summary>
        /// Get error response
        /// </summary>
        public static ServerResponse ErrorResponse(string messageComplement, object id = null)
        {
            return new ServerResponse(false, string.Format(Constants.HTTP_ERROR_API, messageComplement), id);
        }
    }
}
