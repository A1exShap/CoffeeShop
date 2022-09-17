using CoffeeStore.Domain;
using CoffeeStore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeStore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController
    {
        private readonly IPropertiesService _propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            _propertiesService = propertiesService;
        }

        [HttpGet("types")]
        public async Task<ActionResult<Dictionary<Guid, string>>> GetProductTypes()
        {
            var types = await _propertiesService.GetProductTypes();

            return new JsonResult(types);
        }

        [HttpGet("sorts")]
        public async Task<ActionResult<Dictionary<Guid, string>>> GetSorts()
        {
            var sorts = await _propertiesService.GetProperties(ProductPropertyNames.Sort);

            return new JsonResult(sorts);
        }

        [HttpGet("strengths")]
        public async Task<ActionResult<Dictionary<Guid, string>>> GetStrengths()
        {
            var strengths = await _propertiesService.GetProperties(ProductPropertyNames.Strength);

            return new JsonResult(strengths);
        }

        [HttpGet("machinetypes")]
        public async Task<ActionResult<Dictionary<Guid, string>>> GetMachineTypes()
        {
            var machineTypes = await _propertiesService.GetProperties(ProductPropertyNames.CoffeeMachineType);

            return new JsonResult(machineTypes);
        }
    }
}
