using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Domain.Contracts.Services
{
    public interface IApplicationService
    {
        Task<IList<ApplicationViewModel>> Get();

        Task<IList<ApplicationViewModel>> GetActive();

        Task<ApplicationViewModel> GetById(int id);

        Task<ServerResponse> Save(SaveApplicationViewModel model);

        Task<ServerResponse> Update(SaveApplicationViewModel model);
    }
}
