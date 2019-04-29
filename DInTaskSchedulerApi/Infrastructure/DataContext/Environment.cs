using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class Environment
    {
        public Environment()
        {
            ApplicationEnvironment = new HashSet<ApplicationEnvironment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicationEnvironment> ApplicationEnvironment { get; set; }
    }
}
