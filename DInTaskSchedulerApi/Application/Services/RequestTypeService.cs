using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;

namespace DInTaskSchedulerApi.Application.Services
{
    public class RequestTypeService : IRequestTypeService
    {
        private readonly IRequestTypeRepository requestTypeRepository;

        public RequestTypeService(IRequestTypeRepository requestTypeRepository)
        {
            this.requestTypeRepository = requestTypeRepository;
        }

        public async Task<IList<CatalogViewModel>> Get()
        {
            IList<CatalogViewModel> result;
            try
            {
                result = await Task.FromResult(requestTypeRepository.Get().Select(e => ModelFormatter.FormatRequestTypeCatalogModel(e)).ToList());
            }
            catch
            {
                result = new List<CatalogViewModel>();
            }
            return result;
        }
    }
}
