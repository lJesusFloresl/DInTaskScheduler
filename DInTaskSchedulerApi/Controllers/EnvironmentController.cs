using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class EnvironmentController : BaseController
    {
        private readonly IEnvironmentService environmentService;

        public EnvironmentController(IEnvironmentService environmentService)
        {
            this.environmentService = environmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await environmentService.Get();
            return Ok(result);
        }
    }
}
