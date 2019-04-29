using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class JobExecution
    {
        public long Id { get; set; }
        public DateTime ExecutionDateTime { get; set; }
        public int IdJob { get; set; }
        public bool IsSuccess { get; set; }
        public string UrlEndpoint { get; set; }
        public string Data { get; set; }
        public string Response { get; set; }
        public DateTime? InitDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public Job IdJobNavigation { get; set; }
    }
}
