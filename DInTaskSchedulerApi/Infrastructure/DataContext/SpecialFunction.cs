using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class SpecialFunction
    {
        public SpecialFunction()
        {
            JobParameter = new HashSet<JobParameter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdPropertyType { get; set; }

        public PropertyType IdPropertyTypeNavigation { get; set; }
        public ICollection<JobParameter> JobParameter { get; set; }
    }
}
