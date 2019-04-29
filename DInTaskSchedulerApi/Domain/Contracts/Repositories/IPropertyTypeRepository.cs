using DInTaskSchedulerApi.Infrastructure.DataContext;
using System.Linq;

namespace DInTaskSchedulerApi.Domain.Contracts.Repositories
{
    public interface IPropertyTypeRepository
    {
        IQueryable<PropertyType> Get();
    }
}
