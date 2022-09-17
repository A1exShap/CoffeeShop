using CoffeeStore.Domain;

namespace CoffeeStore.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<IProductItem>> GetAllProducts();

        Task<IEnumerable<IProductItem>> GetProductsByPartialName(string partialName);

        Task<IEnumerable<IProductItem>> GetProductsByType(Guid productTypeId);

        Task<Domain.ProductType> GetProductType(Guid productTypeId);

        Task Upsert(ProductItem productItem);
    }
}