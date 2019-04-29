using DInTaskSchedulerApi.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Domain.Contracts.Services
{
    public interface IPropertyTypeService
    {
        Task<IList<CatalogViewModel>> Get();
    }
}
