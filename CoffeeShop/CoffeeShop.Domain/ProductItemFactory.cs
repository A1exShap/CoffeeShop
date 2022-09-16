using CoffeeStore.DataAccess.Dto;
using CoffeeStore.Domain.CoffeeMachines;
using CoffeeStore.Domain.CoffeeProducts;
using static CoffeeStore.Domain.ProductPropertyNames;

namespace CoffeeStore.Domain
{
    public static class ProductItemFactory
    {
        public static CoffeeProduct CreateCoffeeProduct(Product product, ProductType productType)
        {
            var actualPrice = GetActualPrice(product);

            return new CoffeeProduct
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ProductType = productType,
                SellingPrice = actualPrice?.SellingPrice ?? 0,
                VendorPrice = actualPrice?.VendorPrice ?? 0,
                Sort = GetString(Sort, product),
                Strength = GetInt(Strength, product),
                Origin = GetString(Origin, product)
            };
        }

        public static CoffeeMachineProduct CreateCoffeeMachine(Product product)
        {
            const int defaultGuaranteePeriod = 12;

            var actualPrice = GetActualPrice(product);

            return new CoffeeMachineProduct
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ProductType = ProductType.CoffeeMachine,
                SellingPrice = actualPrice?.SellingPrice ?? 0,
                VendorPrice = actualPrice?.VendorPrice ?? 0,
                GuaranteePeriod = GetInt(GuaranteePeriod, product) ?? defaultGuaranteePeriod,
                MachineType = GetString(ProductPropertyNames.CoffeeMachineType, product) ?? string.Empty,
                HasCoffeeGrinder = GetBool(CoffeeGrinder, product),
                HasCappuccinatore = GetBool(Cappuccinatore, product)
            };
        }

        private static Price? GetActualPrice(Product product)
        {
            var prices = product.Prices
                .Where(price => price.Date.Date <= DateTime.Today)
                .OrderByDescending(price => price.Date);

            return prices.FirstOrDefault();
        }

        private static string? GetString(string propertyName, Product product)
        {
            var propValue = GetPropertyValue(propertyName, product);

            var property = propValue?.Property;

            if (property?.ValueType == (int)PropertyValueType.String)
            {
                return propValue?.StringValue;
            }

            if (property?.ValueType == (int)PropertyValueType.EnumValue)
            {
                return propValue?.EnumValue?.StringValue;
            }

            return default;
        }

        private static decimal? GetDecimal(string propertyName, Product product)
        {
            var propValue = GetPropertyValue(propertyName, product);
            var property = propValue?.Property;

            if (property?.ValueType == (int)PropertyValueType.Number)
            {
                return propValue?.NumericValue;
            }

            if (property?.ValueType == (int)PropertyValueType.EnumValue)
            {
                return propValue?.EnumValue?.NumericValue;
            }

            return default;
        }

        private static int? GetInt(string propertyName, Product product)
            => (int?)GetDecimal(propertyName, product);

        private static bool GetBool(string propertyName, Product product)
            => Convert.ToBoolean(GetDecimal(propertyName, product));

        private static ProductPropertyValue? GetPropertyValue(string propertyName, Product product)
            => product.ProductPropertyValues
                    .SingleOrDefault(value => value.Property.Name == propertyName);
    }
}
