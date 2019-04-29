using DInTaskSchedulerApi.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Domain.Contracts.Services
{
    public interface ISpecialFunctionService
    {
        Task<IList<SpecialFunctionViewModel>> Get();

        Task<IList<SpecialFunctionViewModel>> GetByPropertyType(int idPropertyType);
    }
}
