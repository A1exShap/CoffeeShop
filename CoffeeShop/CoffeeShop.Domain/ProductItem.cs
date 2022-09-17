using CoffeeStore.DataAccess.Dto;
using System.Text.Json.Serialization;

namespace CoffeeStore.Domain
{
    public abstract record ProductItem : IProductItem
    {
        public static IProductItem FromDbProduct(Product product)
        {
            var productTypeName = product.ProductType.Name;
            IProductItem productItem = productTypeName switch
            {
                ProductTypeNames.CoffeeBeans => ProductItemFactory.CreateCoffeeProduct(product, product.ProductType.Id),
                ProductTypeNames.GroundCoffee => ProductItemFactory.CreateCoffeeProduct(product, product.ProductType.Id),
                ProductTypeNames.CoffeeMachine => ProductItemFactory.CreateCoffeeMachine(product, product.ProductType.Id),
                _ => throw new InvalidOperationException($"Couldn't process product type '{productTypeName}'")
            };

            return productItem;
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nomenclatureNumber")]
        public string NomenclatureNumber { get; init; } = string.Empty;

        [JsonPropertyName("productType")]
        public Guid ProductType { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("vendorPrice")]
        public decimal VendorPrice { get; init; }

        [JsonPropertyName("sellingPrice")]
        public decimal SellingPrice { get; init; }
    }
}