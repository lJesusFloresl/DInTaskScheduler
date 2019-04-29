using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class RequestType
    {
        public RequestType()
        {
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Job> Job { get; set; }
    }
}
