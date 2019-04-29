using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class Settings
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string Version { get; set; }
    }
}
