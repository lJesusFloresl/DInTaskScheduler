using DInTaskSchedulerApi.Infrastructure.DataContext;
using System.Linq;

namespace DInTaskSchedulerApi.Domain.Contracts.Repositories
{
    public interface IParameterTypeRepository
    {
        IQueryable<ParameterType> Get();
    }
}
