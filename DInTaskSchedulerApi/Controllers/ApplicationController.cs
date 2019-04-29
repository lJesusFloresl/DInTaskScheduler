using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Domain.ViewModels;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await applicationService.Get();
            return Ok(result);
        }

        [HttpGet("Active")]
        public async Task<IActionResult> GetActive()
        {
            var result = await applicationService.GetActive();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await applicationService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveApplicationViewModel model)
        {
            var result = await applicationService.Save(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SaveApplicationViewModel model)
        {
            var result = await applicationService.Update(model);
            return Ok(result);
        }
    }
}
