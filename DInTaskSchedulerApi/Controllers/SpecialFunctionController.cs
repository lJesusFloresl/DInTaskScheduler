using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class SpecialFunctionController : BaseController
    {
        private readonly ISpecialFunctionService specialFunctionService;

        public SpecialFunctionController(ISpecialFunctionService specialFunctionService)
        {
            this.specialFunctionService = specialFunctionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await specialFunctionService.Get();
            return Ok(result);
        }

        [HttpGet("PropertyType/{idPropertyType:int}")]
        public async Task<IActionResult> GetByPropertyType(int idPropertyType)
        {
            var result = await specialFunctionService.GetByPropertyType(idPropertyType);
            return Ok(result);
        }
    }
}
