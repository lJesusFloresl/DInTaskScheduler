namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Generic server response
    /// </summary>
    public class ServerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Id { get; set; }

        public ServerResponse(bool success, string message, object id)
        {
            this.Success = success;
            this.Message = message;
            this.Id = id;
        }
    }
}
