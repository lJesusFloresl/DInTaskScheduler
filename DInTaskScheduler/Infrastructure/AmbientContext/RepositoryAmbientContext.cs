using DInTaskScheduler.Domain.Contracts.Repositories;
using DInTaskScheduler.Infrastructure.DataContext;
using DInTaskScheduler.Infrastructure.Repositories;

namespace DInTaskScheduler.Infrastructure.AmbientContext
{
    /// <summary>
    /// Class inherits many repositories
    /// </summary>
    public class RepositoryAmbientContext
    {
        public readonly IJobExecutionRepository jobExecutionRepository;
        public readonly IJobRepository jobRepository;

        public RepositoryAmbientContext(DInTaskSchedulerEntities context)
        {
            this.jobExecutionRepository = new JobExecutionRepository(context);
            //this.jobRepository = 
        }
    }
}
