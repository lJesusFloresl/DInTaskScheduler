using System.Linq;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class ParameterTypeRepository : IParameterTypeRepository
    {
        private readonly DInTaskSchedulerContext context;

        public ParameterTypeRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<ParameterType> Get()
        {
            return context.ParameterType.AsQueryable();
        }
    }
}
