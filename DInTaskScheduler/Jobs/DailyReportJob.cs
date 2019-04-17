using DInTaskScheduler.Models;
using DInTaskScheduler.Services;
using DInTaskScheduler.Tools;
using Quartz;
using System.Collections.Generic;
using static DInTaskScheduler.Tools.Enums;

namespace DInTaskScheduler.Jobs
{
    public class DailyReportJob : IJob
    {
        List<EndpointTaskViewModel> taskList;

        public DailyReportJob()
        {
            taskList = new List<EndpointTaskViewModel>();
        }

        public void Execute(IJobExecutionContext context)
        {
            Utils.PrintConsole("Executing Job...");

            var executionEndpoint = new EndpointTaskViewModel()
            {
                HttpMethod = HttpMethods.POST,
                EndpointSufix = Constants.API_ROUTE_REPORTING_DAILYSUMMARY,
                Body = new DailySummaryReportFilterViewModel(1, Utils.GetCurrentDate()
                    , "ljesusfloresl@gmail.com").ToJson()
            };

            taskList.Add(executionEndpoint);

            taskList.ForEach(task => { TaskEndpointService.ExecuteEndpointTaskAsync(task); });
        }
    }
}
