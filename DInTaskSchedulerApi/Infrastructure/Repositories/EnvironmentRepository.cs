using System.Linq;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class EnvironmentRepository : IEnvironmentRepository
    {
        private readonly DInTaskSchedulerContext context;

        public EnvironmentRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<Environment> Get()
        {
            return context.Environment.AsQueryable();
        }
    }
}
