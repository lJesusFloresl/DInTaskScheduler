using System.Linq;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Infrastructure.DataContext;

namespace DInTaskSchedulerApi.Infrastructure.Repositories
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly DInTaskSchedulerContext context;

        public PropertyTypeRepository(DInTaskSchedulerContext context)
        {
            this.context = context;
        }

        public IQueryable<PropertyType> Get()
        {
            return context.PropertyType.AsQueryable();
        }
    }
}
