using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;

namespace DInTaskSchedulerApi.Application.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository statusRepository;

        public EnvironmentService(IEnvironmentRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        public async Task<IList<CatalogViewModel>> Get()
        {
            IList<CatalogViewModel> result;
            try
            {
                result = await Task.FromResult(statusRepository.Get().Select(e => ModelFormatter.FormatEnvironmentCatalogModel(e)).ToList());
            }
            catch
            {
                result = new List<CatalogViewModel>();
            }
            return result;
        }
    }
}
