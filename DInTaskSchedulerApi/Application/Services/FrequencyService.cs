using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInTaskSchedulerApi.Domain.Contracts.Repositories;
using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;

namespace DInTaskSchedulerApi.Application.Services
{
    public class FrequencyService : IFrequencyService
    {
        private readonly IFrequencyRepository frequencyRepository;

        public FrequencyService(IFrequencyRepository frequencyRepository)
        {
            this.frequencyRepository = frequencyRepository;
        }

        public async Task<IList<CatalogViewModel>> Get()
        {
            IList<CatalogViewModel> result;
            try
            {
                result = await Task.FromResult(frequencyRepository.Get().Select(e => ModelFormatter.FormatFrequencyCatalogModel(e)).ToList());
            }
            catch
            {
                result = new List<CatalogViewModel>();
            }
            return result;
        }
    }
}
