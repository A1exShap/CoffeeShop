using CoffeeStore.Domain;
using CoffeeStore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeStore.WebApi.Controllers
{
    [ApiController]
    [Route("Products/{typeId?}")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productService)
        {
            _productsService = productService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ProductItem[]>> GetAllProducts()
        {
            var products = await _productsService.GetAllProducts();

            return new JsonResult(products);
        }

        [HttpPost("add")]
        public async Task AddProduct()
        {
            if (!Guid.TryParse(Request.RouteValues["typeId"].ToString(), out Guid productTypeId)) return;
            var productType = await _productsService.GetProductType(productTypeId);

            using var streamReader = new StreamReader(Request.Body);
            var requestBody = await streamReader.ReadToEndAsync();
            dynamic? product = JsonConvert.DeserializeObject(requestBody);
            
            if (productType == ProductType.CoffeeMachine)
                await _productsService.Upsert(JsonConvert.DeserializeObject<CoffeeMachineProduct>(product));

            else if (productType == ProductType.CoffeeBeans || productType == ProductType.GroundedCoffee)
                await _productsService.Upsert(JsonConvert.DeserializeObject<CoffeeProduct>(product));
        }
    }
}
