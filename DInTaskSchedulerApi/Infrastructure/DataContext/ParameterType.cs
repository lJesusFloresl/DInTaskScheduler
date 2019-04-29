using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class ParameterType
    {
        public ParameterType()
        {
            JobParameter = new HashSet<JobParameter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<JobParameter> JobParameter { get; set; }
    }
}
