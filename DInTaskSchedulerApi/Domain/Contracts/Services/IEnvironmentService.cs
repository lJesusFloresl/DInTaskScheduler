using DInTaskSchedulerApi.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Domain.Contracts.Services
{
    public interface IEnvironmentService
    {
        Task<IList<CatalogViewModel>> Get();
    }
}
