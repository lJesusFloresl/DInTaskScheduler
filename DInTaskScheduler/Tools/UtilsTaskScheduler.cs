using DInTaskScheduler.Services;
using System;

namespace DInTaskScheduler.Tools
{
    /// <summary>
    /// Utils for task scheduler
    /// </summary>
    public static class UtilsTaskScheduler
    {
        /// <summary>
        /// Action execution in seconds
        /// </summary>
        /// <param name="startHour">Start hour</param>
        /// <param name="startMinute">Start minute</param>
        /// <param name="interval">Interval</param>
        /// <param name="task">Action to execute</param>
        public static void IntervalInSeconds(int startHour, int startMinute, double interval, Action task)
        {
            interval = interval / 3600;
            TaskSchedulerService.Instance.ScheduleTask(startHour, startMinute, interval, task);
        }

        /// <summary>
        /// Action execution in minutes
        /// </summary>
        /// <param name="startHour">Start hour</param>
        /// <param name="startMinute">Start minute</param>
        /// <param name="interval">Interval</param>
        /// <param name="task">Action to execute</param>
        public static void IntervalInMinutes(int startHour, int startMinute, double interval, Action task)
        {
            interval = interval / 60;
            TaskSchedulerService.Instance.ScheduleTask(startHour, startMinute, interval, task);
        }

        /// <summary>
        /// Action execution in hours
        /// </summary>
        /// <param name="startHour">Start hour</param>
        /// <param name="startMinute">Start minute</param>
        /// <param name="interval">Interval</param>
        /// <param name="task">Action to execute</param>
        public static void IntervalInHours(int startHour, int startMinute, double interval, Action task)
        {
            TaskSchedulerService.Instance.ScheduleTask(startHour, startMinute, interval, task);
        }

        /// <summary>
        /// Action execution in days
        /// </summary>
        /// <param name="startHour">Start hour</param>
        /// <param name="startMinute">Start minute</param>
        /// <param name="interval">Interval</param>
        /// <param name="task">Action to execute</param>
        public static void IntervalInDays(int startHour, int startMinute, double interval, Action task)
        {
            interval = interval * 24;
            TaskSchedulerService.Instance.ScheduleTask(startHour, startMinute, interval, task);
        }
    }
}
