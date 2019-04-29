using System.Linq;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly DInTaskSchedulerContext context;

        public RequestTypeRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<RequestType> Get()
        {
            return context.RequestType.AsQueryable();
        }
    }
}
