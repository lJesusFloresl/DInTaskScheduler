using DInTaskScheduler.Jobs;
using DInTaskScheduler.Models;
using DInTaskScheduler.Services;
using DInTaskScheduler.Tools;
using Quartz;
using Quartz.Impl;
using System;
using static DInTaskScheduler.Tools.Enums;

namespace DInTaskScheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var now = Utils.GetCurrentDateTime();
            StartQuartzScheduler(now);

            ConsoleKeyInfo keyConsole;
            Console.WriteLine("Service Status Active, press (Esc) key to quit...");
            do
            {
                keyConsole = Console.ReadKey();
            } while (keyConsole.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Start job scheduler (timer mode)
        /// </summary>
        /// <param name="date">Start date</param>
        public static void StartTimerScheduler(DateTime date)
        {
            Utils.PrintConsole("Executing Job...");

            var executionEndpoint = new EndpointTaskViewModel()
            {
                HttpMethod = HttpMethods.POST,
                EndpointSufix = Constants.API_ROUTE_REPORTING_DAILYSUMMARY,
                Body = new DailySummaryReportFilterViewModel(1, Utils.GetCurrentDate()
                    , "ljesusfloresl@gmail.com").ToJson()
            };

            UtilsTaskScheduler.IntervalInSeconds(date.Hour, date.AddMinutes(1).Minute, 30, TaskEndpointService.ExecuteEndpointTaskAction(executionEndpoint));
        }

        /// <summary>
        /// Start job scheduler (quartz mode)
        /// </summary>
        /// <param name="date">Start date</param>
        public static void StartQuartzScheduler(DateTime date)
        {
            date = date.AddSeconds(10);
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<DailyReportJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
             .WithIdentity("DailyReportJob", "JobGroup")
               .StartAt(date)
               .WithPriority(1)
               .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
