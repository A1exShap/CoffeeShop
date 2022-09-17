using CoffeeStore.DataAccess.Dto;
using CoffeeStore.DataAccess.Repositories;
using CoffeeStore.Domain;
using System.Transactions;

namespace CoffeeStore.Services.Implementation
{
    internal class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductTypesRepository _productTypesRepository;
        private readonly IProductPropertiesRepository _productPropertiesRepository;
        private readonly IEnumValuesRepository _enumValuesRepository;
        private readonly IProductPropertyValuesRepository _productPropertyValuesRepository;

        public ProductsService(IProductsRepository productsRepository, 
                               IProductTypesRepository productTypesRepository,
                               IProductPropertiesRepository productPropertiesRepository,
                               IEnumValuesRepository enumValuesRepository,
                               IProductPropertyValuesRepository productPropertyValuesRepository)
        {
            _productsRepository = productsRepository;
            _productTypesRepository = productTypesRepository;
            _productPropertiesRepository = productPropertiesRepository;
            _enumValuesRepository = enumValuesRepository;
            _productPropertyValuesRepository = productPropertyValuesRepository; 
        }

        public async Task<IEnumerable<IProductItem>> GetAllProducts()
        {
            var products = await _productsRepository.GetAllProducts();
            return products.Select(ProductItem.FromDbProduct);
        }

        public async Task<IEnumerable<IProductItem>> GetProductsByPartialName(string partialName)
        {
            var products = await _productsRepository.GetProductsByPartialName(partialName);
            return products.Select(ProductItem.FromDbProduct);
        }

        public async Task<IEnumerable<IProductItem>> GetProductsByType(Guid productTypeId)
        {
            var products = await _productsRepository.GetProductsByType(productTypeId);
            return products.Select(ProductItem.FromDbProduct);
        }

        public async Task Upsert(ProductItem? productItem)
        {
            if (productItem is null)
                throw new ArgumentNullException();

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var product = new Product
            {
                Id = productItem.Id,
                NomenclatureNumber = productItem.NomenclatureNumber,
                Name = productItem.Name,
                ProductTypeId = productItem.ProductType,
                Description = productItem.Description
            };

            productItem.Id = await _productsRepository.Upsert(product);

            if (productItem is CoffeeMachineProduct)
            {
                var coffeeMachine = (CoffeeMachineProduct)productItem;

                await SetProperty(coffeeMachine.Id, ProductPropertyNames.CoffeeMachineType, stringValue: coffeeMachine.MachineType.ToString());
                await SetProperty(coffeeMachine.Id, ProductPropertyNames.CoffeeGrinder, numericValue: coffeeMachine.HasCoffeeGrinder ? 1 : 0);
                await SetProperty(coffeeMachine.Id, ProductPropertyNames.Cappuccinatore, numericValue: coffeeMachine.HasCappuccinatore ? 1 : 0);
            }
            else if (productItem is CoffeeProduct)
            {
                var coffeeProduct = (CoffeeProduct)productItem;

                await SetProperty(coffeeProduct.Id, ProductPropertyNames.Sort, stringValue: coffeeProduct.Sort.ToString());
                await SetProperty(coffeeProduct.Id, ProductPropertyNames.Origin, stringValue: coffeeProduct.Origin);
                await SetProperty(coffeeProduct.Id, ProductPropertyNames.Strength, stringValue: coffeeProduct.Strength.ToString());
            }

            transaction.Complete();
        }

        public async Task<Domain.ProductType> GetProductType(Guid productTypeId)
        {
            var type = (await _productTypesRepository.GetProductTypes()).Where(x => x.Id == productTypeId).FirstOrDefault();

            return type.Name switch
            {
                ProductTypeNames.CoffeeMachine => Domain.ProductType.CoffeeMachine,
                ProductTypeNames.CoffeeBeans => Domain.ProductType.CoffeeBeans,
                ProductTypeNames.GroundCoffee => Domain.ProductType.GroundedCoffee,
                _ => throw new InvalidOperationException($"Couldn't process product type '{productTypeId}'")
            };
        }

        private Task<Guid> GetProductTypeId(Domain.ProductType productType)
        {
            var productTypeName = productType switch
            {
                Domain.ProductType.GroundedCoffee => ProductTypeNames.GroundCoffee,
                Domain.ProductType.CoffeeBeans => ProductTypeNames.CoffeeBeans,
                Domain.ProductType.CoffeeMachine => ProductTypeNames.CoffeeMachine,
                _ => throw new InvalidOperationException($"Couldn't process product type '{productType}'")
            };

            return _productTypesRepository.GetProductTypeId(productTypeName);
        }

        private async Task SetProperty(Guid productId, string propertyName, string? stringValue = null, decimal? numericValue = null)
        {
            (var propertyId, var valueType) = await _productPropertiesRepository.GetPropertyParameters(propertyName);

            var propertyValue = new ProductPropertyValue
            {
                ProductId = productId,
                PropertyId = propertyId,
            };

            var type = (Domain.PropertyValueType?)valueType;

            if (type == Domain.PropertyValueType.String)
                propertyValue.StringValue = stringValue;
            else if (type == Domain.PropertyValueType.Number)
                propertyValue.NumericValue = numericValue;
            else if (type == Domain.PropertyValueType.EnumValue)
                propertyValue.EnumValueId = Guid.Parse(stringValue);

            await _productPropertyValuesRepository.Upsert(propertyValue);
        }
    }
}
