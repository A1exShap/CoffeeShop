using CoffeeStore.DataAccess.Dto;

namespace CoffeeStore.Domain
{
    public abstract record ProductItem : IProductItem
    {
        public static IProductItem FromDbProduct(Product product)
        {
            var productTypeName = product.ProductType.Name;
            IProductItem productItem = productTypeName switch
            {
                ProductTypeNames.CoffeeBeans => ProductItemFactory.CreateCoffeeProduct(product, ProductType.CoffeeBeans),
                ProductTypeNames.GroundCoffee => ProductItemFactory.CreateCoffeeProduct(product, ProductType.GroundedCoffee),
                ProductTypeNames.CoffeeMachine => ProductItemFactory.CreateCoffeeMachine(product),
                _ => throw new InvalidOperationException($"Couldn't process product type '{productTypeName}'")
            };

            return productItem;
        }

        public Guid Id { get; init; }

        public string NomenclatureNumber { get; init; }

        public ProductType ProductType { get; init; }

        public string Name { get; init; } = string.Empty;

        public string? Description { get; init; }

        public decimal VendorPrice { get; init; }

        public decimal SellingPrice { get; init; }
    }
}