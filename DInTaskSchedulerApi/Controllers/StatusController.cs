using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class StatusController : BaseController
    {
        private readonly IStatusService statusService;

        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await statusService.Get();
            return Ok(result);
        }
    }
}
