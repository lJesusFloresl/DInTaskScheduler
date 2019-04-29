using DInTaskSchedulerApi.Domain.Contracts.Services;
using DInTaskSchedulerApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DInTaskSchedulerApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE)]
    public class PropertyTypeController : BaseController
    {
        private readonly IPropertyTypeService propertyTypeService;

        public PropertyTypeController(IPropertyTypeService propertyTypeService)
        {
            this.propertyTypeService = propertyTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await propertyTypeService.Get();
            return Ok(result);
        }
    }
}
