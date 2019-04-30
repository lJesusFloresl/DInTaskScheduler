using DInTaskScheduler.Application.Services;
using DInTaskScheduler.Domain.Contracts.Services;
using DInTaskScheduler.Infrastructure.AmbientContext;
using DInTaskScheduler.Tools;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DInTaskScheduler.Application.Jobs
{
    public class JobAsyncExecutor : IJob
    {
        private readonly IJobExecutionService jobExecutionService;

        public JobAsyncExecutor(RepositoryAmbientContext repository)
        {
            jobExecutionService = new JobExecutionService(repository.jobExecutionRepository);
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            DateTime currentDate = Utils.GetCurrentDateTime();
            Utils.PrintConsole("Checking new jobs...");
            var jobs = await jobExecutionService.GetByDate(currentDate);
            Utils.PrintConsole("Jobs found ({0}) ...", jobs.Count());
            jobs.ForEach(job => 
            {
                Utils.PrintConsole("Executing job: Id {0} - Name {1}", job.IdJob, job.Job.Name);
                jobExecutionService.ExecuteJob(job);
            });

            //var executionEndpoint = new EndpointTaskViewModel()
            //{
            //    HttpMethod = HttpMethods.POST,
            //    EndpointSufix = Constants.API_ROUTE_REPORTING_DAILYSUMMARY,
            //    Body = new DailySummaryReportFilterViewModel(1, Utils.GetCurrentDate()
            //        , "ljesusfloresl@gmail.com").ToJson()
            //};

            //taskList.Add(executionEndpoint);

            //taskList.ForEach(task => { TaskEndpointService.ExecuteEndpointTaskAsync(task); });
        }
    }
}
