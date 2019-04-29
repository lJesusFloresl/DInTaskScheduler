using DInTaskSchedulerApi.Infrastructure.DataContext;
using System.Linq;

namespace DInTaskSchedulerApi.Domain.Contracts.Repositories
{
    public interface ISpecialFunctionRepository
    {
        IQueryable<SpecialFunction> Get();

        IQueryable<SpecialFunction> GetByPropertyType(int idPropertyType);
    }
}
