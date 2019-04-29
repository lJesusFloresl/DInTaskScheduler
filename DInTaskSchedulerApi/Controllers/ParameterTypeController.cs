using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class ParameterTypeController : BaseController
    {
        private readonly IParameterTypeService parameterTypeService;

        public ParameterTypeController(IParameterTypeService parameterTypeService)
        {
            this.parameterTypeService = parameterTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await parameterTypeService.Get();
            return Ok(result);
        }
    }
}
