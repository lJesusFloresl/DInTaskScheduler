using System.Linq;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DInTaskSchedulerContext context;

        public StatusRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<Status> Get()
        {
            return context.Status.AsQueryable();
        }
    }
}
