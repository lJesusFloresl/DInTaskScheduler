using DInTaskScheduler.Infrastructure.DataContext;
using DInTaskScheduler.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DInTaskScheduler.Domain.Contracts.Services
{
    public interface IJobExecutionService
    {
        Task<List<JobExecution>> GetByDate(DateTime date);

        Task<ServerResponse> ExecuteJob(JobExecution job);
    }
}
