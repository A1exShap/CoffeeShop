namespace CoffeeStore.DataAccess.Repositories
{
    public interface IProductTypesRepository
    {
        Task<Guid> GetProductTypeId(string productTypeName);
    }
}
