using DInTaskSchedulerApi.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Domain.Contracts.Services
{
    public interface IRequestTypeService
    {
        Task<IList<CatalogViewModel>> Get();
    }
}
