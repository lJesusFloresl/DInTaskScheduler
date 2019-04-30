using DInTaskScheduler.Domain.Contracts.Repositories;
using DInTaskScheduler.Domain.Contracts.Services;
using DInTaskScheduler.Infrastructure.DataContext;
using DInTaskScheduler.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DInTaskScheduler.Tools.Enums;

namespace DInTaskScheduler.Application.Services
{
    public class JobExecutionService : IJobExecutionService
    {
        private readonly IJobExecutionRepository jobExecutionRepository;

        public JobExecutionService(IJobExecutionRepository jobExecutionRepository)
        {
            this.jobExecutionRepository = jobExecutionRepository;
        }

        public async Task<List<JobExecution>> GetByDate(DateTime date)
        {
            return await Task.Run(() =>
            {
                List<JobExecution> result;
                var status = StatusCatalog.ACTIVE.GetValue();

                try
                {
                    result = jobExecutionRepository.Get(status, date).ToList();
                }
                catch
                {
                    result = new List<JobExecution>();
                }

                return result;
            });
        }

        public async Task<ServerResponse> ExecuteJob(JobExecution job)
        {
            return await Task.Run(() =>
            {
                ServerResponse result;

                try
                {
                    job.InProcess = true;
                    result = Utils.SuccessResponse(job.Id);
                }
                catch (Exception ex)
                {
                    result = Utils.ErrorResponse(Constants.ERROR_ENDPOINT_EXECUTION, ex.ToString());
                }

                return result;
            });
        }
    }
}
