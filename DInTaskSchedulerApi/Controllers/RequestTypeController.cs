using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class RequestTypeController : BaseController
    {
        private readonly IRequestTypeService requestTypeService;

        public RequestTypeController(IRequestTypeService requestTypeService)
        {
            this.requestTypeService = requestTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await requestTypeService.Get();
            return Ok(result);
        }
    }
}
