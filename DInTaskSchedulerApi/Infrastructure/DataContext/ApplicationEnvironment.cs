using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class ApplicationEnvironment
    {
        public ApplicationEnvironment()
        {
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public int IdApplication { get; set; }
        public int IdEnvironment { get; set; }
        public string EndpointUrlInfo { get; set; }
        public int IdStatus { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string EndpointUrlBase { get; set; }

        public Application IdApplicationNavigation { get; set; }
        public Environment IdEnvironmentNavigation { get; set; }
        public Status IdStatusNavigation { get; set; }
        public ICollection<Job> Job { get; set; }
    }
}
