using DInTaskScheduler.Infrastructure.DataContext;
using System;
using System.Linq;

namespace DInTaskScheduler.Domain.Contracts.Repositories
{
    public interface IJobExecutionRepository
    {
        IQueryable<JobExecution> Get(int idStatus, DateTime dateTime);
    }
}
