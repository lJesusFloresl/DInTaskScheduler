using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class FrequencyController : BaseController
    {
        private readonly IFrequencyService frequencyService;

        public FrequencyController(IFrequencyService frequencyService)
        {
            this.frequencyService = frequencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await frequencyService.Get();
            return Ok(result);
        }
    }
}
