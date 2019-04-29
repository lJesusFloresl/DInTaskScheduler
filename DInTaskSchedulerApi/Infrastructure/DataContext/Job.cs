using System;
using System.Collections.Generic;

namespace DInTaskSchedulerApi.Infrastructure.DataContext
{
    public partial class Job
    {
        public Job()
        {
            JobExecution = new HashSet<JobExecution>();
            JobNotification = new HashSet<JobNotification>();
            JobParameter = new HashSet<JobParameter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Endpoint { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan HourExecution { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int IdStatus { get; set; }
        public int IdFrequency { get; set; }
        public int IdRequestType { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public int IdApplicationEnvironment { get; set; }
        public bool UseAuthentication { get; set; }

        public ApplicationEnvironment IdApplicationEnvironmentNavigation { get; set; }
        public Frequency IdFrequencyNavigation { get; set; }
        public RequestType IdRequestTypeNavigation { get; set; }
        public Status IdStatusNavigation { get; set; }
        public ICollection<JobExecution> JobExecution { get; set; }
        public ICollection<JobNotification> JobNotification { get; set; }
        public ICollection<JobParameter> JobParameter { get; set; }
    }
}
