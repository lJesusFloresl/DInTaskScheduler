using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;

namespace DInTaskSchedulerApi.Application.Services
{
    public class SpecialFunctionService : ISpecialFunctionService
    {
        private readonly ISpecialFunctionRepository specialFunctionRepository;

        public SpecialFunctionService(ISpecialFunctionRepository specialFunctionRepository)
        {
            this.specialFunctionRepository = specialFunctionRepository;
        }

        public async Task<IList<SpecialFunctionViewModel>> Get()
        {
            IList<SpecialFunctionViewModel> result;
            try
            {
                result = await Task.FromResult(specialFunctionRepository.Get().Select(e => ModelFormatter.FormatSpecialFunctionModel(e)).ToList());
            }
            catch
            {
                result = new List<SpecialFunctionViewModel>();
            }
            return result;
        }

        public async Task<IList<SpecialFunctionViewModel>> GetByPropertyType(int idPropertyType)
        {
            IList<SpecialFunctionViewModel> result;
            try
            {
                result = await Task.FromResult(specialFunctionRepository.GetByPropertyType(idPropertyType).Select(e => ModelFormatter.FormatSpecialFunctionModel(e)).ToList());
            }
            catch
            {
                result = new List<SpecialFunctionViewModel>();
            }
            return result;
        }
    }
}
