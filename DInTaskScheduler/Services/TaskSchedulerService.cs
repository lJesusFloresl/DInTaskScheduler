using DInTaskScheduler.Tools;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DInTaskScheduler.Services
{
    /// <summary>
    /// Task scheduler service
    /// </summary>
    public class TaskSchedulerService
    {
        private static TaskSchedulerService _instance;
        private List<Timer> timers = new List<Timer>();

        private TaskSchedulerService()
        {
        }

        public static TaskSchedulerService Instance => _instance ?? (_instance = new TaskSchedulerService());

        /// <summary>
        /// Check if task must be executed
        /// </summary>
        /// <param name="startHour">Start hour</param>
        /// <param name="startMinute">Start minute</param>
        /// <param name="intervalInHour">Execution interval</param>
        /// <param name="task">Execution task</param>
        public void ScheduleTask(int startHour, int startMinute, double intervalInHour, Action task)
        {
            DateTime now = Utils.GetCurrentDateTime();
            DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, startHour, startMinute, 0, 0);

            if (now > firstRun)
                firstRun = firstRun.AddDays(1);

            TimeSpan timeToGo = firstRun - now;

            if (timeToGo <= TimeSpan.Zero)
                timeToGo = TimeSpan.Zero;

            var timer = new Timer(callback =>
            {
                task.Invoke();
            }, null, timeToGo, TimeSpan.FromHours(intervalInHour));

            timers.Add(timer);
        }
    }
}
