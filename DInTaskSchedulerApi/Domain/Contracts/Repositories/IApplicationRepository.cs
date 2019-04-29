using System.Linq;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Domain.Contracts.Repositories
{
    public interface IApplicationRepository
    {
        IQueryable<Infrastructure.DataContext.Application> Get();

        IQueryable<Infrastructure.DataContext.Application> GetActive();

        Infrastructure.DataContext.Application GetById(int id);

        Task<Infrastructure.DataContext.Application> Save(Infrastructure.DataContext.Application model);

        Task<Infrastructure.DataContext.Application> Update(Infrastructure.DataContext.Application model);
    }
}
