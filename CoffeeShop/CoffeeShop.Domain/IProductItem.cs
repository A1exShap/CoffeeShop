namespace CoffeeShop.Domain
{
    public interface IProductItem
    {
        Guid Id { get; }

        ProductType ProductType { get; }

        string Name { get; }

        decimal VendorPrice { get; }

        decimal SellingPrice { get; }

    }
}
