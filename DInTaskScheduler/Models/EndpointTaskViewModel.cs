using static DInTaskScheduler.Tools.Enums;

namespace DInTaskScheduler.Models
{
    public class EndpointTaskViewModel
    {
        public int Id { get; set; }
        public HttpMethods HttpMethod { get; set; }
        public string EndpointSufix { get; set; }
        public string Body { get; set; }
    }
}
