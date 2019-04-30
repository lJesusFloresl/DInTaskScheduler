using System.Threading.Tasks;
using DInTaskScheduler.Domain.Contracts.Repositories;
using DInTaskScheduler.Infrastructure.DataContext;

namespace DInTaskScheduler.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DInTaskSchedulerEntities context;

        public JobRepository(DInTaskSchedulerEntities context)
        {
            this.context = context;
        }

        public Task<bool> UpdateFinished(int idJob, bool finished)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateProcess(int idJob, bool InProcess)
        {
            throw new System.NotImplementedException();
        }
    }
}
