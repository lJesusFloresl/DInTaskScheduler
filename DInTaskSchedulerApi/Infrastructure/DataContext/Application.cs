using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class Application
    {
        public Application()
        {
            ApplicationEnvironment = new HashSet<ApplicationEnvironment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int IdStatus { get; set; }

        public Status IdStatusNavigation { get; set; }
        public ICollection<ApplicationEnvironment> ApplicationEnvironment { get; set; }
    }
}
