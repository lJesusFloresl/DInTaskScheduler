using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;

namespace DInTaskSchedulerApi.Application.Services
{
    public class ParameterTypeService : IParameterTypeService
    {
        private readonly IParameterTypeRepository parameterTypeRepository;

        public ParameterTypeService(IParameterTypeRepository parameterTypeRepository)
        {
            this.parameterTypeRepository = parameterTypeRepository;
        }

        public async Task<IList<CatalogViewModel>> Get()
        {
            IList<CatalogViewModel> result;
            try
            {
                result = await Task.FromResult(parameterTypeRepository.Get().Select(e => ModelFormatter.FormatParameterTypeCatalogModel(e)).ToList());
            }
            catch
            {
                result = new List<CatalogViewModel>();
            }
            return result;
        }
    }
}
