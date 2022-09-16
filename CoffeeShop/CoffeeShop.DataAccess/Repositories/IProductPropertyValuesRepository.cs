using CoffeeStore.DataAccess.Dto;

namespace CoffeeStore.DataAccess.Repositories
{
    public interface IProductPropertyValuesRepository
    {
        Task Upsert(ProductPropertyValue propertyValue);
    }
}
