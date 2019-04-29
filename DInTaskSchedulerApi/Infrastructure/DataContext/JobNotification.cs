using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class JobNotification
    {
        public int Id { get; set; }
        public int IdJob { get; set; }
        public string Mail { get; set; }

        public Job IdJobNavigation { get; set; }
    }
}
