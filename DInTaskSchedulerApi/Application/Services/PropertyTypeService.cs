using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;

namespace DInTaskSchedulerApi.Application.Services
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IPropertyTypeRepository propertyTypeRepository;

        public PropertyTypeService(IPropertyTypeRepository propertyTypeRepository)
        {
            this.propertyTypeRepository = propertyTypeRepository;
        }

        public async Task<IList<CatalogViewModel>> Get()
        {
            IList<CatalogViewModel> result;
            try
            {
                result = await Task.FromResult(propertyTypeRepository.Get().Select(e => ModelFormatter.FormatPropertyTypeCatalogModel(e)).ToList());
            }
            catch
            {
                result = new List<CatalogViewModel>();
            }
            return result;
        }
    }
}
