﻿using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            JobParameter = new HashSet<JobParameter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<JobParameter> JobParameter { get; set; }
    }
}
