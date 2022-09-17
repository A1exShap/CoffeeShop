using CoffeeStore.DataAccess.Dto;

namespace CoffeeStore.DataAccess.Repositories
{
    public interface IProductTypesRepository
    {
        Task<ProductType[]> GetProductTypes();

        Task<Guid> GetProductTypeId(string productTypeName);
    }
}
