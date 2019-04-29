using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class Frequency
    {
        public Frequency()
        {
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Job> Job { get; set; }
    }
}
