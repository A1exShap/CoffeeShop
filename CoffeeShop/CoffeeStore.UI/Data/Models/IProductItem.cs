namespace CoffeeStore.UI.Data.Models
{
    public interface IProductItem
    {
        Guid Id { get; }

        int ProductType { get; }

        string Name { get; }

        public string? Description { get; init; }

        public decimal VendorPrice { get; init; }

        decimal SellingPrice { get; }

    }
}
