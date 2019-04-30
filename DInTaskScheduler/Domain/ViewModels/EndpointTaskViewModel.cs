using static DInTaskScheduler.Tools.Enums;

namespace DInTaskScheduler.Domain.ViewModels
{
    public class EndpointTaskViewModel
    {
        public int Id { get; set; }
        public HttpMethods HttpMethod { get; set; }
        public string EndpointSufix { get; set; }
        public string Body { get; set; }
    }
}
