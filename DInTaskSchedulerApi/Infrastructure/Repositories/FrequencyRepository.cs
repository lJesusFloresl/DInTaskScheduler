using System.Linq;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class FrequencyRepository : IFrequencyRepository
    {
        private readonly DInTaskSchedulerContext context;

        public FrequencyRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<Frequency> Get()
        {
            return context.Frequency.AsQueryable();
        }
    }
}
