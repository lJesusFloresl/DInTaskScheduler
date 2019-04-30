using DInTaskScheduler.Application.Jobs;
using DInTaskScheduler.Tools;
using Quartz;
using System;

namespace DInTaskScheduler
{
    public class JobScheduler
    {
        private readonly IScheduler scheduler;

        public JobScheduler(IScheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        public void Start()
        {
            DateTime startTime = Utils.RoundUp(Utils.GetCurrentDateTime(), TimeSpan.FromMinutes(1));
            Utils.PrintConsole(string.Format("Programming first job executions at time {0:HH:mm:ss}", startTime));

            scheduler.Start();

            IJobDetail job = JobBuilder.Create<JobAsyncExecutor>().Build();

            ITrigger trigger = TriggerBuilder.Create()
             .WithIdentity("JobAsyncExecutor", "JobAsyncGroup")
             //.StartAt(startTime)
             .StartNow()
             .WithPriority(1)
             .WithCronSchedule(Constants.CRON_EXPR_EVERY_10_SECONDS)
             .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}
