using CoffeeStore.Domain;
using CoffeeStore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeStore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productService)
        {
            _productsService = productService;
        }

        [HttpGet(Name = "products")]
        public async Task<ActionResult<ProductItem[]>> GetAllProducts()
        {
            var products = await _productsService.GetAllProducts();

            return new JsonResult(products);
        }

        [HttpPost(Name = "add")]
        public async Task AddProduct()
        {
            using var streamReader = new StreamReader(Request.Body);
            var requestBody = await streamReader.ReadToEndAsync();

            dynamic? product = JsonConvert.DeserializeObject(requestBody);
            
            if (product is null) return;

            if (product.productType != null && product.productType == "2")
                await _productsService.Upsert(JsonConvert.DeserializeObject<CoffeeMachineProduct>(requestBody));
            else
                await _productsService.Upsert(JsonConvert.DeserializeObject<CoffeeProduct>(requestBody));
        }
    }
}
