using DInTaskSchedulerApi.Infrastructure.DataContext;
using System.Linq;

namespace DInTaskSchedulerApi.Domain.Contracts.Repositories
{
    public interface IEnvironmentRepository
    {
        IQueryable<Environment> Get();
    }
}
