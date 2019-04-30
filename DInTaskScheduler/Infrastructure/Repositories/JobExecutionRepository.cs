using System;
using System.Data.Entity;
using System.Linq;
using DInTaskScheduler.Domain.Contracts.Repositories;
using DInTaskScheduler.Infrastructure.DataContext;

namespace DInTaskScheduler.Infrastructure.Repositories
{
    public class JobExecutionRepository : IJobExecutionRepository
    {
        private readonly DInTaskSchedulerEntities context;

        public JobExecutionRepository(DInTaskSchedulerEntities context)
        {
            this.context = context;
        }

        public IQueryable<JobExecution> Get(int idStatus, DateTime dateTime)
        {
            return context.JobExecution
                .Include(e => e.Job)
                .Include(e => e.Job.ApplicationEnvironment)
                .Include(e => e.Job.ApplicationEnvironment.Application)
                .Include(e => e.Job.JobExecution)
                .Include(e => e.Job.JobNotification)
                .Where(e => e.Job.IdStatus.Equals(idStatus)
                && e.Job.ApplicationEnvironment.IdStatus.Equals(idStatus)
                && e.Job.ApplicationEnvironment.Application.IdStatus.Equals(idStatus)
                && (!e.Job.EndDate.HasValue || (e.Job.EndDate.Value.Year.Equals(dateTime.Year)
                && e.Job.EndDate.Value.Month.Equals(dateTime.Month) && e.Job.EndDate.Value.Day.Equals(dateTime.Day)))
                && e.InProcess.Equals(false)
                && e.Finished.Equals(false)
                && (e.ExecutionDateTime.Year.Equals(dateTime.Year) && e.ExecutionDateTime.Month.Equals(dateTime.Month)
                && e.ExecutionDateTime.Day.Equals(dateTime.Day)))
                //&& (e.ExecutionDateTime.Hour.Equals(dateTime.Hour) && e.ExecutionDateTime.Minute.Equals(dateTime.Minute)))
                .AsQueryable();
        }
    }
}
