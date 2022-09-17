using CoffeeStore.DataAccess.Dto;

namespace CoffeeStore.DataAccess.Repositories
{
    public interface IProductsRepository
    {
        Task<Product[]> GetAllProducts();

        Task<Product[]> GetProductsByPartialName(string partialName);

        Task<Product[]> GetProductsByType(Guid productTypeId);

        Task<Guid> Upsert(Product product);

        Task Delete(Product product);
    }
}
