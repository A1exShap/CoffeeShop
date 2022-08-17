namespace CoffeeShop.Domain
{
    public abstract record ProductItem : IProductItem
    {
        public Guid Id { get; }

        public ProductType ProductType { get; }

        public string Name { get; } = string.Empty;

        public decimal VendorPrice { get; }

        public decimal SellingPrice { get; }
    }
}