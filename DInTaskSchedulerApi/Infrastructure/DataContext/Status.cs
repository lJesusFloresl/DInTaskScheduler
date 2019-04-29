using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class Status
    {
        public Status()
        {
            Application = new HashSet<Application>();
            ApplicationEnvironment = new HashSet<ApplicationEnvironment>();
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Application> Application { get; set; }
        public ICollection<ApplicationEnvironment> ApplicationEnvironment { get; set; }
        public ICollection<Job> Job { get; set; }
    }
}
