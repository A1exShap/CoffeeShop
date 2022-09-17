namespace CoffeeStore.Domain
{
    public interface IProductItem
    {
        Guid Id { get; }

        string NomenclatureNumber { get; }

        Guid ProductType { get; }

        string Name { get; }

        decimal VendorPrice { get; }

        decimal SellingPrice { get; }

    }
}
