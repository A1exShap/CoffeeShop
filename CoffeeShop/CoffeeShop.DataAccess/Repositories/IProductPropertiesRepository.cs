namespace CoffeeStore.DataAccess.Repositories
{
    public interface IProductPropertiesRepository
    {
        Task<(Guid id, short valueType)> GetPropertyParameters(string propertyName);
    }
}
